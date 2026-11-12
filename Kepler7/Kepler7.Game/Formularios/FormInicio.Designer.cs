#nullable enable

using System.Drawing;
using System.Windows.Forms;

namespace Kepler7.Game.Formularios;

partial class FormInicio
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
        this.columna = new FlowLayoutPanel();
        this.lblTitulo = new Label();
        this.lblSubtitulo = new Label();
        this.lblMateria = new Label();
        this.lblProgreso = new Label();
        this.btnJugar = new Button();
        this.btnTutorial = new Button();
        this.btnLogros = new Button();
        this.btnSalir = new Button();
        this.lblIntegrantes = new Label();

        this.SuspendLayout();
        this.columna.SuspendLayout();

        // FormInicio
        this.Controls.Add(this.columna);
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.WhiteSmoke;
        this.ForeColor = System.Drawing.Color.Black;
        this.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.ClientSize = new System.Drawing.Size(900, 620);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "KEPLER-7";
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        // columna
        this.columna.Controls.Add(this.lblTitulo);
        this.columna.Controls.Add(this.lblSubtitulo);
        this.columna.Controls.Add(this.lblMateria);
        this.columna.Controls.Add(this.lblProgreso);
        this.columna.Controls.Add(this.btnJugar);
        this.columna.Controls.Add(this.btnTutorial);
        this.columna.Controls.Add(this.btnLogros);
        this.columna.Controls.Add(this.btnSalir);
        this.columna.Controls.Add(this.lblIntegrantes);
        this.columna.BackColor = System.Drawing.Color.WhiteSmoke;
        this.columna.ForeColor = System.Drawing.Color.Black;
        this.columna.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        this.columna.WrapContents = false;
        this.columna.Dock = System.Windows.Forms.DockStyle.Fill;
        this.columna.Padding = new System.Windows.Forms.Padding(60, 50, 0, 0);

        // lblTitulo
        this.lblTitulo.BackColor = System.Drawing.Color.WhiteSmoke;
        this.lblTitulo.ForeColor = System.Drawing.Color.Black;
        this.lblTitulo.Text = "KEPLER-7";
        this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold);
        this.lblTitulo.AutoSize = true;

        // lblSubtitulo
        this.lblSubtitulo.BackColor = System.Drawing.Color.WhiteSmoke;
        this.lblSubtitulo.ForeColor = System.Drawing.Color.Black;
        this.lblSubtitulo.Text = "El universo de los patrones";
        this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 13F);
        this.lblSubtitulo.AutoSize = true;

        // lblMateria
        this.lblMateria.BackColor = System.Drawing.Color.WhiteSmoke;
        this.lblMateria.ForeColor = System.Drawing.Color.DimGray;
        this.lblMateria.Text = "";
        this.lblMateria.AutoSize = true;

        // lblProgreso
        this.lblProgreso.BackColor = System.Drawing.Color.WhiteSmoke;
        this.lblProgreso.ForeColor = System.Drawing.Color.DimGray;
        this.lblProgreso.Text = "";
        this.lblProgreso.AutoSize = true;
        this.lblProgreso.Margin = new System.Windows.Forms.Padding(3, 16, 3, 14);

        // btnJugar
        this.btnJugar.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
        this.btnJugar.Size = new System.Drawing.Size(260, 38);
        this.btnJugar.Text = "Jugar";
        this.btnJugar.UseVisualStyleBackColor = true;
        this.btnJugar.Click += new System.EventHandler(this.btnJugar_Click);

        // btnTutorial
        this.btnTutorial.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
        this.btnTutorial.Size = new System.Drawing.Size(260, 38);
        this.btnTutorial.Text = "Tutorial";
        this.btnTutorial.UseVisualStyleBackColor = true;
        this.btnTutorial.Click += new System.EventHandler(this.btnTutorial_Click);

        // btnLogros
        this.btnLogros.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
        this.btnLogros.Size = new System.Drawing.Size(260, 38);
        this.btnLogros.Text = "Logros";
        this.btnLogros.UseVisualStyleBackColor = true;
        this.btnLogros.Click += new System.EventHandler(this.btnLogros_Click);

        // btnSalir
        this.btnSalir.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
        this.btnSalir.Size = new System.Drawing.Size(260, 38);
        this.btnSalir.Text = "Salir";
        this.btnSalir.UseVisualStyleBackColor = true;
        this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);

        // lblIntegrantes
        this.lblIntegrantes.BackColor = System.Drawing.Color.WhiteSmoke;
        this.lblIntegrantes.ForeColor = System.Drawing.Color.Black;
        this.lblIntegrantes.Text = "Integrantes";
        this.lblIntegrantes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.lblIntegrantes.AutoSize = true;
        this.lblIntegrantes.Margin = new System.Windows.Forms.Padding(3, 26, 3, 3);

        this.columna.ResumeLayout(false);
        this.columna.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private FlowLayoutPanel columna = null!;
    private Label lblTitulo = null!;
    private Label lblSubtitulo = null!;
    private Label lblMateria = null!;
    private Label lblProgreso = null!;
    private Button btnJugar = null!;
    private Button btnTutorial = null!;
    private Button btnLogros = null!;
    private Button btnSalir = null!;
    private Label lblIntegrantes = null!;
}
