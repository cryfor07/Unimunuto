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
    public partial class PrestamoLibroView : Form
    {
        // Instacia de clase
        GridViewPrestamoLibro gridViewPrestamoLibro = new GridViewPrestamoLibro();
        DaoPrestamoLibroImp daoPrestamoLibroImp = new DaoPrestamoLibroImp();
        PrestamoLibro prestamoLibro = new PrestamoLibro();
        DaoMorasImp daoMoraImp = new DaoMorasImp();
        Mora mora = new Mora();
        
        // Variable global
        private int fila;

        public PrestamoLibroView()
        {
            InitializeComponent();
        }
        
        private void PrestamoLibroView_Load(object sender, EventArgs e)
        {
            mostrar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            mostrar();
        }
        
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            PrestamoLibroAdd prestamoLibroAdd = new PrestamoLibroAdd();
            prestamoLibroAdd.Show();
        }

        private void btnSolventar_Click(object sender, EventArgs e)
        {
            fila = int.Parse(dgvDatos[0, dgvDatos.CurrentRow.Index].Value.ToString());
            if (!validaError())
            {
                Update(fila);
                conteoEntregaPuntual(fila);
                mostrar();
            }
        }

        /// <summary>
        /// Funcion que nos muestra todos los elementos de un la tabla prestamo_libro
        /// </summary>
        public void mostrar()
        {
            try
            {
                dgvDatos.AutoGenerateColumns = true;
                dgvDatos.Columns.Clear();
                dgvDatos.DataSource = gridViewPrestamoLibro.allPrestamoLibroInsolvente();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Nos actualiza un registro agregandole la fecha en que se entego la mora
        /// dependiendo el id que reciba
        /// </summary>
        /// <param name="rowsID">ID de la mora a actualizar</param>
        private void Update(int rowsID)
        {
            try
            {
                prestamoLibro.FechaEntrega = DateTime.Now;
                prestamoLibro.IdPrestamoLibro = rowsID;
                daoPrestamoLibroImp.updatePrestamooLibro(prestamoLibro);
                MessageBox.Show("La entrega se registro con exito");
            }
            catch (Exception ex)
            {
                MessageBox.Show("El error es " + ex);
            }
        }

        /// <summary>
        /// Funcion que evalua si el libro se entrego a tiempo
        /// </summary>
        /// <param name="rowsID"></param>
        private void conteoEntregaPuntual(int rowsID)
        {
            try
            {
                prestamoLibro.IdPrestamoLibro = rowsID;
                //Recibe de parametros el id del prestamo del libro
                int Cantida  = daoPrestamoLibroImp.comparaFechaLiminiteEntrega(prestamoLibro);
                // Si retorna 0 Significa que el libro se entrgo tarde 
                if (Cantida == 0)
                {
                    insertMora(rowsID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El error es " + ex);
            }
        }

        /// <summary>
        /// Verifica que se seleccione una fila del dataGridView
        /// </summary>
        /// <returns>Si retorna TRUE es que existe un error</returns>
        private Boolean validaError()
        {
            bool error = false;
            if (dgvDatos.SelectedRows.Count == 0)
            {
                error = true;
                MessageBox.Show("No se ha seleccionado ningun item");
            }
            
            return error;
        }
        
        /// <summary>
        /// Funcion que Agrega una mora 
        /// </summary>
        /// <param name="rowsID"></param>
        private void insertMora(int rowsID)
        {
            try
            {
                mora.PrestamoLibro.IdPrestamoLibro = rowsID;
                daoMoraImp.addMora(mora);
                MessageBox.Show("La entrega se registro con exito");

            }
            catch (Exception ex)
            {
                MessageBox.Show("El error es " + ex);
            }
        }

        private void btnSolvencia_Click(object sender, EventArgs e)
        {
            PrestamoLibroEntregados prestamoLibroEntregados = new PrestamoLibroEntregados();
            prestamoLibroEntregados.Show();
        }

        private void txtNoAlumno_TextChanged(object sender, EventArgs e)
        {
            buscarPrestamosInsolventes(txtNoAlumno.Text.Trim());
        }

        /// <summary>
        /// realiza una busqueda por el numero de carnet 
        /// </summary>
        /// <param name="ncarnet">Retorna todos los prestamos con el numero de carnet del alumno</param>
        public void buscarPrestamosInsolventes(string ncarnet)
        {
            try
            {
                dgvDatos.Columns.Clear();
                dgvDatos.DataSource = gridViewPrestamoLibro.allPrestamoLibroInsolvente(ncarnet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
