#nullable enable

using System.Drawing;
using System.Windows.Forms;

namespace Kepler7.Game.Formularios;

partial class FormCombate
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
        tablaRaiz = new TableLayoutPanel();
        flujoTablero = new FlowLayoutPanel();
        lblHud = new Label();
        tablero = new Kepler7.Game.Controles.TableroControl();
        panelAcciones = new FlowLayoutPanel();
        btnMover = new Button();
        btnAtacar = new Button();
        btnCurar = new Button();
        btnFuria = new Button();
        btnAuto = new Button();
        btnDeshacer = new Button();
        btnRehacer = new Button();
        btnTerminar = new Button();
        lblUltimoGolpe = new Label();
        lblMensaje = new Label();
        tablaUnidad = new TableLayoutPanel();
        grpUnidad = new GroupBox();
        flujoUnidad = new FlowLayoutPanel();
        lblUnidadNombre = new Label();
        lblUnidadVida = new Label();
        lblUnidadEstado = new Label();
        lblUnidadAcciones = new Label();
        lblUnidadArma = new Label();
        grpDefensas = new GroupBox();
        panelDefensas = new Panel();
        lstDefensas = new ListBox();
        panelCadena = new FlowLayoutPanel();
        btnCapaSubir = new Button();
        btnCapaBajar = new Button();
        btnCapaQuitar = new Button();
        cboNuevaCapa = new ComboBox();
        btnCapaAgregar = new Button();
        grpIA = new GroupBox();
        panelIA = new Panel();
        lstComparacion = new ListBox();
        lblIaUltima = new Label();
        lblIaIntencion = new Label();
        panelCambioIA = new FlowLayoutPanel();
        cboEstrategia = new ComboBox();
        btnCambiarIA = new Button();
        tablaInfo = new TableLayoutPanel();
        grpInventario = new GroupBox();
        panelInventario = new Panel();
        txtVisitante = new TextBox();
        panelVisitante = new FlowLayoutPanel();
        cboVisitante = new ComboBox();
        btnAplicarVisitante = new Button();
        grpHistorial = new GroupBox();
        lstHistorial = new ListBox();
        grpBitacora = new GroupBox();
        lstBitacora = new ListBox();
        lblAviso = new Label();
        tablaRaiz.SuspendLayout();
        flujoTablero.SuspendLayout();
        panelAcciones.SuspendLayout();
        tablaUnidad.SuspendLayout();
        grpUnidad.SuspendLayout();
        flujoUnidad.SuspendLayout();
        grpDefensas.SuspendLayout();
        panelDefensas.SuspendLayout();
        panelCadena.SuspendLayout();
        grpIA.SuspendLayout();
        panelIA.SuspendLayout();
        panelCambioIA.SuspendLayout();
        tablaInfo.SuspendLayout();
        grpInventario.SuspendLayout();
        panelInventario.SuspendLayout();
        panelVisitante.SuspendLayout();
        grpHistorial.SuspendLayout();
        grpBitacora.SuspendLayout();
        SuspendLayout();
        // 
        // tablaRaiz
        // 
        tablaRaiz.BackColor = Color.WhiteSmoke;
        tablaRaiz.ColumnCount = 3;
        tablaRaiz.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 540F));
        tablaRaiz.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 340F));
        tablaRaiz.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tablaRaiz.Controls.Add(flujoTablero, 0, 0);
        tablaRaiz.Controls.Add(tablaUnidad, 1, 0);
        tablaRaiz.Controls.Add(tablaInfo, 2, 0);
        tablaRaiz.Dock = DockStyle.Fill;
        tablaRaiz.ForeColor = Color.Black;
        tablaRaiz.Location = new Point(0, 28);
        tablaRaiz.Name = "tablaRaiz";
        tablaRaiz.Padding = new Padding(6);
        tablaRaiz.RowCount = 1;
        tablaRaiz.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tablaRaiz.Size = new Size(1360, 772);
        tablaRaiz.TabIndex = 0;
        // 
        // flujoTablero
        // 
        flujoTablero.BackColor = Color.WhiteSmoke;
        flujoTablero.Controls.Add(lblHud);
        flujoTablero.Controls.Add(tablero);
        flujoTablero.Controls.Add(panelAcciones);
        flujoTablero.Controls.Add(lblUltimoGolpe);
        flujoTablero.Controls.Add(lblMensaje);
        flujoTablero.Dock = DockStyle.Fill;
        flujoTablero.FlowDirection = FlowDirection.TopDown;
        flujoTablero.ForeColor = Color.Black;
        flujoTablero.Location = new Point(9, 9);
        flujoTablero.Name = "flujoTablero";
        flujoTablero.Size = new Size(534, 754);
        flujoTablero.TabIndex = 0;
        flujoTablero.WrapContents = false;
        // 
        // lblHud
        // 
        lblHud.BackColor = Color.WhiteSmoke;
        lblHud.Font = new Font("Segoe UI", 13F);
        lblHud.ForeColor = Color.Black;
        lblHud.Location = new Point(3, 0);
        lblHud.Name = "lblHud";
        lblHud.Size = new Size(520, 30);
        lblHud.TabIndex = 0;
        // 
        // tablero
        // 
        tablero.BackColor = Color.FromArgb(15, 22, 42);
        tablero.Contexto = null;
        tablero.Location = new Point(3, 33);
        tablero.Modo = Controles.ModoAccion.Ninguno;
        tablero.Name = "tablero";
        tablero.Seleccionado = null;
        tablero.Size = new Size(513, 513);
        tablero.TabIndex = 1;
        tablero.TabStop = false;
        tablero.CasillaClick += tablero_CasillaClick;
        // 
        // panelAcciones
        // 
        panelAcciones.BackColor = Color.WhiteSmoke;
        panelAcciones.Controls.Add(btnMover);
        panelAcciones.Controls.Add(btnAtacar);
        panelAcciones.Controls.Add(btnCurar);
        panelAcciones.Controls.Add(btnFuria);
        panelAcciones.Controls.Add(btnAuto);
        panelAcciones.Controls.Add(btnDeshacer);
        panelAcciones.Controls.Add(btnRehacer);
        panelAcciones.Controls.Add(btnTerminar);
        panelAcciones.ForeColor = Color.Black;
        panelAcciones.Location = new Point(3, 552);
        panelAcciones.Name = "panelAcciones";
        panelAcciones.Size = new Size(520, 84);
        panelAcciones.TabIndex = 2;
        // 
        // btnMover
        // 
        btnMover.Location = new Point(3, 3);
        btnMover.Name = "btnMover";
        btnMover.Size = new Size(80, 34);
        btnMover.TabIndex = 0;
        btnMover.Text = "Mover";
        btnMover.UseVisualStyleBackColor = true;
        btnMover.Click += btnMover_Click;
        // 
        // btnAtacar
        // 
        btnAtacar.Location = new Point(89, 3);
        btnAtacar.Name = "btnAtacar";
        btnAtacar.Size = new Size(80, 34);
        btnAtacar.TabIndex = 1;
        btnAtacar.Text = "Atacar";
        btnAtacar.UseVisualStyleBackColor = true;
        btnAtacar.Click += btnAtacar_Click;
        // 
        // btnCurar
        // 
        btnCurar.Location = new Point(175, 3);
        btnCurar.Name = "btnCurar";
        btnCurar.Size = new Size(80, 34);
        btnCurar.TabIndex = 2;
        btnCurar.Text = "Curar";
        btnCurar.UseVisualStyleBackColor = true;
        btnCurar.Click += btnCurar_Click;
        // 
        // btnFuria
        // 
        btnFuria.Location = new Point(261, 3);
        btnFuria.Name = "btnFuria";
        btnFuria.Size = new Size(80, 34);
        btnFuria.TabIndex = 3;
        btnFuria.Text = "Furia";
        btnFuria.UseVisualStyleBackColor = true;
        btnFuria.Click += btnFuria_Click;
        // 
        // btnAuto
        // 
        panelAcciones.SetFlowBreak(btnAuto, true);
        btnAuto.Location = new Point(347, 3);
        btnAuto.Name = "btnAuto";
        btnAuto.Size = new Size(160, 34);
        btnAuto.TabIndex = 4;
        btnAuto.Text = "Turno automático";
        btnAuto.UseVisualStyleBackColor = true;
        btnAuto.Click += btnAuto_Click;
        // 
        // btnDeshacer
        // 
        btnDeshacer.Location = new Point(3, 43);
        btnDeshacer.Name = "btnDeshacer";
        btnDeshacer.Size = new Size(120, 34);
        btnDeshacer.TabIndex = 5;
        btnDeshacer.Text = "Deshacer";
        btnDeshacer.UseVisualStyleBackColor = true;
        btnDeshacer.Click += btnDeshacer_Click;
        // 
        // btnRehacer
        // 
        btnRehacer.Location = new Point(129, 43);
        btnRehacer.Name = "btnRehacer";
        btnRehacer.Size = new Size(120, 34);
        btnRehacer.TabIndex = 6;
        btnRehacer.Text = "Rehacer";
        btnRehacer.UseVisualStyleBackColor = true;
        btnRehacer.Click += btnRehacer_Click;
        // 
        // btnTerminar
        // 
        btnTerminar.Location = new Point(255, 43);
        btnTerminar.Name = "btnTerminar";
        btnTerminar.Size = new Size(170, 34);
        btnTerminar.TabIndex = 7;
        btnTerminar.Text = "Terminar ronda";
        btnTerminar.UseVisualStyleBackColor = true;
        btnTerminar.Click += btnTerminar_Click;
        // 
        // lblUltimoGolpe
        // 
        lblUltimoGolpe.BackColor = Color.WhiteSmoke;
        lblUltimoGolpe.Font = new Font("Segoe UI", 9.5F);
        lblUltimoGolpe.ForeColor = Color.Black;
        lblUltimoGolpe.Location = new Point(3, 639);
        lblUltimoGolpe.Name = "lblUltimoGolpe";
        lblUltimoGolpe.Size = new Size(520, 56);
        lblUltimoGolpe.TabIndex = 3;
        // 
        // lblMensaje
        // 
        lblMensaje.BackColor = Color.WhiteSmoke;
        lblMensaje.ForeColor = Color.Black;
        lblMensaje.Location = new Point(3, 695);
        lblMensaje.Name = "lblMensaje";
        lblMensaje.Size = new Size(520, 44);
        lblMensaje.TabIndex = 4;
        // 
        // tablaUnidad
        // 
        tablaUnidad.BackColor = Color.WhiteSmoke;
        tablaUnidad.ColumnCount = 1;
        tablaUnidad.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tablaUnidad.Controls.Add(grpUnidad, 0, 0);
        tablaUnidad.Controls.Add(grpDefensas, 0, 1);
        tablaUnidad.Controls.Add(grpIA, 0, 2);
        tablaUnidad.Dock = DockStyle.Fill;
        tablaUnidad.ForeColor = Color.Black;
        tablaUnidad.Location = new Point(549, 9);
        tablaUnidad.Name = "tablaUnidad";
        tablaUnidad.RowCount = 3;
        tablaUnidad.RowStyles.Add(new RowStyle(SizeType.Percent, 24F));
        tablaUnidad.RowStyles.Add(new RowStyle(SizeType.Percent, 34F));
        tablaUnidad.RowStyles.Add(new RowStyle(SizeType.Percent, 42F));
        tablaUnidad.Size = new Size(334, 754);
        tablaUnidad.TabIndex = 1;
        // 
        // grpUnidad
        // 
        grpUnidad.BackColor = Color.WhiteSmoke;
        grpUnidad.Controls.Add(flujoUnidad);
        grpUnidad.Dock = DockStyle.Fill;
        grpUnidad.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        grpUnidad.ForeColor = Color.Black;
        grpUnidad.Location = new Point(4, 4);
        grpUnidad.Margin = new Padding(4);
        grpUnidad.Name = "grpUnidad";
        grpUnidad.Padding = new Padding(8, 6, 8, 8);
        grpUnidad.Size = new Size(326, 172);
        grpUnidad.TabIndex = 0;
        grpUnidad.TabStop = false;
        grpUnidad.Text = "Unidad seleccionada";
        // 
        // flujoUnidad
        // 
        flujoUnidad.BackColor = Color.WhiteSmoke;
        flujoUnidad.Controls.Add(lblUnidadNombre);
        flujoUnidad.Controls.Add(lblUnidadVida);
        flujoUnidad.Controls.Add(lblUnidadEstado);
        flujoUnidad.Controls.Add(lblUnidadAcciones);
        flujoUnidad.Controls.Add(lblUnidadArma);
        flujoUnidad.Dock = DockStyle.Fill;
        flujoUnidad.FlowDirection = FlowDirection.TopDown;
        flujoUnidad.ForeColor = Color.Black;
        flujoUnidad.Location = new Point(8, 24);
        flujoUnidad.Name = "flujoUnidad";
        flujoUnidad.Size = new Size(310, 140);
        flujoUnidad.TabIndex = 0;
        flujoUnidad.WrapContents = false;
        // 
        // lblUnidadNombre
        // 
        lblUnidadNombre.AutoSize = true;
        lblUnidadNombre.BackColor = Color.WhiteSmoke;
        lblUnidadNombre.Font = new Font("Segoe UI", 13F);
        lblUnidadNombre.ForeColor = Color.Black;
        lblUnidadNombre.Location = new Point(3, 0);
        lblUnidadNombre.Name = "lblUnidadNombre";
        lblUnidadNombre.Size = new Size(0, 25);
        lblUnidadNombre.TabIndex = 0;
        // 
        // lblUnidadVida
        // 
        lblUnidadVida.AutoSize = true;
        lblUnidadVida.BackColor = Color.WhiteSmoke;
        lblUnidadVida.ForeColor = Color.Black;
        lblUnidadVida.Location = new Point(3, 25);
        lblUnidadVida.Name = "lblUnidadVida";
        lblUnidadVida.Size = new Size(0, 19);
        lblUnidadVida.TabIndex = 1;
        // 
        // lblUnidadEstado
        // 
        lblUnidadEstado.AutoSize = true;
        lblUnidadEstado.BackColor = Color.WhiteSmoke;
        lblUnidadEstado.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblUnidadEstado.ForeColor = Color.Black;
        lblUnidadEstado.Location = new Point(3, 44);
        lblUnidadEstado.Name = "lblUnidadEstado";
        lblUnidadEstado.Size = new Size(0, 19);
        lblUnidadEstado.TabIndex = 2;
        // 
        // lblUnidadAcciones
        // 
        lblUnidadAcciones.AutoSize = true;
        lblUnidadAcciones.BackColor = Color.WhiteSmoke;
        lblUnidadAcciones.ForeColor = Color.DimGray;
        lblUnidadAcciones.Location = new Point(3, 63);
        lblUnidadAcciones.Name = "lblUnidadAcciones";
        lblUnidadAcciones.Size = new Size(0, 19);
        lblUnidadAcciones.TabIndex = 3;
        // 
        // lblUnidadArma
        // 
        lblUnidadArma.AutoSize = true;
        lblUnidadArma.BackColor = Color.WhiteSmoke;
        lblUnidadArma.ForeColor = Color.DimGray;
        lblUnidadArma.Location = new Point(3, 82);
        lblUnidadArma.Name = "lblUnidadArma";
        lblUnidadArma.Size = new Size(0, 19);
        lblUnidadArma.TabIndex = 4;
        // 
        // grpDefensas
        // 
        grpDefensas.BackColor = Color.WhiteSmoke;
        grpDefensas.Controls.Add(panelDefensas);
        grpDefensas.Dock = DockStyle.Fill;
        grpDefensas.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        grpDefensas.ForeColor = Color.Black;
        grpDefensas.Location = new Point(4, 184);
        grpDefensas.Margin = new Padding(4);
        grpDefensas.Name = "grpDefensas";
        grpDefensas.Padding = new Padding(8, 6, 8, 8);
        grpDefensas.Size = new Size(326, 248);
        grpDefensas.TabIndex = 1;
        grpDefensas.TabStop = false;
        grpDefensas.Text = "Cadena de defensas (el golpe pasa de arriba hacia abajo)";
        // 
        // panelDefensas
        // 
        panelDefensas.BackColor = Color.WhiteSmoke;
        panelDefensas.Controls.Add(lstDefensas);
        panelDefensas.Controls.Add(panelCadena);
        panelDefensas.Dock = DockStyle.Fill;
        panelDefensas.ForeColor = Color.Black;
        panelDefensas.Location = new Point(8, 24);
        panelDefensas.Name = "panelDefensas";
        panelDefensas.Size = new Size(310, 216);
        panelDefensas.TabIndex = 0;
        // 
        // lstDefensas
        // 
        lstDefensas.BackColor = Color.White;
        lstDefensas.BorderStyle = BorderStyle.FixedSingle;
        lstDefensas.Dock = DockStyle.Fill;
        lstDefensas.Font = new Font("Segoe UI", 9.5F);
        lstDefensas.ForeColor = Color.Black;
        lstDefensas.FormattingEnabled = true;
        lstDefensas.IntegralHeight = false;
        lstDefensas.ItemHeight = 17;
        lstDefensas.Location = new Point(0, 0);
        lstDefensas.Name = "lstDefensas";
        lstDefensas.Size = new Size(310, 136);
        lstDefensas.TabIndex = 0;
        // 
        // panelCadena
        // 
        panelCadena.BackColor = Color.WhiteSmoke;
        panelCadena.Controls.Add(btnCapaSubir);
        panelCadena.Controls.Add(btnCapaBajar);
        panelCadena.Controls.Add(btnCapaQuitar);
        panelCadena.Controls.Add(cboNuevaCapa);
        panelCadena.Controls.Add(btnCapaAgregar);
        panelCadena.Dock = DockStyle.Bottom;
        panelCadena.ForeColor = Color.Black;
        panelCadena.Location = new Point(0, 136);
        panelCadena.Name = "panelCadena";
        panelCadena.Size = new Size(310, 80);
        panelCadena.TabIndex = 1;
        // 
        // btnCapaSubir
        // 
        btnCapaSubir.Location = new Point(3, 3);
        btnCapaSubir.Name = "btnCapaSubir";
        btnCapaSubir.Size = new Size(64, 34);
        btnCapaSubir.TabIndex = 0;
        btnCapaSubir.Text = "Subir";
        btnCapaSubir.UseVisualStyleBackColor = true;
        btnCapaSubir.Click += btnCapaSubir_Click;
        // 
        // btnCapaBajar
        // 
        btnCapaBajar.Location = new Point(73, 3);
        btnCapaBajar.Name = "btnCapaBajar";
        btnCapaBajar.Size = new Size(64, 34);
        btnCapaBajar.TabIndex = 1;
        btnCapaBajar.Text = "Bajar";
        btnCapaBajar.UseVisualStyleBackColor = true;
        btnCapaBajar.Click += btnCapaBajar_Click;
        // 
        // btnCapaQuitar
        // 
        btnCapaQuitar.Location = new Point(143, 3);
        btnCapaQuitar.Name = "btnCapaQuitar";
        btnCapaQuitar.Size = new Size(70, 34);
        btnCapaQuitar.TabIndex = 2;
        btnCapaQuitar.Text = "Quitar";
        btnCapaQuitar.UseVisualStyleBackColor = true;
        btnCapaQuitar.Click += btnCapaQuitar_Click;
        // 
        // cboNuevaCapa
        // 
        cboNuevaCapa.BackColor = Color.White;
        cboNuevaCapa.DropDownStyle = ComboBoxStyle.DropDownList;
        cboNuevaCapa.ForeColor = Color.Black;
        cboNuevaCapa.FormattingEnabled = true;
        cboNuevaCapa.Items.AddRange(new object[] { "Esquiva", "Bloqueo", "Armadura", "Escudo" });
        cboNuevaCapa.Location = new Point(3, 43);
        cboNuevaCapa.Name = "cboNuevaCapa";
        cboNuevaCapa.Size = new Size(100, 25);
        cboNuevaCapa.TabIndex = 3;
        // 
        // btnCapaAgregar
        // 
        btnCapaAgregar.Location = new Point(109, 43);
        btnCapaAgregar.Name = "btnCapaAgregar";
        btnCapaAgregar.Size = new Size(80, 34);
        btnCapaAgregar.TabIndex = 4;
        btnCapaAgregar.Text = "Agregar";
        btnCapaAgregar.UseVisualStyleBackColor = true;
        btnCapaAgregar.Click += btnCapaAgregar_Click;
        // 
        // grpIA
        // 
        grpIA.BackColor = Color.WhiteSmoke;
        grpIA.Controls.Add(panelIA);
        grpIA.Dock = DockStyle.Fill;
        grpIA.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        grpIA.ForeColor = Color.Black;
        grpIA.Location = new Point(4, 440);
        grpIA.Margin = new Padding(4);
        grpIA.Name = "grpIA";
        grpIA.Padding = new Padding(8, 6, 8, 8);
        grpIA.Size = new Size(326, 310);
        grpIA.TabIndex = 2;
        grpIA.TabStop = false;
        grpIA.Text = "IA del enemigo (Strategy)";
        // 
        // panelIA
        // 
        panelIA.BackColor = Color.WhiteSmoke;
        panelIA.Controls.Add(lstComparacion);
        panelIA.Controls.Add(lblIaUltima);
        panelIA.Controls.Add(lblIaIntencion);
        panelIA.Controls.Add(panelCambioIA);
        panelIA.Dock = DockStyle.Fill;
        panelIA.ForeColor = Color.Black;
        panelIA.Location = new Point(8, 24);
        panelIA.Name = "panelIA";
        panelIA.Size = new Size(310, 278);
        panelIA.TabIndex = 0;
        // 
        // lstComparacion
        // 
        lstComparacion.BackColor = Color.White;
        lstComparacion.BorderStyle = BorderStyle.FixedSingle;
        lstComparacion.Dock = DockStyle.Fill;
        lstComparacion.Font = new Font("Segoe UI", 9.5F);
        lstComparacion.ForeColor = Color.Black;
        lstComparacion.FormattingEnabled = true;
        lstComparacion.HorizontalScrollbar = true;
        lstComparacion.IntegralHeight = false;
        lstComparacion.ItemHeight = 17;
        lstComparacion.Location = new Point(0, 132);
        lstComparacion.Name = "lstComparacion";
        lstComparacion.Size = new Size(310, 146);
        lstComparacion.TabIndex = 0;
        // 
        // lblIaUltima
        // 
        lblIaUltima.BackColor = Color.WhiteSmoke;
        lblIaUltima.Dock = DockStyle.Top;
        lblIaUltima.Font = new Font("Segoe UI", 9F);
        lblIaUltima.ForeColor = Color.DimGray;
        lblIaUltima.Location = new Point(0, 88);
        lblIaUltima.Name = "lblIaUltima";
        lblIaUltima.Size = new Size(310, 44);
        lblIaUltima.TabIndex = 1;
        // 
        // lblIaIntencion
        // 
        lblIaIntencion.BackColor = Color.WhiteSmoke;
        lblIaIntencion.Dock = DockStyle.Top;
        lblIaIntencion.ForeColor = Color.Black;
        lblIaIntencion.Location = new Point(0, 44);
        lblIaIntencion.Name = "lblIaIntencion";
        lblIaIntencion.Size = new Size(310, 44);
        lblIaIntencion.TabIndex = 2;
        // 
        // panelCambioIA
        // 
        panelCambioIA.BackColor = Color.WhiteSmoke;
        panelCambioIA.Controls.Add(cboEstrategia);
        panelCambioIA.Controls.Add(btnCambiarIA);
        panelCambioIA.Dock = DockStyle.Top;
        panelCambioIA.ForeColor = Color.Black;
        panelCambioIA.Location = new Point(0, 0);
        panelCambioIA.Name = "panelCambioIA";
        panelCambioIA.Size = new Size(310, 44);
        panelCambioIA.TabIndex = 3;
        // 
        // cboEstrategia
        // 
        cboEstrategia.BackColor = Color.White;
        cboEstrategia.DropDownStyle = ComboBoxStyle.DropDownList;
        cboEstrategia.ForeColor = Color.Black;
        cboEstrategia.FormattingEnabled = true;
        cboEstrategia.Location = new Point(3, 3);
        cboEstrategia.Name = "cboEstrategia";
        cboEstrategia.Size = new Size(140, 25);
        cboEstrategia.TabIndex = 0;
        // 
        // btnCambiarIA
        // 
        btnCambiarIA.Location = new Point(149, 3);
        btnCambiarIA.Name = "btnCambiarIA";
        btnCambiarIA.Size = new Size(100, 34);
        btnCambiarIA.TabIndex = 1;
        btnCambiarIA.Text = "Cambiar IA";
        btnCambiarIA.UseVisualStyleBackColor = true;
        btnCambiarIA.Click += btnCambiarIA_Click;
        // 
        // tablaInfo
        // 
        tablaInfo.BackColor = Color.WhiteSmoke;
        tablaInfo.ColumnCount = 1;
        tablaInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tablaInfo.Controls.Add(grpInventario, 0, 0);
        tablaInfo.Controls.Add(grpHistorial, 0, 1);
        tablaInfo.Controls.Add(grpBitacora, 0, 2);
        tablaInfo.Dock = DockStyle.Fill;
        tablaInfo.ForeColor = Color.Black;
        tablaInfo.Location = new Point(889, 9);
        tablaInfo.Name = "tablaInfo";
        tablaInfo.RowCount = 3;
        tablaInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
        tablaInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        tablaInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
        tablaInfo.Size = new Size(462, 754);
        tablaInfo.TabIndex = 2;
        // 
        // grpInventario
        // 
        grpInventario.BackColor = Color.WhiteSmoke;
        grpInventario.Controls.Add(panelInventario);
        grpInventario.Dock = DockStyle.Fill;
        grpInventario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        grpInventario.ForeColor = Color.Black;
        grpInventario.Location = new Point(4, 4);
        grpInventario.Margin = new Padding(4);
        grpInventario.Name = "grpInventario";
        grpInventario.Padding = new Padding(8, 6, 8, 8);
        grpInventario.Size = new Size(454, 218);
        grpInventario.TabIndex = 0;
        grpInventario.TabStop = false;
        grpInventario.Text = "Inventario (Visitor)";
        // 
        // panelInventario
        // 
        panelInventario.BackColor = Color.WhiteSmoke;
        panelInventario.Controls.Add(txtVisitante);
        panelInventario.Controls.Add(panelVisitante);
        panelInventario.Dock = DockStyle.Fill;
        panelInventario.ForeColor = Color.Black;
        panelInventario.Location = new Point(8, 24);
        panelInventario.Name = "panelInventario";
        panelInventario.Size = new Size(438, 186);
        panelInventario.TabIndex = 0;
        // 
        // txtVisitante
        // 
        txtVisitante.BackColor = Color.White;
        txtVisitante.BorderStyle = BorderStyle.FixedSingle;
        txtVisitante.Dock = DockStyle.Fill;
        txtVisitante.Font = new Font("Segoe UI", 9.5F);
        txtVisitante.ForeColor = Color.Black;
        txtVisitante.Location = new Point(0, 44);
        txtVisitante.Multiline = true;
        txtVisitante.Name = "txtVisitante";
        txtVisitante.ReadOnly = true;
        txtVisitante.ScrollBars = ScrollBars.Vertical;
        txtVisitante.Size = new Size(438, 142);
        txtVisitante.TabIndex = 0;
        // 
        // panelVisitante
        // 
        panelVisitante.BackColor = Color.WhiteSmoke;
        panelVisitante.Controls.Add(cboVisitante);
        panelVisitante.Controls.Add(btnAplicarVisitante);
        panelVisitante.Dock = DockStyle.Top;
        panelVisitante.ForeColor = Color.Black;
        panelVisitante.Location = new Point(0, 0);
        panelVisitante.Name = "panelVisitante";
        panelVisitante.Size = new Size(438, 44);
        panelVisitante.TabIndex = 1;
        // 
        // cboVisitante
        // 
        cboVisitante.BackColor = Color.White;
        cboVisitante.DropDownStyle = ComboBoxStyle.DropDownList;
        cboVisitante.ForeColor = Color.Black;
        cboVisitante.FormattingEnabled = true;
        cboVisitante.Items.AddRange(new object[] { "Calculador de precio", "Contador de armas", "Aplicador de veneno", "Generador de estadísticas" });
        cboVisitante.Location = new Point(3, 3);
        cboVisitante.Name = "cboVisitante";
        cboVisitante.Size = new Size(200, 25);
        cboVisitante.TabIndex = 0;
        // 
        // btnAplicarVisitante
        // 
        btnAplicarVisitante.Location = new Point(209, 3);
        btnAplicarVisitante.Name = "btnAplicarVisitante";
        btnAplicarVisitante.Size = new Size(90, 34);
        btnAplicarVisitante.TabIndex = 1;
        btnAplicarVisitante.Text = "Aplicar";
        btnAplicarVisitante.UseVisualStyleBackColor = true;
        btnAplicarVisitante.Click += btnAplicarVisitante_Click;
        // 
        // grpHistorial
        // 
        grpHistorial.BackColor = Color.WhiteSmoke;
        grpHistorial.Controls.Add(lstHistorial);
        grpHistorial.Dock = DockStyle.Fill;
        grpHistorial.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        grpHistorial.ForeColor = Color.Black;
        grpHistorial.Location = new Point(4, 230);
        grpHistorial.Margin = new Padding(4);
        grpHistorial.Name = "grpHistorial";
        grpHistorial.Padding = new Padding(8, 6, 8, 8);
        grpHistorial.Size = new Size(454, 180);
        grpHistorial.TabIndex = 1;
        grpHistorial.TabStop = false;
        grpHistorial.Text = "Historial de comandos (Command)";
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
        lstHistorial.Size = new Size(438, 148);
        lstHistorial.TabIndex = 0;
        // 
        // grpBitacora
        // 
        grpBitacora.BackColor = Color.WhiteSmoke;
        grpBitacora.Controls.Add(lstBitacora);
        grpBitacora.Dock = DockStyle.Fill;
        grpBitacora.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        grpBitacora.ForeColor = Color.Black;
        grpBitacora.Location = new Point(4, 418);
        grpBitacora.Margin = new Padding(4);
        grpBitacora.Name = "grpBitacora";
        grpBitacora.Padding = new Padding(8, 6, 8, 8);
        grpBitacora.Size = new Size(454, 332);
        grpBitacora.TabIndex = 2;
        grpBitacora.TabStop = false;
        grpBitacora.Text = "Bitácora: turnos (Template Method) y decisiones de la IA";
        // 
        // lstBitacora
        // 
        lstBitacora.BackColor = Color.White;
        lstBitacora.BorderStyle = BorderStyle.FixedSingle;
        lstBitacora.Dock = DockStyle.Fill;
        lstBitacora.Font = new Font("Segoe UI", 9.5F);
        lstBitacora.ForeColor = Color.Black;
        lstBitacora.FormattingEnabled = true;
        lstBitacora.HorizontalScrollbar = true;
        lstBitacora.IntegralHeight = false;
        lstBitacora.ItemHeight = 17;
        lstBitacora.Location = new Point(8, 24);
        lstBitacora.Name = "lstBitacora";
        lstBitacora.Size = new Size(438, 300);
        lstBitacora.TabIndex = 0;
        // 
        // lblAviso
        // 
        lblAviso.BackColor = Color.WhiteSmoke;
        lblAviso.Dock = DockStyle.Top;
        lblAviso.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblAviso.ForeColor = Color.Black;
        lblAviso.Location = new Point(0, 0);
        lblAviso.Name = "lblAviso";
        lblAviso.Size = new Size(1360, 28);
        lblAviso.TabIndex = 1;
        lblAviso.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // FormCombate
        // 
        AutoScaleDimensions = new SizeF(7F, 17F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.WhiteSmoke;
        ClientSize = new Size(1360, 800);
        Controls.Add(tablaRaiz);
        Controls.Add(lblAviso);
        Font = new Font("Segoe UI", 10F);
        ForeColor = Color.Black;
        MinimumSize = new Size(1280, 780);
        Name = "FormCombate";
        StartPosition = FormStartPosition.CenterParent;
        Text = "KEPLER-7 — Combate";
        FormClosing += FormCombate_FormClosing;
        FormClosed += FormCombate_FormClosed;
        tablaRaiz.ResumeLayout(false);
        flujoTablero.ResumeLayout(false);
        panelAcciones.ResumeLayout(false);
        tablaUnidad.ResumeLayout(false);
        grpUnidad.ResumeLayout(false);
        flujoUnidad.ResumeLayout(false);
        flujoUnidad.PerformLayout();
        grpDefensas.ResumeLayout(false);
        panelDefensas.ResumeLayout(false);
        panelCadena.ResumeLayout(false);
        grpIA.ResumeLayout(false);
        panelIA.ResumeLayout(false);
        panelCambioIA.ResumeLayout(false);
        tablaInfo.ResumeLayout(false);
        grpInventario.ResumeLayout(false);
        panelInventario.ResumeLayout(false);
        panelInventario.PerformLayout();
        panelVisitante.ResumeLayout(false);
        grpHistorial.ResumeLayout(false);
        grpBitacora.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private TableLayoutPanel tablaRaiz = null!;
    private FlowLayoutPanel flujoTablero = null!;
    private Label lblHud = null!;
    private Kepler7.Game.Controles.TableroControl tablero = null!;
    private FlowLayoutPanel panelAcciones = null!;
    private Button btnMover = null!;
    private Button btnAtacar = null!;
    private Button btnCurar = null!;
    private Button btnFuria = null!;
    private Button btnAuto = null!;
    private Button btnDeshacer = null!;
    private Button btnRehacer = null!;
    private Button btnTerminar = null!;
    private Label lblUltimoGolpe = null!;
    private Label lblMensaje = null!;
    private TableLayoutPanel tablaUnidad = null!;
    private GroupBox grpUnidad = null!;
    private FlowLayoutPanel flujoUnidad = null!;
    private Label lblUnidadNombre = null!;
    private Label lblUnidadVida = null!;
    private Label lblUnidadEstado = null!;
    private Label lblUnidadAcciones = null!;
    private Label lblUnidadArma = null!;
    private GroupBox grpDefensas = null!;
    private Panel panelDefensas = null!;
    private ListBox lstDefensas = null!;
    private FlowLayoutPanel panelCadena = null!;
    private Button btnCapaSubir = null!;
    private Button btnCapaBajar = null!;
    private Button btnCapaQuitar = null!;
    private ComboBox cboNuevaCapa = null!;
    private Button btnCapaAgregar = null!;
    private GroupBox grpIA = null!;
    private Panel panelIA = null!;
    private ListBox lstComparacion = null!;
    private Label lblIaUltima = null!;
    private Label lblIaIntencion = null!;
    private FlowLayoutPanel panelCambioIA = null!;
    private ComboBox cboEstrategia = null!;
    private Button btnCambiarIA = null!;
    private TableLayoutPanel tablaInfo = null!;
    private GroupBox grpInventario = null!;
    private Panel panelInventario = null!;
    private TextBox txtVisitante = null!;
    private FlowLayoutPanel panelVisitante = null!;
    private ComboBox cboVisitante = null!;
    private Button btnAplicarVisitante = null!;
    private GroupBox grpHistorial = null!;
    private ListBox lstHistorial = null!;
    private GroupBox grpBitacora = null!;
    private ListBox lstBitacora = null!;
    private Label lblAviso = null!;
}
