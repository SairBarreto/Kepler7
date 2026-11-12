namespace Kepler7.Core.Creacional.Prototype;

/// <summary>
/// PROTOTYPE: un objeto que sabe producir una copia independiente de sí mismo.
/// Es genérica para que Clonar() devuelva el tipo concreto y no haga falta castear.
/// </summary>
public interface IPrototipo<out T>
{
    /// <summary>Copia PROFUNDA: modificar la copia nunca debe alterar al original.</summary>
    T Clonar();
}
