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
    public partial class MorasSolventes : Form
    {
        // Instancia de clases
        GridViewMoras gidViewMoras = new GridViewMoras();

        public MorasSolventes()
        {
            InitializeComponent();
        }

        private void MorasSolventes_Load(object sender, EventArgs e)
        {
            mostrar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            mostrar();
        }

        /// <summary>
        /// 
        /// </summary>
        public void mostrar()
        {
            try
            {
                dgvDatos.AutoGenerateColumns = true;
                dgvDatos.Columns.Clear();
                dgvDatos.DataSource = gidViewMoras.allMorasSolventes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void txtNoAlumno_TextChanged(object sender, EventArgs e)
        {
            buscarMoraSolvente(txtNoAlumno.Text.Trim());
        }

        /// <summary>
        /// realiza una busqueda por los numeros de carnet de alumno 
        /// </summary>
        /// <param name="ncarnet">Retorna todas las moras solventes alumnos con el numero de carnet</param>
        public void buscarMoraSolvente(string ncarnet)
        {
            try
            {
                dgvDatos.Columns.Clear();
                dgvDatos.DataSource = gidViewMoras.allMorasSolventes(ncarnet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
