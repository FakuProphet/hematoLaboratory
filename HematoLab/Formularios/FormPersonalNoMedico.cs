using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using HematoLab.Gestores;
using HematoLab.Clases;


namespace HematoLab.Formularios
{
    public partial class FormPersonalNoMedico : MetroFramework.Forms.MetroForm
    {

        GestorPersonalNoMedico miGestorPNM = new GestorPersonalNoMedico();
        GestorImagen miGestorImagen;
        Administrativo[] PNMVector;
        private bool bandera;


        public FormPersonalNoMedico()
        {
            InitializeComponent();
            PNMVector = miGestorPNM.GetPersonalNoMedico();
            miGestorImagen = new GestorImagen();
            bandera = false;
        }

        private void FormPersonalNoMedico_Load(object sender, EventArgs e)
        {
            cargarCombosPNM();
            miGestorPNM.CargarListado(lstpersonalNoMedico);
            comprobarLista();
            inicio();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            inicio();
            lblAltaSistema.Visible = true;
            txtRegistroPNM.Visible = true;
            lstpersonalNoMedico.SelectedIndex = 1;
        }

        private void actualizarPNM()
        {
            bandera = false;
            groupBoxDatosPNM.Enabled = true;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
            btnActualizar.Enabled = false;
            dtpFechaNacPNM.Hide();
            txtNroDocPNM.Enabled = false;
            lblAltaSistema.Hide();
            txtRegistroPNM.Hide();
            lstpersonalNoMedico.Enabled = false;
            txtNombrePNM.Focus();
            
        }

        private void limpiarCampos()
        {
            foreach (Control t in this.groupBoxDatosPNM.Controls)
            {
                if (t is TextBox)
                    ((TextBox)t).Clear();
            }

            foreach (Control c in this.groupBoxDatosPNM.Controls)
            {
                if (c is ComboBox)
                {
                    ((ComboBox)c).SelectedIndex = 0;
                }
            }    
        }





