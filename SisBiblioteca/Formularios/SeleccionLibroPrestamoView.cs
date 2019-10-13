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
    public partial class SeleccionLibroPrestamoView : Form
    {
        public SeleccionLibroPrestamoView()
        {
            InitializeComponent();
        }

        DaoLibroImp daoLibroImp = new DaoLibroImp();

        public void mostrar()
        {
            dgvDatos.Columns.Clear();
            dgvDatos.DataSource = daoLibroImp.allLibroDisponible();
        }
        private void SeleccionLibroPrestamoView_Load(object sender, EventArgs e)
        {
            mostrar();
        }

        private void btnSleccionarLibro_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count != 0)
            {
                string fila = dgvDatos[0, dgvDatos.CurrentRow.Index].Value.ToString();
                SeleccionAlumnoPrestamo seleccionAlumno = new SeleccionAlumnoPrestamo();
                seleccionAlumno.IdLibro = Convert.ToInt16(fila);
                seleccionAlumno.NombreLibro = dgvDatos[1, dgvDatos.CurrentRow.Index].Value.ToString();
                seleccionAlumno.Show();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningun item");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
