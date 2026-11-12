using Kepler7.Core.Aplicacion;
using Kepler7.Core.Comportamiento.ChainOfResponsibility;
using Kepler7.Core.Comportamiento.Command;
using Kepler7.Core.Comportamiento.State;
using Kepler7.Core.Comportamiento.Strategy;
using Kepler7.Core.Comportamiento.TemplateMethod;
using Kepler7.Core.Comportamiento.Visitor;
using Kepler7.Core.Comun;
using Kepler7.Core.Dominio.Combate;
using Kepler7.Game.Controles;
using Kepler7.Game.Visual;

namespace Kepler7.Game.Formularios;

/// <summary>
/// Pantalla de combate (estática). No contiene reglas: cada botón arma un comando (o llama al motor) y después se
/// redibuja leyendo el estado del Core. El tablero usa colores funcionales y los paneles muestran el resultado por escrito.
///  - COMMAND ........ Mover/Atacar/Curar crean comandos que se envían a <c>Motor.Comandos</c>; Deshacer/Rehacer.
///  - TEMPLATE METHOD  «Turno automático» juega las 4 etapas de la clase de la unidad (se leen en la bitácora).
///  - STRATEGY ....... el panel de IA cambia la estrategia del enemigo elegido y muestra su efecto.
///  - CHAIN .......... cada golpe informa su recorrido; el panel de defensas reordena las capas en caliente.
///  - STATE .......... el anillo de color de cada unidad y sus restricciones salen del estado actual.
///  - VISITOR ........ el panel de inventario aplica visitantes a las armas y pociones.
/// </summary>
internal sealed partial class FormCombate : Form
{
    private static readonly (string Nombre, Func<IVisitor> Crear)[] Visitantes =
    {
        ("Calculador de precio", () => new CalculadorPrecio()),
        ("Contador de armas", () => new ContadorArmas()),
        ("Aplicador de veneno", () => new AplicadorVeneno()),
        ("Generador de estadísticas", () => new GeneradorEstadisticas())
    };

    private readonly JuegoKepler7 _juego = JuegoKepler7.Instancia;     // SINGLETON
    private readonly MotorCombate _motor;

    private Combatiente? _seleccion;
    private ModoAccion _modo = ModoAccion.Ninguno;
    private bool _terminado;
    private ResumenPartida? _resumenPendiente;

    public FormCombate()
    {
        InitializeComponent();

        cboNuevaCapa.SelectedIndex = 0;
        cboVisitante.SelectedIndex = 0; 

        // El Singleton arma el combate con la base y la bitácora compartidas del juego.
        _motor = _juego.NuevoCombate();

        Text = $"{Equipo.Juego} — Combate";
        foreach (IEstrategiaIA estrategia in ComparadorEstrategias.EstrategiasDisponibles()) cboEstrategia.Items.Add(estrategia.Nombre);

        Conectar();

        tablero.Contexto = _motor.Contexto;
        Seleccionar(_motor.Contexto.AliadosVivos.FirstOrDefault());
        Mensaje("Elegí una unidad en el tablero y usá las acciones. Cuando termines, «Terminar ronda».", true);
    }

    // =====================================================================
    // Conexión con el Core
    // =====================================================================

    private void Conectar()
    {
        // Eventos del Core -> la interfaz solo se redibuja.
        _juego.Bitacora.EntradaRegistrada += AlRegistrar;
        _juego.PartidaFinalizada += AlFinalizarPartida;
        _juego.PatronDominado += AlDominarPatron;
        _motor.Comandos.Cambio += AlCambiarComandos;

        foreach (Combatiente c in Todos()) c.DanioRecibido += AlRecibirDanio;
    }

    private void Desconectar()
    {
        _juego.Bitacora.EntradaRegistrada -= AlRegistrar;
        _juego.PartidaFinalizada -= AlFinalizarPartida;
        _juego.PatronDominado -= AlDominarPatron;
        _motor.Comandos.Cambio -= AlCambiarComandos;

        foreach (Combatiente c in Todos()) c.DanioRecibido -= AlRecibirDanio;
    }

    private IEnumerable<Combatiente> Todos() =>
        _motor.Contexto.Aliados.Cast<Combatiente>().Concat(_motor.Contexto.Enemigos);

    private void AlRegistrar(object? sender, EntradaBitacora entrada) =>
        Ui.EnUi(this, () => Ui.AgregarAlFinal(lstBitacora, entrada.ToString(), 600));

    private void AlCambiarComandos(object? sender, EventArgs e) => Ui.EnUi(this, RefrescarHistorial);

