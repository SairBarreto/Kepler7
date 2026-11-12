using Kepler7.Core.Aplicacion;
using Kepler7.Core.Comun;
using Kepler7.Core.Estructural.Facade;
using Kepler7.Game.Visual;

namespace Kepler7.Game.Controles;

/// <summary>
/// FACADE en pantalla: tres botones, una sola llamada cada uno. La interfaz no sabe que detrás hay seis
/// subsistemas (energía, soporte vital, navegación, comunicaciones, seguridad y defensa).
/// </summary>
internal sealed partial class PanelControlCentral : UserControl
{
    private readonly JuegoKepler7 _juego = JuegoKepler7.Instancia;
    private readonly ControlCentral _control;

    public PanelControlCentral()
    {
        InitializeComponent();
        _control = _juego.Control;

        _juego.Bitacora.EntradaRegistrada += AlRegistrar;
        Disposed += (_, _) => _juego.Bitacora.EntradaRegistrada -= AlRegistrar; // el Singleton retendría el control para siempre
        VisibleChanged += (_, _) => { if (Visible) CargarRegistro(); };
        CargarRegistro();
        Refrescar();
    }

    // Cada botón es UNA llamada a la fachada.
    private void btnIniciarTurno_Click(object? sender, EventArgs e) { _control.IniciarTurno(); Refrescar(); }

    private void btnEmergencia_Click(object? sender, EventArgs e) { _control.EntrarEnEmergencia(); Refrescar(); }

    private void btnApagar_Click(object? sender, EventArgs e) { _control.ApagarEstacion(); Refrescar(); }

    private void CargarRegistro()
    {
        lstRegistro.Items.Clear();
        foreach (EntradaBitacora entrada in _juego.Bitacora.Entradas.TakeLast(60)) lstRegistro.Items.Add(entrada.ToString());
        lstRegistro.TopIndex = Math.Max(0, lstRegistro.Items.Count - 1);
    }

    private void AlRegistrar(object? sender, EntradaBitacora entrada) =>
        Ui.EnUi(this, () => Ui.AgregarAlFinal(lstRegistro, entrada.ToString()));

    private void Refrescar()
    {
        lblModo.Text = _control.Modo.ToString().ToUpperInvariant();
        lblTurno.Text = $"Turno {_control.TurnoActual}";

        lvSubsistemas.BeginUpdate();
        lvSubsistemas.Items.Clear();
        foreach (EstadoSubsistema s in _control.ObtenerEstadoSubsistemas())
        {
            var item = new ListViewItem(new[] { s.Nombre, s.Activo ? "Activo" : "Inactivo", s.Nivel.ToString(), s.Detalle });
            lvSubsistemas.Items.Add(item);
        }
        lvSubsistemas.EndUpdate();
    }
}
