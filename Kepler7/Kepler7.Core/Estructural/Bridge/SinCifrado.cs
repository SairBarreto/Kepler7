namespace Kepler7.Core.Estructural.Bridge;

/// <summary>Transmisión en claro: rápida, pero cualquiera que intercepte la señal puede leerla.</summary>
public sealed class SinCifrado : ICifrado
{
    public string Nombre => "Sin cifrado";

    public string Cifrar(string textoPlano) => textoPlano;

    public string Descifrar(string textoCifrado) => textoCifrado;
}
