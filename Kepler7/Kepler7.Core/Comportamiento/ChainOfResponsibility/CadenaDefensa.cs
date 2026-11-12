namespace Kepler7.Core.Comportamiento.ChainOfResponsibility;

/// <summary>
/// Administra la cadena de un combatiente: permite construirla, agregar, quitar y reordenar eslabones
/// en tiempo de ejecución. Después de cada cambio vuelve a enlazar los eslabones y mantiene a
/// <see cref="Vida"/> siempre al final.
/// </summary>
public sealed class CadenaDefensa
{
    private readonly List<IManejadorDanio> _eslabones = new();

    public CadenaDefensa(Vida vida)
    {
        Vida = vida ?? throw new ArgumentNullException(nameof(vida));
        _eslabones.Add(vida);
        Reenlazar();
    }

    public Vida Vida { get; }

    /// <summary>Copia del orden actual (el primero recibe el golpe, el último es siempre Vida).</summary>
    public IReadOnlyList<IManejadorDanio> Eslabones => _eslabones.ToArray();

    /// <summary>Se dispara cuando cambia la composición u orden de la cadena (para refrescar la UI).</summary>
    public event EventHandler? Cambio;

    /// <summary>Texto para mostrar, ej.: "Esquiva → Bloqueo → Armadura → Escudo → Vida".</summary>
    public string Descripcion => string.Join(" → ", _eslabones.Select(e => e.Nombre));

    /// <summary>Inserta un eslabón en la posición indicada; por defecto, justo antes de Vida.</summary>
    public void Agregar(IManejadorDanio eslabon, int? indice = null)
    {
        ArgumentNullException.ThrowIfNull(eslabon);
        if (ReferenceEquals(eslabon, Vida) || _eslabones.Contains(eslabon))
            throw new ArgumentException("Ese eslabón ya forma parte de la cadena.", nameof(eslabon));

        int posicion = Math.Clamp(indice ?? _eslabones.Count - 1, 0, _eslabones.Count - 1);
        _eslabones.Insert(posicion, eslabon);
        Reenlazar();
    }

    /// <summary>Quita un eslabón. La vida no se puede quitar (devuelve false).</summary>
    public bool Quitar(IManejadorDanio eslabon)
    {
        if (ReferenceEquals(eslabon, Vida)) return false;
        if (!_eslabones.Remove(eslabon)) return false;

        eslabon.EstablecerSiguiente(null);
        Reenlazar();
        return true;
    }

    /// <summary>Reubica un eslabón. Nunca puede pasar por detrás de Vida.</summary>
    public bool Mover(IManejadorDanio eslabon, int nuevoIndice)
    {
        if (ReferenceEquals(eslabon, Vida) || !_eslabones.Remove(eslabon)) return false;

        int posicion = Math.Clamp(nuevoIndice, 0, _eslabones.Count - 1);
        _eslabones.Insert(posicion, eslabon);
        Reenlazar();
        return true;
    }

    public T? Buscar<T>() where T : class, IManejadorDanio => _eslabones.OfType<T>().FirstOrDefault();

    /// <summary>Lanza el daño por la cadena y devuelve el resumen del recorrido.</summary>
    public ResultadoDanio Procesar(Danio danio, string nombreObjetivo)
    {
        ArgumentNullException.ThrowIfNull(danio);

        _eslabones[0].Manejar(danio);

        return new ResultadoDanio(
            nombreObjetivo,
            danio.Cantidad,
            danio.DanioAVida,
            danio.Esquivado,
            !Vida.EstaViva,
            danio.Trayecto.ToArray());
    }

    /// <summary>Construye la cadena clásica Esquiva → Bloqueo → Armadura → Escudo → Vida (omite lo que valga 0).</summary>
    public static CadenaDefensa Estandar(int vida, int armadura, int escudo, double esquiva, double bloqueo, Random azar)
    {
        var cadena = new CadenaDefensa(new Vida(vida));

        if (esquiva > 0) cadena.Agregar(new Esquiva(esquiva, azar));
        if (bloqueo > 0) cadena.Agregar(new Bloqueo(bloqueo, 0.5, azar));
        if (armadura > 0) cadena.Agregar(new Armadura(armadura));
        if (escudo > 0) cadena.Agregar(new Escudo(escudo));

        return cadena;
    }

    private void Reenlazar()
    {
        for (int i = 0; i < _eslabones.Count; i++)
            _eslabones[i].EstablecerSiguiente(i + 1 < _eslabones.Count ? _eslabones[i + 1] : null);

        Cambio?.Invoke(this, EventArgs.Empty);
    }
}
