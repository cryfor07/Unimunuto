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
    public partial class LibroView : Form
    {
        //Instacia de la clases
        DaoLibroImp daoLibroImp = new DaoLibroImp();
        Libro libro = new Libro();

        public LibroView()
        {
            InitializeComponent();
        }
        
        private void LibroView_Load(object sender, EventArgs e)
        {
            mostrar();
        }

        private void btnAgregarAutor_Click(object sender, EventArgs e)
        {
            LibroAdd libroAdd = new LibroAdd();
            libroAdd.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            mostrar();
        }

        private void txtNombreLibro_TextChanged(object sender, EventArgs e)
        {
            buscarLibro(txtNombreLibro.Text);
        }

        /// <summary>
        ///     Función limpia y asigna los datos al dataGridView
        /// </summary>
        public void mostrar()
        {
            dgvDatos.Columns.Clear();
            dgvDatos.DataSource = daoLibroImp.allLibro();
        }

        /// <summary>
        ///     Funcion que recibe el nombre del libro para realizar
        ///     una busqueda de los datos con ese mismo nombre
        /// </summary>
        /// <param name="nombreLibro"></param>
        public void buscarLibro(String nombreLibro)
        {
            try
            {
                dgvDatos.Columns.Clear();
                dgvDatos.DataSource = daoLibroImp.allLibro(nombreLibro);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
