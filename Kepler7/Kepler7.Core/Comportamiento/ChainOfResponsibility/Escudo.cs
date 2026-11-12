namespace Kepler7.Core.Comportamiento.ChainOfResponsibility;

/// <summary>Reserva de puntos que absorbe daño hasta agotarse. Se puede recargar.</summary>
public sealed class Escudo : ManejadorDanioBase
{
    public Escudo(int maximo)
    {
        Maximo = Math.Max(1, maximo);
        Puntos = Maximo;
    }

    public int Maximo { get; }
    public int Puntos { get; internal set; }

    public override string Nombre => "Escudo";

    /// <summary>Recupera hasta <paramref name="cantidad"/> puntos y devuelve cuántos recuperó realmente.</summary>
    public int Recargar(int cantidad)
    {
        int antes = Puntos;
        Puntos = Math.Min(Maximo, Puntos + Math.Max(0, cantidad));
        return Puntos - antes;
    }

    protected override void Procesar(Danio danio)
    {
        if (Puntos == 0)
        {
            danio.Pasar(Nombre, "Escudo agotado.");
            return;
        }

        int absorbido = Math.Min(Puntos, danio.Restante);
        Puntos -= absorbido;
        danio.Absorber(Nombre, absorbido, $"Absorbe {absorbido} (quedan {Puntos}/{Maximo}).");
    }
}
