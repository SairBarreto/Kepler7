using System.Security.Cryptography;
using System.Text;

namespace Kepler7.Core.Estructural.Bridge;

/// <summary>
/// AES-256 real (System.Security.Cryptography, parte de .NET). Cada mensaje usa un IV aleatorio
/// que viaja al comienzo del paquete; la salida es Base64(IV + datos cifrados).
/// </summary>
public sealed class CifradoAES : ICifrado
{
    private const string ClavePorDefecto = "Kepler-7/Consejo-de-Ingenieria";
    private readonly byte[] _clave;

    public CifradoAES(string? clave = null)
    {
        // Se deriva una clave de 256 bits a partir de la frase compartida con la Tierra.
        _clave = SHA256.HashData(Encoding.UTF8.GetBytes(clave ?? ClavePorDefecto));
    }

    public string Nombre => "AES-256";

    public string Cifrar(string textoPlano)
    {
        using var aes = Aes.Create();
        aes.Key = _clave;

        byte[] iv = RandomNumberGenerator.GetBytes(16);
        byte[] cifrado = aes.EncryptCbc(Encoding.UTF8.GetBytes(textoPlano), iv);

        byte[] paquete = new byte[iv.Length + cifrado.Length];
        iv.CopyTo(paquete, 0);
        cifrado.CopyTo(paquete, iv.Length);
        return Convert.ToBase64String(paquete);
    }

    public string Descifrar(string textoCifrado)
    {
        byte[] paquete = Convert.FromBase64String(textoCifrado);
        if (paquete.Length <= 16) throw new FormatException("Paquete AES inválido.");

        using var aes = Aes.Create();
        aes.Key = _clave;

        byte[] iv = paquete[..16];
        byte[] cifrado = paquete[16..];
        return Encoding.UTF8.GetString(aes.DecryptCbc(cifrado, iv));
    }
}
