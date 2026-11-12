namespace Kepler7.Core.Estructural.Proxy;

/// <summary>
/// SUJETO común del Proxy: la bóveda real y su guardián exponen exactamente el mismo contrato,
/// así el cliente no sabe (ni le importa) con cuál está hablando.
/// </summary>
public interface IBoveda
{
    string LeerArchivo(string id);
    void EscribirArchivo(string id, string contenido);

    /// <summary>Ids de los archivos guardados (la UI lo necesita para armar la lista; el Proxy también lo protege).</summary>
    IReadOnlyList<string> ListarArchivos();
}
