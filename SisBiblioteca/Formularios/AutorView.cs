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
    public partial class AutorView : Form
    {
        // Instancia de clases
        DaoAutorImp daoAutorImp = new DaoAutorImp();
        Autor autor = new Autor();

        // Variable global
        string fila = null;

        public AutorView()
        {
            InitializeComponent();
        }

        private void AutorView_Load(object sender, EventArgs e)
        {
            mostrar();
        }

        private void btnAgregarAutor_Click(object sender, EventArgs e)
        {
            AutorAdd autorAdd = new AutorAdd();
            autorAdd.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            fila = dgvDatos[0, dgvDatos.CurrentRow.Index].Value.ToString();
            if (!validaError())
            {
                eliminar();
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            fila = dgvDatos[0, dgvDatos.CurrentRow.Index].Value.ToString();
            if (!validaError())
            {
                envioDatosUpdate();
            }

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            mostrar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        ///     Función que asigna datos de la tabla autor al dataGridView
        /// </summary>
        private void mostrar()
        {
            dgvDatos.Columns.Clear();
            dgvDatos.DataSource = daoAutorImp.allAutor();
        }

        /// <summary>
        ///     Valida existe algun error en la captura de datos
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
        ///     Función que realiza un Delete en la tabla Autores
        /// </summary>
        private void eliminar()
        {
            string value = dgvDatos[1, dgvDatos.CurrentRow.Index].Value.ToString();
            DialogResult result = MessageBox.Show("Desea eliminar este " + value, "DELETE", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    autor.IdAutor = Convert.ToInt16(fila);
                    daoAutorImp.deleteAutor(autor);
                    mostrar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo eliminar " + ex); ;
                }
            }
        }

        /// <summary>
        ///     Función que pasa el idAutor, nombreAutor 
        ///     hacia el formulario en el cual se actualizaran los datos
        /// </summary>
        private void envioDatosUpdate()
        {
            AutorUpdate autorUpdate = new AutorUpdate();
            autorUpdate.indiceDato = Convert.ToInt16(fila);
            autorUpdate.nombreAutor = dgvDatos[1, dgvDatos.CurrentRow.Index].Value.ToString();
            autorUpdate.Show();
        }

        private void txtNombreAutor_TextChanged(object sender, EventArgs e)
        {
            buscarAutor(txtNombreAutor.Text.Trim());
        }

        /// <summary>
        /// realiza una busqueda por el Nombre del autor 
        /// </summary>
        /// <param name="ncarnet">Retorna todos los autores con ese nombre</param>
        public void buscarAutor(string nombreAutor)
        {
            try
            {
                dgvDatos.Columns.Clear();
                dgvDatos.DataSource = daoAutorImp.allAutor(nombreAutor);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
