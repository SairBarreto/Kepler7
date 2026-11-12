namespace Kepler7.Core.Estructural.Flyweight;

/// <summary>
/// FLYWEIGHT: estado INTRÍNSECO de una especie. Es inmutable, idéntico para todos los
/// tripulantes de esa especie y por eso se comparte (solo existen cinco en toda la estación).
/// </summary>
public interface IEspecie
{
    string Nombre { get; }

    /// <summary>Color en formato "#RRGGBB". El Core no usa System.Drawing; la UI lo convierte.</summary>
    string ColorHex { get; }

    string PlanetaOrigen { get; }
    string Dieta { get; }
}
