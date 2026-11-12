using Kepler7.Core.Comportamiento.ChainOfResponsibility;
using Kepler7.Core.Dominio.Combate;

namespace Kepler7.Core.Comportamiento.State;

/// <summary>
/// Debilitado por veneno: ataca al 75%, camina una casilla menos y, al terminar cada turno, pierde vida
/// directamente (el veneno ignora la cadena de defensas). Una curación lo elimina.
/// </summary>
public sealed class Envenenado : EstadoPersonajeBase
{
    public const int DuracionPorDefecto = 3;
    public const int DanioPorTurno = 5;

    public Envenenado(int turnosRestantes = DuracionPorDefecto) : base(turnosRestantes) { }

    public override string Nombre => "Envenenado";
    public override string ColorHex => "#9C27B0";

    public override int MovimientoPermitido(Combatiente combatiente) => Math.Max(1, combatiente.Movimiento - 1);

    public override ResultadoAccion Atacar(Combatiente atacante, Combatiente objetivo) =>
        EjecutarAtaque(atacante, objetivo, multiplicador: 0.75, alcance: atacante.Alcance);

    public override ResultadoAccion Mover(Combatiente combatiente, Posicion destino, ContextoCombate contexto) =>
        EjecutarMovimiento(combatiente, destino, contexto, MovimientoPermitido(combatiente));

    public override ResultadoDanio RecibirDanio(Combatiente combatiente, Danio danio) =>
        AplicarDanio(combatiente, danio, multiplicador: 1.0);

    public override ResultadoAccion AlFinalizarTurno(Combatiente combatiente)
    {
        int aplicado = combatiente.Vida.AplicarDirecto(DanioPorTurno);

        if (!combatiente.EstaVivo)
            return ResultadoAccion.Ok($"{combatiente.Nombre} sucumbe al veneno (-{aplicado}).");

        int quedan = TurnosRestantes - 1;
        if (quedan <= 0)
        {
            combatiente.CambiarEstado(new Normal());
            return ResultadoAccion.Ok($"El veneno hace efecto (-{aplicado}) y luego se disipa: {combatiente.Nombre} vuelve a la normalidad.");
        }

        combatiente.CambiarEstado(new Envenenado(quedan));
        return ResultadoAccion.Ok($"El veneno hace efecto: {combatiente.Nombre} pierde {aplicado} de vida ({quedan} turno(s) más).");
    }
}
