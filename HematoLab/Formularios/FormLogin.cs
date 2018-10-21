using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using HematoLab.Clases;
using HematoLab.Gestores;

namespace HematoLab.Formularios
{
    public partial class FormLogin : Form
    {
        GestorUsuarios miGestor;
        private static string tabla1 = "UsuariosProfesionales";
        private static string tabla2 = "UsuariosNoMedicos";
        private static string tabla3 = "UsuariosExtractorio";
        private Usuario[] vUsuariosLab;
        private Usuario[] vUsuariosAtencionPublico;
        private Usuario[] vUsuariosExtractorio;
        private Administrador miAdmin;



        public FormLogin()
        {
            InitializeComponent();
            miGestor = new GestorUsuarios();
            vUsuariosLab = miGestor.GetObjetos(tabla1);
            vUsuariosAtencionPublico = miGestor.GetObjetos(tabla2);
            vUsuariosExtractorio = miGestor.GetObjetos(tabla3);
            miAdmin = miGestor.GetAdministrador();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;  
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtNombreUsuario_Enter(object sender, EventArgs e)
        {
            if(txtNombreUsuario.Text=="ALIAS")
            {
                txtNombreUsuario.Text = "";
                txtNombreUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtNombreUsuario_Leave(object sender, EventArgs e)
        {
            if (txtNombreUsuario.Text == "")
            {
                txtNombreUsuario.Text = "ALIAS";
                txtNombreUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            if (txtPassword.Text == "CONTRASEÑA")
            {
                txtPassword.Text = "";
                txtPassword.ForeColor = Color.LightGray;
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "CONTRASEÑA";
                txtPassword.ForeColor = Color.LightGray;
                txtPassword.UseSystemPasswordChar = false;
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            cargarCombo(cboTipoUsuario,"TiposUsuario");
        }

       
        private void restriccionesLab()
        {
            //instanciando el formulario principal
            FormMain main = new FormMain();
            MetroFramework.MetroMessageBox.Show(this, "Login exitoso bienvenido/a al sistema HematoLab.", "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
            main.HematoToolStripMenuItem.Enabled = true;
            main.UsuariosToolStripMenuItem.Enabled = false;
            main.TurnosToolStripMenuItem.Enabled = false;
            main.ExtractorioToolStripMenuItem.Enabled = false;
            usuarioLogueado(1);
            main.Show();//abriendo el formulario principal
            this.Hide();//esto sirve para ocultar el formulario de login
        }

        private void restriccionesExt()
        {
            //instanciando el formulario principal
            FormMain main = new FormMain();
            MetroFramework.MetroMessageBox.Show(this, "Login exitoso bienvenido/a al sistema HematoLab.", "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
            main.HematoToolStripMenuItem.Enabled = false;
            main.UsuariosToolStripMenuItem.Enabled = false;
            main.TurnosToolStripMenuItem.Enabled = false;
            main.ExtractorioToolStripMenuItem.Enabled = true;
            usuarioLogueado(3);
            main.Show();//abriendo el formulario principal
            this.Hide();//esto sirve para ocultar el formulario de login
        }

        private void restriccionesAtencion()
        {
            //instanciando el formulario principal
            FormMain main = new FormMain();
            MetroFramework.MetroMessageBox.Show(this, "Login exitoso bienvenido/a al sistema HematoLab.", "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
            main.HematoToolStripMenuItem.Enabled = false;
            main.UsuariosToolStripMenuItem.Enabled = false;
            main.TurnosToolStripMenuItem.Enabled = true;
            main.ExtractorioToolStripMenuItem.Enabled = false;
            usuarioLogueado(2);
            main.Show();//abriendo el formulario principal
            this.Hide();//esto sirve para ocultar el formulario de login
        }


        private void restriccionesAdministrador()
        {
            //instanciando el formulario principal
            FormMain main = new FormMain();
            MetroFramework.MetroMessageBox.Show(this, "Login exitoso bienvenido/a al sistema HematoLab.", "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
            main.HematoToolStripMenuItem.Enabled = false;
            main.UsuariosToolStripMenuItem.Enabled = true;
            main.TurnosToolStripMenuItem.Enabled = false;
            main.ExtractorioToolStripMenuItem.Enabled = false;
            usuarioLogueado(4);
            main.Show();//abriendo el formulario principal
            this.Hide();//esto sirve para ocultar el formulario de login
        }



        private void loginLaboratorio(int parametro,Usuario[] vUsuarios)
        {

            foreach (Usuario u in vUsuarios)
            {
                if(u!=null && u.tipoUsuario==parametro)
                {
                    if ((txtNombreUsuario.Text == u.usuario && (txtPassword.Text == u.pass) && (u.estado==1)))
                    {
                        restriccionesLab();
                        break;
                    }
                    else if ((txtNombreUsuario.Text == u.usuario && (txtPassword.Text == u.pass) && (u.estado == 2)))
                    {
                        MetroFramework.MetroMessageBox.Show(this, "El usuario ha sido dado de baja del sistema, consultar al Administrador.", "Prohibido el acceso", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        break;
                    }
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Error! Su contraseña y/o usuario son invalidos");
                    break;
                }
            }

        }

        private void loginAtencion(int parametro, Usuario[] vUsuarios)
        {

            foreach (Usuario u in vUsuarios)
            {
                if (u != null && u.tipoUsuario == parametro)
                {
                    if ((txtNombreUsuario.Text == u.usuario && (txtPassword.Text == u.pass) && (u.estado==1)))
                    {
                        restriccionesAtencion();
                        break;
                    }
                    else if ((txtNombreUsuario.Text == u.usuario && (txtPassword.Text == u.pass) && (u.estado == 2)))
                    {
                        MetroFramework.MetroMessageBox.Show(this, "El usuario ha sido dado de baja del sistema, consultar al Administrador.", "Prohibido el acceso", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        break;
                    }
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Error! Su contraseña y/o usuario son invalidos");
                    break;
                }
            }

        }

        private void loginExtractorio(int parametro, Usuario[] vUsuarios)
        {

            foreach (Usuario u in vUsuarios)
            {
                if (u != null && u.tipoUsuario == parametro)
                {
                    if ((txtNombreUsuario.Text == u.usuario && (txtPassword.Text == u.pass) && (u.estado==1)))
                    {
                        restriccionesExt();
                        break;
                    }
                    else if ((txtNombreUsuario.Text == u.usuario && (txtPassword.Text == u.pass ) && (u.estado==2)))
                    {
                        MetroFramework.MetroMessageBox.Show(this, "El usuario ha sido dado de baja del sistema, consultar al Administrador.", "Prohibido el acceso", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        break;
                    }
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Error! Su contraseña y/o usuario son invalidos");
                    break;
                }
            }

        }


        private void loginAdministrador( Administrador administrador)
        {

                if (administrador != null)
                {
                    if ((txtNombreUsuario.Text == administrador.userAdmin && (txtPassword.Text == administrador.passAdmin)))
                    {
                        restriccionesAdministrador();     
                    }
                    else
                    {
                       MetroFramework.MetroMessageBox.Show(this,"Error! Su contraseña y/o usuario son invalidos");
                    }
                }
           
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


        private string tabla()
        {
            string salida="";

            if(Convert.ToInt32(cboTipoUsuario.SelectedValue)==1)
            {
                salida = tabla1;
            }
            if (Convert.ToInt32(cboTipoUsuario.SelectedValue) == 2)
            {
                salida = tabla2;
            }
            if (Convert.ToInt32(cboTipoUsuario.SelectedValue) == 3)
            {
                salida = tabla3;
            }
            return salida;
        }

        private void usuarioLogueado(int parametro)
        {
            string usuario = txtNombreUsuario.Text;
            UserLoguedInn.usuario = usuario;
            UserLoguedInn.tipoUsuario = parametro;
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
          
                int parametro = Convert.ToInt32(cboTipoUsuario.SelectedValue);

                if (parametro == 1)
                {
                    loginLaboratorio(parametro, vUsuariosLab);
                }
                if (parametro == 2)
                {
                    loginAtencion(parametro, vUsuariosAtencionPublico);
                }
                if (parametro == 3)
                {
                    loginExtractorio(parametro, vUsuariosExtractorio);
                }
                if (parametro == 4)
                {
                    loginAdministrador(miAdmin);
                }
            
        }

        int x = 0;
        int y = 0;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                x = e.X;
                y = e.Y;
            }
            else
            {
                Left = Left + (e.X - x);
                Top = Top + (e.Y - y);
            }
        }
    }
}
