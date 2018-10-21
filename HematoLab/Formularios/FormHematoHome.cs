using HematoLab.Clases;
using HematoLab.Gestores;
using System;
using System.Windows.Forms;

namespace HematoLab.Formularios
{
    public partial class FormHematoHome : MetroFramework.Forms.MetroForm
    {


        GestorHemato miGestorHemato;    
        private string paciente;
        private string dni;
        private string edad;
        private string grupoEtario;
        private string texto;
        const int tam = 2000;


        public FormHematoHome()
        {
            InitializeComponent();
            miGestorHemato = new GestorHemato();
            paciente = "";
            dni = "";
            edad = "";
            grupoEtario = "";
            texto = "";
        }


        private void FormHematoHome_Load(object sender, EventArgs e)
        {
            fechaActual();
            miGestorHemato.efectosDGV(dataGridView1);
            cargarDGV();
            ocultarcelda();
        }


        private void fechaActual()
        {
            txtFechaActual.Text = DateTime.Today.ToShortDateString();
        }


        private void inicio()
        {
            btnCancelar.Enabled = false;
            btnSiguiente.Enabled = false;
            btnSeleccionPaciente.Enabled = true;
            paciente = "";
            dni = "";
            edad = "";
            grupoEtario = "";
        }


        private void siguiente()
        {
            btnSeleccionPaciente.Enabled = false;
            btnSiguiente.Enabled = true;
            btnCancelar.Enabled = true;
        }



        private void btnSeleccionPaciente_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(edad) && !String.IsNullOrEmpty(grupoEtario) && !String.IsNullOrEmpty(dni) && !String.IsNullOrEmpty(paciente) && !String.IsNullOrEmpty(texto))
            {
                if (texto == "Muestra No Disponible")
                {
                    MetroFramework.MetroMessageBox.Show(this, "El paciente " +paciente.ToUpper()+ " No posee muestra para analizar");
                }
                else
                {
                    if (MetroFramework.MetroMessageBox.Show(this, "Desea proseguir con el paciente: " + paciente.ToString().ToUpper() + " documento número: " + dni.ToString() + " ?", "Analizar Datos Hemograma.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        siguiente();
                    }
                    else
                    {
                        inicio();
                    }
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "No ha seleccionado ningun paciente.");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            inicio();
        }


        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            FormHemograma nuevo = new FormHemograma();
            string paciente = this.paciente;
            string documento = dni;
            string edad = this.edad;
            string ge = grupoEtario;
            nuevo.lblPaciente.Text = paciente;
            nuevo.LBLNroDoc.Text = documento;
            nuevo.txtEdad.Text = edad;
            nuevo.lblEdad.Text = edad;
            nuevo.lblGrupoEtario.Text = ge;
           // this.Hide();
            this.Close();
            this.Dispose();
            nuevo.ShowDialog();
        }

        void cargarDGV()
        {
            miGestorHemato.cargarDataGrid(dataGridView1, txtFechaActual.Text, "vista");
            ocultarcelda();
        }


        private void btnCargar_Click(object sender, EventArgs e)
        {
            miGestorHemato.cargarDataGrid(dataGridView1, txtFechaActual.Text, "vista");
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MessageBox.Show("Click sobre encabezado, no aplicable...");
        }

        private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MessageBox.Show("Click sobre encabezado, no aplicable...");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index != -1)
            {
                paciente = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                dni = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                grupoEtario = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                edad = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                texto = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                DatoDTO.numeroDeOrden = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                DatoDTO.codigoGrupoEtario = Convert.ToInt32(dataGridView1.CurrentRow.Cells[12].Value.ToString());
                DatoDTO.codigoGenero = Convert.ToInt32(dataGridView1.CurrentRow.Cells[13].Value.ToString());
                DatoDTO.codigoPaciente = Convert.ToInt32(dataGridView1.CurrentRow.Cells[14].Value.ToString());
            }
        }

        void ocultarcelda()
        {
            dataGridView1.Columns[11].Visible = false;/*visibilidad lab*/
            dataGridView1.Columns[12].Visible = false;/*cod Grupo etario*/
            dataGridView1.Columns[13].Visible = false;/*cod genero*/
            dataGridView1.Columns[14].Visible = false;/*cod paciente*/
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Desea abandonar y volver a la ventana principal?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
               this.Close();
               this.Dispose();
            }
            else
            {
                
            }
        }

        //private void FormHematoHome_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if (MetroFramework.MetroMessageBox.Show(this, "Desea abandonar y volver a la ventana principal?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //    {
        //        e.Cancel = false;
        //    }
        //    else
        //    {
        //        e.Cancel = true;
        //    }
        //}

        private void btnFiltroFecha_Click(object sender, EventArgs e)
        {
            try
            {
                miGestorHemato.cargarDataGrid(dataGridView1,dateTimePicker1.Value.ToShortDateString(), "vista");
                if(dataGridView1.Rows.Count==0)
                {
                    MetroFramework.MetroMessageBox.Show(this,"No se encontraron estudios sin realizar.");
                }
                else
                {

                }
            }
            catch (Exception error)
            {
                MetroFramework.MetroMessageBox.Show(this, "Ha ocurrido un error, Si lo desea, puede tomar una captura y enviar a la dirección de email de soporte técnico: " + error.ToString() );
            }
                 
        }
    }
}
