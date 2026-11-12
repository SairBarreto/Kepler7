#nullable enable

using System.Drawing;
using System.Windows.Forms;

namespace Kepler7.Game.Formularios;

partial class FormTutorial
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
        this.lblTexto = new Label();
        this.lblPagina = new Label();
        this.panelBotones = new FlowLayoutPanel();
        this.btnSiguiente = new Button();
        this.btnAnterior = new Button();
        this.btnSaltar = new Button();
        this.panelCabecera = new Panel();
        this.lblTitulo = new Label();

        this.SuspendLayout();
        this.panelBotones.SuspendLayout();
        this.panelCabecera.SuspendLayout();

        // FormTutorial
        this.Controls.Add(this.lblTexto);
        this.Controls.Add(this.lblPagina);
        this.Controls.Add(this.panelBotones);
        this.Controls.Add(this.panelCabecera);
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.WhiteSmoke;
        this.ForeColor = System.Drawing.Color.Black;
        this.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.ClientSize = new System.Drawing.Size(760, 440);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Tutorial";
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        // lblTexto
        this.lblTexto.BackColor = System.Drawing.Color.WhiteSmoke;
        this.lblTexto.ForeColor = System.Drawing.Color.Black;
        this.lblTexto.Text = "";
        this.lblTexto.Font = new System.Drawing.Font("Segoe UI", 13F);
        this.lblTexto.AutoSize = false;
        this.lblTexto.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lblTexto.Padding = new System.Windows.Forms.Padding(16, 6, 16, 6);

        // lblPagina
        this.lblPagina.BackColor = System.Drawing.Color.WhiteSmoke;
        this.lblPagina.ForeColor = System.Drawing.Color.DimGray;
        this.lblPagina.Text = "";
        this.lblPagina.Font = new System.Drawing.Font("Segoe UI", 9F);
        this.lblPagina.AutoSize = false;
        this.lblPagina.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.lblPagina.Size = new System.Drawing.Size(0, 24);
        this.lblPagina.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);

        // panelBotones
        this.panelBotones.Controls.Add(this.btnSiguiente);
        this.panelBotones.Controls.Add(this.btnAnterior);
        this.panelBotones.Controls.Add(this.btnSaltar);
        this.panelBotones.BackColor = System.Drawing.Color.WhiteSmoke;
        this.panelBotones.ForeColor = System.Drawing.Color.Black;
        this.panelBotones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
        this.panelBotones.WrapContents = true;
        this.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.panelBotones.Height = 50;
        this.panelBotones.Padding = new System.Windows.Forms.Padding(8, 8, 8, 8);

        // btnSiguiente
        this.btnSiguiente.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
        this.btnSiguiente.Size = new System.Drawing.Size(130, 34);
        this.btnSiguiente.Text = "Siguiente";
        this.btnSiguiente.UseVisualStyleBackColor = true;
        this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);

        // btnAnterior
        this.btnAnterior.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
        this.btnAnterior.Size = new System.Drawing.Size(110, 34);
        this.btnAnterior.Text = "Anterior";
        this.btnAnterior.UseVisualStyleBackColor = true;
        this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);

        // btnSaltar
        this.btnSaltar.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
        this.btnSaltar.Size = new System.Drawing.Size(90, 34);
        this.btnSaltar.Text = "Saltar";
        this.btnSaltar.UseVisualStyleBackColor = true;
        this.btnSaltar.Click += new System.EventHandler(this.btnSaltar_Click);

        // panelCabecera
        this.panelCabecera.Controls.Add(this.lblTitulo);
        this.panelCabecera.BackColor = System.Drawing.Color.WhiteSmoke;
        this.panelCabecera.ForeColor = System.Drawing.Color.Black;
        this.panelCabecera.Dock = System.Windows.Forms.DockStyle.Top;
        this.panelCabecera.Height = 54;
        this.panelCabecera.Padding = new System.Windows.Forms.Padding(16, 14, 16, 0);

        // lblTitulo
        this.lblTitulo.BackColor = System.Drawing.Color.WhiteSmoke;
        this.lblTitulo.ForeColor = System.Drawing.Color.Black;
        this.lblTitulo.Text = "";
        this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 13F);
        this.lblTitulo.AutoSize = true;

        this.panelBotones.ResumeLayout(false);
        this.panelBotones.PerformLayout();
        this.panelCabecera.ResumeLayout(false);
        this.panelCabecera.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private Label lblTexto = null!;
    private Label lblPagina = null!;
    private FlowLayoutPanel panelBotones = null!;
    private Button btnSiguiente = null!;
    private Button btnAnterior = null!;
    private Button btnSaltar = null!;
    private Panel panelCabecera = null!;
    private Label lblTitulo = null!;
}
