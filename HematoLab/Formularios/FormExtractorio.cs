using HematoLab.Clases;
using HematoLab.Gestores;
using System;
using System.Data;
using System.Windows.Forms;


namespace HematoLab.Formularios
{
    public partial class FormExtractorio : MetroFramework.Forms.MetroForm
    {

        GestorExtractorio miGestor;
        private string consulta;
        private bool bandera;
        private ExtractorioDTO[] vExtracciones;
       

        public FormExtractorio()
        {
            InitializeComponent();
            miGestor = new GestorExtractorio();
            consulta = miGestor.obtenerConsulta();
            //  vExtracciones = miGestor.GetTurnosExtractorioVista();
            bandera = false;
            
        }


        private void fechaActual()
        {
            label14.Text = DateTime.Today.ToShortDateString();
            label14.Text = DateTime.Today.ToShortDateString();
        }

        private void FormExtractorio_Load(object sender, EventArgs e)
        {
            fechaActual();
          //  txtFechaDeHoy.Text = DateTime.Today.ToShortDateString();
            cargarCombo(cboCambiarEstado,"EstadoTurno");
            //cargarComboEspecial(cboUltimasFechas);
            nombreDelTecnico();
            miGestor.CargarListadoExtractorio(lstTurnos,label14.Text);
            vExtracciones = miGestor.GetTurnosExtractorioVista(label14.Text);
            comprobarLista();
        }

        


        private void nombreDelTecnico()
        {
            ULD nuevo = new ULD();
            nuevo = miGestor.GetNombreRealUsuarioLogueado(UserLoguedInn.usuario);
            if (nuevo != null)
            {
                lblRealizadoPor.Text = nuevo.nombreCompleto.ToString().ToUpper();
                lblLegajo.Text =  nuevo.legajoSistema.ToString();
            }
        }
        
        private void comprobarLista()
        {
            if (lstTurnos.Items.Count == 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "No hay nuevo turnos cargados en el sistema.", "Aviso");
                limpiarCampos();
                btnActualizar.Enabled = false;
                btnEmitirTicket.Enabled = false;
                btnAbrirFiltro.Enabled = false;
                ckbNoRealizado.Enabled = false;
                cboUltimasFechas.DataSource = null;
                cboUltimasFechas.Items.Clear();
            }
            else
            {
                lstTurnos.SelectedIndex = 0;
                btnActualizar.Enabled = true;
                btnEmitirTicket.Enabled = true;
                btnAbrirFiltro.Enabled = true;
                ckbNoRealizado.Enabled = true;
            }
        }


        private void btnEmitirTicket_Click(object sender, EventArgs e)
        {
            FormStickerExtractorio nuevo = new FormStickerExtractorio();
            nuevo.lblNombre.Text = txtCodPaciente.Text;
            nuevo.lblDni.Text = txtNumDni.Text;
            nuevo.lblDocDup.Text = txtNumDni.Text;
            nuevo.lblNombreDup.Text = txtCodPaciente.Text;
            nuevo.lblFecha.Text = txtFecha.Text;
            nuevo.lblFechaDup.Text = txtFecha.Text;
            nuevo.ShowDialog();
        }


        private void inicio()
        {
            lstTurnos.Enabled = true;
            txtObservaciones.Enabled = false;
            btnActualizar.Enabled = true;
            btnCancelar.Enabled = false;
            btnGrabar.Enabled = false;
            bandera = false;
            ckbNoRealizado.Enabled = true;
            ckbNoRealizado.Checked = false;
            txtObservaciones.Text = "Sin Observaciones";
        }

        private void cargarCampos(int i)
        {
            txtNroOrden.Text = vExtracciones[i].nroOrden.ToString();
            txtFecha.Text = vExtracciones[i].fecha;
            txtHora.Text = vExtracciones[i].hora;
            txtCodPaciente.Text = vExtracciones[i].paciente;
            txtObservaciones.Text = vExtracciones[i].observaciones;
            txtEstado.Text = vExtracciones[i].estado;
            txtGrupoEtario.Text = vExtracciones[i].grupoEtario;
            txtNumDni.Text = vExtracciones[i].nroDoc.ToString();
            if (vExtracciones[i].eritrosedimentacion == 1)
            {
                ckbEritro.Checked = true;  
            }
            else
            {
                ckbEritro.Checked = false;
            }
            if (vExtracciones[i].citilogico == 1)
            {
                ckbCito.Checked = true;
            }
            else
            {
                ckbCito.Checked = false;
            }
            if (vExtracciones[i].reticulocitos == 1)
            {
                ckbReti.Checked = true;
            }
            else
            {
                ckbReti.Checked = false;
            }
        }

        private void habilitarControles2()
        {
           // txtObservaciones.Enabled = true;
            btnActualizar.Enabled = false;
            btnGrabar.Enabled = true;
            txtObservaciones.Focus();
            lstTurnos.Enabled = false;
            btnCancelar.Enabled = true;
        }
        private void habilitarControles()
        {
            txtObservaciones.Enabled = true;
            btnActualizar.Enabled=false;
            btnGrabar.Enabled = true;
            txtObservaciones.Focus();
            lstTurnos.Enabled = false;
            btnCancelar.Enabled = true;
        }


        private void cargarCombo(ComboBox combo, string nombreTabla)
        {
            DataTable tabla = new DataTable();
            tabla = miGestor.consultarTabla(nombreTabla);
            combo.DataSource = tabla;
            combo.DisplayMember = tabla.Columns[1].ColumnName;
            combo.ValueMember = tabla.Columns[0].ColumnName;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedIndex = 1;
        }

