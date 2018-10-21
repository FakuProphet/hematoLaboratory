using HematoLab.Clases;
using HematoLab.Gestores;
using System;
using System.Windows.Forms;

namespace HematoLab.Formularios
{
    public partial class FormConteoGuardar : MetroFramework.Forms.MetroForm
    {

        GestorConteo miGestor;

        public FormConteoGuardar()
        {
            InitializeComponent();
            miGestor = new GestorConteo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtAlias.Text))
                {
                    if (MetroFramework.MetroMessageBox.Show(this, "Desea guardar el conteo?", "Guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Conteo.alias = this.txtAlias.Text;
                        miGestor.insertar(Conteo.fecha, Conteo.hora, Conteo.alias, Conteo.blasto, Conteo.promielocito, Conteo.mielNeutro,
                                         Conteo.metamielNeutro, Conteo.neutCayado, Conteo.neuSegm, Conteo.eosinofilo,
                                         Conteo.basofilo, Conteo.linfocito, Conteo.monocito, Conteo.linfReac, Conteo.celPLasmatica,
                                         Conteo.eritroblasto, Conteo.paciente, Conteo.dni);
                        MetroFramework.MetroMessageBox.Show(this, "Registro exitoso");
                        this.Dispose();
                    }
                    else
                    {

                    }
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Debe ingresar un alias");
                }
            }
            catch (Exception exc)
            {
                MetroFramework.MetroMessageBox.Show(this, "Error: " + exc.ToString());
            }
        }

        private void FormConteoGuardar_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