    private void AlDominarPatron(object? sender, PatronGoF patron) =>
        Ui.EnUi(this, () => lblAviso.Text = $"Insignia «{patron.Insignia()}» ({patron.Nombre()})  +25 XP");

    /// <summary>CHAIN: cada golpe llega con su recorrido por las capas de defensa. La interfaz muestra ese recorrido por escrito.</summary>
    private void AlRecibirDanio(object? sender, ResultadoDanio resultado)
    {
        lblUltimoGolpe.Text = $"Último golpe — {resultado.Objetivo}:{Environment.NewLine}{resultado.Recorrido}{Environment.NewLine}{resultado.Resumen}";
    }

    private void AlFinalizarPartida(object? sender, ResumenPartida resumen) => Ui.EnUi(this, () =>
    {
        // Sólo se anota: el resumen se abre cuando termina la acción en curso (ver Ejecutar).
        _terminado = true;
        _resumenPendiente = resumen;
        CancelarModo();
        Refrescar();
        Mensaje(resumen.Victoria ? "¡Victoria! Todos los enemigos fueron neutralizados."
              : resumen.TiempoAgotado ? $"Tiempo agotado: pasaron {_motor.MaximoRondas} rondas sin vencedor."
              : "Derrota: el escuadrón fue aniquilado.", resumen.Victoria);
    });

    // =====================================================================
    // Selección y modos de acción
    // =====================================================================

    private void Seleccionar(Combatiente? combatiente)
    {
        _seleccion = combatiente;
        CancelarModo();
        Refrescar();
    }

    private void ElegirModo(ModoAccion modo)
    {
        _modo = _modo == modo ? ModoAccion.Ninguno : modo; // pulsar de nuevo cancela
        Refrescar();

        string ayuda = _modo switch
        {
            ModoAccion.Mover => "Hacé clic en una casilla verde para mover.",
            ModoAccion.Atacar => "Hacé clic en un enemigo marcado en rojo.",
            ModoAccion.Curar => "Hacé clic en un aliado marcado en verde.",
            _ => "Acción cancelada."
        };
        Mensaje(ayuda, true);
    }

    private void CancelarModo() => _modo = ModoAccion.Ninguno;

    private void tablero_CasillaClick(object? sender, Posicion casilla)
    {
        if (_terminado) return;

        Combatiente? clic = _motor.Contexto.EnPosicion(casilla);

        if (_seleccion is Personaje actor && _modo != ModoAccion.Ninguno)
        {
            switch (_modo)
            {
                case ModoAccion.Mover when clic is null:
                    // COMMAND: el clic se convierte en un objeto y se lo entregamos al invocador.
                    Ejecutar(() => _motor.Comandos.Ejecutar(new MoverComando(actor, casilla, _motor.Contexto)));
                    return;

                case ModoAccion.Atacar when clic is Enemigo enemigo:
                    Ejecutar(() => _motor.Comandos.Ejecutar(new AtacarComando(actor, enemigo)));
                    return;

                case ModoAccion.Curar when clic is Personaje aliado:
                    Ejecutar(() => _motor.Comandos.Ejecutar(new CurarComando(actor, aliado, actor.PoderCuracion)));
                    return;
            }
        }

        // Cualquier otro clic sobre una unidad la selecciona.
        if (clic is not null) Seleccionar(clic);
    }

    // =====================================================================
    // Botones de acción
    // =====================================================================

    private void btnMover_Click(object? sender, EventArgs e) => ElegirModo(ModoAccion.Mover);

    private void btnAtacar_Click(object? sender, EventArgs e) => ElegirModo(ModoAccion.Atacar);

    private void btnCurar_Click(object? sender, EventArgs e) => ElegirModo(ModoAccion.Curar);

    /// <summary>STATE + COMMAND: la furia no necesita objetivo; es un comando que lleva al soldado a Berserk.</summary>
    private void btnFuria_Click(object? sender, EventArgs e)
    {
        if (_seleccion is not Personaje personaje) return;
        Ejecutar(() => _motor.Comandos.Ejecutar(new EnfurecerComando(personaje)));
    }

    private void btnDeshacer_Click(object? sender, EventArgs e) => Ejecutar(() => _motor.Comandos.Deshacer());

    private void btnRehacer_Click(object? sender, EventArgs e) => Ejecutar(() => _motor.Comandos.Rehacer());

