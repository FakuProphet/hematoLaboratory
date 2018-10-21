using HematoLab.Clases;
using HematoLab.Gestores;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;



namespace HematoLab.Formularios
{
    public partial class FormProfesionales : MetroFramework.Forms.MetroForm
    {

       
        private bool banderaProf;
        Profesional[] vProfesionales;
        GestorProfesionales miGestorProfesionales = new GestorProfesionales();
        GestorImagen miGestorImagen;

        public FormProfesionales()
        {
            InitializeComponent();
            banderaProf = false;
            vProfesionales = miGestorProfesionales.GetProfesionales();
            miGestorImagen = new GestorImagen();
        }

        private void FormAdmUsurios_Load(object sender, EventArgs e)
        {
            cargarCombosProfesionales();
            miGestorProfesionales.CargarListadoProfesionales(lstProfesionales);
            comprobarLista();
            inicio();
        }

        private void comprobarLista()
        {


            if (lstProfesionales.Items.Count == 0)
                MessageBox.Show("Lista Vacia.");
            else
                lstProfesionales.SelectedIndex = 0;


            //if (lstProfesionales.Items.Count == 0)
            //{
            //    MessageBox.Show("Lista Vacia.");
            //    btnActualizarProf.Enabled = false;
            //   // btnAdmFoto.Enabled = false;

            //    btnGenerarUsuario.Enabled = false;
            //    //btnGenerarUsuarioExt.Enabled = false;
            //}
            //else
            //{
            //    lstProfesionales.SelectedIndex = 0;
            //    btnActualizarProf.Enabled = true;
            //   // btnAdmFoto.Enabled = true;
            //    btnGenerarUsuario.Enabled = true;
            //    //btnGenerarUsuarioExt.Enabled = true;
            //}
        }


        private void cargarCombosProfesionales()
        {
            cargarCombo(cboEspecialidadProf, "Especialidades");
            cargarCombo(cboGeneroProf, "Generos");
            cargarCombo(cboTipoDocProf, "TiposDeDocumento");
            cargarCombo(cboTituloProf, "TitulosAcademicos");
            cargarCombo(cboTurnoProf, "TurnoLaboral");
        }


        private void limpiarCamposProf()
        {
            foreach (Control t in this.groupBox1.Controls)
            {
                if (t is TextBox)
                    ((TextBox)t).Clear();
            }

            foreach (Control c in this.groupBox1.Controls)
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
            tabla = miGestorProfesionales.consultarTabla(nombreTabla);
            combo.DataSource = tabla;
            combo.DisplayMember = tabla.Columns[1].ColumnName;
            combo.ValueMember = tabla.Columns[0].ColumnName;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedIndex = 0;
        }


        private void actualizarProfesional()
        {
            banderaProf = false;
            groupBox1.Enabled = true;
            btnGrabarProf.Enabled = true;
            btnCancelarProf.Enabled = true;
            btnNuevoProf.Enabled = false;
            txtFechaNacProf.Show();
            lblFechaRegProf.Hide();
            txtFechaRegistroProf.Hide();
            txtNroDocProf.Enabled = false;
            lstProfesionales.Enabled = false;
            dtpFechaNacProf.Visible = false;
            btnActualizarProf.Enabled = false;
            txtNombreProf.Focus();
        }

        private void nuevoProfesional()
        {
            banderaProf = true;
            groupBox1.Enabled = true;
            groupBox6.Hide();
            limpiarCamposProf();
            txtNombreProf.Focus();
            btnGrabarProf.Enabled = true;
            btnCancelarProf.Enabled = true;
            btnSalirProf.Enabled = false;
            txtFechaNacProf.Hide();
            txtFechaRegistroProf.Hide();
            lstProfesionales.Enabled = false;
            btnNuevoProf.Enabled = false;
            lblFechaRegProf.Hide();
            btnActualizarProf.Enabled = false;
            dtpFechaNacProf.Visible = true;
        }



