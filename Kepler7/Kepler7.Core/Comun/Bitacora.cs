namespace Kepler7.Core.Comun;

/// <summary>Severidad de una entrada de la bitácora (la UI puede mapearla a colores).</summary>
public enum NivelBitacora
{
    Info,
    Advertencia,
    Critico
}

/// <summary>Una línea del registro de eventos de la estación.</summary>
public sealed record EntradaBitacora(DateTime Fecha, string Origen, string Mensaje, NivelBitacora Nivel)
{
    public override string ToString() => $"[{Fecha:HH:mm:ss}] {Origen}: {Mensaje}";
}

/// <summary>
/// Canal por el que el Core "habla" con la interfaz sin conocerla.
/// La UI se suscribe a <see cref="EntradaRegistrada"/> y pinta lo que llega.
/// </summary>
public interface IBitacora
{
    /// <summary>Se dispara en el mismo hilo que llamó a <see cref="Registrar"/>; la UI debe hacer Invoke si hace falta.</summary>
    event EventHandler<EntradaBitacora>? EntradaRegistrada;

    IReadOnlyList<EntradaBitacora> Entradas { get; }

    void Registrar(string origen, string mensaje, NivelBitacora nivel = NivelBitacora.Info);
}

/// <summary>Implementación en memoria, segura entre hilos y con tope de capacidad.</summary>
public sealed class Bitacora : IBitacora
{
    private readonly List<EntradaBitacora> _entradas = new();
    private readonly object _candado = new();
    private readonly int _capacidad;

    public Bitacora(int capacidad = 1000)
    {
        if (capacidad <= 0) throw new ArgumentOutOfRangeException(nameof(capacidad));
        _capacidad = capacidad;
    }

    public event EventHandler<EntradaBitacora>? EntradaRegistrada;

    public IReadOnlyList<EntradaBitacora> Entradas
    {
        get { lock (_candado) return _entradas.ToArray(); }
    }

    public void Registrar(string origen, string mensaje, NivelBitacora nivel = NivelBitacora.Info)
    {
        var entrada = new EntradaBitacora(DateTime.Now, origen, mensaje, nivel);

        lock (_candado)
        {
            _entradas.Add(entrada);
            if (_entradas.Count > _capacidad) _entradas.RemoveAt(0);
        }

        EntradaRegistrada?.Invoke(this, entrada);
    }
}
