using System;
using System.Configuration;
using System.Data.SqlClient;



namespace HematoLab.Clases
{
    class Conexion
    {
        static string cadena = ConfigurationManager.ConnectionStrings["cadenaDeConexion"].ToString();


        public static string pCadena
        {
            get { return cadena; }
        }


        public static SqlConnection ObtenerConexion()
        {

            try
            {
                SqlConnection conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["cadenaDeConexion"].ToString());
                conectar.Open();
                return conectar;
            }
            catch (Exception)
            {
                throw new Exception("Error en la conexion"); 
            }
        }

        public static SqlConnection CerrarConexion()
        {
            SqlConnection desconectar = new SqlConnection(ConfigurationManager.ConnectionStrings["cadenaDeConexion"].ToString());
            desconectar.Close();
            desconectar.Dispose();
            return desconectar;
        }
    }
}
