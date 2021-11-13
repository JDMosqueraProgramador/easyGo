
namespace wEasyGoDriver.views
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.cerrarForm = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabsMain = new System.Windows.Forms.TabControl();
            this.tabMainInicio = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.lblEstadoMoto = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFechaSoat = new System.Windows.Forms.Label();
            this.lblSoat = new System.Windows.Forms.Label();
            this.lblFechaTecnomecanica = new System.Windows.Forms.Label();
            this.lblTecnomecanica = new System.Windows.Forms.Label();
            this.lblFechaLicencia = new System.Windows.Forms.Label();
            this.lblLicencia = new System.Windows.Forms.Label();
            this.lblVencimiento = new System.Windows.Forms.Label();
            this.btnEstado = new System.Windows.Forms.Button();
            this.lblTituloMain = new System.Windows.Forms.Label();
            this.tabMainViajes = new System.Windows.Forms.TabPage();
            this.btnEnfocarPosicion = new System.Windows.Forms.Button();
            this.flpViajes = new System.Windows.Forms.FlowLayoutPanel();
            this.lblAvisoViajes = new System.Windows.Forms.Label();
            this.pnlViajeAceptado = new System.Windows.Forms.Panel();
            this.btnTerminarViaje = new System.Windows.Forms.Button();
            this.btnEnInicioAceptado = new System.Windows.Forms.Button();
            this.lblDistanciaInicioAceptado = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblTelefonoAceptado = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblNombreAceptado = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblEstadoViajeAceptado = new System.Windows.Forms.Label();
            this.lblEstadoAceptado = new System.Windows.Forms.Label();
            this.btnCancelarAceptado = new System.Windows.Forms.Button();
            this.btnViajeAceptado = new System.Windows.Forms.Button();
            this.lblPrecioAceptado = new System.Windows.Forms.Label();
            this.lblDestinoAceptado = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblInicioAceptado = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblTitleViajeAceptado = new System.Windows.Forms.Label();
            this.gMapPrincipal = new GMap.NET.WindowsForms.GMapControl();
            this.tabMainHistorial = new System.Windows.Forms.TabPage();
            this.lblTituloHistorial = new System.Windows.Forms.Label();
            this.dtgHistorialViajes = new System.Windows.Forms.DataGridView();
            this.notifyViaje = new System.Windows.Forms.NotifyIcon(this.components);
            this.pnlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cerrarForm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).BeginInit();
            this.tabsMain.SuspendLayout();
            this.tabMainInicio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabMainViajes.SuspendLayout();
            this.flpViajes.SuspendLayout();
            this.pnlViajeAceptado.SuspendLayout();
            this.tabMainHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistorialViajes)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(156)))));
            this.pnlTitulo.Controls.Add(this.cerrarForm);
            this.pnlTitulo.Controls.Add(this.btnCerrar);
            this.pnlTitulo.Controls.Add(this.lblTitle);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(1011, 60);
            this.pnlTitulo.TabIndex = 2;
            // 
            // cerrarForm
            // 
            this.cerrarForm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cerrarForm.Image = global::wEasyGoDriver.Properties.Resources.CerrarForm;
            this.cerrarForm.Location = new System.Drawing.Point(953, 14);
            this.cerrarForm.Name = "cerrarForm";
            this.cerrarForm.Size = new System.Drawing.Size(43, 25);
            this.cerrarForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cerrarForm.TabIndex = 48;
            this.cerrarForm.TabStop = false;
            this.cerrarForm.Click += new System.EventHandler(this.cerrarForm_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.Image = global::wEasyGoDriver.Properties.Resources.CerrarForm;
            this.btnCerrar.Location = new System.Drawing.Point(886, 14);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(43, 25);
            this.btnCerrar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnCerrar.TabIndex = 47;
            this.btnCerrar.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(467, 21);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(53, 18);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Home";
            // 
            // tabsMain
            // 
            this.tabsMain.Controls.Add(this.tabMainInicio);
            this.tabsMain.Controls.Add(this.tabMainViajes);
            this.tabsMain.Controls.Add(this.tabMainHistorial);
            this.tabsMain.Location = new System.Drawing.Point(0, 66);
            this.tabsMain.Name = "tabsMain";
            this.tabsMain.SelectedIndex = 0;
            this.tabsMain.Size = new System.Drawing.Size(1011, 445);
            this.tabsMain.TabIndex = 4;
            // 
            // tabMainInicio
            // 
            this.tabMainInicio.Controls.Add(this.button1);
            this.tabMainInicio.Controls.Add(this.lblEstadoMoto);
            this.tabMainInicio.Controls.Add(this.pictureBox1);
            this.tabMainInicio.Controls.Add(this.label2);
            this.tabMainInicio.Controls.Add(this.label1);
            this.tabMainInicio.Controls.Add(this.lblFechaSoat);
            this.tabMainInicio.Controls.Add(this.lblSoat);
            this.tabMainInicio.Controls.Add(this.lblFechaTecnomecanica);
            this.tabMainInicio.Controls.Add(this.lblTecnomecanica);
            this.tabMainInicio.Controls.Add(this.lblFechaLicencia);
            this.tabMainInicio.Controls.Add(this.lblLicencia);
            this.tabMainInicio.Controls.Add(this.lblVencimiento);
            this.tabMainInicio.Controls.Add(this.btnEstado);
            this.tabMainInicio.Controls.Add(this.lblTituloMain);
            this.tabMainInicio.Location = new System.Drawing.Point(4, 22);
            this.tabMainInicio.Name = "tabMainInicio";
            this.tabMainInicio.Padding = new System.Windows.Forms.Padding(3);
            this.tabMainInicio.Size = new System.Drawing.Size(1003, 419);
            this.tabMainInicio.TabIndex = 0;
            this.tabMainInicio.Text = "Inicio";
            this.tabMainInicio.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.button1.Location = new System.Drawing.Point(643, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(208, 45);
            this.button1.TabIndex = 14;
            this.button1.Text = "ver mi perfil";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lblEstadoMoto
            // 
            this.lblEstadoMoto.AutoSize = true;
            this.lblEstadoMoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoMoto.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblEstadoMoto.Location = new System.Drawing.Point(593, 334);
            this.lblEstadoMoto.Name = "lblEstadoMoto";
            this.lblEstadoMoto.Size = new System.Drawing.Size(38, 16);
            this.lblEstadoMoto.TabIndex = 13;
            this.lblEstadoMoto.Text = "valor";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::wEasyGoDriver.Properties.Resources.biker_iStock_1575255671;
            this.pictureBox1.Location = new System.Drawing.Point(-4, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(507, 419);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Location = new System.Drawing.Point(538, 334);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Estado:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(320, 275);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 10;
            // 
            // lblFechaSoat
            // 
            this.lblFechaSoat.AutoSize = true;
            this.lblFechaSoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaSoat.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblFechaSoat.Location = new System.Drawing.Point(583, 305);
            this.lblFechaSoat.Name = "lblFechaSoat";
            this.lblFechaSoat.Size = new System.Drawing.Size(97, 16);
            this.lblFechaSoat.TabIndex = 8;
            this.lblFechaSoat.Text = "Fecha del soat";
            // 
            // lblSoat
            // 
            this.lblSoat.AutoSize = true;
            this.lblSoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoat.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblSoat.Location = new System.Drawing.Point(538, 305);
            this.lblSoat.Name = "lblSoat";
            this.lblSoat.Size = new System.Drawing.Size(39, 16);
            this.lblSoat.TabIndex = 7;
            this.lblSoat.Text = "Soat:";
            // 
            // lblFechaTecnomecanica
            // 
            this.lblFechaTecnomecanica.AutoSize = true;
            this.lblFechaTecnomecanica.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaTecnomecanica.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblFechaTecnomecanica.Location = new System.Drawing.Point(653, 272);
            this.lblFechaTecnomecanica.Name = "lblFechaTecnomecanica";
            this.lblFechaTecnomecanica.Size = new System.Drawing.Size(163, 16);
            this.lblFechaTecnomecanica.TabIndex = 6;
            this.lblFechaTecnomecanica.Text = "Fecha de tecnomecánica ";
            // 
            // lblTecnomecanica
            // 
            this.lblTecnomecanica.AutoSize = true;
            this.lblTecnomecanica.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTecnomecanica.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblTecnomecanica.Location = new System.Drawing.Point(538, 272);
            this.lblTecnomecanica.Name = "lblTecnomecanica";
            this.lblTecnomecanica.Size = new System.Drawing.Size(109, 16);
            this.lblTecnomecanica.TabIndex = 5;
            this.lblTecnomecanica.Text = "Tecnomecánica:";
            // 
            // lblFechaLicencia
            // 
            this.lblFechaLicencia.AutoSize = true;
            this.lblFechaLicencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaLicencia.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblFechaLicencia.Location = new System.Drawing.Point(605, 239);
            this.lblFechaLicencia.Name = "lblFechaLicencia";
            this.lblFechaLicencia.Size = new System.Drawing.Size(128, 16);
            this.lblFechaLicencia.TabIndex = 4;
            this.lblFechaLicencia.Text = "Fecha de la licencia";
            // 
            // lblLicencia
            // 
            this.lblLicencia.AutoSize = true;
            this.lblLicencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicencia.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblLicencia.Location = new System.Drawing.Point(538, 239);
            this.lblLicencia.Name = "lblLicencia";
            this.lblLicencia.Size = new System.Drawing.Size(61, 16);
            this.lblLicencia.TabIndex = 3;
            this.lblLicencia.Text = "Licencia:";
            // 
            // lblVencimiento
            // 
            this.lblVencimiento.AutoSize = true;
            this.lblVencimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVencimiento.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblVencimiento.Location = new System.Drawing.Point(537, 200);
            this.lblVencimiento.Name = "lblVencimiento";
            this.lblVencimiento.Size = new System.Drawing.Size(201, 20);
            this.lblVencimiento.TabIndex = 2;
            this.lblVencimiento.Text = "Vencimiento de papeles";
            // 
            // btnEstado
            // 
            this.btnEstado.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.btnEstado.Location = new System.Drawing.Point(643, 79);
            this.btnEstado.Name = "btnEstado";
            this.btnEstado.Size = new System.Drawing.Size(208, 45);
            this.btnEstado.TabIndex = 1;
            this.btnEstado.Text = "Iniciar jornada";
            this.btnEstado.UseVisualStyleBackColor = true;
            this.btnEstado.Click += new System.EventHandler(this.btnEstado_Click);
            // 
            // lblTituloMain
            // 
            this.lblTituloMain.AutoSize = true;
            this.lblTituloMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloMain.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblTituloMain.Location = new System.Drawing.Point(518, 28);
            this.lblTituloMain.Name = "lblTituloMain";
            this.lblTituloMain.Size = new System.Drawing.Size(455, 24);
            this.lblTituloMain.TabIndex = 0;
            this.lblTituloMain.Text = "¿Estás listo para viajar? ¡los clientes te esperan!";
            // 
            // tabMainViajes
            // 
            this.tabMainViajes.Controls.Add(this.btnEnfocarPosicion);
            this.tabMainViajes.Controls.Add(this.flpViajes);
            this.tabMainViajes.Controls.Add(this.gMapPrincipal);
            this.tabMainViajes.Location = new System.Drawing.Point(4, 22);
            this.tabMainViajes.Name = "tabMainViajes";
            this.tabMainViajes.Padding = new System.Windows.Forms.Padding(3);
            this.tabMainViajes.Size = new System.Drawing.Size(1003, 419);
            this.tabMainViajes.TabIndex = 1;
            this.tabMainViajes.Text = "Viajes";
            this.tabMainViajes.UseVisualStyleBackColor = true;
            // 
            // btnEnfocarPosicion
            // 
            this.btnEnfocarPosicion.Location = new System.Drawing.Point(525, 389);
            this.btnEnfocarPosicion.Name = "btnEnfocarPosicion";
            this.btnEnfocarPosicion.Size = new System.Drawing.Size(140, 23);
            this.btnEnfocarPosicion.TabIndex = 3;
            this.btnEnfocarPosicion.Text = "Enfocar posición actual";
            this.btnEnfocarPosicion.UseVisualStyleBackColor = true;
            this.btnEnfocarPosicion.Click += new System.EventHandler(this.btnEnfocarPosicion_Click);
            // 
            // flpViajes
            // 
            this.flpViajes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpViajes.AutoScroll = true;
            this.flpViajes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpViajes.Controls.Add(this.lblAvisoViajes);
            this.flpViajes.Controls.Add(this.pnlViajeAceptado);
            this.flpViajes.Location = new System.Drawing.Point(671, 6);
            this.flpViajes.Name = "flpViajes";
            this.flpViajes.Size = new System.Drawing.Size(324, 406);
            this.flpViajes.TabIndex = 2;
            this.flpViajes.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.flpViajes_ControlRemoved);
            // 
            // lblAvisoViajes
            // 
            this.lblAvisoViajes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAvisoViajes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAvisoViajes.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblAvisoViajes.Location = new System.Drawing.Point(3, 0);
            this.lblAvisoViajes.Name = "lblAvisoViajes";
            this.lblAvisoViajes.Size = new System.Drawing.Size(318, 45);
            this.lblAvisoViajes.TabIndex = 2;
            this.lblAvisoViajes.Text = "Aquí aparecerán las solicitudes de viajes";
            this.lblAvisoViajes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlViajeAceptado
            // 
            this.pnlViajeAceptado.Controls.Add(this.btnTerminarViaje);
            this.pnlViajeAceptado.Controls.Add(this.btnEnInicioAceptado);
            this.pnlViajeAceptado.Controls.Add(this.lblDistanciaInicioAceptado);
            this.pnlViajeAceptado.Controls.Add(this.label8);
            this.pnlViajeAceptado.Controls.Add(this.lblTelefonoAceptado);
            this.pnlViajeAceptado.Controls.Add(this.label11);
            this.pnlViajeAceptado.Controls.Add(this.lblNombreAceptado);
            this.pnlViajeAceptado.Controls.Add(this.label9);
            this.pnlViajeAceptado.Controls.Add(this.lblEstadoViajeAceptado);
            this.pnlViajeAceptado.Controls.Add(this.lblEstadoAceptado);
            this.pnlViajeAceptado.Controls.Add(this.btnCancelarAceptado);
            this.pnlViajeAceptado.Controls.Add(this.btnViajeAceptado);
            this.pnlViajeAceptado.Controls.Add(this.lblPrecioAceptado);
            this.pnlViajeAceptado.Controls.Add(this.lblDestinoAceptado);
            this.pnlViajeAceptado.Controls.Add(this.label10);
            this.pnlViajeAceptado.Controls.Add(this.lblInicioAceptado);
            this.pnlViajeAceptado.Controls.Add(this.label12);
            this.pnlViajeAceptado.Controls.Add(this.lblTitleViajeAceptado);
            this.pnlViajeAceptado.Location = new System.Drawing.Point(3, 48);
            this.pnlViajeAceptado.Name = "pnlViajeAceptado";
            this.pnlViajeAceptado.Size = new System.Drawing.Size(318, 287);
            this.pnlViajeAceptado.TabIndex = 3;
            // 
            // btnTerminarViaje
            // 
            this.btnTerminarViaje.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.btnTerminarViaje.Location = new System.Drawing.Point(13, 248);
            this.btnTerminarViaje.Name = "btnTerminarViaje";
            this.btnTerminarViaje.Size = new System.Drawing.Size(288, 23);
            this.btnTerminarViaje.TabIndex = 18;
            this.btnTerminarViaje.Text = "Terminar viaje";
            this.btnTerminarViaje.UseVisualStyleBackColor = true;
            this.btnTerminarViaje.Click += new System.EventHandler(this.btnTerminarViaje_Click);
            // 
            // btnEnInicioAceptado
            // 
            this.btnEnInicioAceptado.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.btnEnInicioAceptado.Location = new System.Drawing.Point(13, 219);
            this.btnEnInicioAceptado.Name = "btnEnInicioAceptado";
            this.btnEnInicioAceptado.Size = new System.Drawing.Size(172, 23);
            this.btnEnInicioAceptado.TabIndex = 17;
            this.btnEnInicioAceptado.Text = "En el lugar de inicio";
            this.btnEnInicioAceptado.UseVisualStyleBackColor = true;
            this.btnEnInicioAceptado.Click += new System.EventHandler(this.btnEnInicioAceptado_Click);
            // 
            // lblDistanciaInicioAceptado
            // 
            this.lblDistanciaInicioAceptado.AutoSize = true;
            this.lblDistanciaInicioAceptado.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblDistanciaInicioAceptado.Location = new System.Drawing.Point(153, 159);
            this.lblDistanciaInicioAceptado.Name = "lblDistanciaInicioAceptado";
            this.lblDistanciaInicioAceptado.Size = new System.Drawing.Size(93, 13);
            this.lblDistanciaInicioAceptado.TabIndex = 16;
            this.lblDistanciaInicioAceptado.Text = "Número en metros";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label8.Location = new System.Drawing.Point(10, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Distancia de lugar de inicio:";
            // 
            // lblTelefonoAceptado
            // 
            this.lblTelefonoAceptado.AutoSize = true;
            this.lblTelefonoAceptado.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblTelefonoAceptado.Location = new System.Drawing.Point(75, 135);
            this.lblTelefonoAceptado.Name = "lblTelefonoAceptado";
            this.lblTelefonoAceptado.Size = new System.Drawing.Size(54, 13);
            this.lblTelefonoAceptado.TabIndex = 14;
            this.lblTelefonoAceptado.Text = "Cellphone";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label11.Location = new System.Drawing.Point(10, 135);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Contancto:";
            // 
            // lblNombreAceptado
            // 
            this.lblNombreAceptado.AutoSize = true;
            this.lblNombreAceptado.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblNombreAceptado.Location = new System.Drawing.Point(58, 114);
            this.lblNombreAceptado.Name = "lblNombreAceptado";
            this.lblNombreAceptado.Size = new System.Drawing.Size(90, 13);
            this.lblNombreAceptado.TabIndex = 12;
            this.lblNombreAceptado.Text = "Nombre completo";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label9.Location = new System.Drawing.Point(10, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Cliente:";
            // 
            // lblEstadoViajeAceptado
            // 
            this.lblEstadoViajeAceptado.AutoSize = true;
            this.lblEstadoViajeAceptado.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblEstadoViajeAceptado.Location = new System.Drawing.Point(95, 46);
            this.lblEstadoViajeAceptado.Name = "lblEstadoViajeAceptado";
            this.lblEstadoViajeAceptado.Size = new System.Drawing.Size(40, 13);
            this.lblEstadoViajeAceptado.TabIndex = 10;
            this.lblEstadoViajeAceptado.Text = "Estado";
            // 
            // lblEstadoAceptado
            // 
            this.lblEstadoAceptado.AutoSize = true;
            this.lblEstadoAceptado.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblEstadoAceptado.Location = new System.Drawing.Point(10, 46);
            this.lblEstadoAceptado.Name = "lblEstadoAceptado";
            this.lblEstadoAceptado.Size = new System.Drawing.Size(85, 13);
            this.lblEstadoAceptado.TabIndex = 9;
            this.lblEstadoAceptado.Text = "Estado del viaje:";
            // 
            // btnCancelarAceptado
            // 
            this.btnCancelarAceptado.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.btnCancelarAceptado.Location = new System.Drawing.Point(191, 219);
            this.btnCancelarAceptado.Name = "btnCancelarAceptado";
            this.btnCancelarAceptado.Size = new System.Drawing.Size(110, 23);
            this.btnCancelarAceptado.TabIndex = 8;
            this.btnCancelarAceptado.Text = "Cancelar viaje";
            this.btnCancelarAceptado.UseVisualStyleBackColor = true;
            this.btnCancelarAceptado.Click += new System.EventHandler(this.btnCancelarAceptado_Click);
            // 
            // btnViajeAceptado
            // 
            this.btnViajeAceptado.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.btnViajeAceptado.Location = new System.Drawing.Point(13, 190);
            this.btnViajeAceptado.Name = "btnViajeAceptado";
            this.btnViajeAceptado.Size = new System.Drawing.Size(288, 23);
            this.btnViajeAceptado.TabIndex = 7;
            this.btnViajeAceptado.Text = "Inciar viaje";
            this.btnViajeAceptado.UseVisualStyleBackColor = true;
            this.btnViajeAceptado.Click += new System.EventHandler(this.btnViajeAceptado_Click);
            // 
            // lblPrecioAceptado
            // 
            this.lblPrecioAceptado.AutoSize = true;
            this.lblPrecioAceptado.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblPrecioAceptado.Location = new System.Drawing.Point(205, 14);
            this.lblPrecioAceptado.Name = "lblPrecioAceptado";
            this.lblPrecioAceptado.Size = new System.Drawing.Size(96, 13);
            this.lblPrecioAceptado.TabIndex = 5;
            this.lblPrecioAceptado.Text = "Cantidad de dinero";
            this.lblPrecioAceptado.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblDestinoAceptado
            // 
            this.lblDestinoAceptado.AutoSize = true;
            this.lblDestinoAceptado.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblDestinoAceptado.Location = new System.Drawing.Point(105, 91);
            this.lblDestinoAceptado.Name = "lblDestinoAceptado";
            this.lblDestinoAceptado.Size = new System.Drawing.Size(101, 13);
            this.lblDestinoAceptado.TabIndex = 4;
            this.lblDestinoAceptado.Text = "Calle tal sitio tal y tal";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label10.Location = new System.Drawing.Point(10, 91);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 13);
            this.label10.TabIndex = 3;
            this.label10.Text = "Lugar de destino:";
            // 
            // lblInicioAceptado
            // 
            this.lblInicioAceptado.AutoSize = true;
            this.lblInicioAceptado.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblInicioAceptado.Location = new System.Drawing.Point(95, 69);
            this.lblInicioAceptado.Name = "lblInicioAceptado";
            this.lblInicioAceptado.Size = new System.Drawing.Size(101, 13);
            this.lblInicioAceptado.TabIndex = 2;
            this.lblInicioAceptado.Text = "Calle tal sitio tal y tal";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label12.Location = new System.Drawing.Point(10, 69);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Lugar de inicio:";
            // 
            // lblTitleViajeAceptado
            // 
            this.lblTitleViajeAceptado.AutoSize = true;
            this.lblTitleViajeAceptado.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleViajeAceptado.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblTitleViajeAceptado.Location = new System.Drawing.Point(7, 9);
            this.lblTitleViajeAceptado.Name = "lblTitleViajeAceptado";
            this.lblTitleViajeAceptado.Size = new System.Drawing.Size(117, 18);
            this.lblTitleViajeAceptado.TabIndex = 0;
            this.lblTitleViajeAceptado.Text = "Solicitud de viaje";
            // 
            // gMapPrincipal
            // 
            this.gMapPrincipal.Bearing = 0F;
            this.gMapPrincipal.CanDragMap = true;
            this.gMapPrincipal.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapPrincipal.GrayScaleMode = false;
            this.gMapPrincipal.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapPrincipal.LevelsKeepInMemory = 5;
            this.gMapPrincipal.Location = new System.Drawing.Point(8, 6);
            this.gMapPrincipal.MarkersEnabled = true;
            this.gMapPrincipal.MaxZoom = 2;
            this.gMapPrincipal.MinZoom = 2;
            this.gMapPrincipal.MouseWheelZoomEnabled = true;
            this.gMapPrincipal.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapPrincipal.Name = "gMapPrincipal";
            this.gMapPrincipal.NegativeMode = false;
            this.gMapPrincipal.PolygonsEnabled = true;
            this.gMapPrincipal.RetryLoadTile = 0;
            this.gMapPrincipal.RoutesEnabled = true;
            this.gMapPrincipal.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapPrincipal.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapPrincipal.ShowTileGridLines = false;
            this.gMapPrincipal.Size = new System.Drawing.Size(657, 407);
            this.gMapPrincipal.TabIndex = 0;
            this.gMapPrincipal.Zoom = 0D;
            // 
            // tabMainHistorial
            // 
            this.tabMainHistorial.Controls.Add(this.lblTituloHistorial);
            this.tabMainHistorial.Controls.Add(this.dtgHistorialViajes);
            this.tabMainHistorial.Location = new System.Drawing.Point(4, 22);
            this.tabMainHistorial.Name = "tabMainHistorial";
            this.tabMainHistorial.Padding = new System.Windows.Forms.Padding(3);
            this.tabMainHistorial.Size = new System.Drawing.Size(1003, 419);
            this.tabMainHistorial.TabIndex = 2;
            this.tabMainHistorial.Text = "Historial";
            this.tabMainHistorial.UseVisualStyleBackColor = true;
            // 
            // lblTituloHistorial
            // 
            this.lblTituloHistorial.AutoSize = true;
            this.lblTituloHistorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloHistorial.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.lblTituloHistorial.Location = new System.Drawing.Point(576, 17);
            this.lblTituloHistorial.Name = "lblTituloHistorial";
            this.lblTituloHistorial.Size = new System.Drawing.Size(174, 24);
            this.lblTituloHistorial.TabIndex = 1;
            this.lblTituloHistorial.Text = "Historial de viajes";
            // 
            // dtgHistorialViajes
            // 
            this.dtgHistorialViajes.BackgroundColor = System.Drawing.Color.White;
            this.dtgHistorialViajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgHistorialViajes.Location = new System.Drawing.Point(309, 55);
            this.dtgHistorialViajes.Name = "dtgHistorialViajes";
            this.dtgHistorialViajes.Size = new System.Drawing.Size(683, 357);
            this.dtgHistorialViajes.TabIndex = 0;
            // 
            // notifyViaje
            // 
            this.notifyViaje.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyViaje.Icon")));
            this.notifyViaje.Text = "EasyGo Driver";
            this.notifyViaje.Visible = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1011, 512);
            this.Controls.Add(this.tabsMain);
            this.Controls.Add(this.pnlTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.Text = "EASY GO";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cerrarForm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCerrar)).EndInit();
            this.tabsMain.ResumeLayout(false);
            this.tabMainInicio.ResumeLayout(false);
            this.tabMainInicio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabMainViajes.ResumeLayout(false);
            this.flpViajes.ResumeLayout(false);
            this.pnlViajeAceptado.ResumeLayout(false);
            this.pnlViajeAceptado.PerformLayout();
            this.tabMainHistorial.ResumeLayout(false);
            this.tabMainHistorial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgHistorialViajes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.PictureBox btnCerrar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabControl tabsMain;
        private System.Windows.Forms.TabPage tabMainInicio;
        private System.Windows.Forms.Label lblFechaSoat;
        private System.Windows.Forms.Label lblSoat;
        private System.Windows.Forms.Label lblFechaTecnomecanica;
        private System.Windows.Forms.Label lblTecnomecanica;
        private System.Windows.Forms.Label lblFechaLicencia;
        private System.Windows.Forms.Label lblLicencia;
        private System.Windows.Forms.Label lblVencimiento;
        private System.Windows.Forms.Button btnEstado;
        private System.Windows.Forms.Label lblTituloMain;
        private System.Windows.Forms.TabPage tabMainViajes;
        private System.Windows.Forms.TabPage tabMainHistorial;
        private System.Windows.Forms.Label label1;
        private GMap.NET.WindowsForms.GMapControl gMapPrincipal;
        private System.Windows.Forms.FlowLayoutPanel flpViajes;
        private System.Windows.Forms.Label lblAvisoViajes;
        private System.Windows.Forms.Label lblTituloHistorial;
        private System.Windows.Forms.DataGridView dtgHistorialViajes;
        private System.Windows.Forms.Panel pnlViajeAceptado;
        private System.Windows.Forms.Button btnEnInicioAceptado;
        private System.Windows.Forms.Label lblDistanciaInicioAceptado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblTelefonoAceptado;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblNombreAceptado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblEstadoViajeAceptado;
        private System.Windows.Forms.Label lblEstadoAceptado;
        private System.Windows.Forms.Button btnCancelarAceptado;
        private System.Windows.Forms.Button btnViajeAceptado;
        private System.Windows.Forms.Label lblPrecioAceptado;
        private System.Windows.Forms.Label lblDestinoAceptado;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblInicioAceptado;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblTitleViajeAceptado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblEstadoMoto;
        private System.Windows.Forms.PictureBox cerrarForm;
        private System.Windows.Forms.Button btnEnfocarPosicion;
        private System.Windows.Forms.NotifyIcon notifyViaje;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnTerminarViaje;
    }
}