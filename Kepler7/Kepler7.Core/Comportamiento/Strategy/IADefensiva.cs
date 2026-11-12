using Kepler7.Core.Comportamiento.ChainOfResponsibility;
using Kepler7.Core.Dominio.Combate;

namespace Kepler7.Core.Comportamiento.Strategy;

/// <summary>
/// Prioriza sobrevivir: si está herido o con el escudo bajo, se repliega o se cubre; recién cuando se
/// siente seguro ataca a quien tenga al alcance. Nunca persigue.
/// </summary>
public sealed class IADefensiva : IEstrategiaIA
{
    public string Nombre => "IA Defensiva";

    public AccionIA DecidirAccion(Enemigo enemigo, ContextoCombate contexto)
    {
        Personaje? cercano = contexto.MasCercano(enemigo, contexto.AliadosVivos);
        if (cercano is null) return AccionIA.Esperar("no quedan objetivos");

        int distancia = enemigo.Posicion.Distancia(cercano.Posicion);
        double proporcionVida = enemigo.Vida.Actual / (double)enemigo.Vida.Maxima;
        Escudo? escudo = enemigo.Defensas.Buscar<Escudo>();
        bool escudoBajo = escudo is not null && escudo.Puntos < escudo.Maximo / 2;

        if (proporcionVida < 0.5 || escudoBajo)
        {
            if (distancia <= 2)
            {
                Posicion? repliegue = contexto.CasillaMasLejanaDe(enemigo, cercano.Posicion, enemigo.MovimientoDisponible);
                if (repliegue is { } r) return AccionIA.Mover(r, $"herido, se repliega para alejarse de {cercano.Nombre}");
            }

            if (escudo is not null && escudo.Puntos < escudo.Maximo)
                return AccionIA.Defender("se cubre y recarga el escudo antes de arriesgarse");
        }

        if (distancia <= enemigo.Alcance)
            return AccionIA.Atacar(cercano, $"se siente seguro y dispara a {cercano.Nombre}, que entró en su alcance");

        return AccionIA.Esperar("mantiene la posición y deja que el enemigo se acerque");
    }
}
