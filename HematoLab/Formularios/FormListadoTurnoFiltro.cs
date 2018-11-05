using HematoLab.Gestores;
using System;
using System.Data;
using System.Windows.Forms;

namespace HematoLab.Formularios
{
    public partial class FormListadoTurnoFiltro : Form
    {

        GestorExtractorio miGestor;
        GestorDGV miGestorDGV;

        public FormListadoTurnoFiltro()
        {
            InitializeComponent();
            miGestor = new GestorExtractorio();
            miGestorDGV = new GestorDGV();
        }

        private void FormListadoTurnoFiltro_Load(object sender, EventArgs e)
        {
            fechaActual();
            cargarCombo(cboFiltroGrupoEtario,"GrupoEtario");
            miGestorDGV.efectosDGV(dataGridView1);
        }


    


        private void cargarCombo(ComboBox combo, string nombreTabla)
        {
            DataTable tabla = new DataTable();
            tabla = miGestor.consultarTabla(nombreTabla);
            combo.DataSource = tabla;
            combo.DisplayMember = tabla.Columns[1].ColumnName;
            combo.ValueMember = tabla.Columns[0].ColumnName;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedIndex = 0;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void fechaActual()
        {
            txtFechaActual.Text = DateTime.Today.ToShortDateString();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string query = "select * from listadoTurnosPorGrupoEtario v where v.[Grupo Etario] like '%" + cboFiltroGrupoEtario.Text + "%' and v.[Estado del turno] not like 'Cancelado' and v.[Turnos de la fecha] like '%"+txtFechaActual.Text.Trim()+"%' ";
            miGestorDGV.cargarDataGrid(dataGridView1, query);
        }

      
    }
}
