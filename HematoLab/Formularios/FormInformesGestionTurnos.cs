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
    public partial class FormInformesGestionTurnos : MetroFramework.Forms.MetroForm
    {

        GestorInformeAdmTurnos miGestor;

        public FormInformesGestionTurnos()
        {
            InitializeComponent();
            miGestor = new GestorInformeAdmTurnos();
        }

        private void FormInfPacObraSocial_Load(object sender, EventArgs e)
        {
            miGestor.efectosDGV(dataGridView1);
            cargarCombos();
        }

        private void btnCargarLista_Click(object sender, EventArgs e)
        {
            miGestor.cargarDataGrid(dataGridView1, "select * from vista_pac_obra_social", "vista");
        }

        private void btnCargarListaPorGE_Click(object sender, EventArgs e)
        {
            miGestor.cargarDataGrid(dataGridView1, "SELECT * FROM vista_pac_grupo_etario ORDER BY 2", "vista");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            miGestor.cargarDataGrid(dataGridView1, "SELECT * FROM vista_pac_datos_de_contacto ORDER BY 1 ASC", "vista");
        }

        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MetroFramework.MetroMessageBox.Show(this,"La lista esta vacia, mostrar datos antes de generar el PDF.");
            }
            else
            {
                miGestor.To_pdf(dataGridView1, "Hemato lab informes.", "LISTADO DE PACIENTES ASOCIADOS POR GRUPO ETARIO");
            }
        }

        private void btnGenerarPDFOS_Click(object sender, EventArgs e)
        {
            miGestor.To_pdf(dataGridView1, "Hemato lab informes.", "LISTADO DE PACIENTES ASOCIADOS POR OBRA SOCIAL");
        }

        private void mostrarGroupBox()
        {
            int parametro = Convert.ToInt32(cboSeleccion.SelectedIndex);

            if(parametro>0)
            {
                if(parametro==1)
                {
                    groupBoxFiltroGE.Enabled = true;
                    groupBoxFiltroOS.Enabled = false;
                    groupBoxDatosCont.Enabled = false;
                }
                if (parametro == 2)
                {
                    groupBoxFiltroOS.Enabled = true;
                    groupBoxDatosCont.Enabled = false;
                    groupBoxFiltroGE.Enabled = false;
                }
                if (parametro == 3)
                {
                    groupBoxDatosCont.Enabled = true;
                    groupBoxFiltroOS.Enabled = false;
                    groupBoxFiltroGE.Enabled = false;
                }
            }
        }

        private void cargarCombos()
        {
            cargarCombo(cboGrupoEtario,"GrupoEtario",1);
            cargarCombo(cboObraSocial,"ObrasSociales",2);
            cboSeleccion.SelectedIndex = 0;
            cboObraSocial.SelectedIndex = 1;
        }


        private void cargarCombo(ComboBox combo, string nombreTabla,int displayMember)
        {
            DataTable tabla = new DataTable();
            tabla = miGestor.consultarTabla(nombreTabla);
            combo.DataSource = tabla;
            combo.DisplayMember = tabla.Columns[displayMember].ColumnName;
            combo.ValueMember = tabla.Columns[0].ColumnName;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedIndex = 0;
        }

        private void btnFiltroGrupoEtario_Click(object sender, EventArgs e)
        {
            string parametro = cboGrupoEtario.Text;
            miGestor.cargarDataGrid(dataGridView1, "SELECT * FROM vista_pac_grupo_etario V WHERE V.[GRUPO ETARIO] LIKE '%"+parametro+"%'  ORDER BY 1","vista");
        }

        private void btnFiltroOS_Click(object sender, EventArgs e)
        {
            string parametro = cboObraSocial.Text;
            miGestor.cargarDataGrid(dataGridView1, "select * from vista_pac_obra_social v where v.SIGLA like '%"+parametro+"%' ", "vista");
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboSeleccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            mostrarGroupBox();
            dataGridView1.DataSource = "";
        }

        private void btnLstDatosContactoPDF_Click(object sender, EventArgs e)
        {
            miGestor.To_pdf(dataGridView1,"Sistema HematoLab","LISTADO COMPLETO DE PACIENTES CON DATOS DE CONTACTO.");
        }

        private void FormInformesGestionTurnos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Desea abandonar y salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

      
    }
}
