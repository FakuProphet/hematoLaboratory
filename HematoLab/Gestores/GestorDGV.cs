using HematoLab.Clases;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace HematoLab.Gestores
{
    class GestorDGV
    {
        public void efectosDGV(DataGridView miDGV)
        {
            miDGV.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            miDGV.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            miDGV.BackgroundColor = Color.White;
            miDGV.EnableHeadersVisualStyles = false;
            miDGV.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            miDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            miDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

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

        public void cargarDataGrid2(DataGridView miDataGrid, string consulta, string tablaConsulta)
        {

            DataSet miDataSet = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(consulta, Conexion.ObtenerConexion());
            da.Fill(miDataSet, tablaConsulta);
            Conexion.CerrarConexion();
            miDataGrid.RowHeadersVisible = false;
            miDataGrid.AllowUserToAddRows = false;
            miDataGrid.AllowUserToDeleteRows = false;
            miDataGrid.AllowUserToOrderColumns = false;
            miDataGrid.AllowUserToResizeColumns = true;
            miDataGrid.AllowUserToResizeRows = false;
            miDataGrid.AutoResizeColumns();
            //estas dos lineas siguientes indican q las celdas se ajusten al contenido
            //-----------------------------------------------------------------------
            miDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            miDataGrid.BorderStyle = BorderStyle.None;
            //---------------------------------------------------------------------
            miDataGrid.DataSource = miDataSet.Tables[tablaConsulta].DefaultView;
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
    }
}
