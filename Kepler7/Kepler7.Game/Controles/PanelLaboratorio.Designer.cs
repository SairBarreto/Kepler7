#nullable enable

using System.Drawing;
using System.Windows.Forms;

namespace Kepler7.Game.Controles;

partial class PanelLaboratorio
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
        panelDerecha = new Panel();
        panelInforme = new Panel();
        grpInforme = new GroupBox();
        txtInforme = new TextBox();
        btnMemoria = new Button();
        lblVeredicto = new Label();
        tablaComparacion = new TableLayoutPanel();
        grpOriginal = new GroupBox();
        txtOriginal = new TextBox();
        grpClon = new GroupBox();
        txtClon = new TextBox();
        panelAcciones = new FlowLayoutPanel();
        btnClonar = new Button();
        lblNombreClon = new Label();
        txtNuevoNombre = new TextBox();
        btnRenombrar = new Button();
        btnHabilidad = new Button();
        btnFuerza = new Button();
        btnPrueba = new Button();
        panelIzquierda = new Panel();
        grpTripulacion = new GroupBox();
        lstTripulacion = new ListBox();
        lblFlyweight = new Label();
        btnGenerar = new Button();
        panelDerecha.SuspendLayout();
        panelInforme.SuspendLayout();
        grpInforme.SuspendLayout();
        tablaComparacion.SuspendLayout();
        grpOriginal.SuspendLayout();
        grpClon.SuspendLayout();
        panelAcciones.SuspendLayout();
        panelIzquierda.SuspendLayout();
        grpTripulacion.SuspendLayout();
        SuspendLayout();
        // 
        // panelDerecha
        // 
        panelDerecha.BackColor = Color.WhiteSmoke;
        panelDerecha.Controls.Add(panelInforme);
        panelDerecha.Controls.Add(lblVeredicto);
        panelDerecha.Controls.Add(tablaComparacion);
        panelDerecha.Controls.Add(panelAcciones);
        panelDerecha.Dock = DockStyle.Fill;
        panelDerecha.ForeColor = Color.Black;
        panelDerecha.Location = new Point(300, 0);
        panelDerecha.Name = "panelDerecha";
        panelDerecha.Size = new Size(700, 600);
        panelDerecha.TabIndex = 0;
        // 
        // panelInforme
        // 
        panelInforme.BackColor = Color.WhiteSmoke;
        panelInforme.Controls.Add(grpInforme);
        panelInforme.Dock = DockStyle.Fill;
        panelInforme.ForeColor = Color.Black;
        panelInforme.Location = new Point(0, 214);
        panelInforme.Name = "panelInforme";
        panelInforme.Size = new Size(700, 386);
        panelInforme.TabIndex = 0;
        // 
        // grpInforme
        // 
        grpInforme.BackColor = Color.WhiteSmoke;
        grpInforme.Controls.Add(txtInforme);
        grpInforme.Dock = DockStyle.Fill;
        grpInforme.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        grpInforme.ForeColor = Color.Black;
        grpInforme.Location = new Point(0, 0);
        grpInforme.Margin = new Padding(4);
        grpInforme.Name = "grpInforme";
        grpInforme.Padding = new Padding(8, 6, 8, 8);
        grpInforme.Size = new Size(700, 386);
        grpInforme.TabIndex = 0;
        grpInforme.TabStop = false;
        grpInforme.Text = "Informe (prueba de clonación / comparación de memoria)";
        // 
        // txtInforme
        // 
        txtInforme.BackColor = Color.White;
        txtInforme.BorderStyle = BorderStyle.FixedSingle;
        txtInforme.Dock = DockStyle.Fill;
        txtInforme.Font = new Font("Segoe UI", 9.5F);
        txtInforme.ForeColor = Color.Black;
        txtInforme.Location = new Point(8, 24);
        txtInforme.Multiline = true;
        txtInforme.Name = "txtInforme";
        txtInforme.ReadOnly = true;
        txtInforme.ScrollBars = ScrollBars.Vertical;
        txtInforme.Size = new Size(684, 354);
        txtInforme.TabIndex = 0;
        // 
        // btnMemoria
        // 
        btnMemoria.Location = new Point(123, 47);
        btnMemoria.Name = "btnMemoria";
        btnMemoria.Size = new Size(430, 34);
        btnMemoria.TabIndex = 1;
        btnMemoria.Text = "Comparar memoria: Flyweight vs sin Flyweight (10.000 tripulantes)";
        btnMemoria.UseVisualStyleBackColor = true;
        btnMemoria.Click += btnMemoria_Click;
        // 
        // lblVeredicto
        // 
        lblVeredicto.BackColor = Color.WhiteSmoke;
        lblVeredicto.Dock = DockStyle.Top;
        lblVeredicto.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblVeredicto.ForeColor = Color.DimGray;
        lblVeredicto.Location = new Point(0, 184);
        lblVeredicto.Name = "lblVeredicto";
        lblVeredicto.Padding = new Padding(8, 6, 0, 0);
        lblVeredicto.Size = new Size(700, 30);
        lblVeredicto.TabIndex = 1;
        // 
        // tablaComparacion
        // 
        tablaComparacion.BackColor = Color.WhiteSmoke;
        tablaComparacion.ColumnCount = 2;
        tablaComparacion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tablaComparacion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tablaComparacion.Controls.Add(grpOriginal, 0, 0);
        tablaComparacion.Controls.Add(grpClon, 1, 0);
        tablaComparacion.Dock = DockStyle.Top;
        tablaComparacion.ForeColor = Color.Black;
        tablaComparacion.Location = new Point(0, 84);
        tablaComparacion.Name = "tablaComparacion";
        tablaComparacion.RowCount = 1;
        tablaComparacion.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tablaComparacion.Size = new Size(700, 100);
        tablaComparacion.TabIndex = 2;
        // 
        // grpOriginal
        // 
        grpOriginal.BackColor = Color.WhiteSmoke;
        grpOriginal.Controls.Add(txtOriginal);
        grpOriginal.Dock = DockStyle.Fill;
        grpOriginal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        grpOriginal.ForeColor = Color.Black;
        grpOriginal.Location = new Point(4, 4);
        grpOriginal.Margin = new Padding(4);
        grpOriginal.Name = "grpOriginal";
        grpOriginal.Padding = new Padding(8, 6, 8, 8);
        grpOriginal.Size = new Size(342, 92);
        grpOriginal.TabIndex = 0;
        grpOriginal.TabStop = false;
        grpOriginal.Text = "Original";
        // 
        // txtOriginal
        // 
        txtOriginal.BackColor = Color.White;
        txtOriginal.BorderStyle = BorderStyle.FixedSingle;
        txtOriginal.Dock = DockStyle.Fill;
        txtOriginal.Font = new Font("Segoe UI", 9.5F);
        txtOriginal.ForeColor = Color.Black;
        txtOriginal.Location = new Point(8, 24);
        txtOriginal.Multiline = true;
        txtOriginal.Name = "txtOriginal";
        txtOriginal.ReadOnly = true;
        txtOriginal.ScrollBars = ScrollBars.Vertical;
        txtOriginal.Size = new Size(326, 60);
        txtOriginal.TabIndex = 0;
        // 
        // grpClon
        // 
        grpClon.BackColor = Color.WhiteSmoke;
        grpClon.Controls.Add(txtClon);
        grpClon.Dock = DockStyle.Fill;
        grpClon.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        grpClon.ForeColor = Color.Black;
        grpClon.Location = new Point(354, 4);
        grpClon.Margin = new Padding(4);
        grpClon.Name = "grpClon";
        grpClon.Padding = new Padding(8, 6, 8, 8);
        grpClon.Size = new Size(342, 92);
        grpClon.TabIndex = 1;
        grpClon.TabStop = false;
        grpClon.Text = "Clon (copia profunda)";
        // 
        // txtClon
        // 
        txtClon.BackColor = Color.White;
        txtClon.BorderStyle = BorderStyle.FixedSingle;
        txtClon.Dock = DockStyle.Fill;
        txtClon.Font = new Font("Segoe UI", 9.5F);
        txtClon.ForeColor = Color.Black;
        txtClon.Location = new Point(8, 24);
        txtClon.Multiline = true;
        txtClon.Name = "txtClon";
        txtClon.ReadOnly = true;
        txtClon.ScrollBars = ScrollBars.Vertical;
        txtClon.Size = new Size(326, 60);
        txtClon.TabIndex = 0;
        // 
        // panelAcciones
        // 
        panelAcciones.BackColor = Color.WhiteSmoke;
        panelAcciones.Controls.Add(btnClonar);
        panelAcciones.Controls.Add(lblNombreClon);
        panelAcciones.Controls.Add(txtNuevoNombre);
        panelAcciones.Controls.Add(btnRenombrar);
        panelAcciones.Controls.Add(btnHabilidad);
        panelAcciones.Controls.Add(btnFuerza);
        panelAcciones.Controls.Add(btnMemoria);
        panelAcciones.Controls.Add(btnPrueba);
        panelAcciones.Dock = DockStyle.Top;
        panelAcciones.ForeColor = Color.Black;
        panelAcciones.Location = new Point(0, 0);
        panelAcciones.Name = "panelAcciones";
        panelAcciones.Padding = new Padding(4);
        panelAcciones.Size = new Size(700, 84);
        panelAcciones.TabIndex = 3;
        // 
        // btnClonar
        // 
        btnClonar.Location = new Point(7, 7);
        btnClonar.Name = "btnClonar";
        btnClonar.Size = new Size(100, 34);
        btnClonar.TabIndex = 0;
        btnClonar.Text = "Clonar";
        btnClonar.UseVisualStyleBackColor = true;
        btnClonar.Click += btnClonar_Click;
        // 
        // lblNombreClon
        // 
        lblNombreClon.AutoSize = true;
        lblNombreClon.BackColor = Color.WhiteSmoke;
        lblNombreClon.ForeColor = Color.Black;
        lblNombreClon.Location = new Point(118, 12);
        lblNombreClon.Margin = new Padding(8, 8, 3, 3);
        lblNombreClon.Name = "lblNombreClon";
        lblNombreClon.Size = new Size(113, 19);
        lblNombreClon.TabIndex = 1;
        lblNombreClon.Text = "Nombre del clon:";
        // 
        // txtNuevoNombre
        // 
        txtNuevoNombre.BackColor = Color.White;
        txtNuevoNombre.BorderStyle = BorderStyle.FixedSingle;
        txtNuevoNombre.ForeColor = Color.Black;
        txtNuevoNombre.Location = new Point(237, 7);
        txtNuevoNombre.Name = "txtNuevoNombre";
        txtNuevoNombre.Size = new Size(170, 25);
        txtNuevoNombre.TabIndex = 2;
        txtNuevoNombre.Text = "Alfa-2";
        // 
        // btnRenombrar
        // 
        btnRenombrar.Location = new Point(413, 7);
        btnRenombrar.Name = "btnRenombrar";
        btnRenombrar.Size = new Size(130, 34);
        btnRenombrar.TabIndex = 3;
        btnRenombrar.Text = "Renombrar clon";
        btnRenombrar.UseVisualStyleBackColor = true;
        btnRenombrar.Click += btnRenombrar_Click;
        // 
        // btnHabilidad
        // 
        btnHabilidad.Location = new Point(549, 7);
        btnHabilidad.Name = "btnHabilidad";
        btnHabilidad.Size = new Size(110, 34);
        btnHabilidad.TabIndex = 4;
        btnHabilidad.Text = "+ Habilidad";
        btnHabilidad.UseVisualStyleBackColor = true;
        btnHabilidad.Click += btnHabilidad_Click;
        // 
        // btnFuerza
        // 
        btnFuerza.Location = new Point(7, 47);
        btnFuerza.Name = "btnFuerza";
        btnFuerza.Size = new Size(110, 34);
        btnFuerza.TabIndex = 5;
        btnFuerza.Text = "+50 Fuerza";
        btnFuerza.UseVisualStyleBackColor = true;
        btnFuerza.Click += btnFuerza_Click;
        // 
        // btnPrueba
        // 
        btnPrueba.Location = new Point(7, 87);
        btnPrueba.Name = "btnPrueba";
        btnPrueba.Size = new Size(160, 34);
        btnPrueba.TabIndex = 6;
        btnPrueba.Text = "Prueba automática";
        btnPrueba.UseVisualStyleBackColor = true;
        btnPrueba.Click += btnPrueba_Click;
        // 
        // panelIzquierda
        // 
        panelIzquierda.BackColor = Color.WhiteSmoke;
        panelIzquierda.Controls.Add(grpTripulacion);
        panelIzquierda.Controls.Add(lblFlyweight);
        panelIzquierda.Controls.Add(btnGenerar);
        panelIzquierda.Dock = DockStyle.Left;
        panelIzquierda.ForeColor = Color.Black;
        panelIzquierda.Location = new Point(0, 0);
        panelIzquierda.Name = "panelIzquierda";
        panelIzquierda.Size = new Size(300, 600);
        panelIzquierda.TabIndex = 1;
        // 
        // grpTripulacion
        // 
        grpTripulacion.BackColor = Color.WhiteSmoke;
        grpTripulacion.Controls.Add(lstTripulacion);
        grpTripulacion.Dock = DockStyle.Fill;
        grpTripulacion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        grpTripulacion.ForeColor = Color.Black;
        grpTripulacion.Location = new Point(0, 0);
        grpTripulacion.Margin = new Padding(4);
        grpTripulacion.Name = "grpTripulacion";
        grpTripulacion.Padding = new Padding(8, 6, 8, 8);
        grpTripulacion.Size = new Size(300, 556);
        grpTripulacion.TabIndex = 0;
        grpTripulacion.TabStop = false;
        grpTripulacion.Text = "Tripulantes (comparten especies)";
        // 
        // lstTripulacion
        // 
        lstTripulacion.BackColor = Color.White;
        lstTripulacion.BorderStyle = BorderStyle.FixedSingle;
        lstTripulacion.Dock = DockStyle.Fill;
        lstTripulacion.ForeColor = Color.Black;
        lstTripulacion.FormattingEnabled = true;
        lstTripulacion.IntegralHeight = false;
        lstTripulacion.ItemHeight = 17;
        lstTripulacion.Location = new Point(8, 24);
        lstTripulacion.Name = "lstTripulacion";
        lstTripulacion.Size = new Size(284, 524);
        lstTripulacion.TabIndex = 0;
        lstTripulacion.SelectedIndexChanged += lstTripulacion_SelectedIndexChanged;
        // 
        // lblFlyweight
        // 
        lblFlyweight.BackColor = Color.WhiteSmoke;
        lblFlyweight.Dock = DockStyle.Bottom;
        lblFlyweight.ForeColor = Color.DimGray;
        lblFlyweight.Location = new Point(0, 556);
        lblFlyweight.Name = "lblFlyweight";
        lblFlyweight.Size = new Size(300, 44);
        lblFlyweight.TabIndex = 1;
        // 
        // btnGenerar
        // 
        btnGenerar.Location = new Point(0, 0);
        btnGenerar.Name = "btnGenerar";
        btnGenerar.Size = new Size(280, 36);
        btnGenerar.TabIndex = 2;
        btnGenerar.Text = "Generar tripulación (40)";
        btnGenerar.UseVisualStyleBackColor = true;
        btnGenerar.Click += btnGenerar_Click;
        // 
        // PanelLaboratorio
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.WhiteSmoke;
        Controls.Add(panelDerecha);
        Controls.Add(panelIzquierda);
        Font = new Font("Segoe UI", 10F);
        ForeColor = Color.Black;
        Name = "PanelLaboratorio";
        Size = new Size(1000, 600);
        panelDerecha.ResumeLayout(false);
        panelInforme.ResumeLayout(false);
        grpInforme.ResumeLayout(false);
        grpInforme.PerformLayout();
        tablaComparacion.ResumeLayout(false);
        grpOriginal.ResumeLayout(false);
        grpOriginal.PerformLayout();
        grpClon.ResumeLayout(false);
        grpClon.PerformLayout();
        panelAcciones.ResumeLayout(false);
        panelAcciones.PerformLayout();
        panelIzquierda.ResumeLayout(false);
        grpTripulacion.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel panelDerecha = null!;
    private Panel panelInforme = null!;
    private GroupBox grpInforme = null!;
    private TextBox txtInforme = null!;
    private Button btnMemoria = null!;
    private Label lblVeredicto = null!;
    private TableLayoutPanel tablaComparacion = null!;
    private GroupBox grpOriginal = null!;
    private TextBox txtOriginal = null!;
    private GroupBox grpClon = null!;
    private TextBox txtClon = null!;
    private FlowLayoutPanel panelAcciones = null!;
    private Button btnClonar = null!;
    private Label lblNombreClon = null!;
    private TextBox txtNuevoNombre = null!;
    private Button btnRenombrar = null!;
    private Button btnHabilidad = null!;
    private Button btnFuerza = null!;
    private Button btnPrueba = null!;
    private Panel panelIzquierda = null!;
    private GroupBox grpTripulacion = null!;
    private ListBox lstTripulacion = null!;
    private Label lblFlyweight = null!;
    private Button btnGenerar = null!;
}
