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

namespace HematoLab.Formularios
{
    public partial class FormAdmUsuarios : MetroFramework.Forms.MetroForm
    {

       
        private bool banderaProf;
        Profesional[] vProfesionales;
        GestorProfesionales miGestorProfesionales = new GestorProfesionales();
     

        public FormAdmUsuarios()
        {
            InitializeComponent();
            banderaProf = false;
            vProfesionales = miGestorProfesionales.GetProfesionales();
        }

        private void FormAdmUsurios_Load(object sender, EventArgs e)
        {
            cargarCombosProfesionales();
            miGestorProfesionales.CargarListadoProfesionales(lstProfesionales);
            inicio();
            comprobarLista();
        }

     

        
       

        private void comprobarLista()
        {
            if (lstProfesionales.Items.Count == 0)
                MessageBox.Show("Lista Vacia.");
            else
                lstProfesionales.SelectedIndex = 0;
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

     

        private void btnCancelarProf_Click(object sender, EventArgs e)
        {
            inicio();
            lblFechaRegProf.Visible = true;
            txtFechaRegistroProf.Visible = true;
        }

        private void nuevoProfesional()
        {
            banderaProf = true;
            groupBox1.Enabled = true;
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
        }



        private void inicio()
        {
            lstProfesionales.Enabled = true;
            lstProfesionales.SelectedIndex = 0;
            banderaProf = false;
            groupBox1.Enabled = false;
            btnGrabarProf.Enabled = false;
            btnCancelarProf.Enabled = false;
           // lblFechaRegProf.Hide();
            btnSalirProf.Enabled = true;
            btnNuevoProf.Enabled = true;
        }

        private bool validar()
        {
            bool valido = false;


            if (string.IsNullOrEmpty(this.txtApeProf.Text))
            {
                MessageBox.Show("Debe completar el apellido.");
                valido = false;
            }
            else if (string.IsNullOrEmpty(this.txtNombreProf.Text))
            {
                MessageBox.Show("Debe completar los nombres.");
                valido = false;
            }
            else if (string.IsNullOrEmpty(this.txtEdadProf.Text))
            {
                MessageBox.Show("Debe completar la edad.");
                valido = false;
            }
            else if (string.IsNullOrEmpty(this.txtNroDocProf.Text))
            {
                MessageBox.Show("Debe completar el nro documento.");
                valido = false;
            }
            else if (string.IsNullOrEmpty(this.txtEmailProf.Text))
            {
                MessageBox.Show("Debe completar el email.");
                valido = false;
            }
            else if (existeDocumento(Convert.ToDouble(txtNroDocProf.Text)))
            {
                MessageBox.Show("El dni ya existe en nuestros registros.");
                valido = false;
            }
            else if (existeMatricula(txtMatriculaProf.Text))
            {
                MessageBox.Show("La matricula ya existe en nuestros registros.");
                valido = false;
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

        }

        private void btnGrabarProf_Click(object sender, EventArgs e)
        {
            string sql = "";


            if (banderaProf)
            {

                if (validar())

                {
                    Profesional p = new Profesional();
                    p.pApellido = txtApeProf.Text;
                    p.pNombre = txtNombreProf.Text;
                    p.pEdad = Convert.ToInt32 (txtEdadProf.Text);
                    p.pNroDoc = Convert.ToInt32(txtNroDocProf.Text);
                    p.pTipoDoc = Convert.ToInt32(cboTipoDocProf.SelectedValue);
                    p.pFechaNac = dtpFechaNacProf.Value.ToString();
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

                    miGestorProfesionales.actualizarBD(sql);
                    miGestorProfesionales.CargarListadoProfesionales(lstProfesionales);
                    ActualizarVectorProfesionales();
                    inicio();
                    MessageBox.Show("Registro exitoso.");
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
                vProfesionales[i].pFechaNac = dtpFechaNacProf.Value.ToString();
                vProfesionales[i].pIdEspecialidad = Convert.ToInt32(cboEspecialidadProf.SelectedValue);
                vProfesionales[i].pLegajo = Convert.ToInt32 (txtLegajoProf.Text);
                vProfesionales[i].pEmail = txtEmailProf.Text;
                vProfesionales[i].pIdTurnoTrabajo = Convert.ToInt32(cboTurnoProf.SelectedValue);
                vProfesionales[i].pFechaNac = dtpFechaNacProf.Value.ToShortDateString();
                vProfesionales[i].pMatricula = txtMatriculaProf.Text;

                sql = "Update Profesionales set apellido ='" + vProfesionales[i].pApellido + "',"
                                                      + "nombre='" + vProfesionales[i].pNombre + "',"
                                                      + "matricula= " + vProfesionales[i].pMatricula + ","
                                                      + "turno= " + vProfesionales[i].pIdTurnoTrabajo + ","
                                                      + "fechaNac= '" + vProfesionales[i].pFechaNac + "',"
                                                      + "edad= " + vProfesionales[i].pEdad + ","
                                                      + "genero= " + vProfesionales[i].pIdGenero + ","
                                                      + "nroDoc= " + vProfesionales[i].pNroDoc + ","
                                                      + "tipoDoc= " + vProfesionales[i].pTipoDoc + ","
                                                      + "email= '" + vProfesionales[i].pEmail + "',"
                                                      + "especialidad= " + vProfesionales[i].pIdEspecialidad + ","
                                                      + "tituloAcademico= " + vProfesionales[i].pTituloAcademico + ","
                                                      + " Where codigoSocio = " + vProfesionales[i].pLegajo;
                miGestorProfesionales.actualizarBD(sql);
                miGestorProfesionales.CargarListadoProfesionales(lstProfesionales);
                ActualizarVectorProfesionales();
                inicio();
                lstProfesionales.SelectedIndex = 0;
            }
        }

        private void lstProfesionales_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarCamposProfesionales(lstProfesionales.SelectedIndex);
        }

        private void btnNuevoProf_Click(object sender, EventArgs e)
        {
            nuevoProfesional();
        }




    }
}
