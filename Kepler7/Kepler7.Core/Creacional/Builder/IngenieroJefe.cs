using Kepler7.Core.Comun;

namespace Kepler7.Core.Creacional.Builder;

/// <summary>
/// DIRECTOR del patrón Builder: conoce el ORDEN de ensamblaje, no los materiales.
/// Con la misma secuencia y distinta receta se obtienen naves completamente distintas.
/// </summary>
public sealed class IngenieroJefe
{
    private INaveBuilder _receta;
    private readonly IBitacora? _bitacora;

    /// <param name="receta">Builder concreto a utilizar.</param>
    /// <param name="bitacora">Opcional: si se pasa, cada paso del ensamblaje queda registrado para mostrarlo en la UI.</param>
    public IngenieroJefe(INaveBuilder receta, IBitacora? bitacora = null)
    {
        _receta = receta ?? throw new ArgumentNullException(nameof(receta));
        _bitacora = bitacora;
    }

    /// <summary>Permite al jugador elegir otra receta sin crear otro director.</summary>
    public void CambiarReceta(INaveBuilder receta) =>
        _receta = receta ?? throw new ArgumentNullException(nameof(receta));

    /// <summary>Solo el chasis: casco, motor y combustible (nave básica y barata).</summary>
    public Nave ConstruirNaveBasica()
    {
        Iniciar();
        Paso(1, 3, "Casco", _receta.ConstruirCasco);
        Paso(2, 3, "Motor", _receta.InstalarMotor);
        Paso(3, 3, "Tanques de combustible", _receta.AgregarTanquesCombustible);
        return Terminar();
    }

    /// <summary>Ensamblaje total: los siete componentes, en orden.</summary>
    public Nave ConstruirNaveCompleta()
    {
        Iniciar();
        Paso(1, 7, "Casco", _receta.ConstruirCasco);
        Paso(2, 7, "Motor", _receta.InstalarMotor);
        Paso(3, 7, "Escudo", _receta.InstalarEscudo);
        Paso(4, 7, "Armamento", _receta.InstalarArmas);
        Paso(5, 7, "Radar", _receta.InstalarRadar);
        Paso(6, 7, "Inteligencia artificial", _receta.InstalarIA);
        Paso(7, 7, "Tanques de combustible", _receta.AgregarTanquesCombustible);
        return Terminar();
    }

    private void Iniciar()
    {
        _receta.Reiniciar();
        Registrar($"Iniciando ensamblaje con la receta {_receta.NombreReceta}.");
    }

    private Nave Terminar()
    {
        Nave nave = _receta.ObtenerNave();
        Registrar($"Nave {nave.Tipo} lista ({nave.CostoCreditos} créditos).");
        return nave;
    }

    private void Paso(int numero, int total, string descripcion, Action accion)
    {
        accion();
        Registrar($"Paso {numero}/{total} completado: {descripcion}.");
    }

    private void Registrar(string mensaje) => _bitacora?.Registrar("Ingeniero Jefe", mensaje);
}
