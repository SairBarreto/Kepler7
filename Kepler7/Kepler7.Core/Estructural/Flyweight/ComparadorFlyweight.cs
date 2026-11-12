using System.Diagnostics;
using Kepler7.Core.Dominio;

namespace Kepler7.Core.Estructural.Flyweight;

/// <summary>Resultado de comparar la misma población CON y SIN Flyweight.</summary>
public sealed record ResultadoComparacionFlyweight(
    int Cantidad,
    int EspeciesConFlyweight,
    int EspeciesSinFlyweight,
    long BytesConFlyweight,
    long BytesSinFlyweight,
    long MilisegundosConFlyweight,
    long MilisegundosSinFlyweight)
{
    public long BytesAhorrados => BytesSinFlyweight - BytesConFlyweight;

    public double PorcentajeAhorro =>
        BytesSinFlyweight <= 0 ? 0 : 100.0 * BytesAhorrados / BytesSinFlyweight;
}

/// <summary>
/// Comparación REAL (no simulada): construye la población dos veces y mide la memoria con el GC.
/// "Sin Flyweight" cada tripulante recibe su propia copia de la especie.
/// Las cifras exactas varían entre ejecuciones; lo que importa es la proporción.
/// </summary>
public static class ComparadorFlyweight
{
    public static ResultadoComparacionFlyweight Comparar(int cantidad = GeneradorTripulantes.PoblacionEstacion)
    {
        var con = Medir(cantidad, usarFlyweight: true);
        var sin = Medir(cantidad, usarFlyweight: false);

        return new ResultadoComparacionFlyweight(
            cantidad, con.Especies, sin.Especies, con.Bytes, sin.Bytes, con.Milisegundos, sin.Milisegundos);
    }

    private static (long Bytes, long Milisegundos, int Especies) Medir(int cantidad, bool usarFlyweight)
    {
        long antes = GC.GetTotalMemory(forceFullCollection: true);
        var reloj = Stopwatch.StartNew();

        List<Tripulante> poblacion;
        int especiesCreadas;

        if (usarFlyweight)
        {
            var fabrica = new FabricaEspecies();
            poblacion = GeneradorTripulantes.Generar(cantidad, fabrica, semilla: 7);
            especiesCreadas = fabrica.InstanciasCreadas;
        }
        else
        {
            int contador = 0;
            poblacion = GeneradorTripulantes.GenerarCon(cantidad, nombre =>
            {
                contador++;
                return CatalogoEspecies.CrearIndependiente(nombre);
            }, semilla: 7);
            especiesCreadas = contador;
        }

        reloj.Stop();
        long despues = GC.GetTotalMemory(forceFullCollection: true);
        GC.KeepAlive(poblacion); // la población debe seguir viva al momento de medir

        return (Math.Max(0, despues - antes), reloj.ElapsedMilliseconds, especiesCreadas);
    }
}
