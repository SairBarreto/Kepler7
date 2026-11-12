using Kepler7.Core.Dominio.Combate;

namespace Kepler7.Core.Comportamiento.Command;

/// <summary>
/// Atacar a un objetivo. Guarda una foto del objetivo antes y después del golpe: deshacer restaura la
/// de antes y rehacer vuelve a la de después, de modo que repetir el ataque da EXACTAMENTE el mismo
/// resultado (sin volver a tirar la esquiva ni el bloqueo).
/// </summary>
public sealed class AtacarComando : IComando
{
    private readonly Combatiente _atacante;
    private readonly Combatiente _objetivo;
    private SnapshotCombatiente? _antes;
    private SnapshotCombatiente? _despues;
    private ResultadoAccion? _resultado;

    public AtacarComando(Combatiente atacante, Combatiente objetivo)
    {
        _atacante = atacante ?? throw new ArgumentNullException(nameof(atacante));
        _objetivo = objetivo ?? throw new ArgumentNullException(nameof(objetivo));
    }

    public string Descripcion => $"{_atacante.Nombre} ataca a {_objetivo.Nombre}";

    public ResultadoAccion Ejecutar()
    {
        if (_atacante.HaActuado) return ResultadoAccion.Fallo($"{_atacante.Nombre} ya actuó en esta ronda.");

        if (_despues is not null)
        {
            _objetivo.Restaurar(_despues); // rehacer: reproduce el mismo golpe
            _atacante.HaActuado = true;
            return _resultado!;
        }

        SnapshotCombatiente antes = _objetivo.Capturar();
        ResultadoAccion resultado = _atacante.Atacar(_objetivo);

        if (resultado.Exito)
        {
            _antes = antes;
            _despues = _objetivo.Capturar();
            _resultado = resultado;
            _atacante.HaActuado = true;
        }

        return resultado;
    }

    public void Deshacer()
    {
        if (_antes is not null) _objetivo.Restaurar(_antes);
        _atacante.HaActuado = false; // deshacer devuelve la acción de la ronda
    }
}
