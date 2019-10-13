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
    
    public partial class EditorialViews : Form
    {
        //Instancia de clases
        DaoEditorialImp daoEditorialImp = new DaoEditorialImp();
        Editorial editorial = new Editorial();

        // Variable global
        string fila;

        public EditorialViews()
        {
            InitializeComponent();
        }
        
        private void Editorial_Load(object sender, EventArgs e)
        {
            mostrar();
        }

        private void btnAgregarEditorial_Click(object sender, EventArgs e)
        {
            EditorialAgregar editorialAgregar = new EditorialAgregar();
            editorialAgregar.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count != 0)
            {
                fila = dgvDatos[0, dgvDatos.CurrentRow.Index].Value.ToString();
                string value = dgvDatos[1, dgvDatos.CurrentRow.Index].Value.ToString();
                if (!fila.Trim().Equals(""))
                {
                    DialogResult result = MessageBox.Show("Desea eliminar este " + value, "DELETE", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            editorial.IdEditorial = Convert.ToInt16(fila);
                            daoEditorialImp.deleteEditorial(editorial);
                            mostrar();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("No se pudo eliminar " + ex); ;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningun item");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count != 0)
            {
                fila = dgvDatos[0, dgvDatos.CurrentRow.Index].Value.ToString();
                frmEditarEditorial frmEditarEditorial = new frmEditarEditorial();
                frmEditarEditorial.indiceDato = Convert.ToInt16(fila);
                frmEditarEditorial.EditorialDato = dgvDatos[1, dgvDatos.CurrentRow.Index].Value.ToString();
                frmEditarEditorial.Show();
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ningun item");
            }
        }

        private void btnActualizar(object sender, EventArgs e)
        {
            mostrar();
        }

        /// <summary>
        /// Funcion que iguala los datos extraidos de la funcion que lista las editoriales
        /// y agrega los valores al dataGridView
        /// </summary>
        public void mostrar()
        {
            dgvDatos.Columns.Clear();
            dgvDatos.DataSource = daoEditorialImp.allEditorial();
        }

        private void txtNombreEditorial_TextChanged(object sender, EventArgs e)
        {
            buscarEditorial(txtNombreEditorial.Text.Trim());
        }

        /// <summary>
        /// realiza una busqueda por el nombre de la editorial 
        /// </summary>
        /// <param name="ncarnet">Retorna la editorial con ese nombre</param>
        public void buscarEditorial(string ncarnet)
        {
            try
            {
                dgvDatos.Columns.Clear();
                dgvDatos.DataSource = daoEditorialImp.allEditorial(ncarnet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
