using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using HematoLab.Gestores;
using HematoLab.Clases;

namespace HematoLab.Formularios
{
    public partial class FormResponsablesExtractorio : MetroFramework.Forms.MetroForm
    {

        GestorPersonalExtractorio miGestorPE = new GestorPersonalExtractorio();
        GestorImagen miGestorImagen;
        ResponsableExtraccion[] vRespExt;
        private bool bandera;



        public FormResponsablesExtractorio()
        {
            InitializeComponent();
            vRespExt = miGestorPE.GetResponsablesDeExtraciones();
            miGestorImagen = new GestorImagen();
            bandera = false;
        }

        private void FormResponsablesExtractorio_Load(object sender, EventArgs e)
        {
            cargarCombosPRE();
            miGestorPE.CargarListado(lstPersonalTecnico);
            comprobarLista();
            inicio();
        }

        private string nombreTabla = "FotografiasTecnicos";
        private void cargarCamposPE(int posicion)
        {
            txtLegajoRT.Text = vRespExt[posicion].pLegajo.ToString();
            txtApellidoRT.Text = vRespExt[posicion].pApellido;
            txtNombreRT.Text = vRespExt[posicion].pNombre;
            txtNroDocRT.Text = vRespExt[posicion].pNroDoc.ToString();
            txtEdadRT.Text = vRespExt[posicion].pEdad.ToString();
            txtEmailRT.Text = vRespExt[posicion].pEmail;
            txtFechaNacRT.Text = vRespExt[posicion].pFechaNac;
            txtFechaRegistroRT.Text= vRespExt[posicion].pFechaRegistro;
            txtMatriculaRT.Text = vRespExt[posicion].pMatricula;
            cboEspTecRT.SelectedValue = vRespExt[posicion].pTitulo;
            cboGeneroRT.SelectedValue = vRespExt[posicion].pIdGenero;
            cboTipoDocRT.SelectedValue= vRespExt[posicion].pTipoDoc;
            cboTurnoRT.SelectedValue = vRespExt[posicion].pIdTurnoTrabajo;
            miGestorImagen.verImagen(pictureBoxRT,Convert.ToInt32(txtLegajoRT.Text),nombreTabla);
        }



        private void comprobarLista()
        {
            if (lstPersonalTecnico.Items.Count == 0)
            {
                MessageBox.Show("Lista Vacia.");
                btnActualizar.Enabled = false;
            }
            else
            {
                lstPersonalTecnico.SelectedIndex = 0;
                btnActualizar.Enabled = true;
            }
        }

        private void cargarCombosPRE()
        {
            cargarCombo(cboEspTecRT, "EspecialidadesTecnicas");
            cargarCombo(cboGeneroRT, "Generos");
            cargarCombo(cboTipoDocRT, "TiposDeDocumento");
            cargarCombo(cboTurnoRT, "TurnoLaboral");
        }

        private void nuevoPE()
        {
            bandera = true;
            groupBox3.Enabled = true;
            groupBox5.Hide();
            limpiarCampos();
            txtNombreRT.Focus();
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
            btnSalir.Enabled = false;
            txtFechaNacRT.Hide();
            txtFechaRegistroRT.Hide();
            lstPersonalTecnico.Enabled = false;
            btnNuevo.Enabled = false;
            lblRegistroSistema.Hide();
            dtpFechaNacRT.Visible = true;
            btnActualizar.Enabled = false;
            txtNroDocRT.Enabled = true;
        }


        private void limpiarCampos()
        {
            foreach (Control t in this.groupBox3.Controls)
            {
                if (t is TextBox)
                    ((TextBox)t).Clear();
            }

            foreach (Control c in this.groupBox3.Controls)
            {
                if (c is ComboBox)
                {
                    ((ComboBox)c).SelectedIndex = 0;
                }
            }
        }


        private void cargarCombo(ComboBox combo, string nombreTabla)
        {
            DataTable tabla = new DataTable();
            tabla = miGestorPE.consultarTabla(nombreTabla);
            combo.DataSource = tabla;
            combo.DisplayMember = tabla.Columns[1].ColumnName;
            combo.ValueMember = tabla.Columns[0].ColumnName;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedIndex = 0;
        }

        private bool existeDocumento(double doc)
        {
            for (int i = 0; i < lstPersonalTecnico.Items.Count; i++)
                if (vRespExt[i].pNroDoc == doc)
                    return true;
            return false;
        }


