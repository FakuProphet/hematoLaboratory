using HematoLab.Gestores;
using System;
using System.Data;
using System.Windows.Forms;



namespace HematoLab.Formularios
{
    public partial class FormGenerarUsusariosSistema : MetroFramework.Forms.MetroForm
    {

        GestorUsuarios miGestor = new GestorUsuarios();


        public FormGenerarUsusariosSistema()
        {
            InitializeComponent();
            txtNombreUsuario.Focus();
        }

        private void FormAdmUsusariosSistema_Load(object sender, EventArgs e)
        {
            cargarCombo(cboTipoUsuario, "TiposUsuario",Convert.ToInt32(txtTipo.Text));
            cargarComboBasic(cboEstado, "estadoUsuario");
        }

        private void cargarCombo(ComboBox combo, string nombreTabla, int parametro)
        {
            DataTable tabla = new DataTable();
            tabla = miGestor.consultarTabla(nombreTabla);
            combo.DataSource = tabla;
            combo.DisplayMember = tabla.Columns[1].ColumnName;
            combo.ValueMember = tabla.Columns[0].ColumnName;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedValue = parametro;
        }

        private void cargarComboBasic(ComboBox combo, string nombreTabla)
        {
            DataTable tabla = new DataTable();
            tabla = miGestor.consultarTabla(nombreTabla);
            combo.DataSource = tabla;
            combo.DisplayMember = tabla.Columns[1].ColumnName;
            combo.ValueMember = tabla.Columns[0].ColumnName;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedIndex=0;
        }

        static string tablaUP = "UsuariosProfesionales";
        static string tablaUNM = "UsuariosNoMedicos";
        static string tablaUE = "UsuariosExtractorio";
        private void btnGenerarUsuario_Click(object sender, EventArgs e)
        {
            int legajo = Convert.ToInt32(txtLegajoUsuario.Text);
            string usuario = txtNombreUsuario.Text;
            string pass = txtContrasena.Text;
            int tipoUsuario = Convert.ToInt32(cboTipoUsuario.SelectedValue);
            int estado = Convert.ToInt32(cboEstado.SelectedValue);
            try
            {
                if (!String.IsNullOrEmpty(txtNombreUsuario.Text) && !String.IsNullOrEmpty(txtContrasena.Text))
                {
                    if (MetroFramework.MetroMessageBox.Show(this, "Desea generar el usuario de sistema?", "Usuario de sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (tipoUsuario == 1)
                        {
                            miGestor.generarUsuario(legajo, usuario, pass, tipoUsuario, estado, tablaUP);
                            MetroFramework.MetroMessageBox.Show(this, "Exito al generar el usuario de laboratorio");
                            this.Hide();
                        }
                        if (tipoUsuario == 2)
                        {
                            miGestor.generarUsuario(legajo, usuario, pass, tipoUsuario, estado, tablaUNM);
                            MetroFramework.MetroMessageBox.Show(this, "Exito al generar el usuario de  atención ");
                            this.Hide();
                        }
                        if (tipoUsuario == 3)
                        {
                            miGestor.generarUsuario(legajo, usuario, pass, tipoUsuario, estado, tablaUE);
                            MetroFramework.MetroMessageBox.Show(this, "Exito al generar el usuario extractorio");
                            this.Hide();
                        }
                    }
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "No debe quedar ningun campo vacio.");
                }
            }
            catch(Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, "Error al generar el registro: " + ex.ToString());
            }

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Desea abandonar y cancelar la generación del usuario?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                
            }
        }

        //private void FormGenerarUsusariosSistema_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if (MetroFramework.MetroMessageBox.Show(this, "Desea abandonar y cancelar la generación del usuario?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //    {
        //        e.Cancel = false;
        //    }
        //    else
        //    {
        //        e.Cancel = true;
        //    }
        //}
    }
}
