using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;
using System.Data;


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
