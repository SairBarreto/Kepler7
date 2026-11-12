namespace Kepler7.Core.Aplicacion;

/// <summary>Los doce patrones del TP. Cada uno se "domina" al usar su mecánica dentro del juego.</summary>
public enum PatronGoF
{
    Builder,
    Prototype,
    Flyweight,
    Facade,
    Bridge,
    Proxy,
    ChainOfResponsibility,
    Command,
    Visitor,
    State,
    TemplateMethod,
    Strategy
}

/// <summary>Textos para el panel de logros (nombre de la insignia y qué hay que hacer para obtenerla).</summary>
public static class PatronGoFInfo
{
    public static string Nombre(this PatronGoF patron) => patron switch
    {
        PatronGoF.Builder => "Builder",
        PatronGoF.Prototype => "Prototype",
        PatronGoF.Flyweight => "Flyweight",
        PatronGoF.Facade => "Facade",
        PatronGoF.Bridge => "Bridge",
        PatronGoF.Proxy => "Proxy",
        PatronGoF.ChainOfResponsibility => "Chain of Responsibility",
        PatronGoF.Command => "Command",
        PatronGoF.Visitor => "Visitor",
        PatronGoF.State => "State",
        PatronGoF.TemplateMethod => "Template Method",
        PatronGoF.Strategy => "Strategy",
        _ => patron.ToString()
    };

    public static string Insignia(this PatronGoF patron) => patron switch
    {
        PatronGoF.Builder => "Ingeniero Jefe",
        PatronGoF.Prototype => "Maestro Clonador",
        PatronGoF.Flyweight => "Ahorrador de Memoria",
        PatronGoF.Facade => "Controlador Central",
        PatronGoF.Bridge => "Enlace con la Tierra",
        PatronGoF.Proxy => "Guardián de la Bóveda",
        PatronGoF.ChainOfResponsibility => "Muro de Defensas",
        PatronGoF.Command => "Viajero del Tiempo",
        PatronGoF.Visitor => "Inspector de Inventario",
        PatronGoF.State => "Cambio de Humor",
        PatronGoF.TemplateMethod => "Táctico de Escuadrón",
        PatronGoF.Strategy => "Maestro de Marionetas",
        _ => patron.ToString()
    };

    public static string Mecanica(this PatronGoF patron) => patron switch
    {
        PatronGoF.Builder => "Construí una nave en el Astillero.",
        PatronGoF.Prototype => "Cloná un tripulante y modificá el clon en el Laboratorio.",
        PatronGoF.Flyweight => "Compará la memoria con y sin Flyweight en el Laboratorio.",
        PatronGoF.Facade => "Iniciá un turno o declará una emergencia desde Control Central.",
        PatronGoF.Bridge => "Enviá un mensaje cifrado a la Tierra.",
        PatronGoF.Proxy => "Intentá abrir la Bóveda con un rol sin permisos.",
        PatronGoF.ChainOfResponsibility => "Recibí o provocá un golpe y mirá su recorrido por las defensas.",
        PatronGoF.Command => "Deshacé una acción en combate.",
        PatronGoF.Visitor => "Aplicá un visitante al inventario.",
        PatronGoF.State => "Hacé que una unidad cambie de estado (veneno, aturdimiento, berserk).",
        PatronGoF.TemplateMethod => "Jugá el turno automático de una unidad.",
        PatronGoF.Strategy => "Cambiá la IA de un enemigo en plena batalla.",
        _ => string.Empty
    };
}
