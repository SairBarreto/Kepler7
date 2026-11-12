using Kepler7.Core.Dominio.Combate;

namespace Kepler7.Core.Comportamiento.Strategy;

/// <summary>Va siempre por el enemigo más cercano: si lo tiene a tiro ataca, si no, avanza hacia él.</summary>
public sealed class IAAgresiva : IEstrategiaIA
{
    public string Nombre => "IA Agresiva";

    public AccionIA DecidirAccion(Enemigo enemigo, ContextoCombate contexto)
    {
        Personaje? objetivo = contexto.MasCercano(enemigo, contexto.AliadosVivos);
        if (objetivo is null) return AccionIA.Esperar("no quedan objetivos");

        int distancia = enemigo.Posicion.Distancia(objetivo.Posicion);
        if (distancia <= enemigo.Alcance)
            return AccionIA.Atacar(objetivo, $"embiste a {objetivo.Nombre}, el más cercano (a {distancia})");

        Posicion? destino = contexto.CasillaMasCercanaA(enemigo, objetivo.Posicion, enemigo.MovimientoDisponible);
        return destino is { } d
            ? AccionIA.Mover(d, $"avanza hacia {objetivo.Nombre} sin importar el riesgo")
            : AccionIA.Esperar($"no encuentra camino hacia {objetivo.Nombre}");
    }
}
