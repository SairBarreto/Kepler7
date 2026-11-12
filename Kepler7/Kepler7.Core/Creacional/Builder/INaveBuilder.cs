namespace Kepler7.Core.Creacional.Builder;

/// <summary>
/// BUILDER: define los pasos para ensamblar una <see cref="Nave"/>.
/// Cada receta concreta decide QUÉ pieza monta en cada paso (o ninguna);
/// el orden y la selección de pasos los decide el <see cref="IngenieroJefe"/>.
/// </summary>
public interface INaveBuilder
{
    /// <summary>Nombre de la receta para mostrar en la UI (ej. "Exploradora").</summary>
    string NombreReceta { get; }

    /// <summary>Descarta lo construido hasta el momento y empieza una nave nueva.</summary>
    void Reiniciar();

    void ConstruirCasco();
    void InstalarMotor();
    void InstalarEscudo();
    void InstalarArmas();
    void InstalarRadar();
    void InstalarIA();
    void AgregarTanquesCombustible();

    /// <summary>Entrega la nave terminada y deja al builder listo para la siguiente.</summary>
    Nave ObtenerNave();
}
