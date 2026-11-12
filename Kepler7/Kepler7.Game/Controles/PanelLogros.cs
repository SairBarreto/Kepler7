using Kepler7.Core.Aplicacion;
using Kepler7.Game.Visual;

namespace Kepler7.Game.Controles;

/// <summary>
/// Panel de insignias: una por patrón, con lo que hay que hacer para conseguirla.
/// Cada insignia indica en texto si está obtenida o pendiente.
/// </summary>
internal sealed partial class PanelLogros : UserControl
{
    private static readonly Font FuenteTitulo = new("Segoe UI", 10f, FontStyle.Bold);
    private static readonly Font FuenteDetalle = new("Segoe UI", 8.5f);

    private readonly JuegoKepler7 _juego = JuegoKepler7.Instancia;

    public PanelLogros()
    {
        InitializeComponent();
        barraXp.Maximum = ProgresoJugador.XpPorNivel;
        Actualizar();
    }

    public void Actualizar()
    {
        ProgresoJugador p = _juego.Progreso;
        lblResumen.Text = $"Nivel {p.Nivel}  ·  {p.Xp} XP  ·  {p.Monedas} monedas  ·  insignias {p.PatronesDominados.Count}/12  ·  victorias {p.PartidasGanadas} / derrotas {p.PartidasPerdidas}";
        barraXp.Value = Math.Min(barraXp.Maximum, p.XpEnNivel);

        flujoLogros.SuspendLayout();
        foreach (Control anterior in flujoLogros.Controls) anterior.Dispose();
        flujoLogros.Controls.Clear();

        foreach (PatronGoF patron in Enum.GetValues<PatronGoF>())
        {
            bool obtenida = _juego.EstaDominado(patron);
            var fila = new Panel
            {
                Width = 640,
                Height = 50,
                BackColor = Tema.Superficie,
                Margin = new Padding(4, 3, 4, 3)
            };

            var titulo = new Label
            {
                AutoSize = true,
                Text = $"{patron.Nombre()} — {patron.Insignia()} ({(obtenida ? "obtenida" : "pendiente")})",
                Font = FuenteTitulo,
                Location = new Point(10, 5)
            };
            var detalle = new Label
            {
                AutoSize = true,
                Text = patron.Mecanica(),
                Font = FuenteDetalle,
                ForeColor = Tema.TextoSuave,
                Location = new Point(10, 27)
            };

            fila.Controls.AddRange(new Control[] { titulo, detalle });
            flujoLogros.Controls.Add(fila);
        }

        flujoLogros.ResumeLayout();
    }
}
