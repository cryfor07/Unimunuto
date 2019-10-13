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
    public partial class AutorUpdate : Form
    {
        // Instancia de clases
        DaoAutorImp daoAutorImp = new DaoAutorImp();
        Autor autor = new Autor();

        // Declaración de variables publicas
        public string nombreAutor;
        public int indiceDato;

        public AutorUpdate()
        {
            InitializeComponent();
        }
        
        private void AutorUpdate_Load(object sender, EventArgs e)
        {
            txtNombreAutor.Text = nombreAutor;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!txtNombreAutor.Text.Trim().Equals(""))
            {
                update();
            }
            else
            {
                MessageBox.Show("Debe llenar el campo");

            }
        }

        /// <summary>
        ///     Función que recibe parametros y actualiza el dato 
        ///     seleccionado de la tabla aurtor
        /// </summary>
        private void update()
        {
            try
            {
                autor.IdAutor = indiceDato;
                autor.NombreAutor = txtNombreAutor.Text.Trim();
                daoAutorImp.updateAutor(autor);
                MessageBox.Show("El dato fue actualizado exitosamente.");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("El error es " + ex);
            }
        }
    }
}
