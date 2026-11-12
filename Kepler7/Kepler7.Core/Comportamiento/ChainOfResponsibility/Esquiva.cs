namespace Kepler7.Core.Comportamiento.ChainOfResponsibility;

/// <summary>Primera línea: con cierta probabilidad evita el golpe por completo.</summary>
public sealed class Esquiva : ManejadorDanioBase
{
    private readonly Random _azar;

    public Esquiva(double probabilidad, Random? azar = null)
    {
        Probabilidad = Math.Clamp(probabilidad, 0, 1);
        _azar = azar ?? Random.Shared;
    }

    public double Probabilidad { get; set; }

    public override string Nombre => "Esquiva";

    protected override void Procesar(Danio danio)
    {
        double tirada = _azar.NextDouble();

        if (tirada < Probabilidad)
            danio.Esquivar(Nombre, $"¡Esquivado! (tirada {tirada:P0} < {Probabilidad:P0})");
        else
            danio.Pasar(Nombre, $"No logra esquivar (tirada {tirada:P0} ≥ {Probabilidad:P0}).");
    }
}
