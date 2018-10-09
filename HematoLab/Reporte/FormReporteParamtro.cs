using HematoLab.Clases;
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

namespace HematoLab.Reporte
{
    public partial class FormReporteParamtro : MetroFramework.Forms.MetroForm
    {
        public string parametro;
        public string fecha;
        public int dni;
        public int idGenero;
        GestorReporte miGestor;
        Paciente[] vP;


        public FormReporteParamtro()
        {
            InitializeComponent();
            miGestor = new GestorReporte();
            vP = miGestor.GetPacientes();
        }


        private void btnReporte_Click(object sender, EventArgs e)
        {
            fecha = cboFechasEstudios.Text;
            dni = Convert.ToInt32 (txtDni.Text);
            if (!String.IsNullOrEmpty(cboFechasEstudios.Text))
            {
                FormInforme nuevo = new FormInforme();
                nuevo.fecha = fecha;
                nuevo.dni = dni;
                nuevo.idGenero = this.idGenero;
                nuevo.Show();
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Este paciente no tiene estudios  Hematológicos realiizados.");
            }
        }

        private void FormReporteParamtro_Load(object sender, EventArgs e)
        {
            miGestor.CargarListado(lstPacientes);
            comprobarLista();
        }

        private void cargarCampos(int i)
        {
            lblPaciente.Text = vP[i].apellido.ToUpper() + ' ' + vP[i].nombre.ToString();
            txtDni.Text = vP[i].numeroDocumento.ToString();
            idGenero = vP[i].genero;
        }

        private void comprobarLista()
        {
            if (lstPacientes.Items.Count == 0)
            {
                MessageBox.Show("Lista Vacia.");
                btnReporte.Enabled = false;
            }
            else
                lstPacientes.SelectedIndex = 0;
        }

        private void txtDniFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void cargarComboEspecial(ComboBox combo)
        {
            DataTable tabla = new DataTable();
            tabla = miGestor.consultarEspecial(Convert.ToInt32(txtDni.Text));
            combo.DataSource = tabla;
            combo.DisplayMember = tabla.Columns[0].ColumnName;
            combo.ValueMember = tabla.Columns[0].ColumnName;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedIndex = 1;
        }

        private void cargarComboEspecial2(ComboBox combo)
        {
            DataTable tabla = new DataTable();
            tabla = miGestor.consultarEspecial2(Convert.ToInt32(txtDni.Text));
            combo.DataSource = tabla;
            combo.DisplayMember = tabla.Columns[0].ColumnName;
            combo.ValueMember = tabla.Columns[0].ColumnName;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedIndex = 1;
        }

        private void lstPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lstPacientes.SelectedIndex;
            cargarCampos(index);

            try
            {
                cargarComboEspecial(cboFechasEstudios);
    //                cargarComboEspecial2(cboNumero);
            }
            catch (Exception)
            {
                
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string doc = txtDniFind.Text;
            BuscarDoc(doc);
        }

        private void BuscarDoc(string searchString)
        {

            if (searchString != string.Empty)
            {

                int index = lstPacientes.FindString(searchString);

                if (index != -1)
                    lstPacientes.SetSelected(index, true);
                else
                    MetroFramework.MetroMessageBox.Show(this, "El nro de documento no existe...");
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
