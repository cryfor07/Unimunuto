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
    class GridViewMoras : Cnn
    {
        MySqlConnection Con = null;
        MySqlCommand comand = null;

        /// <summary>
        /// Nos permite traer los datos de las moras, libro y alumno 
        /// que estan insolventes
        /// </summary>
        /// <returns>Retorna una lista con los datos extraidoss</returns>
        public List<GridMoras> allMorasInsolventes()
        {
            List<GridMoras> listMorasInsolventes = new List<GridMoras>();
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "SELECT mora.idMora, alumno.nombreAlumno, alumno.apellidoAlumno, alumno.nCarnet, "
                                   + "libro.nombreLibro, mora.cantidadMora, prestamo_libro.fechaPrestamo, "
                                   + "prestamo_libro.fechaEntrega, prestamo_libro.fechaLimite, mora.moraCancelada, "
                                   + "mora.fechaPagoMora "
                                   + "FROM libro "
                                   + "INNER JOIN prestamo_libro ON prestamo_libro.idLibro = libro.idLibro "
                                   + "INNER JOIN alumno ON prestamo_libro.idAlumno = alumno.idAlumno "
                                   + "INNER JOIN mora ON mora.idPrestamoLibro = prestamo_libro.idPrestamoLibro "
                                   + "WHERE mora.moraCancelada = 'No' ";
                MySqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    GridMoras gridMoras = new GridMoras();
                    gridMoras.IdMora = reader.GetInt16("idMora");
                    gridMoras.NombreAlumno = reader.GetString("nombreAlumno");
                    gridMoras.ApellidoAlumno = reader.GetString("apellidoAlumno");
                    gridMoras.NCarnet = reader.GetInt32("nCarnet");
                    gridMoras.NombreLibro = reader.GetString("nombreLibro");
                    gridMoras.CantidadMora = reader.GetDouble("cantidadMora");
                    gridMoras.FechaPrestamo = reader.GetDateTime("fechaPrestamo");
                    gridMoras.FechaEntrega = reader.GetDateTime("fechaEntrega");
                    gridMoras.FechaLimite = reader.GetDateTime("fechaLimite");
                    gridMoras.MoraCancelada = reader.GetString("moraCancelada");
                    gridMoras.FechaPagoMora = reader.GetDateTime("fechaPagoMora");
                    listMorasInsolventes.Add(gridMoras);
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
            return listMorasInsolventes;
        }

        /// <summary>
        /// Nos permite traer los datos de las moras, libro y alumno 
        /// que estan insolventes pero se realiza busqueda por en ncarnet alumno
        /// </summary>
        /// <returns>Retorna una lista con los datos extraidoss</returns>
        public List<GridMoras> allMorasInsolventes(string ncarnet)
        {
            List<GridMoras> listMorasInsolventes = new List<GridMoras>();
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "SELECT mora.idMora, alumno.nombreAlumno, alumno.apellidoAlumno, alumno.nCarnet, "
                                   + "libro.nombreLibro, mora.cantidadMora, prestamo_libro.fechaPrestamo, "
                                   + "prestamo_libro.fechaEntrega, prestamo_libro.fechaLimite, mora.moraCancelada, "
                                   + "mora.fechaPagoMora "
                                   + "FROM libro "
                                   + "INNER JOIN prestamo_libro ON prestamo_libro.idLibro = libro.idLibro "
                                   + "INNER JOIN alumno ON prestamo_libro.idAlumno = alumno.idAlumno "
                                   + "INNER JOIN mora ON mora.idPrestamoLibro = prestamo_libro.idPrestamoLibro "
                                   + "WHERE mora.moraCancelada = 'No' "
                                   + "AND alumno.nCarnet LIKE '%' @nCarnet '%' ";
                comand.Prepare();
                comand.Parameters.AddWithValue("@nCarnet", ncarnet);
                MySqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    GridMoras gridMoras = new GridMoras();
                    gridMoras.IdMora = reader.GetInt16("idMora");
                    gridMoras.NombreAlumno = reader.GetString("nombreAlumno");
                    gridMoras.ApellidoAlumno = reader.GetString("apellidoAlumno");
                    gridMoras.NCarnet = reader.GetInt32("nCarnet");
                    gridMoras.NombreLibro = reader.GetString("nombreLibro");
                    gridMoras.CantidadMora = reader.GetDouble("cantidadMora");
                    gridMoras.FechaPrestamo = reader.GetDateTime("fechaPrestamo");
                    gridMoras.FechaEntrega = reader.GetDateTime("fechaEntrega");
                    gridMoras.FechaLimite = reader.GetDateTime("fechaLimite");
                    gridMoras.MoraCancelada = reader.GetString("moraCancelada");
                    gridMoras.FechaPagoMora = reader.GetDateTime("fechaPagoMora");
                    listMorasInsolventes.Add(gridMoras);
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
            return listMorasInsolventes;
        }

        /// <summary>
        /// Nos permite traer los datos de las moras, libro y alumno 
        /// que estan solventes
        /// </summary>
        /// <returns>Retorna una lista con los datos extraidoss</returns>
        public List<GridMoras> allMorasSolventes()
        {
            List<GridMoras> listMorasSolventes = new List<GridMoras>();
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "SELECT mora.idMora, alumno.nombreAlumno, alumno.apellidoAlumno, alumno.nCarnet, "
                                   + "libro.nombreLibro, mora.cantidadMora, prestamo_libro.fechaPrestamo, "
                                   + "prestamo_libro.fechaEntrega, prestamo_libro.fechaLimite, mora.moraCancelada, "
                                   + "mora.fechaPagoMora "
                                   + "FROM libro "
                                   + "INNER JOIN prestamo_libro ON prestamo_libro.idLibro = libro.idLibro "
                                   + "INNER JOIN alumno ON prestamo_libro.idAlumno = alumno.idAlumno "
                                   + "INNER JOIN mora ON mora.idPrestamoLibro = prestamo_libro.idPrestamoLibro "
                                   + "WHERE mora.moraCancelada = 'Si' ";
                MySqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    GridMoras gridMoras = new GridMoras();
                    gridMoras.IdMora = reader.GetInt16("idMora");
                    gridMoras.NombreAlumno = reader.GetString("nombreAlumno");
                    gridMoras.ApellidoAlumno = reader.GetString("apellidoAlumno");
                    gridMoras.NCarnet = reader.GetInt32("nCarnet");
                    gridMoras.NombreLibro = reader.GetString("nombreLibro");
                    gridMoras.CantidadMora = reader.GetDouble("cantidadMora");
                    gridMoras.FechaPrestamo = reader.GetDateTime("fechaPrestamo");
                    gridMoras.FechaEntrega = reader.GetDateTime("fechaEntrega");
                    gridMoras.FechaLimite = reader.GetDateTime("fechaLimite");
                    gridMoras.MoraCancelada = reader.GetString("moraCancelada");
                    gridMoras.FechaPagoMora = reader.GetDateTime("fechaPagoMora");
                    listMorasSolventes.Add(gridMoras);
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
            return listMorasSolventes;
        }

        /// <summary>
        /// Nos permite traer los datos de las moras, libro y alumno 
        /// que estan solventes pero se realiza busqueda por en ncarnet alumno
        /// </summary>
        /// <returns>Retorna una lista con los datos extraidoss</returns>
        public List<GridMoras> allMorasSolventes(string ncarnet)
        {
            List<GridMoras> listMorasSolventes = new List<GridMoras>();
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "SELECT mora.idMora, alumno.nombreAlumno, alumno.apellidoAlumno, alumno.nCarnet, "
                                   + "libro.nombreLibro, mora.cantidadMora, prestamo_libro.fechaPrestamo, "
                                   + "prestamo_libro.fechaEntrega, prestamo_libro.fechaLimite, mora.moraCancelada, "
                                   + "mora.fechaPagoMora "
                                   + "FROM libro "
                                   + "INNER JOIN prestamo_libro ON prestamo_libro.idLibro = libro.idLibro "
                                   + "INNER JOIN alumno ON prestamo_libro.idAlumno = alumno.idAlumno "
                                   + "INNER JOIN mora ON mora.idPrestamoLibro = prestamo_libro.idPrestamoLibro "
                                   + "WHERE mora.moraCancelada = 'Si' "
                                   + "AND alumno.nCarnet LIKE '%' @nCarnet '%' ";
                comand.Prepare();
                comand.Parameters.AddWithValue("@nCarnet", ncarnet);
                MySqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    GridMoras gridMoras = new GridMoras();
                    gridMoras.IdMora = reader.GetInt16("idMora");
                    gridMoras.NombreAlumno = reader.GetString("nombreAlumno");
                    gridMoras.ApellidoAlumno = reader.GetString("apellidoAlumno");
                    gridMoras.NCarnet = reader.GetInt32("nCarnet");
                    gridMoras.NombreLibro = reader.GetString("nombreLibro");
                    gridMoras.CantidadMora = reader.GetDouble("cantidadMora");
                    gridMoras.FechaPrestamo = reader.GetDateTime("fechaPrestamo");
                    gridMoras.FechaEntrega = reader.GetDateTime("fechaEntrega");
                    gridMoras.FechaLimite = reader.GetDateTime("fechaLimite");
                    gridMoras.MoraCancelada = reader.GetString("moraCancelada");
                    gridMoras.FechaPagoMora = reader.GetDateTime("fechaPagoMora");
                    listMorasSolventes.Add(gridMoras);
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
            return listMorasSolventes;
        }
    }
}
