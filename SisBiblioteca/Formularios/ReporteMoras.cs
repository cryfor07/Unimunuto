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
    public partial class ReporteMoras : Form
    {
        // Instancia de clases
        GridReporteMorasView gridReporteMorasView = new GridReporteMorasView();
        DaoCarreraImp daoCarreraImpo = new DaoCarreraImp();
        // variables globales
        string Cancelada;
        DateTime Desde;
        DateTime Hasta;

        public ReporteMoras()
        {
            InitializeComponent();
        }

        private void ReporteMoras_Load(object sender, EventArgs e)
        {
            mostra();
        }

        private void mostra()
        {
            dgvDatos.Columns.Clear();
            dgvDatos.DataSource = gridReporteMorasView.allReporteMoras();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            Cancelada = cbxCancelada.Text.Trim();
            if (!Cancelada.Equals(""))
            {
                dgvDatos.Columns.Clear();
                dgvDatos.DataSource = gridReporteMorasView.allReporteMoras(Cancelada);
            }
            if (!Desde.Equals("") && !Hasta.Equals(""))
            {
                dgvDatos.Columns.Clear();
                dgvDatos.DataSource = gridReporteMorasView.allReporteMoras(Desde, Hasta);
            }
            if (!Cancelada.Equals("") && !Hasta.Equals("") && !Desde.Equals(""))
            {
                dgvDatos.Columns.Clear();
                dgvDatos.DataSource = gridReporteMorasView.allReporteMoras(Desde, Hasta, Cancelada);
            }
            if (Cancelada.Equals("") && Hasta.Equals("") && Desde.Equals(""))
            {
                mostra();
            }
            
        }

        private void btnSinFiltro_Click(object sender, EventArgs e)
        {
            mostra();
            
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
