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
    class DaoCategoriaImp : Cnn, DaoCategoria
    {
        MySqlConnection Con = null;
        MySqlCommand comand = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoria"></param>
        public void addCategoria(Categoria categoria)
        {
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "INSERT INTO categoria(idCategoria, nombreCategoria) VALUES (null, @nombreCategoria)";
                comand.Prepare();
                comand.Parameters.AddWithValue("@nombreCategoria", categoria.NombreCategoria);
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
        /// <returns></returns>
        public List<Categoria> allCategoria()
        {
            List<Categoria> listCategoria = new List<Categoria>();
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "SELECT * FROM categoria";
                MySqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.IdCategoria = reader.GetInt16(0);
                    categoria.NombreCategoria = reader.GetString(1);
                    listCategoria.Add(categoria);
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
            return listCategoria;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreCategoria"></param>
        /// <returns></returns>
        public List<Categoria> allCategoria(string nombreCategoria)
        {
            List<Categoria> listCategoria = new List<Categoria>();
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "SELECT * FROM categoria "
                                   + "WHERE nombreCategoria LIKE '%' @nombreCategoria '%' ";
                comand.Prepare();
                comand.Parameters.AddWithValue("@nombreCategoria", nombreCategoria);
                MySqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    Categoria categoria = new Categoria();
                    categoria.IdCategoria = reader.GetInt16(0);
                    categoria.NombreCategoria = reader.GetString(1);
                    listCategoria.Add(categoria);
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
            return listCategoria;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoria"></param>
        public void deleteCategoria(Categoria categoria)
        {
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "DELETE FROM categoria WHERE idCategoria = @idCategoria";
                comand.Prepare();
                comand.Parameters.AddWithValue("@idCategoria", categoria.IdCategoria);
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
        /// <param name="categoria"></param>
        public void updateCategoria(Categoria categoria)
        {
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "UPDATE categoria SET nombreCategoria = @nombreCategoria  WHERE idCategoria = @idCategoria";
                comand.Prepare();
                comand.Parameters.AddWithValue("@nombreCategoria", categoria.NombreCategoria);
                comand.Parameters.AddWithValue("@idCategoria", categoria.IdCategoria);
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
