using Kepler7.Core.Comportamiento.Command;
using Kepler7.Core.Comportamiento.State;
using Kepler7.Core.Comun;
using Kepler7.Core.Dominio.Combate;

namespace Kepler7.Core.Comportamiento.TemplateMethod;

/// <summary>El médico atiende primero a los envenenados y luego a los más heridos; si nadie lo necesita, se defiende.</summary>
public sealed class TurnoMedico : TurnoUnidad
{
    private const double UmbralHerido = 0.7;

    public TurnoMedico(Personaje unidad, ContextoCombate contexto, GestorComandos comandos, IBitacora? bitacora = null)
        : base(unidad, contexto, comandos, bitacora) { }

    protected override IComando? Decidir()
    {
        List<Personaje> necesitados = Contexto.AliadosVivos
            .Where(a => a.Estado.PermiteCuracion && (a.Estado is Envenenado || a.Vida.Actual < a.Vida.Maxima * UmbralHerido))
            .OrderByDescending(a => a.Estado is Envenenado)
            .ThenBy(a => a.Vida.Actual / (double)a.Vida.Maxima)
            .ThenBy(a => a.Nombre, StringComparer.Ordinal)
            .ToList();

        if (necesitados.Count > 0)
        {
            Personaje paciente = necesitados[0];
            int distancia = Unidad.Posicion.Distancia(paciente.Posicion);

            if (distancia <= Unidad.Alcance)
            {
                Registrar($"{paciente.Nombre} necesita ayuda ({paciente.Estado.Nombre}, vida {paciente.Vida.Actual}/{paciente.Vida.Maxima}): lo atiende.");
                return new CurarComando(Unidad, paciente, Unidad.PoderCuracion);
            }

            Posicion? destino = Contexto.CasillaMasCercanaA(Unidad, paciente.Posicion, Unidad.MovimientoDisponible);
            if (destino is { } d)
            {
                Registrar($"{paciente.Nombre} necesita ayuda pero está a {distancia}: corre hacia {d}.");
                return new MoverComando(Unidad, d, Contexto);
            }
        }

        Enemigo? enemigo = Contexto.MasCercano(Unidad, Contexto.EnemigosVivos);
        if (enemigo is not null && Unidad.Posicion.Distancia(enemigo.Posicion) <= Unidad.Alcance)
        {
            Registrar($"Nadie necesita curación y {enemigo.Nombre} está encima: se defiende.");
            return new AtacarComando(Unidad, enemigo);
        }

        Registrar("Nadie necesita curación: vigila al escuadrón.");
        return null;
    }
}
