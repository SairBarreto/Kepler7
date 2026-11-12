using Kepler7.Core.Creacional.Builder;

namespace Kepler7.Core.Dominio;

/// <summary>
/// La base de Kepler-7 (la parte de "gestión"): administra créditos y la flota que se va construyendo.
/// Sus cambios pasan por comandos (ConstruirComando) para poder deshacerlos.
/// </summary>
public sealed class BaseEstacion
{
    private readonly List<Nave> _flota = new();

    public BaseEstacion(int creditosIniciales)
    {
        Creditos = Math.Max(0, creditosIniciales);
    }

    public int Creditos { get; private set; }
    public IReadOnlyList<Nave> Flota => _flota;

    public event EventHandler? Cambio;

    internal bool Gastar(int cantidad)
    {
        if (cantidad > Creditos) return false;
        Creditos -= cantidad;
        Cambio?.Invoke(this, EventArgs.Empty);
        return true;
    }

    internal void Reembolsar(int cantidad)
    {
        Creditos += Math.Max(0, cantidad);
        Cambio?.Invoke(this, EventArgs.Empty);
    }

    internal void AgregarNave(Nave nave)
    {
        _flota.Add(nave);
        Cambio?.Invoke(this, EventArgs.Empty);
    }

    internal bool QuitarNave(Nave nave)
    {
        bool quitada = _flota.Remove(nave);
        if (quitada) Cambio?.Invoke(this, EventArgs.Empty);
        return quitada;
    }
}
