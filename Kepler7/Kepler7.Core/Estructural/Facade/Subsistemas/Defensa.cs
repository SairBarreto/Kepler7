using Kepler7.Core.Comun;

namespace Kepler7.Core.Estructural.Facade.Subsistemas;

internal sealed class Defensa : SubsistemaBase
{
    public Defensa(IBitacora bitacora) : base("Defensa", bitacora) { }

    public void ArmarEscudos()
    {
        Establecer(true, 100, "Escudos armados");
        Registrar("Escudos perimetrales armados.");
    }

    public void ActivarTorretas()
    {
        Establecer(true, 100, "Torretas en alerta máxima");
        Registrar("Torretas defensivas en alerta máxima.", NivelBitacora.Critico);
    }

    public void Apagar()
    {
        Establecer(false, 0, "Desactivada");
        Registrar("Escudos y torretas desactivados.");
    }
}
