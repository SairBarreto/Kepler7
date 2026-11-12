using System.Text;

namespace Kepler7.Core.Comportamiento.Visitor;

/// <summary>
/// Unta veneno en el arsenal: las armas pasan a envenenar a quien golpean (se conecta con el patrón State)
/// y las pociones quedan contaminadas. Las armaduras no se ven afectadas.
/// </summary>
public sealed class AplicadorVeneno : IVisitor
{
    private int _armasEnvenenadas, _pocionesContaminadas, _ignoradas;

    public string Nombre => "Aplicador de veneno";

    public void Visitar(Arma arma)
    {
        if (arma.Venenosa) return; // ya estaba envenenada
        arma.Venenosa = true;
        _armasEnvenenadas++;
    }

    public void Visitar(Pocion pocion)
    {
        if (pocion.Contaminada) return;
        pocion.Contaminada = true;
        _pocionesContaminadas++;
    }

    public void Visitar(ArmaduraItem armadura) => _ignoradas++;

    public string ObtenerResultado() =>
        $"Veneno aplicado: {_armasEnvenenadas} arma(s) envenenada(s), {_pocionesContaminadas} poción(es) contaminada(s); " +
        $"{_ignoradas} armadura(s) sin efecto.";
}
