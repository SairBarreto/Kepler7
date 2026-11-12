using Kepler7.Core.Creacional.Builder;
using Kepler7.Core.Dominio;
using Kepler7.Core.Dominio.Combate;

namespace Kepler7.Core.Comportamiento.Command;

/// <summary>
/// Acción de gestión de la base: encargar una nave. Usa el Builder de la Fase 1 (IngenieroJefe + receta)
/// y la paga con los créditos de la base. Deshacer quita la nave y devuelve el dinero.
/// </summary>
public sealed class ConstruirComando : IComando
{
    private readonly BaseEstacion _base;
    private readonly INaveBuilder _receta;
    private readonly bool _completa;
    private Nave? _nave;

    public ConstruirComando(BaseEstacion baseEstacion, INaveBuilder receta, bool completa = true)
    {
        _base = baseEstacion ?? throw new ArgumentNullException(nameof(baseEstacion));
        _receta = receta ?? throw new ArgumentNullException(nameof(receta));
        _completa = completa;
    }

    public string Descripcion => $"Construir nave {_receta.NombreReceta}";

    public ResultadoAccion Ejecutar()
    {
        // La nave se ensambla una sola vez; rehacer vuelve a registrar la misma.
        if (_nave is null)
        {
            var director = new IngenieroJefe(_receta);
            _nave = _completa ? director.ConstruirNaveCompleta() : director.ConstruirNaveBasica();
        }

        if (!_base.Gastar(_nave.CostoCreditos))
            return ResultadoAccion.Fallo($"Créditos insuficientes: la nave {_nave.Tipo} cuesta {_nave.CostoCreditos} y la base tiene {_base.Creditos}.");

        _base.AgregarNave(_nave);
        return ResultadoAccion.Ok($"Nave {_nave.Tipo} construida por {_nave.CostoCreditos} créditos (quedan {_base.Creditos}).");
    }

    public void Deshacer()
    {
        if (_nave is null || !_base.QuitarNave(_nave)) return;
        _base.Reembolsar(_nave.CostoCreditos);
    }
}
