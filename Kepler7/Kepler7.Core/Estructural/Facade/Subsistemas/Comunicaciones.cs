using Kepler7.Core.Comun;

namespace Kepler7.Core.Estructural.Facade.Subsistemas;

internal sealed class Comunicaciones : SubsistemaBase
{
    public Comunicaciones(IBitacora bitacora) : base("Comunicaciones", bitacora) { }

    public void AbrirCanalTierra()
    {
        Establecer(true, 100, "Canal con la Tierra abierto");
        Registrar("Enlace con la Tierra establecido.");
    }

    public void TransmitirSOS()
    {
        Establecer(true, 100, "Transmitiendo SOS");
        Registrar("Señal de socorro SOS transmitida a la Tierra.", NivelBitacora.Critico);
    }

    public void Apagar()
    {
        Establecer(false, 0, "Sin señal");
        Registrar("Último reporte enviado; enlace cerrado.");
    }
}
