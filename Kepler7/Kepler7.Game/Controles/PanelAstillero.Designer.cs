#nullable enable

using System.Drawing;
using System.Windows.Forms;

namespace Kepler7.Game.Controles;

partial class PanelAstillero
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
        tablaInferior = new TableLayoutPanel();
        grpFlota = new GroupBox();
        lstFlota = new ListBox();
        grpDetalle = new GroupBox();
        txtDetalle = new TextBox();
        grpHistorial = new GroupBox();
        lstHistorial = new ListBox();
        lblMensaje = new Label();
        panelControles = new FlowLayoutPanel();
        lblReceta = new Label();
        cboRecetas = new ComboBox();
        rdoCompleta = new RadioButton();
        rdoBasica = new RadioButton();
        btnConstruir = new Button();
        btnDeshacer = new Button();
        btnRehacer = new Button();
        lblCreditos = new Label();
        tablaInferior.SuspendLayout();
        grpFlota.SuspendLayout();
        grpDetalle.SuspendLayout();
        grpHistorial.SuspendLayout();
        panelControles.SuspendLayout();
        SuspendLayout();
        // 
        // tablaInferior
        // 
        tablaInferior.BackColor = Color.WhiteSmoke;
        tablaInferior.ColumnCount = 3;
        tablaInferior.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24F));
        tablaInferior.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 46F));
        tablaInferior.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
        tablaInferior.Controls.Add(grpFlota, 0, 0);
        tablaInferior.Controls.Add(grpDetalle, 1, 0);
        tablaInferior.Controls.Add(grpHistorial, 2, 0);
        tablaInferior.Dock = DockStyle.Fill;
        tablaInferior.ForeColor = Color.Black;
        tablaInferior.Location = new Point(0, 92);
        tablaInferior.Name = "tablaInferior";
        tablaInferior.RowCount = 1;
        tablaInferior.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tablaInferior.Size = new Size(1000, 476);
        tablaInferior.TabIndex = 0;
        // 
        // grpFlota
        // 
        grpFlota.BackColor = Color.WhiteSmoke;
        grpFlota.Controls.Add(lstFlota);
        grpFlota.Dock = DockStyle.Fill;
        grpFlota.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        grpFlota.ForeColor = Color.Black;
        grpFlota.Location = new Point(4, 4);
        grpFlota.Margin = new Padding(4);
        grpFlota.Name = "grpFlota";
        grpFlota.Padding = new Padding(8, 6, 8, 8);
        grpFlota.Size = new Size(232, 468);
        grpFlota.TabIndex = 0;
        grpFlota.TabStop = false;
        grpFlota.Text = "Flota";
        // 
        // lstFlota
        // 
        lstFlota.BackColor = Color.White;
        lstFlota.BorderStyle = BorderStyle.FixedSingle;
        lstFlota.Dock = DockStyle.Fill;
        lstFlota.ForeColor = Color.Black;
        lstFlota.FormattingEnabled = true;
        lstFlota.IntegralHeight = false;
        lstFlota.ItemHeight = 17;
        lstFlota.Location = new Point(8, 24);
        lstFlota.Name = "lstFlota";
        lstFlota.Size = new Size(216, 436);
        lstFlota.TabIndex = 0;
        lstFlota.SelectedIndexChanged += lstFlota_SelectedIndexChanged;
        // 
        // grpDetalle
        // 
        grpDetalle.BackColor = Color.WhiteSmoke;
        grpDetalle.Controls.Add(txtDetalle);
        grpDetalle.Dock = DockStyle.Fill;
        grpDetalle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        grpDetalle.ForeColor = Color.Black;
        grpDetalle.Location = new Point(244, 4);
        grpDetalle.Margin = new Padding(4);
        grpDetalle.Name = "grpDetalle";
        grpDetalle.Padding = new Padding(8, 6, 8, 8);
        grpDetalle.Size = new Size(452, 468);
        grpDetalle.TabIndex = 1;
        grpDetalle.TabStop = false;
        grpDetalle.Text = "Nave seleccionada (producto del Builder)";
        // 
        // txtDetalle
        // 
        txtDetalle.BackColor = Color.White;
        txtDetalle.BorderStyle = BorderStyle.FixedSingle;
        txtDetalle.Dock = DockStyle.Fill;
        txtDetalle.Font = new Font("Segoe UI", 9.5F);
        txtDetalle.ForeColor = Color.Black;
        txtDetalle.Location = new Point(8, 24);
        txtDetalle.Multiline = true;
        txtDetalle.Name = "txtDetalle";
        txtDetalle.ReadOnly = true;
        txtDetalle.ScrollBars = ScrollBars.Vertical;
        txtDetalle.Size = new Size(436, 436);
        txtDetalle.TabIndex = 0;
        // 
        // grpHistorial
        // 
        grpHistorial.BackColor = Color.WhiteSmoke;
        grpHistorial.Controls.Add(lstHistorial);
        grpHistorial.Dock = DockStyle.Fill;
        grpHistorial.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        grpHistorial.ForeColor = Color.Black;
        grpHistorial.Location = new Point(704, 4);
        grpHistorial.Margin = new Padding(4);
        grpHistorial.Name = "grpHistorial";
        grpHistorial.Padding = new Padding(8, 6, 8, 8);
        grpHistorial.Size = new Size(292, 468);
        grpHistorial.TabIndex = 2;
        grpHistorial.TabStop = false;
        grpHistorial.Text = "Historial de comandos";
        // 
        // lstHistorial
        // 
        lstHistorial.BackColor = Color.White;
        lstHistorial.BorderStyle = BorderStyle.FixedSingle;
        lstHistorial.Dock = DockStyle.Fill;
        lstHistorial.Font = new Font("Segoe UI", 9.5F);
        lstHistorial.ForeColor = Color.Black;
        lstHistorial.FormattingEnabled = true;
        lstHistorial.HorizontalScrollbar = true;
        lstHistorial.IntegralHeight = false;
        lstHistorial.ItemHeight = 17;
        lstHistorial.Location = new Point(8, 24);
        lstHistorial.Name = "lstHistorial";
        lstHistorial.Size = new Size(276, 436);
        lstHistorial.TabIndex = 0;
        // 
        // lblMensaje
        // 
        lblMensaje.BackColor = Color.WhiteSmoke;
        lblMensaje.Dock = DockStyle.Bottom;
        lblMensaje.ForeColor = Color.DimGray;
        lblMensaje.Location = new Point(0, 568);
        lblMensaje.Name = "lblMensaje";
        lblMensaje.Padding = new Padding(8, 6, 0, 0);
        lblMensaje.Size = new Size(1000, 32);
        lblMensaje.TabIndex = 1;
        // 
        // panelControles
        // 
        panelControles.BackColor = Color.WhiteSmoke;
        panelControles.Controls.Add(lblReceta);
        panelControles.Controls.Add(cboRecetas);
        panelControles.Controls.Add(rdoCompleta);
        panelControles.Controls.Add(rdoBasica);
        panelControles.Controls.Add(btnConstruir);
        panelControles.Controls.Add(btnDeshacer);
        panelControles.Controls.Add(btnRehacer);
        panelControles.Controls.Add(lblCreditos);
        panelControles.Dock = DockStyle.Top;
        panelControles.ForeColor = Color.Black;
        panelControles.Location = new Point(0, 0);
        panelControles.Name = "panelControles";
        panelControles.Padding = new Padding(6);
        panelControles.Size = new Size(1000, 92);
        panelControles.TabIndex = 2;
        // 
        // lblReceta
        // 
        lblReceta.AutoSize = true;
        lblReceta.BackColor = Color.WhiteSmoke;
        lblReceta.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblReceta.ForeColor = Color.Black;
        lblReceta.Location = new Point(9, 14);
        lblReceta.Margin = new Padding(3, 8, 3, 3);
        lblReceta.Name = "lblReceta";
        lblReceta.Size = new Size(58, 19);
        lblReceta.TabIndex = 0;
        lblReceta.Text = "Receta:";
        // 
        // cboRecetas
        // 
        cboRecetas.BackColor = Color.White;
        cboRecetas.DropDownStyle = ComboBoxStyle.DropDownList;
        cboRecetas.ForeColor = Color.Black;
        cboRecetas.FormattingEnabled = true;
        cboRecetas.Location = new Point(73, 9);
        cboRecetas.Name = "cboRecetas";
        cboRecetas.Size = new Size(230, 25);
        cboRecetas.TabIndex = 1;
        // 
        // rdoCompleta
        // 
        rdoCompleta.AutoSize = true;
        rdoCompleta.Checked = true;
        rdoCompleta.Location = new Point(309, 9);
        rdoCompleta.Name = "rdoCompleta";
        rdoCompleta.Size = new Size(118, 23);
        rdoCompleta.TabIndex = 2;
        rdoCompleta.TabStop = true;
        rdoCompleta.Text = "Nave completa";
        rdoCompleta.UseVisualStyleBackColor = true;
        // 
        // rdoBasica
        // 
        rdoBasica.AutoSize = true;
        rdoBasica.Location = new Point(433, 9);
        rdoBasica.Name = "rdoBasica";
        rdoBasica.Size = new Size(99, 23);
        rdoBasica.TabIndex = 3;
        rdoBasica.Text = "Nave básica";
        rdoBasica.UseVisualStyleBackColor = true;
        // 
        // btnConstruir
        // 
        btnConstruir.Location = new Point(538, 9);
        btnConstruir.Name = "btnConstruir";
        btnConstruir.Size = new Size(130, 34);
        btnConstruir.TabIndex = 4;
        btnConstruir.Text = "Construir";
        btnConstruir.UseVisualStyleBackColor = true;
        btnConstruir.Click += btnConstruir_Click;
        // 
        // btnDeshacer
        // 
        btnDeshacer.Location = new Point(674, 9);
        btnDeshacer.Name = "btnDeshacer";
        btnDeshacer.Size = new Size(110, 34);
        btnDeshacer.TabIndex = 5;
        btnDeshacer.Text = "Deshacer";
        btnDeshacer.UseVisualStyleBackColor = true;
        btnDeshacer.Click += btnDeshacer_Click;
        // 
        // btnRehacer
        // 
        btnRehacer.Location = new Point(790, 9);
        btnRehacer.Name = "btnRehacer";
        btnRehacer.Size = new Size(110, 34);
        btnRehacer.TabIndex = 6;
        btnRehacer.Text = "Rehacer";
        btnRehacer.UseVisualStyleBackColor = true;
        btnRehacer.Click += btnRehacer_Click;
        // 
        // lblCreditos
        // 
        lblCreditos.AutoSize = true;
        lblCreditos.BackColor = Color.WhiteSmoke;
        lblCreditos.Font = new Font("Segoe UI", 13F);
        lblCreditos.ForeColor = Color.Black;
        lblCreditos.Location = new Point(921, 12);
        lblCreditos.Margin = new Padding(18, 6, 3, 3);
        lblCreditos.Name = "lblCreditos";
        lblCreditos.Size = new Size(0, 25);
        lblCreditos.TabIndex = 7;
        // 
        // PanelAstillero
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.WhiteSmoke;
        Controls.Add(tablaInferior);
        Controls.Add(lblMensaje);
        Controls.Add(panelControles);
        Font = new Font("Segoe UI", 10F);
        ForeColor = Color.Black;
        Name = "PanelAstillero";
        Size = new Size(1000, 600);
        tablaInferior.ResumeLayout(false);
        grpFlota.ResumeLayout(false);
        grpDetalle.ResumeLayout(false);
        grpDetalle.PerformLayout();
        grpHistorial.ResumeLayout(false);
        panelControles.ResumeLayout(false);
        panelControles.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tablaInferior = null!;
    private GroupBox grpFlota = null!;
    private ListBox lstFlota = null!;
    private GroupBox grpDetalle = null!;
    private TextBox txtDetalle = null!;
    private GroupBox grpHistorial = null!;
    private ListBox lstHistorial = null!;
    private Label lblMensaje = null!;
    private FlowLayoutPanel panelControles = null!;
    private Label lblReceta = null!;
    private ComboBox cboRecetas = null!;
    private RadioButton rdoCompleta = null!;
    private RadioButton rdoBasica = null!;
    private Button btnConstruir = null!;
    private Button btnDeshacer = null!;
    private Button btnRehacer = null!;
    private Label lblCreditos = null!;
}
