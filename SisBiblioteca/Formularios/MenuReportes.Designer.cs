namespace SisBiblioteca.Formularios
{
    partial class MenuReportes
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
            this.btnReportesMoras = new System.Windows.Forms.Button();
            this.btnPrestamos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnReportesMoras
            // 
            this.btnReportesMoras.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportesMoras.Location = new System.Drawing.Point(12, 12);
            this.btnReportesMoras.Name = "btnReportesMoras";
            this.btnReportesMoras.Size = new System.Drawing.Size(105, 50);
            this.btnReportesMoras.TabIndex = 25;
            this.btnReportesMoras.Text = "Moras";
            this.btnReportesMoras.UseVisualStyleBackColor = true;
            this.btnReportesMoras.Click += new System.EventHandler(this.btnReportesMoras_Click);
            // 
            // btnPrestamos
            // 
            this.btnPrestamos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrestamos.Location = new System.Drawing.Point(167, 12);
            this.btnPrestamos.Name = "btnPrestamos";
            this.btnPrestamos.Size = new System.Drawing.Size(105, 50);
            this.btnPrestamos.TabIndex = 26;
            this.btnPrestamos.Text = "Prestamos";
            this.btnPrestamos.UseVisualStyleBackColor = true;
            this.btnPrestamos.Click += new System.EventHandler(this.btnPrestamos_Click);
            // 
            // MenuReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnPrestamos);
            this.Controls.Add(this.btnReportesMoras);
            this.Name = "MenuReportes";
            this.Text = "MenuReportes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReportesMoras;
        private System.Windows.Forms.Button btnPrestamos;
    }
}