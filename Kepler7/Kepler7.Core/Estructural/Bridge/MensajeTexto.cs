namespace Kepler7.Core.Estructural.Bridge;

/// <summary>Comunicación rutinaria con la Tierra.</summary>
public sealed class MensajeTexto : Mensaje
{
    public MensajeTexto(string contenido, ICifrado cifrado) : base(contenido, cifrado) { }

    public override string Tipo => "Texto";
    public override PrioridadMensaje Prioridad => PrioridadMensaje.Normal;

    protected override string Formatear() => $"[TEXTO] {Contenido}";
}
