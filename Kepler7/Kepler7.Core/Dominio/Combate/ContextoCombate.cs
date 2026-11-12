namespace Kepler7.Core.Dominio.Combate;

/// <summary>
/// Todo lo que una IA, un turno o un comando necesitan saber del campo de batalla: quién está dónde,
/// qué casillas están libres y un generador de azar compartido (con semilla, para poder reproducir partidas).
/// </summary>
public sealed class ContextoCombate
{
    private readonly List<Personaje> _aliados = new();
    private readonly List<Enemigo> _enemigos = new();

    public ContextoCombate(int ancho = 8, int alto = 8, Random? azar = null)
    {
        Ancho = ancho;
        Alto = alto;
        Azar = azar ?? new Random();
    }

    public int Ancho { get; }
    public int Alto { get; }
    public Random Azar { get; }
    public int Ronda { get; internal set; } = 1;

    public IReadOnlyList<Personaje> Aliados => _aliados;
    public IReadOnlyList<Enemigo> Enemigos => _enemigos;

    public IEnumerable<Personaje> AliadosVivos => _aliados.Where(a => a.EstaVivo);
    public IEnumerable<Enemigo> EnemigosVivos => _enemigos.Where(e => e.EstaVivo);
    public IEnumerable<Combatiente> TodosVivos => AliadosVivos.Cast<Combatiente>().Concat(EnemigosVivos);

    public void Agregar(Personaje personaje) => _aliados.Add(personaje);
    public void Agregar(Enemigo enemigo) => _enemigos.Add(enemigo);

    public bool EnTablero(Posicion p) => p.X >= 0 && p.X < Ancho && p.Y >= 0 && p.Y < Alto;

    public Combatiente? EnPosicion(Posicion p) => TodosVivos.FirstOrDefault(c => c.Posicion == p);

    public bool EstaLibre(Posicion p) => EnTablero(p) && EnPosicion(p) is null;

    /// <summary>El candidato más cercano a <paramref name="desde"/> (desempata por nombre para ser determinista).</summary>
    public T? MasCercano<T>(Combatiente desde, IEnumerable<T> candidatos) where T : Combatiente =>
        candidatos
            .OrderBy(c => c.Posicion.Distancia(desde.Posicion))
            .ThenBy(c => c.Nombre, StringComparer.Ordinal)
            .FirstOrDefault();

    /// <summary>Casillas libres a las que el combatiente llega con <paramref name="pasos"/> pasos.</summary>
    public IReadOnlyList<Posicion> CasillasAlcanzables(Combatiente combatiente, int pasos)
    {
        var resultado = new List<Posicion>();

        for (int dx = -pasos; dx <= pasos; dx++)
        {
            int margenY = pasos - Math.Abs(dx);
            for (int dy = -margenY; dy <= margenY; dy++)
            {
                if (dx == 0 && dy == 0) continue;

                var casilla = new Posicion(combatiente.Posicion.X + dx, combatiente.Posicion.Y + dy);
                if (EstaLibre(casilla)) resultado.Add(casilla);
            }
        }

        return resultado;
    }

    /// <summary>La casilla alcanzable que más lo acerca a <paramref name="meta"/>; null si ninguna mejora su distancia actual.</summary>
    public Posicion? CasillaMasCercanaA(Combatiente combatiente, Posicion meta, int pasos)
    {
        int actual = combatiente.Posicion.Distancia(meta);
        Posicion? mejor = null;

        foreach (Posicion c in CasillasAlcanzables(combatiente, pasos))
        {
            if (mejor is null || EsMejorParaAcercarse(c, mejor.Value, meta, combatiente.Posicion)) mejor = c;
        }

        return mejor is { } m && m.Distancia(meta) < actual ? m : null;
    }

    /// <summary>La casilla alcanzable que más lo aleja de <paramref name="amenaza"/>; null si ninguna mejora su distancia actual.</summary>
    public Posicion? CasillaMasLejanaDe(Combatiente combatiente, Posicion amenaza, int pasos)
    {
        int actual = combatiente.Posicion.Distancia(amenaza);
        Posicion? mejor = null;

        foreach (Posicion c in CasillasAlcanzables(combatiente, pasos))
        {
            if (mejor is null || EsMejorParaAlejarse(c, mejor.Value, amenaza, combatiente.Posicion)) mejor = c;
        }

        return mejor is { } m && m.Distancia(amenaza) > actual ? m : null;
    }

    private static bool EsMejorParaAcercarse(Posicion candidata, Posicion mejor, Posicion meta, Posicion origen)
    {
        int dc = candidata.Distancia(meta), dm = mejor.Distancia(meta);
        if (dc != dm) return dc < dm;

        // Empate: la que menos camina; luego orden fijo para que el resultado sea reproducible.
        int pc = candidata.Distancia(origen), pm = mejor.Distancia(origen);
        if (pc != pm) return pc < pm;
        return (candidata.X, candidata.Y).CompareTo((mejor.X, mejor.Y)) < 0;
    }

    private static bool EsMejorParaAlejarse(Posicion candidata, Posicion mejor, Posicion amenaza, Posicion origen)
    {
        int dc = candidata.Distancia(amenaza), dm = mejor.Distancia(amenaza);
        if (dc != dm) return dc > dm;

        int pc = candidata.Distancia(origen), pm = mejor.Distancia(origen);
        if (pc != pm) return pc < pm;
        return (candidata.X, candidata.Y).CompareTo((mejor.X, mejor.Y)) < 0;
    }
}
