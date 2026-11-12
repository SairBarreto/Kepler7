using System.Text;

namespace Kepler7.Core.Comportamiento.Visitor;

/// <summary>Resume el poder ofensivo, curativo y defensivo del inventario.</summary>
public sealed class GeneradorEstadisticas : IVisitor
{
    private int _danioTotal, _curacionUtil, _pocionesUtiles, _pocionesInservibles, _defensaTotal;

    public string Nombre => "Estadísticas del inventario";

    public void Visitar(Arma arma) => _danioTotal += arma.Danio;

    public void Visitar(Pocion pocion)
    {
        if (pocion.Contaminada)
        {
            _pocionesInservibles++;
            return;
        }

        _pocionesUtiles++;
        _curacionUtil += pocion.Curacion;
    }

    public void Visitar(ArmaduraItem armadura) => _defensaTotal += armadura.Defensa;

    public string ObtenerResultado()
    {
        var sb = new StringBuilder();
        sb.Append($"Daño base acumulado: {_danioTotal}. ");
        sb.Append($"Curación disponible: {_curacionUtil} ({_pocionesUtiles} poción(es) utilizable(s)");
        sb.Append(_pocionesInservibles > 0 ? $", {_pocionesInservibles} contaminada(s)). " : "). ");
        sb.Append($"Defensa total: {_defensaTotal}.");
        return sb.ToString();
    }
}
