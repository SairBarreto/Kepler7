using Kepler7.Core.Comportamiento.ChainOfResponsibility;
using Kepler7.Core.Comportamiento.State;
using Kepler7.Core.Comportamiento.Visitor;

namespace Kepler7.Core.Dominio.Combate;

/// <summary>Aviso de que un combatiente cambió de estado (la UI repinta su color o ícono).</summary>
public sealed record CambioEstado(Combatiente Combatiente, IEstadoPersonaje Anterior, IEstadoPersonaje Nuevo);

/// <summary>Foto del combatiente para poder deshacer acciones (patrón Memento, mínimo).</summary>
public sealed record SnapshotCombatiente(
    Posicion Posicion,
    int Vida,
    IReadOnlyDictionary<Escudo, int> Escudos,
    IEstadoPersonaje Estado);

/// <summary>
/// Cualquier unidad del tablero. Reúne los tres patrones que viven "dentro" de un combatiente:
///  - CHAIN: <see cref="Defensas"/> es su cadena de defensas.
///  - STATE: <see cref="Estado"/>; atacar, mover y recibir daño se delegan en él.
///  - VISITOR: el <see cref="ArmaEquipada"/> viene del inventario que los visitantes pueden modificar.
/// </summary>
public abstract class Combatiente
{
    protected Combatiente(string nombre, Posicion posicion, int ataque, int alcance, int movimiento, CadenaDefensa defensas)
    {
        Nombre = nombre;
        Posicion = posicion;
        Ataque = ataque;
        Alcance = alcance;
        Movimiento = movimiento;
        Defensas = defensas ?? throw new ArgumentNullException(nameof(defensas));
        Estado = new Normal();
    }

    public string Nombre { get; }
    public Posicion Posicion { get; internal set; }

    public int Ataque { get; }
    public int Alcance { get; }
    public int Movimiento { get; }

    public CadenaDefensa Defensas { get; }
    public Vida Vida => Defensas.Vida;
    public bool EstaVivo => Vida.EstaViva;

    public Arma? ArmaEquipada { get; private set; }
    public IEstadoPersonaje Estado { get; private set; }

    public event EventHandler<CambioEstado>? EstadoCambiado;

    /// <summary>Se dispara con cada golpe que llega a este combatiente, con el recorrido completo por la cadena de defensas.</summary>
    public event EventHandler<ResultadoDanio>? DanioRecibido;

    // ---- Presupuesto de acciones por ronda: 1 movimiento y 1 acción (atacar o curar) ----

    /// <summary>Ya movió en esta ronda. Lo marcan y desmarcan los comandos, por eso deshacer devuelve la acción.</summary>
    public bool HaMovido { get; internal set; }

    /// <summary>Ya atacó o curó en esta ronda.</summary>
    public bool HaActuado { get; internal set; }

    public bool PuedeMover => EstaVivo && !HaMovido;
    public bool PuedeActuar => EstaVivo && !HaActuado;

    /// <summary>Devuelve el presupuesto de acciones al comenzar una ronda.</summary>
    internal void NuevaRonda()
    {
        HaMovido = false;
        HaActuado = false;
    }

    /// <summary>Ataque base más el daño del arma equipada.</summary>
    public int PoderDeAtaque => Ataque + (ArmaEquipada?.Danio ?? 0);

    public TipoDanio TipoDeAtaque => ArmaEquipada?.Tipo ?? TipoDanio.Cinetico;

    /// <summary>Cuánto hay que "romper" para derrotarlo: vida más puntos de escudo.</summary>
    public int Resistencia => Vida.Actual + Defensas.Eslabones.OfType<Escudo>().Sum(e => e.Puntos);

    /// <summary>Casillas que puede recorrer ahora, según su estado.</summary>
    public int MovimientoDisponible => Estado.MovimientoPermitido(this);

    /// <summary>Alcance de ataque ahora, según su estado (0 = no puede atacar).</summary>
    public int AlcanceDisponible => Estado.AlcancePermitido(this);

    public void EquiparArma(Arma? arma) => ArmaEquipada = arma;

    /// <summary>Ajusta la capa de Armadura de su cadena (o la agrega si no tenía) con la defensa del ítem.</summary>
    public void EquiparArmadura(ArmaduraItem armadura)
    {
        Armadura? capa = Defensas.Buscar<Armadura>();
        if (capa is null)
        {
            int indice = Defensas.Eslabones.ToList().FindIndex(e => e is Escudo);
            Defensas.Agregar(new Armadura(armadura.Defensa), indice >= 0 ? indice : null);
        }
        else capa.Valor = Math.Max(capa.Valor, armadura.Defensa); // equipar nunca empeora la defensa
    }

    // ---- Delegación en el estado actual (STATE) ----

    public ResultadoAccion Atacar(Combatiente objetivo) => Estado.Atacar(this, objetivo);

    public ResultadoAccion Mover(Posicion destino, ContextoCombate contexto) => Estado.Mover(this, destino, contexto);

    public ResultadoDanio RecibirDanio(Danio danio)
    {
        ResultadoDanio resultado = Estado.RecibirDanio(this, danio);
        DanioRecibido?.Invoke(this, resultado);
        return resultado;
    }

    public ResultadoAccion FinalizarTurno() => Estado.AlFinalizarTurno(this);

    public void CambiarEstado(IEstadoPersonaje nuevo)
    {
        ArgumentNullException.ThrowIfNull(nuevo);

        IEstadoPersonaje anterior = Estado;
        Estado = nuevo;
        EstadoCambiado?.Invoke(this, new CambioEstado(this, anterior, nuevo));
    }

    /// <summary>Se cubre y recarga parte de su escudo.</summary>
    public ResultadoAccion Defender()
    {
        Escudo? escudo = Defensas.Buscar<Escudo>();
        if (escudo is null) return ResultadoAccion.Fallo($"{Nombre} no tiene escudo que reforzar.");

        int recuperado = escudo.Recargar(15);
        return ResultadoAccion.Ok($"{Nombre} se cubre y recarga {recuperado} de escudo ({escudo.Puntos}/{escudo.Maximo}).");
    }

    // ---- Memento mínimo para deshacer comandos ----

    public SnapshotCombatiente Capturar() => new(
        Posicion,
        Vida.Actual,
        Defensas.Eslabones.OfType<Escudo>().ToDictionary(e => e, e => e.Puntos),
        Estado);

    internal void Restaurar(SnapshotCombatiente foto)
    {
        Posicion = foto.Posicion;
        Vida.Actual = foto.Vida;

        foreach (var (escudo, puntos) in foto.Escudos) escudo.Puntos = puntos;

        if (!ReferenceEquals(Estado, foto.Estado)) CambiarEstado(foto.Estado);
    }

    public override string ToString() =>
        $"{Nombre} [{Estado.Nombre}] vida {Vida.Actual}/{Vida.Maxima} en {Posicion}";
}
