#nullable enable

using System.Drawing;
using System.Windows.Forms;

namespace Kepler7.Game.Controles;

partial class PanelLogros
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
        this.flujoLogros = new FlowLayoutPanel();
        this.panelCabecera = new Panel();
        this.barraXp = new ProgressBar();
        this.lblResumen = new Label();

        this.SuspendLayout();
        this.panelCabecera.SuspendLayout();

        // PanelLogros
        this.Controls.Add(this.flujoLogros);
        this.Controls.Add(this.panelCabecera);
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.WhiteSmoke;
        this.ForeColor = System.Drawing.Color.Black;
        this.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.Size = new System.Drawing.Size(700, 700);

        // flujoLogros
        this.flujoLogros.BackColor = System.Drawing.Color.WhiteSmoke;
        this.flujoLogros.ForeColor = System.Drawing.Color.Black;
        this.flujoLogros.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        this.flujoLogros.WrapContents = false;
        this.flujoLogros.Dock = System.Windows.Forms.DockStyle.Fill;
        this.flujoLogros.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
        this.flujoLogros.AutoScroll = true;

        // panelCabecera
        this.panelCabecera.Controls.Add(this.barraXp);
        this.panelCabecera.Controls.Add(this.lblResumen);
        this.panelCabecera.BackColor = System.Drawing.Color.WhiteSmoke;
        this.panelCabecera.ForeColor = System.Drawing.Color.Black;
        this.panelCabecera.Dock = System.Windows.Forms.DockStyle.Top;
        this.panelCabecera.Height = 64;
        this.panelCabecera.Padding = new System.Windows.Forms.Padding(8, 8, 8, 4);

        // barraXp
        this.barraXp.Dock = System.Windows.Forms.DockStyle.Top;
        this.barraXp.Height = 16;
        this.barraXp.Maximum = 100;
        this.barraXp.Style = System.Windows.Forms.ProgressBarStyle.Continuous;

        // lblResumen
        this.lblResumen.BackColor = System.Drawing.Color.WhiteSmoke;
        this.lblResumen.ForeColor = System.Drawing.Color.Black;
        this.lblResumen.Text = "";
        this.lblResumen.Font = new System.Drawing.Font("Segoe UI", 13F);
        this.lblResumen.AutoSize = false;
        this.lblResumen.Dock = System.Windows.Forms.DockStyle.Top;
        this.lblResumen.Size = new System.Drawing.Size(0, 30);

        this.panelCabecera.ResumeLayout(false);
        this.panelCabecera.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private FlowLayoutPanel flujoLogros = null!;
    private Panel panelCabecera = null!;
    private ProgressBar barraXp = null!;
    private Label lblResumen = null!;
}
