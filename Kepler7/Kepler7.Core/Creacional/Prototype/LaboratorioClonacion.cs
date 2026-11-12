using Kepler7.Core.Dominio;

namespace Kepler7.Core.Creacional.Prototype;

/// <summary>Evidencia de la prueba de independencia, lista para mostrar en la interfaz.</summary>
public sealed record ResultadoPruebaClonacion(
    string OriginalAntes,
    string OriginalDespues,
    string ClonModificado,
    bool OriginalIntacto,
    bool HabilidadesIndependientes,
    bool AtributosIndependientes,
    bool EspecieCompartida);

/// <summary>
/// Laboratorio de biotecnología: el CLIENTE del Prototype. Pide copias de un tripulante base,
/// les asigna una identidad nueva y puede demostrar que la copia es realmente independiente.
/// </summary>
public sealed class LaboratorioClonacion
{
    private int _siguienteId;

    /// <param name="primerId">Primer Id que recibirá un clon (por defecto, a continuación de los 10.000 tripulantes base).</param>
    public LaboratorioClonacion(int primerId = 10_001)
    {
        _siguienteId = primerId;
    }

    public Tripulante Clonar(Tripulante prototipo, string? nuevoNombre = null)
    {
        ArgumentNullException.ThrowIfNull(prototipo);

        Tripulante clon = prototipo.Clonar();
        clon.Id = _siguienteId++;
        clon.Nombre = nuevoNombre ?? $"{prototipo.Nombre} (clon)";
        return clon;
    }

    /// <summary>
    /// Clona al original, MODIFICA el clon (nombre, rango, habilidades y atributos) y comprueba
    /// que el original conserva todos sus valores. Es la "prueba visible" que pide la consigna.
    /// </summary>
    public ResultadoPruebaClonacion ProbarIndependencia(Tripulante original)
    {
        ArgumentNullException.ThrowIfNull(original);

        string antes = original.ToString();
        Tripulante clon = Clonar(original);

        // Mutaciones sobre el clon, incluyendo la colección y el objeto anidado.
        clon.Nombre += " Mk-II";
        clon.Rango = RangoTripulante.Cadete;
        clon.Habilidades.Add("Mutación: regeneración celular");
        clon.Atributos.Fuerza += 50;
        clon.Atributos.Salud = 1;

        string despues = original.ToString();

        return new ResultadoPruebaClonacion(
            OriginalAntes: antes,
            OriginalDespues: despues,
            ClonModificado: clon.ToString(),
            OriginalIntacto: antes == despues,
            HabilidadesIndependientes: !ReferenceEquals(original.Habilidades, clon.Habilidades),
            AtributosIndependientes: !ReferenceEquals(original.Atributos, clon.Atributos),
            EspecieCompartida: ReferenceEquals(original.Especie, clon.Especie));
    }
}
