using Kepler7.Core.Creacional.Prototype;
using Kepler7.Core.Estructural.Flyweight;

namespace Kepler7.Core.Dominio;

public enum RangoTripulante
{
    Cadete,
    Tecnico,
    Oficial,
    Capitan
}

/// <summary>
/// Entidad compartida por dos patrones:
///  - FLYWEIGHT: Nombre, Id y Rango son estado EXTRÍNSECO (propio de cada tripulante); la
///    <see cref="Especie"/> es estado INTRÍNSECO y se comparte entre miles de tripulantes.
///  - PROTOTYPE: <see cref="Clonar"/> hace una copia profunda de todo lo que es propio del
///    tripulante (habilidades y atributos) pero NO copia la especie: el flyweight se comparte
///    por diseño, clonarlo rompería la garantía de "una instancia por especie".
/// </summary>
public sealed class Tripulante : IPrototipo<Tripulante>
{
    public Tripulante(int id, string nombre, RangoTripulante rango, IEspecie especie,
                      IEnumerable<string>? habilidades = null, AtributosTripulante? atributos = null)
    {
        Id = id;
        Nombre = nombre;
        Rango = rango;
        Especie = especie ?? throw new ArgumentNullException(nameof(especie));
        Habilidades = habilidades is null ? new List<string>() : new List<string>(habilidades);
        Atributos = atributos ?? new AtributosTripulante();
    }

    /// <summary>Constructor de copia: solo lo usa <see cref="Clonar"/>.</summary>
    private Tripulante(Tripulante original)
    {
        Id = original.Id;
        Nombre = original.Nombre;
        Rango = original.Rango;
        Especie = original.Especie;                           // flyweight: se comparte
        Habilidades = new List<string>(original.Habilidades); // colección nueva
        Atributos = original.Atributos.Clonar();              // objeto anidado nuevo
    }

    /// <summary>Identificador único. Lo reasigna el laboratorio al registrar un clon.</summary>
    public int Id { get; internal set; }

    public string Nombre { get; set; }
    public RangoTripulante Rango { get; set; }

    /// <summary>Estado intrínseco compartido (Flyweight).</summary>
    public IEspecie Especie { get; }

    public List<string> Habilidades { get; }
    public AtributosTripulante Atributos { get; }

    public Tripulante Clonar() => new(this);

    public override string ToString() =>
        $"#{Id} {Nombre} | {Rango} | {Especie.Nombre} | Habilidades: [{string.Join(", ", Habilidades)}] | {Atributos}";
}
