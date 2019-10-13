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
    public partial class CategoriaUpdate : Form
    {
        //Instancia de clases
        DaoCategoriaImp daoCategoriaImp = new DaoCategoriaImp();
        Categoria categoria = new Categoria();

        // Variables publicas que recibiran los valores para ser modificados
        public string nombreCategoria;
        public int indice;

        public CategoriaUpdate()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CategoriaUpdate_Load(object sender, EventArgs e)
        {
            txtNombreCategoria.Text = nombreCategoria;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!txtNombreCategoria.Text.Trim().Equals(""))
            {
                ediatCategoria();
            }
        }

        /// <summary>
        /// Funcion que nos realiza un update en la tabla categoria
        /// </summary>
        private void ediatCategoria()
        {
            categoria.IdCategoria = indice;
            categoria.NombreCategoria = txtNombreCategoria.Text.Trim();
            daoCategoriaImp.updateCategoria(categoria);
            MessageBox.Show("El dato fue actualizado exitosamente");
            this.Close();
        }

    }
}
