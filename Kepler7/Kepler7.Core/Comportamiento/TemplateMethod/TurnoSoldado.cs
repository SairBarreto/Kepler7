using Kepler7.Core.Comportamiento.Command;
using Kepler7.Core.Comun;
using Kepler7.Core.Dominio.Combate;

namespace Kepler7.Core.Comportamiento.TemplateMethod;

/// <summary>El soldado va al frente: elige al enemigo más cercano y lo ataca o se le acerca.</summary>
public sealed class TurnoSoldado : TurnoUnidad
{
    public TurnoSoldado(Personaje unidad, ContextoCombate contexto, GestorComandos comandos, IBitacora? bitacora = null)
        : base(unidad, contexto, comandos, bitacora) { }

    protected override IComando? Decidir()
    {
        Enemigo? objetivo = Contexto.MasCercano(Unidad, Contexto.EnemigosVivos);
        if (objetivo is null)
        {
            Registrar("No quedan enemigos.");
            return null;
        }

        Registrar($"Elige al enemigo más cercano: {objetivo.Nombre}.");
        return AtacarOAcercarse(objetivo);
    }
}
