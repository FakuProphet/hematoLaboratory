using HematoLab.Gestores;
using System;
using System.Windows.Forms;

namespace HematoLab.Formularios
{
    public partial class FormListadoConteos : MetroFramework.Forms.MetroForm
    {
        GestorConteo miGestor;
        GestorDGV miGestorDGV;
        public string fecha;
        public string dni;


        public FormListadoConteos()
        {
            InitializeComponent();
            miGestor = new GestorConteo();
            miGestorDGV = new GestorDGV();
        }

        private void FormListadoConteos_Load(object sender, EventArgs e)
        {
            miGestorDGV.efectosDataGridView(this.dataGridView1);
        }

     

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            try
            {
                string consulta = "Select * from vista_lista_conteos v where v.Fecha like '%" + fecha + "%' and v.Dni like '%" + dni + "%'";
                miGestorDGV.cargarDataGrid(dataGridView1, consulta);

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
