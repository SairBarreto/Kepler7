using Kepler7.Core.Dominio;

namespace Kepler7.Core.Estructural.Flyweight;

/// <summary>Puebla la estación con tripulantes. Cada uno obtiene su especie a través de la fábrica.</summary>
public static class GeneradorTripulantes
{
    /// <summary>Población total de Kepler-7.</summary>
    public const int PoblacionEstacion = 10_000;

    private static readonly string[] Nombres =
    {
        "Aria", "Bruno", "Camila", "Darío", "Elena", "Facundo", "Greta", "Hugo", "Ines", "Joaquín",
        "Katya", "Lucas", "Mara", "Nico", "Olivia", "Pablo", "Quinn", "Rocío", "Santi", "Tamara"
    };

    private static readonly string[] Apellidos =
    {
        "Vega", "Ortiz", "Nakamura", "Petrov", "Silva", "Okafor", "Lindqvist", "Moreau",
        "Duarte", "Haddad", "Ferrari", "Zhang", "Kowalski", "Benítez", "Rojas", "Aguirre"
    };

    /// <summary>Genera tripulantes compartiendo especies mediante la <paramref name="fabrica"/> (CON Flyweight).</summary>
    public static List<Tripulante> Generar(int cantidad, FabricaEspecies fabrica, int? semilla = null)
    {
        ArgumentNullException.ThrowIfNull(fabrica);
        return GenerarCon(cantidad, fabrica.ObtenerEspecie, semilla);
    }

    /// <summary>Núcleo común: el "proveedor" decide si la especie se comparte o se duplica.</summary>
    internal static List<Tripulante> GenerarCon(int cantidad, Func<string, IEspecie> proveedorEspecie, int? semilla)
    {
        if (cantidad < 0) throw new ArgumentOutOfRangeException(nameof(cantidad));

        var azar = semilla.HasValue ? new Random(semilla.Value) : new Random();
        var especies = CatalogoEspecies.Nombres;
        var lista = new List<Tripulante>(cantidad);

        for (int id = 1; id <= cantidad; id++)
        {
            string especie = especies[azar.Next(especies.Count)];
            string nombre = $"{Nombres[azar.Next(Nombres.Length)]} {Apellidos[azar.Next(Apellidos.Length)]}";
            lista.Add(new Tripulante(id, nombre, ElegirRango(azar), proveedorEspecie(especie)));
        }

        return lista;
    }

    // Pirámide jerárquica: muchos cadetes, pocos capitanes.
    private static RangoTripulante ElegirRango(Random azar)
    {
        int tirada = azar.Next(100);
        return tirada switch
        {
            < 55 => RangoTripulante.Cadete,
            < 85 => RangoTripulante.Tecnico,
            < 97 => RangoTripulante.Oficial,
            _ => RangoTripulante.Capitan
        };
    }
}
