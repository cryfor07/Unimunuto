using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SisBiblioteca.Formularios;

namespace SisBiblioteca
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnEditorial_Click(object sender, EventArgs e)
        {
            EditorialViews editorialView = new EditorialViews();
            editorialView.Show();
        }

        private void btnAutor_Click(object sender, EventArgs e)
        {
            AutorView autorView = new AutorView();
            autorView.Show();
        }

        private void btnCarrera_Click(object sender, EventArgs e)
        {
            CarreraView carreraView = new CarreraView();
            carreraView.Show();
        }

        private void btnAlumno_Click(object sender, EventArgs e)
        {
            AlumnoView alumnoView = new AlumnoView();
            alumnoView.Show();
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            CategoriaView categoriaView = new CategoriaView();
            categoriaView.Show();
        }

        private void btnLibro_Click(object sender, EventArgs e)
        {
            LibroView libroView = new LibroView();
            libroView.Show();
        }

        private void btnPrestamoLibro_Click(object sender, EventArgs e)
        {
            PrestamoLibroView prestamoLibroView = new PrestamoLibroView();
            prestamoLibroView.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAutor_Click_1(object sender, EventArgs e)
        {
            AutorView autorView = new AutorView();
            autorView.Show();
        }

        private void btnMoras_Click(object sender, EventArgs e)
        {
            MorasView morasView = new MorasView();
            morasView.Show();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            MenuReportes menuReportes = new MenuReportes();
            menuReportes.Show();
        }
    }
}
