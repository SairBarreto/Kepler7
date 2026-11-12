namespace Kepler7.Core.Estructural.Bridge;

/// <summary>Pedido de auxilio: máxima prioridad, exige acuse de recibo.</summary>
public sealed class MensajeEmergencia : Mensaje
{
    public MensajeEmergencia(string contenido, ICifrado cifrado) : base(contenido, cifrado) { }

    public override string Tipo => "Emergencia";
    public override PrioridadMensaje Prioridad => PrioridadMensaje.Critica;

    protected override string Formatear() =>
        $"[EMERGENCIA][SOS] {Contenido.ToUpperInvariant()} // ACUSE DE RECIBO INMEDIATO";
}
