namespace Kepler7.Core.Comportamiento.ChainOfResponsibility;

/// <summary>
/// CHAIN OF RESPONSIBILITY: cada capa de defensa decide si absorbe el daño (total o parcialmente)
/// o si lo transfiere al eslabón siguiente. El atacante no sabe qué capas existen.
/// </summary>
public interface IManejadorDanio
{
    string Nombre { get; }
    IManejadorDanio? Siguiente { get; }

    /// <summary>Lo usa <see cref="CadenaDefensa"/> para (re)enlazar la cadena cuando se agregan, quitan o reordenan eslabones.</summary>
    void EstablecerSiguiente(IManejadorDanio? siguiente);

    void Manejar(Danio danio);
}

/// <summary>
/// Resuelve el enlace y el "¿sigo pasando?" una sola vez: el eslabón aplica su regla en
/// <see cref="Procesar"/> y, si todavía queda daño, la base lo reenvía al siguiente.
/// </summary>
public abstract class ManejadorDanioBase : IManejadorDanio
{
    public abstract string Nombre { get; }
    public IManejadorDanio? Siguiente { get; private set; }

    public void EstablecerSiguiente(IManejadorDanio? siguiente) => Siguiente = siguiente;

    public void Manejar(Danio danio)
    {
        Procesar(danio);

        // Si este eslabón detuvo el golpe (esquivó o absorbió todo), la cadena termina acá.
        if (danio.Restante > 0) Siguiente?.Manejar(danio);
    }

    protected abstract void Procesar(Danio danio);
}
