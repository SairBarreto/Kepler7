using Kepler7.Core.Comportamiento.ChainOfResponsibility;
using Kepler7.Core.Comportamiento.Strategy;

namespace Kepler7.Core.Dominio.Combate;

public sealed record CambioEstrategia(Enemigo Enemigo, IEstrategiaIA Anterior, IEstrategiaIA Nueva);

/// <summary>
/// Unidad hostil. Es el CONTEXTO del patrón Strategy: no sabe cómo decide, solo le pregunta a su
/// estrategia actual, que se puede reemplazar en cualquier momento de la partida.
/// </summary>
public sealed class Enemigo : Combatiente
{
    public Enemigo(string nombre, Posicion posicion, int ataque, int alcance, int movimiento,
                   CadenaDefensa defensas, IEstrategiaIA estrategia)
        : base(nombre, posicion, ataque, alcance, movimiento, defensas)
    {
        Estrategia = estrategia ?? throw new ArgumentNullException(nameof(estrategia));
    }

    public IEstrategiaIA Estrategia { get; private set; }

    /// <summary>Última decisión tomada: sirve para mostrar el efecto de cambiar la estrategia.</summary>
    public AccionIA? UltimaDecision { get; private set; }

    public event EventHandler<CambioEstrategia>? EstrategiaCambiada;

    public void CambiarEstrategia(IEstrategiaIA nueva)
    {
        ArgumentNullException.ThrowIfNull(nueva);

        IEstrategiaIA anterior = Estrategia;
        Estrategia = nueva;
        EstrategiaCambiada?.Invoke(this, new CambioEstrategia(this, anterior, nueva));
    }

    public AccionIA Decidir(ContextoCombate contexto)
    {
        UltimaDecision = Estrategia.DecidirAccion(this, contexto);
        return UltimaDecision;
    }
}
