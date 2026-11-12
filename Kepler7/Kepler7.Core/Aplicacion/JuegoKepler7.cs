using Kepler7.Core.Comportamiento.Command;
using Kepler7.Core.Comun;
using Kepler7.Core.Creacional.Prototype;
using Kepler7.Core.Dominio;
using Kepler7.Core.Dominio.Combate;
using Kepler7.Core.Estructural.Facade;
using Kepler7.Core.Estructural.Flyweight;
using Kepler7.Core.Estructural.Proxy;
using Kepler7.Core.Persistencia;

namespace Kepler7.Core.Aplicacion;

/// <summary>
/// SINGLETON: el único punto de acceso al motor del juego. Los formularios no crean subsistemas por su
/// cuenta; le piden todo a <see cref="Instancia"/>, de modo que la estación, la base, el progreso y el
/// combate en curso son los mismos objetos sin importar desde qué pantalla se mire.
///
/// No es uno de los doce patrones del TP: es la pieza que los reúne. Por eso también concentra las
/// reglas del juego que no pertenecen a ningún patrón (recompensas, XP, insignias, guardado).
///
/// Instancia perezosa y segura entre hilos (<see cref="Lazy{T}"/>), constructor privado y sin estado
/// global mutable fuera de lo que expone.
/// </summary>
public sealed class JuegoKepler7
{
    private const int XpPorPatron = 25;

    private static readonly Lazy<JuegoKepler7> _instancia =
        new(() => new JuegoKepler7(new AlmacenJson()), LazyThreadSafetyMode.ExecutionAndPublication);

    /// <summary>La única instancia del juego.</summary>
    public static JuegoKepler7 Instancia => _instancia.Value;

    private readonly AlmacenJson _almacen;
    private readonly List<PatronGoF> _patronesDePartida = new();
    private int _nivelAlIniciarPartida;

    private JuegoKepler7(AlmacenJson almacen)
    {
        _almacen = almacen;

        Progreso = _almacen.Cargar("progreso.json", () => new ProgresoJugador());
        Progreso.PatronesDominados ??= new List<PatronGoF>();
        Bitacora = new Bitacora();

        // Estación: la fachada y la base comparten bitácora, así la UI tiene un único registro que mostrar.
        Control = new ControlCentral(Bitacora);
        Base = new BaseEstacion(Progreso.Monedas);
        ComandosEstacion = new GestorComandos();
        Laboratorio = new LaboratorioClonacion();
        Fabrica = new FabricaEspecies();

        // Proxy de la bóveda: protege el acceso según el rol de la sesión.
        Sesion = new Sesion(new Usuario("Capitán", RolUsuario.Capitan));
        Accesos = new RegistroAccesosDenegados(_almacen);
        Boveda = new ProxyBoveda(new BovedaDatos(), Sesion, Accesos, Bitacora);

        // Patrones que ya emiten eventos: se dominan solos al usarlos.
        Control.ModoCambiado += (_, _) => Dominar(PatronGoF.Facade);
        Accesos.IntentoRegistrado += (_, _) => Dominar(PatronGoF.Proxy);

        // Las monedas viven en la base; cada cambio se refleja en el progreso y se guarda.
        Base.Cambio += (_, _) =>
        {
            Progreso.Monedas = Base.Creditos;
            Guardar();
        };
    }

    // ---- Servicios compartidos ----

    public ProgresoJugador Progreso { get; }
    public IBitacora Bitacora { get; }
    public Sesion Sesion { get; }

    /// <summary>FACADE de la estación (arrancar, emergencia, apagar).</summary>
    public ControlCentral Control { get; }

    public BaseEstacion Base { get; }

    /// <summary>COMMAND: historial deshacible de la base (construcción de naves).</summary>
    public GestorComandos ComandosEstacion { get; }

    public LaboratorioClonacion Laboratorio { get; }
    public FabricaEspecies Fabrica { get; }

    /// <summary>PROXY de la bóveda de datos.</summary>
    public IBoveda Boveda { get; }

    public RegistroAccesosDenegados Accesos { get; }

    // ---- Partida en curso ----

    public MotorCombate? Combate { get; private set; }
    public ResumenPartida? UltimoResumen { get; private set; }

