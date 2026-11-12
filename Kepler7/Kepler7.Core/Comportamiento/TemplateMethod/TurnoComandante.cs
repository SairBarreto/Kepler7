using Kepler7.Core.Comportamiento.ChainOfResponsibility;
using Kepler7.Core.Comportamiento.Command;
using Kepler7.Core.Comun;
using Kepler7.Core.Dominio.Combate;

namespace Kepler7.Core.Comportamiento.TemplateMethod;

/// <summary>
/// El comandante marca como prioridad al enemigo más peligroso y, al cerrar su turno, emite una orden de
/// campo que recarga los escudos de los aliados cercanos (redefine el paso de finalización).
/// </summary>
public sealed class TurnoComandante : TurnoUnidad
{
    private const int RadioOrden = 2;
    private const int RecargaOrden = 10;

    public TurnoComandante(Personaje unidad, ContextoCombate contexto, GestorComandos comandos, IBitacora? bitacora = null)
        : base(unidad, contexto, comandos, bitacora) { }

    protected override IComando? Decidir()
    {
        Enemigo? amenaza = Contexto.EnemigosVivos
            .OrderByDescending(e => e.PoderDeAtaque)
            .ThenBy(e => e.Nombre, StringComparer.Ordinal)
            .FirstOrDefault();

        if (amenaza is null)
        {
            Registrar("No quedan enemigos.");
            return null;
        }

        Registrar($"Marca como amenaza principal a {amenaza.Nombre} (ataque {amenaza.PoderDeAtaque}).");
        return AtacarOAcercarse(amenaza);
    }

    protected override void Finalizacion()
    {
        base.Finalizacion();

        int recargados = 0;
        foreach (Personaje aliado in Contexto.AliadosVivos.Where(a => Unidad.Posicion.Distancia(a.Posicion) <= RadioOrden))
        {
            Escudo? escudo = aliado.Defensas.Buscar<Escudo>();
            if (escudo is not null && escudo.Recargar(RecargaOrden) > 0) recargados++;
        }

        Registrar($"Orden de campo: recarga el escudo de {recargados} unidad(es) cercanas.");
    }
}
