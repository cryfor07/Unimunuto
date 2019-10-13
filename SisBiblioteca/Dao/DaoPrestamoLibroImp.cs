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
    class DaoPrestamoLibroImp : Cnn, DaoPrestamoLibro
    {
        MySqlConnection Con = null;
        MySqlCommand comand = null;

        /// <summary>
        /// Función que realiza la incerción de los datos,
        /// menos la fecha de entrega en la tabla prestamo_libro
        /// </summary>
        /// <param name="prestamoLibro"></param>
        public void addPrestamoLibro(PrestamoLibro prestamoLibro)
        {
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "INSERT INTO prestamo_libro(idPrestamoLibro, idAlumno, "
                       + "idLibro, fechaPrestamo, prestamoSolvente, fechaLimite) "
                       + "VALUES (null, @idAlumno, "
                       + "@idLibro, @fechaPrestamo, @prestamoSolvente, @fechaLimite)";
                comand.Prepare();
                comand.Parameters.AddWithValue("@idAlumno", prestamoLibro.Alumno.IdAlumno);
                comand.Parameters.AddWithValue("@idLibro", prestamoLibro.Libro.IdLibro);
                comand.Parameters.AddWithValue("@fechaPrestamo", prestamoLibro.FechaPrestamo);
                comand.Parameters.AddWithValue("@prestamoSolvente", prestamoLibro.PrestamoSolvente);
                comand.Parameters.AddWithValue("@fechaLimite", prestamoLibro.FechaLimite);
                comand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("El error es " + ex);
            }
            finally
            {
                closeBd();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prestamoLibro"></param>
        public void updatePrestamooLibro(PrestamoLibro prestamoLibro)
        {
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "UPDATE prestamo_libro "
                                   + "SET prestamoSolvente = 'Solvente', fechaEntrega = @fechaEntrega "
                                   + "WHERE idPrestamoLibro = @idPrestamoLibro";
                comand.Prepare();
                comand.Parameters.AddWithValue("@fechaEntrega", prestamoLibro.FechaEntrega);
                comand.Parameters.AddWithValue("@idPrestamoLibro", prestamoLibro.IdPrestamoLibro);
                comand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede actualizar por: " + ex);
            }
            finally
            {
                closeBd();
            }
        }

        public int comparaFechaLiminiteEntrega(PrestamoLibro prestamoLibro)
        {
            int cantidad = 0;
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "SELECT COUNT(prestamo_libro.idPrestamoLibro) as 'cantidad'"
                                    + "FROM prestamo_libro "
                                    + "WHERE fechaEntrega BETWEEN fechaPrestamo AND fechaLimite "
                                    + "AND idPrestamoLibro = @idPrestamoLibro ";
                comand.Prepare();
                comand.Parameters.AddWithValue("@idPrestamoLibro", prestamoLibro.IdPrestamoLibro);
                MySqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    cantidad = reader.GetInt16("cantidad");
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
            return cantidad;
        }

        public int CuentaMorasAlumnoSinPagar(PrestamoLibro prestamoLibro)
        {
            int cantidad = 0;
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "SELECT COUNT(alumno.idAlumno) AS 'cantidadMoras' "
                                   + "FROM prestamo_libro "
                                   + "INNER JOIN alumno ON prestamo_libro.idAlumno = alumno.idAlumno "
                                   + "INNER JOIN mora ON mora.idPrestamoLibro = prestamo_libro.idPrestamoLibro "
                                   + "WHERE mora.moraCancelada = 'No' "
                                   + "AND alumno.idAlumno = @idAlumno ";
                comand.Prepare();
                comand.Parameters.AddWithValue("@idAlumno", prestamoLibro.Alumno.IdAlumno);
                MySqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    cantidad = reader.GetInt16("cantidadMoras");
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
            return cantidad;
        }
    }
}
