using HematoLab.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HematoLab.Gestores
{
    class GestorReporte
    {

        SqlCommand cmd;
        SqlDataReader dr;
        const int tam = 10000;



        public SqlDataReader pDr
        { set { dr = value; } get { return dr; } }


        public void CargarListado(ListBox lista)
        {
            lista.Items.Clear();

            Paciente[] vP = GetPacientes();
            for (int i = 0; i < vP.Length; i++)
            {
                if (vP[i] != null)
                {
                    lista.Items.Add(vP[i].toStringPaciente());
                }
            }
        }

        public DataTable consultarEspecial(int dni)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            da.SelectCommand = new SqlCommand("SELECT fecha FROM Estudios WHERE dni LIKE '%" + dni + "%'", Conexion.ObtenerConexion());
            da.Fill(ds);
            dt = ds.Tables[0];
            Conexion.CerrarConexion();
            return dt;
        }

        public DataTable consultarEspecial2(int dni)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            da.SelectCommand = new SqlCommand("SELECT numero FROM Estudios WHERE dni LIKE '%" + dni + "%'", Conexion.ObtenerConexion());
            da.Fill(ds);
            dt = ds.Tables[0];
            Conexion.CerrarConexion();
            return dt;
        }

        public Paciente[] GetPacientes()
        {

            Paciente[] miLista = new Paciente[tam];
            cmd = new SqlCommand("select * from pacientes order by 10 asc", Conexion.ObtenerConexion());
            dr = cmd.ExecuteReader();

            int c = 0;

            while (dr.Read())

            {
                Paciente nuevo = new Paciente();

                if (!pDr.IsDBNull(0))
                {
                    nuevo.codigo = pDr.GetInt32(0);
                }

                if (!pDr.IsDBNull(1))
                {
                    nuevo.nombre = pDr.GetString(1);
                }

                if (!pDr.IsDBNull(2))
                {
                    nuevo.apellido = pDr.GetString(2);
                }

                if (!pDr.IsDBNull(3))
                {
                    nuevo.edad = pDr.GetInt32(3);
                }

                if (!pDr.IsDBNull(4))
                {
                    nuevo.fechaNacimiento = pDr.GetString(4);
                }

                if (!pDr.IsDBNull(5))
                {
                    nuevo.nacionalidad = pDr.GetString(5);
                }

                if (!pDr.IsDBNull(6))
                {
                    nuevo.grupoEtario = pDr.GetInt32(6);
                }

                if (!pDr.IsDBNull(7))
                {
                    nuevo.genero = pDr.GetInt32(7);
                }

                if (!pDr.IsDBNull(8))
                {
                    nuevo.fechaRegistro = pDr.GetString(8);
                }

                if (!pDr.IsDBNull(9))
                {
                    nuevo.numeroDocumento = pDr.GetInt32(9);
                }

                if (!pDr.IsDBNull(10))
                {
                    nuevo.tipoDocumento = pDr.GetInt32(10);
                }

                if (!pDr.IsDBNull(11))
                {
                    nuevo.email = pDr.GetString(11);
                }

                if (!pDr.IsDBNull(12))
                {
                    nuevo.obraSocial = pDr.GetString(12);
                }

                if (!pDr.IsDBNull(13))
                {
                    nuevo.estadoCivil = pDr.GetInt32(13);
                }

                if (!pDr.IsDBNull(14))
                {
                    nuevo.provincia = pDr.GetInt32(14);
                }

                if (!pDr.IsDBNull(15))
                {
                    nuevo.localidad = pDr.GetInt32(15);
                }

                if (!pDr.IsDBNull(16))
                {
                    nuevo.calle = pDr.GetString(16);
                }

                if (!pDr.IsDBNull(17))
                {
                    nuevo.numeroCalle = pDr.GetInt32(17);
                }

                if (!pDr.IsDBNull(18))
                {
                    nuevo.barrio = pDr.GetString(18);
                }

                if (!pDr.IsDBNull(19))
                {
                    nuevo.telefonoFijo = pDr.GetString(19);
                }

                if (!pDr.IsDBNull(20))
                {
                    nuevo.telefonoCelular = pDr.GetString(20);
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
