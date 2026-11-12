using Kepler7.Core.Aplicacion;

namespace Kepler7.Game.Formularios;

/// <summary>Tutorial de cuatro pantallas. El cambio de página es instantáneo: sólo se reemplaza el texto.</summary>
internal sealed partial class FormTutorial : Form
{
    private static readonly (string Titulo, string Texto)[] Paginas =
    {
        ("1 · La estación",
         "Kepler-7 es una estación orbital en crisis. Desde el Control Central arrancás los sistemas, " +
         "declarás emergencias y los apagás con un solo botón: la fachada se ocupa de coordinar energía, " +
         "soporte vital, navegación, comunicaciones, seguridad y defensa.\n\n" +
         "En el Astillero construís naves, en el Laboratorio clonás tripulantes, en Comunicaciones " +
         "enviás mensajes cifrados y en la Bóveda guardás secretos que no cualquiera puede leer."),

        ("2 · El combate por turnos",
         "Tu escuadrón (Rex, Vega, Kira y Ortiz) enfrenta a cuatro enemigos en un tablero de 8×8.\n\n" +
         "Cada unidad tiene UN movimiento y UNA acción por ronda (atacar o curar). Elegí una unidad, " +
         "tocá Mover / Atacar / Curar y hacé clic en el tablero. Cuando termines, pulsá «Terminar ronda»: " +
         "los enemigos deciden con su inteligencia artificial y vuelve tu turno."),

        ("3 · Defensas, estados y deshacer",
         "Cada golpe atraviesa la cadena Esquiva → Bloqueo → Armadura → Escudo → Vida. Podés reordenar " +
         "esas capas en caliente desde el panel de defensas.\n\n" +
         "El veneno, el aturdimiento y el berserk cambian cómo peleás (el anillo de color te lo muestra). " +
         "¿Te arrepentiste? «Deshacer» y «Rehacer» recorren tus acciones de la ronda y te devuelven el movimiento y la acción."),

        ("4 · Progreso e insignias",
         "Ganar partidas da XP y monedas; subís de nivel cada 100 XP. Además hay una insignia por cada uno " +
         "de los 12 patrones de diseño: se obtiene la primera vez que usás su mecánica dentro del juego.\n\n" +
         "Tu progreso se guarda solo en %AppData%\\Kepler7. ¡Buena suerte, comandante!")
    };

    private int _indice;

    public FormTutorial()
    {
        InitializeComponent();
        Ir(0);
    }

    private void btnSiguiente_Click(object? sender, EventArgs e)
    {
        if (_indice == Paginas.Length - 1) Terminar();
        else Ir(_indice + 1);
    }

    private void btnAnterior_Click(object? sender, EventArgs e) => Ir(_indice - 1);

    private void btnSaltar_Click(object? sender, EventArgs e) => Terminar();

    private void Ir(int indice)
    {
        if (indice < 0 || indice >= Paginas.Length) return;

        _indice = indice;
        lblTitulo.Text = Paginas[indice].Titulo;
        lblTexto.Text = Paginas[indice].Texto;
        lblPagina.Text = $"Pantalla {indice + 1} de {Paginas.Length}";
        btnAnterior.Enabled = indice > 0;
        btnSiguiente.Text = indice == Paginas.Length - 1 ? "¡A jugar!" : "Siguiente";
    }

    private void Terminar()
    {
        JuegoKepler7.Instancia.MarcarTutorialVisto();
        Close();
    }
}