        private void cargarComboEspecial(ComboBox combo)
        {
            DataTable tabla = new DataTable();
            tabla = miGestor.consultarEspecial(Convert.ToInt32(txtNumDni.Text));
            combo.DataSource = tabla;
            combo.DisplayMember = tabla.Columns[0].ColumnName;
            combo.ValueMember = tabla.Columns[0].ColumnName;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedIndex = 1;
        }

        private void lstTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarCampos(lstTurnos.SelectedIndex);
            try
            {
                cargarComboEspecial(cboUltimasFechas);
                btnInfoPaciente.Enabled = true;
            }
            catch (Exception)
            {
                // MetroFramework.MetroMessageBox.Show(this, "Error al cargar las fechas, el paciente no registra visitas anteriores.");
                // btnInfoPaciente.Enabled = false;
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            miGestor.CargarListadoExtractorio(lstTurnos,label14.Text);
            comprobarLista();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (bandera == false)
            {
                if (MetroFramework.MetroMessageBox.Show(this, "Sino ha sido generado el sticker correspondiente, se recomienda efectuar la tarea antes de proseguir.", "Actualizar Estado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    habilitarControles();
                    ckbNoRealizado.Enabled = false;
                }
            }
            else
            {
                habilitarControles2();
            }
        }

        private void limpiarCampos()
        {
            foreach (Control t in this.groupBox1.Controls)
            {
                if (t is TextBox)
                    ((TextBox)t).Clear();
            }

            foreach (Control c in this.groupBox1.Controls)
            {
                if (c is CheckBox)
                {
                    ((CheckBox)c).Checked = false;
                }
            }
        }

        private void actualizarVectorYCargarLista()
        {
            vExtracciones = miGestor.GetTurnosExtractorioVista(label14.Text);
            miGestor.CargarListadoExtractorio(lstTurnos,label14.Text);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigoEstado = Convert.ToInt32(cboCambiarEstado.SelectedValue);
                int nroOrden = Convert.ToInt32(txtNroOrden.Text);
                string observaciones = txtObservaciones.Text.Trim();
                int realizador = Convert.ToInt32(lblLegajo.Text);
                string pac = txtCodPaciente.Text;


                if (MetroFramework.MetroMessageBox.Show(this, "Confirma el cambio de estado del paciente "+pac.ToUpper()+" ? ","Cambio de estado del turno", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    
                    miGestor.actualizarEstadoTurno(codigoEstado, nroOrden, observaciones, realizador);
                    MetroFramework.MetroMessageBox.Show(this, "Cambio de estado realizado con exito.");
                    actualizarVectorYCargarLista();
                    inicio();
                    comprobarLista();
                }
            }
            catch (Exception error)
            {
                MetroFramework.MetroMessageBox.Show(this, error.ToString());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            inicio();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormExtractorio_FormClosing(object sender, FormClosingEventArgs e)
        {
          if( MetroFramework.MetroMessageBox.Show(this, "Desea abandonar y salir de la Administración de Extractorio?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                e.Cancel = false;
            }
          else
            {
                e.Cancel = true;
            }
        }

        private void btnAbrirFiltro_Click(object sender, EventArgs e)
        {
            FormListadoTurnoFiltro nuevo = new FormListadoTurnoFiltro();
            nuevo.ShowDialog();
        }

        private void txtObservaciones_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(txtObservaciones,"Maximo 250 caracteres.");
        }

        private void btnInfoPaciente_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnInfoPaciente,"Muestra información, sobre la última visita del paciente.");
        }

        private void btnAbrirFiltro_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnAbrirFiltro,"Abrir formulario para mostrar turnos filtrados por grupo etario.");
        }

        private void btnInfoPaciente_Click(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(txtNumDni.Text) && !String.IsNullOrEmpty(cboUltimasFechas.Text))
            {

                TurnoAnterior miTurno = new TurnoAnterior();
                miTurno = miGestor.GetTurnoAnteriorPaciente(txtNumDni.Text,cboUltimasFechas.Text);
                if (miTurno != null)
                {
                    FormInfoPaciente nuevo = new FormInfoPaciente();
                    nuevo.lblNombreCompleto.Text = miTurno.paciente.ToString();
                    nuevo.lblObraSocial.Text = miTurno.obraSocial.ToString();
                    nuevo.lblFechaUltimaVisita.Text = miTurno.fechaUltimaVisita.ToString();
                    if (miTurno.reti == 1)
                    {
                        nuevo.ckbReti.Checked = true;
                    }
                    if (miTurno.cito == 1)
                    {
                        nuevo.ckbCito.Checked = true;
                    }
                    if (miTurno.eritro == 1)
                    {
                        nuevo.ckbEritro.Checked = true;
                    }
                    nuevo.lblObservaciones.Text = miTurno.observaciones.ToString();
                    nuevo.ShowDialog();
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "El Paciente no registra antecedentes");
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this,"El campo de dni o el listado de fechas  no contienen datos...");
            }
        }

        
        private void ckbNoRealizado_CheckedChanged(object sender, EventArgs e)
        {
            if(ckbNoRealizado.Checked)
            {
                bandera = true;
                txtObservaciones.Text = "Muestra No Disponible";
                btnEmitirTicket.Enabled = false;
            }
            else
            {
                bandera = false;
                txtObservaciones.Text = "Sin Observaciones";
                btnEmitirTicket.Enabled = true;
            }
        }
    }
}
