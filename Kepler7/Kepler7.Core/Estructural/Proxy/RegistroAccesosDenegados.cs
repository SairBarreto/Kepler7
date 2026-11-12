using Kepler7.Core.Dominio;
using Kepler7.Core.Persistencia;

namespace Kepler7.Core.Estructural.Proxy;

/// <summary>Un intento rechazado por el Proxy. Se guarda en UTC; la UI lo convierte a hora local.</summary>
public sealed record IntentoAcceso(DateTime FechaUtc, string Usuario, RolUsuario Rol, string Operacion, string ArchivoId);

/// <summary>Se lanza cuando el Proxy rechaza una operación. Transporta el intento para que la UI lo muestre.</summary>
public sealed class AccesoDenegadoException : Exception
{
    public AccesoDenegadoException(IntentoAcceso intento)
        : base($"Acceso denegado: {intento.Usuario} ({intento.Rol.ATexto()}) no puede ejecutar '{intento.Operacion}' sobre '{intento.ArchivoId}'.")
    {
        Intento = intento;
    }

    public IntentoAcceso Intento { get; }
}

/// <summary>
/// Registro PERSISTENTE de los intentos denegados: se carga al arrancar y se guarda a disco
/// (JSON en %AppData%\Kepler7\) cada vez que se agrega uno, así sobrevive entre ejecuciones.
/// </summary>
public sealed class RegistroAccesosDenegados
{
    private const string Archivo = "accesos_denegados.json";
    private const int MaximoEntradas = 500;

    private readonly AlmacenJson _almacen;
    private readonly List<IntentoAcceso> _intentos;
    private readonly object _candado = new();

    public RegistroAccesosDenegados(AlmacenJson? almacen = null)
    {
        _almacen = almacen ?? new AlmacenJson();
        _intentos = _almacen.Cargar(Archivo, () => new List<IntentoAcceso>());
    }

    public event EventHandler<IntentoAcceso>? IntentoRegistrado;

    public IReadOnlyList<IntentoAcceso> Intentos
    {
        get { lock (_candado) return _intentos.ToArray(); }
    }

    public void Registrar(IntentoAcceso intento)
    {
        lock (_candado)
        {
            _intentos.Add(intento);
            if (_intentos.Count > MaximoEntradas) _intentos.RemoveAt(0);
            _almacen.Guardar(Archivo, _intentos);
        }

        IntentoRegistrado?.Invoke(this, intento);
    }
}
