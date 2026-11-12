using System.Text.Json.Serialization;

namespace Kepler7.Core.Aplicacion;

/// <summary>
/// Lo que se guarda entre ejecuciones (progreso.json en %AppData%\Kepler7): experiencia, monedas,
/// historial de partidas y patrones dominados. Es un contenedor de datos: la lógica de recompensas
/// vive en <see cref="JuegoKepler7"/>.
/// </summary>
public sealed class ProgresoJugador
{
    public const int XpPorNivel = 100;
    public const int MonedasIniciales = 3000;

    public int Xp { get; set; }
    public int Monedas { get; set; } = MonedasIniciales;
    public int PartidasGanadas { get; set; }
    public int PartidasPerdidas { get; set; }
    public bool TutorialVisto { get; set; }

    /// <summary>Insignias obtenidas (los nombres de enum se guardan como texto en el JSON).</summary>
    public List<PatronGoF> PatronesDominados { get; set; } = new();

    [JsonIgnore] public int Nivel => 1 + Xp / XpPorNivel;
    [JsonIgnore] public int XpEnNivel => Xp % XpPorNivel;
}
