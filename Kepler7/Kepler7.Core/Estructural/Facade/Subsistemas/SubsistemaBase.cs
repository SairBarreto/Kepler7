using Kepler7.Core.Comun;

namespace Kepler7.Core.Estructural.Facade.Subsistemas;

/// <summary>
/// Base común de los subsistemas. Es INTERNA a propósito: desde Kepler7.Game es imposible
/// instanciar o invocar un subsistema; el único camino es <see cref="ControlCentral"/>.
/// </summary>
internal abstract class SubsistemaBase
{
    private readonly IBitacora _bitacora;

    protected SubsistemaBase(string nombre, IBitacora bitacora)
    {
        Nombre = nombre;
        _bitacora = bitacora;
    }

    public string Nombre { get; }
    public bool Activo { get; private set; }

    /// <summary>Rendimiento 0-100 (la UI lo puede dibujar como barra).</summary>
    public int Nivel { get; private set; }

    public string Detalle { get; private set; } = "Apagado";

    public EstadoSubsistema ObtenerEstado() => new(Nombre, Activo, Nivel, Detalle);

    /// <summary>Mantenimiento que ocurre en cada turno. Los subsistemas pueden redefinirlo.</summary>
    public virtual void ProcesarTurno() => Registrar($"Ciclo de turno completado: {Detalle}.");

    protected void Establecer(bool activo, int nivel, string detalle)
    {
        Activo = activo;
        Nivel = nivel;
        Detalle = detalle;
    }

    protected void Registrar(string mensaje, NivelBitacora nivel = NivelBitacora.Info) =>
        _bitacora.Registrar(Nombre, mensaje, nivel);
}
