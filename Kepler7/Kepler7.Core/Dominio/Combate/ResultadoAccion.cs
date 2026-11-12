using Kepler7.Core.Comportamiento.ChainOfResponsibility;

namespace Kepler7.Core.Dominio.Combate;

/// <summary>Resultado de cualquier acción de combate: si funcionó, qué pasó y (si hubo golpe) el detalle del daño.</summary>
public sealed record ResultadoAccion(bool Exito, string Mensaje, ResultadoDanio? Danio = null)
{
    public static ResultadoAccion Ok(string mensaje, ResultadoDanio? danio = null) => new(true, mensaje, danio);

    public static ResultadoAccion Fallo(string mensaje) => new(false, mensaje);
}
