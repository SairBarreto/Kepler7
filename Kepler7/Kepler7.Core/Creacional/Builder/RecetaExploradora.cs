namespace Kepler7.Core.Creacional.Builder;

/// <summary>Nave de largo alcance: liviana, sensores potentes y mucha autonomía; casi sin armas.</summary>
public sealed class RecetaExploradora : RecetaBase
{
    public RecetaExploradora() : base("Exploradora") { }

    public override void ConstruirCasco()
    {
        Producto.Casco = "Casco ligero de aleación de titanio";
        Producto.Aportar(resistencia: 30, capacidadCarga: 20, costo: 200);
    }

    public override void InstalarMotor()
    {
        Producto.Motor = "Propulsor iónico de largo alcance";
        Producto.Aportar(velocidad: 70, autonomia: 20, costo: 400);
    }

    public override void InstalarEscudo()
    {
        Producto.Escudo = "Escudo de deflexión básico";
        Producto.Aportar(resistencia: 15, costo: 150);
    }

    public override void InstalarArmas()
    {
        Producto.AgregarArma("Láser de defensa personal");
        Producto.Aportar(poderFuego: 10, costo: 100);
    }

    public override void InstalarRadar()
    {
        Producto.Radar = "Radar de espectro profundo";
        Producto.Aportar(deteccion: 90, costo: 350);
    }

    public override void InstalarIA()
    {
        Producto.InteligenciaArtificial = "IA cartógrafa 'Magallanes'";
        Producto.Aportar(deteccion: 10, velocidad: 5, costo: 300);
    }

    public override void AgregarTanquesCombustible()
    {
        Producto.TanquesCombustible = 3;
        Producto.Aportar(autonomia: 75, costo: 90);
    }
}
