using HematoLab.Gestores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HematoLab.Formularios
{
    public partial class FormListadoConteos : MetroFramework.Forms.MetroForm
    {
        GestorConteo miGestor;
        public string fecha;
        public string dni;


        public FormListadoConteos()
        {
            InitializeComponent();
            miGestor = new GestorConteo();
        }

        private void FormListadoConteos_Load(object sender, EventArgs e)
        {
            efectosDataGridView();
        }

        public void efectosDataGridView()
        {
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                string consulta = "Select * from vista_lista_conteos v where v.Fecha like '%" + fecha + "%' and v.Dni like '%" + dni + "%'";
                miGestor.cargarDataGrid(dataGridView1, consulta);

                if (dataGridView1.Rows.Count == 0)
                {
                    MetroFramework.MetroMessageBox.Show(this, "No hay datos para mostrar");
                }
            
            }
            catch (Exception exc)
            {
                MetroFramework.MetroMessageBox.Show(this, "No se pudo obtener los datos: " + exc.ToString() , "Error al obtener los datos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
           
        }
    }
}
