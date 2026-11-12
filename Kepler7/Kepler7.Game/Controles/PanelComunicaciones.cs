using Kepler7.Core.Aplicacion;
using Kepler7.Core.Estructural.Bridge;

namespace Kepler7.Game.Controles;

/// <summary>
/// BRIDGE: el tipo de mensaje y el cifrado se eligen por separado y se combinan en tiempo de ejecución
/// (3 × 3 = 9 combinaciones con 6 clases). «Reenviar» cambia solo el cifrado del mismo mensaje.
/// </summary>
internal sealed partial class PanelComunicaciones : UserControl
{
    private readonly JuegoKepler7 _juego = JuegoKepler7.Instancia;
    private Mensaje? _ultimo;

    public PanelComunicaciones()
    {
        InitializeComponent();
    }

    private void btnEnviar_Click(object? sender, EventArgs e)
    {
        // Abstracción (tipo de mensaje) + implementación (cifrado), elegidas de forma independiente.
        ICifrado cifrado = CrearCifrado();
        _ultimo = cboTipo.SelectedIndex switch
        {
            1 => new MensajeAlerta(txtContenido.Text, cifrado),
            2 => new MensajeEmergencia(txtContenido.Text, cifrado),
            _ => new MensajeTexto(txtContenido.Text, cifrado)
        };

        Mostrar(_ultimo.Enviar());
    }

    private void btnReenviar_Click(object? sender, EventArgs e)
    {
        if (_ultimo is null)
        {
            txtResultado.Text = "Todavía no enviaste ningún mensaje.";
            return;
        }

        _ultimo.CambiarCifrado(CrearCifrado()); // mismo mensaje, otro cifrado
        Mostrar(_ultimo.Enviar());
    }

    private ICifrado CrearCifrado() => cboCifrado.SelectedIndex switch
    {
        1 => new CifradoAES(),
        2 => new CifradoCuantico(),
        _ => new SinCifrado()
    };

    private void Mostrar(ResultadoEnvio r)
    {
        txtResultado.Text = string.Join(Environment.NewLine, new[]
        {
            $"Tipo: {r.TipoMensaje}  (prioridad {r.Prioridad})    Cifrado: {r.NombreCifrado}",
            string.Empty,
            "ENVIADO (con el formato propio del tipo de mensaje):",
            r.TextoFormateado,
            string.Empty,
            "TRANSMITIDO (lo que viaja por el espacio):",
            r.TextoTransmitido,
            string.Empty,
            "RECIBIDO EN LA TIERRA (descifrado):",
            r.DescifrarEnDestino()
        });

        _juego.Dominar(PatronGoF.Bridge);
    }
}
