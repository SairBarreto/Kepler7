using Kepler7.Core.Comportamiento.ChainOfResponsibility;
using Kepler7.Core.Dominio.Combate;

namespace Kepler7.Core.Comportamiento.State;

/// <summary>Sin alteraciones: usa sus capacidades al 100%.</summary>
public sealed class Normal : EstadoPersonajeBase
{
    public override string Nombre => "Normal";
    public override string ColorHex => "#4CAF50";

    public override int MovimientoPermitido(Combatiente combatiente) => combatiente.Movimiento;

    public override ResultadoAccion Atacar(Combatiente atacante, Combatiente objetivo) =>
        EjecutarAtaque(atacante, objetivo, multiplicador: 1.0, alcance: atacante.Alcance);

    public override ResultadoAccion Mover(Combatiente combatiente, Posicion destino, ContextoCombate contexto) =>
        EjecutarMovimiento(combatiente, destino, contexto, MovimientoPermitido(combatiente));

    public override ResultadoDanio RecibirDanio(Combatiente combatiente, Danio danio) =>
        AplicarDanio(combatiente, danio, multiplicador: 1.0);
}
