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
    public partial class SeleccionAlumnoPrestamo : Form
    {
        public SeleccionAlumnoPrestamo()
        {
            InitializeComponent();
        }

        public int IdLibro;
        public string NombreLibro;

        DaoAlumnoImp daoAlumnoImp = new DaoAlumnoImp();

        public void mostrar()
        {
            dgvDatos.Columns.Clear();
            dgvDatos.DataSource = daoAlumnoImp.allAlumno();
        }
        private void SeleccionAlumnoPrestamo_Load(object sender, EventArgs e)
        {
            mostrar();
            lblIdLibro.Text = IdLibro.ToString();
            lblNombreLibro.Text = NombreLibro;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!validaFormulario())
            {
                agregar();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count != 0)
            {
                string fila = dgvDatos[0, dgvDatos.CurrentRow.Index].Value.ToString();
                
                lblIdAlumno.Text = fila;
                lblNombreAlumno.Text = dgvDatos[1, dgvDatos.CurrentRow.Index].Value.ToString();
                
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningun item");
            }
        }

        public Boolean validaFormulario()
        {
            bool error = false;
            if (lblNombreAlumno.Text.Trim().Equals(""))
            {
                error = true;
                MessageBox.Show("No se ha seleccionado ningun alumno");
                
            }
            if (lblIdAlumno.Text.Trim().Equals(""))
            {
                error = true;
                MessageBox.Show("No se ha seleccionado ningun alumno");

            }
            
            return error;
        }
        public void agregar()
        {
            try
            {

                DaoPrestamoLibroImp prestamo = new DaoPrestamoLibroImp();
                PrestamoLibro prestamoLibro = new PrestamoLibro();
                prestamoLibro.Alumno.IdAlumno = Convert.ToInt32(lblIdAlumno.Text);
                prestamoLibro.Libro.IdLibro = Convert.ToInt32(lblIdLibro.Text);
                prestamoLibro.FechaPrestamo = DateTime.Now;
                prestamoLibro.PrestamoSolvente = "Insolvente";
                prestamoLibro.FechaLimite = fecha;

                prestamo.addPrestamoLibro(prestamoLibro);
                MessageBox.Show("Se ha realizado el prestamo exitosamente");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("El error es " + ex);
            }
        }

        public DateTime fecha;
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            fecha = monthCalendar1.SelectionRange.Start.Date;
            lblFechaLimite.Text = fecha.ToShortDateString();
            MessageBox.Show(fecha.ToString());
        }

        private void monthCalendar1_MouseCaptureChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
