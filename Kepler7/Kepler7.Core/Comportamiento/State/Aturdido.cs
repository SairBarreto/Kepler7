using Kepler7.Core.Comportamiento.ChainOfResponsibility;
using Kepler7.Core.Dominio.Combate;

namespace Kepler7.Core.Comportamiento.State;

/// <summary>Fuera de eje: no puede atacar, solo da un paso por turno y queda más expuesto (+25% de daño recibido).</summary>
public sealed class Aturdido : EstadoPersonajeBase
{
    public const int DuracionPorDefecto = 2;

    public Aturdido(int turnosRestantes = DuracionPorDefecto) : base(turnosRestantes) { }

    public override string Nombre => "Aturdido";
    public override string ColorHex => "#FFC107";

    public override int MovimientoPermitido(Combatiente combatiente) => 1;

    public override int AlcancePermitido(Combatiente combatiente) => 0; // no puede atacar

    public override ResultadoAccion Atacar(Combatiente atacante, Combatiente objetivo) =>
        ResultadoAccion.Fallo($"{atacante.Nombre} está aturdido y no puede atacar.");

    public override ResultadoAccion Mover(Combatiente combatiente, Posicion destino, ContextoCombate contexto) =>
        EjecutarMovimiento(combatiente, destino, contexto, MovimientoPermitido(combatiente));

    public override ResultadoDanio RecibirDanio(Combatiente combatiente, Danio danio) =>
        AplicarDanio(combatiente, danio, multiplicador: 1.25);

    public override ResultadoAccion AlFinalizarTurno(Combatiente combatiente)
    {
        int quedan = TurnosRestantes - 1;
        if (quedan <= 0)
        {
            combatiente.CambiarEstado(new Normal());
            return ResultadoAccion.Ok($"{combatiente.Nombre} se recupera del aturdimiento.");
        }

        combatiente.CambiarEstado(new Aturdido(quedan));
        return ResultadoAccion.Ok($"{combatiente.Nombre} sigue aturdido ({quedan} turno(s) más).");
    }
}
