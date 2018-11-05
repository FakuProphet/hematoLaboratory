using HematoLab.Clases;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HematoLab.Gestores
{
    class GestorExtractorio
    {
        SqlCommand cmd;
        SqlDataReader dr;
        const int tam = 1000;
        private string consulta {get; set;}


        public SqlDataReader pDr
        { set { dr = value; } get { return dr; } }


        public string obtenerConsulta()
        {
            return consulta="SELECT * FROM vistaTurnosFechaActual";
        }


        public void actualizarEstadoTurno(int codEstado, int numeroOrden, string observaciones, int realizador)
        {
            string query = "UPDATE Extracciones SET Estado = @codEstado, observaciones=@observaciones, realizador=@realizador WHERE numeroOrden = @nroOrden";
            using (SqlCommand command = new SqlCommand(query, Conexion.ObtenerConexion()))
            {
                command.Parameters.AddWithValue("@nroOrden", numeroOrden);
                command.Parameters.AddWithValue("@codEstado", codEstado);
                command.Parameters.AddWithValue("@observaciones", observaciones);
                command.Parameters.AddWithValue("@realizador", realizador);
                int result = command.ExecuteNonQuery();
            }

        }

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

        public DataTable consultarEspecial(int dni)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            da.SelectCommand = new SqlCommand("SELECT p.[Fecha última visita] FROM pruebaTurno P WHERE P.[Nro Documento paciente] LIKE '%"+dni+"%'", Conexion.ObtenerConexion());
            da.Fill(ds);
            dt = ds.Tables[0];
            Conexion.CerrarConexion();
            return dt;
        }


        public void actualizarBD(string consultasql)
        {
            Conexion.ObtenerConexion();
            cmd.CommandText = consultasql;
            cmd.ExecuteNonQuery();
            Conexion.CerrarConexion();
        }

       

      



        public void CargarListadoExtractorio(ListBox lista,string fecha)
        {
            lista.Items.Clear();

            ExtractorioDTO[] v = GetTurnosExtractorioVista( fecha);
            for (int i = 0; i < v.Length; i++)
            {
                if (v[i] != null)
                {
                    if (v[i].estado=="Pendiente")
                    {
                        lista.Items.Add(v[i].toStringExtractorio());
                    }
                }
            }
        }

        public ULD GetNombreRealUsuarioLogueado(string parametro)
        {
            ULD miNombre = new ULD(); 
            cmd = new SqlCommand("select * from nombreDelUsuarioExtractorio v where v.usuario like '%"+parametro+"%' ", Conexion.ObtenerConexion());
            dr = cmd.ExecuteReader();
            int c=0;

            if(dr.Read())
            {
                ULD nuevo = new ULD();
                if (!pDr.IsDBNull(0))
                {
                    nuevo.nombreCompleto = pDr.GetString(0);
                }
                if(!pDr.IsDBNull(2))
                {
                    nuevo.legajoSistema = pDr.GetInt32(2);
                }
                c++;
                miNombre=nuevo;
            }

            dr.Close();
            Conexion.CerrarConexion();
            return miNombre;
        }

        public ExtractorioDTO[] GetTurnosExtractorioVista(string parametro)
        {

            ExtractorioDTO[] miLista = new ExtractorioDTO[tam];
            cmd = new SqlCommand("select * from vista2 v where v.[Turnos de la fecha] like '%"+parametro+"%'", Conexion.ObtenerConexion());
            dr = cmd.ExecuteReader();

            int c = 0;

            while (dr.Read())

            {
                ExtractorioDTO nuevo = new ExtractorioDTO();

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
                    nuevo.extraccion = pDr.GetInt32(6);
                }

                if (!pDr.IsDBNull(7))
                {
                    nuevo.citilogico = pDr.GetInt32(7);
                }

                if (!pDr.IsDBNull(8))
                {
                    nuevo.eritrosedimentacion = pDr.GetInt32(8);
                }

                if (!pDr.IsDBNull(9))
                {
                    nuevo.reticulocitos = pDr.GetInt32(9);
                }

                if (!pDr.IsDBNull(10))
                {
                    nuevo.nroDoc = pDr.GetInt32(10);
                }

                if (!pDr.IsDBNull(11))
                {
                    nuevo.grupoEtario = pDr.GetString(11);
                }

                miLista[c] = nuevo;
                c++;
            }

            dr.Close();
            Conexion.CerrarConexion();
            return miLista;
        }




        public Extractorio[] GetTurnosExtractorio()
        {

            Extractorio[] miLista = new Extractorio[tam];
            cmd = new SqlCommand("select * from Extracciones ", Conexion.ObtenerConexion());
            dr = cmd.ExecuteReader();

            int c = 0;

            while (dr.Read())

            {
                Extractorio nuevo = new Extractorio();

                if (!pDr.IsDBNull(0))
                {
                    nuevo.nroOrden = pDr.GetInt32(0);
                }

                if (!pDr.IsDBNull(1))
                {
                    nuevo.idPaciente = pDr.GetInt32(1);
                }

                if (!pDr.IsDBNull(2))
                {
                    nuevo.fecha = pDr.GetString(2);
                }

                if (!pDr.IsDBNull(3))
                {
                    nuevo.hora = pDr.GetInt32(3);
                }

                if (!pDr.IsDBNull(4))
                {
                    nuevo.idEstado = pDr.GetInt32(4);
                }

                if (!pDr.IsDBNull(5))
                {
                    nuevo.observaciones = pDr.GetString(5);
                }

                if (!pDr.IsDBNull(6))
                {
                    nuevo.extraccion = pDr.GetInt32(6);
                }

                if (!pDr.IsDBNull(7))
                {
                    nuevo.citilogico = pDr.GetInt32(7);
                }

                if (!pDr.IsDBNull(8))
                {
                    nuevo.eritrosedimentacion = pDr.GetInt32(8);
                }

                if (!pDr.IsDBNull(9))
                {
                    nuevo.reticulocitos = pDr.GetInt32(9);
                }

                miLista[c] = nuevo;
                c++;
            }

            dr.Close();
            Conexion.CerrarConexion();
            return miLista;
        }


        public TurnoAnterior GetTurnoAnteriorPaciente(string nroDoc,string fecha)
        {
            TurnoAnterior miTurno = new TurnoAnterior();
            cmd = new SqlCommand("SELECT * FROM pruebaTurno P WHERE P.[Fecha última visita] LIKE '%"+fecha+"%' AND P.[Nro Documento paciente] LIKE '%"+nroDoc+"%'", Conexion.ObtenerConexion());
            dr = cmd.ExecuteReader();

            int c = 0;

            if (dr.Read())

            {
                TurnoAnterior nuevo = new TurnoAnterior();

                if (!pDr.IsDBNull(0))
                {
                    nuevo.paciente = pDr.GetString(0);
                }

                if (!pDr.IsDBNull(1))
                {
                    nuevo.obraSocial = pDr.GetString(1);
                }

                if (!pDr.IsDBNull(2))
                {
                    nuevo.fechaUltimaVisita = pDr.GetString(2);
                }

                if (!pDr.IsDBNull(3))
                {
                    nuevo.codigoEstado = pDr.GetInt32(3);
                }

                if (!pDr.IsDBNull(4))
                {
                    nuevo.eritro = pDr.GetInt32(4);
                }

                if (!pDr.IsDBNull(5))
                {
                    nuevo.reti = pDr.GetInt32(5);
                }

                if (!pDr.IsDBNull(6))
                {
                    nuevo.cito = pDr.GetInt32(6);
                }

                if (!pDr.IsDBNull(7))
                {
                    nuevo.observaciones = pDr.GetString(7);
                }

                if (!pDr.IsDBNull(8))
                {
                    nuevo.nroDoc = pDr.GetInt32(8);
                }

                miTurno = nuevo;
                c++;
            }

            dr.Close();
            Conexion.CerrarConexion();
            return miTurno;
        }



    }
}
