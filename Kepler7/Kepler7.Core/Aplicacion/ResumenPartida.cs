using Kepler7.Core.Dominio.Combate;

namespace Kepler7.Core.Aplicacion;

/// <summary>Datos de la pantalla final: qué pasó en la partida y qué se ganó.</summary>
public sealed record ResumenPartida(
    ResultadoCombate Resultado,
    int Rondas,
    int AliadosVivos,
    int AliadosTotales,
    int EnemigosDerrotados,
    int EnemigosTotales,
    int ComandosEjecutados,
    int XpGanada,
    int MonedasGanadas,
    int NivelAnterior,
    int NivelActual,
    IReadOnlyList<PatronGoF> PatronesNuevos)
{
    public bool Victoria => Resultado == ResultadoCombate.Victoria;
    public bool TiempoAgotado => Resultado == ResultadoCombate.TiempoAgotado;
    public bool SubioDeNivel => NivelActual > NivelAnterior;
}
