using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kepler7.Core.Persistencia;

/// <summary>Ubicaciones de archivos del juego. Nunca se escribe junto al ejecutable.</summary>
public static class RutasKepler7
{
    /// <summary>%AppData%\Kepler7\ en Windows.</summary>
    public static string CarpetaDatos =>
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Kepler7");
}

/// <summary>
/// Lectura/escritura de objetos como JSON (System.Text.Json) dentro de una carpeta.
/// La carpeta es inyectable para poder probar sin tocar el AppData real.
/// </summary>
public sealed class AlmacenJson
{
    private static readonly JsonSerializerOptions Opciones = new()
    {
        WriteIndented = true,
        Converters = { new JsonStringEnumConverter() }
    };

    public AlmacenJson(string? carpeta = null)
    {
        Carpeta = carpeta ?? RutasKepler7.CarpetaDatos;
    }

    public string Carpeta { get; }

    /// <summary>Carga el archivo; si no existe o está corrupto devuelve el valor por defecto.</summary>
    public T Cargar<T>(string archivo, Func<T> valorPorDefecto)
    {
        string ruta = Path.Combine(Carpeta, archivo);
        if (!File.Exists(ruta)) return valorPorDefecto();

        try
        {
            using var flujo = File.OpenRead(ruta);
            return JsonSerializer.Deserialize<T>(flujo, Opciones) ?? valorPorDefecto();
        }
        catch (JsonException)
        {
            Resguardar(ruta); // no pisar el archivo dañado: queda como .bak
            return valorPorDefecto();
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            return valorPorDefecto(); // archivo bloqueado o sin permisos: el juego arranca igual
        }
    }

    private static void Resguardar(string ruta)
    {
        try 
        { 
            File.Move(ruta, ruta + ".bak", overwrite: true); 
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException) { } //si no se puede resguardar, se sigue
    }

    /// <summary>Guarda de forma atómica: escribe a un temporal y luego reemplaza, para no dejar JSON a medias.</summary>
    public bool Guardar<T>(string archivo, T datos)
    {
        try
        {
            Directory.CreateDirectory(Carpeta);

            string ruta = Path.Combine(Carpeta, archivo);
            string temporal = ruta + ".tmp";

            File.WriteAllText(temporal, JsonSerializer.Serialize(datos, Opciones));
            File.Move(temporal, ruta, overwrite: true);
            return true;
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            return false; // un fallo de disco no debe tumbar la partida
        }
    }
}
