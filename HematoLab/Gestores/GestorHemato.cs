using HematoLab.Clases;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HematoLab.Gestores
{
    class GestorHemato
    {
        SqlCommand cmd;
        SqlDataReader dr;
        const int tam = 1000;
        private string consulta { get; set; }


        public SqlDataReader pDr
        { set { dr = value; } get { return dr; } }



        public DataTable consultarTabla(string nombreTabla)
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            da.SelectCommand = new SqlCommand("SELECT * FROM " + nombreTabla, Conexion.ObtenerConexion());
            da.Fill(ds);
            dt = ds.Tables[0];
            Conexion.CerrarConexion();
            return dt;
        }


        public void CargarListadoExtractorio(ListBox lista,string fecha)
        {
            lista.Items.Clear();

            AnalisisDTO[] v = GetTurnosExtractorioVista(fecha);
            for (int i = 0; i < v.Length; i++)
            {
                if (v[i] != null)
                {
                    lista.Items.Add(v[i].toStringAnalisis());   
                }
            }
        }

        public void actualizarBD(string consultasql)
        {
            Conexion.ObtenerConexion();
            cmd.CommandText = consultasql;
            cmd.ExecuteNonQuery();
            Conexion.CerrarConexion();
        }

        public string GetNombreTecnicoExt(string legajo)
        {
            string nombre = "";
            cmd = new SqlCommand("select v.[Responsable extractorio] from TEC_EXT2 v where v.legajo like '%"+legajo+"%'", Conexion.ObtenerConexion());
            dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                if (!pDr.IsDBNull(0))
                {
                    nombre = pDr.GetString(0);
                }
            }
            return nombre;
        }

        public AnalisisDTO[] GetTurnosExtractorioVista(string fecha)
        {

            AnalisisDTO[] miLista = new AnalisisDTO[tam];
            cmd = new SqlCommand("select * from vista_analisis_realizados v where v.[Turnos de la fecha] like '%"+fecha+ "%' and v.[Estado del turno] like 'Realizado'", Conexion.ObtenerConexion());
            dr = cmd.ExecuteReader();

            int c = 0;

            while (dr.Read())

            {
                AnalisisDTO nuevo = new AnalisisDTO();

                if (!pDr.IsDBNull(0))
                {
                    nuevo.nroOrden = pDr.GetInt32(0);
                }

                if (!pDr.IsDBNull(1))
                {
                    nuevo.paciente = pDr.GetString(1);
                }

                if (!pDr.IsDBNull(2))
                {
                    nuevo.fecha = pDr.GetString(2);
                }

                if (!pDr.IsDBNull(3))
                {
                    nuevo.hora = pDr.GetString(3);
                }

                if (!pDr.IsDBNull(4))
                {
                    nuevo.estado = pDr.GetString(4);
                }

                if (!pDr.IsDBNull(5))
                {
                    nuevo.observaciones = pDr.GetString(5);
                }

                

                if (!pDr.IsDBNull(6))
                {
                    nuevo.grupoEtario = pDr.GetString(6);
                }

                if (!pDr.IsDBNull(7))
                {
                    nuevo.edad = pDr.GetInt32(7);
                }


                if (!pDr.IsDBNull(8))
                {
                    nuevo.nroDoc = pDr.GetInt32(8);
                }

                if (!pDr.IsDBNull(9))
                {
                    nuevo.realizado = pDr.GetString(9);
                }

                miLista[c] = nuevo;
                c++;
            }

            dr.Close();
            Conexion.CerrarConexion();
            return miLista;
        }


       

        public void ConcluirEstudio(int estado , int numeroOrden)
        {
            string query = "UPDATE Extracciones SET visibleLab = @estado WHERE numeroOrden = @nroOrden";
            using (SqlCommand command = new SqlCommand(query, Conexion.ObtenerConexion()))
            {
                command.Parameters.AddWithValue("@estado",estado);
                command.Parameters.AddWithValue("@nroOrden", numeroOrden);
                int result = command.ExecuteNonQuery();
            }
       
        }

       



        public ULD GetNombreRealUsuarioLogueado(string parametro)
        {
            ULD miNombre = new ULD();
            cmd = new SqlCommand("select * from nombreDelUsuarioLaboratorio v where v.usuario like '%" + parametro + "%' ", Conexion.ObtenerConexion());
            dr = cmd.ExecuteReader();
            int c = 0;

            if (dr.Read())
            {
                ULD nuevo = new ULD();
                if (!pDr.IsDBNull(0))
                {
                    nuevo.nombreCompleto = pDr.GetString(0);
                }
                if (!pDr.IsDBNull(2))
                {
                    nuevo.legajoSistema = pDr.GetInt32(2);
                }
                c++;
                miNombre = nuevo;
            }

            dr.Close();
            Conexion.CerrarConexion();
            return miNombre;
        }

    }
}
