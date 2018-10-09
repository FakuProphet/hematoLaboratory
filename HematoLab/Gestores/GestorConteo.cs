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
    class GestorConteo
    {
        public bool insertar(string fecha, string hora, string alias,int blasto,int promielocito,int mielNeut, int metaMielNeut, int neutCayado, int neutSegm,int eosino, int basof, int linf, int monoc,int linfReac, int celPlasm,int eritro, string paciente, string dni)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO CONTEO VALUES (@fecha,@hora,@alias, @blasto,@promie,@mielNeut,@metaMielNeut,@neutCay,@neuSeg,@eosino,@basof,@linf,@monoc,@linfReact,@celPlasm,@eritro,@paciente,@dni)", Conexion.ObtenerConexion());

            cmd.Parameters.Add("@fecha", SqlDbType.VarChar);
            cmd.Parameters.Add("@hora", SqlDbType.VarChar);
            cmd.Parameters.Add("@alias", SqlDbType.VarChar);
            cmd.Parameters.Add("@blasto", SqlDbType.Int);
            cmd.Parameters.Add("@promie", SqlDbType.Int);
            cmd.Parameters.Add("@mielNeut", SqlDbType.Int);
            cmd.Parameters.Add("@metaMielNeut", SqlDbType.Int);
            cmd.Parameters.Add("@neutCay", SqlDbType.Int);
            cmd.Parameters.Add("@neuSeg", SqlDbType.Int);
            cmd.Parameters.Add("@eosino", SqlDbType.Int);
            cmd.Parameters.Add("@basof", SqlDbType.Int);
            cmd.Parameters.Add("@linf", SqlDbType.Int);
            cmd.Parameters.Add("@monoc", SqlDbType.Int);
            cmd.Parameters.Add("@linfReact", SqlDbType.Int);
            cmd.Parameters.Add("@celPlasm", SqlDbType.Int);
            cmd.Parameters.Add("@eritro", SqlDbType.Int);
            cmd.Parameters.Add("@paciente", SqlDbType.VarChar);
            cmd.Parameters.Add("@dni", SqlDbType.VarChar);


            cmd.Parameters["@fecha"].Value = fecha;
            cmd.Parameters["@hora"].Value = hora;
            cmd.Parameters["@alias"].Value = alias;
            cmd.Parameters["@blasto"].Value = blasto;
            cmd.Parameters["@promie"].Value = promielocito;
            cmd.Parameters["@mielNeut"].Value= mielNeut;
            cmd.Parameters["@metaMielNeut"].Value= metaMielNeut;
            cmd.Parameters["@neutCay"].Value=neutCayado;
            cmd.Parameters["@neuSeg"].Value=neutSegm;
            cmd.Parameters["@eosino"].Value=eosino;
            cmd.Parameters["@basof"].Value=basof;
            cmd.Parameters["@linf"].Value=linf;
            cmd.Parameters["@monoc"].Value=monoc;
            cmd.Parameters["@linfReact"].Value=linfReac;
            cmd.Parameters["@celPlasm"].Value= celPlasm;
            cmd.Parameters["@eritro"].Value=eritro;
            cmd.Parameters["@paciente"].Value=paciente;
            cmd.Parameters["@dni"].Value=dni;



            int resultado = cmd.ExecuteNonQuery();
            Conexion.CerrarConexion();

            if (resultado > 0) return true;
            else return false;
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
    }
}
