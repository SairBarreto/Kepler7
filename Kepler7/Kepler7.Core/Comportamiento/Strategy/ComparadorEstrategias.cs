using Kepler7.Core.Dominio.Combate;

namespace Kepler7.Core.Comportamiento.Strategy;

/// <summary>Lo que decidiría una estrategia concreta en la situación actual.</summary>
public sealed record DecisionEstrategia(string Estrategia, AccionIA Accion);

/// <summary>
/// Pregunta a todas las estrategias qué harían el enemigo en el estado actual del campo, sin ejecutar
/// nada. Es la forma más clara de VER el efecto de cambiar la IA durante la partida.
/// </summary>
public static class ComparadorEstrategias
{
    public static IReadOnlyList<IEstrategiaIA> EstrategiasDisponibles() => new IEstrategiaIA[]
    {
        new IAAgresiva(),
        new IADefensiva(),
        new IAAleatoria(),
        new IACalculadora()
    };

    public static IReadOnlyList<DecisionEstrategia> Comparar(Enemigo enemigo, ContextoCombate contexto)
    {
        ArgumentNullException.ThrowIfNull(enemigo);
        ArgumentNullException.ThrowIfNull(contexto);
        
        IEstrategiaIA[] consulta = { new IAAgresiva(), new IADefensiva(), new IAAleatoria(new Random()), new IACalculadora() };

        return consulta
            .Select(e => new DecisionEstrategia(e.Nombre, e.DecidirAccion(enemigo, contexto)))
            .ToList();
    }
}
