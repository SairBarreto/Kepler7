namespace Kepler7.Core.Dominio.Combate;

/// <summary>Casilla del tablero táctico.</summary>
public readonly record struct Posicion(int X, int Y)
{
    /// <summary>Distancia Manhattan (cuadras): lo que cuesta caminar o apuntar en una grilla sin diagonales.</summary>
    public int Distancia(Posicion otra) => Math.Abs(X - otra.X) + Math.Abs(Y - otra.Y);

    public override string ToString() => $"({X},{Y})";
}
