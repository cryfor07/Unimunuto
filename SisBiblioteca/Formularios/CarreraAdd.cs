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
    public partial class CarreraAdd : Form
    {
        // Instancias de clases
        DaoCarreraImp daoCarreraImp = new DaoCarreraImp();
        Carrera carrera = new Carrera();

        public CarreraAdd()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!txtNombreCarrera.Text.Trim().Equals(""))
            {
                agregarCarrera();
            }
            else
            {
                MessageBox.Show("Debe llenar el campo");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Funcion para realizar un Insert en la tabla carrera
        /// </summary>
        private void agregarCarrera()
        {
            try
            {
                carrera.NombreCarrera = txtNombreCarrera.Text.Trim();
                daoCarreraImp.addCarrera(carrera);
                MessageBox.Show("La carrera " + txtNombreCarrera.Text + " se a ingresado corectamente");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("El error es " + ex);
            }
        }
    }
}
