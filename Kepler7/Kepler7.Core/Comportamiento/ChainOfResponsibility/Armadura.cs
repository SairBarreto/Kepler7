namespace Kepler7.Core.Comportamiento.ChainOfResponsibility;

/// <summary>
/// Reduce una cantidad FIJA de cada golpe. Es eficaz contra daño cinético y solo la mitad de
/// eficaz contra energía (el blindaje físico no frena un rayo).
/// </summary>
public sealed class Armadura : ManejadorDanioBase
{
    public Armadura(int valor)
    {
        Valor = Math.Max(0, valor);
    }

    public int Valor { get; set; }

    public override string Nombre => "Armadura";

    protected override void Procesar(Danio danio)
    {
        int efectivo = danio.Tipo == TipoDanio.Energia ? Valor / 2 : Valor;

        if (efectivo <= 0)
        {
            danio.Pasar(Nombre, "Sin blindaje efectivo contra este tipo de daño.");
            return;
        }

        danio.Absorber(Nombre, efectivo, $"Absorbe {Math.Min(efectivo, danio.Restante)} (blindaje {efectivo}).");
    }
}
