using HematoLab.Clases;
using HematoLab.Gestores;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace HematoLab.Formularios
{
    public partial class FormAdmTurno : MetroFramework.Forms.MetroForm
    {

        GestorTurnos miGestor;
        GestorPacientes miGestorPacientes;
        Paciente[] vPacientes;
        Extractorio[] vTurnosDelDia;
        private Timer tiempo;

        public FormAdmTurno()
        {

            tiempo = new Timer();
            tiempo.Tick += new EventHandler(eventoReloj);

            InitializeComponent();
            miGestor = new GestorTurnos();
            miGestorPacientes = new GestorPacientes();
            vPacientes = miGestorPacientes.GetPacientes();
            vTurnosDelDia = miGestor.GetTurnosExtractorioDelDia();
            tiempo.Enabled = true;
        }

        private void eventoReloj(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Now;
            lblHoraActual.Text = hoy.ToString("H:mm");
        }

        private void FormAdmTurno_Load(object sender, EventArgs e)
        {
            efectosDataGridView();
            fechaActual();
            cargarCombo(cboHora,"Horas");
            miGestorPacientes.CargarListadoPacientes(lstPacientes);
            comprobarLista();
            mostrarCantidadTurnosCancelados();
        }

        private void mostrarCantidadTurnosCancelados()
        {
            try
            {
                lblTurnosCancelados.Text = miGestor.GetCantidadTurnosCancelados(txtFecha.Text);
            }
            catch (Exception)
            {
                MetroFramework.MetroMessageBox.Show(this, "Error al obtener la cantidad de turnos cancelados");
            }

        }

        private void cargarCampo(int posicion)
        {
            txtDni.Text = vPacientes[posicion].numeroDocumento.ToString();
            txtCodigoPaciente.Text = vPacientes[posicion].codigo.ToString();
            txtNombre.Text = vPacientes[posicion].nombre;
            txtApellido.Text = vPacientes[posicion].apellido;
        }



        private void Filtrar(string parametro)
        {
            // asegurarnos q tengamos una cadena para buscar.
            if (parametro != string.Empty)
            {
                // Buscar el item en la lista, y guardar su index.
                int index = lstPacientes.FindString(parametro);
                // Determinamos si es un index valido. lo seleccionamos.
                if (index != -1)
                    lstPacientes.SetSelected(index, true);
                else
                    MessageBox.Show("El número de dni no existe...","Aviso");
            }
        }

        private void comprobarLista()
        {
            if (lstPacientes.Items.Count == 0)
            {
                MessageBox.Show("Lista Vacia.","Aviso");
               // btnEliminarTurno.Enabled = false;
            }
            else
                lstPacientes.SelectedIndex = 0;
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

        public void efectosDataGridView()
        {
            //   dataGridViewReporte.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.None;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
           
        }

        private void btnEliminarTurno_Click(object sender, EventArgs e)
        {
            if (valorCelda != "")
            {
                if (estado == "Realizado")
                {
                    MetroFramework.MetroMessageBox.Show(this, "Los turnos realizados no se pueden cancelar.");
                }
                else if (estado == "Cancelado")
                {
                    MetroFramework.MetroMessageBox.Show(this, "El turno seleccionado ya fue cancelado.");
                }
                else
                {
                    if (MetroFramework.MetroMessageBox.Show(this, "Seguro quiere cancelar el turno numero : " + valorCelda + " ?", "Cancelar turno", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //  miGestor.cambiarEstadoTurno(3, "Extracciones", Convert.ToInt32(valorCelda));
                        miGestor.EliminarTurno("Extracciones",Convert.ToInt32(valorCelda));
                        valorCelda = "";
                        string parametro = txtFecha.Text.Trim();
                        miGestor.cargarDataGrid(dataGridView1, "select * from vista1 v where v.[Turnos de la fecha] like '%" + parametro + "%'");
                        mostrarCantidadTurnosCancelados();
                    }
                    else
                    {
                        valorCelda = "";
                    }
                }
                         
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "No hay turnos seleccionados para cancelar", "Aviso");
            }
        }

        
        private void btnAbrirAdmPacientes_Click(object sender, EventArgs e)
        {
            FormAdmPacientes admpac = new FormAdmPacientes();
            admpac.ShowDialog();
        }

        private void btnGrabarTurno_Click(object sender, EventArgs e)
        {
            
            try
            {
                int codigo = Convert.ToInt32(txtCodigoPaciente.Text); 
                int idHora = Convert.ToInt32(cboHora.SelectedValue);
                int ext=0; int cito=0; int eritro=0; int reti=0;

                if (ckbExt.Checked)
                {
                    ext = 1;
                }

                if(ckbCito.Checked)
                {
                    cito = 1;
                }

                if (ckbEritro.Checked)
                {
                    eritro = 1;
                }

                if (ckbReti.Checked)
                {
                   reti = 1;
                }


                if (MetroFramework.MetroMessageBox.Show(this,"Se recomienda revisar que los pedidos esten correctos antes de continuar. Desea registrar el turno? ","Registrar turno", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {   
                    string tabla = "Extracciones";
                    miGestor.generarTurno(codigo, idHora, tabla, ext, cito, eritro, reti);
                    string parametro = txtFecha.Text.Trim();
                    miGestor.cargarDataGrid(dataGridView1, "select * from vista1 v where v.[Turnos de la fecha] like '%" + parametro + "%' order by v.[Nombre del paciente]");
                    lblExisteTurno.Text = "";
                    btnGrabarTurno.Enabled = false;
                }
            }
            catch (Exception error)
            {
                MetroFramework.MetroMessageBox.Show(this,error.ToString());
            }
            
        }



        private void btnAbrirAdmPacientes_MouseHover(object sender, EventArgs e)
        {
            ToolTip mensaje = new ToolTip();
            mensaje.SetToolTip(btnAbrirAdmPacientes, "Abre la ventana de administración de pacientes.");
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            Filtrar(txtBuscar.Text);
        }

        private void lstPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarCampo(lstPacientes.SelectedIndex);       
        }

        public void cargarDataGrid()
        {
            string consulta2 = "SELECT v.[Número de orden],v.[Nombre del paciente],v.[Turnos de la fecha],v.[Horario del turno]," +
                "v.[Estado del turno]" +
                " FROM turnos_vista v ORDER BY 1";
            miGestor.cargarDataGrid(dataGridView1, consulta2);
        }

       


       
        private bool disponibilidadTurnoHora(string hora,string fecha)
        {
            bool disponible = true;

            DataTable miDT = miGestor.realizarConsulta("select * from vista1 v where v.[Turnos de la fecha] like '%"+fecha+"%'");
            
            foreach (DataRow fila in miDT.Rows)
            {
                if (fila != null)
                {
                    if (fila[0].ToString() == hora && fila[1].ToString() == "Cancelado")
                    {
                        disponible = true;
                        lblExisteTurno.ForeColor = Color.Green;
                        lblExisteTurno.Text = "Horario disponible";
                        //  btnGrabarTurno.Enabled = true;
                    }       
                }
          
            }

            return disponible;
        }

     

        private void btnVerificarTurno_Click(object sender, EventArgs e)
        {
            //string parametroHora = cboHora.Text ;
            //disponibilidadTurnoHora(parametroHora); 
            int id = Convert.ToInt32(cboHora.SelectedValue);
            string fecha = txtFecha.Text;

            if (miGestor.GetDisponibilidadHora(id, fecha))
            {
                lblExisteTurno.Text = "Disponible";
                lblExisteTurno.ForeColor = Color.Green;
                btnGrabarTurno.Enabled = true;
            }
            else
            {
                lblExisteTurno.Text = "No Disponible";
                lblExisteTurno.ForeColor = Color.Red;
                btnGrabarTurno.Enabled = false;
            }
        }

        private string estado;
        private string valorCelda;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.CurrentRow.Index!=-1)
            {
                valorCelda = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                estado = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MessageBox.Show("Click sobre encabezado, no aplicable...");
        }

        private void dataGridView1_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MessageBox.Show("Click sobre encabezado, no aplicable...");
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                txtBuscar.Focus();
                return;
            }
        }

        private void fechaActual()
        {
            txtFecha.Text = DateTime.Today.ToShortDateString();
            Fecha.fecha = txtFecha.Text;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();  
        }

        private void FormAdmTurno_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Abandonar Administración de turnos?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnUpdateListado_Click(object sender, EventArgs e)
        {
            vPacientes = miGestorPacientes.GetPacientes();
            miGestorPacientes.CargarListadoPacientes(lstPacientes);
            lstPacientes.SelectedIndex = 0;
        }


         
        private void cboHora_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnCargarListado_Click(object sender, EventArgs e)
        {
            string parametro = txtFecha.Text.Trim();
            miGestor.cargarDataGrid(dataGridView1, "select * from vista1 v where v.[Turnos de la fecha] like '%"+parametro+ "%' order by v.[Nombre del paciente]");
        }

        private void txtFiltrarTurnos_KeyUp(object sender, KeyEventArgs e)
        {
            string consulta= "select * from vista1 v where v.[Nro Documento paciente] like '%" + txtFiltrarTurnos.Text + "%' and v.[Turnos de la fecha] like '%" + txtFecha.Text + "%' order by v.[Nombre del paciente] ";
            miGestor.cargarDataGrid(dataGridView1, consulta);
        }

        private void txtFiltrarTurnos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                txtFiltrarTurnos.Focus();
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormPacientesTurnosCancelados nuevo = new FormPacientesTurnosCancelados();
            nuevo.fecha = txtFecha.Text;
            nuevo.ShowDialog();
        }

      
    }
}
