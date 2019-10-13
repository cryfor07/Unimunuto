namespace SisBiblioteca.Formularios
{
    partial class MorasView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MorasView));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSolvencia = new System.Windows.Forms.Button();
            this.btnSolventar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.txtNoAlumno = new System.Windows.Forms.TextBox();
            this.lblEditorial = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSolvencia);
            this.groupBox1.Controls.Add(this.btnSolventar);
            this.groupBox1.Controls.Add(this.btnCerrar);
            this.groupBox1.Controls.Add(this.btnActualizar);
            this.groupBox1.Location = new System.Drawing.Point(12, 337);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(807, 90);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            // 
            // btnSolvencia
            // 
            this.btnSolvencia.Image = global::SisBiblioteca.Properties.Resources.tick_box_with_a_check_mark__1_;
            this.btnSolvencia.Location = new System.Drawing.Point(404, 28);
            this.btnSolvencia.Name = "btnSolvencia";
            this.btnSolvencia.Size = new System.Drawing.Size(84, 47);
            this.btnSolvencia.TabIndex = 12;
            this.btnSolvencia.UseVisualStyleBackColor = true;
            this.btnSolvencia.Click += new System.EventHandler(this.btnSolvencia_Click);
            // 
            // btnSolventar
            // 
            this.btnSolventar.Image = global::SisBiblioteca.Properties.Resources.verificacion_de_la_lista_de_entrega_simbolo_de_portapapeles__2_;
            this.btnSolventar.Location = new System.Drawing.Point(301, 28);
            this.btnSolventar.Name = "btnSolventar";
            this.btnSolventar.Size = new System.Drawing.Size(84, 47);
            this.btnSolventar.TabIndex = 10;
            this.btnSolventar.UseVisualStyleBackColor = true;
            this.btnSolventar.Click += new System.EventHandler(this.btnSolventar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrar.Image")));
            this.btnCerrar.Location = new System.Drawing.Point(516, 28);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(84, 47);
            this.btnCerrar.TabIndex = 8;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.Location = new System.Drawing.Point(195, 28);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(84, 47);
            this.btnActualizar.TabIndex = 7;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // txtNoAlumno
            // 
            this.txtNoAlumno.Location = new System.Drawing.Point(12, 43);
            this.txtNoAlumno.Name = "txtNoAlumno";
            this.txtNoAlumno.Size = new System.Drawing.Size(152, 20);
            this.txtNoAlumno.TabIndex = 25;
            this.txtNoAlumno.TextChanged += new System.EventHandler(this.txtNoAlumno_TextChanged);
            // 
            // lblEditorial
            // 
            this.lblEditorial.AutoSize = true;
            this.lblEditorial.Location = new System.Drawing.Point(12, 18);
            this.lblEditorial.Name = "lblEditorial";
            this.lblEditorial.Size = new System.Drawing.Size(110, 13);
            this.lblEditorial.TabIndex = 24;
            this.lblEditorial.Text = "No. Carnet de alumno";
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(12, 84);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.Size = new System.Drawing.Size(807, 235);
            this.dgvDatos.TabIndex = 23;
            // 
            // MorasView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 444);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtNoAlumno);
            this.Controls.Add(this.lblEditorial);
            this.Controls.Add(this.dgvDatos);
            this.Name = "MorasView";
            this.Text = "MorasView";
            this.Load += new System.EventHandler(this.MorasView_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSolventar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.TextBox txtNoAlumno;
        private System.Windows.Forms.Label lblEditorial;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.Button btnSolvencia;
    }
}