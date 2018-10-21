

using HematoLab.Clases;
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


        public void efectosDataGridView(DataGridView miDataGridView)
        {
            miDataGridView.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            miDataGridView.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            miDataGridView.BackgroundColor = Color.White;
            miDataGridView.EnableHeadersVisualStyles = false;
            miDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            miDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            miDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }
    }
}
