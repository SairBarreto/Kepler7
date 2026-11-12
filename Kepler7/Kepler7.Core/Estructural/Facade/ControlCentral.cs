using Kepler7.Core.Comun;
using Kepler7.Core.Estructural.Facade.Subsistemas;

namespace Kepler7.Core.Estructural.Facade;

public enum ModoEstacion
{
    Apagada,
    Operativa,
    Emergencia
}

/// <summary>Foto de solo lectura de un subsistema, para que la UI pueda dibujarlo sin tocarlo.</summary>
public sealed record EstadoSubsistema(string Nombre, bool Activo, int Nivel, string Detalle);

/// <summary>
/// FACADE: tres operaciones simples para manejar seis subsistemas.
/// Los subsistemas son internos y se crean aquí adentro, de modo que el formulario cliente
/// no puede invocarlos directamente. La UI sigue la secuencia coordinada suscribiéndose a
/// <see cref="Bitacora"/> y dibuja el estado con <see cref="ObtenerEstadoSubsistemas"/>.
/// </summary>
public sealed class ControlCentral
{
    private readonly Energia _energia;
    private readonly SoporteVital _soporteVital;
    private readonly Navegacion _navegacion;
    private readonly Comunicaciones _comunicaciones;
    private readonly Seguridad _seguridad;
    private readonly Defensa _defensa;
    private readonly SubsistemaBase[] _todos;

    public ControlCentral(IBitacora? bitacora = null)
    {
        Bitacora = bitacora ?? new Bitacora();

        _energia = new Energia(Bitacora);
        _soporteVital = new SoporteVital(Bitacora);
        _navegacion = new Navegacion(Bitacora);
        _comunicaciones = new Comunicaciones(Bitacora);
        _seguridad = new Seguridad(Bitacora);
        _defensa = new Defensa(Bitacora);

        _todos = new SubsistemaBase[] { _energia, _soporteVital, _navegacion, _comunicaciones, _seguridad, _defensa };
    }

    public IBitacora Bitacora { get; }
    public ModoEstacion Modo { get; private set; } = ModoEstacion.Apagada;
    public int TurnoActual { get; private set; }

    public event EventHandler<ModoEstacion>? ModoCambiado;

    public IReadOnlyList<EstadoSubsistema> ObtenerEstadoSubsistemas() =>
        _todos.Select(s => s.ObtenerEstado()).ToList();

    /// <summary>
    /// Avanza un turno. Si la estación está apagada ejecuta antes la secuencia de arranque;
    /// si venía de una emergencia, la da por terminada y normaliza los sistemas.
    /// </summary>
    public void IniciarTurno()
    {
        if (Modo == ModoEstacion.Apagada) ArrancarSubsistemas();
        else if (Modo == ModoEstacion.Emergencia) SalirDeEmergencia();

        TurnoActual++;
        Registrar($"--- Inicio del turno {TurnoActual} ---");
        foreach (SubsistemaBase subsistema in _todos) subsistema.ProcesarTurno();
    }

    public void EntrarEnEmergencia()
    {
        if (Modo == ModoEstacion.Apagada)
        {
            Registrar("No se puede declarar emergencia: la estación está apagada.", NivelBitacora.Advertencia);
            return;
        }

        if (Modo == ModoEstacion.Emergencia)
        {
            Registrar("La estación ya está en modo emergencia.", NivelBitacora.Advertencia);
            return;
        }

        Registrar("¡PROTOCOLO DE EMERGENCIA ACTIVADO!", NivelBitacora.Critico);
        _energia.DerivarAReservas();
        _soporteVital.ReducirAModulosCriticos();
        _navegacion.CalcularRutaEvacuacion();
        _comunicaciones.TransmitirSOS();
        _seguridad.SellarCompuertas();
        _defensa.ActivarTorretas();
        CambiarModo(ModoEstacion.Emergencia);
    }

    public void ApagarEstacion()
    {
        if (Modo == ModoEstacion.Apagada)
        {
            Registrar("La estación ya está apagada.", NivelBitacora.Advertencia);
            return;
        }

        Registrar("Iniciando apagado ordenado de la estación.");

        // Orden inverso al arranque: primero lo que depende de la energía, la energía al final.
        _defensa.Apagar();
        _seguridad.Apagar();
        _comunicaciones.Apagar();
        _navegacion.Apagar();
        _soporteVital.Apagar();
        _energia.Apagar();
        CambiarModo(ModoEstacion.Apagada);
    }

    private void ArrancarSubsistemas()
    {
        Registrar("Secuencia de arranque de la estación.");
        _energia.Encender();
        _soporteVital.Activar();
        _navegacion.MantenerOrbita();
        _comunicaciones.AbrirCanalTierra();
        _seguridad.PatrullarSectores();
        _defensa.ArmarEscudos();
        CambiarModo(ModoEstacion.Operativa);
    }

    private void SalirDeEmergencia()
    {
        Registrar("Fin de la emergencia: restableciendo operación normal.");
        _soporteVital.Activar();
        _navegacion.MantenerOrbita();
        _comunicaciones.AbrirCanalTierra();
        _seguridad.PatrullarSectores();
        _defensa.ArmarEscudos();
        CambiarModo(ModoEstacion.Operativa);
    }

    private void CambiarModo(ModoEstacion nuevoModo)
    {
        Modo = nuevoModo;
        ModoCambiado?.Invoke(this, nuevoModo);
    }

    private void Registrar(string mensaje, NivelBitacora nivel = NivelBitacora.Info) =>
        Bitacora.Registrar("Control Central", mensaje, nivel);
}