        private bool validar()
        {
            bool valido = false;

            

            if (string.IsNullOrEmpty(txtApellidoRT.Text))
            {
                MessageBox.Show("Debe completar el apellido.");
                valido = false;
                txtApellidoRT.Focus();
            }
            else if (string.IsNullOrEmpty(txtNombreRT.Text))
            {
                MessageBox.Show("Debe completar los nombres.");
                valido = false;
                txtNombreRT.Focus();
            }
            else if (string.IsNullOrEmpty(txtEdadRT.Text))
            {
                MessageBox.Show("Debe completar la edad.");
                valido = false;
                txtEdadRT.Focus();
            }
            else if (string.IsNullOrEmpty(txtNroDocRT.Text))
            {
                MessageBox.Show("Debe completar el nro documento.");
                valido = false;
                txtNroDocRT.Focus();
            }
            else if (string.IsNullOrEmpty(txtEmailRT.Text))
            {
                MessageBox.Show("Debe completar el email.");
                valido = false;
                txtEmailRT.Focus();
            }

            else if (string.IsNullOrEmpty(txtMatriculaRT.Text))
            {
                MessageBox.Show("Debe completar la matricula.");
                valido = false;
                txtMatriculaRT.Focus();
            }

            else if (bandera == true)
            {
                if (existeDocumento(Convert.ToInt32(txtNroDocRT.Text)))
                {
                    MessageBox.Show("Ese número de documento se encuentra registrado.");
                    valido = false;
                    txtNroDocRT.Focus();
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

        private void inicio()
        {
            lstPersonalTecnico.Enabled = true;
            bandera = false;
            groupBox3.Enabled = false;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;
            btnSalir.Enabled = true;
            btnNuevo.Enabled = true;
            txtFechaNacRT.Visible = true;
            btnActualizar.Enabled = true;
        }

        public void ActualizarVectorPE()
        {
            vRespExt = miGestorPE.GetResponsablesDeExtraciones();
        }


        private void btnGrabar_Click(object sender, EventArgs e)
        {

            try
            {
                if (validar())
                {
                    string sql = "";

                    if (bandera)

                    {
                        ResponsableExtraccion p = new ResponsableExtraccion();
                        p.pApellido = txtApellidoRT.Text;
                        p.pNombre = txtNombreRT.Text;
                        p.pEdad = Convert.ToInt32(txtEdadRT.Text);
                        p.pNroDoc = Convert.ToInt32(txtNroDocRT.Text);
                        p.pTipoDoc = Convert.ToInt32(cboTipoDocRT.SelectedValue);
                        p.pFechaNac = dtpFechaNacRT.Value.ToShortDateString();
                        p.pEmail = txtEmailRT.Text;
                        p.pTitulo = Convert.ToInt32(cboEspTecRT.SelectedValue);
                        p.pIdTurnoTrabajo = Convert.ToInt32(cboTurnoRT.SelectedValue);
                        p.pMatricula = txtMatriculaRT.Text;
                        p.pIdGenero = Convert.ToInt32(cboGeneroRT.SelectedValue);


                        sql = "insert into ResponsablesTecnicos(matricula,turno,nombre,apellido,edad,genero,fechaNac,NroDoc,tipoDoc,email,especialidadTecnica) values ('"

                           + p.pMatricula + "',"
                           + p.pIdTurnoTrabajo + ",'"
                           + p.pNombre + "','"
                           + p.pApellido + "',"
                           + p.pEdad + ","
                           + p.pIdGenero + ",'"
                           + p.pFechaNac + "',"
                           + p.pNroDoc + ","
                           + p.pTipoDoc + ",'"
                           + p.pEmail + "',"
                           + p.pTitulo + ""
                           + ")";
                        if (MetroFramework.MetroMessageBox.Show(this, "Desea registrar al Prof. de extractorio?", "Alta de personal extractorio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            miGestorPE.actualizarBD(sql);
                            miGestorPE.CargarListado(lstPersonalTecnico);
                            ActualizarVectorPE();
                            inicio();
                            MessageBox.Show("Registro exitoso.");
                            lstPersonalTecnico.SelectedIndex = 0;
                        }
                        else
                        {

                        }
                    }



                    else
                    {
                        int i = lstPersonalTecnico.SelectedIndex;
                        vRespExt[i].pApellido = txtApellidoRT.Text;
                        vRespExt[i].pNombre = txtNombreRT.Text;
                        vRespExt[i].pIdGenero = Convert.ToInt32(cboGeneroRT.SelectedValue);
                        vRespExt[i].pNroDoc = Convert.ToInt32(txtNroDocRT.Text);
                        vRespExt[i].pTitulo = Convert.ToInt32(cboEspTecRT.SelectedValue);
                        vRespExt[i].pFechaNac = txtFechaNacRT.Text;                  
                        vRespExt[i].pLegajo = Convert.ToInt32(txtLegajoRT.Text);
                        vRespExt[i].pEmail = txtEmailRT.Text;
                        vRespExt[i].pIdTurnoTrabajo = Convert.ToInt32(cboTurnoRT.SelectedValue);
                        vRespExt[i].pMatricula = txtMatriculaRT.Text;
                        vRespExt[i].pEdad = Convert.ToInt32(txtEdadRT.Text);


                        sql = "Update ResponsablesTecnicos set apellido ='" + vRespExt[i].pApellido + "',"
                                                                  + "nombre='" + vRespExt[i].pNombre + "',"
                                                                  + "genero= " + vRespExt[i].pIdGenero + ","
                                                                  + "nroDoc= " + vRespExt[i].pNroDoc + ","
                                                                  + "especialidadTecnica= " + vRespExt[i].pTitulo + ","
                                                                  + "fechaNac= '" + vRespExt[i].pFechaNac + "',"
                                                                  + "email= '" + vRespExt[i].pEmail + "',"
                                                                  + "turno= " + vRespExt[i].pIdTurnoTrabajo + ","
                                                                  + "matricula= '" + vRespExt[i].pMatricula + "',"
                                                                  + "edad= " + vRespExt[i].pEdad + ""
                                                                  + " Where legajo = " + vRespExt[i].pLegajo;
                        if (MetroFramework.MetroMessageBox.Show(this, "Desea confirmar los cambios realizados?", "Actualización de datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            miGestorPE.actualizarBD(sql);
                            miGestorPE.CargarListado(lstPersonalTecnico);
                            ActualizarVectorPE();
                            inicio();
                            MessageBox.Show("Actualización correcta.");
                            lstPersonalTecnico.SelectedIndex = 0;
                        }
                        else
                        {

                        }
                    }

                }

            }

            catch (DataException error)
            {
                MessageBox.Show("No se puedo completar: " + error.ToString());
            }
        }


        private void actualizarPE()
        {
            bandera = false;
            groupBox3.Enabled = true;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
            btnNuevo.Enabled = false;
            btnActualizar.Enabled = false;
            txtFechaNacRT.Show();
            dtpFechaNacRT.Hide();
            lblRegistroSistema.Hide();
            txtFechaRegistroRT.Hide();
            lstPersonalTecnico.Enabled = false;
            txtNroDocRT.Enabled = false;
        }



        private void btnActualizar_Click(object sender, EventArgs e)
        {
            actualizarPE();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevoPE();
        }

        private void lstPersonalTecnico_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarCamposPE(lstPersonalTecnico.SelectedIndex);
            if (existeUsuario(Convert.ToInt32(txtLegajoRT.Text)))
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            inicio();
            lstPersonalTecnico.SelectedIndex = 1;
        }


        public string[] datoAPasar()
        {
            string[] salida = new string[2];
            int legajo = Convert.ToInt32(txtLegajoRT.Text);
            int tipopersonal = 3;
            salida[0] = legajo.ToString();
            salida[1] = tipopersonal.ToString();
            return salida;
        }



        private void btnAdmFoto_Click(object sender, EventArgs e)
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


        private void button3_Click(object sender, EventArgs e)
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

            DataTable miDT = miGestorPE.consultarTabla("UsuariosExtractorio");
            ResponsableExtraccion r = new ResponsableExtraccion();
            foreach (DataRow fila in miDT.Rows)
            {
                if (fila != null)
                {
                    r.pLegajo = Convert.ToInt32(fila["legajo"]);
                    if (r.pLegajo == parametro)
                    {
                        existe = true;
                    }
                }
            }

            return existe;
        }

        private void txtNombreRT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo texto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtApellidoRT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo texto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtEdadRT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtNroDocRT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void BuscarDoc(string searchString)
        {

            if (searchString != string.Empty)
            {

                int index = lstPersonalTecnico.FindString(searchString);

                if (index != -1)
                    lstPersonalTecnico.SetSelected(index, true);
                else
                    MetroFramework.MetroMessageBox.Show(this, "El nro de documento no existe...");
            }

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string parametro = txtFiltrar.Text;
            BuscarDoc(parametro);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormResponsablesExtractorio_FormClosing(object sender, FormClosingEventArgs e)
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