        private void btnGrabar_Click(object sender, EventArgs e)
        {

            if (validar())
            {
                string sql = "";

                if (bandera)
                {
                    Administrativo p = new Administrativo();
                    p.pApellido = txtApellidoPNM.Text;
                    p.pNombre = txtNombrePNM.Text;
                    p.pEdad = Convert.ToInt32(txtEdadPNM.Text);
                    p.pNroDoc = Convert.ToInt32(txtNroDocPNM.Text);
                    p.pTipoDoc = Convert.ToInt32(cboTipoDocPNM.SelectedValue);
                    p.pFechaNacimiento = dtpFechaNacPNM.Value.ToShortDateString();
                    p.pEmail = txtEmailPNM.Text;
                    p.pIdGenero = Convert.ToInt32(cboGeneroPNM.SelectedValue);
                    p.pIdTurnoDeTrabajo = Convert.ToInt32(cboTurnoPNM.SelectedValue);


                    sql = "insert into PersonalNoMedico (turno,nombre,apellido,genero,fechaNac,NroDoc,tipoDoc,email,edad) values ("

                       + p.pIdTurnoDeTrabajo + ",'"
                       + p.pNombre + "','"
                       + p.pApellido + "',"
                       + p.pIdGenero + ",'"
                       + p.pFechaNacimiento + "',"
                       + p.pNroDoc + ","
                       + p.pTipoDoc + ",'"
                       + p.pEmail + "',"
                       + p.pEdad + ""
                       + ")";
                    if (MetroFramework.MetroMessageBox.Show(this, "Desea registrar a la persona de atención?", "Alta de personal no médico", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        miGestorPNM.actualizarBD(sql);
                        miGestorPNM.CargarListado(lstpersonalNoMedico);
                        ActualizarVector();
                        inicio();
                        MessageBox.Show("Registro exitoso.");
                    }
                    else
                    {

                    }
                }

                else
                {
                    int i = lstpersonalNoMedico.SelectedIndex;
                    PNMVector[i].pApellido = txtApellidoPNM.Text;
                    PNMVector[i].pNombre = txtNombrePNM.Text;
                    PNMVector[i].pIdGenero = Convert.ToInt32(cboGeneroPNM.SelectedValue);
                    PNMVector[i].pNroDoc = Convert.ToInt32(txtNroDocPNM.Text);
                    PNMVector[i].pIdTurnoDeTrabajo = Convert.ToInt32(cboTurnoPNM.SelectedValue);
                    PNMVector[i].pFechaNacimiento = txtFechaNacPNM.Text;
                    PNMVector[i].pEmail = txtEmailPNM.Text;
                    PNMVector[i].pIdTurnoDeTrabajo = Convert.ToInt32(cboTurnoPNM.SelectedValue);
                    PNMVector[i].pLegajo = Convert.ToInt32(txtLegajoPNM.Text);
                    PNMVector[i].pEdad = Convert.ToInt32(txtEdadPNM.Text);



                    sql = "Update PersonalNoMedico set apellido ='" + PNMVector[i].pApellido + "',"
                                                          + "nombre='" + PNMVector[i].pNombre + "',"
                                                          + "genero=" + PNMVector[i].pIdGenero + ","
                                                          + "NroDoc=" + PNMVector[i].pNroDoc + ","
                                                          + "FechaNac='" + PNMVector[i].pFechaNacimiento + "',"
                                                          + "email='" + PNMVector[i].pEmail + "',"
                                                          + "turno=" + PNMVector[i].pIdTurnoDeTrabajo + ","
                                                          + "edad=" + PNMVector[i].pEdad + ""
                                                          + "Where legajo =" + PNMVector[i].pLegajo;

                    if (MetroFramework.MetroMessageBox.Show(this, "Desea confirmar los cambios realizados?", "Actualización de datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        miGestorPNM.actualizarBD(sql);
                        miGestorPNM.CargarListado(lstpersonalNoMedico);
                        inicio();
                        lstpersonalNoMedico.SelectedIndex = 0;
                        MessageBox.Show("Actualización correcta.");
                    }
                    else
                    {

                    }
                }
            }
        }


        private void inicio()
        {
            lstpersonalNoMedico.Enabled = true;
            bandera = false;
            this.groupBoxDatosPNM.Enabled = false;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;
            btnSalir.Enabled = true;
            btnNuevo.Enabled = true;
            btnActualizar.Enabled = true;
            groupBoxFotoPNM.Visible = true;
            txtFechaNacPNM.Visible = true;
        }


        private void nuevoRegistro()
        {
            bandera = true;
            limpiarCampos();
            lblAltaSistema.Hide();
            txtRegistroPNM.Hide();
            txtFechaNacPNM.Hide();
            dtpFechaNacPNM.Show();
            groupBoxFotoPNM.Hide();
            groupBoxDatosPNM.Enabled = true;
            lstpersonalNoMedico.Enabled = false;
            btnActualizar.Enabled = false;
            btnCancelar.Enabled = true;
            btnGrabar.Enabled = true;
            btnSalir.Enabled = false;
            btnNuevo.Enabled = false;
            txtNombrePNM.Focus();   
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevoRegistro();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            actualizarPNM();
        }


       


        private void comprobarLista()
        {
            if (lstpersonalNoMedico.Items.Count == 0)
                MessageBox.Show("Lista Vacia.");
            else
                lstpersonalNoMedico.SelectedIndex = 0;
        }

        private void cargarCombo(ComboBox combo, string nombreTabla)
        {
            DataTable tabla = new DataTable();
            tabla = miGestorPNM.consultarTabla(nombreTabla);
            combo.DataSource = tabla;
            combo.DisplayMember = tabla.Columns[1].ColumnName;
            combo.ValueMember = tabla.Columns[0].ColumnName;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedIndex = 0;
        }

        public void ActualizarVector()
        {
            PNMVector = miGestorPNM.GetPersonalNoMedico();
        }

        private void cargarCombosPNM()
        {
            cargarCombo(cboGeneroPNM, "Generos");
            cargarCombo(cboTipoDocPNM, "TiposDeDocumento");
            cargarCombo(cboTurnoPNM, "TurnoLaboral");
        }

        private void actualizarDatosLista()
        {
            miGestorPNM.CargarListado(lstpersonalNoMedico);
        }


        private static string nombreTabla = "FotografiasNoMedicos";
        private void cargarCampos(int posicion)
        {
            txtLegajoPNM.Text = PNMVector[posicion].pLegajo.ToString();
            txtNombrePNM.Text = PNMVector[posicion].pNombre;
            txtApellidoPNM.Text = PNMVector[posicion].pApellido;
            txtEdadPNM.Text = PNMVector[posicion].pEdad.ToString();
            txtEmailPNM.Text = PNMVector[posicion].pEmail;
            txtFechaNacPNM.Text = PNMVector[posicion].pFechaNacimiento;
            txtRegistroPNM.Text = PNMVector[posicion].pAltaEnSistema;
            txtNroDocPNM.Text = PNMVector[posicion].pNroDoc.ToString();
            cboGeneroPNM.SelectedValue = PNMVector[posicion].pIdGenero;
            cboTipoDocPNM.SelectedValue = PNMVector[posicion].pTipoDoc;
            cboTurnoPNM.SelectedValue = PNMVector[posicion].pIdTurnoDeTrabajo;
            miGestorImagen.verImagen(pictureBoxPNM, Convert.ToInt32(txtLegajoPNM.Text), nombreTabla);
        }


        private void lstpersonalNoMedico_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarCampos(lstpersonalNoMedico.SelectedIndex);
            if (existeUsuario(Convert.ToInt32(txtLegajoPNM.Text)))
            {
                btnGenerarUsuario.Enabled = false;
                btnGenerarUsuario.BackColor = Color.White;
            }
            else
            {
                btnGenerarUsuario.Enabled = true;
                btnGenerarUsuario.BackColor = Color.Azure;
            }
        }



       
        private bool existeDocumento(int doc)
        {
            for (int i = 0; i < lstpersonalNoMedico.Items.Count; i++)
                if (PNMVector[i].pNroDoc == doc)
                    return true;
            return false;
        }



        private bool validar()
        {
            bool valido = false;


            if (string.IsNullOrEmpty(txtNombrePNM.Text))
            {
                MessageBox.Show("Debe completar el nombre.");
                valido = false;
                txtNombrePNM.Focus();
            }
            else if (string.IsNullOrEmpty(txtApellidoPNM.Text))
            {
                MessageBox.Show("Debe completar los apellido.");
                valido = false;
                txtApellidoPNM.Focus();
            }
            else if (string.IsNullOrEmpty(txtEdadPNM.Text))
            {
                MessageBox.Show("Debe completar la edad.");
                valido = false;
                txtEdadPNM.Focus();
            }
            else if (string.IsNullOrEmpty(txtNroDocPNM.Text))
            {
                MessageBox.Show("Debe completar el nro documento.");
                valido = false;
                txtNroDocPNM.Focus();
            }
            else if (string.IsNullOrEmpty(txtEmailPNM.Text))
            {
                MessageBox.Show("Debe completar el email.");
                valido = false;
                txtEmailPNM.Focus();
            }


            else if (bandera == true)
            {
                if (existeDocumento(Convert.ToInt32(txtNroDocPNM.Text)))
                {
                    MessageBox.Show("Ese número de documento se encuentra registrado.");
                    valido = false;
                    txtNroDocPNM.Focus();
                }

                else
                {
                    valido = true;
                }

            }

            else
            {
                valido = true;
            }

            return valido;
        }


        public string[] datoAPasar()
        {
            string[] salida = new string[2];
            int legajo = Convert.ToInt32(txtLegajoPNM.Text);
            int tipopersonal = 2;
            salida[0] = legajo.ToString();
            salida[1] = tipopersonal.ToString();
            return salida;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormFotografias nuevo = new FormFotografias();
            Dato d = new Dato();
            string[] parametros = datoAPasar();
            d.legajo = Convert.ToInt32(parametros[0]);
            d.tipoPersona = Convert.ToInt32(parametros[1]);
            nuevo.lblLegajo.Text = Convert.ToString(d.legajo);
            nuevo.txtTipoPersonal.Text = Convert.ToString(d.tipoPersona);
            nuevo.ShowDialog();
        }

        private void btnGenerarUsuario_Click(object sender, EventArgs e)
        {
            FormGenerarUsusariosSistema nuevo = new FormGenerarUsusariosSistema();
            Dato d = new Dato();
            string[] parametros = datoAPasar();
            d.legajo = Convert.ToInt32(parametros[0]);
            d.tipoPersona = Convert.ToInt32(parametros[1]);
            nuevo.txtLegajoUsuario.Text = Convert.ToString(d.legajo);
            nuevo.txtTipo.Text = Convert.ToString(d.tipoPersona);
            nuevo.ShowDialog();
        }


        private bool existeUsuario(int parametro)
        {
            bool existe = false;

            DataTable miDT = miGestorPNM.consultarTabla("UsuariosNoMedicos");
            Administrativo a = new Administrativo();
            foreach (DataRow fila in miDT.Rows)
            {
                if (fila != null)
                {
                    a.pLegajo = Convert.ToInt32(fila["legajo"]);
                    if (a.pLegajo == parametro)
                    {
                        existe = true;
                    }
                }
            }

            return existe;
        }

        private void FormPersonalNoMedico_FormClosing(object sender, FormClosingEventArgs e)
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

        private void txtEdadPNM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtNroDocPNM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtNombrePNM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtApellidoPNM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void BuscarDoc(string searchString)
        {

            if (searchString != string.Empty)
            {

                int index = lstpersonalNoMedico.FindString(searchString);

                if (index != -1)
                    lstpersonalNoMedico.SetSelected(index, true);
                else
                    MetroFramework.MetroMessageBox.Show(this, "El nro de documento no existe...");
            }

        }

        

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string parametro = txtFiltrar.Text;
            BuscarDoc(parametro);
        }

        private void txtFiltrar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                txtFiltrar.Focus();
                return;
            }
        }
    }
}
