using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HematoLab.Clases;
using System.Windows.Forms;

namespace HematoLab.Gestores
{
    class GestorPersonalNoMedico
    {

        SqlCommand cmd;
        SqlDataReader dr;
        const int tam = 1000;
     


        public SqlDataReader pDr
        { set { dr = value; } get { return dr; } }


        public void actualizarBD(string consultasql)
        {
            Conexion.ObtenerConexion();
            cmd.CommandText = consultasql;
            cmd.ExecuteNonQuery();
            Conexion.CerrarConexion();
        }

     

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



        public void CargarListado(ListBox lista)
        {
          
            lista.Items.Clear();

            Administrativo[] vPNM = GetPersonalNoMedico();
            for (int i = 0; i < vPNM.Length; i++)
            {
                if (vPNM[i] != null)
                {
                    lista.Items.Add(vPNM[i].toStringPNM());
                }
            }

        }


        public Administrativo[] GetPersonalNoMedico()
        {
            Administrativo[] miLista = new Administrativo[tam];

            cmd = new SqlCommand("select * from PersonalNoMedico", Conexion.ObtenerConexion());
            dr = cmd.ExecuteReader();


            int c = 0;

            while (dr.Read())

            {
                Administrativo nuevo = new Administrativo();

                if (!pDr.IsDBNull(0))
                {
                    nuevo.pLegajo = pDr.GetInt32(0);
                }

                if (!pDr.IsDBNull(1))
                {
                    nuevo.pIdTurnoDeTrabajo = pDr.GetInt32(1);
                }

                if (!pDr.IsDBNull(2))
                {
                    nuevo.pNombre = pDr.GetString(2);
                }

                if (!pDr.IsDBNull(3))
                {
                    nuevo.pApellido = pDr.GetString(3);
                }

                if (!pDr.IsDBNull(4))
                {
                    nuevo.pIdGenero = pDr.GetInt32(4);
                }

                if (!pDr.IsDBNull(5))
                {
                    nuevo.pFechaNacimiento = pDr.GetString(5);
                }

                if (!pDr.IsDBNull(6))
                {
                    nuevo.pAltaEnSistema = pDr.GetString(6);
                }

                if (!pDr.IsDBNull(7))
                {
                    nuevo.pNroDoc = pDr.GetInt32(7);
                }

                if (!pDr.IsDBNull(8))
                {
                    nuevo.pTipoDoc = pDr.GetInt32(8);
                }

                if (!pDr.IsDBNull(9))
                {
                    nuevo.pEmail = pDr.GetString(9);
                }

                if (!pDr.IsDBNull(10))
                {
                    nuevo.pEdad = pDr.GetInt32(10);
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