    /// <summary>TEMPLATE METHOD: la unidad juega sus cuatro etapas (inicio, decisión, acción y finalización).</summary>
    private void btnAuto_Click(object? sender, EventArgs e)
    {
        if (_seleccion is not Personaje personaje) return;

        Ejecutar(() =>
        {
            ResultadoTurno turno = _motor.EjecutarTurnoAutomatico(personaje);
            _juego.Dominar(PatronGoF.TemplateMethod);

            return turno.Etapas.Count == 1
                ? ResultadoAccion.Fallo(turno.Etapas[0].Descripcion)
                : ResultadoAccion.Ok($"{personaje.Nombre} jugó su turno automático ({turno.Etapas.Count} pasos, mirá la bitácora).");
        });
    }

    /// <summary>STRATEGY: los enemigos deciden con su IA; sus decisiones quedan en la bitácora.</summary>
    private void btnTerminar_Click(object? sender, EventArgs e) => Ejecutar(() =>
    {
        _motor.TerminarRonda();
        return ResultadoAccion.Ok($"Los enemigos actuaron. Comienza la ronda {_motor.Contexto.Ronda}.");
    });

    /// <summary>
    /// Punto único por donde pasa toda acción: ejecuta, deja que el motor evalúe si el combate terminó,
    /// redibuja el estado leído del Core y, si la partida terminó, abre la pantalla final.
    /// </summary>
    private void Ejecutar(Func<ResultadoAccion> accion)
    {
        if (_terminado) return;

        ResultadoAccion resultado = accion();
        Mensaje(resultado.Mensaje, resultado.Exito);

        _motor.EvaluarResultado();

        CancelarModo();
        Refrescar();
        MostrarResumenSiTermino();
    }

    /// <summary>Al terminar la acción que cerró el combate se abre el resumen (sin pausas ni temporizadores).</summary>
    private void MostrarResumenSiTermino()
    {
        if (_resumenPendiente is null) return;

        ResumenPartida resumen = _resumenPendiente;
        _resumenPendiente = null;

        using (var pantallaFinal = new FormResumen(resumen)) pantallaFinal.ShowDialog(this);
        DialogResult = DialogResult.OK;
    }

    // =====================================================================
    // Cadena de defensas (Chain of Responsibility)
    // =====================================================================

    private IManejadorDanio? CapaElegida()
    {
        int i = lstDefensas.SelectedIndex;
        if (_seleccion is null || i < 0 || i >= _seleccion.Defensas.Eslabones.Count) return null;
        return _seleccion.Defensas.Eslabones[i];
    }

    private void btnCapaSubir_Click(object? sender, EventArgs e) => MoverCapa(-1);

    private void btnCapaBajar_Click(object? sender, EventArgs e) => MoverCapa(1);

    private void btnCapaQuitar_Click(object? sender, EventArgs e) => QuitarCapa();

    private void btnCapaAgregar_Click(object? sender, EventArgs e) => AgregarCapa();

    private void MoverCapa(int desplazamiento)
    {
        IManejadorDanio? capa = CapaElegida();
        if (capa is null || _seleccion is null) return;

        int destino = lstDefensas.SelectedIndex + desplazamiento;
        if (!_seleccion.Defensas.Mover(capa, destino))
        {
            Mensaje("No se puede mover esa capa (la Vida siempre es la última).", false);
            return;
        }

        Refrescar();
        lstDefensas.SelectedIndex = Math.Clamp(destino, 0, lstDefensas.Items.Count - 1);
        Mensaje($"Nuevo orden de {_seleccion.Nombre}: {_seleccion.Defensas.Descripcion}", true);
    }

    private void QuitarCapa()
    {
        IManejadorDanio? capa = CapaElegida();
        if (capa is null || _seleccion is null) return;

        if (_seleccion.Defensas.Quitar(capa)) Mensaje($"Se quitó {capa.Nombre}. Ahora: {_seleccion.Defensas.Descripcion}", true);
        else Mensaje("La Vida no se puede quitar de la cadena.", false);

        Refrescar();
    }

    private void AgregarCapa()
    {
        if (_seleccion is null) return;

        Random azar = _motor.Contexto.Azar;
        IManejadorDanio nueva = cboNuevaCapa.SelectedIndex switch
        {
            0 => new Esquiva(0.25, azar),
            1 => new Bloqueo(0.25, 0.5, azar),
            2 => new Armadura(3),
            _ => new Escudo(20)
        };

        _seleccion.Defensas.Agregar(nueva, 0); // al frente: es la primera capa que toca el golpe
        Mensaje($"Se agregó {nueva.Nombre} al frente. Ahora: {_seleccion.Defensas.Descripcion}", true);
        Refrescar();
    }

