using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SisBiblioteca.Models;

using System.Data;
using SisBiblioteca.LibsBd;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace SisBiblioteca.Dao
{
    class GridViewPrestamoLibro : Cnn
    {
        MySqlConnection Con = null;
        MySqlCommand comand = null;

        /// <summary>
        /// Nos permite traer los datos de las prestamo-libro, libro y alumno 
        /// que estan insolventes
        /// </summary>
        /// <returns>Retorna una lista con los datos extraidoss</returns>
        public List<GridPrestamoLibro> allPrestamoLibroInsolvente()
        {
            List<GridPrestamoLibro> listPrestamoLibro = new List<GridPrestamoLibro>();
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "SELECT prestamo_libro.idPrestamoLibro, alumno.nombreAlumno, "
                                    + "alumno.apellidoAlumno, alumno.nCarnet, libro.nombreLibro, "
                                    + "prestamo_libro.fechaPrestamo, "
                                    + "prestamo_libro.fechaLimite, prestamo_libro.prestamoSolvente "
                                    + "FROM prestamo_libro "
                                    + "INNER JOIN alumno ON prestamo_libro.idAlumno = alumno.idAlumno "
                                    + "INNER JOIN libro ON prestamo_libro.idLibro = libro.idLibro "
                                    + "WHERE prestamo_libro.prestamoSolvente = 'Insolvente' "
                                    + "ORDER BY prestamo_libro.idPrestamoLibro DESC;";
                MySqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    GridPrestamoLibro gridPrestamoLibro = new GridPrestamoLibro();
                    gridPrestamoLibro.IdPrestamoLibro = reader.GetInt16("idPrestamoLibro");
                    gridPrestamoLibro.NombreAlumno = reader.GetString("nombreAlumno");
                    gridPrestamoLibro.ApellidoAlumno = reader.GetString("apellidoAlumno");
                    gridPrestamoLibro.NCarnet = reader.GetInt32("nCarnet");
                    gridPrestamoLibro.NombreLibro = reader.GetString("nombreLibro");
                    gridPrestamoLibro.FechaPrestamo = reader.GetDateTime("fechaPrestamo");
                    gridPrestamoLibro.FechaLimite = reader.GetDateTime("fechaLimite");
                    gridPrestamoLibro.PrestamoSolvente = reader.GetString("prestamoSolvente");
                    listPrestamoLibro.Add(gridPrestamoLibro);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede Listar " + ex);
            }
            finally
            {
                closeBd();
            }
            return listPrestamoLibro;
        }

        /// <summary>
        /// Nos permite traer los datos de las prestamo-libro, libro y alumno 
        /// que estan insolventes por busqueda
        /// </summary>
        /// <returns>Retorna una lista con los datos extraidoss</returns>
        public List<GridPrestamoLibro> allPrestamoLibroInsolvente(string nCarnet)
        {
            List<GridPrestamoLibro> listPrestamoLibro = new List<GridPrestamoLibro>();
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "SELECT prestamo_libro.idPrestamoLibro, alumno.nombreAlumno, "
                                    + "alumno.apellidoAlumno, alumno.nCarnet, libro.nombreLibro, "
                                    + "prestamo_libro.fechaPrestamo, "
                                    + "prestamo_libro.fechaLimite, prestamo_libro.prestamoSolvente "
                                    + "FROM prestamo_libro "
                                    + "INNER JOIN alumno ON prestamo_libro.idAlumno = alumno.idAlumno "
                                    + "INNER JOIN libro ON prestamo_libro.idLibro = libro.idLibro "
                                    + "WHERE prestamo_libro.prestamoSolvente = 'Insolvente' "
                                    + "AND alumno.nCarnet LIKE '%' @nCarnet '%' "
                                    + "ORDER BY prestamo_libro.idPrestamoLibro DESC ";
                comand.Prepare();
                comand.Parameters.AddWithValue("@nCarnet", nCarnet);
                MySqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    GridPrestamoLibro gridPrestamoLibro = new GridPrestamoLibro();
                    gridPrestamoLibro.IdPrestamoLibro = reader.GetInt16("idPrestamoLibro");
                    gridPrestamoLibro.NombreAlumno = reader.GetString("nombreAlumno");
                    gridPrestamoLibro.ApellidoAlumno = reader.GetString("apellidoAlumno");
                    gridPrestamoLibro.NCarnet = reader.GetInt32("nCarnet");
                    gridPrestamoLibro.NombreLibro = reader.GetString("nombreLibro");
                    gridPrestamoLibro.FechaPrestamo = reader.GetDateTime("fechaPrestamo");
                    gridPrestamoLibro.FechaLimite = reader.GetDateTime("fechaLimite");
                    gridPrestamoLibro.PrestamoSolvente = reader.GetString("prestamoSolvente");
                    listPrestamoLibro.Add(gridPrestamoLibro);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede Listar " + ex);
            }
            finally
            {
                closeBd();
            }
            return listPrestamoLibro;
        }

        /// <summary>
        /// Nos permite traer los datos de las prestamo-libro, libro y alumno 
        /// que estan solventes
        /// </summary>
        /// <returns>Retorna una lista con los datos extraidoss</returns>
        public List<GridPrestamoLibro> allPrestamoLibroSolvente()
        {
            List<GridPrestamoLibro> listPrestamoLibro = new List<GridPrestamoLibro>();
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "SELECT prestamo_libro.idPrestamoLibro, alumno.nombreAlumno, "
                                    + "alumno.apellidoAlumno, alumno.nCarnet, libro.nombreLibro, "
                                    + "prestamo_libro.fechaPrestamo, prestamo_libro.fechaEntrega, "
                                    + "prestamo_libro.fechaLimite, prestamo_libro.prestamoSolvente "
                                    + "FROM prestamo_libro "
                                    + "INNER JOIN alumno ON prestamo_libro.idAlumno = alumno.idAlumno "
                                    + "INNER JOIN libro ON prestamo_libro.idLibro = libro.idLibro "
                                    + "WHERE prestamo_libro.prestamoSolvente = 'Solvente' "
                                    + "ORDER BY prestamo_libro.idPrestamoLibro DESC;";
                MySqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    GridPrestamoLibro gridPrestamoLibro = new GridPrestamoLibro();
                    gridPrestamoLibro.IdPrestamoLibro = reader.GetInt16("idPrestamoLibro");
                    gridPrestamoLibro.NombreAlumno = reader.GetString("nombreAlumno");
                    gridPrestamoLibro.ApellidoAlumno = reader.GetString("apellidoAlumno");
                    gridPrestamoLibro.NCarnet = reader.GetInt32("nCarnet");
                    gridPrestamoLibro.NombreLibro = reader.GetString("nombreLibro");
                    gridPrestamoLibro.FechaPrestamo = reader.GetDateTime("fechaPrestamo");
                    gridPrestamoLibro.FechaEntrega = reader.GetDateTime("fechaEntrega");
                    gridPrestamoLibro.FechaLimite = reader.GetDateTime("fechaLimite");
                    gridPrestamoLibro.PrestamoSolvente = reader.GetString("prestamoSolvente");
                    listPrestamoLibro.Add(gridPrestamoLibro);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede Listar " + ex);
            }
            finally
            {
                closeBd();
            }
            return listPrestamoLibro;
        }

        /// <summary>
        /// Nos permite traer los datos de las prestamo-libro, libro y alumno 
        /// que estan solventes busqueda
        /// </summary>
        /// <returns>Retorna una lista con los datos extraidoss</returns>
        public List<GridPrestamoLibro> allPrestamoLibroSolvente(string nCarnet)
        {
            List<GridPrestamoLibro> listPrestamoLibro = new List<GridPrestamoLibro>();
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "SELECT prestamo_libro.idPrestamoLibro, alumno.nombreAlumno, "
                                    + "alumno.apellidoAlumno, alumno.nCarnet, libro.nombreLibro, "
                                    + "prestamo_libro.fechaPrestamo, prestamo_libro.fechaEntrega, "
                                    + "prestamo_libro.fechaLimite, prestamo_libro.prestamoSolvente "
                                    + "FROM prestamo_libro "
                                    + "INNER JOIN alumno ON prestamo_libro.idAlumno = alumno.idAlumno "
                                    + "INNER JOIN libro ON prestamo_libro.idLibro = libro.idLibro "
                                    + "WHERE prestamo_libro.prestamoSolvente = 'Solvente' "
                                    + "AND alumno.nCarnet LIKE '%' @nCarnet '%' "
                                    + "ORDER BY prestamo_libro.idPrestamoLibro DESC ";
                comand.Prepare();
                comand.Parameters.AddWithValue("@nCarnet", nCarnet);
                MySqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    GridPrestamoLibro gridPrestamoLibro = new GridPrestamoLibro();
                    gridPrestamoLibro.IdPrestamoLibro = reader.GetInt16("idPrestamoLibro");
                    gridPrestamoLibro.NombreAlumno = reader.GetString("nombreAlumno");
                    gridPrestamoLibro.ApellidoAlumno = reader.GetString("apellidoAlumno");
                    gridPrestamoLibro.NCarnet = reader.GetInt32("nCarnet");
                    gridPrestamoLibro.NombreLibro = reader.GetString("nombreLibro");
                    gridPrestamoLibro.FechaPrestamo = reader.GetDateTime("fechaPrestamo");
                    gridPrestamoLibro.FechaEntrega = reader.GetDateTime("fechaEntrega");
                    gridPrestamoLibro.FechaLimite = reader.GetDateTime("fechaLimite");
                    gridPrestamoLibro.PrestamoSolvente = reader.GetString("prestamoSolvente");
                    listPrestamoLibro.Add(gridPrestamoLibro);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede Listar " + ex);
            }
            finally
            {
                closeBd();
            }
            return listPrestamoLibro;
        }
    }
}
