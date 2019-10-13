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
    public partial class PrestamoLibroAdd : Form
    {
        //Instacia de clases
        DaoPrestamoLibroImp daoPrestamoLibroImp = new DaoPrestamoLibroImp();
        PrestamoLibro prestamoLibro = new PrestamoLibro();
        DaoAlumnoImp daoAlumnoImp = new DaoAlumnoImp();
        DaoLibroImp daoLibroImp = new DaoLibroImp();

        // Variable publica
        private DateTime fecha;

        public PrestamoLibroAdd()
        {
            InitializeComponent();
        }

        private void PrestamoLibroAdd_Load(object sender, EventArgs e)
        {
            mostrarAlumno();
            MostrarLibro();
            lblFechaPrestamo.Text = DateTime.Now.ToShortDateString();
        }

        private void txtNombreLibro_TextChanged(object sender, EventArgs e)
        {
            buscarLibro(txtNombreLibro.Text.Trim());
        }

        private void btnAlumnoPrestamo_Click(object sender, EventArgs e)
        {
            if (dgvDatosAlumno.SelectedRows.Count != 0)
            {
                string fila = dgvDatosAlumno[0, dgvDatosAlumno.CurrentRow.Index].Value.ToString();
                lblIdAlumno.Text = fila;
                lblNombreAlumno.Text = dgvDatosAlumno[1, dgvDatosAlumno.CurrentRow.Index].Value.ToString();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningun item");
            }
        }

        private void btnLibroPrestar_Click(object sender, EventArgs e)
        {
            if (dgvDatosLibro.SelectedRows.Count != 0)
            {
                string fila = dgvDatosLibro[0, dgvDatosLibro.CurrentRow.Index].Value.ToString();
                lblIdLibro.Text = fila;
                lblNombreLibro.Text = dgvDatosLibro[1, dgvDatosLibro.CurrentRow.Index].Value.ToString();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningun item");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!validaFormulario())
            {
                conteoAlumnosConMora(int.Parse(lblIdAlumno.Text));
            }
        }

        private void mcalFechaLimite_DateChanged(object sender, DateRangeEventArgs e)
        {
            fecha = mcalFechaLimite.SelectionRange.Start.Date;
            lblFechaLimite.Text = fecha.ToShortDateString();
            
        }

        /// <summary>
        /// Funcion que nos llena el dataGridViw con los datos de los alumnos
        /// </summary>
        public void mostrarAlumno()
        {
            dgvDatosAlumno.Columns.Clear();
            dgvDatosAlumno.DataSource = daoAlumnoImp.allAlumno();
        }

        /// <summary>
        /// Funcion que nos llena el dataGridViw con los datos de los alumnos
        /// </summary>
        public void MostrarLibro()
        {
            dgvDatosLibro.Columns.Clear();
            dgvDatosLibro.DataSource = daoLibroImp.allLibroDisponible();
        }

        /// <summary>
        /// Funciom que realiza la busqueda de libro por el nombre del mismo
        /// </summary>
        /// <param name="nombreLibro"></param>
        public void buscarLibro(String nombreLibro)
        {
            try
            {
                dgvDatosLibro.Columns.Clear();
                dgvDatosLibro.DataSource = daoLibroImp.allLibroDisponible(nombreLibro);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Funcion que verifica que todo los datos esten correctamente llenos
        /// </summary>
        /// <returns>Si retorna TRUE es que existe un error o datos bacios</returns>
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
            if (lblIdLibro.Text.Trim().Equals(""))
            {
                error = true;
                MessageBox.Show("No se ha seleccionado ningun libro");

            }
            if (lblNombreLibro.Text.Trim().Equals(""))
            {
                error = true;
                MessageBox.Show("No se ha seleccionado ningun libro");

            }
            if (lblFechaLimite.Text.Trim().Equals(""))
            {
                error = true;
                MessageBox.Show("Se debe establecer una fecha limite");
            }
            return error;
        }

        /// <summary>
        /// Funcion que realiza Inser en la tabla PrestamoLibro
        /// </summary>
        public void agregar()
        {
            try
            {
                prestamoLibro.Alumno.IdAlumno = Convert.ToInt32(lblIdAlumno.Text);
                prestamoLibro.Libro.IdLibro = Convert.ToInt32(lblIdLibro.Text);
                prestamoLibro.FechaPrestamo = DateTime.Now;
                prestamoLibro.PrestamoSolvente = "Insolvente";
                prestamoLibro.FechaLimite = fecha;

                daoPrestamoLibroImp.addPrestamoLibro(prestamoLibro);
                MessageBox.Show("Se ha realizado el prestamo exitosamente");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("El error es " + ex);
            }
        }

        /// <summary>
        /// Funcion que verifica si un alumno tiene mora,
        /// si no posee mora se realizara el prestamo
        /// </summary>
        /// <param name="rowsID"></param>
        private void conteoAlumnosConMora(int rowsID)
        {
            try
            {
                prestamoLibro.Alumno.IdAlumno = rowsID;
                int Cantida = daoPrestamoLibroImp.CuentaMorasAlumnoSinPagar(prestamoLibro);
                if (Cantida == 0)
                {
                    agregar();
                }
                else
                {
                    MessageBox.Show("No se puede realizar el prestamo, este alumno posee moras pendiente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El error es " + ex);
            }
        }

        private void txtNoAlumno_TextChanged(object sender, EventArgs e)
        {
            buscarAlumno(txtNoAlumno.Text.Trim());
        }

        /// <summary>
        /// realiza una busqueda por los numeros de carnet de alumno 
        /// </summary>
        /// <param name="ncarnet">Retorna todos los alumnos con el numero de carnet</param>
        public void buscarAlumno(string ncarnet)
        {
            try
            {
                dgvDatosAlumno.Columns.Clear();
                dgvDatosAlumno.DataSource = daoAlumnoImp.allAlumno(ncarnet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvDatosLibro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
