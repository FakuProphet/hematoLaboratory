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
using HematoLab.Clases;

namespace HematoLab.Formularios
{
    public partial class FormUsuariosSistemaAdm : MetroFramework.Forms.MetroForm
    {

        GestorUsuarios miGestor = new GestorUsuarios();
        Usuario[] vUsuariosLaboratorio;
        Usuario[] vUsuariosExtractorio;
        Usuario[] vUsuariosNoMedicos;
        private static string tabla1 = "UsuariosProfesionales";
        private static string tabla2 = "UsuariosNoMedicos";
        private static string tabla3 = "UsuariosExtractorio";



        public FormUsuariosSistemaAdm()
        {
            InitializeComponent();
            vUsuariosLaboratorio = miGestor.GetObjetos(tabla1);
            vUsuariosNoMedicos = miGestor.GetObjetos(tabla2);
            vUsuariosExtractorio = miGestor.GetObjetos(tabla3);
        }



        private void FormUsuariosSistemaAdm_Load(object sender, EventArgs e)
        {
            CargarTodosLosCombos();
            CargarTodosLosListados();
            ComprobarTodasLasListas();      
        }

        void CargarTodosLosCombos()
        {
            CargarComboBasic(cboEstadoLab,"estadoUsuario");
            CargarComboBasic(cboTipoUsuarioLab, "tiposUsuario");
            CargarComboBasic(cboEstadoExt, "estadoUsuario");
            CargarComboBasic(cboTipoUsuarioExt, "tiposUsuario");
            CargarComboBasic(cboEstadoAP, "estadoUsuario");
            CargarComboBasic(cboTipoUsuarioAP, "tiposUsuario");
        }

        void CargarTodosLosListados()
        {
            miGestor.CargarListado(lstUsuariosProfesionales,tabla1);
            miGestor.CargarListado(lstPersonalAtencion, tabla2);
            miGestor.CargarListado(lstExtractorio,tabla3);
        }

        private void CargarComboBasic(ComboBox combo, string nombreTabla)
        {
            DataTable tabla = new DataTable();
            tabla = miGestor.consultarTabla(nombreTabla);
            combo.DataSource = tabla;
            combo.DisplayMember = tabla.Columns[1].ColumnName;
            combo.ValueMember = tabla.Columns[0].ColumnName;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedIndex = 0;
        }

        private void ComprobarLista(ListBox lista)
        {
            if (lista.Items.Count == 0)
                MessageBox.Show("Lista Vacia.");
            else
                lista.SelectedIndex = 0;
        }

        private void ComprobarTodasLasListas()
        {
            ComprobarLista(lstExtractorio);
            ComprobarLista(lstPersonalAtencion);
            ComprobarLista(lstUsuariosProfesionales);
        }


        private void CargarCamposUsuariosLab(int posicion)
        {
            txtLegajoLab.Text = vUsuariosLaboratorio[posicion].legajo.ToString();
            cboTipoUsuarioLab.SelectedValue = vUsuariosLaboratorio[posicion].tipoUsuario;
            txtNombreUsuarioLab.Text = vUsuariosLaboratorio[posicion].usuario;
            txtContrasenaLab.Text = vUsuariosLaboratorio[posicion].pass;
            cboEstadoLab.SelectedValue = vUsuariosLaboratorio[posicion].estado;
        }

        private void CargarCamposUsuariosExt(int posicion)
        {
            txtLegajoExt.Text = vUsuariosExtractorio[posicion].legajo.ToString();
            cboTipoUsuarioExt.SelectedValue = vUsuariosExtractorio[posicion].tipoUsuario;
            txtNombreUsuarioExt.Text = vUsuariosExtractorio[posicion].usuario;
            txtPassExt.Text = vUsuariosExtractorio[posicion].pass;
            cboEstadoExt.SelectedValue = vUsuariosExtractorio[posicion].estado;
        }

        private void CargarCamposUsuariosNoMed(int posicion)
        {
            txtLegajoAP.Text = vUsuariosNoMedicos[posicion].legajo.ToString();
            cboTipoUsuarioAP.SelectedValue = vUsuariosNoMedicos[posicion].tipoUsuario;
            txtNombreUsuarioAP.Text = vUsuariosNoMedicos[posicion].usuario;
            txtPassAP.Text = vUsuariosNoMedicos[posicion].pass;
            cboEstadoAP.SelectedValue = vUsuariosNoMedicos[posicion].estado;
        }

