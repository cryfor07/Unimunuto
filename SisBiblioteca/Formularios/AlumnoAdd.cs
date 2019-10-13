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
    public partial class AlumnoAdd : Form
    {
        //Instacia de clases
        DaoCarreraImp daoCarreraImpo = new DaoCarreraImp();
        DaoAlumnoImp daoAlumnoImp = new DaoAlumnoImp();
        Alumno alumno = new Alumno();

        public AlumnoAdd()
        {
            InitializeComponent();
        }
                
        private void AlumnoAdd_Load(object sender, EventArgs e)
        {   
            // Lenamos el comboBox con los datos de la tabla carrera
            cbxCarrera.ValueMember = "idCarrera";
            cbxCarrera.DisplayMember = "nombreCarrera";
            cbxCarrera.DataSource = daoCarreraImpo.allCarrera();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!validaFormulario())
            {
                agregar();
                
            }
        }

        /// <summary>
        /// Función que valida si el dato ingresado es entero
        /// </summary>
        /// <param name="numero">numero es el dato a evaluar</param>
        /// <returns> Si es entero nos retornara True de lo contrario sera False</returns>
        private Boolean isInt(String numero)
        {
            Boolean error = true;
            try
            {
                int valor = Convert.ToInt32(numero);
            }
            catch (Exception )
            {
                error = false;

            }
            return error;
        }

        /// <summary>
        /// Función que valida que se encuentren correctamente llenados los campos
        /// </summary>
        /// <returns> De no existir un error devuelve False de lo contrario sera True</returns>
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
            if (txtNoCarnet.Text.Trim().Equals(""))
            {
                error = true;
                MessageBox.Show("El carnet no puede estar vacio.");
                txtNoCarnet.Clear();
                txtNoCarnet.Focus();

            }
            else if (isInt(txtNoCarnet.Text.Trim().Equals("").ToString()))
            {
                MessageBox.Show("El No Carnet es un campo numerico.");
                txtNoCarnet.Clear();
                txtNoCarnet.Focus();
                error = true;
            }
            return error;
        }

        /// <summary>
        /// Funcion que recibe los parametros y realiza un Insert en la tabla Alumno
        /// </summary>
        private void agregar()
        {
            try
            {
                alumno.NombreAlumno = txtNombreAlumno.Text.Trim();
                alumno.ApellidoAlumno = txtApellidoAlumno.Text.Trim();
                alumno.NCarnet = Convert.ToInt32(txtNoCarnet.Text.Trim());
                alumno.Carrera.IdCarrera = Convert.ToInt32(cbxCarrera.SelectedValue);
                alumno.Genero = cbxGenero.SelectedItem.ToString();
                daoAlumnoImp.addAlumno(alumno);
                MessageBox.Show("El alumno " + txtNombreAlumno.Text + " se a ingresado corectamente");
                
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("El error es " + ex);
            }
        }

    }
}
