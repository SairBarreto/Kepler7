namespace Kepler7.Core.Estructural.Bridge;

/// <summary>Aviso de un problema que requiere atención pronto.</summary>
public sealed class MensajeAlerta : Mensaje
{
    public MensajeAlerta(string contenido, ICifrado cifrado) : base(contenido, cifrado) { }

    public override string Tipo => "Alerta";
    public override PrioridadMensaje Prioridad => PrioridadMensaje.Alta;

    protected override string Formatear() => $"[ALERTA] {Contenido.ToUpperInvariant()}";
}
