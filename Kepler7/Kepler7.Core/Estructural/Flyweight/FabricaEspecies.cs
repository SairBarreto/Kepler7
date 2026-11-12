namespace Kepler7.Core.Estructural.Flyweight;

/// <summary>
/// FLYWEIGHT FACTORY: garantiza UNA sola instancia por especie. Si ya existe, la reutiliza;
/// si no, la crea y la guarda en el diccionario.
/// </summary>
public sealed class FabricaEspecies
{
    private readonly Dictionary<string, IEspecie> _especies = new(StringComparer.OrdinalIgnoreCase);
    private readonly object _candado = new();

    /// <summary>CONTADOR de la consigna: cuántos objetos Especie se crearon realmente (tope: 5).</summary>
    public int InstanciasCreadas { get; private set; }

    /// <summary>Cuántas veces se pidió una especie (en la demo: 10.000). Contrasta con <see cref="InstanciasCreadas"/>.</summary>
    public int SolicitudesAtendidas { get; private set; }

    /// <summary>Especies que la estación conoce.</summary>
    public IReadOnlyList<string> NombresDisponibles => CatalogoEspecies.Nombres;

    public IEspecie ObtenerEspecie(string nombre)
    {
        lock (_candado)
        {
            SolicitudesAtendidas++;

            if (_especies.TryGetValue(nombre, out IEspecie? existente))
                return existente;

            var datos = CatalogoEspecies.Buscar(nombre)
                ?? throw new ArgumentException($"Especie desconocida: {nombre}", nameof(nombre));

            IEspecie nueva = CatalogoEspecies.Crear(datos);
            _especies[datos.Nombre] = nueva;
            InstanciasCreadas++;
            return nueva;
        }
    }
}
