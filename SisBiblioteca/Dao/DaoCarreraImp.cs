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
    public class DaoCarreraImp : Cnn, DaoCarrera
    {
        MySqlConnection Con = null;
        MySqlCommand comand = null;
        public void addCarrera(Carrera carrera)
        {
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "INSERT INTO carrera(idCarrera, nombreCarrera) VALUES (null, @nombreCarrera)";
                comand.Prepare();
                comand.Parameters.AddWithValue("@nombreCarrera", carrera.NombreCarrera);
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

        public List<Carrera> allCarrera()
        {
            List<Carrera> listCarrera = new List<Carrera>();
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "SELECT * FROM carrera";
                MySqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    Carrera carrera = new Carrera();
                    carrera.IdCarrera = reader.GetInt16(0);
                    carrera.NombreCarrera = reader.GetString(1);
                    listCarrera.Add(carrera);
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
            return listCarrera;
        }

        public List<Carrera> allCarrera(string nombreCarrera)
        {
            List<Carrera> listCarrera = new List<Carrera>();
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "SELECT * FROM carrera "
                                   + "WHERE nombreCarrera LIKE '%' @nombreCarrera '%' ";
                comand.Prepare();
                comand.Parameters.AddWithValue("@nombreCarrera", nombreCarrera);
                MySqlDataReader reader = comand.ExecuteReader();
                while (reader.Read())
                {
                    Carrera carrera = new Carrera();
                    carrera.IdCarrera = reader.GetInt16(0);
                    carrera.NombreCarrera = reader.GetString(1);
                    listCarrera.Add(carrera);
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
            return listCarrera;
        }

        public void deleteCarrera(Carrera carrera)
        {
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "DELETE FROM carrera WHERE idCarrera = @idCarrera";
                comand.Prepare();
                comand.Parameters.AddWithValue("@idCarrera", carrera.IdCarrera);
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

        public void updateCarrera(Carrera carrera)
        {
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "UPDATE carrera SET nombreCarrera= @nombreCarrera WHERE idCarrera = @idCarrera";
                comand.Prepare();
                comand.Parameters.AddWithValue("@nombreCarrera", carrera.NombreCarrera);
                comand.Parameters.AddWithValue("@idCarrera", carrera.IdCarrera);
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
