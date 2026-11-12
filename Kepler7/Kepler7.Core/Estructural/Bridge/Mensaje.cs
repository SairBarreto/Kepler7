namespace Kepler7.Core.Estructural.Bridge;

public enum PrioridadMensaje
{
    Normal,
    Alta,
    Critica
}

/// <summary>Constancia de un envío, con todo lo que la UI necesita mostrar.</summary>
public sealed record ResultadoEnvio(
    string TipoMensaje,
    PrioridadMensaje Prioridad,
    string NombreCifrado,
    string ContenidoOriginal,
    string TextoFormateado,
    string TextoTransmitido,
    ICifrado CifradoUtilizado)
{
    /// <summary>Simula la recepción en la Tierra: aplica el descifrado del mismo mecanismo usado al enviar.</summary>
    public string DescifrarEnDestino() => CifradoUtilizado.Descifrar(TextoTransmitido);
}

/// <summary>
/// ABSTRACCIÓN del Bridge. Define "qué" se envía (tipo de mensaje) y delega el "cómo se protege"
/// en un <see cref="ICifrado"/>. Así 3 tipos × 3 cifrados = 9 combinaciones con solo 3 + 3 clases,
/// y la combinación se puede cambiar en tiempo de ejecución.
/// </summary>
public abstract class Mensaje
{
    protected Mensaje(string contenido, ICifrado cifrado)
    {
        Contenido = contenido ?? throw new ArgumentNullException(nameof(contenido));
        Cifrado = cifrado ?? throw new ArgumentNullException(nameof(cifrado));
    }

    public string Contenido { get; }

    /// <summary>El puente: referencia a la jerarquía de implementación.</summary>
    public ICifrado Cifrado { get; private set; }

    public abstract string Tipo { get; }
    public abstract PrioridadMensaje Prioridad { get; }

    /// <summary>Cada tipo de mensaje arma su encabezado y estilo propios.</summary>
    protected abstract string Formatear();

    /// <summary>Cambia el mecanismo de cifrado sin tocar el tipo de mensaje.</summary>
    public void CambiarCifrado(ICifrado nuevoCifrado) =>
        Cifrado = nuevoCifrado ?? throw new ArgumentNullException(nameof(nuevoCifrado));

    public ResultadoEnvio Enviar()
    {
        string formateado = Formatear();
        string transmitido = Cifrado.Cifrar(formateado);

        return new ResultadoEnvio(Tipo, Prioridad, Cifrado.Nombre, Contenido, formateado, transmitido, Cifrado);
    }
}
