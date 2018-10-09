using HematoLab.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HematoLab.Gestores
{
    class GestorTurnos
    {
        SqlCommand cmd;
        SqlDataReader dr;
        const int tam = 1000;
        


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

        public DataTable realizarConsulta(string query)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            da.SelectCommand = new SqlCommand(query, Conexion.ObtenerConexion());
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


        public void generarTurno(int codigoPac,int hora,string nombreTabla,int ext,int cito,int eritro,int reti)
        {
          // Conexion miConexion = null;
            String query = "INSERT INTO " + nombreTabla + " (paciente,hora,extraccion,citologico,eritrosedimentacion,reticulocitos) " +
                           "VALUES (@paciente,@hora,@ext,@cito,@eritro,@reti)";
            using (SqlCommand command = new SqlCommand(query, Conexion.ObtenerConexion()))
            {
                command.Parameters.AddWithValue("@ext", ext);
                command.Parameters.AddWithValue("@cito", cito);
                command.Parameters.AddWithValue("@eritro", eritro);
                command.Parameters.AddWithValue("@reti", reti);
                command.Parameters.AddWithValue("@paciente", codigoPac);
                command.Parameters.AddWithValue("@hora", hora);
                
                int result = command.ExecuteNonQuery();
            }

        }


        public void EliminarTurno(string nombreTabla, int numeroOrden)
        {
            string query = "DELETE " + nombreTabla + " WHERE numeroOrden = @numeroOrden";
            using (SqlCommand command = new SqlCommand(query, Conexion.ObtenerConexion()))
            {
                command.Parameters.AddWithValue("@numeroOrden", numeroOrden);
                int result = command.ExecuteNonQuery();
            }
        }




        public void cambiarEstadoTurno(int codEstado, string nombreTabla,int numeroOrden)
        {
            string query = "UPDATE " + nombreTabla + " SET estado = @estado WHERE numeroOrden = @numeroOrden";
            using (SqlCommand command = new SqlCommand(query, Conexion.ObtenerConexion()))
            {  
                command.Parameters.AddWithValue("@numeroOrden", numeroOrden);
                command.Parameters.AddWithValue("@estado", codEstado);
                int result = command.ExecuteNonQuery();
            }
        }



        public void cargarDataGrid(DataGridView miDataGrid, string consulta)
        {
            DataSet miDataSet = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conexion.ObtenerConexion());
            da.Fill(miDataSet);
            Conexion.CerrarConexion();
            miDataGrid.RowHeadersVisible = false;
            miDataGrid.AllowUserToAddRows = false;
            miDataGrid.AllowUserToDeleteRows = false;
            miDataGrid.AllowUserToOrderColumns = false;
            miDataGrid.AllowUserToResizeColumns = true;
            miDataGrid.AllowUserToResizeRows = false;
            miDataGrid.AutoResizeColumns();
            miDataGrid.DataSource = miDataSet.Tables[0];
            //estas dos lineas siguientes indican q las celdas se ajusten al contenido
            //-----------------------------------------------------------------------
            miDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            miDataGrid.BorderStyle = BorderStyle.None;
            //---------------------------------------------------------------------
        }

        public void cargarDataGridMetodo2(DataGridView miDataGrid, string consulta)
        {

            try
            {
                SqlCommand cmd = new SqlCommand();
                // setear parametros del command
                cmd.CommandType = CommandType.Text;
                // abrimos la conexion
                // instanciamos el adaptador de datos
                SqlDataAdapter da = new SqlDataAdapter(consulta, Conexion.ObtenerConexion());
                // creamos un dataset que será rellenado a partir del anterior dataAdapter
                DataSet ds = new DataSet();
                // rellenamos
                da.Fill(ds);
                // asignamos a la grilla como datasource, la tabla de indice 0 del datasource creado
                miDataGrid.DataSource = ds.Tables[0];
            } // fin try
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } // fin catch
            finally
            {
                Conexion.CerrarConexion();
            } // fin finally

        }

        public void efectosDGV(DataGridView miDGV)
        {
            miDGV.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            miDGV.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            miDGV.BackgroundColor = Color.White;
            miDGV.EnableHeadersVisualStyles = false;
            miDGV.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            miDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            miDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
          //  miDGV.Columns[2].DefaultCellStyle.BackColor = Color.Orange;
        }



        public string GetCantidadTurnosCancelados(string fecha)
        {
            string salida = "0";
            cmd = new SqlCommand("select * from turnos_cancelados_cantidad v where v.fecha like '%"+fecha+"%'", Conexion.ObtenerConexion());
            dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                salida = Convert.ToString( pDr.GetInt32(0));
            }
            return salida;
        }



        public Extractorio[] GetTurnosExtractorioDelDia()
        {

            Extractorio[] miLista = new Extractorio[tam];
            cmd = new SqlCommand("select * from Extracciones where fecha =(select max(fecha)from Extracciones)", Conexion.ObtenerConexion());
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


        public bool GetDisponibilidadHora(int id,string fecha)
        {

            cmd = new SqlCommand("select v.id from test_turno v where v.id="+id+" and fecha like '%"+fecha+"%'", Conexion.ObtenerConexion());
            dr = cmd.ExecuteReader();
            bool bandera = true;
          
            if (dr.Read())

            {
               
                if (!pDr.IsDBNull(0))
                {
                    bandera = false;
                }
                if (pDr.IsDBNull(0))
                {
                    bandera = true;
                }
                    
            }

            dr.Close();
            Conexion.CerrarConexion();
            return  bandera;
        }




    }
}
