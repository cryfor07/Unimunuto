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
    public partial class CategoriaAdd : Form
    {
        // Instancia de clases
        DaoCategoriaImp daoCategoriaImp = new DaoCategoriaImp();
        Categoria categoria = new Categoria();

        public CategoriaAdd()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            if (!txtNombreCategoria.Text.Trim().Equals(""))
            {
                agregarCategoria();
            }
            else
            {
                MessageBox.Show("Debe llenar el campo");

            }
        }

        private void agregarCategoria()
        {
            try
            {
                categoria.NombreCategoria = txtNombreCategoria.Text.Trim();
                daoCategoriaImp.addCategoria(categoria);
                MessageBox.Show("La categoria " + txtNombreCategoria.Text + " se a ingresado corectamente");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("El error es " + ex);
            }
        }
    }
}
