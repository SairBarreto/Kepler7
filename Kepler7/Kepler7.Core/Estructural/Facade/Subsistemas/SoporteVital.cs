using Kepler7.Core.Comun;

namespace Kepler7.Core.Estructural.Facade.Subsistemas;

internal sealed class SoporteVital : SubsistemaBase
{
    public SoporteVital(IBitacora bitacora) : base("Soporte Vital", bitacora) { }

    public void Activar()
    {
        Establecer(true, 100, "Atmósfera estable en todos los módulos");
        Registrar("Reciclaje de aire y agua operativo; módulos presurizados.");
    }

    public void ReducirAModulosCriticos()
    {
        Establecer(true, 70, "Solo módulos críticos");
        Registrar("Soporte restringido a módulos críticos para ahorrar energía.", NivelBitacora.Advertencia);
    }

    public void Apagar()
    {
        Establecer(false, 0, "Modo latencia");
        Registrar("Soporte vital en modo latencia.");
    }
}
