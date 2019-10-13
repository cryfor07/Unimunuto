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
    public partial class frmEditarEditorial : Form
    {
        //Instancia de clases
        DaoEditorialImp daoEditorialImp = new DaoEditorialImp();
        Editorial editorial = new Editorial();

        //Variables publicas Reciben los datos que son  enviados del formulario CategoriaView
        public string EditorialDato;
        public int indiceDato;

        public frmEditarEditorial()
        {
            InitializeComponent();
        }
        
        private void frmEditarEditorial_Load(object sender, EventArgs e)
        {
            txtNombreEditorial.Text = EditorialDato;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!txtNombreEditorial.Text.Trim().Equals(""))
            {
                try
                {
                    editorial.IdEditorial = indiceDato;
                    editorial.NombreEditorial = txtNombreEditorial.Text;
                    daoEditorialImp.updateEditorial(editorial);
                    MessageBox.Show("El dato fue actualizado exitosamente");
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
    }
}
