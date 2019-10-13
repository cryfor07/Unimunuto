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
    public partial class CarreraUpdate : Form
    {
        // Instancia de clases
        DaoCarreraImp daoCarreraImp = new DaoCarreraImp();
        Carrera carrera = new Carrera();

        // Variables publicas que recibiran datas para actualizarlos
        public string nombreCarrera;
        public int indiceDato;

        public CarreraUpdate()
        {
            InitializeComponent();
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CarreraUpdate_Load(object sender, EventArgs e)
        {
            txtNombreCarrera.Text = nombreCarrera;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!txtNombreCarrera.Text.Trim().Equals(""))
            {
                editarCarrera();
            }
            else
            {
                MessageBox.Show("Debe llenar el campo");
            }
        }

        /// <summary>
        /// Funcion que nos realiza un update en la tabla carrera
        /// </summary>
        private void editarCarrera()
        {
            try
            {
                carrera.IdCarrera = indiceDato;
                carrera.NombreCarrera = txtNombreCarrera.Text.Trim();
                daoCarreraImp.updateCarrera(carrera);
                MessageBox.Show("El dato fue actualizado exitosamente");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("El error es " + ex);
            }
        }
    }
}
