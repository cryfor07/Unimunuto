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
    public partial class PrestamoLibroEntregados : Form
    {
        //Instancia de clases
        GridViewPrestamoLibro gridViewPrestamoLibro = new GridViewPrestamoLibro();
        PrestamoLibro prestamoLibro = new PrestamoLibro();

        public PrestamoLibroEntregados()
        {
            InitializeComponent();
        }

        private void PrestamoLibroEntregados_Load(object sender, EventArgs e)
        {
            mostrar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            mostrar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Funcion que nos muestra todos los elementos de un la tabla prestamo_libro que se han entregado
        /// </summary>
        public void mostrar()
        {
            try
            {
                dgvDatos.AutoGenerateColumns = true;
                dgvDatos.Columns.Clear();
                dgvDatos.DataSource = gridViewPrestamoLibro.allPrestamoLibroSolvente();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }

        private void txtNoAlumno_TextChanged(object sender, EventArgs e)
        {
            buscarPrestamosInsolventes(txtNoAlumno.Text.Trim());
        }

        /// <summary>
        /// realiza una busqueda por el numero de carnet 
        /// </summary>
        /// <param name="ncarnet">Retorna todos los prestamos con el numero de carnet del alumno</param>
        public void buscarPrestamosInsolventes(string ncarnet)
        {
            try
            {
                dgvDatos.Columns.Clear();
                dgvDatos.DataSource = gridViewPrestamoLibro.allPrestamoLibroSolvente(ncarnet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

    }
}
