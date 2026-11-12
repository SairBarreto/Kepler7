#nullable enable

using System.Drawing;
using System.Windows.Forms;

namespace Kepler7.Game.Controles;

partial class PanelControlCentral
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
        this.tablaCentral = new TableLayoutPanel();
        this.grpSubsistemas = new GroupBox();
        this.lvSubsistemas = new ListView();
        this.colSubsistema = new ColumnHeader();
        this.colEstado = new ColumnHeader();
        this.colNivel = new ColumnHeader();
        this.colDetalle = new ColumnHeader();
        this.grpRegistro = new GroupBox();
        this.lstRegistro = new ListBox();
        this.panelBotones = new FlowLayoutPanel();
        this.btnIniciarTurno = new Button();
        this.btnEmergencia = new Button();
        this.btnApagar = new Button();
        this.panelEstado = new FlowLayoutPanel();
        this.lblModo = new Label();
        this.lblTurno = new Label();

        this.SuspendLayout();
        this.tablaCentral.SuspendLayout();
        this.grpSubsistemas.SuspendLayout();
        this.lvSubsistemas.SuspendLayout();
        this.grpRegistro.SuspendLayout();
        this.panelBotones.SuspendLayout();
        this.panelEstado.SuspendLayout();

        // PanelControlCentral
        this.Controls.Add(this.tablaCentral);
        this.Controls.Add(this.panelBotones);
        this.Controls.Add(this.panelEstado);
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.WhiteSmoke;
        this.ForeColor = System.Drawing.Color.Black;
        this.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.Size = new System.Drawing.Size(1000, 600);

        // tablaCentral
        this.tablaCentral.ColumnCount = 1;
        this.tablaCentral.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
        this.tablaCentral.RowCount = 2;
        this.tablaCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
        this.tablaCentral.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
        this.tablaCentral.Controls.Add(this.grpSubsistemas, 0, 0);
        this.tablaCentral.Controls.Add(this.grpRegistro, 0, 1);
        this.tablaCentral.BackColor = System.Drawing.Color.WhiteSmoke;
        this.tablaCentral.ForeColor = System.Drawing.Color.Black;
        this.tablaCentral.Dock = System.Windows.Forms.DockStyle.Fill;

        // grpSubsistemas
        this.grpSubsistemas.Controls.Add(this.lvSubsistemas);
        this.grpSubsistemas.BackColor = System.Drawing.Color.WhiteSmoke;
        this.grpSubsistemas.Dock = System.Windows.Forms.DockStyle.Fill;
        this.grpSubsistemas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.grpSubsistemas.ForeColor = System.Drawing.Color.Black;
        this.grpSubsistemas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
        this.grpSubsistemas.Padding = new System.Windows.Forms.Padding(8, 6, 8, 8);
        this.grpSubsistemas.Text = "Subsistemas";
        this.grpSubsistemas.TabStop = false;

        // lvSubsistemas
        this.lvSubsistemas.BackColor = System.Drawing.Color.White;
        this.lvSubsistemas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.lvSubsistemas.ForeColor = System.Drawing.Color.Black;
        this.lvSubsistemas.FullRowSelect = true;
        this.lvSubsistemas.GridLines = true;
        this.lvSubsistemas.HideSelection = false;
        this.lvSubsistemas.View = System.Windows.Forms.View.Details;
        this.lvSubsistemas.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lvSubsistemas.UseCompatibleStateImageBehavior = false;
        this.lvSubsistemas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {this.colSubsistema, this.colEstado, this.colNivel, this.colDetalle});

        // colSubsistema
        this.colSubsistema.Text = "Subsistema";
        this.colSubsistema.Width = 150;

        // colEstado
        this.colEstado.Text = "Estado";
        this.colEstado.Width = 90;

        // colNivel
        this.colNivel.Text = "Nivel";
        this.colNivel.Width = 70;

        // colDetalle
        this.colDetalle.Text = "Detalle";
        this.colDetalle.Width = 460;

        // grpRegistro
        this.grpRegistro.Controls.Add(this.lstRegistro);
        this.grpRegistro.BackColor = System.Drawing.Color.WhiteSmoke;
        this.grpRegistro.Dock = System.Windows.Forms.DockStyle.Fill;
        this.grpRegistro.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.grpRegistro.ForeColor = System.Drawing.Color.Black;
        this.grpRegistro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
        this.grpRegistro.Padding = new System.Windows.Forms.Padding(8, 6, 8, 8);
        this.grpRegistro.Text = "Registro de la estación (bitácora compartida)";
        this.grpRegistro.TabStop = false;

        // lstRegistro
        this.lstRegistro.BackColor = System.Drawing.Color.White;
        this.lstRegistro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.lstRegistro.ForeColor = System.Drawing.Color.Black;
        this.lstRegistro.FormattingEnabled = true;
        this.lstRegistro.IntegralHeight = false;
        this.lstRegistro.Font = new System.Drawing.Font("Segoe UI", 9.5F);
        this.lstRegistro.HorizontalScrollbar = true;
        this.lstRegistro.Dock = System.Windows.Forms.DockStyle.Fill;

        // panelBotones
        this.panelBotones.Controls.Add(this.btnIniciarTurno);
        this.panelBotones.Controls.Add(this.btnEmergencia);
        this.panelBotones.Controls.Add(this.btnApagar);
        this.panelBotones.BackColor = System.Drawing.Color.WhiteSmoke;
        this.panelBotones.ForeColor = System.Drawing.Color.Black;
        this.panelBotones.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
        this.panelBotones.WrapContents = true;
        this.panelBotones.Dock = System.Windows.Forms.DockStyle.Top;
        this.panelBotones.Height = 46;
        this.panelBotones.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);

        // btnIniciarTurno
        this.btnIniciarTurno.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
        this.btnIniciarTurno.Size = new System.Drawing.Size(150, 34);
        this.btnIniciarTurno.Text = "Iniciar turno";
        this.btnIniciarTurno.UseVisualStyleBackColor = true;
        this.btnIniciarTurno.Click += new System.EventHandler(this.btnIniciarTurno_Click);

        // btnEmergencia
        this.btnEmergencia.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
        this.btnEmergencia.Size = new System.Drawing.Size(150, 34);
        this.btnEmergencia.Text = "Emergencia";
        this.btnEmergencia.UseVisualStyleBackColor = true;
        this.btnEmergencia.Click += new System.EventHandler(this.btnEmergencia_Click);

        // btnApagar
        this.btnApagar.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
        this.btnApagar.Size = new System.Drawing.Size(170, 34);
        this.btnApagar.Text = "Apagar estación";
        this.btnApagar.UseVisualStyleBackColor = true;
        this.btnApagar.Click += new System.EventHandler(this.btnApagar_Click);

        // panelEstado
        this.panelEstado.Controls.Add(this.lblModo);
        this.panelEstado.Controls.Add(this.lblTurno);
        this.panelEstado.BackColor = System.Drawing.Color.WhiteSmoke;
        this.panelEstado.ForeColor = System.Drawing.Color.Black;
        this.panelEstado.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight;
        this.panelEstado.WrapContents = false;
        this.panelEstado.Dock = System.Windows.Forms.DockStyle.Top;
        this.panelEstado.Height = 56;
        this.panelEstado.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);

        // lblModo
        this.lblModo.BackColor = System.Drawing.Color.WhiteSmoke;
        this.lblModo.ForeColor = System.Drawing.Color.DimGray;
        this.lblModo.Text = "";
        this.lblModo.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
        this.lblModo.AutoSize = true;
        this.lblModo.Margin = new System.Windows.Forms.Padding(3, 0, 24, 0);

        // lblTurno
        this.lblTurno.BackColor = System.Drawing.Color.WhiteSmoke;
        this.lblTurno.ForeColor = System.Drawing.Color.DimGray;
        this.lblTurno.Text = "";
        this.lblTurno.Font = new System.Drawing.Font("Segoe UI", 13F);
        this.lblTurno.AutoSize = true;
        this.lblTurno.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);

        this.lvSubsistemas.ResumeLayout(false);
        this.lvSubsistemas.PerformLayout();
        this.grpSubsistemas.ResumeLayout(false);
        this.grpSubsistemas.PerformLayout();
        this.grpRegistro.ResumeLayout(false);
        this.grpRegistro.PerformLayout();
        this.tablaCentral.ResumeLayout(false);
        this.tablaCentral.PerformLayout();
        this.panelBotones.ResumeLayout(false);
        this.panelBotones.PerformLayout();
        this.panelEstado.ResumeLayout(false);
        this.panelEstado.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private TableLayoutPanel tablaCentral = null!;
    private GroupBox grpSubsistemas = null!;
    private ListView lvSubsistemas = null!;
    private ColumnHeader colSubsistema = null!;
    private ColumnHeader colEstado = null!;
    private ColumnHeader colNivel = null!;
    private ColumnHeader colDetalle = null!;
    private GroupBox grpRegistro = null!;
    private ListBox lstRegistro = null!;
    private FlowLayoutPanel panelBotones = null!;
    private Button btnIniciarTurno = null!;
    private Button btnEmergencia = null!;
    private Button btnApagar = null!;
    private FlowLayoutPanel panelEstado = null!;
    private Label lblModo = null!;
    private Label lblTurno = null!;
}
