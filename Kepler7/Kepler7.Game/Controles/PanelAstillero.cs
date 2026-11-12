using Kepler7.Core.Aplicacion;
using Kepler7.Core.Comportamiento.Command;
using Kepler7.Core.Creacional.Builder;
using Kepler7.Core.Dominio.Combate;
using Kepler7.Game.Visual;

namespace Kepler7.Game.Controles;

/// <summary>
/// BUILDER + COMMAND: el jugador elige una receta y el comando «construir» la ejecuta a través del
/// director (IngenieroJefe). Como es un comando, se puede deshacer y rehacer (con reembolso de créditos).
/// </summary>
internal sealed partial class PanelAstillero : UserControl
{
    private sealed record OpcionReceta(string Nombre, Func<INaveBuilder> Crear)
    {
        public override string ToString() => Nombre;
    }

    private readonly JuegoKepler7 _juego = JuegoKepler7.Instancia;

    public PanelAstillero()
    {
        InitializeComponent();

        cboRecetas.Items.Add(new OpcionReceta("Exploradora", () => new RecetaExploradora()));
        cboRecetas.Items.Add(new OpcionReceta("Combate", () => new RecetaCombate()));
        cboRecetas.Items.Add(new OpcionReceta("Carga", () => new RecetaCarga()));
        cboRecetas.SelectedIndex = 0;

        _juego.Base.Cambio += AlCambiar;
        _juego.ComandosEstacion.Cambio += AlCambiar;
        Disposed += (_, _) =>
        {
            _juego.Base.Cambio -= AlCambiar;
            _juego.ComandosEstacion.Cambio -= AlCambiar;
        };
        VisibleChanged += (_, _) => { if (Visible) Refrescar(); }; // los avisos recibidos con la pestaña oculta se recuperan acá
        Refrescar();
    }

    private void btnConstruir_Click(object? sender, EventArgs e)
    {
        var receta = (OpcionReceta)cboRecetas.SelectedItem!;

        // El botón solo arma el comando y se lo entrega al invocador.
        ResultadoAccion resultado = _juego.ComandosEstacion.Ejecutar(
            new ConstruirComando(_juego.Base, receta.Crear(), rdoCompleta.Checked));

        if (resultado.Exito)
        {
            _juego.Dominar(PatronGoF.Builder);
            lstFlota.SelectedIndex = lstFlota.Items.Count - 1;
        }

        Responder(resultado);
    }

    private void btnDeshacer_Click(object? sender, EventArgs e) => Responder(_juego.ComandosEstacion.Deshacer());

    private void btnRehacer_Click(object? sender, EventArgs e) => Responder(_juego.ComandosEstacion.Rehacer());

    private void lstFlota_SelectedIndexChanged(object? sender, EventArgs e) => MostrarDetalle();

    private void Responder(ResultadoAccion r)
    {
        lblMensaje.Text = r.Exito ? $"Éxito: {r.Mensaje}" : $"No se pudo completar: {r.Mensaje}";
    }

    private void AlCambiar(object? sender, EventArgs e) => Ui.EnUi(this, Refrescar);

    private void Refrescar()
    {
        lblCreditos.Text = $"Créditos: {_juego.Base.Creditos}";

        int seleccion = lstFlota.SelectedIndex;
        lstFlota.Items.Clear();
        foreach (Nave nave in _juego.Base.Flota) lstFlota.Items.Add($"{nave.Tipo} · {nave.CostoCreditos} cr.");
        if (seleccion >= 0 && seleccion < lstFlota.Items.Count) lstFlota.SelectedIndex = seleccion;
        MostrarDetalle();

        lstHistorial.Items.Clear();
        foreach (string linea in _juego.ComandosEstacion.Historial) lstHistorial.Items.Add(linea);
        lstHistorial.TopIndex = Math.Max(0, lstHistorial.Items.Count - 1);

        btnDeshacer.Enabled = _juego.ComandosEstacion.PuedeDeshacer;
        btnRehacer.Enabled = _juego.ComandosEstacion.PuedeRehacer;
    }

    private void MostrarDetalle()
    {
        int i = lstFlota.SelectedIndex;
        txtDetalle.Text = i >= 0 && i < _juego.Base.Flota.Count
            ? _juego.Base.Flota[i].Describir().Replace("\n", Environment.NewLine)
            : "Todavía no hay una nave seleccionada.";
    }
}
