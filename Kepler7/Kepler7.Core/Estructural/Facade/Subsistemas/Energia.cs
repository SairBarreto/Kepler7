using Kepler7.Core.Comun;

namespace Kepler7.Core.Estructural.Facade.Subsistemas;

internal sealed class Energia : SubsistemaBase
{
    public Energia(IBitacora bitacora) : base("Energía", bitacora) { }

    public void Encender()
    {
        Establecer(true, 100, "Reactor en línea");
        Registrar("Reactor de fusión encendido al 100%.");
    }

    public void DerivarAReservas()
    {
        Establecer(true, 60, "Reservas de emergencia");
        Registrar("Potencia derivada a soporte vital y escudos; reactor al 60%.", NivelBitacora.Advertencia);
    }

    /// <summary>Después de una emergencia el reactor se recupera de a poco, turno a turno.</summary>
    public override void ProcesarTurno()
    {
        if (Nivel < 100)
        {
            int nuevoNivel = Math.Min(100, Nivel + 10);
            Establecer(true, nuevoNivel, nuevoNivel == 100 ? "Reactor en línea" : "Recuperando potencia");
        }

        Registrar($"Reactor al {Nivel}%.");
    }

    public void Apagar()
    {
        Establecer(false, 0, "Apagado");
        Registrar("Reactor apagado.");
    }
}
