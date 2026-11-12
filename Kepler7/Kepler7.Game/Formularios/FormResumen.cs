using Kepler7.Core.Aplicacion;

namespace Kepler7.Game.Formularios;

/// <summary>Pantalla final de la partida: resultado, estadísticas, recompensas e insignias nuevas (todo estático).</summary>
internal sealed partial class FormResumen : Form
{
    public FormResumen(ResumenPartida resumen)
    {
        InitializeComponent();

        lblResultado.Text = resumen.Victoria ? "¡VICTORIA!" : resumen.TiempoAgotado ? "TIEMPO AGOTADO" : "DERROTA";
        lblDetalle.Text = resumen.Victoria
            ? "Los enemigos fueron neutralizados. Kepler-7 respira."
            : resumen.TiempoAgotado
                ? "Nadie logró imponerse a tiempo. Kepler-7 resiste, pero el combate quedó sin vencedor."
                : "El escuadrón cayó. La estación sigue en pie… por ahora.";

        lblRondas.Text = resumen.Rondas.ToString();
        lblAliados.Text = $"{resumen.AliadosVivos} de {resumen.AliadosTotales}";
        lblEnemigos.Text = $"{resumen.EnemigosDerrotados} de {resumen.EnemigosTotales}";
        lblComandos.Text = resumen.ComandosEjecutados.ToString();
        lblXp.Text = $"+{resumen.XpGanada}";
        lblMonedas.Text = $"+{resumen.MonedasGanadas}";

        // Barra de experiencia: se muestra directamente el valor final (sin llenado progresivo).
        ProgresoJugador progreso = JuegoKepler7.Instancia.Progreso;
        lblNivel.Text = $"Nivel {progreso.Nivel}  ·  {progreso.Xp} XP";
        barraXp.Maximum = ProgresoJugador.XpPorNivel;
        barraXp.Value = Math.Min(barraXp.Maximum, progreso.Xp % ProgresoJugador.XpPorNivel);

        lblSubioNivel.Text = $"¡Subiste al nivel {resumen.NivelActual}!";
        lblSubioNivel.Visible = resumen.SubioDeNivel;

        if (resumen.PatronesNuevos.Count == 0) lstInsignias.Items.Add("Ninguna esta vez.");
        foreach (PatronGoF patron in resumen.PatronesNuevos)
            lstInsignias.Items.Add($"{patron.Insignia()}  ({patron.Nombre()})");
    }
}
