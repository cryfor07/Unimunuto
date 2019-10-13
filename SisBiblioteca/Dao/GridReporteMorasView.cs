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
    public class GridReporteMorasView : Cnn
    {
        MySqlConnection Con = null;
        MySqlCommand comand = null;

        /// <summary>
        /// Nos permite traer los datos de las moras, libro y alumno 
        /// que estan insolventes
        /// </summary>
        /// <returns>Retorna una lista con los datos extraidoss</returns>
        public List<GridReporteMoras> allReporteMoras()
        {
            List<GridReporteMoras> listReporteMoras = new List<GridReporteMoras>();
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "SELECT libro.nombreLibro AS 'Libro', categoria.nombreCategoria AS 'Categoria', "
                                   + "alumno.nombreAlumno AS 'Nombre', alumno.apellidoAlumno AS 'Apellido', "
                                   + "alumno.nCarnet, carrera.nombreCarrera AS 'Carrera', prestamo_libro.fechaPrestamo, "
                                   + "prestamo_libro.fechaLimite, prestamo_libro.fechaEntrega, mora.moraCancelada, "
                                   + "mora.fechaPagoMora "
                                   + "from mora "
                                   + "INNER JOIN prestamo_libro ON mora.idPrestamoLibro = prestamo_libro.idPrestamoLibro "
                                   + "INNER JOIN libro ON prestamo_libro.idLibro = libro.idLibro "
                                   + "INNER JOIN alumno ON prestamo_libro.idAlumno = alumno.idAlumno "
                                   + "INNER JOIN carrera ON alumno.idCarrera = carrera.idCarrera "
                                   + "INNER JOIN categoria ON libro.idCategoria = categoria.idCategoria ";
                MySqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    GridReporteMoras gridReporteMoras = new GridReporteMoras();
                    gridReporteMoras.NombreLibro = reader.GetString("Libro");
                    gridReporteMoras.NombreCategoria = reader.GetString("Categoria");
                    gridReporteMoras.NombreAlumno = reader.GetString("Nombre");
                    gridReporteMoras.ApellidoAlumno = reader.GetString("Apellido");
                    gridReporteMoras.NCarnet = reader.GetInt32("nCarnet");
                    gridReporteMoras.NombreCarrera = reader.GetString("Carrera");
                    gridReporteMoras.FechaPrestamo = reader.GetDateTime("fechaPrestamo");
                    gridReporteMoras.FechaLimite = reader.GetDateTime("fechaLimite");
                    gridReporteMoras.FechaEntrega = reader.GetDateTime("fechaEntrega");
                    gridReporteMoras.MoraCancelada = reader.GetString("moraCancelada");
                    gridReporteMoras.FechaPagoMora = reader.GetDateTime("fechaPagoMora");
                    listReporteMoras.Add(gridReporteMoras);
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
            return listReporteMoras;
        }

        /// <summary>
        /// Nos permite traer los datos de las moras, libro y alumno 
        /// con filtro de una morasCanceladas
        /// </summary>
        /// <returns>Retorna una lista con los datos extraidoss</returns>
        public List<GridReporteMoras> allReporteMoras(string Cancelada)
        {
            List<GridReporteMoras> listReporteMoras = new List<GridReporteMoras>();
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "SELECT libro.nombreLibro AS 'Libro', categoria.nombreCategoria AS 'Categoria', "
                                   + "alumno.nombreAlumno AS 'Nombre', alumno.apellidoAlumno AS 'Apellido', "
                                   + "alumno.nCarnet, carrera.nombreCarrera AS 'Carrera', prestamo_libro.fechaPrestamo, "
                                   + "prestamo_libro.fechaLimite, prestamo_libro.fechaEntrega, mora.moraCancelada, "
                                   + "mora.fechaPagoMora "
                                   + "from mora "
                                   + "INNER JOIN prestamo_libro ON mora.idPrestamoLibro = prestamo_libro.idPrestamoLibro "
                                   + "INNER JOIN libro ON prestamo_libro.idLibro = libro.idLibro "
                                   + "INNER JOIN alumno ON prestamo_libro.idAlumno = alumno.idAlumno "
                                   + "INNER JOIN carrera ON alumno.idCarrera = carrera.idCarrera "
                                   + "INNER JOIN categoria ON libro.idCategoria = categoria.idCategoria "
                                   + "WHERE mora.moraCancelada = @Cancelada";
                comand.Prepare();
                comand.Parameters.AddWithValue("@Cancelada", Cancelada);
                MySqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    GridReporteMoras gridReporteMoras = new GridReporteMoras();
                    gridReporteMoras.NombreLibro = reader.GetString("Libro");
                    gridReporteMoras.NombreCategoria = reader.GetString("Categoria");
                    gridReporteMoras.NombreAlumno = reader.GetString("Nombre");
                    gridReporteMoras.ApellidoAlumno = reader.GetString("Apellido");
                    gridReporteMoras.NCarnet = reader.GetInt32("nCarnet");
                    gridReporteMoras.NombreCarrera = reader.GetString("Carrera");
                    gridReporteMoras.FechaPrestamo = reader.GetDateTime("fechaPrestamo");
                    gridReporteMoras.FechaLimite = reader.GetDateTime("fechaLimite");
                    gridReporteMoras.FechaEntrega = reader.GetDateTime("fechaEntrega");
                    gridReporteMoras.MoraCancelada = reader.GetString("moraCancelada");
                    gridReporteMoras.FechaPagoMora = reader.GetDateTime("fechaPagoMora");
                    listReporteMoras.Add(gridReporteMoras);
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
            return listReporteMoras;
        }

        /// <summary>
        /// Nos permite traer los datos de las moras, libro y alumno 
        /// con filtro de una morasCanceladas en un rango de 2 fechas
        /// </summary>
        /// <returns>Retorna una lista con los datos extraidoss</returns>
        public List<GridReporteMoras> allReporteMoras(DateTime desde, DateTime hasta)
        {
            //string Desde = desde.ToShortDateString();
            //string Hasta = hasta.ToShortDateString();

            List<GridReporteMoras> listReporteMoras = new List<GridReporteMoras>();
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "SELECT libro.nombreLibro AS 'Libro', categoria.nombreCategoria AS 'Categoria', "
                                   + "alumno.nombreAlumno AS 'Nombre', alumno.apellidoAlumno AS 'Apellido', "
                                   + "alumno.nCarnet, carrera.nombreCarrera AS 'Carrera', prestamo_libro.fechaPrestamo, "
                                   + "prestamo_libro.fechaLimite, prestamo_libro.fechaEntrega, mora.moraCancelada, "
                                   + "mora.fechaPagoMora "
                                   + "from mora "
                                   + "INNER JOIN prestamo_libro ON mora.idPrestamoLibro = prestamo_libro.idPrestamoLibro "
                                   + "INNER JOIN libro ON prestamo_libro.idLibro = libro.idLibro "
                                   + "INNER JOIN alumno ON prestamo_libro.idAlumno = alumno.idAlumno "
                                   + "INNER JOIN carrera ON alumno.idCarrera = carrera.idCarrera "
                                   + "INNER JOIN categoria ON libro.idCategoria = categoria.idCategoria "
                                   + "WHERE "
                                   + "prestamo_libro.fechaEntrega BETWEEN @Desde AND @Hasta ";
                comand.Prepare();
                comand.Parameters.AddWithValue("@Desde", desde);
                comand.Parameters.AddWithValue("@Hasta", hasta);
                MySqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    GridReporteMoras gridReporteMoras = new GridReporteMoras();
                    gridReporteMoras.NombreLibro = reader.GetString("Libro");
                    gridReporteMoras.NombreCategoria = reader.GetString("Categoria");
                    gridReporteMoras.NombreAlumno = reader.GetString("Nombre");
                    gridReporteMoras.ApellidoAlumno = reader.GetString("Apellido");
                    gridReporteMoras.NCarnet = reader.GetInt32("nCarnet");
                    gridReporteMoras.NombreCarrera = reader.GetString("Carrera");
                    gridReporteMoras.FechaPrestamo = reader.GetDateTime("fechaPrestamo");
                    gridReporteMoras.FechaLimite = reader.GetDateTime("fechaLimite");
                    gridReporteMoras.FechaEntrega = reader.GetDateTime("fechaEntrega");
                    gridReporteMoras.MoraCancelada = reader.GetString("moraCancelada");
                    gridReporteMoras.FechaPagoMora = reader.GetDateTime("fechaPagoMora");
                    listReporteMoras.Add(gridReporteMoras);
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
            return listReporteMoras;
        }

        /// <summary>
        /// Nos permite traer los datos de las moras, libro y alumno 
        /// con filtro de una morasCanceladas en un rango de 2 fechas
        /// </summary>
        /// <returns>Retorna una lista con los datos extraidoss</returns>
        public List<GridReporteMoras> allReporteMoras(DateTime desde, DateTime hasta, string Cancelada)
        {
            //string Desde = desde.ToShortDateString();
            //string Hasta = hasta.ToShortDateString();
            List<GridReporteMoras> listReporteMoras = new List<GridReporteMoras>();
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "SELECT libro.nombreLibro AS 'Libro', categoria.nombreCategoria AS 'Categoria', "
                                   + "alumno.nombreAlumno AS 'Nombre', alumno.apellidoAlumno AS 'Apellido', "
                                   + "alumno.nCarnet, carrera.nombreCarrera AS 'Carrera', prestamo_libro.fechaPrestamo, "
                                   + "prestamo_libro.fechaLimite, prestamo_libro.fechaEntrega, mora.moraCancelada, "
                                   + "mora.fechaPagoMora "
                                   + "FROM mora "
                                   + "INNER JOIN prestamo_libro ON mora.idPrestamoLibro = prestamo_libro.idPrestamoLibro "
                                   + "INNER JOIN libro ON prestamo_libro.idLibro = libro.idLibro "
                                   + "INNER JOIN alumno ON prestamo_libro.idAlumno = alumno.idAlumno "
                                   + "INNER JOIN carrera ON alumno.idCarrera = carrera.idCarrera "
                                   + "INNER JOIN categoria ON libro.idCategoria = categoria.idCategoria "
                                   + "WHERE prestamo_libro.fechaEntrega BETWEEN @Desde AND @Hasta "
                                   + "AND mora.moraCancelada = @Cancelada ";
                comand.Prepare();
                comand.Parameters.AddWithValue("@Cancelada", Cancelada);
                comand.Parameters.AddWithValue("@Desde", desde);
                comand.Parameters.AddWithValue("@Hasta", hasta);
                MySqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    GridReporteMoras gridReporteMoras = new GridReporteMoras();
                    gridReporteMoras.NombreLibro = reader.GetString("Libro");
                    gridReporteMoras.NombreCategoria = reader.GetString("Categoria");
                    gridReporteMoras.NombreAlumno = reader.GetString("Nombre");
                    gridReporteMoras.ApellidoAlumno = reader.GetString("Apellido");
                    gridReporteMoras.NCarnet = reader.GetInt32("nCarnet");
                    gridReporteMoras.NombreCarrera = reader.GetString("Carrera");
                    gridReporteMoras.FechaPrestamo = reader.GetDateTime("fechaPrestamo");
                    gridReporteMoras.FechaLimite = reader.GetDateTime("fechaLimite");
                    gridReporteMoras.FechaEntrega = reader.GetDateTime("fechaEntrega");
                    gridReporteMoras.MoraCancelada = reader.GetString("moraCancelada");
                    gridReporteMoras.FechaPagoMora = reader.GetDateTime("fechaPagoMora");
                    listReporteMoras.Add(gridReporteMoras);
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
            return listReporteMoras;
        }
    }
}