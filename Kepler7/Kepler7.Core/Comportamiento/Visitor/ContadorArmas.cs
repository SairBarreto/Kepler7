using System.Text;

namespace Kepler7.Core.Comportamiento.Visitor;

/// <summary>Cuenta las armas y cuántas están envenenadas.</summary>
public sealed class ContadorArmas : IVisitor
{
    private readonly List<string> _nombres = new();
    private int _venenosas;

    public string Nombre => "Contador de armas";

    public int Cantidad => _nombres.Count;

    public void Visitar(Arma arma)
    {
        _nombres.Add(arma.Nombre);
        if (arma.Venenosa) _venenosas++;
    }

    public void Visitar(Pocion pocion) { /* no es un arma */ }
    public void Visitar(ArmaduraItem armadura) { /* no es un arma */ }

    public string ObtenerResultado() =>
        Cantidad == 0
            ? "No hay armas en el inventario."
            : $"{Cantidad} arma(s), {_venenosas} envenenada(s): {string.Join(", ", _nombres)}.";
}
