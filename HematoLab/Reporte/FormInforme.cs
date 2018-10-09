using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HematoLab.Reporte
{
    public partial class FormInforme : MetroFramework.Forms.MetroForm
    {

        public string fecha;
        public int dni;
        public int idGenero;


        public FormInforme()
        {
            InitializeComponent();
        }


        private void FormInforme_Load(object sender, EventArgs e)
        {
            CrystalReport5 objReporte = new CrystalReport5();
            objReporte.SetParameterValue("@fecha", fecha);
            objReporte.SetParameterValue("@dni", dni);
            objReporte.SetParameterValue("@id", idGenero);
            crystalReportViewerNuevo.ReportSource = objReporte;
        }
    }
}
