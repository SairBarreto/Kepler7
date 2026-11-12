using Kepler7.Core.Comun;

namespace Kepler7.Core.Estructural.Facade.Subsistemas;

internal sealed class Navegacion : SubsistemaBase
{
    public Navegacion(IBitacora bitacora) : base("Navegación", bitacora) { }

    public void MantenerOrbita()
    {
        Establecer(true, 100, "Órbita estable");
        Registrar("Órbita estabilizada alrededor del planeta.");
    }

    public void CalcularRutaEvacuacion()
    {
        Establecer(true, 85, "Ruta de evacuación calculada");
        Registrar("Ruta de evacuación calculada; propulsores listos.", NivelBitacora.Advertencia);
    }

    public void Apagar()
    {
        Establecer(false, 0, "Propulsores apagados");
        Registrar("Propulsores apagados; órbita pasiva.");
    }
}
