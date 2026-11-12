using System.Drawing;

namespace Kepler7.Game.Visual;

/// <summary>Paleta de los controles creados en ejecución y colores funcionales del tablero.</summary>
internal static class Tema
{
    public static readonly Color Superficie = Color.White;
    public static readonly Color TextoSuave = Color.DimGray;

    // TableroControl usa estos valores para el fondo, los resaltados y las barras.
    public static readonly Color Campo = Color.FromArgb(15, 22, 42);
    public static readonly Color Acento = Color.FromArgb(90, 200, 255);
    public static readonly Color Bueno = Color.FromArgb(80, 220, 130);
    public static readonly Color Malo = Color.FromArgb(255, 100, 100);
    public static readonly Color Aviso = Color.FromArgb(255, 210, 80);
}
