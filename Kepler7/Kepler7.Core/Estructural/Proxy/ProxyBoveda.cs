using Kepler7.Core.Comun;
using Kepler7.Core.Dominio;

namespace Kepler7.Core.Estructural.Proxy;

/// <summary>
/// PROXY DE PROTECCIÓN: se interpone entre el cliente y la <see cref="BovedaDatos"/> real.
/// Antes de delegar verifica el rol del usuario de la <see cref="Sesion"/>: solo Capitán y
/// Oficial de Seguridad pasan. El resto es rechazado (excepción) y el intento queda registrado en disco.
/// </summary>
public sealed class ProxyBoveda : IBoveda
{
    private static readonly HashSet<RolUsuario> RolesAutorizados = new()
    {
        RolUsuario.Capitan,
        RolUsuario.OficialSeguridad
    };

    private readonly IBoveda _bovedaReal;
    private readonly Sesion _sesion;
    private readonly RegistroAccesosDenegados _registro;
    private readonly IBitacora? _bitacora;

    public ProxyBoveda(IBoveda bovedaReal, Sesion sesion, RegistroAccesosDenegados registro, IBitacora? bitacora = null)
    {
        _bovedaReal = bovedaReal ?? throw new ArgumentNullException(nameof(bovedaReal));
        _sesion = sesion ?? throw new ArgumentNullException(nameof(sesion));
        _registro = registro ?? throw new ArgumentNullException(nameof(registro));
        _bitacora = bitacora;
    }

    public string LeerArchivo(string id)
    {
        Autorizar("Lectura", id);
        return _bovedaReal.LeerArchivo(id);
    }

    public void EscribirArchivo(string id, string contenido)
    {
        Autorizar("Escritura", id);
        _bovedaReal.EscribirArchivo(id, contenido);
    }

    public IReadOnlyList<string> ListarArchivos()
    {
        Autorizar("Listado", "*");
        return _bovedaReal.ListarArchivos();
    }

    private void Autorizar(string operacion, string archivoId)
    {
        Usuario usuario = _sesion.UsuarioActual;

        if (RolesAutorizados.Contains(usuario.Rol))
        {
            _bitacora?.Registrar("Bóveda", $"Acceso concedido a {usuario.Nombre} ({usuario.Rol.ATexto()}): {operacion} de '{archivoId}'.");
            return;
        }

        var intento = new IntentoAcceso(DateTime.UtcNow, usuario.Nombre, usuario.Rol, operacion, archivoId);
        _registro.Registrar(intento);
        _bitacora?.Registrar("Bóveda", $"ACCESO DENEGADO a {usuario.Nombre} ({usuario.Rol.ATexto()}): {operacion} de '{archivoId}'.", NivelBitacora.Critico);

        throw new AccesoDenegadoException(intento);
    }
}
