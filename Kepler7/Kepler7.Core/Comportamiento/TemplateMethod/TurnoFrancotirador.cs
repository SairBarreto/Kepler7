using Kepler7.Core.Comportamiento.Command;
using Kepler7.Core.Comun;
using Kepler7.Core.Dominio.Combate;

namespace Kepler7.Core.Comportamiento.TemplateMethod;

/// <summary>
/// El francotirador pelea de lejos: se aleja si lo tienen encima y, si no, le dispara al enemigo más frágil.
/// Redefine además el paso de inicio (apuntar).
/// </summary>
public sealed class TurnoFrancotirador : TurnoUnidad
{
    public TurnoFrancotirador(Personaje unidad, ContextoCombate contexto, GestorComandos comandos, IBitacora? bitacora = null)
        : base(unidad, contexto, comandos, bitacora) { }

    protected override void Inicio()
    {
        base.Inicio();
        Registrar("Regula la mira y estima distancias.");
    }

    protected override IComando? Decidir()
    {
        List<Enemigo> enemigos = Contexto.EnemigosVivos.ToList();
        if (enemigos.Count == 0)
        {
            Registrar("No quedan enemigos.");
            return null;
        }

        Enemigo cercano = Contexto.MasCercano(Unidad, enemigos)!;
        if (Unidad.Posicion.Distancia(cercano.Posicion) <= 1)
        {
            Posicion? repliegue = Contexto.CasillaMasLejanaDe(Unidad, cercano.Posicion, Unidad.MovimientoDisponible);
            if (repliegue is { } r)
            {
                Registrar($"{cercano.Nombre} lo tiene encima: se repliega a {r} para recuperar distancia.");
                return new MoverComando(Unidad, r, Contexto);
            }
        }

        Enemigo masFragil = enemigos
            .Where(e => Unidad.Posicion.Distancia(e.Posicion) <= Unidad.Alcance)
            .OrderBy(e => e.Resistencia)
            .ThenBy(e => e.Nombre, StringComparer.Ordinal)
            .FirstOrDefault() ?? cercano;

        Registrar($"Apunta a {masFragil.Nombre} (resistencia {masFragil.Resistencia}).");
        return AtacarOAcercarse(masFragil);
    }

    /// <summary>Replegarse gasta el movimiento, no la acción: tras reubicarse, dispara al más frágil que tenga a tiro.</summary>
    protected override void Actuar(IComando? comando)
    {
        base.Actuar(comando);
        if (comando is not MoverComando || !Unidad.PuedeActuar) return;

        Enemigo? blanco = Contexto.EnemigosVivos
            .Where(e => Unidad.Posicion.Distancia(e.Posicion) <= Unidad.Alcance)
            .OrderBy(e => e.Resistencia)
            .ThenBy(e => e.Nombre, StringComparer.Ordinal)
            .FirstOrDefault();
        if (blanco is null) return;

        Registrar($"Desde su nueva posición dispara a {blanco.Nombre}.");
        ResultadoAccion disparo = Comandos.Ejecutar(new AtacarComando(Unidad, blanco));
        Registrar(disparo.Exito ? disparo.Mensaje : $"Acción fallida: {disparo.Mensaje}");
    }
}
