using Kepler7.Core.Comun;

namespace Kepler7.Core.Estructural.Facade.Subsistemas;

internal sealed class Seguridad : SubsistemaBase
{
    public Seguridad(IBitacora bitacora) : base("Seguridad", bitacora) { }

    public void PatrullarSectores()
    {
        Establecer(true, 100, "Patrullas activas");
        Registrar("Patrullas desplegadas en todos los sectores.");
    }

    public void SellarCompuertas()
    {
        Establecer(true, 90, "Compuertas selladas");
        Registrar("Compuertas selladas; sectores aislados.", NivelBitacora.Advertencia);
    }

    public void Apagar()
    {
        Establecer(false, 0, "Sin vigilancia");
        Registrar("Patrullas replegadas.");
    }
}