    /// <summary>Se dispara cuando se obtiene una insignia nueva.</summary>
    public event EventHandler<PatronGoF>? PatronDominado;

    /// <summary>Se dispara cuando termina un combate, con el resumen listo para la pantalla final.</summary>
    public event EventHandler<ResumenPartida>? PartidaFinalizada;

    /// <summary>Arma un combate nuevo con el escenario de Kepler-7, compartiendo la base y la bitácora del juego.</summary>
    public MotorCombate NuevoCombate(int? semilla = null)
    {
        _patronesDePartida.Clear();
        _nivelAlIniciarPartida = Progreso.Nivel;
        UltimoResumen = null;

        MotorCombate motor = EscenarioCombate.Crear(semilla ?? Random.Shared.Next(1, 1_000_000), bitacora: Bitacora, baseEstacion: Base);
        Combate = motor;
        ConectarPatrones(motor);
        return motor;
    }

    // ---- Progreso ----

    /// <summary>Marca una insignia. Las repetidas no hacen nada; la primera suma XP y se guarda al instante.</summary>
    public bool Dominar(PatronGoF patron)
    {
        if (Progreso.PatronesDominados.Contains(patron)) return false;

        Progreso.PatronesDominados.Add(patron);
        Progreso.Xp += XpPorPatron;
        _patronesDePartida.Add(patron);
        Guardar();

        PatronDominado?.Invoke(this, patron);
        return true;
    }

    public bool EstaDominado(PatronGoF patron) => Progreso.PatronesDominados.Contains(patron);

    public void MarcarTutorialVisto()
    {
        Progreso.TutorialVisto = true;
        Guardar();
    }

    public void Guardar() => _almacen.Guardar("progreso.json", Progreso);

    // ---- Interno ----

    /// <summary>
    /// Engancha los patrones que producen eventos durante el combate. Así el juego no depende de que cada
    /// botón se acuerde de avisar: el logro se otorga cuando la mecánica realmente ocurre.
    /// </summary>
    private void ConectarPatrones(MotorCombate motor)
    {
        foreach (Combatiente c in motor.Contexto.Aliados.Cast<Combatiente>().Concat(motor.Contexto.Enemigos))
        {
            c.DanioRecibido += (_, _) => Dominar(PatronGoF.ChainOfResponsibility);
            c.EstadoCambiado += (_, _) => Dominar(PatronGoF.State);
        }

        foreach (Enemigo e in motor.Contexto.Enemigos)
            e.EstrategiaCambiada += (_, _) => Dominar(PatronGoF.Strategy);

        motor.Comandos.Cambio += (_, _) =>
        {
            IReadOnlyList<string> historial = motor.Comandos.Historial;
            if (historial.Count > 0 && historial[^1].StartsWith("Deshecho", StringComparison.Ordinal))
                Dominar(PatronGoF.Command);
        };

        motor.CombateTerminado += (_, resultado) => FinalizarPartida(motor, resultado);
    }

    private void FinalizarPartida(MotorCombate motor, ResultadoCombate resultado)
    {
        bool victoria = resultado == ResultadoCombate.Victoria;
        int vivos = motor.Contexto.AliadosVivos.Count();
        int totalAliados = motor.Contexto.Aliados.Count;
        int totalEnemigos = motor.Contexto.Enemigos.Count;
        int derrotados = totalEnemigos - motor.Contexto.EnemigosVivos.Count();

        int xp = victoria ? 80 + 20 * vivos : 25 + 5 * derrotados;
        int monedas = victoria ? 400 + 100 * vivos : 100;

        Progreso.Xp += xp;
        if (victoria) Progreso.PartidasGanadas++; else Progreso.PartidasPerdidas++;

        Base.Reembolsar(monedas); // dispara Base.Cambio: sincroniza monedas y guarda el progreso
        Guardar();

        int comandos = motor.Comandos.Historial.Count(h => h.StartsWith("Ejecutado", StringComparison.Ordinal));

        UltimoResumen = new ResumenPartida(
            resultado, motor.Contexto.Ronda, vivos, totalAliados, derrotados, totalEnemigos, comandos,
            xp, monedas, _nivelAlIniciarPartida, Progreso.Nivel, _patronesDePartida.ToArray());

        PartidaFinalizada?.Invoke(this, UltimoResumen);
    }
}
