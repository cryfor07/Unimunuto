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
    class DaoAutorImp : Cnn, DaoAutor
    {
        MySqlConnection Con = null;
        MySqlCommand comand = null;

        /// <summary>
        /// Función que genera un INSERT en la tabla autor
        /// </summary>
        /// <param name="autor">Objeto creado al instancia de la clase autor</param>
        public void addAutor(Autor autor)
        {
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "INSERT INTO autor(idAutor, nombreAutor) VALUES (null, @nombreAutor)";
                comand.Prepare();
                comand.Parameters.AddWithValue("@nombreAutor", autor.NombreAutor);
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
        public List<Autor> allAutor()
        {
            List<Autor> listAutor = new List<Autor>();
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "SELECT * FROM autor";
                MySqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    Autor autor = new Autor();
                    autor.IdAutor = reader.GetInt16(0);
                    autor.NombreAutor = reader.GetString(1);
                    listAutor.Add(autor);
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
            return listAutor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreAutor"></param>
        /// <returns></returns>
        public List<Autor> allAutor(string nombreAutor)
        {
            List<Autor> listAutor = new List<Autor>();
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "SELECT * FROM autor "
                                   + "WHERE nombreAutor LIKE '%' @nombreAutor '%' ";
                comand.Prepare();
                comand.Parameters.AddWithValue("@nombreAutor", nombreAutor);
                MySqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    Autor autor = new Autor();
                    autor.IdAutor = reader.GetInt16(0);
                    autor.NombreAutor = reader.GetString(1);
                    listAutor.Add(autor);
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
            return listAutor;
        }

        /// <summary>
        /// Función que genera un DELETE en la tabla autor dependiendo de un id que reciba
        /// </summary>
        /// <param name="autor">Objeto creado al instancia de la clase autor</param>
        public void deleteAutor(Autor autor)
        {
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "DELETE FROM autor WHERE idAutor = @idAutor";
                comand.Prepare();
                comand.Parameters.AddWithValue("@idAutor", autor.IdAutor);
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
        /// Función que genera un UPDATE en la tabla autor dependiendo de un id que reciba
        /// </summary>
        /// <param name="autor">Objeto creado al instancia de la clase autor</param>
        public void updateAutor(Autor autor)
        {
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "UPDATE autor SET nombreAutor= @nombreAutor WHERE idAutor = @idAutor";
                comand.Prepare();
                comand.Parameters.AddWithValue("@nombreAutor", autor.NombreAutor);
                comand.Parameters.AddWithValue("@idAutor", autor.IdAutor);
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
