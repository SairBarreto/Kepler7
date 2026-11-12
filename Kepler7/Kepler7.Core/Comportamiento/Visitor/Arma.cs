using Kepler7.Core.Comportamiento.ChainOfResponsibility;

namespace Kepler7.Core.Comportamiento.Visitor;

/// <summary>Arma del inventario. Si está envenenada, cada golpe que conecta envenena al objetivo.</summary>
public sealed class Arma : IItem
{
    public Arma(string nombre, int danio, int precio, TipoDanio tipo = TipoDanio.Cinetico)
    {
        Nombre = nombre;
        Danio = danio;
        Precio = precio;
        Tipo = tipo;
    }

    public string Nombre { get; }
    public int Danio { get; }
    public int Precio { get; }
    public TipoDanio Tipo { get; }

    /// <summary>Solo los visitantes del Core la modifican (ver AplicadorVeneno).</summary>
    public bool Venenosa { get; internal set; }
    /// <summary>Si es true, cada golpe que conecta aturde al objetivo un turno (ver EstadoPersonajeBase.EjecutarAtaque).</summary>
    public bool Aturdidora { get; internal set; }
    public void Aceptar(IVisitor visitante) => visitante.Visitar(this);
}
