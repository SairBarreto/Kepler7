using System.Windows.Forms;

namespace Kepler7.Game.Visual;

internal static class Ui
{
    /// <summary>
    /// Ejecuta la acción en el hilo de la interfaz. Los eventos del Core se disparan en el hilo que los origina;
    /// hoy es el de la UI, pero esta guarda evita romper la pantalla si mañana alguno viene de otro hilo.
    /// </summary>
    public static void EnUi(Control control, Action accion)
    {
        if (control.IsDisposed || !control.IsHandleCreated) return;

        if (control.InvokeRequired) control.BeginInvoke(accion);
        else accion();
    }

    public static void AgregarAlFinal(ListBox lista, string linea, int maximo = 400)
    {
        lista.Items.Add(linea);
        while (lista.Items.Count > maximo) lista.Items.RemoveAt(0);
        lista.TopIndex = Math.Max(0, lista.Items.Count - 1);
    }
}
