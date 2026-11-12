using System.Drawing.Drawing2D;
using Kepler7.Core.Comportamiento.ChainOfResponsibility;
using Kepler7.Core.Dominio.Combate;
using Kepler7.Game.Visual;

namespace Kepler7.Game.Controles;

/// <summary>Qué hará el próximo clic sobre el tablero.</summary>
internal enum ModoAccion
{
    Ninguno,
    Mover,
    Atacar,
    Curar
}

/// <summary>
/// Dibuja el campo de batalla con GDI+ (imagen fija: se repinta sólo cuando el formulario llama a Invalidate).
/// No contiene reglas: solo LEE el <see cref="ContextoCombate"/> del Core y avisa con un evento cuando el
/// jugador hace clic en una casilla.
/// </summary>
internal sealed class TableroControl : Control
{
    private const int Celda = 64;

    private static readonly Font FuenteLetra = new("Segoe UI Semibold", 11f, FontStyle.Bold);
    private static readonly Font FuenteVida = new("Segoe UI", 7f);

    private ContextoCombate? _contexto;

    public TableroControl()
    {
        DoubleBuffered = true;
        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
        BackColor = Tema.Campo;
    }

    public event EventHandler<Posicion>? CasillaClick;

    public ContextoCombate? Contexto
    {
        get => _contexto;
        set
        {
            _contexto = value;
            if (value is not null) Size = new Size(value.Ancho * Celda + 1, value.Alto * Celda + 1);
            Invalidate();
        }
    }

    public Combatiente? Seleccionado { get; set; }
    public ModoAccion Modo { get; set; }

    protected override void OnMouseClick(MouseEventArgs e)
    {
        base.OnMouseClick(e);
        if (_contexto is null) return;

        var casilla = new Posicion(e.X / Celda, e.Y / Celda);
        if (_contexto.EnTablero(casilla)) CasillaClick?.Invoke(this, casilla);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        if (_contexto is null) return;

        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        DibujarCasillas(g);
        DibujarResaltados(g);

        foreach (Combatiente c in _contexto.TodosVivos) DibujarUnidad(g, c);
    }

    private void DibujarCasillas(Graphics g)
    {
        for (int y = 0; y < _contexto!.Alto; y++)
        {
            for (int x = 0; x < _contexto.Ancho; x++)
            {
                Color color = (x + y) % 2 == 0 ? Color.FromArgb(20, 28, 52) : Color.FromArgb(26, 36, 66);
                using var pincel = new SolidBrush(color);
                g.FillRectangle(pincel, x * Celda, y * Celda, Celda, Celda);
            }
        }

        using var rejilla = new Pen(Color.FromArgb(40, 255, 255, 255));
        for (int x = 0; x <= _contexto.Ancho; x++) g.DrawLine(rejilla, x * Celda, 0, x * Celda, _contexto.Alto * Celda);
        for (int y = 0; y <= _contexto.Alto; y++) g.DrawLine(rejilla, 0, y * Celda, _contexto.Ancho * Celda, y * Celda);
    }

    /// <summary>Casillas alcanzables al mover y objetivos válidos al atacar o curar, según el modo elegido.</summary>
    private void DibujarResaltados(Graphics g)
    {
        if (Seleccionado is null || Modo == ModoAccion.Ninguno) return;

        switch (Modo)
        {
            case ModoAccion.Mover:
                using (var relleno = new SolidBrush(Color.FromArgb(70, Tema.Bueno)))
                {
                    foreach (Posicion p in _contexto!.CasillasAlcanzables(Seleccionado, Seleccionado.MovimientoDisponible))
                        g.FillRectangle(relleno, p.X * Celda + 1, p.Y * Celda + 1, Celda - 1, Celda - 1);
                }
                break;

            case ModoAccion.Atacar:
                foreach (Enemigo enemigo in _contexto!.EnemigosVivos)
                {
                    if (Seleccionado.Posicion.Distancia(enemigo.Posicion) <= Seleccionado.Alcance)
                        Marco(g, enemigo.Posicion, Tema.Malo);
                }
                break;

            case ModoAccion.Curar:
                foreach (Personaje aliado in _contexto!.AliadosVivos)
                {
                    if (Seleccionado.Posicion.Distancia(aliado.Posicion) <= Seleccionado.Alcance)
                        Marco(g, aliado.Posicion, Tema.Bueno);
                }
                break;
        }
    }

