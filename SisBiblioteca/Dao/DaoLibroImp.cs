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
    class DaoLibroImp : Cnn, DaoLibro
    {
        MySqlConnection Con = null;
        MySqlCommand comand = null;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="libro"></param>
        public void addLibro(Libro libro)
        {
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "INSERT INTO libro(idLibro, nombreLibro, idEditorial, "
                       + "anio, idCategoria, descripcion, "
                       + "idAutor) VALUES (null, @nombreLibro, @idEditorial, "
                       + "@anio, @idCategoria, @descripcion, "
                       + "@idAutor)";
                comand.Prepare();
                comand.Parameters.AddWithValue("@nombreLibro", libro.NombreLibro);
                comand.Parameters.AddWithValue("@idEditorial", libro.Editorial.IdEditorial);
                comand.Parameters.AddWithValue("@anio", libro.Anio);
                comand.Parameters.AddWithValue("@idCategoria", libro.Categoria.IdCategoria);
                comand.Parameters.AddWithValue("@descripcion", libro.Descripcion);
                comand.Parameters.AddWithValue("@idAutor", libro.Autor.IdAutor);
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

        public List<Libro> allLibro(string buscar)
        {
            List<Libro> listLibro = new List<Libro>();
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "SELECT libro.idLibro, libro.nombreLibro, editorial.nombreEditorial, "
                                    + "libro.anio, categoria.nombreCategoria, libro.descripcion, "
                                    + "autor.nombreAutor "
                                    + "FROM libro "
                                    + "INNER JOIN editorial ON libro.idEditorial = editorial.idEditorial "
                                    + "INNER JOIN categoria ON libro.idCategoria = categoria.idCategoria "
                                    + "INNER JOIN autor ON libro.idAutor = autor.idAutor "
                                    + "WHERE libro.nombreLibro LIKE '%' @nombreLibro '%' ";
                comand.Prepare();
                comand.Parameters.AddWithValue("@nombreLibro", buscar);
                MySqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    Libro libro = new Libro();
                    libro.IdLibro = reader.GetInt16("idLibro");
                    libro.NombreLibro = reader.GetString("nombreLibro");
                    libro.Editorial.NombreEditorial = reader.GetString("nombreEditorial");
                    libro.Anio = reader.GetInt32("anio");
                    libro.Categoria.NombreCategoria = reader.GetString("nombreCategoria");
                    libro.Descripcion = reader.GetString("descripcion");
                    libro.Autor.NombreAutor = reader.GetString("nombreAutor");
                    listLibro.Add(libro);
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
            return listLibro;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Libro> allLibro()
        {
            List<Libro> listLibro = new List<Libro>();
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "SELECT libro.idLibro, libro.nombreLibro, editorial.nombreEditorial, "
                                    + "libro.anio, categoria.nombreCategoria, libro.descripcion, "
                                    + "autor.nombreAutor "
                                    + "FROM libro "
                                    + "INNER JOIN editorial ON libro.idEditorial = editorial.idEditorial "
                                    + "INNER JOIN categoria ON libro.idCategoria = categoria.idCategoria "
                                    + "INNER JOIN autor ON libro.idAutor = autor.idAutor ";
                MySqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    Libro libro = new Libro();
                    libro.IdLibro= reader.GetInt16("idLibro");
                    libro.NombreLibro = reader.GetString("nombreLibro");
                    libro.Editorial.NombreEditorial = reader.GetString("nombreEditorial");
                    libro.Anio = reader.GetInt32("anio");
                    libro.Categoria.NombreCategoria = reader.GetString("nombreCategoria");
                    libro.Descripcion = reader.GetString("descripcion");
                    libro.Autor.NombreAutor = reader.GetString("nombreAutor");
                    listLibro.Add(libro);
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
            return listLibro;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombreLibro"></param>
        /// <returns></returns>
        public List<Libro> allLibroDisponible(string buscar)
        {
            List<Libro> listLibroDisponible = new List<Libro>();
            try
            {
                
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "SELECT libro.idLibro, libro.nombreLibro, editorial.nombreEditorial, libro.anio, "
                                   + "categoria.nombreCategoria, libro.descripcion, "
                                   + "autor.nombreAutor "
                                   + "FROM libro  "
                                   + "INNER JOIN editorial ON libro.idEditorial = editorial.idEditorial "
                                   + "INNER JOIN categoria ON libro.idCategoria = categoria.idCategoria "
                                   + "INNER JOIN autor ON libro.idAutor = autor.idAutor "
                                   + "WHERE libro.idLibro NOT IN (SELECT idLibro "
                                   + "FROM prestamo_Libro "
                                   + "WHERE prestamoSolvente = 'Insolvente') "
                                   + "AND libro.nombreLibro LIKE '%' @nombreLibro '%' ";
                comand.Prepare();
                comand.Parameters.AddWithValue("@nombreLibro", buscar);
                MySqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    Libro libro = new Libro();
                    libro.IdLibro = reader.GetInt16("idLibro");
                    libro.NombreLibro = reader.GetString("nombreLibro");
                    libro.Editorial.NombreEditorial = reader.GetString("nombreEditorial");
                    libro.Anio = reader.GetInt32("anio");
                    libro.Categoria.NombreCategoria = reader.GetString("nombreCategoria");
                    libro.Descripcion = reader.GetString("descripcion");
                    libro.Autor.NombreAutor = reader.GetString("nombreAutor");
                    listLibroDisponible.Add(libro);
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
            return listLibroDisponible;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Libro> allLibroDisponible()
        {
            List<Libro> listLibroDisponible = new List<Libro>();
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "SELECT libro.idLibro, libro.nombreLibro, editorial.nombreEditorial, libro.anio, "
                                   + "categoria.nombreCategoria, libro.descripcion, "
                                   + "autor.nombreAutor "
                                   + "FROM libro  "
                                   + "INNER JOIN editorial ON libro.idEditorial = editorial.idEditorial "
                                   + "INNER JOIN categoria ON libro.idCategoria = categoria.idCategoria "
                                   + "INNER JOIN autor ON libro.idAutor = autor.idAutor "
                                   + "WHERE libro.idLibro NOT IN (SELECT idLibro "
                                   + "FROM prestamo_Libro "
                                   + "WHERE prestamoSolvente = 'Insolvente') ";
                MySqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    Libro libro = new Libro();
                    libro.IdLibro = reader.GetInt16("idLibro");
                    libro.NombreLibro = reader.GetString("nombreLibro");
                    libro.Editorial.NombreEditorial = reader.GetString("nombreEditorial");
                    libro.Anio = reader.GetInt32("anio");
                    libro.Categoria.NombreCategoria = reader.GetString("nombreCategoria");
                    libro.Descripcion = reader.GetString("descripcion");
                    libro.Autor.NombreAutor = reader.GetString("nombreAutor");
                    listLibroDisponible.Add(libro);
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
            return listLibroDisponible;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="libro"></param>
        public void deleteLibro(Libro libro)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="libro"></param>
        public void updateLibro(Libro libro)
        {
            throw new NotImplementedException();
        }


    }
}
