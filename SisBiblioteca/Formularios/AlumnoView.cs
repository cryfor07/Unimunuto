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
    public partial class AlumnoView : Form
    {
        // Instancia de clases
        DaoAlumnoImp daoAlumnoImp = new DaoAlumnoImp();
        Alumno alumno = new Alumno();

        // Variable global
        string fila = null;

        public AlumnoView()
        {
            InitializeComponent();
        }

        private void AlumnoView_Load(object sender, EventArgs e)
        {
            mostrar();
        }

        private void btnAgregarAutor_Click(object sender, EventArgs e)
        {
            AlumnoAdd alumnoAdd = new AlumnoAdd();
            alumnoAdd.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            fila = dgvDatos[0, dgvDatos.CurrentRow.Index].Value.ToString();
            if (!validaError())
            {
                eliminar();                
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            mostrar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            fila = dgvDatos[0, dgvDatos.CurrentRow.Index].Value.ToString();
            if (!validaError())
            {
                envioDatosUpdate();
            }
            
        }

        /// <summary>
        /// Funcion que nos muestra los datos en el dataGridView
        /// </summary>
        public void mostrar()
        {
            dgvDatos.Columns.Clear();
            dgvDatos.DataSource = daoAlumnoImp.allAlumno();
        }

        /// <summary>
        ///     Valida existe algun error en la captura de datos del
        ///     dataGridView y verifica si la fila seleccionada 
        /// </summary>
        /// <returns> 
        ///     Si devuelve False todos los campos se llenaron correctamente 
        ///     de lo contrio devolvera True
        /// </returns>
        private Boolean validaError()
        {
            bool error = false;
            if (dgvDatos.SelectedRows.Count == 0)
            {
                error = true;
                MessageBox.Show("No se ha seleccionado ningun item");
            }
            if (fila.Trim().Equals(""))
            {
                error = true;
                MessageBox.Show("No se ha seleccionado ningun item");
            }

            return error;
        }

        /// <summary>
        ///     Fucion que nos realiza un DELETE en la tabla Alumno
        /// </summary>
        private void eliminar()
        {
            string value = dgvDatos[1, dgvDatos.CurrentRow.Index].Value.ToString();
            DialogResult result = MessageBox.Show("Desea eliminar el Alumno '" + value + "' ", "DELETE", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    alumno.IdAlumno = Convert.ToInt16(fila);
                    daoAlumnoImp.deleteAlumno(alumno);
                    mostrar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo eliminar " + ex); ;
                }
            }
        }

        /// <summary>
        ///     Función que pasa el idAlumno, nombreAlumno, apellidoAlumno, 
        ///     genero, y la carrera hacia el formulario en el cual se actualizaran los datos
        /// </summary>
        private void envioDatosUpdate()
        {
            AlumnoUpdate alumnoUpdate = new AlumnoUpdate();
            alumnoUpdate.Id = Convert.ToInt16(fila);
            alumnoUpdate.Nombre = dgvDatos[1, dgvDatos.CurrentRow.Index].Value.ToString();
            alumnoUpdate.Apellido = dgvDatos[2, dgvDatos.CurrentRow.Index].Value.ToString();
            alumnoUpdate.Genero = dgvDatos[4, dgvDatos.CurrentRow.Index].Value.ToString();
            alumnoUpdate.Carrera = dgvDatos[5, dgvDatos.CurrentRow.Index].Value.ToString();
            alumnoUpdate.Show();
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
                dgvDatos.Columns.Clear();
                dgvDatos.DataSource = daoAlumnoImp.allAlumno(ncarnet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
