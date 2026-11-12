namespace Kepler7.Core.Creacional.Builder;

/// <summary>
/// Esqueleto común de los builders concretos: guarda la nave en construcción y resuelve
/// Reiniciar/ObtenerNave. Las recetas solo implementan qué instalan en cada paso.
/// </summary>
public abstract class RecetaBase : INaveBuilder
{
    private Nave _producto;

    protected RecetaBase(string nombreReceta)
    {
        NombreReceta = nombreReceta;
        _producto = new Nave(nombreReceta);
    }

    public string NombreReceta { get; }

    /// <summary>La nave que se está armando; las subclases la completan paso a paso.</summary>
    protected Nave Producto => _producto;

    public void Reiniciar() => _producto = new Nave(NombreReceta);

    public Nave ObtenerNave()
    {
        Nave terminada = _producto;
        Reiniciar();
        return terminada;
    }

    public abstract void ConstruirCasco();
    public abstract void InstalarMotor();
    public abstract void InstalarEscudo();
    public abstract void InstalarArmas();
    public abstract void InstalarRadar();
    public abstract void InstalarIA();
    public abstract void AgregarTanquesCombustible();
}
