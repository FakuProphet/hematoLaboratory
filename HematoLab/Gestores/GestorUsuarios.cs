using HematoLab.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HematoLab.Gestores
{
    class GestorUsuarios
    {


        SqlCommand cmd;
        SqlDataReader dr;
        const int tam = 1000;



        public SqlDataReader pDr
        { set { dr = value; } get { return dr; } }


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

        private void cargarDataGridMetodo2(DataGridView miDataGrid,string consulta)
        {
           
            try
            {
                SqlCommand cmd = new SqlCommand();
                // setear parametros del command
                cmd.CommandType = CommandType.Text;
                // abrimos la conexion
                // instanciamos el adaptador de datos
                SqlDataAdapter da = new SqlDataAdapter(consulta,Conexion.ObtenerConexion());
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

        private void efectosDGV(DataGridView miDGV)
        {         
                miDGV.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
                miDGV.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
                miDGV.BackgroundColor = Color.White;
                miDGV.EnableHeadersVisualStyles = false;
                miDGV.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                miDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
                miDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;          
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

        public void generarUsuario(int legajo,string usuario, string pass, int tipoUsuario,int codEstado,string nombreTabla)
        {
               
                String query = "INSERT INTO "+nombreTabla+" (legajo,usuario,contraseña,tipoUsuario,codEstado) VALUES (@legajo,@usuario,@pass,@tipoUsuario,@codEstado)";
                using (SqlCommand command = new SqlCommand(query, Conexion.ObtenerConexion()))
                {
                    command.Parameters.AddWithValue("@legajo", legajo );
                    command.Parameters.AddWithValue("@usuario",usuario);
                    command.Parameters.AddWithValue("@pass",pass);
                    command.Parameters.AddWithValue("@tipoUsuario",tipoUsuario);
                    command.Parameters.AddWithValue("@codEstado", codEstado);
                    int result = command.ExecuteNonQuery();
                }
            
        }

        public void actualizarUsuario(string pass,string usuario, int codEstado, string nombreTabla,int legajo)
        {
            string query = "UPDATE " +nombreTabla+ " SET contraseña = @pass, usuario = @usuario, codEstado = @codEstado WHERE legajo = @legajo";
            using (SqlCommand command = new SqlCommand(query, Conexion.ObtenerConexion()))
            {
                command.Parameters.AddWithValue("@pass", pass);
                command.Parameters.AddWithValue("@usuario", usuario);
                command.Parameters.AddWithValue("@codEstado", codEstado);
                command.Parameters.AddWithValue("@legajo", legajo);
                int result = command.ExecuteNonQuery();
            }
        }

        public void actualizarUsuarioAdministrador(string pass, string usuario)
        {
            string query = "UPDATE Administrador SET passAdmin = @pass, userAdmin = @usuario WHERE codigo = 10";
            using (SqlCommand command = new SqlCommand(query, Conexion.ObtenerConexion()))
            {
                command.Parameters.AddWithValue("@pass", pass);
                command.Parameters.AddWithValue("@usuario", usuario);
                int result = command.ExecuteNonQuery();
            }
        }

        public void CargarListado(ListBox lista,string nombreTabla)
        {

            lista.Items.Clear();

            Usuario[] v = GetObjetos(nombreTabla);

            for (int i = 0; i < v.Length; i++)
            {
                if (v[i] != null)
                {
                    lista.Items.Add(v[i].toStringUsuario());
                }
            }


        }


        public Usuario[] GetObjetos(string nombreTabla)

        {

            Usuario[] miLista = new Usuario[tam];
            cmd = new SqlCommand("select * from "+ nombreTabla +"", Conexion.ObtenerConexion());
            dr = cmd.ExecuteReader();

            int c = 0;

            while (dr.Read())

            {
                
                Usuario u = new Usuario();


                if (!pDr.IsDBNull(0))
                {
                   u.legajo  = pDr.GetInt32(0);
                }

                if (!pDr.IsDBNull(1))
                {
                    u.usuario = pDr.GetString(1);
                }

                if (!pDr.IsDBNull(2))
                {
                    u.pass = pDr.GetString(2);
                }

                if (!pDr.IsDBNull(3))
                {
                    u.tipoUsuario = pDr.GetInt32(3);
                }

                if (!pDr.IsDBNull(4))
                {
                    u.estado = pDr.GetInt32(4);
                }

                

                miLista[c] = u;
                c++;

            }

            dr.Close();
            Conexion.CerrarConexion();
            return miLista;
        }


       
        public Administrador GetAdministrador()
        {

            Administrador  miAdmin = new Administrador();
            cmd = new SqlCommand("SELECT * FROM Administrador", Conexion.ObtenerConexion());
            dr = cmd.ExecuteReader();

            if(dr.Read())
            {

                Administrador u = new Administrador();

                if (!pDr.IsDBNull(0))
                {
                    u.codigo = pDr.GetInt32(0);
                }

                if (!pDr.IsDBNull(1))
                {
                    u.userAdmin = pDr.GetString(1);
                }

                if (!pDr.IsDBNull(2))
                {
                    u.passAdmin = pDr.GetString(2);
                }

                miAdmin = u;
                
            }

            dr.Close();
            Conexion.CerrarConexion();
            return miAdmin;
        }


    }
}
