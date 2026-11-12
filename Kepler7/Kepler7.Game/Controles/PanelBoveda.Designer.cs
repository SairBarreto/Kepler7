#nullable enable

using System.Drawing;
using System.Windows.Forms;

namespace Kepler7.Game.Controles;

partial class PanelBoveda
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
        tablaCentro = new TableLayoutPanel();
        grpContenido = new GroupBox();
        txtContenido = new TextBox();
        grpDenegados = new GroupBox();
        lstDenegados = new ListBox();
        lblEstado = new Label();
        panelBarra = new FlowLayoutPanel();
        lblRol = new Label();
        cboRol = new ComboBox();
        lblArchivo = new Label();
        txtArchivo = new TextBox();
        btnLeer = new Button();
        btnListar = new Button();
        btnEscribir = new Button();
        tablaCentro.SuspendLayout();
        grpContenido.SuspendLayout();
        grpDenegados.SuspendLayout();
        panelBarra.SuspendLayout();
        SuspendLayout();
        // 
        // tablaCentro
        // 
        tablaCentro.BackColor = Color.WhiteSmoke;
        tablaCentro.ColumnCount = 2;
        tablaCentro.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tablaCentro.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tablaCentro.Controls.Add(grpContenido, 0, 0);
        tablaCentro.Controls.Add(grpDenegados, 1, 0);
        tablaCentro.Dock = DockStyle.Fill;
        tablaCentro.ForeColor = Color.Black;
        tablaCentro.Location = new Point(0, 124);
        tablaCentro.Name = "tablaCentro";
        tablaCentro.RowCount = 1;
        tablaCentro.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tablaCentro.Size = new Size(1000, 476);
        tablaCentro.TabIndex = 0;
        // 
        // grpContenido
        // 
        grpContenido.BackColor = Color.WhiteSmoke;
        grpContenido.Controls.Add(txtContenido);
        grpContenido.Dock = DockStyle.Fill;
        grpContenido.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        grpContenido.ForeColor = Color.Black;
        grpContenido.Location = new Point(4, 4);
        grpContenido.Margin = new Padding(4);
        grpContenido.Name = "grpContenido";
        grpContenido.Padding = new Padding(8, 6, 8, 8);
        grpContenido.Size = new Size(492, 468);
        grpContenido.TabIndex = 0;
        grpContenido.TabStop = false;
        grpContenido.Text = "Contenido";
        // 
        // txtContenido
        // 
        txtContenido.BackColor = Color.White;
        txtContenido.BorderStyle = BorderStyle.FixedSingle;
        txtContenido.Dock = DockStyle.Fill;
        txtContenido.Font = new Font("Segoe UI", 9.5F);
        txtContenido.ForeColor = Color.Black;
        txtContenido.Location = new Point(8, 24);
        txtContenido.Multiline = true;
        txtContenido.Name = "txtContenido";
        txtContenido.ReadOnly = true;
        txtContenido.ScrollBars = ScrollBars.Vertical;
        txtContenido.Size = new Size(476, 436);
        txtContenido.TabIndex = 0;
        // 
        // grpDenegados
        // 
        grpDenegados.BackColor = Color.WhiteSmoke;
        grpDenegados.Controls.Add(lstDenegados);
        grpDenegados.Dock = DockStyle.Fill;
        grpDenegados.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        grpDenegados.ForeColor = Color.Black;
        grpDenegados.Location = new Point(504, 4);
        grpDenegados.Margin = new Padding(4);
        grpDenegados.Name = "grpDenegados";
        grpDenegados.Padding = new Padding(8, 6, 8, 8);
        grpDenegados.Size = new Size(492, 468);
        grpDenegados.TabIndex = 1;
        grpDenegados.TabStop = false;
        grpDenegados.Text = "Intentos denegados (guardados en accesos_denegados.json)";
        // 
        // lstDenegados
        // 
        lstDenegados.BackColor = Color.White;
        lstDenegados.BorderStyle = BorderStyle.FixedSingle;
        lstDenegados.Dock = DockStyle.Fill;
        lstDenegados.Font = new Font("Segoe UI", 9.5F);
        lstDenegados.ForeColor = Color.Black;
        lstDenegados.FormattingEnabled = true;
        lstDenegados.HorizontalScrollbar = true;
        lstDenegados.IntegralHeight = false;
        lstDenegados.ItemHeight = 17;
        lstDenegados.Location = new Point(8, 24);
        lstDenegados.Name = "lstDenegados";
        lstDenegados.Size = new Size(476, 436);
        lstDenegados.TabIndex = 0;
        // 
        // lblEstado
        // 
        lblEstado.BackColor = Color.WhiteSmoke;
        lblEstado.Dock = DockStyle.Top;
        lblEstado.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblEstado.ForeColor = Color.DimGray;
        lblEstado.Location = new Point(0, 92);
        lblEstado.Name = "lblEstado";
        lblEstado.Padding = new Padding(8, 6, 0, 0);
        lblEstado.Size = new Size(1000, 32);
        lblEstado.TabIndex = 1;
        // 
        // panelBarra
        // 
        panelBarra.BackColor = Color.WhiteSmoke;
        panelBarra.Controls.Add(lblRol);
        panelBarra.Controls.Add(cboRol);
        panelBarra.Controls.Add(lblArchivo);
        panelBarra.Controls.Add(txtArchivo);
        panelBarra.Controls.Add(btnLeer);
        panelBarra.Controls.Add(btnListar);
        panelBarra.Controls.Add(btnEscribir);
        panelBarra.Dock = DockStyle.Top;
        panelBarra.ForeColor = Color.Black;
        panelBarra.Location = new Point(0, 0);
        panelBarra.Name = "panelBarra";
        panelBarra.Padding = new Padding(6);
        panelBarra.Size = new Size(1000, 92);
        panelBarra.TabIndex = 2;
        // 
        // lblRol
        // 
        lblRol.AutoSize = true;
        lblRol.BackColor = Color.WhiteSmoke;
        lblRol.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblRol.ForeColor = Color.Black;
        lblRol.Location = new Point(9, 14);
        lblRol.Margin = new Padding(3, 8, 3, 3);
        lblRol.Name = "lblRol";
        lblRol.Size = new Size(51, 19);
        lblRol.TabIndex = 0;
        lblRol.Text = "Tu rol:";
        // 
        // cboRol
        // 
        cboRol.BackColor = Color.White;
        cboRol.DropDownStyle = ComboBoxStyle.DropDownList;
        cboRol.ForeColor = Color.Black;
        cboRol.FormattingEnabled = true;
        cboRol.Location = new Point(66, 9);
        cboRol.Name = "cboRol";
        cboRol.Size = new Size(200, 25);
        cboRol.TabIndex = 1;
        cboRol.SelectedIndexChanged += cboRol_SelectedIndexChanged;
        // 
        // lblArchivo
        // 
        lblArchivo.AutoSize = true;
        lblArchivo.BackColor = Color.WhiteSmoke;
        lblArchivo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblArchivo.ForeColor = Color.Black;
        lblArchivo.Location = new Point(281, 14);
        lblArchivo.Margin = new Padding(12, 8, 3, 3);
        lblArchivo.Name = "lblArchivo";
        lblArchivo.Size = new Size(65, 19);
        lblArchivo.TabIndex = 2;
        lblArchivo.Text = "Archivo:";
        // 
        // txtArchivo
        // 
        txtArchivo.BackColor = Color.White;
        txtArchivo.BorderStyle = BorderStyle.FixedSingle;
        txtArchivo.ForeColor = Color.Black;
        txtArchivo.Location = new Point(352, 9);
        txtArchivo.Name = "txtArchivo";
        txtArchivo.Size = new Size(180, 25);
        txtArchivo.TabIndex = 3;
        txtArchivo.Text = "diario-capitan";
        // 
        // btnLeer
        // 
        btnLeer.Location = new Point(538, 9);
        btnLeer.Name = "btnLeer";
        btnLeer.Size = new Size(90, 34);
        btnLeer.TabIndex = 4;
        btnLeer.Text = "Leer";
        btnLeer.UseVisualStyleBackColor = true;
        btnLeer.Click += btnLeer_Click;
        // 
        // btnListar
        // 
        btnListar.Location = new Point(634, 9);
        btnListar.Name = "btnListar";
        btnListar.Size = new Size(90, 34);
        btnListar.TabIndex = 5;
        btnListar.Text = "Listar";
        btnListar.UseVisualStyleBackColor = true;
        btnListar.Click += btnListar_Click;
        // 
        // btnEscribir
        // 
        btnEscribir.Location = new Point(730, 9);
        btnEscribir.Name = "btnEscribir";
        btnEscribir.Size = new Size(130, 34);
        btnEscribir.TabIndex = 6;
        btnEscribir.Text = "Escribir nota";
        btnEscribir.UseVisualStyleBackColor = true;
        btnEscribir.Click += btnEscribir_Click;
        // 
        // PanelBoveda
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.WhiteSmoke;
        Controls.Add(tablaCentro);
        Controls.Add(lblEstado);
        Controls.Add(panelBarra);
        Font = new Font("Segoe UI", 10F);
        ForeColor = Color.Black;
        Name = "PanelBoveda";
        Size = new Size(1000, 600);
        tablaCentro.ResumeLayout(false);
        grpContenido.ResumeLayout(false);
        grpContenido.PerformLayout();
        grpDenegados.ResumeLayout(false);
        panelBarra.ResumeLayout(false);
        panelBarra.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tablaCentro = null!;
    private GroupBox grpContenido = null!;
    private TextBox txtContenido = null!;
    private GroupBox grpDenegados = null!;
    private ListBox lstDenegados = null!;
    private Label lblEstado = null!;
    private FlowLayoutPanel panelBarra = null!;
    private Label lblRol = null!;
    private ComboBox cboRol = null!;
    private Label lblArchivo = null!;
    private TextBox txtArchivo = null!;
    private Button btnLeer = null!;
    private Button btnListar = null!;
    private Button btnEscribir = null!;
}
