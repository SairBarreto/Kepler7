using Kepler7.Core.Comportamiento.ChainOfResponsibility;
using Kepler7.Core.Dominio.Combate;

namespace Kepler7.Core.Comportamiento.State;

/// <summary>
/// Mecánica común que los estados parametrizan (multiplicador, alcance, pasos). Cada estado concreto
/// implementa sus tres operaciones eligiendo sus valores; la resolución compartida vive acá una sola vez.
/// </summary>
public abstract class EstadoPersonajeBase : IEstadoPersonaje
{
    protected EstadoPersonajeBase(int turnosRestantes = 0)
    {
        TurnosRestantes = turnosRestantes;
    }

    public abstract string Nombre { get; }
    public abstract string ColorHex { get; }
    public int TurnosRestantes { get; }
    public virtual bool PermiteCuracion => true;

    public abstract int MovimientoPermitido(Combatiente combatiente);
    /// <summary>Por defecto el alcance propio del combatiente; Berserk y Aturdido lo redefinen.</summary>
    public virtual int AlcancePermitido(Combatiente combatiente) => combatiente.Alcance;
    public abstract ResultadoAccion Atacar(Combatiente atacante, Combatiente objetivo);
    public abstract ResultadoAccion Mover(Combatiente combatiente, Posicion destino, ContextoCombate contexto);
    public abstract ResultadoDanio RecibirDanio(Combatiente combatiente, Danio danio);

    public virtual ResultadoAccion AlFinalizarTurno(Combatiente combatiente) =>
        ResultadoAccion.Ok($"{combatiente.Nombre} termina su turno.");

    /// <summary>Resuelve un ataque: validaciones, daño, paso por la cadena de defensas y efecto de arma envenenada.</summary>
    protected static ResultadoAccion EjecutarAtaque(Combatiente atacante, Combatiente objetivo, double multiplicador, int alcance)
    {
        if (!atacante.EstaVivo) return ResultadoAccion.Fallo($"{atacante.Nombre} está fuera de combate.");
        if (!objetivo.EstaVivo) return ResultadoAccion.Fallo($"{objetivo.Nombre} ya está fuera de combate.");

        int distancia = atacante.Posicion.Distancia(objetivo.Posicion);
        if (distancia > alcance)
            return ResultadoAccion.Fallo($"{objetivo.Nombre} está fuera de alcance ({distancia} > {alcance}).");

        int cantidad = (int)Math.Round(atacante.PoderDeAtaque * multiplicador);
        var danio = new Danio(cantidad, atacante.TipoDeAtaque, atacante.Nombre);
        ResultadoDanio resultado = objetivo.RecibirDanio(danio);

        string mensaje = $"{atacante.Nombre} ataca a {objetivo.Nombre} ({cantidad} de daño {danio.Tipo.ToString().ToLowerInvariant()}): {resultado.Resumen}.";

        // Arma envenenada (Visitor) + estado (State): si el golpe conecta, el objetivo queda envenenado.
        bool puedeEnvenenarse = objetivo.Estado is Normal or Envenenado;
        if (atacante.ArmaEquipada is { Venenosa: true } && !resultado.Esquivado && objetivo.EstaVivo && puedeEnvenenarse)
        {
            objetivo.CambiarEstado(new Envenenado(Envenenado.DuracionPorDefecto));
            mensaje += $" ¡El arma está envenenada: {objetivo.Nombre} queda envenenado!";
        }

        // Arma aturdidora (State): si el golpe conecta y el objetivo está sin alteraciones, queda aturdido un turno.
        if (atacante.ArmaEquipada is { Aturdidora: true } && !resultado.Esquivado && objetivo.EstaVivo && objetivo.Estado is Normal)
        {
            objetivo.CambiarEstado(new Aturdido(1));
            mensaje += $" ¡El golpe aturde a {objetivo.Nombre}!";
        }

        return ResultadoAccion.Ok(mensaje, resultado);
    }

    /// <summary>Resuelve un movimiento: límites del tablero, distancia permitida y casilla libre.</summary>
    protected static ResultadoAccion EjecutarMovimiento(Combatiente combatiente, Posicion destino, ContextoCombate contexto, int maximoCasillas)
    {
        if (!combatiente.EstaVivo) return ResultadoAccion.Fallo($"{combatiente.Nombre} está fuera de combate.");

        int distancia = combatiente.Posicion.Distancia(destino);
        if (distancia == 0) return ResultadoAccion.Fallo($"{combatiente.Nombre} ya está en {destino}.");
        if (distancia > maximoCasillas)
            return ResultadoAccion.Fallo($"{destino} está demasiado lejos ({distancia} > {maximoCasillas} casillas permitidas).");
        if (!contexto.EnTablero(destino)) return ResultadoAccion.Fallo($"{destino} está fuera del tablero.");
        if (!contexto.EstaLibre(destino)) return ResultadoAccion.Fallo($"{destino} está ocupada.");

        Posicion origen = combatiente.Posicion;
        combatiente.Posicion = destino;
        return ResultadoAccion.Ok($"{combatiente.Nombre} se mueve de {origen} a {destino}.");
    }

    /// <summary>Hace pasar el daño por la cadena de defensas, escalándolo antes si el estado lo exige.</summary>
    protected static ResultadoDanio AplicarDanio(Combatiente combatiente, Danio danio, double multiplicador)
    {
        Danio efectivo = multiplicador == 1.0
            ? danio
            : new Danio((int)Math.Ceiling(danio.Cantidad * multiplicador), danio.Tipo, danio.Origen);

        return combatiente.Defensas.Procesar(efectivo, combatiente.Nombre);
    }
}
