using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace SisBiblioteca.LibsBd
{
    public class Cnn
    {
        MySqlConnection Coneccion = new MySqlConnection();
        private string Host = "localhost";
        private string DbName = "alajandrina_c_sharp";
        private string User = "root";
        private string Pass = "";
        bool BanderaConeccion = false;

        /// <summary>
        /// Esta funcion nos abre la conexión a la base de datos
        /// </summary>
        /// <returns>Nos retorna la conexión</returns>
        public MySqlConnection openBd() 
        {
            
            try
            {
                string cadenaConeccion = "Server=" + Host + ";Database=" + DbName + ";User id=" + User + ";Password=" + Pass + ";ConvertZeroDatetime=True;AllowZeroDatetime=True";
                Coneccion.ConnectionString = cadenaConeccion;
                Coneccion.Open();
                BanderaConeccion = true;
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("No se puede conectar a la base de datos", ex.ToString());
            }

            return Coneccion;
        }

        /// <summary>
        /// Funcion que cierra la conexión a la base de datos
        /// </summary>
        public void closeBd()
        {
            if (BanderaConeccion)
            {
                try
                {
                    Coneccion.Close();
                    BanderaConeccion = false;
                }
                catch (MySqlException ex)
                {

                    MessageBox.Show("Error al cerrar la conexion." + ex);
                }
            }
        }

    }
}
