namespace SisBiblioteca.Formularios
{
    partial class SeleccionLibroPrestamoView
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSleccionarLibro = new System.Windows.Forms.Button();
            this.txtNombreLibro = new System.Windows.Forms.TextBox();
            this.lblEditorial = new System.Windows.Forms.Label();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnSleccionarLibro);
            this.groupBox1.Location = new System.Drawing.Point(12, 342);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(705, 90);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Image = global::SisBiblioteca.Properties.Resources.enter;
            this.button1.Location = new System.Drawing.Point(388, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 47);
            this.button1.TabIndex = 8;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSleccionarLibro
            // 
            this.btnSleccionarLibro.Image = global::SisBiblioteca.Properties.Resources.user;
            this.btnSleccionarLibro.Location = new System.Drawing.Point(189, 23);
            this.btnSleccionarLibro.Name = "btnSleccionarLibro";
            this.btnSleccionarLibro.Size = new System.Drawing.Size(84, 47);
            this.btnSleccionarLibro.TabIndex = 1;
            this.btnSleccionarLibro.UseVisualStyleBackColor = true;
            this.btnSleccionarLibro.Click += new System.EventHandler(this.btnSleccionarLibro_Click);
            // 
            // txtNombreLibro
            // 
            this.txtNombreLibro.Location = new System.Drawing.Point(12, 48);
            this.txtNombreLibro.Name = "txtNombreLibro";
            this.txtNombreLibro.Size = new System.Drawing.Size(152, 20);
            this.txtNombreLibro.TabIndex = 21;
            // 
            // lblEditorial
            // 
            this.lblEditorial.AutoSize = true;
            this.lblEditorial.Location = new System.Drawing.Point(12, 23);
            this.lblEditorial.Name = "lblEditorial";
            this.lblEditorial.Size = new System.Drawing.Size(70, 13);
            this.lblEditorial.TabIndex = 20;
            this.lblEditorial.Text = "Nombre Libro";
            // 
            // dgvDatos
            // 
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Location = new System.Drawing.Point(12, 89);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.Size = new System.Drawing.Size(705, 235);
            this.dgvDatos.TabIndex = 19;
            // 
            // SeleccionLibroPrestamoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 455);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtNombreLibro);
            this.Controls.Add(this.lblEditorial);
            this.Controls.Add(this.dgvDatos);
            this.Name = "SeleccionLibroPrestamoView";
            this.Text = "SeleccionLibroPrestamoView";
            this.Load += new System.EventHandler(this.SeleccionLibroPrestamoView_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSleccionarLibro;
        private System.Windows.Forms.TextBox txtNombreLibro;
        private System.Windows.Forms.Label lblEditorial;
        private System.Windows.Forms.DataGridView dgvDatos;
    }
}