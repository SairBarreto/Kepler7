#nullable enable

using System.Drawing;
using System.Windows.Forms;

namespace Kepler7.Game.Formularios;

partial class FormEstacion
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
        tabControl = new TabControl();
        tabCentral = new TabPage();
        panelControlCentral = new Kepler7.Game.Controles.PanelControlCentral();
        tabAstillero = new TabPage();
        panelAstillero = new Kepler7.Game.Controles.PanelAstillero();
        tabLaboratorio = new TabPage();
        panelLaboratorio = new Kepler7.Game.Controles.PanelLaboratorio();
        tabComunicaciones = new TabPage();
        panelComunicaciones = new Kepler7.Game.Controles.PanelComunicaciones();
        tabBoveda = new TabPage();
        panelBoveda = new Kepler7.Game.Controles.PanelBoveda();
        tabLogros = new TabPage();
        panelLogros = new Kepler7.Game.Controles.PanelLogros();
        panelInferior = new FlowLayoutPanel();
        btnCombate = new Button();
        btnVolver = new Button();
        lblAviso = new Label();
        panelSuperior = new Panel();
        lblHud = new Label();
        tabControl.SuspendLayout();
        tabCentral.SuspendLayout();
        tabAstillero.SuspendLayout();
        tabLaboratorio.SuspendLayout();
        tabComunicaciones.SuspendLayout();
        tabBoveda.SuspendLayout();
        tabLogros.SuspendLayout();
        panelInferior.SuspendLayout();
        panelSuperior.SuspendLayout();
        SuspendLayout();
        // 
        // tabControl
        // 
        tabControl.Controls.Add(tabCentral);
        tabControl.Controls.Add(tabAstillero);
        tabControl.Controls.Add(tabLaboratorio);
        tabControl.Controls.Add(tabComunicaciones);
        tabControl.Controls.Add(tabBoveda);
        tabControl.Controls.Add(tabLogros);
        tabControl.Dock = DockStyle.Fill;
        tabControl.Location = new Point(0, 68);
        tabControl.Name = "tabControl";
        tabControl.SelectedIndex = 0;
        tabControl.Size = new Size(1100, 598);
        tabControl.TabIndex = 0;
        tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;
        // 
        // tabCentral
        // 
        tabCentral.BackColor = Color.WhiteSmoke;
        tabCentral.Controls.Add(panelControlCentral);
        tabCentral.ForeColor = Color.Black;
        tabCentral.Location = new Point(4, 26);
        tabCentral.Name = "tabCentral";
        tabCentral.Size = new Size(1092, 568);
        tabCentral.TabIndex = 0;
        tabCentral.Text = "Control Central";
        // 
        // panelControlCentral
        // 
        panelControlCentral.BackColor = Color.WhiteSmoke;
        panelControlCentral.Dock = DockStyle.Fill;
        panelControlCentral.Font = new Font("Segoe UI", 10F);
        panelControlCentral.ForeColor = Color.Black;
        panelControlCentral.Location = new Point(0, 0);
        panelControlCentral.Name = "panelControlCentral";
        panelControlCentral.Size = new Size(1092, 568);
        panelControlCentral.TabIndex = 0;
        // 
        // tabAstillero
        // 
        tabAstillero.BackColor = Color.WhiteSmoke;
        tabAstillero.Controls.Add(panelAstillero);
        tabAstillero.ForeColor = Color.Black;
        tabAstillero.Location = new Point(4, 24);
        tabAstillero.Name = "tabAstillero";
        tabAstillero.Size = new Size(192, 72);
        tabAstillero.TabIndex = 1;
        tabAstillero.Text = "Astillero";
        // 
        // panelAstillero
        // 
        panelAstillero.BackColor = Color.WhiteSmoke;
        panelAstillero.Dock = DockStyle.Fill;
        panelAstillero.Font = new Font("Segoe UI", 10F);
        panelAstillero.ForeColor = Color.Black;
        panelAstillero.Location = new Point(0, 0);
        panelAstillero.Name = "panelAstillero";
        panelAstillero.Size = new Size(192, 72);
        panelAstillero.TabIndex = 0;
        // 
        // tabLaboratorio
        // 
        tabLaboratorio.BackColor = Color.WhiteSmoke;
        tabLaboratorio.Controls.Add(panelLaboratorio);
        tabLaboratorio.ForeColor = Color.Black;
        tabLaboratorio.Location = new Point(4, 26);
        tabLaboratorio.Name = "tabLaboratorio";
        tabLaboratorio.Size = new Size(1092, 568);
        tabLaboratorio.TabIndex = 2;
        tabLaboratorio.Text = "Laboratorio";
        // 
        // panelLaboratorio
        // 
        panelLaboratorio.BackColor = Color.WhiteSmoke;
        panelLaboratorio.Dock = DockStyle.Fill;
        panelLaboratorio.Font = new Font("Segoe UI", 10F);
        panelLaboratorio.ForeColor = Color.Black;
        panelLaboratorio.Location = new Point(0, 0);
        panelLaboratorio.Name = "panelLaboratorio";
        panelLaboratorio.Size = new Size(1092, 568);
        panelLaboratorio.TabIndex = 0;
        // 
        // tabComunicaciones
        // 
        tabComunicaciones.BackColor = Color.WhiteSmoke;
        tabComunicaciones.Controls.Add(panelComunicaciones);
        tabComunicaciones.ForeColor = Color.Black;
        tabComunicaciones.Location = new Point(4, 24);
        tabComunicaciones.Name = "tabComunicaciones";
        tabComunicaciones.Size = new Size(192, 72);
        tabComunicaciones.TabIndex = 3;
        tabComunicaciones.Text = "Comunicaciones";
        // 
        // panelComunicaciones
        // 
        panelComunicaciones.BackColor = Color.WhiteSmoke;
        panelComunicaciones.Dock = DockStyle.Fill;
        panelComunicaciones.Font = new Font("Segoe UI", 10F);
        panelComunicaciones.ForeColor = Color.Black;
        panelComunicaciones.Location = new Point(0, 0);
        panelComunicaciones.Name = "panelComunicaciones";
        panelComunicaciones.Size = new Size(192, 72);
        panelComunicaciones.TabIndex = 0;
        // 
        // tabBoveda
        // 
        tabBoveda.BackColor = Color.WhiteSmoke;
        tabBoveda.Controls.Add(panelBoveda);
        tabBoveda.ForeColor = Color.Black;
        tabBoveda.Location = new Point(4, 24);
        tabBoveda.Name = "tabBoveda";
        tabBoveda.Size = new Size(192, 72);
        tabBoveda.TabIndex = 4;
        tabBoveda.Text = "Bóveda";
        // 
        // panelBoveda
        // 
        panelBoveda.BackColor = Color.WhiteSmoke;
        panelBoveda.Dock = DockStyle.Fill;
        panelBoveda.Font = new Font("Segoe UI", 10F);
        panelBoveda.ForeColor = Color.Black;
        panelBoveda.Location = new Point(0, 0);
        panelBoveda.Name = "panelBoveda";
        panelBoveda.Size = new Size(192, 72);
        panelBoveda.TabIndex = 0;
        // 
        // tabLogros
        // 
        tabLogros.BackColor = Color.WhiteSmoke;
        tabLogros.Controls.Add(panelLogros);
        tabLogros.ForeColor = Color.Black;
        tabLogros.Location = new Point(4, 24);
        tabLogros.Name = "tabLogros";
        tabLogros.Size = new Size(192, 72);
        tabLogros.TabIndex = 5;
        tabLogros.Text = "Logros";
        // 
        // panelLogros
        // 
        panelLogros.BackColor = Color.WhiteSmoke;
        panelLogros.Dock = DockStyle.Fill;
        panelLogros.Font = new Font("Segoe UI", 10F);
        panelLogros.ForeColor = Color.Black;
        panelLogros.Location = new Point(0, 0);
        panelLogros.Name = "panelLogros";
        panelLogros.Size = new Size(192, 72);
        panelLogros.TabIndex = 0;
        // 
        // panelInferior
        // 
        panelInferior.BackColor = Color.WhiteSmoke;
        panelInferior.Controls.Add(btnCombate);
        panelInferior.Controls.Add(btnVolver);
        panelInferior.Dock = DockStyle.Bottom;
        panelInferior.FlowDirection = FlowDirection.RightToLeft;
        panelInferior.ForeColor = Color.Black;
        panelInferior.Location = new Point(0, 666);
        panelInferior.Name = "panelInferior";
        panelInferior.Padding = new Padding(8);
        panelInferior.Size = new Size(1100, 54);
        panelInferior.TabIndex = 1;
        // 
        // btnCombate
        // 
        btnCombate.Location = new Point(911, 11);
        btnCombate.Name = "btnCombate";
        btnCombate.Size = new Size(170, 36);
        btnCombate.TabIndex = 0;
        btnCombate.Text = "Ir al combate";
        btnCombate.UseVisualStyleBackColor = true;
        btnCombate.Click += btnCombate_Click;
        // 
        // btnVolver
        // 
        btnVolver.Location = new Point(755, 11);
        btnVolver.Name = "btnVolver";
        btnVolver.Size = new Size(150, 36);
        btnVolver.TabIndex = 1;
        btnVolver.Text = "Volver al menú";
        btnVolver.UseVisualStyleBackColor = true;
        btnVolver.Click += btnVolver_Click;
        // 
        // lblAviso
        // 
        lblAviso.BackColor = Color.WhiteSmoke;
        lblAviso.Dock = DockStyle.Top;
        lblAviso.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblAviso.ForeColor = Color.Black;
        lblAviso.Location = new Point(0, 40);
        lblAviso.Name = "lblAviso";
        lblAviso.Size = new Size(1100, 28);
        lblAviso.TabIndex = 2;
        lblAviso.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // panelSuperior
        // 
        panelSuperior.BackColor = Color.WhiteSmoke;
        panelSuperior.Controls.Add(lblHud);
        panelSuperior.Dock = DockStyle.Top;
        panelSuperior.ForeColor = Color.Black;
        panelSuperior.Location = new Point(0, 0);
        panelSuperior.Name = "panelSuperior";
        panelSuperior.Padding = new Padding(10, 10, 0, 0);
        panelSuperior.Size = new Size(1100, 40);
        panelSuperior.TabIndex = 3;
        // 
        // lblHud
        // 
        lblHud.AutoSize = true;
        lblHud.BackColor = Color.WhiteSmoke;
        lblHud.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblHud.ForeColor = Color.Black;
        lblHud.Location = new Point(0, 0);
        lblHud.Name = "lblHud";
        lblHud.Size = new Size(0, 19);
        lblHud.TabIndex = 0;
        // 
        // FormEstacion
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.WhiteSmoke;
        ClientSize = new Size(1100, 720);
        Controls.Add(tabControl);
        Controls.Add(panelInferior);
        Controls.Add(lblAviso);
        Controls.Add(panelSuperior);
        Font = new Font("Segoe UI", 10F);
        ForeColor = Color.Black;
        MinimumSize = new Size(980, 640);
        Name = "FormEstacion";
        StartPosition = FormStartPosition.CenterParent;
        Text = "KEPLER-7 — Estación orbital";
        tabControl.ResumeLayout(false);
        tabCentral.ResumeLayout(false);
        tabAstillero.ResumeLayout(false);
        tabLaboratorio.ResumeLayout(false);
        tabComunicaciones.ResumeLayout(false);
        tabBoveda.ResumeLayout(false);
        tabLogros.ResumeLayout(false);
        panelInferior.ResumeLayout(false);
        panelSuperior.ResumeLayout(false);
        panelSuperior.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private TabControl tabControl = null!;
    private TabPage tabCentral = null!;
    private Kepler7.Game.Controles.PanelControlCentral panelControlCentral = null!;
    private TabPage tabAstillero = null!;
    private Kepler7.Game.Controles.PanelAstillero panelAstillero = null!;
    private TabPage tabLaboratorio = null!;
    private Kepler7.Game.Controles.PanelLaboratorio panelLaboratorio = null!;
    private TabPage tabComunicaciones = null!;
    private Kepler7.Game.Controles.PanelComunicaciones panelComunicaciones = null!;
    private TabPage tabBoveda = null!;
    private Kepler7.Game.Controles.PanelBoveda panelBoveda = null!;
    private TabPage tabLogros = null!;
    private Kepler7.Game.Controles.PanelLogros panelLogros = null!;
    private FlowLayoutPanel panelInferior = null!;
    private Button btnCombate = null!;
    private Button btnVolver = null!;
    private Label lblAviso = null!;
    private Panel panelSuperior = null!;
    private Label lblHud = null!;
}
