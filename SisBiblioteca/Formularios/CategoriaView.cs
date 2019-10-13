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
    public partial class CategoriaView : Form
    {
        // Instancia de clases
        DaoCategoriaImp daoCategoriaImp = new DaoCategoriaImp();
        Categoria categoria = new Categoria();

        // Variable global
        string fila = null;

        public CategoriaView()
        {
            InitializeComponent();
        }
        
        private void CategoriaView_Load(object sender, EventArgs e)
        {
            mostrar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CategoriaAdd categoriaAdd = new CategoriaAdd();
            categoriaAdd.Show();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            mostrar();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            fila = dgvDatos[0, dgvDatos.CurrentRow.Index].Value.ToString();
            if (!validaError())
            {
                envioDatosUpdate();
            }
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            fila = dgvDatos[0, dgvDatos.CurrentRow.Index].Value.ToString();
            if (!validaError())
            {
                eliminarCategoria();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Funcion que carga los datos en el dataGridView
        /// </summary>
        public void mostrar()
        {
            dgvDatos.Columns.Clear();
            dgvDatos.DataSource = daoCategoriaImp.allCategoria();
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
        /// Realiza un delete en la tabla Categorias
        /// </summary>
        private void eliminarCategoria()
        {
            string value = dgvDatos[1, dgvDatos.CurrentRow.Index].Value.ToString();
            DialogResult result = MessageBox.Show("Desea eliminar este " + value, "DELETE", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    categoria.IdCategoria = Convert.ToInt16(fila);
                    daoCategoriaImp.deleteCategoria(categoria);
                    mostrar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo eliminar " + ex); ;
                }
            }
        }

        /// <summary>
        /// Envia los datos idCategoria y nombre caterio al formulario categoria update
        /// </summary>
        private void envioDatosUpdate()
        {
            CategoriaUpdate categoriaUpdate = new CategoriaUpdate();
            categoriaUpdate.indice = Convert.ToInt16(fila);
            categoriaUpdate.nombreCategoria = dgvDatos[1, dgvDatos.CurrentRow.Index].Value.ToString();
            categoriaUpdate.Show();
        }

        private void txtNombreCategoria_TextChanged(object sender, EventArgs e)
        {
            buscarCategoria(txtNombreCategoria.Text.Trim());
        }

        /// <summary>
        /// realiza una busqueda por los numeros de carnet de alumno 
        /// </summary>
        /// <param name="ncarnet">Retorna todos los alumnos con el numero de carnet</param>
        public void buscarCategoria(string categoria)
        {
            try
            {
                dgvDatos.Columns.Clear();
                dgvDatos.DataSource = daoCategoriaImp.allCategoria(categoria);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
