namespace Kepler7.Core.Estructural.Bridge;

/// <summary>
/// IMPLEMENTADOR del Bridge: la jerarquía de mecanismos de cifrado.
/// Evoluciona de forma independiente a la jerarquía de mensajes.
/// </summary>
public interface ICifrado
{
    /// <summary>Nombre para mostrar en la UI.</summary>
    string Nombre { get; }

    string Cifrar(string textoPlano);

    /// <summary>Operación inversa, la que haría el receptor en la Tierra.</summary>
    string Descifrar(string textoCifrado);
}
