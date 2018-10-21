using System;

namespace HematoLab.Formularios
{
    public partial class FormInfoPaciente : MetroFramework.Forms.MetroForm
    {
        public FormInfoPaciente()
        {
            InitializeComponent();
        }

        private void FormInfoPaciente_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
