using Kepler7.Core.Dominio.Combate;

namespace Kepler7.Core.Comportamiento.Command;

/// <summary>Mover una unidad (una vez por ronda). El alcance del movimiento lo decide su estado (State).</summary>
public sealed class MoverComando : IComando
{
    private readonly Combatiente _unidad;
    private readonly Posicion _destino;
    private readonly ContextoCombate _contexto;
    private Posicion _origen;

    public MoverComando(Combatiente unidad, Posicion destino, ContextoCombate contexto)
    {
        _unidad = unidad ?? throw new ArgumentNullException(nameof(unidad));
        _contexto = contexto ?? throw new ArgumentNullException(nameof(contexto));
        _destino = destino;
    }

    public string Descripcion => $"{_unidad.Nombre} se mueve a {_destino}";

    public ResultadoAccion Ejecutar()
    {
        if (_unidad.HaMovido) return ResultadoAccion.Fallo($"{_unidad.Nombre} ya se movió en esta ronda.");

        _origen = _unidad.Posicion;
        ResultadoAccion resultado = _unidad.Mover(_destino, _contexto);
        if (resultado.Exito) _unidad.HaMovido = true;
        return resultado;
    }

    public void Deshacer()
    {
        _unidad.Posicion = _origen;
        _unidad.HaMovido = false; // deshacer devuelve el movimiento de la ronda
    }
}
