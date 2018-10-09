using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HematoLab.Formularios
{
    public partial class FormTest2 : Form
    {


        int cBlasto = 0;
        int cPromielocito = 0;
        int cMielocitoNeutrofilo = 0;
        int cMetamielocitoNeutrofilo = 0;
        int cNeutrofiloCayado = 0;
        int cNeutrofiloSegmentado = 0;
        int cLinfocitos = 0;
        int cMonocitos = 0;
        int cEosinofilos = 0;
        int cBasofilos = 0;
        int cLinfocitosReactivos = 0;
        int cCelulasPlasmaticas = 0;
        int cEritroblasto = 0;


        public FormTest2()
        {
            InitializeComponent();
        }


        private void FormTest2_Load(object sender, EventArgs e)
        {

        }

        public void total()
        {
            int total = (cBlasto+cPromielocito+cMielocitoNeutrofilo+cMetamielocitoNeutrofilo+cNeutrofiloCayado
                        +cNeutrofiloSegmentado+cLinfocitos+cMonocitos+cEosinofilos+cBasofilos+cLinfocitosReactivos
                        +cCelulasPlasmaticas+cEritroblasto);
            lblTotales.Text = total.ToString();

            if(total==100)
            {
               if( MessageBox.Show("El conteo de elementos alcanzo los 100, desea seguir el recuento?", "Recuento visual", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
               {
                    
               }
               else
               {
                    /*pasar datos*/
               }

            }
        }

     
        private void FormTest2_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Q:
                    cBlasto++;
                    lblBlasto.Text = cBlasto.ToString();
                    lblUltimaTecla.Text = Keys.Q.ToString();
                    total();
                    break;
                case Keys.W:
                    cPromielocito++;
                    lblPromielocito.Text = cPromielocito.ToString();
                    lblUltimaTecla.Text = Keys.W.ToString();
                    total();
                    break;
                case Keys.E:
                    cMielocitoNeutrofilo++;
                    lblMielocitoNeutrofilo.Text = cMielocitoNeutrofilo.ToString();
                    lblUltimaTecla.Text = Keys.E.ToString();
                    total();
                    break;
                case Keys.R:
                    cMetamielocitoNeutrofilo++;
                    lblMetamielocitoNeutrofilo.Text = cMetamielocitoNeutrofilo.ToString();
                    lblUltimaTecla.Text = Keys.R.ToString();
                    total();
                    break;
                case Keys.F:
                    cNeutrofiloCayado++;
                    lblNeutrofiloCayado.Text = cNeutrofiloCayado.ToString();
                    lblUltimaTecla.Text = Keys.F.ToString();
                    total();
                    break;
                case Keys.A:
                    cNeutrofiloSegmentado++;
                    lblNeutrofiloSegmentado.Text = cNeutrofiloSegmentado.ToString();
                    lblUltimaTecla.Text = Keys.A.ToString();
                    total();
                    break;
                case Keys.S:
                    cLinfocitos++;
                    lblLinfocitos.Text = cLinfocitos.ToString();
                    lblUltimaTecla.Text = Keys.S.ToString();
                    total();
                    break;
                case Keys.D:
                    cMonocitos++;
                    lblMonocito.Text = cMonocitos.ToString();
                    lblUltimaTecla.Text = Keys.D.ToString();
                    total();
                    break;
                case Keys.Z:
                    cEosinofilos++;
                    lblEosinofilos.Text = cEosinofilos.ToString();
                    lblUltimaTecla.Text = Keys.Z.ToString();
                    total();
                    break;
                case Keys.X:
                    cBasofilos++;
                    lblBasofilos.Text = cBasofilos.ToString();
                    lblUltimaTecla.Text = Keys.X.ToString();
                    total();
                    break;
                case Keys.C:
                    cLinfocitosReactivos++;
                    lblLinfocitoReactivo.Text = cLinfocitosReactivos.ToString();
                    lblUltimaTecla.Text = Keys.C.ToString();
                    total();
                    break;
                case Keys.V:
                    cCelulasPlasmaticas++;
                    lblCelulaPlasmatica.Text = cCelulasPlasmaticas.ToString();
                    lblUltimaTecla.Text = Keys.V.ToString();
                    total();
                    break;
                case Keys.L:
                    cEritroblasto++;
                    lblEritroblastos.Text = cEritroblasto.ToString();
                    lblUltimaTecla.Text = Keys.L.ToString();
                    total();
                    break;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormTest2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Esta seguro de abandonar el recuento?", "Recuento visual", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
