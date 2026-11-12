using Kepler7.Core.Aplicacion;

namespace Kepler7.Game.Formularios;

/// <summary>Pantalla inicial: nombre del juego, integrantes y accesos al tutorial, la estación y los logros.</summary>
internal sealed partial class FormInicio : Form
{
    private readonly JuegoKepler7 _juego = JuegoKepler7.Instancia; // SINGLETON

    public FormInicio()
    {
        InitializeComponent();

        Text = $"{Equipo.Juego} — {Equipo.Subtitulo}";
        lblMateria.Text = Equipo.Materia;
        lblIntegrantes.Text = "Integrantes\n" + string.Join("\n", Equipo.Integrantes);
        ActualizarProgreso();
    }

    private void ActualizarProgreso()
    {
        ProgresoJugador p = _juego.Progreso;
        lblProgreso.Text = $"Nivel {p.Nivel}  ·  {p.Xp} XP  ·  {p.Monedas} monedas  ·  insignias {p.PatronesDominados.Count}/12";
    }

    private void btnJugar_Click(object? sender, EventArgs e)
    {
        // La primera vez se pasa por el tutorial; después se va directo a la estación.
        if (!_juego.Progreso.TutorialVisto) MostrarTutorial();

        Hide();
        using (var estacion = new FormEstacion()) estacion.ShowDialog(this);
        ActualizarProgreso();
        Show();
    }

    private void btnTutorial_Click(object? sender, EventArgs e) => MostrarTutorial();

    private void btnLogros_Click(object? sender, EventArgs e)
    {
        using var logros = new FormLogros();
        logros.ShowDialog(this);
    }

    private void btnSalir_Click(object? sender, EventArgs e) => Close();

    private void MostrarTutorial()
    {
        using var tutorial = new FormTutorial();
        tutorial.ShowDialog(this);
    }
}
