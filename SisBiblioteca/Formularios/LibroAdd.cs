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
    public partial class LibroAdd : Form
    {
        // Instancia de clases
        DaoEditorialImp daoEditorialImp = new DaoEditorialImp();
        DaoCategoriaImp daoCategoriaImp = new DaoCategoriaImp();
        DaoAutorImp daoAutorImp = new DaoAutorImp();
        Libro libro = new Libro();

        public LibroAdd()
        {
            InitializeComponent();
        }

        private void LibroAdd_Load(object sender, EventArgs e)
        {
            //Asignacion de datos a los combobox
            //==================================================//
            cbxAutor.ValueMember = "idAutor";
            cbxAutor.DisplayMember = "nombreAutor";
            cbxAutor.DataSource = daoAutorImp.allAutor();
            //==================================================//
            cbxCategoria.ValueMember = "idCategoria";
            cbxCategoria.DisplayMember = "nombreCategoria";
            cbxCategoria.DataSource = daoCategoriaImp.allCategoria();
            //==================================================//
            cbxEditorial.ValueMember = "idEditorial";
            cbxEditorial.DisplayMember = "nombreEditorial";
            cbxEditorial.DataSource = daoEditorialImp.allEditorial();
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
        /// Funcion que verifica si un dato es de tipo int
        /// </summary>
        /// <param name="numero">Dato a evaluar</param>
        /// <returns>Si retorna TRUE es que si es int</returns>
        public Boolean isInt(String numero)
        {
            Boolean error = true;
            try
            {
                int valor = Convert.ToInt32(numero);
            }
            catch (Exception)
            {
                error = false;

            }
            return error;
        }

        /// <summary>
        /// Valida que todos los campos esten correctamente llenos
        /// </summary>
        /// <returns>si retorna True es que existe error</returns>
        public Boolean validaFormulario()
        {
            bool error = false;
            if (txtNombreLibro.Text.Trim().Equals(""))
            {
                error = true;
                MessageBox.Show("El nombre del libro no puede estar vacio.");
                txtNombreLibro.Clear();
                txtNombreLibro.Focus();
            }
            if (txtDescripcion.Text.Trim().Equals(""))
            {
                error = true;
                MessageBox.Show("El apellido del alumno no puede estar vacio.");
                txtDescripcion.Clear();
                txtDescripcion.Focus();
            }
            if (txtAnio.Text.Trim().Equals(""))
            {
                error = true;
                MessageBox.Show("El carnet no puede estar vacio.");
                txtAnio.Clear();
                txtAnio.Focus();

            }
            else if (isInt(txtAnio.Text.Trim().Equals("").ToString()))
            {
                MessageBox.Show("El No Carnet es un campo numerico.");
                txtAnio.Clear();
                txtAnio.Focus();
                error = true;
            }
            
            return error;
        }

        /// <summary>
        /// Funcion que nos realiza el insert en la tabla Libro
        /// </summary>
        public void agregar()
        {
            DaoLibroImp daoLibroImp = new DaoLibroImp();
            try
            {
                libro.NombreLibro = txtNombreLibro.Text.Trim();
                libro.Editorial.IdEditorial= Convert.ToInt32(cbxEditorial.SelectedValue);
                libro.Anio = Convert.ToInt32(txtAnio.Text.Trim());
                libro.Categoria.IdCategoria= Convert.ToInt32(cbxCategoria.SelectedValue);
                libro.Descripcion = txtDescripcion.Text.Trim();
                libro.Autor.IdAutor = Convert.ToInt32(cbxAutor.SelectedValue);
                daoLibroImp.addLibro(libro);
                MessageBox.Show("El libro " + txtNombreLibro.Text + " se a ingresado corectamente");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("El error es " + ex);
            }
        }
    }
}
