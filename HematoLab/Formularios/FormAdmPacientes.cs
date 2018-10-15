using HematoLab.Clases;
using HematoLab.Gestores;
using System;
using System.Data;
using System.Windows.Forms;



namespace HematoLab.Formularios
{
    public partial class FormAdmPacientes : MetroFramework.Forms.MetroForm
    {

        GestorPacientes miGestorPacientes = new GestorPacientes();
        Paciente[] vPacientes;
        bool bandera;

        public FormAdmPacientes()
        {
            InitializeComponent();
            vPacientes = miGestorPacientes.GetPacientes();
            bandera = false;
        }

        private void FormAdmPacientes_Load(object sender, EventArgs e)
        {
            cargarTodosLosCombos();
            miGestorPacientes.CargarListadoPacientes(lstPacientes);
            inicio();
            comprobarLista();
        }

        private void btnCalcularGrupoEtario_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnCalcularGrupoEtario, "Calcular el grupo etario del paciente.");
        }

        private bool EsEmailValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }



        private void cargarCombo(ComboBox combo, string nombreTabla)
        {
            DataTable tabla = new DataTable();
            tabla = miGestorPacientes.consultarTabla(nombreTabla);
            combo.DataSource = tabla;
            combo.DisplayMember = tabla.Columns[1].ColumnName;
            combo.ValueMember = tabla.Columns[0].ColumnName;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedIndex = 0;
        }


        private void cargarTodosLosCombos()
        {
            cargarCombo(cboGenero, "Generos");
            cargarCombo(cboEstadoCivil, "EstadoCivil");
            cargarCombo(cboGrupoEtario, "GrupoEtario");
            cargarCombo(cboLocalidades, "Localidades");
            cargarCombo(cboOS, "ObrasSociales");
            cargarCombo(cboTipoDoc, "TiposDeDocumento");
            cargarCombo(cboProvincias, "Provincias");
            cargarCombo(cboNacionalidad, "Paises");
            cargarCombo(cboEdadEn,"EdadEn");
        }


        private void combosPorDefecto()
        {
            if (cboLocalidades.Items.Count != 0)
            {
                cboLocalidades.SelectedValue = 59;
            }
            if (cboNacionalidad.Items.Count != 0)
            {
                cboNacionalidad.SelectedValue = "AR";
            }
            txtEmail.Text = "@";
        }


        private void comprobarLista()
        {
            if (lstPacientes.Items.Count == 0)
            {
                MessageBox.Show("Lista Vacia.");
                btnActualizar.Enabled = false;
            }
            else
                lstPacientes.SelectedIndex = 0;
        }


        private void limpiarCamposPac()
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

            foreach (Control t in this.groupBox2.Controls)
            {
                if (t is TextBox)
                    ((TextBox)t).Clear();
            }

            foreach (Control c in this.groupBox2.Controls)
            {
                if (c is ComboBox)
                {
                    ((ComboBox)c).SelectedIndex = 0;
                }
            }

        }


        private bool existeDocumento(int doc)
        {
            for (int i = 0; i < lstPacientes.Items.Count; i++)
                if (vPacientes[i].numeroDocumento == doc)
                    return true;
            return false;
        }


        private void cargarCamposPacientes(int i)
        {
            txtCodigo.Text = vPacientes[i].codigo.ToString() ;
            txtApellido.Text = vPacientes[i].apellido ;
            txtNombre.Text = vPacientes[i].nombre;
            cboGenero.SelectedValue = vPacientes[i].genero ;
            txtDni.Text = vPacientes[i].numeroDocumento.ToString();
            cboOS.SelectedValue = vPacientes[i].obraSocial;
            txtFechaNac.Text = vPacientes[i].fechaNacimiento;
            cboProvincias.SelectedValue = vPacientes[i].provincia;
            cboNacionalidad.SelectedValue = vPacientes[i].nacionalidad;
            txtEmail.Text = vPacientes[i].email;
            cboLocalidades.SelectedValue = vPacientes[i].localidad;
            txtCalle.Text = vPacientes[i].calle;
            txtCalleNro.Text = vPacientes[i].numeroCalle.ToString();
            txtEdad.Text = vPacientes[i].edad.ToString();
            cboGrupoEtario.SelectedValue = vPacientes[i].grupoEtario;
            cboEstadoCivil.SelectedValue = vPacientes[i].estadoCivil;
            cboTipoDoc.SelectedValue = vPacientes[i].tipoDocumento ;
            txtBarrio.Text = vPacientes[i].barrio ;
            txtTelParticular.Text = vPacientes[i].telefonoFijo ;
            txtCel.Text = vPacientes[i].telefonoCelular;
        }


        private void actualizarPaciente()
        {
            bandera = false;
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
            btnActualizar.Enabled = false;
            btnNuevo.Enabled = false;
            btnSalir.Enabled = false;
            txtDni.Enabled = false;
            lstPacientes.Enabled = false;
            mostrarControlesEdad();
            dateTimePicker1.Hide();
            txtApellido.Focus();
        }

        private void nuevoPaciente()
        {
            bandera = true;
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            limpiarCamposPac();
            txtApellido.Focus();
            txtDni.Enabled = true;
            btnGrabar.Enabled = true;
            btnCancelar.Enabled = true;
            btnSalir.Enabled = false;
            btnActualizar.Enabled = false;
            txtFechaNac.Hide();
            lstPacientes.Enabled = false;
            btnNuevo.Enabled = false;
            dateTimePicker1.Visible = true;
            mostrarControlesEdad();
            combosPorDefecto();
        }


        private void ocultarControlesEdad()
        {
            lblEn.Hide();
            cboEdadEn.Hide();
            btnCalcularGrupoEtario.Hide();
        }

        private void mostrarControlesEdad()
        {
            lblEn.Show();
            cboEdadEn.Show();
            btnCalcularGrupoEtario.Show();
        }

        private void inicio()
        {
            lstPacientes.Enabled = true;
            bandera = false;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            btnGrabar.Enabled = false;
            btnCancelar.Enabled = false;
            dateTimePicker1.Hide();
            btnSalir.Enabled = true;
            btnNuevo.Enabled = true;
            btnActualizar.Enabled = true;
            ocultarControlesEdad();
            btnActualizar.Enabled = true;
            txtFechaNac.Visible = true;
        }
        


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevoPaciente();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            inicio();
            lstPacientes.SelectedIndex = 1;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            actualizarPaciente();
        }


        public bool validarEdad()
        {
            int valor = Convert.ToInt32(cboEdadEn.SelectedValue);
            bool bandera = false;

            if (valor == 1)
            {
                if (Convert.ToInt32(txtEdad.Text) > 30)
                {
                    MessageBox.Show("El valor no puede ser mayor a 30 dias.", "Error");
                    bandera = false;
                    txtEdad.Focus();
                }
            }
            else
            {
                bandera = true;
            }
            if (valor == 2)
            {
                if (Convert.ToInt32(txtEdad.Text) > 12)
                {
                    MessageBox.Show("El valor no puede ser mayor a 12 meses.", "Error");
                    bandera = false;
                    txtEdad.Focus();
                }
            }
            else
            {
                bandera = true;
            }


            return bandera;
        }


        private void btnCalcularGrupoEtario_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEdad.Text))
            {

                int parametro = Convert.ToInt32(cboEdadEn.SelectedValue);
                int edad = Convert.ToInt32(txtEdad.Text);

                if (validarEdad())
                {
                    // AMBOS SEXOS
                    if (cboGenero.SelectedIndex == 0 || cboGenero.SelectedIndex == 1)
                    {
                        //Calculos por dias
                        if (parametro == 1)
                        {

                            if (edad == 0)
                            {
                                cboGrupoEtario.SelectedValue = 1;
                            }

                            if (edad > 0 && edad <= 3)
                            {
                                cboGrupoEtario.SelectedValue = 2;
                            }

                            if (edad > 3 && edad <= 7)
                            {
                                cboGrupoEtario.SelectedValue = 3;
                            }

                            if (edad > 7 && edad <= 15)
                            {
                                cboGrupoEtario.SelectedValue = 4;
                            }

                            if (edad > 15 && edad <= 30)
                            {
                                cboGrupoEtario.SelectedValue = 5;
                            }

                        }
                        //Calculos por Meses
                        if (parametro == 2)
                        {
                            if (edad > 0 && edad <= 2)
                            {
                                cboGrupoEtario.SelectedValue = 6;
                            }

                            if (edad > 2 && edad <= 6)
                            {
                                cboGrupoEtario.SelectedValue = 7;
                            }

                            if (edad > 6 && edad <= 12)
                            {
                                cboGrupoEtario.SelectedValue = 8;
                            }

                        }

                        //calculo por años
                        if (parametro == 3)
                        {
                            if (edad > 0 && edad <= 2)
                            {
                                cboGrupoEtario.SelectedValue = 9;
                            }

                            if (edad > 2 && edad <= 6)
                            {
                                cboGrupoEtario.SelectedValue = 10;
                            }

                            if (edad > 6 && edad <= 12)
                            {
                                cboGrupoEtario.SelectedValue = 11;
                            }

                            if (edad > 12 && edad <= 18)
                            {
                                cboGrupoEtario.SelectedValue = 12;
                            }

                            if (edad > 18 && edad <= 99)
                            {
                                cboGrupoEtario.SelectedValue = 13;
                            }

                            if (edad > 99)
                            {
                                cboGrupoEtario.SelectedValue = 13;
                            }

                        }


                    }
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Campo edad vacio");
                txtEdad.Focus();
            }
        }


        private bool validar()
        {
            bool valido = false;

          


            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                MessageBox.Show("Debe completar el apellido.");
                valido = false;
                txtApellido.Focus();
            }
            else if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Debe completar los nombres.");
                valido = false;
                txtNombre.Focus();
            }
            else if (string.IsNullOrEmpty(txtEdad.Text))
            {
                MessageBox.Show("Debe completar la edad.");
                valido = false;
                txtEdad.Focus();
            }
            else if (string.IsNullOrEmpty(txtDni.Text))
            {
                MessageBox.Show("Debe completar el nro documento.");
                valido = false;
                txtDni.Focus();
            }
            else if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Debe completar el email.");
                valido = false;
                txtEmail.Focus();
            }
            else if (string.IsNullOrEmpty(txtCalleNro.Text))
            {
                MessageBox.Show("Debe completar el nro de la calle.");
                valido = false;
                txtCalleNro.Focus();
            }
            else if (string.IsNullOrEmpty(txtCalle.Text))
            {
                MessageBox.Show("Debe completar el nombre de la calle");
                valido = false;
                txtCalle.Focus();
            }
            else if (string.IsNullOrEmpty(txtBarrio.Text))
            {
                MessageBox.Show("Debe completar el barrio.");
                valido = false;
                txtBarrio.Focus();
            }
            else if (string.IsNullOrEmpty(txtTelParticular.Text))
            {
                MessageBox.Show("Debe completar el Tel Particular");
                valido = false;
                txtTelParticular.Focus();
            }
            else if (string.IsNullOrEmpty(txtCel.Text))
            {
                MessageBox.Show("Debe completar el Tel celular.");
                valido = false;
                txtCel.Focus();
            }


            else if (bandera==true)
            {
                if (existeDocumento(Convert.ToInt32(txtDni.Text)))
                {
                    MessageBox.Show("Ese número de documento se encuentra registrado.");
                    valido = false;
                    txtDni.Focus();
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


        public void ActualizarVectorPacientes()
        {
            vPacientes = miGestorPacientes.GetPacientes();
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
                            Paciente p = new Paciente();

                            p.apellido = txtApellido.Text;
                            p.nombre = txtNombre.Text;
                            p.edad = Convert.ToInt32(txtEdad.Text);
                            p.numeroDocumento = Convert.ToInt32(txtDni.Text);
                            p.tipoDocumento = Convert.ToInt32(cboTipoDoc.SelectedValue);
                            p.fechaNacimiento = dateTimePicker1.Value.ToShortDateString();
                            p.email = txtEmail.Text;
                            p.nacionalidad = cboNacionalidad.SelectedValue.ToString();
                            p.provincia = Convert.ToInt32(cboProvincias.SelectedValue);
                            p.localidad = Convert.ToInt32(cboLocalidades.SelectedValue);
                            p.genero = Convert.ToInt32(cboGenero.SelectedValue);
                            p.calle = txtCalle.Text;
                            p.numeroCalle = Convert.ToInt32(txtCalleNro.Text);
                            p.grupoEtario = Convert.ToInt32(cboGrupoEtario.SelectedValue);
                            p.obraSocial = cboOS.SelectedValue.ToString();
                            p.estadoCivil = Convert.ToInt32(cboEstadoCivil.SelectedValue);
                            p.telefonoFijo = txtTelParticular.Text;
                            p.telefonoCelular = txtCel.Text;
                            p.barrio = txtBarrio.Text;

                            sql = "INSERT INTO Pacientes(nombre,apellido,edad,fechaNacimiento,nacionalidad,grupoEtario,genero,nroDoc,tipoDoc,email,obraSocial,estadoCivil,provincia,localidad,calle,nroCalle,barrio,telefonoParticular,celularNro) VALUES ('"

                               + p.nombre + "','"
                               + p.apellido + "',"
                               + p.edad + ",'"
                               + p.fechaNacimiento + "','"
                               + p.nacionalidad + "',"
                               + p.grupoEtario + ","
                               + p.genero + ","
                               + p.numeroDocumento + ","
                               + p.tipoDocumento + ",'"
                               + p.email + "','"
                               + p.obraSocial + "',"
                               + p.estadoCivil + ","
                               + p.provincia + ","
                               + p.localidad + ",'"
                               + p.calle + "',"
                               + p.numeroCalle + ",'"
                               + p.barrio + "','"
                               + p.telefonoFijo + "','"
                               + p.telefonoCelular + "'"
                               + ")";
                            if (MetroFramework.MetroMessageBox.Show(this, "Desea registrar el paciente?", "Alta de paciente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                            miGestorPacientes.actualizarBD(sql);
                            miGestorPacientes.CargarListadoPacientes(lstPacientes);
                            ActualizarVectorPacientes();
                            inicio();
                            MessageBox.Show("Registro exitoso.");
                            lstPacientes.SelectedIndex = 0;
                            }
                            else
                            {
                            
                            }
                            
                        }



                        else
                        {
                            int i = lstPacientes.SelectedIndex;

                            vPacientes[i].apellido = txtApellido.Text;
                            vPacientes[i].nombre = txtNombre.Text;
                            vPacientes[i].genero = Convert.ToInt32(cboGenero.SelectedValue);
                            vPacientes[i].numeroDocumento = Convert.ToInt32(txtDni.Text);
                            vPacientes[i].obraSocial = cboOS.SelectedValue.ToString();
                            vPacientes[i].fechaNacimiento = txtFechaNac.Text;
                            vPacientes[i].provincia = Convert.ToInt32(cboProvincias.SelectedValue);
                            vPacientes[i].nacionalidad = cboNacionalidad.SelectedValue.ToString();
                            vPacientes[i].email = txtEmail.Text;
                            vPacientes[i].localidad = Convert.ToInt32(cboLocalidades.SelectedValue);
                            vPacientes[i].calle = txtCalle.Text;
                            vPacientes[i].numeroCalle = Convert.ToInt32(txtCalleNro.Text);
                            vPacientes[i].edad = Convert.ToInt32(txtEdad.Text);
                            vPacientes[i].grupoEtario = Convert.ToInt32(cboGrupoEtario.SelectedValue);
                            vPacientes[i].estadoCivil = Convert.ToInt32(cboEstadoCivil.SelectedValue);
                            vPacientes[i].tipoDocumento = Convert.ToInt32(cboTipoDoc.SelectedValue);
                            vPacientes[i].barrio = txtBarrio.Text;
                            vPacientes[i].telefonoFijo = txtTelParticular.Text;
                            vPacientes[i].telefonoCelular = txtCel.Text;


                            sql = "UPDATE Pacientes SET nombre ='" + vPacientes[i].nombre + "',"
                                                                      + "apellido='" + vPacientes[i].apellido + "',"
                                                                      + "edad= " + vPacientes[i].edad + ","
                                                                      + "fechaNacimiento= '" + vPacientes[i].fechaNacimiento + "',"
                                                                      + "nacionalidad= '" + vPacientes[i].nacionalidad + "',"
                                                                      + "grupoEtario= " + vPacientes[i].grupoEtario + ","
                                                                      + "NroDoc= " + vPacientes[i].numeroDocumento + ","
                                                                      + "tipoDoc= '" + vPacientes[i].tipoDocumento + "',"
                                                                      + "email= '" + vPacientes[i].email + "',"
                                                                      + "obraSocial= '" + vPacientes[i].obraSocial + "',"
                                                                      + "estadoCivil= " + vPacientes[i].estadoCivil + ","
                                                                      + "provincia= " + vPacientes[i].provincia + ","
                                                                      + "localidad= " + vPacientes[i].localidad + ","
                                                                      + "calle= '" + vPacientes[i].calle + "',"
                                                                      + "nroCalle= " + vPacientes[i].numeroCalle + ","
                                                                      + "barrio= '" + vPacientes[i].barrio + "',"
                                                                      + "telefonoParticular= '" + vPacientes[i].telefonoFijo + "',"
                                                                      + "celularNro= '" + vPacientes[i].telefonoCelular + "'"
                                                                      + " Where codigo = " + vPacientes[i].codigo;
                            if (MetroFramework.MetroMessageBox.Show(this, "Desea confirmar los cambios realizados?", "Actualización datos de paciente", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                miGestorPacientes.actualizarBD(sql);
                                miGestorPacientes.CargarListadoPacientes(lstPacientes);
                                ActualizarVectorPacientes();
                                inicio();
                                MessageBox.Show("Actualización correcta.");
                                lstPacientes.SelectedIndex = 0;
                            }
                        }

                    }
                
            }

            catch (Exception)
            {
                MessageBox.Show("No se puedo completar la transaccion: ");
            }
        }

        private void lstPacientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarCamposPacientes(lstPacientes.SelectedIndex);
        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo texto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo texto", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtCalleNro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
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


        private void BuscarDoc(string searchString)
        {
            
            if (searchString != string.Empty)
            {
                
                int index = lstPacientes.FindString(searchString);
                
                if (index != -1)
                    lstPacientes.SetSelected(index, true);
                else
                    MetroFramework.MetroMessageBox.Show(this,"El nro de documento no existe...");
            }

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
           string doc = txtFiltrar.Text;
           BuscarDoc(doc);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAdmPacientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Desea abandonar y salir de la Administración de pacientes?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
