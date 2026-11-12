namespace Kepler7.Core.Comportamiento.Visitor;

/// <summary>
/// ELEMENTO del Visitor. Cada ítem solo sabe "aceptar" a un visitante y decirle quién es
/// (double dispatch): así se agregan operaciones nuevas al inventario sin tocar estas clases.
/// </summary>
public interface IItem
{
    string Nombre { get; }
    int Precio { get; }
    void Aceptar(IVisitor visitante);
}

/// <summary>
/// VISITANTE: una operación sobre el inventario, con un método por tipo de ítem.
/// Cada instancia acumula su resultado: se crea una nueva por cada aplicación.
/// </summary>
public interface IVisitor
{
    string Nombre { get; }

    void Visitar(Arma arma);
    void Visitar(Pocion pocion);
    void Visitar(ArmaduraItem armadura);

    /// <summary>Texto con lo que calculó o modificó, para mostrar en la interfaz.</summary>
    string ObtenerResultado();
}