    private static void Marco(Graphics g, Posicion p, Color color)
    {
        using var lapiz = new Pen(color, 3);
        g.DrawRectangle(lapiz, p.X * Celda + 2, p.Y * Celda + 2, Celda - 4, Celda - 4);
    }

    private void DibujarUnidad(Graphics g, Combatiente c)
    {
        int x = c.Posicion.X * Celda;
        int y = c.Posicion.Y * Celda;
        bool esEnemigo = c is Enemigo;

        Color relleno = esEnemigo ? Color.FromArgb(150, 40, 48) : ColorDeClase((Personaje)c);

        var cuerpo = new Rectangle(x + 10, y + 12, Celda - 20, Celda - 24);
        using (var pincel = new SolidBrush(relleno)) g.FillEllipse(pincel, cuerpo);

        // El anillo muestra el ESTADO del personaje (State): su color viene del propio estado.
        using (var anillo = new Pen(ColorTranslator.FromHtml(c.Estado.ColorHex), c.Estado.Nombre == "Normal" ? 1.5f : 4f))
            g.DrawEllipse(anillo, cuerpo);

        using (var letra = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            g.DrawString(c.Nombre[..1], FuenteLetra, Brushes.White, cuerpo, letra);

        // Barras de vida y de escudo.
        DibujarBarra(g, x + 8, y + 3, Celda - 16, 5, c.Vida.Actual, c.Vida.Maxima, Tema.Bueno);
        Escudo? escudo = c.Defensas.Buscar<Escudo>();
        if (escudo is not null && escudo.Maximo > 0)
            DibujarBarra(g, x + 8, y + 9, Celda - 16, 3, escudo.Puntos, escudo.Maximo, Tema.Acento);

        // Puntos de acción de los aliados: movimiento y acción disponibles en la ronda.
        if (!esEnemigo)
        {
            PuntoDeAccion(g, x + 8, y + Celda - 9, c.PuedeMover);
            PuntoDeAccion(g, x + 20, y + Celda - 9, c.PuedeActuar);
        }

        // Vida en números (fija, sin animación): actual/máxima en la esquina inferior derecha.
        using (var derecha = new StringFormat { Alignment = StringAlignment.Far })
            g.DrawString($"{c.Vida.Actual}/{c.Vida.Maxima}", FuenteVida, Brushes.White, new RectangleF(x + 2, y + Celda - 14, Celda - 5, 12), derecha);

        if (ReferenceEquals(c, Seleccionado))
        {
            using var seleccion = new Pen(Tema.Aviso, 2) { DashStyle = DashStyle.Dash };
            g.DrawRectangle(seleccion, x + 2, y + 2, Celda - 4, Celda - 4);
        }
    }

    private static void DibujarBarra(Graphics g, int x, int y, int ancho, int alto, int valor, int maximo, Color color)
    {
        using var fondo = new SolidBrush(Color.FromArgb(70, 0, 0, 0));
        g.FillRectangle(fondo, x, y, ancho, alto);

        int lleno = maximo <= 0 ? 0 : (int)(ancho * (double)Math.Clamp(valor, 0, maximo) / maximo);
        using var barra = new SolidBrush(color);
        g.FillRectangle(barra, x, y, lleno, alto);
    }

    private static void PuntoDeAccion(Graphics g, int x, int y, bool disponible)
    {
        using var pincel = new SolidBrush(disponible ? Tema.Aviso : Color.FromArgb(70, 90, 110));
        g.FillRectangle(pincel, x, y, 8, 5);
    }

    private static Color ColorDeClase(Personaje p) => p.Clase switch
    {
        ClaseUnidad.Soldado => Color.FromArgb(46, 110, 190),
        ClaseUnidad.Medico => Color.FromArgb(40, 150, 110),
        ClaseUnidad.Francotirador => Color.FromArgb(110, 80, 190),
        ClaseUnidad.Comandante => Color.FromArgb(190, 130, 40),
        _ => Color.SteelBlue
    };
}
