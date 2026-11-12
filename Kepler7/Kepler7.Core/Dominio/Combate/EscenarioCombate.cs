using Kepler7.Core.Comportamiento.ChainOfResponsibility;
using Kepler7.Core.Comportamiento.Strategy;
using Kepler7.Core.Comportamiento.Visitor;
using Kepler7.Core.Comun;

namespace Kepler7.Core.Dominio.Combate;

/// <summary>
/// Escenario de arranque: el escuadrón de Kepler-7 contra cuatro enemigos, cada uno con una IA distinta,
/// en un tablero de 8x8. Con la misma semilla la batalla se reproduce idéntica.
/// </summary>
public static class EscenarioCombate
{
    /// <param name="semilla">Semilla del azar: con la misma semilla la batalla es reproducible.</param>
    /// <param name="creditosIniciales">Créditos de la base si no se le pasa una.</param>
    /// <param name="bitacora">Bitácora compartida; si es null se crea una propia.</param>
    /// <param name="baseEstacion">Base compartida con el resto del juego; si es null se crea una con <paramref name="creditosIniciales"/>.</param>
    public static MotorCombate Crear(int semilla = 7, int creditosIniciales = 3000, IBitacora? bitacora = null, BaseEstacion? baseEstacion = null)
    {
        var azar = new Random(semilla);
        var contexto = new ContextoCombate(8, 8, azar);
        Inventario inventario = Inventario.Inicial();

        Arma rifle = inventario.De<Arma>().First(a => a.Nombre == "Rifle de pulsos");
        Arma francotirador = inventario.De<Arma>().First(a => a.Nombre == "Rifle de francotirador");
        Arma plasma = inventario.De<Arma>().First(a => a.Nombre == "Pistola de plasma");
        ArmaduraItem exoesqueleto = inventario.De<ArmaduraItem>().First(a => a.Nombre == "Exoesqueleto pesado");
        ArmaduraItem chaleco = inventario.De<ArmaduraItem>().First(a => a.Nombre == "Chaleco balístico");

        // ---- Escuadrón ----
        var rex = new Personaje("Sgt. Rex", ClaseUnidad.Soldado, new Posicion(1, 3), ataque: 6, alcance: 3, movimiento: 3,
            CadenaDefensa.Estandar(vida: 100, armadura: 3, escudo: 15, esquiva: 0.10, bloqueo: 0.30, azar));
        rex.EquiparArma(rifle);
        rex.EquiparArmadura(exoesqueleto);

        var vega = new Personaje("Dra. Vega", ClaseUnidad.Medico, new Posicion(0, 4), ataque: 4, alcance: 2, movimiento: 3,
            CadenaDefensa.Estandar(vida: 70, armadura: 1, escudo: 10, esquiva: 0.15, bloqueo: 0.10, azar), poderCuracion: 25);

        var kira = new Personaje("Kira", ClaseUnidad.Francotirador, new Posicion(0, 2), ataque: 8, alcance: 5, movimiento: 2,
            CadenaDefensa.Estandar(vida: 60, armadura: 0, escudo: 10, esquiva: 0.20, bloqueo: 0, azar));
        kira.EquiparArma(francotirador);

        var ortiz = new Personaje("Cmdr. Ortiz", ClaseUnidad.Comandante, new Posicion(1, 4), ataque: 8, alcance: 3, movimiento: 3,
            CadenaDefensa.Estandar(vida: 90, armadura: 4, escudo: 25, esquiva: 0.10, bloqueo: 0.20, azar));
        ortiz.EquiparArma(plasma);
        ortiz.EquiparArmadura(chaleco);

        contexto.Agregar(rex);
        contexto.Agregar(vega);
        contexto.Agregar(kira);
        contexto.Agregar(ortiz);

        // ---- Enemigos: una estrategia distinta cada uno ----
        contexto.Agregar(new Enemigo("Dron Cazador", new Posicion(6, 2), ataque: 48, alcance: 1, movimiento: 3,
            CadenaDefensa.Estandar(vida: 80, armadura: 2, escudo: 0, esquiva: 0.15, bloqueo: 0, azar), new IAAgresiva()));

        contexto.Agregar(new Enemigo("Centinela", new Posicion(7, 3), ataque: 42, alcance: 3, movimiento: 2,
            CadenaDefensa.Estandar(vida: 100, armadura: 4, escudo: 30, esquiva: 0.05, bloqueo: 0.25, azar), new IADefensiva()));

        var saqueador = new Enemigo("Saqueador", new Posicion(6, 4), ataque: 45, alcance: 1, movimiento: 3,
            CadenaDefensa.Estandar(vida: 70, armadura: 1, escudo: 0, esquiva: 0.20, bloqueo: 0, azar), new IAAleatoria());
        saqueador.EquiparArma(new Arma("Garra tóxica", 4, 0) { Venenosa = true });
        contexto.Agregar(saqueador);

        contexto.Agregar(new Enemigo("Mente Colmena", new Posicion(7, 5), ataque: 52, alcance: 3, movimiento: 2,
            CadenaDefensa.Estandar(vida: 130, armadura: 3, escudo: 20, esquiva: 0.10, bloqueo: 0.10, azar), new IACalculadora()));

        return new MotorCombate(contexto, baseEstacion ?? new BaseEstacion(creditosIniciales), inventario, bitacora);
    }
}
