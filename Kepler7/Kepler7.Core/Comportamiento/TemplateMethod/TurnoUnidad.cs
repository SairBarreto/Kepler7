using Kepler7.Core.Comportamiento.Command;
using Kepler7.Core.Comun;
using Kepler7.Core.Dominio.Combate;

namespace Kepler7.Core.Comportamiento.TemplateMethod;

/// <summary>Una línea del historial de turnos: en qué etapa ocurrió y qué pasó.</summary>
public sealed record EtapaTurno(string Etapa, string Descripcion);

/// <summary>Todo lo que ocurrió en un turno, etapa por etapa.</summary>
public sealed record ResultadoTurno(string Unidad, IReadOnlyList<EtapaTurno> Etapas);

/// <summary>
/// TEMPLATE METHOD: el turno de TODAS las unidades sigue siempre el mismo orden (inicio, decisión, acción,
/// finalización). <see cref="EjecutarTurno"/> no es virtual: fija el esqueleto. Las subclases solo
/// redefinen los pasos variables (la decisión es obligatoria; el resto, opcional).
/// </summary>
public abstract class TurnoUnidad
{
    private readonly List<EtapaTurno> _etapas = new();
    private readonly IBitacora? _bitacora;
    private string _etapaActual = string.Empty;

    protected TurnoUnidad(Personaje unidad, ContextoCombate contexto, GestorComandos comandos, IBitacora? bitacora = null)
    {
        Unidad = unidad ?? throw new ArgumentNullException(nameof(unidad));
        Contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));
        Comandos = comandos ?? throw new ArgumentNullException(nameof(comandos));
        _bitacora = bitacora;
    }

    protected Personaje Unidad { get; }
    protected ContextoCombate Contexto { get; }
    protected GestorComandos Comandos { get; }

    /// <summary>El esqueleto del algoritmo. NO es virtual: el orden de las etapas no se puede alterar.</summary>
    public ResultadoTurno EjecutarTurno()
    {
        _etapas.Clear();

        if (!Unidad.EstaVivo)
        {
            EjecutarEtapa("Inicio", () => Registrar($"{Unidad.Nombre} está fuera de combate: pierde el turno."));
            return new ResultadoTurno(Unidad.Nombre, _etapas.ToArray());
        }

        IComando? decision = null;

        EjecutarEtapa("1. Inicio", Inicio);
        EjecutarEtapa("2. Decisión", () => decision = Decidir());
        EjecutarEtapa("3. Acción", () => Actuar(decision));
        EjecutarEtapa("4. Finalización", Finalizacion);

        return new ResultadoTurno(Unidad.Nombre, _etapas.ToArray());
    }

    #region Funciones virtuales
    /// <summary>Paso 1 (virtual): preparación del turno.</summary>
    protected virtual void Inicio() =>
        Registrar($"{Unidad.Nombre} ({Unidad.Clase}) empieza su turno en {Unidad.Posicion}, estado {Unidad.Estado.Nombre}, vida {Unidad.Vida.Actual}/{Unidad.Vida.Maxima}.");

    /// <summary>Paso 2 (ABSTRACTO): cada clase decide a su manera. Devuelve el comando elegido, o null si prefiere esperar.</summary>
    protected abstract IComando? Decidir();

    /// <summary>Paso 3 (virtual): por defecto ejecuta la decisión a través del GestorComandos (queda en el historial y se puede deshacer).</summary>
    protected virtual void Actuar(IComando? comando)
    {
        if (comando is null)
        {
            Registrar("No hay ninguna acción útil: espera.");
            return;
        }

        ResultadoAccion resultado = Comandos.Ejecutar(comando);
        Registrar(resultado.Exito ? resultado.Mensaje : $"Acción fallida: {resultado.Mensaje}");
    }

    /// <summary>Paso 4 (virtual): cierre del turno; por defecto aplica los efectos de fin de turno del estado.</summary>
    protected virtual void Finalizacion() => Registrar(Unidad.FinalizarTurno().Mensaje);
    #endregion

    #region Utilidades para las subclases
    /// <summary>Registra una línea en el historial del turno (y en la bitácora, si hay).</summary>
    protected void Registrar(string descripcion)
    {
        _etapas.Add(new EtapaTurno(_etapaActual, descripcion));
        _bitacora?.Registrar($"Turno {Unidad.Clase}", $"[{Unidad.Nombre}] {_etapaActual}: {descripcion}");
    }

    /// <summary>Si el objetivo está a tiro lo ataca; si no, avanza hacia él. Devuelve null si no hay camino útil.</summary>
    protected IComando? AtacarOAcercarse(Combatiente objetivo)
    {
        int distancia = Unidad.Posicion.Distancia(objetivo.Posicion);
        int alcance = Unidad.AlcanceDisponible; // depende del estado: Berserk solo cuerpo a cuerpo, Aturdido no ataca

        if (alcance == 0)
        {
            Registrar($"{Unidad.Nombre} está {Unidad.Estado.Nombre} y no puede atacar: espera.");
            return null;
        }

        if (distancia <= alcance)
        {
            Registrar($"{objetivo.Nombre} está a {distancia} (alcance {alcance}): ataca.");
            return new AtacarComando(Unidad, objetivo);
        }

        Posicion? destino = Contexto.CasillaMasCercanaA(Unidad, objetivo.Posicion, Unidad.MovimientoDisponible);
        if (destino is { } d)
        {
            Registrar($"{objetivo.Nombre} está a {distancia} (alcance {alcance}): avanza a {d}.");
            return new MoverComando(Unidad, d, Contexto);
        }

        Registrar($"No encuentra un camino útil hacia {objetivo.Nombre}.");
        return null;
    }

    private void EjecutarEtapa(string nombre, Action paso)
    {
        _etapaActual = nombre;
        paso();
    }
    #endregion
}
