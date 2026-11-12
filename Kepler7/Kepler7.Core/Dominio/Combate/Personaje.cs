using Kepler7.Core.Comportamiento.ChainOfResponsibility;

namespace Kepler7.Core.Dominio.Combate;

/// <summary>Especialidad de cada miembro del escuadrón; decide qué TurnoUnidad le corresponde.</summary>
public enum ClaseUnidad
{
    Soldado,
    Medico,
    Francotirador,
    Comandante
}

/// <summary>Miembro del escuadrón de Kepler-7 controlado por el jugador.</summary>
public sealed class Personaje : Combatiente
{
    public Personaje(string nombre, ClaseUnidad clase, Posicion posicion, int ataque, int alcance, int movimiento,
                     CadenaDefensa defensas, int poderCuracion = 0)
        : base(nombre, posicion, ataque, alcance, movimiento, defensas)
    {
        Clase = clase;
        PoderCuracion = poderCuracion;
    }

    public ClaseUnidad Clase { get; }

    /// <summary>Vida que restituye con CurarComando (solo el médico tiene un valor significativo).</summary>
    public int PoderCuracion { get; }
}
