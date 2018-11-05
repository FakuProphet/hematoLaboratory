using HematoLab.Clases;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HematoLab.Gestores
{
    class GestorInformeAdmUsuarios
    {


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

        public DataTable consultarTablaEspecial(string consulta)
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            da.SelectCommand = new SqlCommand(consulta, Conexion.ObtenerConexion());
            da.Fill(ds);
            dt = ds.Tables[0];
            Conexion.CerrarConexion();
            return dt;
        }









       

        public void To_pdf(DataGridView midg, string emitidoPor, string tituloDelPDF)
        {
            Document doc = new Document(PageSize.A4.Rotate(), 10, 10, 10, 10);
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"C:";
            saveFileDialog1.Title = "Guardar Reporte";
            saveFileDialog1.DefaultExt = "pdf";
            saveFileDialog1.Filter = "pdf Files (*.pdf)|*.pdf| All Files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            string filename = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = saveFileDialog1.FileName;
            }

            if (filename.Trim() != "")
            {
                FileStream file = new FileStream(filename,
                FileMode.OpenOrCreate,
                FileAccess.ReadWrite,
                FileShare.ReadWrite);
                PdfWriter.GetInstance(doc, file);
                doc.Open();
                string remito = new StringBuilder().Append("Emitido por: ").Append(" ").Append(emitidoPor).ToString();
                string envio = "Fecha:" + DateTime.Now.ToString();
                string titulo = tituloDelPDF;
                Chunk chunk = new Chunk(titulo, FontFactory.GetFont("SketchFlow Print", 20, iTextSharp.text.Font.BOLD));
                doc.Add(new Paragraph(chunk));
                doc.Add(new Paragraph("                       "));
                doc.Add(new Paragraph("                       "));
                doc.Add(new Paragraph("------------------------------------------------------------------------------------------"));
                doc.Add(new Paragraph("Sistema HematoLab"));
                doc.Add(new Paragraph(remito));
                doc.Add(new Paragraph(envio));
                doc.Add(new Paragraph("------------------------------------------------------------------------------------------"));
                doc.Add(new Paragraph("                       "));
                doc.Add(new Paragraph("                       "));
                GenerarDocumento(midg, doc);
                doc.AddCreationDate();
                doc.Add(new Paragraph("______________________________________________", FontFactory.GetFont("ARIAL", 20, iTextSharp.text.Font.BOLD)));
                doc.Add(new Paragraph("", FontFactory.GetFont("ARIAL", 20, iTextSharp.text.Font.BOLD)));
                doc.Close();
                Process.Start(filename);//Esta parte se puede omitir, si solo se desea guardar el archivo, y que este no se ejecute al instante
            }

        }
        public void GenerarDocumento(DataGridView miDataGrid, Document document)
        {
            int i, j;
            PdfPTable datatable = new PdfPTable(miDataGrid.ColumnCount);
            datatable.DefaultCell.Padding = 3;
            float[] headerwidths = GetTamañoColumnas(miDataGrid);
            datatable.SetWidths(headerwidths);
            datatable.WidthPercentage = 100;
            datatable.DefaultCell.BorderWidth = 2;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            for (i = 0; i < miDataGrid.ColumnCount; i++)
            {
                datatable.AddCell(miDataGrid.Columns[i].HeaderText);
            }
            datatable.HeaderRows = 1;
            datatable.DefaultCell.BorderWidth = 1;
            for (i = 0; i < miDataGrid.Rows.Count; i++)
            {
                for (j = 0; j < miDataGrid.Columns.Count; j++)
                {
                    if (miDataGrid[j, i].Value != null)
                    {
                        datatable.AddCell(new Phrase(miDataGrid[j, i].Value.ToString()));//En esta parte, se esta agregando un renglon por cada registro en el datagrid
                    }
                }
                datatable.CompleteRow();
            }
            document.Add(datatable);
        }


        public float[] GetTamañoColumnas(DataGridView dg)
        {
            float[] values = new float[dg.ColumnCount];
            for (int i = 0; i < dg.ColumnCount; i++)
            {
                values[i] = (float)dg.Columns[i].Width;
            }
            return values;

        }



    }
}
