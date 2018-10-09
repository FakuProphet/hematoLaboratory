using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using HematoLab.Clases;
using System.Windows.Forms;
using System.Data;

namespace HematoLab.Gestores
{

    class GestorProfesionales
    {


     //   SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        const int tam = 1000;
        Profesional[] vP = new Profesional[1000];


        public SqlDataReader pDr
        { set { dr = value; } get { return dr; } }


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
            cmd.CommandText = consultasql;
            cmd.ExecuteNonQuery();
            Conexion.CerrarConexion();
        }






        public void CargarListadoProfesionales(ListBox lista)
        {

            lista.Items.Clear();

            Profesional[] vPNM = GetProfesionales();
            for (int i = 0; i < vPNM.Length; i++)
            {
                if (vPNM[i] != null)
                {
                    lista.Items.Add(vPNM[i].toStringProfesional());
                }
            }

      
        }


        public Profesional[] GetProfesionales()
        {

            Profesional[] miLista = new Profesional[tam];
            cmd = new SqlCommand("select * from Profesionales ", Conexion.ObtenerConexion());
            dr = cmd.ExecuteReader();

            int c = 0;

            while (dr.Read())

            {
                Profesional nuevo = new Profesional();

                if (!pDr.IsDBNull(0))
                {
                    nuevo.pLegajo = pDr.GetInt32(0);
                }

                if (!pDr.IsDBNull(1))
                {
                    nuevo.pMatricula = pDr.GetString(1);
                }

                if (!pDr.IsDBNull(2))
                {
                    nuevo.pIdTurnoTrabajo = pDr.GetInt32(2);
                }

                if (!pDr.IsDBNull(3))
                {
                    nuevo.pNombre = pDr.GetString(3);
                }

                if (!pDr.IsDBNull(4))
                {
                    nuevo.pApellido = pDr.GetString(4);
                }

                if (!pDr.IsDBNull(5))
                {
                    nuevo.pEdad = pDr.GetInt32(5);
                }

                if (!pDr.IsDBNull(6))
                {
                    nuevo.pIdGenero = pDr.GetInt32(6);
                }

                if (!pDr.IsDBNull(7))
                {
                    nuevo.pFechaNac = pDr.GetString(7);
                }

                if (!pDr.IsDBNull(8))
                {
                    nuevo.pFechaRegistro = pDr.GetString(8);
                }

                if (!pDr.IsDBNull(9))
                {
                    nuevo.pNroDoc = pDr.GetInt32(9);
                }

                if (!pDr.IsDBNull(10))
                {
                    nuevo.pTipoDoc = pDr.GetInt32(10);
                }

                if (!pDr.IsDBNull(11))
                {
                    nuevo.pEmail = pDr.GetString(11);
                }

                if (!pDr.IsDBNull(12))
                {
                    nuevo.pIdEspecialidad = pDr.GetInt32(12);
                }

                if (!pDr.IsDBNull(13))
                {
                    nuevo.pTituloAcademico = pDr.GetInt32(13);
                }

                
                miLista[c] = nuevo;
                c++;

            }

            dr.Close();
            Conexion.CerrarConexion();
            return miLista;
        }



    }
}
