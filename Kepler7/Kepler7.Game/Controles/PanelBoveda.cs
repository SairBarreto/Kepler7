using Kepler7.Core.Aplicacion;
using Kepler7.Core.Dominio;
using Kepler7.Core.Estructural.Proxy;
using Kepler7.Game.Visual;

namespace Kepler7.Game.Controles;

/// <summary>
/// PROXY: la interfaz habla con <see cref="IBoveda"/> sin saber si tiene delante la bóveda real o el proxy.
/// Según el rol de la sesión, el proxy deja pasar o rechaza (y deja constancia de cada intento denegado).
/// El texto indica si se concedió o denegó el acceso, o si falta el archivo.
/// </summary>
internal sealed partial class PanelBoveda : UserControl
{
    private readonly JuegoKepler7 _juego = JuegoKepler7.Instancia;
    private bool _cargando;

    public PanelBoveda()
    {
        InitializeComponent();

        _cargando = true; // evita que cargar el rol inicial dispare un inicio de sesión
        foreach (RolUsuario rol in Enum.GetValues<RolUsuario>()) cboRol.Items.Add(rol);
        cboRol.SelectedItem = _juego.Sesion.UsuarioActual.Rol;
        _cargando = false;

        _juego.Accesos.IntentoRegistrado += AlDenegar;
        Disposed += (_, _) => _juego.Accesos.IntentoRegistrado -= AlDenegar;
        VisibleChanged += (_, _) => { if (Visible) CargarDenegados(); };
        CargarDenegados();
        lblEstado.Text = "Probá abrir un archivo con distintos roles.";
    }

    private void cboRol_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (_cargando) return;

        var rol = (RolUsuario)cboRol.SelectedItem!;
        _juego.Sesion.IniciarSesion(new Usuario(rol.ATexto(), rol));
        lblEstado.Text = $"Sesión iniciada como {rol.ATexto()}.";
    }

    private void btnLeer_Click(object? sender, EventArgs e) => Intentar(() =>
    {
        txtContenido.Text = _juego.Boveda.LeerArchivo(txtArchivo.Text.Trim());
        return $"Acceso concedido: '{txtArchivo.Text.Trim()}' leído.";
    });

    private void btnListar_Click(object? sender, EventArgs e) => Intentar(() =>
    {
        txtContenido.Text = string.Join(Environment.NewLine, _juego.Boveda.ListarArchivos());
        return "Acceso concedido: listado de la bóveda.";
    });

    private void btnEscribir_Click(object? sender, EventArgs e) => Intentar(() =>
    {
        _juego.Boveda.EscribirArchivo("nota-" + DateTime.Now.ToString("HHmmss"), "Nota escrita por " + _juego.Sesion.UsuarioActual.Nombre);
        return "Acceso concedido: nota guardada en la bóveda.";
    });

    /// <summary>Ejecuta una operación sobre la bóveda y traduce el éxito o la denegación a un mensaje.</summary>
    private void Intentar(Func<string> operacion)
    {
        try
        {
            lblEstado.Text = operacion();
        }
        catch (AccesoDenegadoException ex)
        {
            txtContenido.Text = string.Empty;
            lblEstado.Text = ex.Message;
        }
        catch (FileNotFoundException ex)
        {
            txtContenido.Text = string.Empty;
            lblEstado.Text = $"Advertencia: {ex.Message}";
        }
    }

    private void AlDenegar(object? sender, IntentoAcceso intento) =>
        Ui.EnUi(this, () => lstDenegados.Items.Add(Formatear(intento)));

    private void CargarDenegados()
    {
        lstDenegados.Items.Clear();
        foreach (IntentoAcceso intento in _juego.Accesos.Intentos.TakeLast(50)) lstDenegados.Items.Add(Formatear(intento));
    }

    private static string Formatear(IntentoAcceso i) =>
        $"{i.FechaUtc.ToLocalTime():dd/MM HH:mm:ss}  {i.Rol.ATexto()}  {i.Operacion} '{i.ArchivoId}'";
}
