namespace Kepler7.Core.Creacional.Builder;

/// <summary>
/// PRODUCTO del patrón Builder.
/// Los componentes son opcionales (una nave de carga puede no tener armas) y solo los builders
/// del Core pueden modificarlos: hacia afuera la nave es de solo lectura.
/// </summary>
public sealed class Nave
{
    private readonly List<string> _armas = new();

    public Nave(string tipo)
    {
        Tipo = tipo;
    }

    public string Tipo { get; }

    // Componentes opcionales (null = no instalado).
    public string? Casco { get; internal set; }
    public string? Motor { get; internal set; }
    public string? Escudo { get; internal set; }
    public IReadOnlyList<string> Armas => _armas;
    public string? Radar { get; internal set; }
    public string? InteligenciaArtificial { get; internal set; }
    public int TanquesCombustible { get; internal set; }

    // Estadísticas acumuladas: cada componente instalado aporta lo suyo.
    public int Resistencia { get; private set; }
    public int Velocidad { get; private set; }
    public int PoderFuego { get; private set; }
    public int Autonomia { get; private set; }
    public int Deteccion { get; private set; }
    public int CapacidadCarga { get; private set; }
    public int CostoCreditos { get; private set; }

    internal void AgregarArma(string arma) => _armas.Add(arma);

    internal void Aportar(int resistencia = 0, int velocidad = 0, int poderFuego = 0,
                          int autonomia = 0, int deteccion = 0, int capacidadCarga = 0, int costo = 0)
    {
        Resistencia += resistencia;
        Velocidad += velocidad;
        PoderFuego += poderFuego;
        Autonomia += autonomia;
        Deteccion += deteccion;
        CapacidadCarga += capacidadCarga;
        CostoCreditos += costo;
    }

    /// <summary>Lista legible de los componentes realmente instalados.</summary>
    public IEnumerable<string> Componentes()
    {
        if (Casco is not null) yield return $"Casco: {Casco}";
        if (Motor is not null) yield return $"Motor: {Motor}";
        if (Escudo is not null) yield return $"Escudo: {Escudo}";
        if (_armas.Count > 0) yield return $"Armas: {string.Join(", ", _armas)}";
        if (Radar is not null) yield return $"Radar: {Radar}";
        if (InteligenciaArtificial is not null) yield return $"IA: {InteligenciaArtificial}";
        if (TanquesCombustible > 0) yield return $"Tanques de combustible: {TanquesCombustible}";
    }

    /// <summary>Ficha completa para mostrar en la interfaz.</summary>
    public string Describir()
    {
        var lineas = new List<string> { $"=== Nave {Tipo} ===" };

        var componentes = Componentes().ToList();
        if (componentes.Count == 0) lineas.Add("(sin componentes instalados)");
        else lineas.AddRange(componentes);

        lineas.Add($"Resistencia {Resistencia} | Velocidad {Velocidad} | Poder de fuego {PoderFuego}");
        lineas.Add($"Autonomía {Autonomia} | Detección {Deteccion} | Carga {CapacidadCarga}");
        lineas.Add($"Costo: {CostoCreditos} créditos");

        return string.Join(Environment.NewLine, lineas);
    }

    public override string ToString() => Describir();
}
