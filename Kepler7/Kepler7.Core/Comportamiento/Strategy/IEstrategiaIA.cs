using Kepler7.Core.Dominio.Combate;

namespace Kepler7.Core.Comportamiento.Strategy;

public enum TipoAccionIA
{
    Atacar,
    Mover,
    Defender,
    Esperar
}

/// <summary>
/// Decisión de una IA. Es solo una DESCRIPCIÓN de lo que el enemigo quiere hacer: decidir no modifica
/// nada, por eso se puede consultar a las cuatro estrategias sobre la misma situación y comparar.
/// </summary>
public sealed record AccionIA(TipoAccionIA Tipo, Combatiente? Objetivo, Posicion? Destino, string Razon)
{
    public static AccionIA Atacar(Combatiente objetivo, string razon) => new(TipoAccionIA.Atacar, objetivo, null, razon);
    public static AccionIA Mover(Posicion destino, string razon) => new(TipoAccionIA.Mover, null, destino, razon);
    public static AccionIA Defender(string razon) => new(TipoAccionIA.Defender, null, null, razon);
    public static AccionIA Esperar(string razon) => new(TipoAccionIA.Esperar, null, null, razon);

    public override string ToString() => Tipo switch
    {
        TipoAccionIA.Atacar => $"Atacar a {Objetivo?.Nombre}",
        TipoAccionIA.Mover => $"Mover a {Destino}",
        TipoAccionIA.Defender => "Defender",
        _ => "Esperar"
    };
}

/// <summary>
/// STRATEGY: algoritmo de decisión intercambiable. El enemigo conserva una referencia a la estrategia
/// y se la puede cambiar en pleno combate; su conducta cambia sin tocar la clase Enemigo.
/// </summary>
public interface IEstrategiaIA
{
    string Nombre { get; }
    AccionIA DecidirAccion(Enemigo enemigo, ContextoCombate contexto);
}
