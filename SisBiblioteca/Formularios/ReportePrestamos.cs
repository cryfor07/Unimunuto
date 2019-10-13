using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisBiblioteca.Dao;
using SisBiblioteca.Models;

namespace SisBiblioteca.Formularios
{
    public partial class ReportePrestamos : Form
    {
        // Instancia de clases
        GridReportePrestamosView gridReportePrestamosView = new GridReportePrestamosView();

        // Variables publicas
        DateTime Desde;
        DateTime Hasta;
        string Cancelada;
        public ReportePrestamos()
        {
            InitializeComponent();
        }

        private void btnSinFiltro_Click(object sender, EventArgs e)
        {
            mostra();
        }
        
        private void ReportePrestamos_Load(object sender, EventArgs e)
        {
            mostra();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            Cancelada = cbxCancelada.Text.Trim();
            if (!Cancelada.Equals(""))
            {
                dgvDatos.Columns.Clear();
                dgvDatos.DataSource = gridReportePrestamosView.allReportePrestamos(Cancelada);
            }
            if (!Hasta.Equals("") && !Desde.Equals(""))
            {
                dgvDatos.Columns.Clear();
                dgvDatos.DataSource = gridReportePrestamosView.allReportePrestamos(Desde, Hasta);
            }
            if (!Cancelada.Equals("") && !Hasta.Equals("") && !Desde.Equals(""))
            {
                dgvDatos.Columns.Clear();
                dgvDatos.DataSource = gridReportePrestamosView.allReportePrestamos(Desde, Hasta, Cancelada);
            }
            if (Cancelada.Equals("") && Hasta.Equals("") && Desde.Equals(""))
            {
                mostra();
            }

        }

        private void mostra()
        {
            dgvDatos.Columns.Clear();
            dgvDatos.DataSource = gridReportePrestamosView.allReportePrestamos();
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            Desde = dtpDesde.Value.Date;
            
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            Hasta = dtpHasta.Value.Date;
            
        }
    }
}
