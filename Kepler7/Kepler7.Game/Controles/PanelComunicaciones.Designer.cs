#nullable enable

using System.Drawing;
using System.Windows.Forms;

namespace Kepler7.Game.Controles;

partial class PanelComunicaciones
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
        grpTransmision = new GroupBox();
        txtResultado = new TextBox();
        panelControles = new FlowLayoutPanel();
        lblTipo = new Label();
        cboTipo = new ComboBox();
        lblCifrado = new Label();
        cboCifrado = new ComboBox();
        lblContenido = new Label();
        txtContenido = new TextBox();
        btnEnviar = new Button();
        btnReenviar = new Button();
        grpTransmision.SuspendLayout();
        panelControles.SuspendLayout();
        SuspendLayout();
        // 
        // grpTransmision
        // 
        grpTransmision.BackColor = Color.WhiteSmoke;
        grpTransmision.Controls.Add(txtResultado);
        grpTransmision.Dock = DockStyle.Fill;
        grpTransmision.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        grpTransmision.ForeColor = Color.Black;
        grpTransmision.Location = new Point(0, 92);
        grpTransmision.Margin = new Padding(4);
        grpTransmision.Name = "grpTransmision";
        grpTransmision.Padding = new Padding(8, 6, 8, 8);
        grpTransmision.Size = new Size(1000, 508);
        grpTransmision.TabIndex = 0;
        grpTransmision.TabStop = false;
        grpTransmision.Text = "Transmisión (lo enviado, lo que viaja y lo que recibe la Tierra)";
        // 
        // txtResultado
        // 
        txtResultado.BackColor = Color.White;
        txtResultado.BorderStyle = BorderStyle.FixedSingle;
        txtResultado.Dock = DockStyle.Fill;
        txtResultado.Font = new Font("Segoe UI", 9.5F);
        txtResultado.ForeColor = Color.Black;
        txtResultado.Location = new Point(8, 24);
        txtResultado.Multiline = true;
        txtResultado.Name = "txtResultado";
        txtResultado.ReadOnly = true;
        txtResultado.ScrollBars = ScrollBars.Vertical;
        txtResultado.Size = new Size(984, 476);
        txtResultado.TabIndex = 0;
        // 
        // panelControles
        // 
        panelControles.BackColor = Color.WhiteSmoke;
        panelControles.Controls.Add(lblTipo);
        panelControles.Controls.Add(cboTipo);
        panelControles.Controls.Add(lblCifrado);
        panelControles.Controls.Add(cboCifrado);
        panelControles.Controls.Add(lblContenido);
        panelControles.Controls.Add(txtContenido);
        panelControles.Controls.Add(btnEnviar);
        panelControles.Controls.Add(btnReenviar);
        panelControles.Dock = DockStyle.Top;
        panelControles.ForeColor = Color.Black;
        panelControles.Location = new Point(0, 0);
        panelControles.Name = "panelControles";
        panelControles.Padding = new Padding(6);
        panelControles.Size = new Size(1000, 92);
        panelControles.TabIndex = 1;
        // 
        // lblTipo
        // 
        lblTipo.AutoSize = true;
        lblTipo.BackColor = Color.WhiteSmoke;
        lblTipo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblTipo.ForeColor = Color.Black;
        lblTipo.Location = new Point(9, 14);
        lblTipo.Margin = new Padding(3, 8, 3, 3);
        lblTipo.Name = "lblTipo";
        lblTipo.Size = new Size(43, 19);
        lblTipo.TabIndex = 0;
        lblTipo.Text = "Tipo:";
        // 
        // cboTipo
        // 
        cboTipo.BackColor = Color.White;
        cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
        cboTipo.ForeColor = Color.Black;
        cboTipo.FormattingEnabled = true;
        cboTipo.Items.AddRange(new object[] { "Texto", "Alerta", "Emergencia" });
        cboTipo.Location = new Point(58, 9);
        cboTipo.Name = "cboTipo";
        cboTipo.Size = new Size(140, 25);
        cboTipo.TabIndex = 1;
        // 
        // lblCifrado
        // 
        lblCifrado.AutoSize = true;
        lblCifrado.BackColor = Color.WhiteSmoke;
        lblCifrado.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblCifrado.ForeColor = Color.Black;
        lblCifrado.Location = new Point(213, 14);
        lblCifrado.Margin = new Padding(12, 8, 3, 3);
        lblCifrado.Name = "lblCifrado";
        lblCifrado.Size = new Size(63, 19);
        lblCifrado.TabIndex = 2;
        lblCifrado.Text = "Cifrado:";
        // 
        // cboCifrado
        // 
        cboCifrado.BackColor = Color.White;
        cboCifrado.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCifrado.ForeColor = Color.Black;
        cboCifrado.FormattingEnabled = true;
        cboCifrado.Items.AddRange(new object[] { "Sin cifrado", "AES-256", "Cuántico" });
        cboCifrado.Location = new Point(282, 9);
        cboCifrado.Name = "cboCifrado";
        cboCifrado.Size = new Size(220, 25);
        cboCifrado.TabIndex = 3;
        // 
        // lblContenido
        // 
        lblContenido.AutoSize = true;
        lblContenido.BackColor = Color.WhiteSmoke;
        lblContenido.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblContenido.ForeColor = Color.Black;
        lblContenido.Location = new Point(517, 14);
        lblContenido.Margin = new Padding(12, 8, 3, 3);
        lblContenido.Name = "lblContenido";
        lblContenido.Size = new Size(68, 19);
        lblContenido.TabIndex = 4;
        lblContenido.Text = "Mensaje:";
        // 
        // txtContenido
        // 
        txtContenido.BackColor = Color.White;
        txtContenido.BorderStyle = BorderStyle.FixedSingle;
        txtContenido.ForeColor = Color.Black;
        txtContenido.Location = new Point(9, 39);
        txtContenido.Name = "txtContenido";
        txtContenido.Size = new Size(420, 25);
        txtContenido.TabIndex = 5;
        txtContenido.Text = "Kepler-7 solicita evacuación del sector 4.";
        // 
        // btnEnviar
        // 
        btnEnviar.Location = new Point(435, 39);
        btnEnviar.Name = "btnEnviar";
        btnEnviar.Size = new Size(170, 34);
        btnEnviar.TabIndex = 6;
        btnEnviar.Text = "Enviar a la Tierra";
        btnEnviar.UseVisualStyleBackColor = true;
        btnEnviar.Click += btnEnviar_Click;
        // 
        // btnReenviar
        // 
        btnReenviar.Location = new Point(611, 39);
        btnReenviar.Name = "btnReenviar";
        btnReenviar.Size = new Size(250, 34);
        btnReenviar.TabIndex = 7;
        btnReenviar.Text = "Reenviar con el cifrado elegido";
        btnReenviar.UseVisualStyleBackColor = true;
        btnReenviar.Click += btnReenviar_Click;
        // 
        // PanelComunicaciones
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.WhiteSmoke;
        Controls.Add(grpTransmision);
        Controls.Add(panelControles);
        Font = new Font("Segoe UI", 10F);
        ForeColor = Color.Black;
        Name = "PanelComunicaciones";
        Size = new Size(1000, 600);
        grpTransmision.ResumeLayout(false);
        grpTransmision.PerformLayout();
        panelControles.ResumeLayout(false);
        panelControles.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private GroupBox grpTransmision = null!;
    private TextBox txtResultado = null!;
    private FlowLayoutPanel panelControles = null!;
    private Label lblTipo = null!;
    private ComboBox cboTipo = null!;
    private Label lblCifrado = null!;
    private ComboBox cboCifrado = null!;
    private Label lblContenido = null!;
    private TextBox txtContenido = null!;
    private Button btnEnviar = null!;
    private Button btnReenviar = null!;
}
