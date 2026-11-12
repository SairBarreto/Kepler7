namespace Kepler7.Core.Comportamiento.ChainOfResponsibility;

public enum TipoDanio
{
    Cinetico,
    Energia
}

/// <summary>Una "parada" del daño en la cadena: qué eslabón lo recibió y cuánto quedaba antes y después.</summary>
public sealed record PasoDanio(string Manejador, int RestanteAntes, int RestanteDespues, string Descripcion);

/// <summary>
/// Mensaje que viaja por la cadena de defensas. Cada eslabón lo reduce (o lo detiene) y deja
/// constancia en el <see cref="Trayecto"/>, que la interfaz usa para mostrar el recorrido del golpe.
/// </summary>
public sealed class Danio
{
    private readonly List<PasoDanio> _trayecto = new();

    public Danio(int cantidad, TipoDanio tipo, string origen)
    {
        Cantidad = Math.Max(0, cantidad);
        Restante = Cantidad;
        Tipo = tipo;
        Origen = origen;
    }

    /// <summary>Daño inicial del ataque.</summary>
    public int Cantidad { get; }

    public TipoDanio Tipo { get; }
    public string Origen { get; }

    /// <summary>Daño que todavía no fue absorbido por ningún eslabón.</summary>
    public int Restante { get; private set; }

    public bool Esquivado { get; private set; }

    /// <summary>Daño que finalmente llegó a los puntos de vida.</summary>
    public int DanioAVida { get; private set; }

    public IReadOnlyList<PasoDanio> Trayecto => _trayecto;

    // Los eslabones del Core son los únicos que modifican el daño; la UI solo lo lee.

    internal void Absorber(string manejador, int cantidad, string descripcion)
    {
        int absorbido = Math.Clamp(cantidad, 0, Restante);
        int antes = Restante;
        Restante -= absorbido;
        _trayecto.Add(new PasoDanio(manejador, antes, Restante, descripcion));
    }

    internal void Pasar(string manejador, string descripcion) =>
        _trayecto.Add(new PasoDanio(manejador, Restante, Restante, descripcion));

    internal void Esquivar(string manejador, string descripcion)
    {
        int antes = Restante;
        Restante = 0;
        Esquivado = true;
        _trayecto.Add(new PasoDanio(manejador, antes, 0, descripcion));
    }

    internal void AplicarAVida(string manejador, string descripcion)
    {
        int antes = Restante;
        DanioAVida = Restante;
        Restante = 0;
        _trayecto.Add(new PasoDanio(manejador, antes, 0, descripcion));
    }
}

/// <summary>Resumen del impacto, listo para mostrar en la bitácora o en un panel de combate.</summary>
public sealed record ResultadoDanio(
    string Objetivo,
    int DanioOriginal,
    int DanioAVida,
    bool Esquivado,
    bool ObjetivoDerrotado,
    IReadOnlyList<PasoDanio> Trayecto)
{
    /// <summary>Ej.: "Esquiva [14→14] → Armadura [14→11] → Escudo [11→1] → Vida [1→0]".</summary>
    public string Recorrido =>
        string.Join(" → ", Trayecto.Select(p => $"{p.Manejador} [{p.RestanteAntes}→{p.RestanteDespues}]"));

    public string Resumen
    {
        get
        {
            if (Esquivado) return $"{Objetivo} esquiva el golpe";
            if (DanioAVida == 0) return $"las defensas de {Objetivo} absorben todo el daño";
            return $"{Objetivo} recibe {DanioAVida} de daño" + (ObjetivoDerrotado ? " y cae fuera de combate" : "");
        }
    }
}
