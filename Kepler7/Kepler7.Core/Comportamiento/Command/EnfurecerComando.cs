using Kepler7.Core.Comportamiento.State;
using Kepler7.Core.Dominio.Combate;

namespace Kepler7.Core.Comportamiento.Command;

/// <summary>
/// Entrar en furia: el combatiente pasa a Berserk (daña el doble, solo cuerpo a cuerpo, +50% de daño recibido,
/// sin curación y, al agotarse, queda aturdido). Gasta la acción de la ronda y se puede deshacer y rehacer.
/// </summary>
public sealed class EnfurecerComando : IComando
{
    private readonly Combatiente _combatiente;
    private SnapshotCombatiente? _antes;
    private SnapshotCombatiente? _despues;
    private ResultadoAccion? _resultado;

    public EnfurecerComando(Combatiente combatiente)
    {
        _combatiente = combatiente ?? throw new ArgumentNullException(nameof(combatiente));
    }

    public string Descripcion => $"{_combatiente.Nombre} entra en furia";

    public ResultadoAccion Ejecutar()
    {
        if (_combatiente.HaActuado) return ResultadoAccion.Fallo($"{_combatiente.Nombre} ya actuó en esta ronda.");

        if (_despues is not null)
        {
            _combatiente.Restaurar(_despues); // rehacer: vuelve a la foto posterior
            _combatiente.HaActuado = true;
            return _resultado!;
        }

        if (!_combatiente.EstaVivo) return ResultadoAccion.Fallo($"{_combatiente.Nombre} está fuera de combate.");
        if (_combatiente.Estado is not Normal)
            return ResultadoAccion.Fallo($"{_combatiente.Nombre} está {_combatiente.Estado.Nombre}: solo puede enfurecerse sin alteraciones.");

        _antes = _combatiente.Capturar();
        _combatiente.CambiarEstado(new Berserk());
        _despues = _combatiente.Capturar();

        _resultado = ResultadoAccion.Ok($"¡{_combatiente.Nombre} entra en furia! Daño x2, solo cuerpo a cuerpo, +50% de daño recibido y sin curación ({Berserk.DuracionPorDefecto} turnos).");
        _combatiente.HaActuado = true;
        return _resultado;
    }

    public void Deshacer()
    {
        if (_antes is not null) _combatiente.Restaurar(_antes);
        _combatiente.HaActuado = false; // deshacer devuelve la acción de la ronda
    }
}