    private static string DescribirCapa(IManejadorDanio capa) => capa switch
    {
        Escudo e => $"Escudo    {e.Puntos}/{e.Maximo}",
        Armadura a => $"Armadura  -{a.Valor} por golpe",
        Esquiva q => $"Esquiva   {q.Probabilidad:P0}",
        Bloqueo b => $"Bloqueo   {b.Probabilidad:P0}, absorbe {b.PorcentajeAbsorbido:P0}",
        Vida v => $"Vida      {v.Actual}/{v.Maxima}",
        _ => capa.Nombre
    };

    // =====================================================================
    // IA del enemigo (Strategy) e inventario (Visitor)
    // =====================================================================

    private void btnCambiarIA_Click(object? sender, EventArgs e)
    {
        if (_seleccion is not Enemigo enemigo || cboEstrategia.SelectedItem is not string nombre) return;

        IEstrategiaIA nueva = ComparadorEstrategias.EstrategiasDisponibles().First(e => e.Nombre == nombre);
        enemigo.CambiarEstrategia(nueva); // en caliente: la próxima decisión ya usa la nueva
        Mensaje($"{enemigo.Nombre} ahora usa «{nueva.Nombre}». Mirá cómo cambia su intención.", true);
        Refrescar();
    }

    private void btnAplicarVisitante_Click(object? sender, EventArgs e)
    {
        // VISITOR: el inventario recorre sus ítems y cada uno «acepta» al visitante elegido.
        IVisitor visitante = Visitantes[cboVisitante.SelectedIndex].Crear();
        string resultado = _motor.Inventario.Aplicar(visitante);

        txtVisitante.Text = $"{visitante.Nombre}{Environment.NewLine}{resultado}{Environment.NewLine}{Environment.NewLine}" +
                             string.Join(Environment.NewLine, _motor.Inventario.Items.Select(DescribirItem));
        _juego.Dominar(PatronGoF.Visitor);

        if (visitante is AplicadorVeneno)
            Mensaje("Las armas quedaron envenenadas: cada golpe que conecte envenenará al enemigo.", true);
    }

    private static string DescribirItem(IItem item) => item switch
    {
        Arma a => $"• {a.Nombre} (daño {a.Danio}){(a.Venenosa ? " · envenenada" : string.Empty)}",
        Pocion p => $"• {p.Nombre} (cura {p.Curacion}){(p.Contaminada ? " · contaminada" : string.Empty)}",
        ArmaduraItem r => $"• {r.Nombre} (defensa {r.Defensa})",
        _ => $"• {item.Nombre}"
    };

    // =====================================================================
    // Refresco de la pantalla (solo lectura del Core)
    // =====================================================================

    private void Mensaje(string texto, bool exito)
    {
        lblMensaje.Text = exito ? texto : $"Aviso: {texto}";
    }

    private void Refrescar()
    {
        ContextoCombate ctx = _motor.Contexto;
        bool enCurso = !_terminado && _motor.Resultado == ResultadoCombate.EnCurso;
        var personaje = _seleccion as Personaje;

        lblHud.Text = $"Ronda {ctx.Ronda}/{_motor.MaximoRondas}   ·   Aliados {ctx.AliadosVivos.Count()}/{ctx.Aliados.Count}   ·   Enemigos {ctx.EnemigosVivos.Count()}/{ctx.Enemigos.Count}";

        tablero.Seleccionado = _seleccion;
        tablero.Modo = _modo;
        tablero.Invalidate();

        btnMover.Enabled = enCurso && personaje is { PuedeMover: true };
        btnAtacar.Enabled = enCurso && personaje is { PuedeActuar: true };
        btnCurar.Enabled = enCurso && personaje is { PuedeActuar: true, PoderCuracion: > 0 };
        btnFuria.Enabled = enCurso && personaje is { PuedeActuar: true, Clase: ClaseUnidad.Soldado, Estado: Normal };
        btnAuto.Enabled = enCurso && personaje is { EstaVivo: true };
        btnDeshacer.Enabled = enCurso && _motor.Comandos.PuedeDeshacer;
        btnRehacer.Enabled = enCurso && _motor.Comandos.PuedeRehacer;
        btnTerminar.Enabled = enCurso;

        RefrescarUnidad();
        RefrescarDefensas();
        RefrescarIA();
        RefrescarHistorial();
    }

