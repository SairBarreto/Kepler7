using Kepler7.Core.Comportamiento.ChainOfResponsibility;
using Kepler7.Core.Dominio.Combate;

namespace Kepler7.Core.Comportamiento.State;

/// <summary>
/// Furia ciega: daña el doble pero solo cuerpo a cuerpo (alcance 1), corre una casilla más, recibe
/// +50% de daño y no acepta curación. Al terminar, el agotamiento lo deja aturdido un turno.
/// </summary>
public sealed class Berserk : EstadoPersonajeBase
{
    public const int DuracionPorDefecto = 3;

    public Berserk(int turnosRestantes = DuracionPorDefecto) : base(turnosRestantes) { }

    public override string Nombre => "Berserk";
    public override string ColorHex => "#F44336";
    public override bool PermiteCuracion => false;

    public override int MovimientoPermitido(Combatiente combatiente) => combatiente.Movimiento + 1;

    public override int AlcancePermitido(Combatiente combatiente) => Math.Min(1, combatiente.Alcance); // solo cuerpo a cuerpo

    public override ResultadoAccion Atacar(Combatiente atacante, Combatiente objetivo) =>
        EjecutarAtaque(atacante, objetivo, multiplicador: 2.0, alcance: AlcancePermitido(atacante));

    public override ResultadoAccion Mover(Combatiente combatiente, Posicion destino, ContextoCombate contexto) =>
        EjecutarMovimiento(combatiente, destino, contexto, MovimientoPermitido(combatiente));

    public override ResultadoDanio RecibirDanio(Combatiente combatiente, Danio danio) =>
        AplicarDanio(combatiente, danio, multiplicador: 1.5);

    public override ResultadoAccion AlFinalizarTurno(Combatiente combatiente)
    {
        int quedan = TurnosRestantes - 1;
        if (quedan <= 0)
        {
            combatiente.CambiarEstado(new Aturdido(1));
            return ResultadoAccion.Ok($"La furia de {combatiente.Nombre} se agota: queda aturdido por el esfuerzo.");
        }

        combatiente.CambiarEstado(new Berserk(quedan));
        return ResultadoAccion.Ok($"{combatiente.Nombre} sigue enfurecido ({quedan} turno(s) más).");
    }
}
