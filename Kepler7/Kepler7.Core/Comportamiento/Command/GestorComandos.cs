using Kepler7.Core.Dominio.Combate;

namespace Kepler7.Core.Comportamiento.Command;

/// <summary>
/// INVOCADOR del patrón Command: ejecuta comandos y mantiene las pilas de deshacer y rehacer
/// más un historial legible. Ejecutar una acción nueva descarta lo que se podía rehacer.
/// </summary>
public sealed class GestorComandos
{
    private readonly Stack<IComando> _deshacer = new();
    private readonly Stack<IComando> _rehacer = new();
    private readonly List<string> _historial = new();

    /// <summary>Se dispara cuando cambia el historial o alguna pila (para habilitar/deshabilitar los botones).</summary>
    public event EventHandler? Cambio;

    public bool PuedeDeshacer => _deshacer.Count > 0;
    public bool PuedeRehacer => _rehacer.Count > 0;

    /// <summary>Bitácora de operaciones en orden cronológico ("Ejecutado: …", "Deshecho: …", "Rehecho: …").</summary>
    public IReadOnlyList<string> Historial => _historial.ToArray();

    public ResultadoAccion Ejecutar(IComando comando)
    {
        ArgumentNullException.ThrowIfNull(comando);

        ResultadoAccion resultado = comando.Ejecutar();
        if (!resultado.Exito) return resultado; // una acción inválida no ensucia el historial

        _deshacer.Push(comando);
        _rehacer.Clear();
        Anotar($"Ejecutado: {comando.Descripcion}");
        return resultado;
    }

    public ResultadoAccion Deshacer()
    {
        if (!PuedeDeshacer) return ResultadoAccion.Fallo("No hay nada para deshacer.");

        IComando comando = _deshacer.Pop();
        comando.Deshacer();
        _rehacer.Push(comando);
        Anotar($"Deshecho: {comando.Descripcion}");
        return ResultadoAccion.Ok($"Deshecho: {comando.Descripcion}.");
    }

    public ResultadoAccion Rehacer()
    {
        if (!PuedeRehacer) return ResultadoAccion.Fallo("No hay nada para rehacer.");

        IComando comando = _rehacer.Pop();
        ResultadoAccion resultado = comando.Ejecutar();

        if (!resultado.Exito)
        {
            // El mundo cambió y ya no se puede repetir: se descarta para no dejar una acción imposible en la pila.
            Anotar($"No se pudo rehacer: {comando.Descripcion} ({resultado.Mensaje})");
            return resultado;
        }

        _deshacer.Push(comando);
        Anotar($"Rehecho: {comando.Descripcion}");
        return ResultadoAccion.Ok($"Rehecho: {comando.Descripcion}.", resultado.Danio);
    }

    /// <summary>Vacía las pilas (no se puede deshacer una ronda ya cerrada). El historial se conserva.</summary>
    public void Limpiar()
    {
        _deshacer.Clear();
        _rehacer.Clear();
        Cambio?.Invoke(this, EventArgs.Empty);
    }

    private void Anotar(string linea)
    {
        _historial.Add(linea);
        Cambio?.Invoke(this, EventArgs.Empty);
    }
}
