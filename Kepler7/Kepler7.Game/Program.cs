using System.Windows.Forms;
using Kepler7.Core.Aplicacion;
using Kepler7.Game.Formularios;

namespace Kepler7.Game;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();

        // SINGLETON: la primera referencia crea el motor y carga el progreso guardado en %AppData%\Kepler7.
        _ = JuegoKepler7.Instancia;

        Application.Run(new FormInicio());
    }
}
