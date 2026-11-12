using Kepler7.Core.Aplicacion;
using Kepler7.Core.Creacional.Prototype;
using Kepler7.Core.Dominio;
using Kepler7.Core.Estructural.Flyweight;

namespace Kepler7.Game.Controles;

/// <summary>
/// PROTOTYPE + FLYWEIGHT sobre los mismos tripulantes: se clona a uno, se modifica el clon y se ve que el
/// original no cambia; y se muestra cuánta memoria ahorra compartir las especies.
/// </summary>
internal sealed partial class PanelLaboratorio : UserControl
{
    private readonly JuegoKepler7 _juego = JuegoKepler7.Instancia;

    private List<Tripulante> _lista = new();
    private Tripulante? _prototipo;
    private Tripulante? _copia;
    private string _fotoOriginal = string.Empty;

    public PanelLaboratorio()
    {
        InitializeComponent();
        Generar();
    }

    private void btnGenerar_Click(object? sender, EventArgs e) => Generar();

    private void lstTripulacion_SelectedIndexChanged(object? sender, EventArgs e) => AlElegir();

    private void btnClonar_Click(object? sender, EventArgs e) => Clonar();

    private void btnRenombrar_Click(object? sender, EventArgs e) => Modificar(c => c.Nombre = txtNuevoNombre.Text);

    private void btnHabilidad_Click(object? sender, EventArgs e) => Modificar(c => c.Habilidades.Add("Hackeo cuántico"));

    private void btnFuerza_Click(object? sender, EventArgs e) => Modificar(c => c.Atributos.Fuerza += 50);

    private void btnPrueba_Click(object? sender, EventArgs e) => ProbarIndependencia();

    private void btnMemoria_Click(object? sender, EventArgs e) => CompararMemoria();

    private void Generar()
    {
        // El generador pide las especies a la FÁBRICA compartida del juego: pocas instancias para muchos tripulantes.
        _lista = GeneradorTripulantes.Generar(40, _juego.Fabrica);
        lstTripulacion.Items.Clear();
        foreach (Tripulante t in _lista) lstTripulacion.Items.Add($"#{t.Id}  {t.Nombre} · {t.Especie.Nombre}");

        lblFlyweight.Text = $"Especies creadas: {_juego.Fabrica.InstanciasCreadas}  ·  solicitudes atendidas: {_juego.Fabrica.SolicitudesAtendidas}";
        lstTripulacion.SelectedIndex = 0;
    }

    private void AlElegir()
    {
        int i = lstTripulacion.SelectedIndex;
        if (i < 0) return;

        _prototipo = _lista[i];
        _copia = null;
        txtOriginal.Text = Detalle(_prototipo);
        txtClon.Text = string.Empty;
        lblVeredicto.Text = "Elegí «Clonar» para crear una copia de este tripulante.";
    }

    private void Clonar()
    {
        if (_prototipo is null) return;

        _fotoOriginal = Detalle(_prototipo);
        _copia = _juego.Laboratorio.Clonar(_prototipo);
        Mostrar();
        lblVeredicto.Text = "Clon creado. Modificalo con los botones y mirá que el original no cambia.";
    }

    private void Modificar(Action<Tripulante> cambio)
    {
        if (_copia is null)
        {
            lblVeredicto.Text = "Advertencia: primero cloná un tripulante.";
            return;
        }

        cambio(_copia);
        Mostrar();

        bool intacto = Detalle(_prototipo!) == _fotoOriginal;
        lblVeredicto.Text = intacto ? "El original conserva todos sus valores." : "Error: el original cambió (copia superficial).";

        _juego.Dominar(PatronGoF.Prototype);
    }

    private void ProbarIndependencia()
    {
        if (_prototipo is null) return;

        ResultadoPruebaClonacion r = _juego.Laboratorio.ProbarIndependencia(_prototipo);
        txtInforme.Text = string.Join(Environment.NewLine, new[]
        {
            "PRUEBA DE INDEPENDENCIA (clon modificado a propósito)",
            $"Original antes:   {r.OriginalAntes}",
            $"Original después: {r.OriginalDespues}",
            $"Clon modificado:  {r.ClonModificado}",
            string.Empty,
            $"Original intacto: {Si(r.OriginalIntacto)}",
            $"Habilidades independientes: {Si(r.HabilidadesIndependientes)}",
            $"Atributos independientes:   {Si(r.AtributosIndependientes)}",
            $"Especie compartida (Flyweight): {Si(r.EspecieCompartida)}"
        });

        _juego.Dominar(PatronGoF.Prototype);
    }

    private void CompararMemoria()
    {
        ResultadoComparacionFlyweight r = ComparadorFlyweight.Comparar();
        txtInforme.Text = string.Join(Environment.NewLine, new[]
        {
            $"COMPARACIÓN CON {r.Cantidad:N0} TRIPULANTES",
            $"Con Flyweight:    {r.EspeciesConFlyweight} especies en memoria · {r.BytesConFlyweight / 1024.0:N0} KB · {r.MilisegundosConFlyweight} ms",
            $"Sin Flyweight:    {r.EspeciesSinFlyweight:N0} especies en memoria · {r.BytesSinFlyweight / 1024.0:N0} KB · {r.MilisegundosSinFlyweight} ms",
            string.Empty,
            $"Ahorro: {r.BytesAhorrados / 1024.0:N0} KB ({r.PorcentajeAhorro:N0}%)"
        });

        _juego.Dominar(PatronGoF.Flyweight);
    }

    private void Mostrar()
    {
        txtOriginal.Text = Detalle(_prototipo!);
        txtClon.Text = _copia is null ? string.Empty : Detalle(_copia);
    }

    private static string Si(bool valor) => valor ? "sí" : "no";

    private static string Detalle(Tripulante t) => string.Join(Environment.NewLine, new[]
    {
        $"Id:        {t.Id}",
        $"Nombre:    {t.Nombre}",
        $"Rango:     {t.Rango}",
        $"Especie:   {t.Especie.Nombre} ({t.Especie.PlanetaOrigen})",
        $"Atributos: salud {t.Atributos.Salud}, fuerza {t.Atributos.Fuerza}, int. {t.Atributos.Inteligencia}, agil. {t.Atributos.Agilidad}",
        $"Habilidades: {(t.Habilidades.Count == 0 ? "(ninguna)" : string.Join(", ", t.Habilidades))}"
    });
}
