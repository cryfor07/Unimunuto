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
    public partial class MorasView : Form
    {
        GridViewMoras gidViewMoras = new GridViewMoras();
        DaoMorasImp daoMorasImp = new DaoMorasImp();
        Mora mora = new Mora();
        public MorasView()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            
        }

        private void MorasView_Load(object sender, EventArgs e)
        {
            mostrar();
        }
        public void mostrar()
        {
            try
            {
                dgvDatos.AutoGenerateColumns = true;
                dgvDatos.Columns.Clear();
                dgvDatos.DataSource = gidViewMoras.allMorasInsolventes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void btnSolventar_Click(object sender, EventArgs e)
        {
            int fila = int.Parse(dgvDatos[0, dgvDatos.CurrentRow.Index].Value.ToString());
            if (!validaError())
            {
                pagoMora(fila);

                mostrar();
            }
        }

        /// <summary>
        /// Verifica que se seleccione una fila del dataGridView
        /// </summary>
        /// <returns>Si retorna TRUE es que existe un error</returns>
        private Boolean validaError()
        {
            bool error = false;
            if (dgvDatos.SelectedRows.Count == 0)
            {
                error = true;
                MessageBox.Show("No se ha seleccionado ningun item");
            }

            return error;
        }

        /// <summary>
        /// Nos actualiza un registro agregandole la fecha en que se pago la mora
        /// dependiendo el id que reciba
        /// </summary>
        /// <param name="rowsID">ID de la mora a actualizar</param>
        private void pagoMora(int rowsID)
        {
            try
            {
                mora.FechaPagoMora = DateTime.Now;
                mora.IdMora = rowsID;
                daoMorasImp.solventarMora(mora);
                MessageBox.Show("La mora ha sido canselada");
            }
            catch (Exception ex)
            {
                MessageBox.Show("El error es " + ex);
            }
        }

        private void btnSolvencia_Click(object sender, EventArgs e)
        {
            MorasSolventes morasSolventes = new MorasSolventes();
            morasSolventes.Show();
        }

        private void txtNoAlumno_TextChanged(object sender, EventArgs e)
        {
            buscarMoraInsolvente(txtNoAlumno.Text.Trim());
        }

        /// <summary>
        /// realiza una busqueda por los numeros de carnet de alumno 
        /// </summary>
        /// <param name="ncarnet">Retorna todas las moras solventes alumnos con el numero de carnet</param>
        public void buscarMoraInsolvente(string ncarnet)
        {
            try
            {
                dgvDatos.Columns.Clear();
                dgvDatos.DataSource = gidViewMoras.allMorasInsolventes(ncarnet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
