using Kepler7.Core.Comportamiento.ChainOfResponsibility;

namespace Kepler7.Core.Comportamiento.Visitor;

/// <summary>Poción curativa. Si se contamina deja de ser utilizable.</summary>
public sealed class Pocion : IItem
{
    public Pocion(string nombre, int curacion, int precio)
    {
        Nombre = nombre;
        Curacion = curacion;
        Precio = precio;
    }

    public string Nombre { get; }
    public int Curacion { get; }
    public int Precio { get; }

    public bool Contaminada { get; internal set; }

    public void Aceptar(IVisitor visitante) => visitante.Visitar(this);
}
