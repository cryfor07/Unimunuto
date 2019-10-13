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
    public partial class AutorAdd : Form
    {
        // Instancia de clases
        DaoAutorImp daoAutorImp = new DaoAutorImp();
        Autor autor = new Autor();

        public AutorAdd()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!validaError())
            {
                agregarAutor();
            }     
        }

        /// <summary>
        ///     Valida si los campos han sido correctamente llenados
        /// </summary>
        /// <returns> 
        ///     Si devuelve False todos los campos se llenaron correctamente 
        ///     de lo contrio devolvera True
        /// </returns>
        private Boolean validaError()
        {
            bool error = false;

            if (txtNombreAutor.Text.Trim().Equals(""))
            {
                error = true;
                MessageBox.Show("El nombre del autor no puede estar vacio.");
                txtNombreAutor.Clear();
                txtNombreAutor.Focus();
            }

            return error;
        }

        /// <summary>
        /// Funcion que recibe los datos y realiza un Insert en la tabla autor
        /// </summary>
        private void agregarAutor()
        {
            try
            {
                autor.NombreAutor = txtNombreAutor.Text.Trim();
                daoAutorImp.addAutor(autor);
                MessageBox.Show("El autor " + txtNombreAutor.Text + " se a ingresado corectamente");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("El error es " + ex);
            }
        }
    }
}
