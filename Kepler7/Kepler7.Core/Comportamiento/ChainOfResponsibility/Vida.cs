namespace Kepler7.Core.Comportamiento.ChainOfResponsibility;

/// <summary>
/// Último eslabón: lo que llega hasta acá lastima de verdad. Es TERMINAL: no tiene siguiente y la
/// <see cref="CadenaDefensa"/> garantiza que siempre esté al final. Además guarda los puntos de vida.
/// </summary>
public sealed class Vida : ManejadorDanioBase
{
    public Vida(int maxima)
    {
        Maxima = Math.Max(1, maxima);
        Actual = Maxima;
    }

    public int Maxima { get; }
    public int Actual { get; internal set; }
    public bool EstaViva => Actual > 0;

    public override string Nombre => "Vida";

    protected override void Procesar(Danio danio)
    {
        Actual = Math.Max(0, Actual - danio.Restante);
        danio.AplicarAVida(Nombre, $"Recibe {danio.Restante} de daño (vida {Actual}/{Maxima}).");
    }

    /// <summary>Devuelve cuánta vida se recuperó realmente.</summary>
    internal int Curar(int cantidad)
    {
        int antes = Actual;
        Actual = Math.Min(Maxima, Actual + Math.Max(0, cantidad));
        return Actual - antes;
    }

    /// <summary>Daño que se salta las defensas (veneno). Devuelve cuánto se aplicó.</summary>
    internal int AplicarDirecto(int cantidad)
    {
        int antes = Actual;
        Actual = Math.Max(0, Actual - Math.Max(0, cantidad));
        return antes - Actual;
    }
}
