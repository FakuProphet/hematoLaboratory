using HematoLab.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;
using System.Drawing;

namespace HematoLab.Gestores
{
    class GestorInformeAdmTurnos
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



        public void cargarDataGrid(DataGridView miDataGrid, string consulta, string tablaConsulta)
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


        public void To_pdf(DataGridView midg, string emitidoPor,string tituloDelPDF)
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
                string envio = "Fecha: " + DateTime.Now.ToString();
                string titulo = tituloDelPDF;
                
                Chunk chunk = new Chunk(titulo, FontFactory.GetFont("Verdana", 20, iTextSharp.text.Font.BOLD));
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


        public void imagen()
        {

            // Creamos el documento con el tamaño de página tradicional
            Document doc = new Document(PageSize.LETTER);
            // Indicamos donde vamos a guardar el documento
            PdfWriter writer = PdfWriter.GetInstance(doc,
            new FileStream(@"C:\prueba.pdf", FileMode.Create));

            // Le colocamos el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("Mi primer PDF");
            doc.AddCreator("Roberto Torres");

            // Abrimos el archivo
            doc.Open();
            // Creamos el tipo de Font que vamos utilizar
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            // Escribimos el encabezamiento en el documento
            doc.Add(new Paragraph("Mi primer documento PDF"));
            doc.Add(Chunk.NEWLINE);

            // Creamos una tabla que contendrá el nombre, apellido y país
            // de nuestros visitante.
            PdfPTable tblPrueba = new PdfPTable(3);
            tblPrueba.WidthPercentage = 100;

            // Configuramos el título de las columnas de la tabla
            PdfPCell clNombre = new PdfPCell(new Phrase("Nombre", _standardFont));
            clNombre.BorderWidth = 0;
            clNombre.BorderWidthBottom = 0.75f;

            PdfPCell clApellido = new PdfPCell(new Phrase("Apellido", _standardFont));
            clApellido.BorderWidth = 0;
            clApellido.BorderWidthBottom = 0.75f;

            PdfPCell clPais = new PdfPCell(new Phrase("País", _standardFont));
            clPais.BorderWidth = 0;
            clPais.BorderWidthBottom = 0.75f;

            // Añadimos las celdas a la tabla
            tblPrueba.AddCell(clNombre);
            tblPrueba.AddCell(clApellido);
            tblPrueba.AddCell(clPais);

            // Llenamos la tabla con información
            clNombre = new PdfPCell(new Phrase("Roberto", _standardFont));
            clNombre.BorderWidth = 0;

            clApellido = new PdfPCell(new Phrase("Torres", _standardFont));
            clApellido.BorderWidth = 0;

            clPais = new PdfPCell(new Phrase("Puerto Rico", _standardFont));
            clPais.BorderWidth = 0;

            // Añadimos las celdas a la tabla
            tblPrueba.AddCell(clNombre);
            tblPrueba.AddCell(clApellido);
            tblPrueba.AddCell(clPais);
            // Finalmente, añadimos la tabla al documento PDF y cerramos el documento
            doc.Add(tblPrueba);

            doc.Close();
            writer.Close();















            /*
            // Se crea el documento con el tamaño de página tradicional
            Document doc = new Document(PageSize.LETTER);
            // Indicamos donde vamos a guardar el documento
            PdfWriter writer = PdfWriter.GetInstance(doc,
                                        new FileStream(@"C:\Users\faku\Desktop", FileMode.Create));

            // Se le coloca el título y el autor
            // **Nota: Esto no será visible en el documento
            doc.AddTitle("Mi primer PDF");
            doc.AddCreator("Ricardo Carrasco S.-");

            // Abrimos el archivo
            doc.Open();
            // Se crea el tipo de Font que vamos utilizar
            iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

            // Se escribe el encabezamiento en el documento
            doc.Add(new Paragraph("Mi primer documento PDF"));
            doc.Add(Chunk.NEWLINE);

            // Se crean las tablas (en este caso 3)
            PdfPTable tblPrueba = new PdfPTable(3);
            tblPrueba.WidthPercentage = 100;

            // Se configura el título de las columnas de la tabla
            PdfPCell clNombrePrimera = new PdfPCell(new Phrase("nombrePrimeraTabla", _standardFont));
            clNombrePrimera.BorderWidth = 0;
            clNombrePrimera.BorderWidthBottom = 0.75f;

            PdfPCell clNombreSegunda = new PdfPCell(new Phrase("nombreSegundaTabla", _standardFont));
            clNombreSegunda.BorderWidth = 0;
            clNombreSegunda.BorderWidthBottom = 0.75f;

            PdfPCell clNombreTercera = new PdfPCell(new Phrase("nombreTerceraTabla", _standardFont));
            clNombreTercera.BorderWidth = 0;
            clNombreTercera.BorderWidthBottom = 0.75f;

            // se añade las celdas a la tabla
            tblPrueba.AddCell(clNombrePrimera);
            tblPrueba.AddCell(clNombreSegunda);
            tblPrueba.AddCell(clNombreTercera);

            // se llena la tabla con información
            clNombrePrimera = new PdfPCell(new Phrase("Info_Tabla1", _standardFont));
            clNombrePrimera.BorderWidth = 0;

            clNombreSegunda = new PdfPCell(new Phrase("Info_Tabla2", _standardFont));
            clNombreSegunda.BorderWidth = 0;

            clNombreTercera = new PdfPCell(new Phrase("Info_Tabla3", _standardFont));
            clNombreTercera.BorderWidth = 0;

            // Añadimos las celdas a la tabla
            tblPrueba.AddCell(clNombrePrimera);
            tblPrueba.AddCell(clNombreSegunda);
            tblPrueba.AddCell(clNombreTercera);

            // Finalmente, se añade la tabla al documento PDF y se cierra el documento
            doc.Add(tblPrueba);

            doc.Close();
            writer.Close();
            */
        }

    }
}
