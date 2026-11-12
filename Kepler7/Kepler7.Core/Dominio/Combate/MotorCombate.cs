using Kepler7.Core.Comportamiento.Command;
using Kepler7.Core.Comportamiento.Strategy;
using Kepler7.Core.Comportamiento.TemplateMethod;
using Kepler7.Core.Comportamiento.Visitor;
using Kepler7.Core.Comun;

namespace Kepler7.Core.Dominio.Combate;

public enum ResultadoCombate
{
    EnCurso,
    Victoria,
    Derrota,
    TiempoAgotado
}

/// <summary>
/// Orquesta una batalla por rondas. Es el punto de entrada que usará la interfaz y donde se ven juntos
/// los patrones de comportamiento:
///  - TEMPLATE METHOD: <see cref="EjecutarTurnoAutomatico"/> juega el turno de una unidad aliada.
///  - COMMAND: todo lo que hacen las unidades pasa por <see cref="Comandos"/> (deshacer/rehacer).
///  - STRATEGY: en <see cref="TerminarRonda"/> cada enemigo decide con su IA intercambiable.
///  - STATE / CHAIN / VISITOR: viven dentro de los combatientes y del <see cref="Inventario"/>.
/// </summary>
public sealed class MotorCombate
{
    /// <summary>Rondas que dura un combate antes de cerrarse por tiempo si nadie ganó.</summary>
    public const int MaximoRondasPorDefecto = 30;
    private readonly HashSet<Personaje> _turnosJugados = new();
    private bool _inicioAnunciado;

    public MotorCombate(ContextoCombate contexto, BaseEstacion baseEstacion, Inventario inventario, IBitacora? bitacora = null,
                        int maximoRondas = MaximoRondasPorDefecto)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(maximoRondas, 1);
        MaximoRondas = maximoRondas;

        Contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));
        Base = baseEstacion ?? throw new ArgumentNullException(nameof(baseEstacion));
        Inventario = inventario ?? throw new ArgumentNullException(nameof(inventario));
        Bitacora = bitacora ?? new Bitacora();
        Comandos = new GestorComandos();
    }

    public ContextoCombate Contexto { get; }
    public BaseEstacion Base { get; }
    public Inventario Inventario { get; }
    public IBitacora Bitacora { get; }
    public GestorComandos Comandos { get; }
    public ResultadoCombate Resultado { get; private set; } = ResultadoCombate.EnCurso;

    /// <summary>Tope de rondas: si la última termina sin vencedor, el combate se cierra con TiempoAgotado</summary>
    public int MaximoRondas { get; }

    public event EventHandler<ResultadoCombate>? CombateTerminado;

    /// <summary>Juega automáticamente el turno de una unidad aliada según su clase (Template Method).</summary>
    public ResultadoTurno EjecutarTurnoAutomatico(Personaje personaje)
    {
        ArgumentNullException.ThrowIfNull(personaje);
        AnunciarInicio();

        if (Resultado != ResultadoCombate.EnCurso)
            return Omitido(personaje, "el combate ya terminó");

        if (_turnosJugados.Contains(personaje))
            return Omitido(personaje, "ya jugó en esta ronda");

        TurnoUnidad turno = CrearTurno(personaje);
        ResultadoTurno resultado = turno.EjecutarTurno();

        _turnosJugados.Add(personaje);
        EvaluarResultado();
        return resultado;
    }

    /// <summary>
    /// Cierra la ronda: las unidades que no jugaron cierran su turno (efectos de estado), actúan los enemigos
    /// según su estrategia, se limpia el historial deshacible y se evalúa victoria o derrota.
    /// </summary>
    public void TerminarRonda()
    {
        AnunciarInicio();
        if (Resultado != ResultadoCombate.EnCurso) return;

        foreach (Personaje aliado in Contexto.AliadosVivos.Where(a => !_turnosJugados.Contains(a)).ToList())
            Registrar(aliado.Nombre, aliado.FinalizarTurno().Mensaje);

        if (EvaluarResultado() != ResultadoCombate.EnCurso) return;

        FaseEnemiga();
        if (Resultado != ResultadoCombate.EnCurso) return;

        // Tope de rondas: si la última terminó y nadie ganó (ni perdió), el combate se cierra por tiempo.
        if (Contexto.Ronda >= MaximoRondas)
        {
            Terminar(ResultadoCombate.TiempoAgotado, $"TIEMPO AGOTADO: pasaron {MaximoRondas} rondas sin vencedor.", NivelBitacora.Advertencia);
            return;
        }

        Contexto.Ronda++;
        _turnosJugados.Clear();
        foreach (Combatiente c in Contexto.TodosVivos) c.NuevaRonda();
        Comandos.Limpiar(); // lo que ya pasó con los enemigos no se puede deshacer
        Registrar("Combate", $"=== Comienza la ronda {Contexto.Ronda} ===");
    }

    public ResultadoCombate EvaluarResultado()
    {
        if (Resultado != ResultadoCombate.EnCurso) return Resultado;

        ResultadoCombate nuevo =
            !Contexto.EnemigosVivos.Any() ? ResultadoCombate.Victoria :
            !Contexto.AliadosVivos.Any() ? ResultadoCombate.Derrota :
            ResultadoCombate.EnCurso;

        if (nuevo != ResultadoCombate.EnCurso)
        {
            Terminar(nuevo, nuevo == ResultadoCombate.Victoria
                ? "¡VICTORIA! Todos los enemigos fueron neutralizados."
                : "DERROTA: el escuadrón fue aniquilado.", nuevo == ResultadoCombate.Victoria ? NivelBitacora.Info : NivelBitacora.Critico);
        }

        return Resultado;
    }

    /// <summary>Punto único de cierre del combate: fija el resultado, lo registra y avisa a quien escuche.</summary>
    private void Terminar(ResultadoCombate resultado, string mensaje, NivelBitacora nivel)
    {
        Resultado = resultado;
        Registrar("Combate", mensaje, nivel);
        CombateTerminado?.Invoke(this, resultado);
    }

    // ---- Fase enemiga (STRATEGY) ----

    private void FaseEnemiga()
    {
        foreach (Enemigo enemigo in Contexto.EnemigosVivos.ToList())
        {
            if (!enemigo.EstaVivo) continue; // pudo caer por veneno de un turno anterior

            AccionIA decision = enemigo.Decidir(Contexto);
            Registrar(enemigo.Estrategia.Nombre, $"{enemigo.Nombre} decide: {decision.Razon}. → {decision}");

            ResultadoAccion resultado = Ejecutar(enemigo, decision);
            Registrar(enemigo.Nombre, resultado.Mensaje, resultado.Exito ? NivelBitacora.Info : NivelBitacora.Advertencia);

            Registrar(enemigo.Nombre, enemigo.FinalizarTurno().Mensaje);

            if (EvaluarResultado() != ResultadoCombate.EnCurso) return;
        }
    }

    /// <summary>Traduce la decisión de la IA en una acción real. Los enemigos reutilizan los mismos comandos que el jugador.</summary>
    private ResultadoAccion Ejecutar(Enemigo enemigo, AccionIA decision) => decision.Tipo switch
    {
        TipoAccionIA.Atacar => new AtacarComando(enemigo, decision.Objetivo!).Ejecutar(),
        TipoAccionIA.Mover => new MoverComando(enemigo, decision.Destino!.Value, Contexto).Ejecutar(),
        TipoAccionIA.Defender => enemigo.Defender(),
        _ => ResultadoAccion.Ok($"{enemigo.Nombre} espera.")
    };

    private TurnoUnidad CrearTurno(Personaje personaje) => personaje.Clase switch
    {
        ClaseUnidad.Soldado => new TurnoSoldado(personaje, Contexto, Comandos, Bitacora),
        ClaseUnidad.Medico => new TurnoMedico(personaje, Contexto, Comandos, Bitacora),
        ClaseUnidad.Francotirador => new TurnoFrancotirador(personaje, Contexto, Comandos, Bitacora),
        ClaseUnidad.Comandante => new TurnoComandante(personaje, Contexto, Comandos, Bitacora),
        _ => throw new ArgumentOutOfRangeException(nameof(personaje), personaje.Clase, "Clase de unidad sin turno definido.")
    };

    private static ResultadoTurno Omitido(Personaje personaje, string motivo) =>
        new(personaje.Nombre, new[] { new EtapaTurno("Omitido", $"{personaje.Nombre}: {motivo}.") });

    private void AnunciarInicio()
    {
        if (_inicioAnunciado) return;
        _inicioAnunciado = true;
        Registrar("Combate", $"=== Comienza el combate: {Contexto.Aliados.Count} aliados contra {Contexto.Enemigos.Count} enemigos (ronda {Contexto.Ronda}) ===");
    }

    private void Registrar(string origen, string mensaje, NivelBitacora nivel = NivelBitacora.Info) =>
        Bitacora.Registrar(origen, mensaje, nivel);
}