        private void inicio()
        {
            lstProfesionales.Enabled = true;
            banderaProf = false;
            groupBox1.Enabled = false;
            groupBox6.Visible = true;
            btnGrabarProf.Enabled = false;
            btnCancelarProf.Enabled = false;
            dtpFechaNacProf.Hide();
            btnSalirProf.Enabled = true;
            btnNuevoProf.Enabled = true;
            txtFechaNacProf.Visible = true;
            lblFechaRegProf.Visible = true;
            txtFechaRegistroProf.Visible = true;
            btnActualizarProf.Enabled = true;
           // lstProfesionales.SelectedIndex = 1;
        }

        private bool validar()
        {
            bool valido = false;

            if (string.IsNullOrEmpty(this.txtApeProf.Text))
            {
                MessageBox.Show("Debe completar el apellido.");
                valido = false;
                txtApeProf.Focus();
            }
            else if (string.IsNullOrEmpty(this.txtNombreProf.Text))
            {
                MessageBox.Show("Debe completar los nombres.");
                valido = false;
                txtNombreProf.Focus();
            }
            else if (string.IsNullOrEmpty(this.txtEdadProf.Text))
            {
                MessageBox.Show("Debe completar la edad.");
                valido = false;
                txtEdadProf.Focus();
            }
            else if (string.IsNullOrEmpty(this.txtNroDocProf.Text))
            {
                MessageBox.Show("Debe completar el nro documento.");
                valido = false;
                txtNroDocProf.Focus();
            }
            else if (string.IsNullOrEmpty(this.txtEmailProf.Text))
            {
                MessageBox.Show("Debe completar el email.");
                valido = false;
                txtEmailProf.Focus();
            }

            else if (banderaProf == true)
            {
                if (existeDocumento(Convert.ToInt32(txtNroDocProf.Text)))
                {
                    MessageBox.Show("Ese número de documento se encuentra registrado.");
                    valido = false;
                    txtNroDocProf.Focus();
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





        private bool existeDocumento(double doc)
        {
            for (int i = 0; i < lstProfesionales.Items.Count; i++)
                if (vProfesionales[i].pNroDoc == doc)
                    return true;
            return false;
        }

        private bool existeMatricula(string mat)
        {
            for (int i = 0; i < lstProfesionales.Items.Count; i++)
                if (vProfesionales[i].pMatricula == mat)
                    return true;
            return false;
        }


        public void ActualizarVectorProfesionales()
        {
            vProfesionales = miGestorProfesionales.GetProfesionales();
        }


        private string tabla = "FotografiasProfesionales";
        private void cargarCamposProfesionales(int posicion)
        {
            txtLegajoProf.Text = vProfesionales[posicion].pLegajo.ToString();
            txtApeProf.Text = vProfesionales[posicion].pApellido;
            txtNombreProf.Text = vProfesionales[posicion].pNombre;
            txtNroDocProf.Text = vProfesionales[posicion].pNroDoc.ToString();
            txtEdadProf.Text = vProfesionales[posicion].pEdad.ToString();
            txtEmailProf.Text = vProfesionales[posicion].pEmail;
            txtFechaNacProf.Text = vProfesionales[posicion].pFechaNac;
            txtFechaRegistroProf.Text = vProfesionales[posicion].pFechaRegistro;
            txtMatriculaProf.Text = vProfesionales[posicion].pMatricula;
            cboEspecialidadProf.SelectedValue = vProfesionales[posicion].pIdEspecialidad;
            cboGeneroProf.SelectedValue = vProfesionales[posicion].pIdGenero;
            cboTipoDocProf.SelectedValue = vProfesionales[posicion].pTipoDoc;
            cboTurnoProf.SelectedValue = vProfesionales[posicion].pIdTurnoTrabajo;
            cboTituloProf.SelectedValue = vProfesionales[posicion].pTituloAcademico;
            miGestorImagen.verImagen(pictureBoxProfesional,Convert.ToInt32 (txtLegajoProf.Text), tabla);
        }

        
        private void lstProfesionales_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cargarCamposProfesionales(lstProfesionales.SelectedIndex);
            if ( existeUsuario(Convert.ToInt32(txtLegajoProf.Text),"UsuariosProfesionales"))
            {
                btnGenerarUsuario.Enabled = false;
                btnGenerarUsuario.BackColor = Color.White;
            }
            else
            {
                btnGenerarUsuario.Enabled = true;
                btnGenerarUsuario.BackColor = Color.Azure;
            }

            //if (existeUsuario(Convert.ToInt32(txtLegajoProf.Text), "UsuariosExtractorio"))
            //{
            //    btnGenerarUsuarioExt.Enabled = false;
            //    btnGenerarUsuarioExt.BackColor = Color.White;
            //}
            //else
            //{
            //    btnGenerarUsuarioExt.Enabled = true;
            //    btnGenerarUsuarioExt.BackColor = Color.Azure;
            //}
        }

        private void btnNuevoProf_Click_1(object sender, EventArgs e)
        {
            nuevoProfesional();
        }

        private void btnGrabarProf_Click_1(object sender, EventArgs e)
        {

            try
            {
                if (validar())
                {
                    string sql = "";

                    if (banderaProf)

                    {
                        Profesional p = new Profesional();
                        p.pApellido = txtApeProf.Text;
                        p.pNombre = txtNombreProf.Text;
                        p.pEdad = Convert.ToInt32(txtEdadProf.Text);
                        p.pNroDoc = Convert.ToInt32(txtNroDocProf.Text);
                        p.pTipoDoc = Convert.ToInt32(cboTipoDocProf.SelectedValue);
                        p.pFechaNac = dtpFechaNacProf.Value.ToShortDateString();
                        p.pEmail = txtEmailProf.Text;
                        p.pIdEspecialidad = Convert.ToInt32(cboEspecialidadProf.SelectedValue);
                        p.pTituloAcademico = Convert.ToInt32(cboTituloProf.SelectedValue);
                        p.pIdTurnoTrabajo = Convert.ToInt32(cboTurnoProf.SelectedValue);
                        p.pMatricula = txtMatriculaProf.Text;
                        p.pIdGenero = Convert.ToInt32(cboGeneroProf.SelectedValue);


                        sql = "insert into Profesionales(matricula,turno,nombre,apellido,edad,genero,fechaNac,NroDoc,tipoDoc,email,especialidad,tituloAcademico) values ('"

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
                           + p.pIdEspecialidad + ","
                           + p.pTituloAcademico + ""
                           + ")";
                        if (MetroFramework.MetroMessageBox.Show(this, "Desea registrar el profesional?", "Alta de Profesionales", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            miGestorProfesionales.actualizarBD(sql);
                            miGestorProfesionales.CargarListadoProfesionales(lstProfesionales);
                            ActualizarVectorProfesionales();
                            inicio();
                            MessageBox.Show("Registro exitoso.");
                            lstProfesionales.SelectedIndex = 0;
                        }
                        else
                        {

                        }
                    }



                    else
                    {
                        int i = lstProfesionales.SelectedIndex;
                        vProfesionales[i].pApellido = txtApeProf.Text;
                        vProfesionales[i].pNombre = txtNombreProf.Text;
                        vProfesionales[i].pIdGenero = Convert.ToInt32(cboGeneroProf.SelectedValue);
                        vProfesionales[i].pNroDoc = Convert.ToInt32(txtNroDocProf.Text);
                        vProfesionales[i].pTituloAcademico = Convert.ToInt32(cboTituloProf.SelectedValue);
                        vProfesionales[i].pFechaNac = txtFechaNacProf.Text;
                        vProfesionales[i].pIdEspecialidad = Convert.ToInt32(cboEspecialidadProf.SelectedValue);
                        vProfesionales[i].pLegajo = Convert.ToInt32(txtLegajoProf.Text);
                        vProfesionales[i].pEmail = txtEmailProf.Text;
                        vProfesionales[i].pIdTurnoTrabajo = Convert.ToInt32(cboTurnoProf.SelectedValue);
                        vProfesionales[i].pMatricula = txtMatriculaProf.Text;
                        vProfesionales[i].pEdad = Convert.ToInt32(txtEdadProf.Text);


                        sql = "Update Profesionales set apellido ='" + vProfesionales[i].pApellido + "',"
                                                                  + "nombre='" + vProfesionales[i].pNombre + "',"
                                                                  + "genero= " + vProfesionales[i].pIdGenero + ","
                                                                  + "NroDoc= " + vProfesionales[i].pNroDoc + ","
                                                                  + "tituloAcademico= " + vProfesionales[i].pTituloAcademico + ","
                                                                  + "fechaNac= '" + vProfesionales[i].pFechaNac + "',"
                                                                  + "especialidad= " + vProfesionales[i].pIdEspecialidad + ","
                                                                  + "email= '" + vProfesionales[i].pEmail + "',"
                                                                  + "turno= " + vProfesionales[i].pIdTurnoTrabajo + ","
                                                                  + "matricula= '" + vProfesionales[i].pMatricula + "',"
                                                                  + "edad= " + vProfesionales[i].pEdad + ""
                                                                  + " Where legajo = " + vProfesionales[i].pLegajo;

                        if (MetroFramework.MetroMessageBox.Show(this, "Desea confirmar los cambios realizados?", "Actualización de datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            miGestorProfesionales.actualizarBD(sql);
                            miGestorProfesionales.CargarListadoProfesionales(lstProfesionales);
                            ActualizarVectorProfesionales();
                            inicio();
                            MessageBox.Show("Actualización correcta.");
                            lstProfesionales.SelectedIndex = 0;
                        }
                        else
                        {

                        }
                    }

                }

            }

            catch(Exception error)
            {
                MessageBox.Show("No se puedo completar la transaccion: " + error.ToString());
            }

        }

           
        

        private void btnCancelarProf_Click_1(object sender, EventArgs e)
        {
            inicio();
        }

        private void btnSalirProf_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizarProf_Click(object sender, EventArgs e)
        {
            actualizarProfesional();
        }



        public string[] datoAPasar()
        {
           // Dato d = new Dato();

            string[] salida = new string[2];

            int legajo = Convert.ToInt32(txtLegajoProf.Text);
            int tipopersonal = 1;//profesional
            
            salida[0] = legajo.ToString();
            salida[1] = tipopersonal.ToString();
        
            return salida;
        }



        private void btnAdmFoto_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtLegajoProf.Text))
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
        }


        private void btnGenerarUsuario_Click(object sender, EventArgs e)
        {
            FormGenerarUsusariosSistema nuevo = new FormGenerarUsusariosSistema();
            Dato d = new Dato();
            string[] parametros = datoAPasar();
            d.legajo = Convert.ToInt32(parametros[0]);
            d.tipoPersona = Convert.ToInt32(parametros[1]);
            nuevo.txtLegajoUsuario.Text = Convert.ToString(d.legajo);
            nuevo.txtTipo.Text= Convert.ToString(d.tipoPersona);
            nuevo.ShowDialog();
        }


        private bool existeUsuario(int parametro,string tabla)
        {
            bool existe = false;

            DataTable miDT = miGestorProfesionales.consultarTabla(tabla);
            Profesional p = new Profesional();
            foreach (DataRow fila in miDT.Rows)
            {
                if (fila != null)
                {
                    p.pLegajo = Convert.ToInt32(fila["legajo"]);
                    if (p.pLegajo == parametro)
                    {
                        existe = true;
                    }                   
                }
            }

            return existe;
        }

       


        private void txtNombreProf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo texto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtApeProf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo texto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtEdadProf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtNroDocProf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void FormProfesionales_FormClosing(object sender, FormClosingEventArgs e)
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



        private void BuscarDoc(string searchString)
        {

            if (searchString != string.Empty)
            {

                int index = lstProfesionales.FindString(searchString);

                if (index != -1)
                    lstProfesionales.SetSelected(index, true);
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

        //private void btnGenerarUsuarioExt_Click(object sender, EventArgs e)
        //{
        //    FormGenerarUsusariosSistema nuevo = new FormGenerarUsusariosSistema();
        //    Dato d = new Dato();
        //    string[] parametros = datoAPasar();
        //    d.legajo = Convert.ToInt32(parametros[0]);
        //    d.tipoPersona = 3;
        //    nuevo.txtLegajoUsuario.Text = Convert.ToString(d.legajo);
        //    nuevo.txtTipo.Text = Convert.ToString(d.tipoPersona);
        //    nuevo.ShowDialog();
        //}
    }
}
