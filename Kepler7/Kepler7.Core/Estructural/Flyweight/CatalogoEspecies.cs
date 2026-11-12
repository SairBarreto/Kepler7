namespace Kepler7.Core.Estructural.Flyweight;

/// <summary>Implementación concreta del flyweight. Constructor interno: solo se crea desde el Core.</summary>
internal sealed class Especie : IEspecie
{
    internal Especie(string nombre, string colorHex, string planetaOrigen, string dieta)
    {
        Nombre = nombre;
        ColorHex = colorHex;
        PlanetaOrigen = planetaOrigen;
        Dieta = dieta;
    }

    public string Nombre { get; }
    public string ColorHex { get; }
    public string PlanetaOrigen { get; }
    public string Dieta { get; }
}

/// <summary>Datos de las cinco especies de Kepler-7 (la "fuente" desde donde se construyen los flyweights).</summary>
internal static class CatalogoEspecies
{
    internal sealed record DatosEspecie(string Nombre, string ColorHex, string PlanetaOrigen, string Dieta);

    private static readonly DatosEspecie[] Datos =
    {
        new("Humano",     "#4FA3FF", "Tierra",         "Omnívora"),
        new("Velkariano", "#E5484D", "Velkar Prime",   "Carnívora"),
        new("Lithoide",   "#A0A0A8", "Petra IX",       "Minerales"),
        new("Aquarion",   "#2EC4B6", "Thalassa",       "Fitoplancton"),
        new("Synthiano",  "#F5B700", "Fábrica Orión",  "Energía eléctrica")
    };

    internal static IReadOnlyList<string> Nombres { get; } = Datos.Select(d => d.Nombre).ToArray();

    internal static DatosEspecie? Buscar(string nombre) =>
        Datos.FirstOrDefault(d => string.Equals(d.Nombre, nombre, StringComparison.OrdinalIgnoreCase));

    /// <summary>
    /// Crea una especie PRIVADA (sin compartir) con copias propias de los textos, como si cada
    /// tripulante cargara su ficha desde disco. Solo la usa la comparación "sin Flyweight".
    /// </summary>
    internal static IEspecie CrearIndependiente(string nombre)
    {
        DatosEspecie d = Buscar(nombre) ?? throw new ArgumentException($"Especie desconocida: {nombre}", nameof(nombre));

        return new Especie(
            new string(d.Nombre.AsSpan()),
            new string(d.ColorHex.AsSpan()),
            new string(d.PlanetaOrigen.AsSpan()),
            new string(d.Dieta.AsSpan()));
    }

    internal static IEspecie Crear(DatosEspecie d) => new Especie(d.Nombre, d.ColorHex, d.PlanetaOrigen, d.Dieta);
}
