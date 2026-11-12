using Kepler7.Core.Comportamiento.ChainOfResponsibility;
using Kepler7.Core.Dominio.Combate;

namespace Kepler7.Core.Comportamiento.State;

/// <summary>
/// STATE: el combatiente no decide cómo ataca, se mueve o recibe daño; delega todo en su estado actual.
/// Cambiar de estado cambia el comportamiento sin un solo "if" en el combatiente.
/// Los estados son INMUTABLES: avanzar un turno de veneno significa pasar a un Envenenado con un turno menos.
/// </summary>
public interface IEstadoPersonaje
{
    string Nombre { get; }

    /// <summary>Color "#RRGGBB" para pintar al combatiente según su estado.</summary>
    string ColorHex { get; }

    /// <summary>Turnos que le quedan al estado (0 = permanente).</summary>
    int TurnosRestantes { get; }

    /// <summary>Restricción visible: algunos estados (Berserk) no aceptan curación.</summary>
    bool PermiteCuracion { get; }

    /// <summary>Cuántas casillas puede recorrer el combatiente en este estado.</summary>
    int MovimientoPermitido(Combatiente combatiente);
    /// <summary>Alcance de ataque en este estado (0 = no puede atacar). Lo usan los turnos automáticos para decidir si disparan o se acercan.</summary>
    int AlcancePermitido(Combatiente combatiente);

    ResultadoAccion Atacar(Combatiente atacante, Combatiente objetivo);
    ResultadoAccion Mover(Combatiente combatiente, Posicion destino, ContextoCombate contexto);
    ResultadoDanio RecibirDanio(Combatiente combatiente, Danio danio);

    /// <summary>Efectos de fin de turno (veneno, cuenta regresiva, transiciones de estado).</summary>
    ResultadoAccion AlFinalizarTurno(Combatiente combatiente);
}
