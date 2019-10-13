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
    public partial class AlumnoUpdate : Form
    {
        // Instancia de clases
        DaoCarreraImp daoCarreraImpo = new DaoCarreraImp();
        DaoAlumnoImp daoAlumnoImp = new DaoAlumnoImp();
        Alumno alumno = new Alumno();

        // Variables publicas que contienen los datos a editar
        public int Id;
        public string Carrera;
        public string Nombre;
        public string Apellido;
        public string Genero;

        public AlumnoUpdate()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void AlumnoUpdate_Load(object sender, EventArgs e)
        {
            // Se le asigna los datos de de la taba carrera al comboBox
            cbxCarrera.ValueMember = "idCarrera";
            cbxCarrera.DisplayMember = "nombreCarrera";
            cbxCarrera.DataSource = daoCarreraImpo.allCarrera();
            // Mostramos los datos que deseamos modificar
            cbxCarrera.SelectedItem = Carrera;
            cbxGenero.SelectedItem = Genero;
            txtApellidoAlumno.Text = Apellido;
            txtNombreAlumno.Text = Nombre;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!validaFormulario())
            {
                update();
            }
        }

        /// <summary>
        ///     Valida si los campos han sido correctamente llenados
        /// </summary>
        /// <returns> 
        ///     Si devuelve False todos los campos se llenaron correctamente 
        ///     de lo contrio devolvera True
        /// </returns>
        private Boolean validaFormulario()
        {
            bool error = false;
            if (txtNombreAlumno.Text.Trim().Equals(""))
            {
                error = true;
                MessageBox.Show("El nombre del alumno no puede estar vacio.");
                txtNombreAlumno.Clear();
                txtNombreAlumno.Focus();
            }
            if (txtApellidoAlumno.Text.Trim().Equals(""))
            {
                error = true;
                MessageBox.Show("El apellido del alumno no puede estar vacio.");
                txtApellidoAlumno.Clear();
                txtApellidoAlumno.Focus();
            }
            
            return error;
        }

        /// <summary>
        ///     Funcion que recibe los parametros de un alumno
        ///     y realiza el un Update a la tabla alumno
        /// </summary>
        private void update()
        {
            try
            {
                alumno.NombreAlumno = txtNombreAlumno.Text.Trim();
                alumno.ApellidoAlumno = txtApellidoAlumno.Text.Trim();
                alumno.Carrera.IdCarrera = Convert.ToInt32(cbxCarrera.SelectedValue);
                alumno.Genero = cbxGenero.SelectedItem.ToString();
                alumno.IdAlumno = Id;
                daoAlumnoImp.updateAlumno(alumno);
                MessageBox.Show("se realizaron los cambios con exito");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("El error es " + ex);
            }
        }
    }
}
