using System.Text;

namespace Kepler7.Core.Comportamiento.Visitor;

/// <summary>Calcula cuánto vale el inventario, en total y por categoría.</summary>
public sealed class CalculadorPrecio : IVisitor
{
    private int _armas, _pociones, _armaduras;

    public string Nombre => "Calculador de precio";

    public int Total => _armas + _pociones + _armaduras;

    public void Visitar(Arma arma) => _armas += arma.Precio;
    public void Visitar(Pocion pocion) => _pociones += pocion.Precio;
    public void Visitar(ArmaduraItem armadura) => _armaduras += armadura.Precio;

    public string ObtenerResultado() =>
        $"Valor total: {Total} créditos (armas {_armas}, pociones {_pociones}, armaduras {_armaduras}).";
}
