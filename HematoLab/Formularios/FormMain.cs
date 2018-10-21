using System;
using System.Windows.Forms;
using HematoLab.Clases;
using HematoLab.Reporte;

namespace HematoLab.Formularios
{
    public partial class FormMain : MetroFramework.Forms.MetroForm

    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            mensajesStatusBar();
            
        }


        private void mensajesStatusBar()
        {
            toolStripStatusLabelFechaYHora.Text = DateTime.Today.ToLongDateString();
            toolStripStatusLabel1.Text = "Usuario: " + UserLoguedInn.usuario;
        }


        private void administracionPacientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAdmPacientes admPac = new FormAdmPacientes();
            admPac.ShowDialog();
        }

        private void administracionTurnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAdmTurno admTurnos = new FormAdmTurno();
            admTurnos.ShowDialog();
        }

        private void administracionTomaDeMuestraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormExtractorio admExt = new FormExtractorio();
            admExt.ShowDialog();
        }

        private void profesionalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProfesionales nuevo = new FormProfesionales();
            nuevo.ShowDialog();
        }

      

        private void responsablesExtractorioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormResponsablesExtractorio nuevo = new FormResponsablesExtractorio();
            nuevo.ShowDialog();
        }

        private void administrarUsuariosSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUsuariosSistemaAdm nuevo = new FormUsuariosSistemaAdm();
            nuevo.ShowDialog();
        }

        private void filtrarTurnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormListadoTurnoFiltro nuevo = new FormListadoTurnoFiltro();
            nuevo.ShowDialog();
        }

      

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Desea abandonar y cerrar el sistema?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void secretariasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPersonalNoMedico nuevo = new FormPersonalNoMedico();
            nuevo.ShowDialog();
        }

        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHematoHome nuevo = new FormHematoHome();
            nuevo.ShowDialog();
        }

        private void emisiónDeInfomesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInformesGestionTurnos nuevo = new FormInformesGestionTurnos();
            nuevo.ShowDialog();
        }

        private void informesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormInformesGestionUsuarios nuevo = new FormInformesGestionUsuarios();
            nuevo.ShowDialog();
        }

        private void administrarCuentaAdministradorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAdministrador nuevo = new FormAdministrador();
            nuevo.ShowDialog();
        }

        private void evoluciónDelPacienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormReporteParamtro nuevo = new FormReporteParamtro();
            nuevo.ShowDialog();
        }
    }
}
