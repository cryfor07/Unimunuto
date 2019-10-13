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
    public partial class EditorialAgregar : Form
    {
        // Instancia de clases
        DaoEditorialImp daoEditorialImp = new DaoEditorialImp();
        Editorial editorial = new Editorial();

        public EditorialAgregar()
        {
            InitializeComponent();
        }
        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!txtNombreEditorial.Text.Trim().Equals(""))
            {
                try
                {
                    editorial.NombreEditorial = txtNombreEditorial.Text;
                    daoEditorialImp.addEditorial(editorial);
                    MessageBox.Show("La editorial: " + txtNombreEditorial.Text.ToUpper() + " se ha ingresado corectamente");
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("El error es " + ex);
                }
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

        private void EditorialAgregar_Load(object sender, EventArgs e)
        {

        }
    }
}
