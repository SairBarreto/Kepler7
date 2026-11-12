using Kepler7.Core.Dominio.Combate;

namespace Kepler7.Core.Comportamiento.Strategy;

/// <summary>
/// Evalúa a cada objetivo con números: premia poder rematar a uno herido, apuntar al médico (el que
/// sostiene al escuadrón) y golpear a los más frágiles. Si nadie está a tiro, se acerca al mejor blanco.
/// </summary>
public sealed class IACalculadora : IEstrategiaIA
{
    private const double BonoRemate = 100;
    private const double BonoMedico = 25;

    public string Nombre => "IA Calculadora";

    public AccionIA DecidirAccion(Enemigo enemigo, ContextoCombate contexto)
    {
        List<Personaje> aliados = contexto.AliadosVivos.ToList();
        if (aliados.Count == 0) return AccionIA.Esperar("no quedan objetivos");

        // 1) Entre los que están a tiro, el de mayor puntaje.
        Personaje? aTiro = aliados
            .Where(a => enemigo.Posicion.Distancia(a.Posicion) <= enemigo.Alcance)
            .OrderByDescending(a => Puntaje(enemigo, a))
            .ThenBy(a => a.Nombre, StringComparer.Ordinal)
            .FirstOrDefault();

        if (aTiro is not null)
        {
            bool remate = enemigo.PoderDeAtaque >= aTiro.Resistencia;
            return AccionIA.Atacar(aTiro,
                $"calcula {Puntaje(enemigo, aTiro):F0} puntos sobre {aTiro.Nombre} " +
                (remate ? $"(puede rematarlo: ataque {enemigo.PoderDeAtaque} ≥ resistencia {aTiro.Resistencia})"
                        : $"(resistencia {aTiro.Resistencia}, ataque {enemigo.PoderDeAtaque})"));
        }

        // 2) Nadie a tiro: va hacia el mejor blanco global.
        Personaje mejor = aliados
            .OrderByDescending(a => Puntaje(enemigo, a))
            .ThenBy(a => a.Nombre, StringComparer.Ordinal)
            .First();

        Posicion? destino = contexto.CasillaMasCercanaA(enemigo, mejor.Posicion, enemigo.MovimientoDisponible);
        return destino is { } d
            ? AccionIA.Mover(d, $"se posiciona para alcanzar a {mejor.Nombre}, su blanco más rentable")
            : AccionIA.Esperar($"no puede acercarse a {mejor.Nombre}");
    }

    private static double Puntaje(Enemigo enemigo, Personaje objetivo)
    {
        double puntaje = 100.0 * enemigo.PoderDeAtaque / Math.Max(1, objetivo.Resistencia);

        if (enemigo.PoderDeAtaque >= objetivo.Resistencia) puntaje += BonoRemate;
        if (objetivo.Clase == ClaseUnidad.Medico) puntaje += BonoMedico;

        return puntaje;
    }
}