        private void lstUsuariosProfesionales_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCamposUsuariosLab(lstUsuariosProfesionales.SelectedIndex);
        }

        private void lstPersonalAtencion_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCamposUsuariosNoMed(lstPersonalAtencion.SelectedIndex);
        }

        private void lstExtractorio_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCamposUsuariosExt(lstExtractorio.SelectedIndex);
        }


        private void ActualizarUsuarioAtencionPublico()
        {
            txtNombreUsuarioAP.Enabled = true;
            txtPassAP.Enabled = true;
            cboEstadoAP.Enabled = true;
            lstPersonalAtencion.Enabled = false;
            //btnSalirAtPublico.Enabled = false;
            btnActualizarAtPublico.Hide();
            btnCancelarAtPublico.Enabled = true;
            txtNombreUsuarioAP.Focus();
        }

        private void CancelarActualizarUsuarioAtencionPublico()
        {
            txtNombreUsuarioAP.Enabled = false;
            txtPassAP.Enabled = false;
            cboEstadoAP.Enabled = false;
            lstPersonalAtencion.Enabled = true;
            //btnSalirAtPublico.Enabled = true;
            btnCancelarAtPublico.Enabled = false;
            btnActualizarAtPublico.Visible = true;
            lstPersonalAtencion.SelectedIndex = 0;
        }

        private void ActualizarUsuarioExtractorio()
        {
            txtNombreUsuarioExt.Enabled = true;
            txtPassExt.Enabled = true;
            cboEstadoExt.Enabled = true;
            lstExtractorio.Enabled = false;
            btnSalirExt.Enabled = false;
            btnActualizarUsuarioExt.Hide();
            btnCancelarExt.Enabled = true;
            txtNombreUsuarioExt.Focus();
        }

        private void CancelarActualizarUsuarioExtractorio()
        {
            txtNombreUsuarioExt.Enabled = false;
            txtPassExt.Enabled = false;
            cboEstadoExt.Enabled = false;
            lstExtractorio.Enabled = true;
            btnSalirExt.Enabled = true;
            btnCancelarExt.Enabled = false;
            btnActualizarUsuarioExt.Visible=true;
            lstExtractorio.SelectedIndex = 0;
        }

        private void ActualizarUsuarioLaboratorio()
        {
            txtNombreUsuarioLab.Enabled = true;
            txtContrasenaLab.Enabled = true;
            cboEstadoLab.Enabled = true;
            lstUsuariosProfesionales.Enabled = false;
            //btnSalirLab.Enabled = false;
            btnActualizarLab.Hide();
            btnCancelarLab.Enabled = true;
            txtNombreUsuarioLab.Focus();
        }

        private void CancelarActualizarUsuarioLaboratorio()
        {
            txtNombreUsuarioLab.Enabled = false;
            txtContrasenaLab.Enabled = false;
            cboEstadoLab.Enabled = false;
            lstUsuariosProfesionales.Enabled = true;
            //btnSalirLab.Enabled = true;
            btnCancelarLab.Enabled = false;
            btnActualizarLab.Visible = true;
            lstUsuariosProfesionales.SelectedIndex = 0;
        }

        private void InicioActualizarUsuarioLaboratorio()
        {
            txtNombreUsuarioLab.Enabled = false;
            txtContrasenaLab.Enabled = false;
            cboEstadoLab.Enabled = false;
            lstUsuariosProfesionales.Enabled = true;
            //btnSalirLab.Enabled = true;
            btnCancelarLab.Enabled = false;
            btnActualizarLab.Visible = true;
            lstUsuariosProfesionales.SelectedIndex = 0;
        }

        private void InicioActualizarUsuarioExtractorio()
        {
            txtNombreUsuarioExt.Enabled = false;
            txtPassExt.Enabled = false;
            cboEstadoExt.Enabled = false;
            lstExtractorio.Enabled = true;
            btnSalirExt.Enabled = true;
            btnCancelarExt.Enabled = false;
            btnActualizarUsuarioExt.Visible = true;
            lstExtractorio.SelectedIndex = 0;
        }

        private void InicioActualizarUsuarioAtencionPublico()
        {
            txtNombreUsuarioAP.Enabled = false;
            txtPassAP.Enabled = false;
            cboEstadoAP.Enabled = false;
            lstPersonalAtencion.Enabled = true;
            //btnSalirAtPublico.Enabled = true;
            btnCancelarAtPublico.Enabled = false;
            btnActualizarAtPublico.Visible = true;
            lstPersonalAtencion.SelectedIndex = 0;
        }

        private void btnActualizarUsuarioExt_Click(object sender, EventArgs e)
        {
            ActualizarUsuarioExtractorio();
        }

        private void btnCancelarExt_Click(object sender, EventArgs e)
        {
            CancelarActualizarUsuarioExtractorio();
        }

        private void btnGrabarExt_Click(object sender, EventArgs e)
        {
            try
            {
                if (MetroFramework.MetroMessageBox.Show(this, "Desea actualizar datos usuario EXTRACTORIO?", "Generar Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    string pass = txtPassExt.Text;
                    string usuario = txtNombreUsuarioExt.Text;
                    int estado = Convert.ToInt32(cboEstadoExt.SelectedValue);
                    int legajo = Convert.ToInt32(txtLegajoExt.Text);
                    miGestor.actualizarUsuario(pass, usuario, estado, tabla3, legajo);
                    ActualizarVectorUsuariosExtractorio();
                    InicioActualizarUsuarioExtractorio();
                    MetroFramework.MetroMessageBox.Show(this, "Actualización correcta!");
                }
                else
                {

                }
            }
            catch (Exception exc)
            {
                MetroFramework.MetroMessageBox.Show(this, exc.ToString());
            }
        }

        private void btnActualizarLab_Click(object sender, EventArgs e)
        {
            ActualizarUsuarioLaboratorio();  
        }

        private void btnCancelarLab_Click(object sender, EventArgs e)
        {
            CancelarActualizarUsuarioLaboratorio();
        }

        private void btnGrabarUsuarioLab_Click(object sender, EventArgs e)
        {
            try
            {
                if (MetroFramework.MetroMessageBox.Show(this, "Desea actualizar datos usuario LABORATORIO?", "Generar Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string usuario = txtNombreUsuarioLab.Text;
                    string pass = txtContrasenaLab.Text;
                    int estado = Convert.ToInt32(cboEstadoLab.SelectedValue);
                    int legajo = Convert.ToInt32(txtLegajoLab.Text);
                    miGestor.actualizarUsuario(pass, usuario, estado, tabla1, legajo);
                    ActualizarVectorUsuariosLaboratorio();
                    InicioActualizarUsuarioLaboratorio();
                    MetroFramework.MetroMessageBox.Show(this, "Actualización correcta!");
                }
                else
                {

                }
            }
            catch (Exception exc)
            {
                MetroFramework.MetroMessageBox.Show(this, exc.ToString());
            }
        }

        private void btnCancelarAtPublico_Click(object sender, EventArgs e)
        {
            CancelarActualizarUsuarioAtencionPublico();
        }

        private void btnActualizarAtPublico_Click(object sender, EventArgs e)
        {
            ActualizarUsuarioAtencionPublico();
        }

        private void btnGrabarUsuarioAP_Click(object sender, EventArgs e)
        {
            try
            {
                if (MetroFramework.MetroMessageBox.Show(this, "Desea  actualizar datos usuario ATENCIÓN?", "Generar Usuario", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string usuario = txtNombreUsuarioAP.Text;
                    string pass = txtPassAP.Text;
                    int estado = Convert.ToInt32(cboEstadoAP.SelectedValue);
                    int legajo = Convert.ToInt32(txtLegajoAP.Text);
                    miGestor.actualizarUsuario(pass, usuario, estado, tabla2, legajo);
                    ActualizarVectorUsuariosAtencion();
                    InicioActualizarUsuarioAtencionPublico();
                    MetroFramework.MetroMessageBox.Show(this, "Actualización correcta!");
                }
                else
                {

                }
            }
            catch (Exception exc)
            {
                MetroFramework.MetroMessageBox.Show(this, exc.ToString());
            }
        }


        public void ActualizarVectorUsuariosLaboratorio()
        {
            vUsuariosLaboratorio = miGestor.GetObjetos(tabla1);
        }

        public void ActualizarVectorUsuariosAtencion()
        {
            vUsuariosNoMedicos = miGestor.GetObjetos(tabla2);
        }

        public void ActualizarVectorUsuariosExtractorio()
        {
            vUsuariosExtractorio = miGestor.GetObjetos(tabla3);
        }

        private void btnSalirExt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormUsuariosSistemaAdm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Abandonar Administración de usuarios de sistema?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
