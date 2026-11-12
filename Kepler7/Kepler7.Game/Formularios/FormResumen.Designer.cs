#nullable enable

using System.Drawing;
using System.Windows.Forms;

namespace Kepler7.Game.Formularios;

partial class FormResumen
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
        this.flujo = new FlowLayoutPanel();
        this.lblResultado = new Label();
        this.lblDetalle = new Label();
        this.tablaDatos = new TableLayoutPanel();
        this.lblRondasT = new Label();
        this.lblRondas = new Label();
        this.lblAliadosT = new Label();
        this.lblAliados = new Label();
        this.lblEnemigosT = new Label();
        this.lblEnemigos = new Label();
        this.lblComandosT = new Label();
        this.lblComandos = new Label();
        this.lblXpT = new Label();
        this.lblXp = new Label();
        this.lblMonedasT = new Label();
        this.lblMonedas = new Label();
        this.lblNivel = new Label();
        this.barraXp = new ProgressBar();
        this.lblSubioNivel = new Label();
        this.lblInsignias = new Label();
        this.lstInsignias = new ListBox();
        this.panelBotones = new Panel();
        this.btnVolver = new Button();

        this.SuspendLayout();
        this.flujo.SuspendLayout();
        this.tablaDatos.SuspendLayout();
        this.panelBotones.SuspendLayout();

        // FormResumen
        this.Controls.Add(this.flujo);
        this.Controls.Add(this.panelBotones);
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.WhiteSmoke;
        this.ForeColor = System.Drawing.Color.Black;
        this.Font = new System.Drawing.Font("Segoe UI", 10F);
        this.ClientSize = new System.Drawing.Size(760, 620);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "Resumen de la partida";
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.AcceptButton = this.btnVolver;

        // flujo
        this.flujo.Controls.Add(this.lblResultado);
        this.flujo.Controls.Add(this.lblDetalle);
        this.flujo.Controls.Add(this.tablaDatos);
        this.flujo.Controls.Add(this.lblNivel);
        this.flujo.Controls.Add(this.barraXp);
        this.flujo.Controls.Add(this.lblSubioNivel);
        this.flujo.Controls.Add(this.lblInsignias);
        this.flujo.Controls.Add(this.lstInsignias);
        this.flujo.BackColor = System.Drawing.Color.WhiteSmoke;
        this.flujo.ForeColor = System.Drawing.Color.Black;
        this.flujo.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
        this.flujo.WrapContents = false;
        this.flujo.Dock = System.Windows.Forms.DockStyle.Fill;
        this.flujo.Padding = new System.Windows.Forms.Padding(40, 30, 40, 10);

        // lblResultado
        this.lblResultado.BackColor = System.Drawing.Color.WhiteSmoke;
        this.lblResultado.ForeColor = System.Drawing.Color.Black;
        this.lblResultado.Text = "";
        this.lblResultado.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold);
        this.lblResultado.AutoSize = true;

        // lblDetalle
        this.lblDetalle.BackColor = System.Drawing.Color.WhiteSmoke;
        this.lblDetalle.ForeColor = System.Drawing.Color.Black;
        this.lblDetalle.Text = "";
        this.lblDetalle.Font = new System.Drawing.Font("Segoe UI", 13F);
        this.lblDetalle.AutoSize = true;
        this.lblDetalle.Margin = new System.Windows.Forms.Padding(3, 0, 3, 12);

        // tablaDatos
        this.tablaDatos.ColumnCount = 2;
        this.tablaDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize, 0F));
        this.tablaDatos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.AutoSize, 0F));
        this.tablaDatos.RowCount = 6;
        this.tablaDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize, 0F));
        this.tablaDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize, 0F));
        this.tablaDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize, 0F));
        this.tablaDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize, 0F));
        this.tablaDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize, 0F));
        this.tablaDatos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.AutoSize, 0F));
        this.tablaDatos.Controls.Add(this.lblRondasT, 0, 0);
        this.tablaDatos.Controls.Add(this.lblRondas, 1, 0);
        this.tablaDatos.Controls.Add(this.lblAliadosT, 0, 1);
        this.tablaDatos.Controls.Add(this.lblAliados, 1, 1);
        this.tablaDatos.Controls.Add(this.lblEnemigosT, 0, 2);
        this.tablaDatos.Controls.Add(this.lblEnemigos, 1, 2);
        this.tablaDatos.Controls.Add(this.lblComandosT, 0, 3);
        this.tablaDatos.Controls.Add(this.lblComandos, 1, 3);
        this.tablaDatos.Controls.Add(this.lblXpT, 0, 4);
        this.tablaDatos.Controls.Add(this.lblXp, 1, 4);
        this.tablaDatos.Controls.Add(this.lblMonedasT, 0, 5);
        this.tablaDatos.Controls.Add(this.lblMonedas, 1, 5);
        this.tablaDatos.BackColor = System.Drawing.Color.WhiteSmoke;
        this.tablaDatos.ForeColor = System.Drawing.Color.Black;
        this.tablaDatos.AutoSize = true;

        // lblRondasT
        this.lblRondasT.BackColor = System.Drawing.Color.WhiteSmoke;
        this.lblRondasT.ForeColor = System.Drawing.Color.DimGray;
        this.lblRondasT.Text = "Rondas jugadas:";
        this.lblRondasT.AutoSize = true;
        this.lblRondasT.Margin = new System.Windows.Forms.Padding(3, 3, 12, 3);

        // lblRondas
        this.lblRondas.BackColor = System.Drawing.Color.WhiteSmoke;
        this.lblRondas.ForeColor = System.Drawing.Color.Black;
        this.lblRondas.Text = "";
        this.lblRondas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.lblRondas.AutoSize = true;
        this.lblRondas.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);

        // lblAliadosT
        this.lblAliadosT.BackColor = System.Drawing.Color.WhiteSmoke;
        this.lblAliadosT.ForeColor = System.Drawing.Color.DimGray;
        this.lblAliadosT.Text = "Aliados en pie:";
        this.lblAliadosT.AutoSize = true;
        this.lblAliadosT.Margin = new System.Windows.Forms.Padding(3, 3, 12, 3);

        // lblAliados
        this.lblAliados.BackColor = System.Drawing.Color.WhiteSmoke;
        this.lblAliados.ForeColor = System.Drawing.Color.Black;
        this.lblAliados.Text = "";
        this.lblAliados.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.lblAliados.AutoSize = true;
        this.lblAliados.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);

        // lblEnemigosT
        this.lblEnemigosT.BackColor = System.Drawing.Color.WhiteSmoke;
        this.lblEnemigosT.ForeColor = System.Drawing.Color.DimGray;
        this.lblEnemigosT.Text = "Enemigos derrotados:";
        this.lblEnemigosT.AutoSize = true;
        this.lblEnemigosT.Margin = new System.Windows.Forms.Padding(3, 3, 12, 3);

        // lblEnemigos
        this.lblEnemigos.BackColor = System.Drawing.Color.WhiteSmoke;
        this.lblEnemigos.ForeColor = System.Drawing.Color.Black;
        this.lblEnemigos.Text = "";
        this.lblEnemigos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.lblEnemigos.AutoSize = true;
        this.lblEnemigos.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);

        // lblComandosT
        this.lblComandosT.BackColor = System.Drawing.Color.WhiteSmoke;
        this.lblComandosT.ForeColor = System.Drawing.Color.DimGray;
        this.lblComandosT.Text = "Comandos ejecutados:";
        this.lblComandosT.AutoSize = true;
        this.lblComandosT.Margin = new System.Windows.Forms.Padding(3, 3, 12, 3);

        // lblComandos
        this.lblComandos.BackColor = System.Drawing.Color.WhiteSmoke;
        this.lblComandos.ForeColor = System.Drawing.Color.Black;
        this.lblComandos.Text = "";
        this.lblComandos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.lblComandos.AutoSize = true;
        this.lblComandos.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);

        // lblXpT
        this.lblXpT.BackColor = System.Drawing.Color.WhiteSmoke;
        this.lblXpT.ForeColor = System.Drawing.Color.DimGray;
        this.lblXpT.Text = "XP ganada:";
        this.lblXpT.AutoSize = true;
        this.lblXpT.Margin = new System.Windows.Forms.Padding(3, 3, 12, 3);

        // lblXp
        this.lblXp.BackColor = System.Drawing.Color.WhiteSmoke;
        this.lblXp.ForeColor = System.Drawing.Color.Black;
        this.lblXp.Text = "";
        this.lblXp.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.lblXp.AutoSize = true;
        this.lblXp.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);

        // lblMonedasT
        this.lblMonedasT.BackColor = System.Drawing.Color.WhiteSmoke;
        this.lblMonedasT.ForeColor = System.Drawing.Color.DimGray;
        this.lblMonedasT.Text = "Monedas ganadas:";
        this.lblMonedasT.AutoSize = true;
        this.lblMonedasT.Margin = new System.Windows.Forms.Padding(3, 3, 12, 3);

        // lblMonedas
        this.lblMonedas.BackColor = System.Drawing.Color.WhiteSmoke;
        this.lblMonedas.ForeColor = System.Drawing.Color.Black;
        this.lblMonedas.Text = "";
        this.lblMonedas.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.lblMonedas.AutoSize = true;
        this.lblMonedas.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);

        // lblNivel
        this.lblNivel.BackColor = System.Drawing.Color.WhiteSmoke;
        this.lblNivel.ForeColor = System.Drawing.Color.Black;
        this.lblNivel.Text = "";
        this.lblNivel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.lblNivel.AutoSize = true;
        this.lblNivel.Margin = new System.Windows.Forms.Padding(3, 14, 3, 3);

        // barraXp
        this.barraXp.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
        this.barraXp.Maximum = 100;
        this.barraXp.Size = new System.Drawing.Size(420, 18);
        this.barraXp.Style = System.Windows.Forms.ProgressBarStyle.Continuous;

        // lblSubioNivel
        this.lblSubioNivel.BackColor = System.Drawing.Color.WhiteSmoke;
        this.lblSubioNivel.ForeColor = System.Drawing.Color.Black;
        this.lblSubioNivel.Text = "";
        this.lblSubioNivel.Font = new System.Drawing.Font("Segoe UI", 13F);
        this.lblSubioNivel.AutoSize = true;
        this.lblSubioNivel.Visible = false;

        // lblInsignias
        this.lblInsignias.BackColor = System.Drawing.Color.WhiteSmoke;
        this.lblInsignias.ForeColor = System.Drawing.Color.Black;
        this.lblInsignias.Text = "Insignias nuevas en esta partida";
        this.lblInsignias.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
        this.lblInsignias.AutoSize = true;
        this.lblInsignias.Margin = new System.Windows.Forms.Padding(3, 14, 3, 3);

        // lstInsignias
        this.lstInsignias.BackColor = System.Drawing.Color.White;
        this.lstInsignias.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        this.lstInsignias.ForeColor = System.Drawing.Color.Black;
        this.lstInsignias.FormattingEnabled = true;
        this.lstInsignias.IntegralHeight = false;
        this.lstInsignias.Size = new System.Drawing.Size(560, 120);

        // panelBotones
        this.panelBotones.Controls.Add(this.btnVolver);
        this.panelBotones.BackColor = System.Drawing.Color.WhiteSmoke;
        this.panelBotones.ForeColor = System.Drawing.Color.Black;
        this.panelBotones.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.panelBotones.Height = 60;

        // btnVolver
        this.btnVolver.Location = new System.Drawing.Point(40, 12);
        this.btnVolver.Size = new System.Drawing.Size(240, 36);
        this.btnVolver.Text = "Volver a la estación";
        this.btnVolver.UseVisualStyleBackColor = true;
        this.btnVolver.DialogResult = System.Windows.Forms.DialogResult.OK;

        this.tablaDatos.ResumeLayout(false);
        this.tablaDatos.PerformLayout();
        this.flujo.ResumeLayout(false);
        this.flujo.PerformLayout();
        this.panelBotones.ResumeLayout(false);
        this.panelBotones.PerformLayout();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private FlowLayoutPanel flujo = null!;
    private Label lblResultado = null!;
    private Label lblDetalle = null!;
    private TableLayoutPanel tablaDatos = null!;
    private Label lblRondasT = null!;
    private Label lblRondas = null!;
    private Label lblAliadosT = null!;
    private Label lblAliados = null!;
    private Label lblEnemigosT = null!;
    private Label lblEnemigos = null!;
    private Label lblComandosT = null!;
    private Label lblComandos = null!;
    private Label lblXpT = null!;
    private Label lblXp = null!;
    private Label lblMonedasT = null!;
    private Label lblMonedas = null!;
    private Label lblNivel = null!;
    private ProgressBar barraXp = null!;
    private Label lblSubioNivel = null!;
    private Label lblInsignias = null!;
    private ListBox lstInsignias = null!;
    private Panel panelBotones = null!;
    private Button btnVolver = null!;
}
