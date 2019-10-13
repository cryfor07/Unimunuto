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
    class DaoEditorialImp : Cnn, DaoEditorial
    {

        MySqlConnection Con = null; 
        MySqlCommand comand = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="editorial"></param>
        public void addEditorial(Editorial editorial)
        {
            
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "INSERT INTO editorial (idEditorial, nombreEditorial) VALUES(null, @nombreEditorial)";
                comand.Prepare();
                comand.Parameters.AddWithValue("@nombreEditorial", editorial.NombreEditorial);
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
        /// <param name="editorial"></param>
        public void deleteEditorial(Editorial editorial)
        {
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "DELETE FROM editorial WHERE idEditorial = @idEditorial";
                comand.Prepare();
                comand.Parameters.AddWithValue("@idEditorial", editorial.IdEditorial);
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
        /// 
        /// </summary>
        /// <param name="editorial"></param>
        public void updateEditorial(Editorial editorial)
        {
            try
            {
                Con = openBd();
                comand = Con.CreateCommand(); 
                comand.CommandText = "UPDATE editorial SET nombreEditorial = @nombreEditorial WHERE idEditorial = @idEditorial";
                comand.Prepare();
                comand.Parameters.AddWithValue("@nombreEditorial", editorial.NombreEditorial);
                comand.Parameters.AddWithValue("@idEditorial", editorial.IdEditorial);
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Editorial> allEditorial()
        {
            List<Editorial> listaEditorial = new List<Editorial>();
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "SELECT * FROM editorial";
                MySqlDataReader reader = comand.ExecuteReader();

                while (reader.Read())
                {
                    Editorial edito = new Editorial();
                    edito.IdEditorial = reader.GetInt16(0);
                    edito.NombreEditorial = reader.GetString(1);
                    listaEditorial.Add(edito);
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
            return listaEditorial;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreEditorial"></param>
        /// <returns></returns>
        public List<Editorial> allEditorial(string nombreEditorial)
        {
            List<Editorial> listaEditorial = new List<Editorial>();
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "SELECT * FROM editorial "
                                   + "WHERE nombreEditorial LIKE '%' @nombreEditorial '%' ";
                comand.Prepare();
                comand.Parameters.AddWithValue("@nombreEditorial", nombreEditorial);
                MySqlDataReader reader = comand.ExecuteReader();

                while (reader.Read())
                {
                    Editorial edito = new Editorial();
                    edito.IdEditorial = reader.GetInt16(0);
                    edito.NombreEditorial = reader.GetString(1);
                    listaEditorial.Add(edito);
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
            return listaEditorial;
        }
    }
}
