using Kepler7.Core.Aplicacion;
using Kepler7.Game.Visual;

namespace Kepler7.Game.Formularios;

/// <summary>
/// Hub de la partida: la estación Kepler-7. Cada pestaña es la cara visible de un patrón y todas hablan con
/// el mismo <see cref="JuegoKepler7"/> (Singleton), así lo que se construye o se cifra en una se ve en las demás.
/// </summary>
internal sealed partial class FormEstacion : Form
{
    private readonly JuegoKepler7 _juego = JuegoKepler7.Instancia;

    public FormEstacion()
    {
        InitializeComponent();

        Text = $"{Equipo.Juego} — Estación orbital";
        _juego.PatronDominado += AlDominarPatron;
        _juego.Base.Cambio += AlCambiarBase;
        ActualizarHud();
    }

    private void btnCombate_Click(object? sender, EventArgs e)
    {
        // El formulario de combate pide su MotorCombate al Singleton y se encarga del resto.
        using (var combate = new FormCombate()) combate.ShowDialog(this);

        ActualizarHud();
        panelLogros.Actualizar();
    }

    private void btnVolver_Click(object? sender, EventArgs e) => Close();

    private void tabControl_SelectedIndexChanged(object? sender, EventArgs e) => panelLogros.Actualizar();

    private void ActualizarHud()
    {
        ProgresoJugador p = _juego.Progreso;
        lblHud.Text = $"Nivel {p.Nivel}   ·   XP {p.XpEnNivel}/{ProgresoJugador.XpPorNivel}   ·   {_juego.Base.Creditos} créditos   ·   insignias {p.PatronesDominados.Count}/12";
    }

    private void AlDominarPatron(object? sender, PatronGoF patron) => Ui.EnUi(this, () =>
    {
        // Feedback estático: el aviso queda escrito hasta que llegue el siguiente (sin temporizador que lo borre).
        lblAviso.Text = $"Insignia «{patron.Insignia()}» ({patron.Nombre()})  +25 XP";
        ActualizarHud();
        panelLogros.Actualizar();
    });

    private void AlCambiarBase(object? sender, EventArgs e) => Ui.EnUi(this, ActualizarHud);

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        _juego.PatronDominado -= AlDominarPatron;
        _juego.Base.Cambio -= AlCambiarBase;
        base.OnFormClosed(e);
    }
}
