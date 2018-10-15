using HematoLab.Clases;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace HematoLab.Gestores
{
    class GestorImagen
    {
        public bool insertar(int legajo, PictureBox pb, string nombreTabla)
        {

            
            SqlCommand cmd = new SqlCommand("INSERT INTO " +nombreTabla+ " VALUES (@legajo, @imagen)", Conexion.ObtenerConexion());
            cmd.Parameters.Add("@legajo", SqlDbType.Int);
            cmd.Parameters.Add("@imagen", SqlDbType.Image);

            cmd.Parameters["@legajo"].Value = legajo;
            MemoryStream ms = new MemoryStream();

            pb.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            cmd.Parameters["@imagen"].Value = ms.GetBuffer();

            int resultado = cmd.ExecuteNonQuery();
            Conexion.CerrarConexion();

            if (resultado > 0) return true;
            else return false;

        }

        public bool actualizar(int legajo, PictureBox pb,string nombreTabla)
        {
            //ObtenerConexion();
            SqlCommand cmd = new SqlCommand("UPDATE " + nombreTabla + " SET imagen=@imagen WHERE legajo=" + legajo, Conexion.ObtenerConexion());
            cmd.Parameters.Add("@legajo", SqlDbType.NVarChar);
            cmd.Parameters.Add("@imagen", SqlDbType.Image);

            cmd.Parameters["@legajo"].Value = legajo;
            MemoryStream ms = new MemoryStream();

            pb.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            cmd.Parameters["@imagen"].Value = ms.GetBuffer();

            int resultado = cmd.ExecuteNonQuery();
            Conexion.CerrarConexion();

            if (resultado > 0) return true;
            else return false;
        }

        //no utilizado
        public bool eliminar(string legajo,string nombreTabla)
        {
            
            SqlCommand cmd = new SqlCommand("DELETE  " + nombreTabla + " WHERE legajo = " + legajo, Conexion.ObtenerConexion());

            int resultado = cmd.ExecuteNonQuery();
            Conexion.CerrarConexion();

            if (resultado > 0) return true;
            else return false;
        }

        public void verImagen(PictureBox pb, int legajo,string nombreTabla)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT imagen FROM " +nombreTabla+ " WHERE legajo=" + legajo, Conexion.ObtenerConexion());
                SqlDataAdapter ad = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                ad.Fill(ds, nombreTabla);
                byte[] datos = new byte[0];
                DataRow dr = ds.Tables[nombreTabla].Rows[0];
                datos = (byte[])dr["imagen"];
                MemoryStream ms = new MemoryStream(datos);
                pb.Image = System.Drawing.Bitmap.FromStream(ms);
                Conexion.CerrarConexion();
            }

            catch (Exception)
            {
                pb.Image = null;
                Conexion.CerrarConexion();
            }

        }
    }
}
