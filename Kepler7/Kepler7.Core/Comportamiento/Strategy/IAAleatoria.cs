using Kepler7.Core.Dominio.Combate;

namespace Kepler7.Core.Comportamiento.Strategy;

/// <summary>Impredecible: elige al azar entre todas las acciones posibles en ese momento.</summary>
public sealed class IAAleatoria : IEstrategiaIA
{
    private readonly Random? _azarPropio;

    /// <summary>Si se indica, la IA sortea con este generador y no gasta el azar compartido de la partida.</summary>
    public IAAleatoria(Random? azarPropio = null) => _azarPropio = azarPropio;
    public string Nombre => "IA Aleatoria";

    public AccionIA DecidirAccion(Enemigo enemigo, ContextoCombate contexto)
    {
        Random azar = _azarPropio ?? contexto.Azar;
        var opciones = new List<AccionIA>();

        foreach (Personaje aliado in contexto.AliadosVivos)
        {
            if (enemigo.Posicion.Distancia(aliado.Posicion) <= enemigo.Alcance)
                opciones.Add(AccionIA.Atacar(aliado, $"tira los dados y se lanza contra {aliado.Nombre}"));
        }

        IReadOnlyList<Posicion> casillas = contexto.CasillasAlcanzables(enemigo, enemigo.MovimientoDisponible);
        if (casillas.Count > 0)
        {
            Posicion destino = casillas[azar.Next(casillas.Count)];
            opciones.Add(AccionIA.Mover(destino, $"tira los dados y deambula hacia {destino}"));
        }

        opciones.Add(AccionIA.Defender("tira los dados y se cubre"));
        opciones.Add(AccionIA.Esperar("tira los dados y no hace nada"));

        return opciones[azar.Next(opciones.Count)];
    }
}
