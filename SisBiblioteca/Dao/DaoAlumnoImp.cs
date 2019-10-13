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
    public class DaoAlumnoImp : Cnn, DaoAlumno
    {
        MySqlConnection Con = null;
        MySqlCommand comand = null;

        /// <summary>
        /// Función que genera un INSERT en la tabla alumno
        /// </summary>
        /// <param name="alumno">Objeto creado al instancia de la clase alumno</param>
        public void addAlumno(Alumno alumno)
        {
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "INSERT INTO alumno(idAlumno, nombreAlumno, apellidoAlumno, nCarnet, idCarrera, genero) "
                    +"VALUES (null, @nombreAlumno, @apellidoAlumno, @nCarnet, @idCarrera, @genero)";
                comand.Prepare();
                comand.Parameters.AddWithValue("@nombreAlumno", alumno.NombreAlumno);
                comand.Parameters.AddWithValue("@apellidoAlumno", alumno.ApellidoAlumno);
                comand.Parameters.AddWithValue("@nCarnet", alumno.NCarnet);
                comand.Parameters.AddWithValue("@idCarrera", alumno.Carrera.IdCarrera);
                comand.Parameters.AddWithValue("@genero", alumno.Genero);
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
        /// Función que enlista todos los datos de la tabla alumno
        /// </summary>
        /// <returns>Retorna una lista con todos los datos extraidos de la tabla</returns>
        public List<Alumno> allAlumno()
        {
            List<Alumno> listAlumno = new List<Alumno>();
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "SELECT alumno.idAlumno, alumno.nombreAlumno, alumno.apellidoAlumno, "
                                    + "alumno.nCarnet, alumno.genero, carrera.nombreCarrera "
                                    + "FROM alumno INNER JOIN carrera ON alumno.idCarrera = carrera.idCarrera";
                MySqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    Alumno alumno = new Alumno();
                    alumno.IdAlumno = reader.GetInt16("idAlumno");
                    alumno.NombreAlumno = reader.GetString("nombreAlumno");
                    alumno.ApellidoAlumno = reader.GetString("apellidoAlumno");
                    alumno.NCarnet = reader.GetInt32("nCarnet");
                    alumno.Genero = reader.GetString("genero");
                    alumno.Carrera.NombreCarrera = reader.GetString("nombreCarrera");
                    listAlumno.Add(alumno);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede agregar por " + ex); ;
            }
            finally
            {
                closeBd();
            }
            return listAlumno;
        }

        /// <summary>
        /// Función que buscara el alumno con el N° de canet que se ingrese en la tabla alumno
        /// </summary>
        /// <param name="nCarnet">Numero de carnet para realizar la busqueda en la Query </param>
        /// <returns></returns>
        public List<Alumno> allAlumno(string nCarnet)
        {
            List<Alumno> listAlumno = new List<Alumno>();
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "SELECT alumno.idAlumno, alumno.nombreAlumno, alumno.apellidoAlumno, "
                                   + "alumno.nCarnet, alumno.genero, carrera.nombreCarrera "
                                   + "FROM alumno INNER JOIN carrera ON alumno.idCarrera = carrera.idCarrera "
                                   + "AND alumno.nCarnet LIKE '%' @nCarnet '%' ";
                comand.Prepare();
                comand.Parameters.AddWithValue("@nCarnet", nCarnet);
                MySqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    Alumno alumno = new Alumno();
                    alumno.IdAlumno = reader.GetInt16("idAlumno");
                    alumno.NombreAlumno = reader.GetString("nombreAlumno");
                    alumno.ApellidoAlumno = reader.GetString("apellidoAlumno");
                    alumno.NCarnet = reader.GetInt32("nCarnet");
                    alumno.Genero = reader.GetString("genero");
                    alumno.Carrera.NombreCarrera = reader.GetString("nombreCarrera");
                    listAlumno.Add(alumno);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede agregar por " + ex); ;
            }
            finally
            {
                closeBd();
            }
            return listAlumno;
        }

        /// <summary>
        /// Funcion que nos genera un DELETE en la tabla alumnos
        /// </summary>
        /// <param name="alumno">Objeto creado al instancia de la clase alumno</param>
        public void deleteAlumno(Alumno alumno)
        {
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "DELETE FROM alumno WHERE idAlumno = @idAlumno";
                comand.Prepare();
                comand.Parameters.AddWithValue("@idAlumno", alumno.IdAlumno);
                comand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede eliminar por: " + ex);
            }
            finally
            {
                closeBd();
            }
        }

        /// <summary>
        /// Funcion que nos genera un UPDATE en la tabla alumnos
        /// </summary>
        /// <param name="alumno">Objeto creado al instancia de la clase alumno</param>
        public void updateAlumno(Alumno alumno)
        {
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "UPDATE alumno SET nombreAlumno = @nombreAlumno, "
                                    + "apellidoAlumno = @apellidoAlumno, idCarrera = @idCarrera, "
                                    + "genero = @genero WHERE idAlumno = @idAlumno ";
                comand.Prepare();
                comand.Parameters.AddWithValue("@nombreAlumno",alumno.NombreAlumno);
                comand.Parameters.AddWithValue("@apellidoAlumno", alumno.ApellidoAlumno);
                comand.Parameters.AddWithValue("@idCarrera", alumno.Carrera.IdCarrera);
                comand.Parameters.AddWithValue("@genero", alumno.Genero);
                comand.Parameters.AddWithValue("@idAlumno", alumno.IdAlumno);
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



    }
    
}
