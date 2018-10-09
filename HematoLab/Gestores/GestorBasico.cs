using HematoLab.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HematoLab.Gestores
{
    class GestorBasico
    {
        public DataTable consultarTabla(string nombreTabla)
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            da.SelectCommand = new SqlCommand("SELECT * from " + nombreTabla, Conexion.ObtenerConexion());
            da.Fill(ds);
            dt = ds.Tables[0];
            return dt;
        }

        public void actualizarBD(string consultasql)
        {
            Conexion.ObtenerConexion();
            SqlCommand comando = new SqlCommand();
            comando.CommandText = consultasql;
            comando.ExecuteNonQuery();
            Conexion.CerrarConexion();
        }


    }
}
