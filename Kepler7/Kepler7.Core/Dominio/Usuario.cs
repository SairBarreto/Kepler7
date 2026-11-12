namespace Kepler7.Core.Dominio;

/// <summary>Roles de la estación. Solo Capitán y Oficial de Seguridad pasan el Proxy de la bóveda.</summary>
public enum RolUsuario
{
    Capitan,
    OficialSeguridad,
    Ingeniero,
    Tripulante,
    Visitante
}

public static class RolUsuarioExtensiones
{
    public static string ATexto(this RolUsuario rol) => rol switch
    {
        RolUsuario.Capitan => "Capitán",
        RolUsuario.OficialSeguridad => "Oficial de Seguridad",
        RolUsuario.Ingeniero => "Ingeniero",
        RolUsuario.Tripulante => "Tripulante",
        RolUsuario.Visitante => "Visitante",
        _ => rol.ToString()
    };
}

/// <summary>Persona que está operando la consola de la estación.</summary>
public sealed record Usuario(string Nombre, RolUsuario Rol);

/// <summary>
/// Sesión actual. La UI cambia el usuario (por ejemplo con un combo de roles)
/// y el Proxy consulta siempre al usuario vigente.
/// </summary>
public sealed class Sesion
{
    public Sesion(Usuario usuarioInicial)
    {
        UsuarioActual = usuarioInicial ?? throw new ArgumentNullException(nameof(usuarioInicial));
    }

    public Usuario UsuarioActual { get; private set; }

    public event EventHandler<Usuario>? UsuarioCambiado;

    public void IniciarSesion(Usuario usuario)
    {
        UsuarioActual = usuario ?? throw new ArgumentNullException(nameof(usuario));
        UsuarioCambiado?.Invoke(this, usuario);
    }
}
