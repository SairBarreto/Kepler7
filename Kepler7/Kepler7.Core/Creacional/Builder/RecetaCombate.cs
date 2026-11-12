namespace Kepler7.Core.Creacional.Builder;

/// <summary>Nave de guerra: blindada, triple armamento y escudo reforzado; poca autonomía.</summary>
public sealed class RecetaCombate : RecetaBase
{
    public RecetaCombate() : base("Combate") { }

    public override void ConstruirCasco()
    {
        Producto.Casco = "Blindaje compuesto de tungsteno";
        Producto.Aportar(resistencia: 80, capacidadCarga: 10, costo: 500);
    }

    public override void InstalarMotor()
    {
        Producto.Motor = "Reactor de fusión de pulso";
        Producto.Aportar(velocidad: 50, autonomia: 10, costo: 600);
    }

    public override void InstalarEscudo()
    {
        Producto.Escudo = "Escudo de plasma de doble capa";
        Producto.Aportar(resistencia: 60, costo: 450);
    }

    public override void InstalarArmas()
    {
        Producto.AgregarArma("Cañón de riel");
        Producto.AgregarArma("Torreta de pulsos");
        Producto.AgregarArma("Lanzamisiles");
        Producto.Aportar(poderFuego: 100, costo: 1200);
    }

    public override void InstalarRadar()
    {
        Producto.Radar = "Radar táctico de corto alcance";
        Producto.Aportar(deteccion: 40, costo: 200);
    }

    public override void InstalarIA()
    {
        Producto.InteligenciaArtificial = "IA de combate 'Centinela'";
        Producto.Aportar(poderFuego: 15, deteccion: 10, costo: 350);
    }

    public override void AgregarTanquesCombustible()
    {
        Producto.TanquesCombustible = 1;
        Producto.Aportar(autonomia: 25, costo: 30);
    }
}
