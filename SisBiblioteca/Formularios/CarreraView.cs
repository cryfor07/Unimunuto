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
    public partial class CarreraView : Form
    {
        // Instancia de clases 
        DaoCarreraImp daoCarreraImp = new DaoCarreraImp();
        Carrera carrera = new Carrera();

        //Variable global
        string fila = null;

        public CarreraView()
        {
            InitializeComponent();
        }
        
        private void CarreraView_Load(object sender, EventArgs e)
        {
            mostrar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CarreraAdd carreraAdd = new CarreraAdd();
            carreraAdd.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            fila = dgvDatos[0, dgvDatos.CurrentRow.Index].Value.ToString();
            if (!validaError())
            {
                eliminarCarrera();
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
        /// Funcion que nos muestra los datos en el dataGridView
        /// </summary>
        public void mostrar()
        {
            dgvDatos.Columns.Clear();
            dgvDatos.DataSource = daoCarreraImp.allCarrera();
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
        /// Funcion que nos realiza un Delete en la tabla carrera
        /// </summary>
        private void eliminarCarrera()
        {
            string value = dgvDatos[1, dgvDatos.CurrentRow.Index].Value.ToString();
            DialogResult result = MessageBox.Show("Desea eliminar este " + value, "DELETE", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    carrera.IdCarrera = Convert.ToInt16(fila);
                    daoCarreraImp.deleteCarrera(carrera);
                    mostrar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo eliminar " + ex); ;
                }
            }
        }

        /// <summary>
        ///     Función que pasa el idCarrera, nombreCarrera
        ///     y los envia hacia el formulario en el cual se actualizaran los datos
        /// </summary>
        private void envioDatosUpdate()
        {
            CarreraUpdate carreraUpdate = new CarreraUpdate();
            carreraUpdate.indiceDato = Convert.ToInt16(fila);
            carreraUpdate.nombreCarrera = dgvDatos[1, dgvDatos.CurrentRow.Index].Value.ToString();
            carreraUpdate.Show();
        }

        private void txtNombreCarrera_TextChanged(object sender, EventArgs e)
        {
            buscarCarrera(txtNombreCarrera.Text.Trim());
        }

        /// <summary>
        /// realiza una busqueda por el nombre de la carre 
        /// </summary>
        /// <param name="ncarnet">Retorna las carreras con ese nombre</param>
        public void buscarCarrera(string nombreCarrera)
        {
            try
            {
                dgvDatos.Columns.Clear();
                dgvDatos.DataSource = daoCarreraImp.allCarrera(nombreCarrera);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
