using Kepler7.Core.Comportamiento.ChainOfResponsibility;

namespace Kepler7.Core.Comportamiento.Visitor;

/// <summary>
/// Armadura del inventario (se llama ArmaduraItem para no chocar con <see cref="ChainOfResponsibility.Armadura"/>,
/// el eslabón de la cadena de defensas: una es el objeto que se guarda, la otra la capa que protege).
/// </summary>
public sealed class ArmaduraItem : IItem
{
    public ArmaduraItem(string nombre, int defensa, int precio)
    {
        Nombre = nombre;
        Defensa = defensa;
        Precio = precio;
    }

    public string Nombre { get; }
    public int Defensa { get; }
    public int Precio { get; }

    public void Aceptar(IVisitor visitante) => visitante.Visitar(this);
}
