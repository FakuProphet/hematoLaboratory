using HematoLab.Clases;
using HematoLab.Gestores;
using System;
using System.Windows.Forms;

namespace HematoLab.Formularios
{
    public partial class FormAdministrador : MetroFramework.Forms.MetroForm
    {

        GestorUsuarios g;
    


        public FormAdministrador()
        {
            InitializeComponent();
            g = new GestorUsuarios();
        }

        private void DatosAdmin()
        {
            Administrador a = g.GetAdministrador();
            lblNombreUsuarioActual.Text = a.userAdmin.ToString();
            lblPassActual.Text = a.passAdmin.ToString();
        }

        private void FormAdministrador_Load(object sender, EventArgs e)
        {
            inicio();
            DatosAdmin();
        }


        private void inicio()
        {
            groupBox1.Enabled = false;
            btnCancelar.Enabled = false;
            btnSalir.Enabled = true;
            btnGrabar.Enabled = false;
            btnDesbloquear.Enabled = true;
            txtUsuario.Text = "";
            txtPass.Text = "";
            btnDesbloquear.Focus();
            txtPass.UseSystemPasswordChar = true;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(txtPass.Text) && !String.IsNullOrEmpty(txtUsuario.Text))
            {
                if (MetroFramework.MetroMessageBox.Show(this, "Desea actualizar los datos del Administrador?", "Actualizar Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    g.actualizarUsuarioAdministrador(txtPass.Text,txtUsuario.Text);
                    MetroFramework.MetroMessageBox.Show(this, "La actualización se realizó con exito!");
                    inicio();
                    DatosAdmin();
                }
                
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Hay campos vacios");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            inicio();
        }

        private void FormAdministrador_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Desea abandonar y volver a la pantalla principal?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

      

        private void btnDesbloquear_Click(object sender, EventArgs e)
        {
           if(groupBox1.Enabled == true)
           {
                groupBox1.Enabled = false;
                btnGrabar.Enabled = false;
                btnCancelar.Enabled = false;
            }
           else
           {
                groupBox1.Enabled = true;
                txtUsuario.Focus();
                btnGrabar.Enabled = true;
                btnCancelar.Enabled = true;
                btnDesbloquear.Enabled = false;
           }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

     
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string text = txtPass.Text;
            if (checkBox1.Checked)
            {
                txtPass.UseSystemPasswordChar = false;
                txtPass.Text = text;
            }
            else
            {
                txtPass.UseSystemPasswordChar = true;
                txtPass.Text = text;
            }
        }
    }
}
