using System.Collections.Concurrent;
using System.Security.Cryptography;
using System.Text;

namespace Kepler7.Core.Estructural.Bridge;

/// <summary>
/// Cifrado "cuántico" ficticio inspirado en la distribución cuántica de claves:
/// cada mensaje usa una clave aleatoria de un solo uso (one-time pad, XOR) tan larga como el texto.
/// Al descifrar, la clave se consume: "el estado cuántico colapsa" y no se puede leer dos veces.
/// </summary>
public sealed class CifradoCuantico : ICifrado
{
    private const string Prefijo = "Q-";
    private readonly ConcurrentDictionary<Guid, byte[]> _estados = new();

    public string Nombre => "Cuántico (clave de un solo uso)";

    public string Cifrar(string textoPlano)
    {
        byte[] datos = Encoding.UTF8.GetBytes(textoPlano);
        byte[] clave = RandomNumberGenerator.GetBytes(datos.Length);

        var cifrado = new byte[datos.Length];
        for (int i = 0; i < datos.Length; i++) cifrado[i] = (byte)(datos[i] ^ clave[i]);

        var idEstado = Guid.NewGuid();
        _estados[idEstado] = clave;
        return $"{Prefijo}{idEstado:N}:{Convert.ToBase64String(cifrado)}";
    }

    public string Descifrar(string textoCifrado)
    {
        int separador = textoCifrado.IndexOf(':');
        if (!textoCifrado.StartsWith(Prefijo) || separador < 0 ||
            !Guid.TryParseExact(textoCifrado[Prefijo.Length..separador], "N", out Guid idEstado))
        {
            throw new FormatException("Paquete cuántico inválido.");
        }

        if (!_estados.TryRemove(idEstado, out byte[]? clave))
            throw new InvalidOperationException("El estado cuántico ya colapsó: la clave de un solo uso fue consumida.");

        byte[] cifrado = Convert.FromBase64String(textoCifrado[(separador + 1)..]);
        var datos = new byte[cifrado.Length];
        for (int i = 0; i < cifrado.Length; i++) datos[i] = (byte)(cifrado[i] ^ clave[i]);
        return Encoding.UTF8.GetString(datos);
    }
}
