namespace SisBiblioteca.Formularios
{
    partial class PrestamoLibroAdd
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
            this.mcalFechaLimite = new System.Windows.Forms.MonthCalendar();
            this.txtNoAlumno = new System.Windows.Forms.TextBox();
            this.lblEditorial = new System.Windows.Forms.Label();
            this.dgvDatosAlumno = new System.Windows.Forms.DataGridView();
            this.txtNombreLibro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDatosLibro = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnAlumnoPrestamo = new System.Windows.Forms.Button();
            this.gbxDatosAlumno = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvControles = new System.Windows.Forms.GroupBox();
            this.btnLibroPrestar = new System.Windows.Forms.Button();
            this.gbxDatosLibro = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblIdAlumno = new System.Windows.Forms.Label();
            this.gbxDatosPrestamo = new System.Windows.Forms.GroupBox();
            this.lblFechaPrestamo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblNombreLibro = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFechaLimite = new System.Windows.Forms.Label();
            this.lblNombreAlumno = new System.Windows.Forms.Label();
            this.lblIdLibro = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosAlumno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosLibro)).BeginInit();
            this.gbxDatosAlumno.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.dgvControles.SuspendLayout();
            this.gbxDatosLibro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.gbxDatosPrestamo.SuspendLayout();
            this.SuspendLayout();
            // 
            // mcalFechaLimite
            // 
            this.mcalFechaLimite.Location = new System.Drawing.Point(530, 28);
            this.mcalFechaLimite.Name = "mcalFechaLimite";
            this.mcalFechaLimite.TabIndex = 25;
            this.mcalFechaLimite.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.mcalFechaLimite_DateChanged);
            // 
            // txtNoAlumno
            // 
            this.txtNoAlumno.Location = new System.Drawing.Point(6, 32);
            this.txtNoAlumno.Name = "txtNoAlumno";
            this.txtNoAlumno.Size = new System.Drawing.Size(152, 20);
            this.txtNoAlumno.TabIndex = 24;
            this.txtNoAlumno.TextChanged += new System.EventHandler(this.txtNoAlumno_TextChanged);
            // 
            // lblEditorial
            // 
            this.lblEditorial.AutoSize = true;
            this.lblEditorial.Location = new System.Drawing.Point(6, 16);
            this.lblEditorial.Name = "lblEditorial";
            this.lblEditorial.Size = new System.Drawing.Size(110, 13);
            this.lblEditorial.TabIndex = 23;
            this.lblEditorial.Text = "No. Carnet de alumno";
            // 
            // dgvDatosAlumno
            // 
            this.dgvDatosAlumno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosAlumno.Location = new System.Drawing.Point(6, 58);
            this.dgvDatosAlumno.Name = "dgvDatosAlumno";
            this.dgvDatosAlumno.ReadOnly = true;
            this.dgvDatosAlumno.Size = new System.Drawing.Size(491, 110);
            this.dgvDatosAlumno.TabIndex = 22;
            // 
            // txtNombreLibro
            // 
            this.txtNombreLibro.Location = new System.Drawing.Point(6, 32);
            this.txtNombreLibro.Name = "txtNombreLibro";
            this.txtNombreLibro.Size = new System.Drawing.Size(317, 20);
            this.txtNombreLibro.TabIndex = 28;
            this.txtNombreLibro.TextChanged += new System.EventHandler(this.txtNombreLibro_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Nombre Libro";
            // 
            // dgvDatosLibro
            // 
            this.dgvDatosLibro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosLibro.Location = new System.Drawing.Point(6, 58);
            this.dgvDatosLibro.Name = "dgvDatosLibro";
            this.dgvDatosLibro.ReadOnly = true;
            this.dgvDatosLibro.Size = new System.Drawing.Size(491, 110);
            this.dgvDatosLibro.TabIndex = 26;
            this.dgvDatosLibro.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatosLibro_CellContentClick);
            // 
            // btnSalir
            // 
            this.btnSalir.Image = global::SisBiblioteca.Properties.Resources.enter;
            this.btnSalir.Location = new System.Drawing.Point(150, 111);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(84, 47);
            this.btnSalir.TabIndex = 31;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = global::SisBiblioteca.Properties.Resources.checkmark;
            this.btnAgregar.Location = new System.Drawing.Point(14, 111);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(84, 47);
            this.btnAgregar.TabIndex = 30;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnAlumnoPrestamo
            // 
            this.btnAlumnoPrestamo.Image = global::SisBiblioteca.Properties.Resources.user_check;
            this.btnAlumnoPrestamo.Location = new System.Drawing.Point(14, 25);
            this.btnAlumnoPrestamo.Name = "btnAlumnoPrestamo";
            this.btnAlumnoPrestamo.Size = new System.Drawing.Size(84, 47);
            this.btnAlumnoPrestamo.TabIndex = 29;
            this.btnAlumnoPrestamo.UseVisualStyleBackColor = true;
            this.btnAlumnoPrestamo.Click += new System.EventHandler(this.btnAlumnoPrestamo_Click);
            // 
            // gbxDatosAlumno
            // 
            this.gbxDatosAlumno.Controls.Add(this.pictureBox1);
            this.gbxDatosAlumno.Controls.Add(this.dgvDatosAlumno);
            this.gbxDatosAlumno.Controls.Add(this.lblEditorial);
            this.gbxDatosAlumno.Controls.Add(this.txtNoAlumno);
            this.gbxDatosAlumno.Location = new System.Drawing.Point(17, 12);
            this.gbxDatosAlumno.Name = "gbxDatosAlumno";
            this.gbxDatosAlumno.Size = new System.Drawing.Size(503, 177);
            this.gbxDatosAlumno.TabIndex = 32;
            this.gbxDatosAlumno.TabStop = false;
            this.gbxDatosAlumno.Text = "Datos Alumno";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SisBiblioteca.Properties.Resources.search;
            this.pictureBox1.Location = new System.Drawing.Point(164, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 36);
            this.pictureBox1.TabIndex = 35;
            this.pictureBox1.TabStop = false;
            // 
            // dgvControles
            // 
            this.dgvControles.Controls.Add(this.btnLibroPrestar);
            this.dgvControles.Controls.Add(this.btnAlumnoPrestamo);
            this.dgvControles.Controls.Add(this.btnAgregar);
            this.dgvControles.Controls.Add(this.btnSalir);
            this.dgvControles.Location = new System.Drawing.Point(530, 195);
            this.dgvControles.Name = "dgvControles";
            this.dgvControles.Size = new System.Drawing.Size(248, 177);
            this.dgvControles.TabIndex = 33;
            this.dgvControles.TabStop = false;
            // 
            // btnLibroPrestar
            // 
            this.btnLibroPrestar.Image = global::SisBiblioteca.Properties.Resources.book;
            this.btnLibroPrestar.Location = new System.Drawing.Point(150, 25);
            this.btnLibroPrestar.Name = "btnLibroPrestar";
            this.btnLibroPrestar.Size = new System.Drawing.Size(84, 47);
            this.btnLibroPrestar.TabIndex = 32;
            this.btnLibroPrestar.UseVisualStyleBackColor = true;
            this.btnLibroPrestar.Click += new System.EventHandler(this.btnLibroPrestar_Click);
            // 
            // gbxDatosLibro
            // 
            this.gbxDatosLibro.Controls.Add(this.pictureBox2);
            this.gbxDatosLibro.Controls.Add(this.dgvDatosLibro);
            this.gbxDatosLibro.Controls.Add(this.label1);
            this.gbxDatosLibro.Controls.Add(this.txtNombreLibro);
            this.gbxDatosLibro.Location = new System.Drawing.Point(15, 195);
            this.gbxDatosLibro.Name = "gbxDatosLibro";
            this.gbxDatosLibro.Size = new System.Drawing.Size(503, 177);
            this.gbxDatosLibro.TabIndex = 34;
            this.gbxDatosLibro.TabStop = false;
            this.gbxDatosLibro.Text = "Datos Libro";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SisBiblioteca.Properties.Resources.search;
            this.pictureBox2.Location = new System.Drawing.Point(329, 16);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(38, 36);
            this.pictureBox2.TabIndex = 29;
            this.pictureBox2.TabStop = false;
            // 
            // lblIdAlumno
            // 
            this.lblIdAlumno.AutoSize = true;
            this.lblIdAlumno.Location = new System.Drawing.Point(69, 26);
            this.lblIdAlumno.Name = "lblIdAlumno";
            this.lblIdAlumno.Size = new System.Drawing.Size(0, 13);
            this.lblIdAlumno.TabIndex = 35;
            // 
            // gbxDatosPrestamo
            // 
            this.gbxDatosPrestamo.Controls.Add(this.lblFechaPrestamo);
            this.gbxDatosPrestamo.Controls.Add(this.label7);
            this.gbxDatosPrestamo.Controls.Add(this.label6);
            this.gbxDatosPrestamo.Controls.Add(this.label4);
            this.gbxDatosPrestamo.Controls.Add(this.label5);
            this.gbxDatosPrestamo.Controls.Add(this.lblNombreLibro);
            this.gbxDatosPrestamo.Controls.Add(this.label2);
            this.gbxDatosPrestamo.Controls.Add(this.label3);
            this.gbxDatosPrestamo.Controls.Add(this.lblFechaLimite);
            this.gbxDatosPrestamo.Controls.Add(this.lblNombreAlumno);
            this.gbxDatosPrestamo.Controls.Add(this.lblIdLibro);
            this.gbxDatosPrestamo.Controls.Add(this.lblIdAlumno);
            this.gbxDatosPrestamo.Location = new System.Drawing.Point(17, 393);
            this.gbxDatosPrestamo.Name = "gbxDatosPrestamo";
            this.gbxDatosPrestamo.Size = new System.Drawing.Size(761, 100);
            this.gbxDatosPrestamo.TabIndex = 36;
            this.gbxDatosPrestamo.TabStop = false;
            this.gbxDatosPrestamo.Text = "Datos del prestamo";
            // 
            // lblFechaPrestamo
            // 
            this.lblFechaPrestamo.AutoSize = true;
            this.lblFechaPrestamo.Location = new System.Drawing.Point(96, 75);
            this.lblFechaPrestamo.Name = "lblFechaPrestamo";
            this.lblFechaPrestamo.Size = new System.Drawing.Size(0, 13);
            this.lblFechaPrestamo.TabIndex = 45;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 44;
            this.label7.Text = "Fecha Prestamo:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(358, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 43;
            this.label6.Text = "Fecha Limite:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(358, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "Libro:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(358, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 41;
            this.label5.Text = "Id Libro:";
            // 
            // lblNombreLibro
            // 
            this.lblNombreLibro.AutoSize = true;
            this.lblNombreLibro.Location = new System.Drawing.Point(414, 50);
            this.lblNombreLibro.Name = "lblNombreLibro";
            this.lblNombreLibro.Size = new System.Drawing.Size(0, 13);
            this.lblNombreLibro.TabIndex = 40;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "NombreAlumno:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Id Alumno:";
            // 
            // lblFechaLimite
            // 
            this.lblFechaLimite.AutoSize = true;
            this.lblFechaLimite.Location = new System.Drawing.Point(434, 75);
            this.lblFechaLimite.Name = "lblFechaLimite";
            this.lblFechaLimite.Size = new System.Drawing.Size(0, 13);
            this.lblFechaLimite.TabIndex = 37;
            // 
            // lblNombreAlumno
            // 
            this.lblNombreAlumno.AutoSize = true;
            this.lblNombreAlumno.Location = new System.Drawing.Point(94, 50);
            this.lblNombreAlumno.Name = "lblNombreAlumno";
            this.lblNombreAlumno.Size = new System.Drawing.Size(0, 13);
            this.lblNombreAlumno.TabIndex = 36;
            // 
            // lblIdLibro
            // 
            this.lblIdLibro.AutoSize = true;
            this.lblIdLibro.Location = new System.Drawing.Point(414, 26);
            this.lblIdLibro.Name = "lblIdLibro";
            this.lblIdLibro.Size = new System.Drawing.Size(0, 13);
            this.lblIdLibro.TabIndex = 36;
            // 
            // PrestamoLibroAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(802, 515);
            this.Controls.Add(this.gbxDatosPrestamo);
            this.Controls.Add(this.gbxDatosLibro);
            this.Controls.Add(this.dgvControles);
            this.Controls.Add(this.gbxDatosAlumno);
            this.Controls.Add(this.mcalFechaLimite);
            this.Name = "PrestamoLibroAdd";
            this.Text = "PrestamoLibroAdd";
            this.Load += new System.EventHandler(this.PrestamoLibroAdd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosAlumno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosLibro)).EndInit();
            this.gbxDatosAlumno.ResumeLayout(false);
            this.gbxDatosAlumno.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.dgvControles.ResumeLayout(false);
            this.gbxDatosLibro.ResumeLayout(false);
            this.gbxDatosLibro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.gbxDatosPrestamo.ResumeLayout(false);
            this.gbxDatosPrestamo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar mcalFechaLimite;
        private System.Windows.Forms.TextBox txtNoAlumno;
        private System.Windows.Forms.Label lblEditorial;
        private System.Windows.Forms.DataGridView dgvDatosAlumno;
        private System.Windows.Forms.TextBox txtNombreLibro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDatosLibro;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnAlumnoPrestamo;
        private System.Windows.Forms.GroupBox gbxDatosAlumno;
        private System.Windows.Forms.GroupBox dgvControles;
        private System.Windows.Forms.GroupBox gbxDatosLibro;
        private System.Windows.Forms.Button btnLibroPrestar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblIdAlumno;
        private System.Windows.Forms.GroupBox gbxDatosPrestamo;
        private System.Windows.Forms.Label lblIdLibro;
        private System.Windows.Forms.Label lblNombreAlumno;
        private System.Windows.Forms.Label lblFechaLimite;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNombreLibro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblFechaPrestamo;
        private System.Windows.Forms.Label label7;
    }
}