namespace Kepler7.Core.Estructural.Proxy;

/// <summary>
/// SUJETO REAL: ejecuta las operaciones sin preguntar nada. No sabe de roles ni de permisos;
/// esa responsabilidad es del <see cref="ProxyBoveda"/>.
/// </summary>
public sealed class BovedaDatos : IBoveda
{
    private readonly Dictionary<string, string> _archivos = new(StringComparer.OrdinalIgnoreCase)
    {
        ["plano-reactor"] = "Planos del reactor de fusión de Kepler-7. Punto débil: el acoplamiento del conducto 4-B.",
        ["codigos-evacuacion"] = "Códigos de lanzamiento de las cápsulas de evacuación: ALFA-7-OMEGA.",
        ["informe-sabotaje"] = "Registros indican manipulación externa del sistema de navegación en el ciclo 4120.",
        ["diario-capitan"] = "Día 212: el Consejo oculta la verdadera causa de la crisis. No confío en nadie."
    };

    private readonly object _candado = new();

    public string LeerArchivo(string id)
    {
        lock (_candado)
        {
            return _archivos.TryGetValue(id, out string? contenido)
                ? contenido
                : throw new FileNotFoundException($"El archivo '{id}' no existe en la bóveda.");
        }
    }

    public void EscribirArchivo(string id, string contenido)
    {
        lock (_candado) _archivos[id] = contenido;
    }

    public IReadOnlyList<string> ListarArchivos()
    {
        lock (_candado) return _archivos.Keys.OrderBy(k => k).ToList();
    }
}
