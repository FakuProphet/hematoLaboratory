using HematoLab.Gestores;
using System;
using System.Data;
using System.Windows.Forms;

namespace HematoLab.Formularios
{
    public partial class FormInformesGestionUsuarios : MetroFramework.Forms.MetroForm
    {

        GestorInformeAdmUsuarios gestor;


        public FormInformesGestionUsuarios()
        {
            InitializeComponent();
            gestor = new GestorInformeAdmUsuarios();
        }

        private void FormInformesGestionUsuarios_Load(object sender, EventArgs e)
        {
            inicio();
        }

        void inicio()
        {
            cargarCombo(cboTurnos, "TurnoLaboral");
            cargarCombo(cboTurnoExt,"TurnoLaboral");
            gestor.efectosDGV(dataGridView1);
            cboSeleccion.SelectedIndex = 0;
            cboEspecialidad.SelectedIndex = 0;
        }




        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void limpiarDGV()
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            dt.Clear();
        }

        private void mostrarGroupBox()
        {
            int parametro = Convert.ToInt32(cboSeleccion.SelectedIndex);

            if (parametro > 0)
            {
                if (parametro == 1)
                {
                    groupBoxFiltroPPT.Enabled = true;
                    groupBoxPNM.Enabled = false;
                    groupBoxPEXT.Enabled = false;
                    groupBox1FiltroPPE.Enabled = false;
                }

                if (parametro == 2)
                {
                    groupBoxFiltroPPT.Enabled = false;
                    groupBoxPNM.Enabled = false;
                    groupBoxPEXT.Enabled = false;
                    groupBox1FiltroPPE.Enabled = true;
                }

                if (parametro == 3)
                {
                    groupBoxFiltroPPT.Enabled = false;
                    groupBoxPNM.Enabled = true;
                    groupBoxPEXT.Enabled = false;
                    groupBox1FiltroPPE.Enabled = false;
                }

                if (parametro == 4)
                {
                    groupBoxFiltroPPT.Enabled = false;
                    groupBoxPNM.Enabled = false;
                    groupBoxPEXT.Enabled = true;
                    groupBox1FiltroPPE.Enabled = false;
                }


            }

        }

            private void cargarCombo(ComboBox combo, string nombreTabla)
            {
                DataTable tabla = new DataTable();
                tabla = gestor.consultarTabla(nombreTabla);
                combo.DataSource = tabla;
                combo.DisplayMember = tabla.Columns[1].ColumnName;
                combo.ValueMember = tabla.Columns[0].ColumnName;
                combo.DropDownStyle = ComboBoxStyle.DropDownList;
                combo.SelectedIndex = 0;
            }

            private void cboSeleccion_SelectedIndexChanged(object sender, EventArgs e)
            {
                mostrarGroupBox();  
            }

           

            private void btnGenerarPDFPPT_Click(object sender, EventArgs e)
            {
                if (dataGridView1.Rows.Count != 0)
                {
                    gestor.To_pdf(dataGridView1, "Sistema HematoLab", "LISTADO PROFESIONALES ");
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "La lista esta vacia no se puede generar PDF vacio.");
                }
            }

        private void btnFiltroEspHem_Click(object sender, EventArgs e)
        {
            string parametro = cboEspecialidad.Text;
            gestor.cargarDataGrid(dataGridView1, "SELECT * FROM vista_prof_por_turno v WHERE v.Especialidad LIKE '%" + parametro + "%'  ORDER BY 1", "vista");
        }

        private void btnFiltroPPT_Click_1(object sender, EventArgs e)
        {
            string parametro = cboTurnos.Text;
            gestor.cargarDataGrid(dataGridView1, "SELECT * FROM vista_prof_por_turno v WHERE v.[Turno de Trabajo] LIKE '%" + parametro + "%'  ORDER BY 1", "vista");
        }

        private void btnCargarListaPPT_Click_1(object sender, EventArgs e)
        {
            gestor.cargarDataGrid(dataGridView1, "SELECT * FROM vista_prof_por_turno  ORDER BY 1", "vista");
        }

        private void btnListadoPNM_Click(object sender, EventArgs e)
        {
            gestor.cargarDataGrid(dataGridView1, "SELECT * FROM vista_personal_no_medico  ORDER BY 1", "vista");
        }

        private void btnGenerarPDFPNM_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                gestor.To_pdf(dataGridView1, "Sistema HematoLab", "LISTADO PERSONAL NO MEDICO");
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "La lista esta vacia no se puede generar PDF vacio.");
            }
        }

        private void cboSeleccion_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            mostrarGroupBox();
            dataGridView1.DataSource = "";
        }

        private void FormInformesGestionUsuarios_FormClosing_1(object sender, FormClosingEventArgs e)
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

        private void btnFiltroPExt_Click(object sender, EventArgs e)
        {
            string parametro = cboTurnoExt.Text;
            gestor.cargarDataGrid(dataGridView1, "SELECT * FROM vista_personal_extractorio v where v.[Turno Laboral] like '%"+parametro+"%' ORDER BY 1", "vista");
        }

        private void btnListadoPExt_Click(object sender, EventArgs e)
        {
            gestor.cargarDataGrid(dataGridView1, "SELECT * FROM vista_personal_extractorio ORDER BY 1", "vista");
        }

        private void btnGenerarPDFPExt_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                gestor.To_pdf(dataGridView1, "Sistema HematoLab", "LISTADO PERSONAL TECNICO -EXTRACTORIO-");
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "La lista esta vacia no se puede generar PDF vacio.");
            }
        }

        private void btnGenerarPDFPPT_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                gestor.To_pdf(dataGridView1, "Sistema HematoLab", "LISTADO PROFESIONALES -ESPECIALISTAS-");
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "La lista esta vacia no se puede generar PDF vacio.");
            }
        }

        private void btnGenerarPDFPPT_Click_2(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                gestor.To_pdf(dataGridView1, "Sistema HematoLab", "LISTADO PROFESIONALES -ESPECIALISTAS-");
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "La lista esta vacia no se puede generar PDF vacio.");
            }
        }

        private void btnFiltroEspHem_Click_1(object sender, EventArgs e)
        {
           string parametro = cboEspecialidad.Text;
            gestor.cargarDataGrid(dataGridView1, "SELECT * FROM vista_prof_por_turno v WHERE v.Especialidad LIKE '%" + parametro + "%'  ORDER BY 1", "vista");
        
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                gestor.To_pdf(dataGridView1, "Sistema HematoLab", "LISTADO PERSONAL PROFESIONALES");
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "La lista esta vacia no se puede generar PDF vacio.");
            }
        }
    }
}
