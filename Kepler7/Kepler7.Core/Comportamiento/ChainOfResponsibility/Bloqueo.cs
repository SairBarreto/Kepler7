namespace Kepler7.Core.Comportamiento.ChainOfResponsibility;

/// <summary>Con cierta probabilidad logra interponer la guardia y absorbe un porcentaje del golpe.</summary>
public sealed class Bloqueo : ManejadorDanioBase
{
    private readonly Random _azar;

    /// <param name="probabilidad">Chance de que el bloqueo salga bien (0-1).</param>
    /// <param name="porcentajeAbsorbido">Fracción del daño que se absorbe si sale bien (0-1).</param>
    /// <param name="azar">Generador de números aleatorios (inyectable para reproducir partidas).</param>
    public Bloqueo(double probabilidad, double porcentajeAbsorbido = 0.5, Random? azar = null)
    {
        Probabilidad = Math.Clamp(probabilidad, 0, 1);
        PorcentajeAbsorbido = Math.Clamp(porcentajeAbsorbido, 0, 1);
        _azar = azar ?? Random.Shared;
    }

    public double Probabilidad { get; set; }
    public double PorcentajeAbsorbido { get; set; }

    public override string Nombre => "Bloqueo";

    protected override void Procesar(Danio danio)
    {
        double tirada = _azar.NextDouble();

        if (tirada < Probabilidad)
        {
            int absorbido = (int)Math.Round(danio.Restante * PorcentajeAbsorbido);
            danio.Absorber(Nombre, absorbido, $"Bloquea {PorcentajeAbsorbido:P0} del golpe (-{absorbido}).");
        }
        else
        {
            danio.Pasar(Nombre, "Guardia baja: no logra bloquear.");
        }
    }
}
