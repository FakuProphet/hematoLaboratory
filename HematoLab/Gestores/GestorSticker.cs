using HematoLab.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HematoLab.Gestores
{
    class GestorSticker
    {
        SqlCommand cmd;
        SqlDataReader dr;



        public SqlDataReader pDr
        { set { dr = value; } get { return dr; } }



        public int GetNumeroSticker()
        {
            int nro = 0;
            cmd = new SqlCommand("SELECT * FROM NRO_STICKER", Conexion.ObtenerConexion());
            dr = cmd.ExecuteReader();
           


            if (dr.Read())
            {
                int nuevo = 0;
                if (!pDr.IsDBNull(0))
                {
                    nuevo = pDr.GetInt32(0);
                }
                nro = nuevo;
            }

            dr.Close();
            Conexion.CerrarConexion();
            return nro;
        }



        public void saveDatosSticker(int nroSticker, int docNro)
        {
            string query = "INSERT INTO STICKER (numero,documento) VALUES (@nro,@doc)";
            using (SqlCommand command = new SqlCommand(query, Conexion.ObtenerConexion()))
            {
                command.Parameters.AddWithValue("@nro", nroSticker);
                command.Parameters.AddWithValue("@doc", docNro);
                int result = command.ExecuteNonQuery();
            }

        }






    }
}
