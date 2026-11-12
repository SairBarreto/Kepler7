using Kepler7.Core.Creacional.Prototype;

namespace Kepler7.Core.Dominio;

/// <summary>
/// Objeto anidado dentro de <see cref="Tripulante"/>. Existe, entre otras cosas, para demostrar
/// que la clonación es profunda: si el Tripulante copiara solo la referencia, clon y original
/// compartirían estos valores.
/// </summary>
public sealed class AtributosTripulante : IPrototipo<AtributosTripulante>
{
    public int Salud { get; set; } = 100;
    public int Fuerza { get; set; } = 10;
    public int Inteligencia { get; set; } = 10;
    public int Agilidad { get; set; } = 10;

    public AtributosTripulante Clonar() => new()
    {
        Salud = Salud,
        Fuerza = Fuerza,
        Inteligencia = Inteligencia,
        Agilidad = Agilidad
    };

    public override string ToString() =>
        $"Salud {Salud}, Fuerza {Fuerza}, Inteligencia {Inteligencia}, Agilidad {Agilidad}";
}
