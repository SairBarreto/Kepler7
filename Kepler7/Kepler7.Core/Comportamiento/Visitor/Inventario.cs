using Kepler7.Core.Comportamiento.ChainOfResponsibility;

namespace Kepler7.Core.Comportamiento.Visitor;

/// <summary>ESTRUCTURA de objetos del Visitor: la bodega del escuadrón.</summary>
public sealed class Inventario
{
    private readonly List<IItem> _items = new();

    public IReadOnlyList<IItem> Items => _items;

    public event EventHandler? Cambio;

    public void Agregar(IItem item)
    {
        ArgumentNullException.ThrowIfNull(item);
        _items.Add(item);
        Cambio?.Invoke(this, EventArgs.Empty);
    }

    public bool Quitar(IItem item)
    {
        bool quitado = _items.Remove(item);
        if (quitado) Cambio?.Invoke(this, EventArgs.Empty);
        return quitado;
    }

    public IEnumerable<T> De<T>() where T : IItem => _items.OfType<T>();

    /// <summary>Recorre todos los ítems con el visitante y devuelve su resultado.</summary>
    public string Aplicar(IVisitor visitante)
    {
        ArgumentNullException.ThrowIfNull(visitante);

        foreach (IItem item in _items) item.Aceptar(visitante);

        Cambio?.Invoke(this, EventArgs.Empty); // algunos visitantes modifican ítems
        return visitante.ObtenerResultado();
    }

    /// <summary>Equipo inicial del escuadrón.</summary>
    public static Inventario Inicial()
    {
        var inventario = new Inventario();
        inventario.Agregar(new Arma("Rifle de pulsos", 20, 450));
        inventario.Agregar(new Arma("Rifle de francotirador", 32, 800));
        inventario.Agregar(new Arma("Pistola de plasma", 16, 380, TipoDanio.Energia) { Aturdidora = true });
        inventario.Agregar(new Pocion("Nanobots reparadores", 30, 80));
        inventario.Agregar(new Pocion("Estimulante celular", 45, 140));
        inventario.Agregar(new ArmaduraItem("Chaleco balístico", 3, 300));
        inventario.Agregar(new ArmaduraItem("Exoesqueleto pesado", 6, 650));
        return inventario;
    }
}
