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
    class DaoMorasImp : Cnn, DaoMoras
    {
        MySqlConnection Con = null;
        MySqlCommand comand = null; 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mora"></param>
        public void addMora(Mora mora)
        {
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "INSERT INTO mora(idMora, idPrestamoLibro, moraCancelada) "
                       + "VALUES (null, @idPrestamoLibro, 'No')";
                comand.Prepare();
                comand.Parameters.AddWithValue("@idPrestamoLibro", mora.PrestamoLibro.IdPrestamoLibro);
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
        /// <param name="mora"></param>
        public void solventarMora(Mora mora)
        {
            try
            {
                Con = openBd();
                comand = Con.CreateCommand();
                comand.CommandText = "UPDATE mora SET moraCancelada = 'Si', cantidadMora = 5.00, "
                                   + "fechaPagoMora = @fechaPagoMora "
                                   + "WHERE idMora = @idMora";
                comand.Prepare();
                comand.Parameters.AddWithValue("@fechaPagoMora", mora.FechaPagoMora);
                comand.Parameters.AddWithValue("@idMora", mora.IdMora);
                comand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al actualizar " + ex);
            }
            finally
            {
                closeBd();
            }
        }
    }
}
