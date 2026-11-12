namespace Kepler7.Core.Creacional.Builder;

/// <summary>Carguero: bodega enorme y muchos tanques, sin armamento (el paso de armas queda vacío).</summary>
public sealed class RecetaCarga : RecetaBase
{
    public RecetaCarga() : base("Carga") { }

    public override void ConstruirCasco()
    {
        Producto.Casco = "Casco reforzado de bodega";
        Producto.Aportar(resistencia: 60, capacidadCarga: 200, costo: 300);
    }

    public override void InstalarMotor()
    {
        Producto.Motor = "Impulsor de carga pesada";
        Producto.Aportar(velocidad: 20, autonomia: 10, costo: 250);
    }

    public override void InstalarEscudo()
    {
        Producto.Escudo = "Escudo antimeteoritos";
        Producto.Aportar(resistencia: 25, costo: 120);
    }

    public override void InstalarArmas()
    {
        // Opcional: un carguero no lleva armas. No se instala nada.
    }

    public override void InstalarRadar()
    {
        Producto.Radar = "Radar de proximidad";
        Producto.Aportar(deteccion: 20, costo: 80);
    }

    public override void InstalarIA()
    {
        Producto.InteligenciaArtificial = "IA logística 'Estibador'";
        Producto.Aportar(autonomia: 10, costo: 200);
    }

    public override void AgregarTanquesCombustible()
    {
        Producto.TanquesCombustible = 5;
        Producto.Aportar(autonomia: 125, costo: 150);
    }
}