    private void RefrescarUnidad()
    {
        Combatiente? c = _seleccion;
        if (c is null)
        {
            lblUnidadNombre.Text = "(ninguna)";
            lblUnidadVida.Text = lblUnidadEstado.Text = lblUnidadAcciones.Text = lblUnidadArma.Text = string.Empty;
            return;
        }

        string rol = c is Personaje p ? p.Clase.ToString() : "Enemigo";
        lblUnidadNombre.Text = $"{c.Nombre}  ·  {rol}";

        Escudo? escudo = c.Defensas.Buscar<Escudo>();
        lblUnidadVida.Text = $"Vida {c.Vida.Actual}/{c.Vida.Maxima}" + (escudo is null ? string.Empty : $"   Escudo {escudo.Puntos}/{escudo.Maximo}") + (c.EstaVivo ? string.Empty : "   (caído)");

        // STATE: el panel muestra el estado actual y los turnos que le quedan.
        int turnos = c.Estado.TurnosRestantes;
        lblUnidadEstado.Text = $"Estado: {c.Estado.Nombre}" + (turnos > 0 ? $" ({turnos} turnos)" : string.Empty);

        lblUnidadAcciones.Text = c is Personaje
            ? $"Movimiento: {(c.PuedeMover ? $"sí ({c.MovimientoDisponible} casillas)" : "ya usado")}   ·   Acción: {(c.PuedeActuar ? "sí" : "ya usada")}"
            : $"Ataque {c.PoderDeAtaque}  ·  alcance {c.Alcance}  ·  mov. {c.MovimientoDisponible}";
        lblUnidadArma.Text = c.ArmaEquipada is { } arma
            ? $"Arma: {arma.Nombre}{(arma.Venenosa ? " (envenenada)" : string.Empty)}{(arma.Aturdidora ? " (aturdidora)" : string.Empty)}  (poder {c.PoderDeAtaque})"
            : $"Poder de ataque: {c.PoderDeAtaque}";
    }

    private void RefrescarDefensas()
    {
        int seleccionado = lstDefensas.SelectedIndex;
        lstDefensas.BeginUpdate();
        lstDefensas.Items.Clear();

        if (_seleccion is not null)
        {
            int posicion = 1;
            foreach (IManejadorDanio capa in _seleccion.Defensas.Eslabones)
                lstDefensas.Items.Add($"{posicion++}. {DescribirCapa(capa)}");
        }

        lstDefensas.EndUpdate();
        if (seleccionado >= 0 && seleccionado < lstDefensas.Items.Count) lstDefensas.SelectedIndex = seleccionado;
    }

    private void RefrescarIA()
    {
        bool esEnemigo = _seleccion is Enemigo;
        cboEstrategia.Enabled = esEnemigo;
        btnCambiarIA.Enabled = esEnemigo && !_terminado;
        lstComparacion.Items.Clear();

        if (_seleccion is not Enemigo enemigo)
        {
            lblIaIntencion.Text = "Elegí un enemigo en el tablero para ver y cambiar su IA.";
            lblIaUltima.Text = string.Empty;
            return;
        }

        cboEstrategia.SelectedItem = enemigo.Estrategia.Nombre;

        if (enemigo.EstaVivo)
        {
            IReadOnlyList<DecisionEstrategia> decisiones = ComparadorEstrategias.Comparar(enemigo, _motor.Contexto);
            DecisionEstrategia? actual = decisiones.FirstOrDefault(d => d.Estrategia == enemigo.Estrategia.Nombre);
            lblIaIntencion.Text = actual is null
                ? $"{enemigo.Estrategia.Nombre}: sin vista previa"
                : $"{actual.Estrategia} → {actual.Accion}{Environment.NewLine}{actual.Accion.Razon}";

            foreach (DecisionEstrategia d in decisiones)
                lstComparacion.Items.Add($"{d.Estrategia}: {d.Accion}");
        }
        else
        {
            lblIaIntencion.Text = "Este enemigo está fuera de combate.";
        }

        lblIaUltima.Text = enemigo.UltimaDecision is { } ultima ? $"Última decisión real: {ultima.Razon}" : "Todavía no actuó.";
    }

    private void RefrescarHistorial()
    {
        lstHistorial.BeginUpdate();
        lstHistorial.Items.Clear();
        foreach (string linea in _motor.Comandos.Historial) lstHistorial.Items.Add(linea);
        lstHistorial.TopIndex = Math.Max(0, lstHistorial.Items.Count - 1);
        lstHistorial.EndUpdate();
    }

    // =====================================================================
    // Cierre
    // =====================================================================

    private void FormCombate_FormClosing(object? sender, FormClosingEventArgs e)
    {
        if (!_terminado && e.CloseReason == CloseReason.UserClosing)
        {
            DialogResult respuesta = MessageBox.Show(this, "¿Abandonar el combate? Se pierde la batalla en curso.", "Combate",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta != DialogResult.Yes) e.Cancel = true;
        }
    }

    private void FormCombate_FormClosed(object? sender, FormClosedEventArgs e)
    {
        // El Singleton vive más que este formulario: hay que soltar todas las suscripciones.
        Desconectar();
    }
}
