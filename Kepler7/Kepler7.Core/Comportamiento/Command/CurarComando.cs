using Kepler7.Core.Comportamiento.State;
using Kepler7.Core.Dominio.Combate;

namespace Kepler7.Core.Comportamiento.Command;

/// <summary>
/// Curar a un aliado (o a sí mismo): restituye vida y elimina el veneno. Respeta las restricciones del
/// estado del objetivo (un Berserk no acepta curación) y del curador (un aturdido no puede concentrarse).
/// </summary>
public sealed class CurarComando : IComando
{
    private readonly Combatiente _curador;
    private readonly Combatiente _objetivo;
    private readonly int _cantidad;
    private SnapshotCombatiente? _antes;
    private SnapshotCombatiente? _despues;
    private ResultadoAccion? _resultado;

    public CurarComando(Combatiente curador, Combatiente objetivo, int cantidad)
    {
        _curador = curador ?? throw new ArgumentNullException(nameof(curador));
        _objetivo = objetivo ?? throw new ArgumentNullException(nameof(objetivo));
        _cantidad = cantidad;
    }

    public string Descripcion => _curador == _objetivo
        ? $"{_curador.Nombre} se cura"
        : $"{_curador.Nombre} cura a {_objetivo.Nombre}";

    public ResultadoAccion Ejecutar()
    {
        if (_curador.HaActuado) return ResultadoAccion.Fallo($"{_curador.Nombre} ya actuó en esta ronda.");

        if (_despues is not null)
        {
            _objetivo.Restaurar(_despues);
            _curador.HaActuado = true;
            return _resultado!;
        }

        if (!_curador.EstaVivo) return ResultadoAccion.Fallo($"{_curador.Nombre} está fuera de combate.");
        if (!_objetivo.EstaVivo) return ResultadoAccion.Fallo($"{_objetivo.Nombre} ya no se puede curar.");
        if (_curador.Estado is Aturdido) return ResultadoAccion.Fallo($"{_curador.Nombre} está aturdido y no puede concentrarse.");

        if (!_objetivo.Estado.PermiteCuracion)
            return ResultadoAccion.Fallo($"{_objetivo.Nombre} está {_objetivo.Estado.Nombre} y no acepta curación.");

        int distancia = _curador.Posicion.Distancia(_objetivo.Posicion);
        if (distancia > _curador.Alcance)
            return ResultadoAccion.Fallo($"{_objetivo.Nombre} está fuera del alcance de curación ({distancia} > {_curador.Alcance}).");

        SnapshotCombatiente antes = _objetivo.Capturar();

        int curado = _objetivo.Vida.Curar(_cantidad);
        bool eraVeneno = _objetivo.Estado is Envenenado;
        if (eraVeneno) _objetivo.CambiarEstado(new Normal());

        if (curado == 0 && !eraVeneno)
            return ResultadoAccion.Fallo($"{_objetivo.Nombre} no necesita curación.");

        _antes = antes;
        _despues = _objetivo.Capturar();

        string mensaje = $"{_curador.Nombre} cura {curado} de vida a {_objetivo.Nombre}" +
                         (eraVeneno ? " y elimina el veneno." : ".");
        _resultado = ResultadoAccion.Ok(mensaje);
        _curador.HaActuado = true;
        return _resultado;
    }

    public void Deshacer()
    {
        if (_antes is not null) _objetivo.Restaurar(_antes);
        _curador.HaActuado = false;
    }
}
