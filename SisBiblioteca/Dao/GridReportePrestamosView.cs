using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using SisBiblioteca.LibsBd;
using SisBiblioteca.Models;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace SisBiblioteca.Dao 
{
    public class GridReportePrestamosView : Cnn
    {
        MySqlConnection Con = null;
        MySqlCommand comand = null;

        /// <summary>
        /// Nos permite traer los datos de las prestamo-libro, libro y alumno 
        /// </summary>
        /// <returns>Retorna una lista con los datos extraidoss</returns>
        public List<GridReportePrestamos> allReportePrestamos()
        {
            List<GridReportePrestamos> listReportePrestamos = new List<GridReportePrestamos>();
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "SELECT libro.nombreLibro as Libro, categoria.nombreCategoria, alumno.nombreAlumno, "
                                   + "alumno.apellidoAlumno, alumno.nCarnet, carrera.nombreCarrera, "
                                   + "prestamo_libro.fechaPrestamo, prestamo_libro.fechaLimite, "
                                   + "prestamo_libro.fechaEntrega, prestamo_libro.prestamoSolvente "
                                   + "FROM prestamo_libro "
                                   + "INNER JOIN alumno ON prestamo_libro.idAlumno = alumno.idAlumno "
                                   + "INNER JOIN carrera ON alumno.idCarrera = carrera.idCarrera "
                                   + "INNER JOIN libro ON prestamo_libro.idLibro = libro.idLibro "
                                   + "INNER JOIN categoria ON libro.idCategoria = categoria.idCategoria ";
                MySqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    GridReportePrestamos gridReportePrestamos = new GridReportePrestamos();
                    gridReportePrestamos.NombreLibro = reader.GetString("Libro");
                    gridReportePrestamos.NombreCategoria = reader.GetString("nombreCategoria");
                    gridReportePrestamos.NombreAlumno = reader.GetString("nombreAlumno");
                    gridReportePrestamos.ApellidoAlumno = reader.GetString("apellidoAlumno");
                    gridReportePrestamos.NCarnet = reader.GetInt32("nCarnet");
                    gridReportePrestamos.NombreCarrera = reader.GetString("nombreCarrera");
                    gridReportePrestamos.FechaPrestamo = reader.GetDateTime("fechaPrestamo");
                    gridReportePrestamos.FechaLimite = reader.GetDateTime("fechaLimite");
                    gridReportePrestamos.FechaEntrega = reader.GetDateTime("fechaEntrega");
                    gridReportePrestamos.PrestamoSolvente = reader.GetString("prestamoSolvente");
                    listReportePrestamos.Add(gridReportePrestamos);
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
            return listReportePrestamos;
        }

        /// <summary>
        /// Nos permite traer los datos de las moras, libro y alumno 
        /// con filtro de una morasCanceladas
        /// </summary>
        /// <returns>Retorna una lista con los datos extraidoss</returns>
        public List<GridReportePrestamos> allReportePrestamos(string prestamoSolvente)
        {
            List<GridReportePrestamos> listReportePrestamos = new List<GridReportePrestamos>();
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "SELECT libro.nombreLibro as Libro, categoria.nombreCategoria, alumno.nombreAlumno, "
                                   + "alumno.apellidoAlumno, alumno.nCarnet, carrera.nombreCarrera, "
                                   + "prestamo_libro.fechaPrestamo, prestamo_libro.fechaLimite, "
                                   + "prestamo_libro.fechaEntrega, prestamo_libro.prestamoSolvente "
                                   + "FROM prestamo_libro "
                                   + "INNER JOIN alumno ON prestamo_libro.idAlumno = alumno.idAlumno "
                                   + "INNER JOIN carrera ON alumno.idCarrera = carrera.idCarrera "
                                   + "INNER JOIN libro ON prestamo_libro.idLibro = libro.idLibro "
                                   + "INNER JOIN categoria ON libro.idCategoria = categoria.idCategoria "
                                   + "WHERE prestamo_libro.prestamoSolvente = @prestamoSolvente";
                comand.Prepare();
                comand.Parameters.AddWithValue("@prestamoSolvente", prestamoSolvente);
                MySqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    GridReportePrestamos gridReportePrestamos = new GridReportePrestamos();
                    gridReportePrestamos.NombreLibro = reader.GetString("Libro");
                    gridReportePrestamos.NombreCategoria = reader.GetString("nombreCategoria");
                    gridReportePrestamos.NombreAlumno = reader.GetString("nombreAlumno");
                    gridReportePrestamos.ApellidoAlumno = reader.GetString("apellidoAlumno");
                    gridReportePrestamos.NCarnet = reader.GetInt32("nCarnet");
                    gridReportePrestamos.NombreCarrera = reader.GetString("nombreCarrera");
                    gridReportePrestamos.FechaPrestamo = reader.GetDateTime("fechaPrestamo");
                    gridReportePrestamos.FechaLimite = reader.GetDateTime("fechaLimite");
                    gridReportePrestamos.FechaEntrega = reader.GetDateTime("fechaEntrega");
                    gridReportePrestamos.PrestamoSolvente = reader.GetString("prestamoSolvente");
                    listReportePrestamos.Add(gridReportePrestamos);
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
            return listReportePrestamos;
        }

        public List<GridReportePrestamos> allReportePrestamos(DateTime desde, DateTime hasta)
        {
            List<GridReportePrestamos> listReportePrestamos = new List<GridReportePrestamos>();
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "SELECT libro.nombreLibro as Libro, categoria.nombreCategoria, alumno.nombreAlumno, "
                                   + "alumno.apellidoAlumno, alumno.nCarnet, carrera.nombreCarrera, "
                                   + "prestamo_libro.fechaPrestamo, prestamo_libro.fechaLimite, "
                                   + "prestamo_libro.fechaEntrega, prestamo_libro.prestamoSolvente "
                                   + "FROM prestamo_libro "
                                   + "INNER JOIN alumno ON prestamo_libro.idAlumno = alumno.idAlumno "
                                   + "INNER JOIN carrera ON alumno.idCarrera = carrera.idCarrera "
                                   + "INNER JOIN libro ON prestamo_libro.idLibro = libro.idLibro "
                                   + "INNER JOIN categoria ON libro.idCategoria = categoria.idCategoria "
                                   + "WHERE prestamo_libro.fechaPrestamo BETWEEN @Desde AND @Hasta ";
                comand.Prepare();
                comand.Parameters.AddWithValue("@Desde", desde);
                comand.Parameters.AddWithValue("@Hasta", hasta);
                MySqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    GridReportePrestamos gridReportePrestamos = new GridReportePrestamos();
                    gridReportePrestamos.NombreLibro = reader.GetString("Libro");
                    gridReportePrestamos.NombreCategoria = reader.GetString("nombreCategoria");
                    gridReportePrestamos.NombreAlumno = reader.GetString("nombreAlumno");
                    gridReportePrestamos.ApellidoAlumno = reader.GetString("apellidoAlumno");
                    gridReportePrestamos.NCarnet = reader.GetInt32("nCarnet");
                    gridReportePrestamos.NombreCarrera = reader.GetString("nombreCarrera");
                    gridReportePrestamos.FechaPrestamo = reader.GetDateTime("fechaPrestamo");
                    gridReportePrestamos.FechaLimite = reader.GetDateTime("fechaLimite");
                    gridReportePrestamos.FechaEntrega = reader.GetDateTime("fechaEntrega");
                    gridReportePrestamos.PrestamoSolvente = reader.GetString("prestamoSolvente");
                    listReportePrestamos.Add(gridReportePrestamos);
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
            return listReportePrestamos;
        }

        public List<GridReportePrestamos> allReportePrestamos(DateTime desde, DateTime hasta, string solvente)
        {
            List<GridReportePrestamos> listReportePrestamos = new List<GridReportePrestamos>();
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "SELECT libro.nombreLibro as Libro, categoria.nombreCategoria, alumno.nombreAlumno, "
                                   + "alumno.apellidoAlumno, alumno.nCarnet, carrera.nombreCarrera, "
                                   + "prestamo_libro.fechaPrestamo, prestamo_libro.fechaLimite, "
                                   + "prestamo_libro.fechaEntrega, prestamo_libro.prestamoSolvente "
                                   + "FROM prestamo_libro "
                                   + "INNER JOIN alumno ON prestamo_libro.idAlumno = alumno.idAlumno "
                                   + "INNER JOIN carrera ON alumno.idCarrera = carrera.idCarrera "
                                   + "INNER JOIN libro ON prestamo_libro.idLibro = libro.idLibro "
                                   + "INNER JOIN categoria ON libro.idCategoria = categoria.idCategoria "
                                   + "WHERE prestamo_libro.fechaPrestamo BETWEEN @Desde AND @Hasta "
                                   + "AND prestamo_libro.prestamoSolvente = @solvente";
                comand.Prepare();
                comand.Parameters.AddWithValue("@Desde", desde);
                comand.Parameters.AddWithValue("@Hasta", hasta);
                comand.Parameters.AddWithValue("@solvente", solvente);
                MySqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    GridReportePrestamos gridReportePrestamos = new GridReportePrestamos();
                    gridReportePrestamos.NombreLibro = reader.GetString("Libro");
                    gridReportePrestamos.NombreCategoria = reader.GetString("nombreCategoria");
                    gridReportePrestamos.NombreAlumno = reader.GetString("nombreAlumno");
                    gridReportePrestamos.ApellidoAlumno = reader.GetString("apellidoAlumno");
                    gridReportePrestamos.NCarnet = reader.GetInt32("nCarnet");
                    gridReportePrestamos.NombreCarrera = reader.GetString("nombreCarrera");
                    gridReportePrestamos.FechaPrestamo = reader.GetDateTime("fechaPrestamo");
                    gridReportePrestamos.FechaLimite = reader.GetDateTime("fechaLimite");
                    gridReportePrestamos.FechaEntrega = reader.GetDateTime("fechaEntrega");
                    gridReportePrestamos.PrestamoSolvente = reader.GetString("prestamoSolvente");
                    listReportePrestamos.Add(gridReportePrestamos);
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
            return listReportePrestamos;
        }
    }
}
