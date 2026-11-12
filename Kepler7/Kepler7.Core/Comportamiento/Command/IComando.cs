using Kepler7.Core.Dominio.Combate;

namespace Kepler7.Core.Comportamiento.Command;

/// <summary>
/// COMMAND: una acción del jugador convertida en objeto. Al ser un objeto se puede ejecutar,
/// deshacer, guardar en un historial y volver a ejecutar (rehacer).
/// </summary>
public interface IComando
{
    /// <summary>Texto para el historial, ej. "Sgt. Rex ataca a Dron Cazador".</summary>
    string Descripcion { get; }

    /// <summary>Intenta ejecutar la acción. Solo los comandos que tuvieron éxito entran al historial.</summary>
    ResultadoAccion Ejecutar();

    /// <summary>Revierte los efectos. Solo es válido después de una ejecución exitosa.</summary>
    void Deshacer();
}
