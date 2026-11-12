#nullable enable

using System.Drawing;
using System.Windows.Forms;

namespace Kepler7.Game.Formularios;

partial class FormLogros
{
    /// <summary>Variable del diseñador necesaria.</summary>
    private System.ComponentModel.IContainer? components = null;

    /// <summary>Limpiar los recursos que se estén usando.</summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null)) components.Dispose();
        base.Dispose(disposing);
    }

    #region Código generado por el Diseñador de Windows Forms

    /// <summary>Método necesario para admitir el Diseñador. No se puede modificar el contenido de este método con el editor de código.</summary>
    private void InitializeComponent()
    {
        this.panelLogros = new Kepler7.Game.Controles.PanelLogros();

        this.SuspendLayout();

        // FormLogros
        this.Controls.Add(this.panelLogros);
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.WhiteSmoke;
        this.ForeColor = System.Drawing.Color.Black;
        this.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.ClientSize = new System.Drawing.Size(700, 720);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Logros — patrones dominados";
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        // panelLogros
        this.panelLogros.Dock = System.Windows.Forms.DockStyle.Fill;

        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private Kepler7.Game.Controles.PanelLogros panelLogros = null!;
}
