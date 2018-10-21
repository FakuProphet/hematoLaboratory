using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Speech.Recognition;
using HematoLab.Clases;

namespace HematoLab.Formularios
{
    public partial class FormContadorElementos : MetroFramework.Forms.MetroForm
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
        string gb;
        bool bandera;
        SpeechRecognitionEngine reco = new SpeechRecognitionEngine();
        Choices opcionesVoz = new Choices();
        private Timer tiempo;

        public FormContadorElementos()
        {
            tiempo = new Timer();
            tiempo.Tick += new EventHandler(eventoReloj);
            InitializeComponent();
            bandera = false;
            tiempo.Enabled = true;
        }


        private void FormContadorElementos_Load(object sender, EventArgs e)
        {
          cargarDatosHemograma();
          guardarValorGB();
          fechaActual();
          this.Focus();
        }


        private void activarVoz()
        {
            opcionesVoz.Add(new string[] { "pausar", "continuar", "detenermicrofono" });
            Grammar gramatica = new Grammar(new GrammarBuilder(opcionesVoz));

            
            reco.SetInputToDefaultAudioDevice(); // Usaremos el microfono predeterminado del sistema
            reco.LoadGrammar(gramatica); //Carga la gramatica de Windows
            reco.SpeechRecognized += te_escucho; // Controlador de eventos. Se ejecutara al reconocer
            reco.RecognizeAsync(RecognizeMode.Multiple);
        }

        void te_escucho(object sender, SpeechRecognizedEventArgs e)
        {

            if (e.Result.Text == "pausar")
            {
                this.KeyPreview = false;
                btnPlay.Enabled = true;
                btnPausarConteo.Enabled = false;
                btnHabilitarEdicion.Enabled = false;
               btnPlay.Focus();
            }
            if (e.Result.Text == "continuar")
            {
                this.KeyPreview = true;
                btnPausarConteo.Enabled = true;
                btnPlay.Enabled = false;
                btnHabilitarEdicion.Enabled = true;
               btnPausarConteo.Focus();
            }
            if (e.Result.Text == "detenermicrofono")
            {
                reco.RecognizeAsyncStop();
                lblMicrofono.Text = "OFF";
                lblMicrofono.BackColor = Color.Red;
                btnActivarVoz.Show();
            }
        }



        private void guardarValorGB()
        {
            gb = txtGBWB.Text;
            GB.valorGB = gb;
        }

        private decimal calculoDiezPorciento()
        {
            decimal total = Convert.ToDecimal(totalElementosContados(), CultureInfo.InvariantCulture);
            Decimal diezPorCiento = Convert.ToDecimal(total * 10 / 100, CultureInfo.InvariantCulture);
            return diezPorCiento;
        }

        private void mostrarPorcentaje()
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            lblSalidaPorc.Text = calculoDiezPorciento().ToString("N", nfi);
        }

        private void totalMasEritroblastos()
        {
            int total = totalElementosContados() + cEritroblasto;
            lblTotalMasEritrob.Text = total.ToString();
        }

        private void alertaEritroblastos()
        {
            decimal entrada = Convert.ToDecimal(cEritroblasto, CultureInfo.InvariantCulture);

            int contados = totalElementosContados();
            if (contados >= 100)
            {
                if (cEritroblasto >= calculoDiezPorciento())
                {
                    button1.Enabled = true;
                    bandera = true;
                }
                else
                {
                    button1.Enabled = false;
                    bandera = false;
                }
            }
        }


        private void cargarDatosHemograma()
        {
            // int cod
            int grupoEtario = Convert.ToInt32(lblCodigoGE.Text);
            int genero = Convert.ToInt32(lblCodigoGenero.Text);

            /* GRUPO ETARIO RN 0 DIAS*/
            if (grupoEtario == 1)
            {
                alarmasGrupoEtario1();
            }

            /*GRUPO ETARIO 1-3 DIAS*/
            if (grupoEtario == 2)
            {
                alarmasGrupoEtario2();
            }

            /*GRUPO ETARIO 4-7 DIAS*/
            if (grupoEtario == 3)
            {
                alarmasGrupoEtario3();
            }

            /*GRUPO ETARIO 8-15 DIAS*/
            if (grupoEtario == 4)
            {
                alarmasGrupoEtario4();
            }

            /*GRUPO ETARIO 16-30 DIAS*/
            if (grupoEtario == 5)
            {
                alarmasGrupoEtario5();
            }

            /*GRUPO ETARIO 1-2 MESES*/
            if (grupoEtario == 6)
            {
                alarmasGrupoEtario6();
            }

            /*GRUPO ETARIO 3-6 MESES*/
            if (grupoEtario == 7)
            {
                alarmasGrupoEtario7();
            }

            /*GRUPO ETARIO 7-12 MESES*/
            if (grupoEtario == 8)
            {
                alarmasGrupoEtario8();
            }

            /*GRUPO ETARIO 1-2 ANIOS*/
            if (grupoEtario == 9)
            {
                alarmasGrupoEtario9();
            }

            /*GRUPO ETARIO 3-6 ANIOS*/
            if (grupoEtario == 10)
            {
                alarmasGrupoEtario10();
            }

            /*GRUPO ETARIO 7-12 ANIOS*/
            if (grupoEtario == 11)
            {
                alarmasGrupoEtario11();
            }

            /*HOMBRES GRUPO ETARIO 13-18*/
            if (grupoEtario == 12 && genero == 1)
            {
                alarmasGrupoEtario13();
            }

            /*MUJERES GRUPO ETARIO 13-18*/
            if (grupoEtario == 12 && genero == 2)
            {
                alarmasGrupoEtario12();
            }

            /*HOMBRES GRUPO ETARIO 19-99*/
            if (grupoEtario == 13 && genero == 1)
            {
                alarmasGrupoEtario15();
            }

            /*MUJERES GRUPO ETARIO 19-99*/
            if (grupoEtario == 13 && genero == 2)
            {
                alarmasGrupoEtario14();
            }
        }



        /*GRUPO ETARIO RN 0 DIAS*//*CORREGIDO*/
        private void alarmasGrupoEtario1()
        {
            decimal RDW = Convert.ToDecimal(txtRDW.Text, CultureInfo.InvariantCulture);
            decimal PLT = Convert.ToDecimal(txtPLT.Text, CultureInfo.InvariantCulture);
            decimal CHCM = Convert.ToDecimal(txtCHCM.Text, CultureInfo.InvariantCulture);
            decimal HCM = Convert.ToDecimal(txtHCM.Text, CultureInfo.InvariantCulture);
            decimal VCM = Convert.ToDecimal(txtVCM.Text, CultureInfo.InvariantCulture);
            decimal HTO = Convert.ToDecimal(txtHTO.Text, CultureInfo.InvariantCulture);
            decimal HB = Convert.ToDecimal(txtHB.Text, CultureInfo.InvariantCulture);
            decimal GBRBC = Convert.ToDecimal(txtGBRBC.Text, CultureInfo.InvariantCulture);
            decimal GBWB = Convert.ToDecimal(txtGBWB.Text, CultureInfo.InvariantCulture);



            if (RDW > 15.0m && RDW <= 18.0m)
            {
                lblSalidaAlarmaRDW.Text = "↑ " + RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Yellow;
            }
            if (RDW > 18.0m)
            {
                lblSalidaAlarmaRDW.Text = "↑ " + RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Red;
            }
            if (RDW <= 15.0m)
            {
                lblSalidaAlarmaRDW.Text = RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Black;
            }


            if (PLT >= 150m && PLT <= 450m)
            {
                lblSalidaPLT.Text = PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Black;
            }
            if (PLT < 150m && PLT >= 100m)
            {
                lblSalidaPLT.Text = "↓ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Yellow;
            }
            if (PLT < 100m)
            {
                lblSalidaPLT.Text = "↓ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Red;
            }

            if (PLT >= 450m && PLT <= 600m)
            {
                lblSalidaPLT.Text = "↑ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Yellow;
            }

            if (PLT > 600m)
            {
                lblSalidaPLT.Text = "↑ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Red;
            }



            if (CHCM >= 31m && CHCM <= 36m)
            {
                lblSalidaCHCM.Text = CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Black;
            }

            if (CHCM > 36m)
            {
                lblSalidaCHCM.Text = "↑ " + CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Red;
            }

            if (CHCM < 31m)
            {
                lblSalidaCHCM.Text = "↓ " + CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Yellow;
            }


            //HCM
            decimal porcentaje = Convert.ToDecimal(31 * 0.8);



            if (HCM >= 31m && HCM <= 37m)
            {
                lblSalidaHCM.Text = HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Black;
            }


            if (HCM > 37m)
            {
                lblSalidaHCM.Text = "↑ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Yellow;
            }

            if (HCM < 31)
            {
                lblSalidaHCM.Text = "↓ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Yellow;
            }

            if (HCM <= porcentaje)
            {
                lblSalidaHCM.Text = "↓ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Red;
            }

            /***********************VCM*************************************/

            decimal porcentajeVCMBajo = Convert.ToDecimal(98 * 0.88);
            decimal porcentajeVCMAlto = Convert.ToDecimal(118 * 1.10);




            if (VCM >= 98m && VCM <= 118m)
            {
                lblSalidaVCM.Text = VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Black;
            }


            if (VCM > 118m && VCM < porcentajeVCMAlto)
            {
                lblSalidaVCM.Text = "↑ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Yellow;
            }


            if (VCM >= porcentajeVCMAlto)
            {
                lblSalidaVCM.Text = "↑ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Red;
            }



            if (VCM < 98m)
            {
                lblSalidaVCM.Text = "↓ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Yellow;
            }

            if (VCM <= porcentajeVCMBajo)
            {
                lblSalidaVCM.Text = "↓ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Red;
            }


            /***********************************VCM*************************************/



            /*********************************HTO**********************************************/

            decimal porcentajeHTOBajo = Convert.ToDecimal(42 * 0.80);
            decimal porcentajeHTOAlto = Convert.ToDecimal(60 * 1.20);




            if (HTO >= 42m && HTO <= 60m)
            {
                lblSalidaHTO.Text = HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Black;
            }


            if (HTO > 60m && HTO < porcentajeHTOAlto)
            {
                lblSalidaHTO.Text = "↑ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Yellow;
            }


            if (HTO >= porcentajeHTOAlto)
            {
                lblSalidaHTO.Text = "↑ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Red;
            }

            if (HTO < 42m)
            {
                lblSalidaHTO.Text = "↓ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Yellow;
            }

            if (HTO <= porcentajeHTOBajo)
            {
                lblSalidaHTO.Text = "↓ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Red;
            }

            /*********************************HTO**********************************************/



            /*********************************HB**********************************************/

            decimal porcentajeHBBajo = Convert.ToDecimal(13.5 * 0.80);
            decimal porcentajeHBAlto = Convert.ToDecimal(19.5 * 1.20);




            if (HB >= 13.5m && HB <= 19.5m)
            {
                lblSalidaHB.Text = HB.ToString();
                lblSalidaHB.ForeColor = Color.Black;
            }


            if (HB > 19.5m && HB < porcentajeHBAlto)
            {
                lblSalidaHB.Text = "↑ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Yellow;
            }


            if (HB >= porcentajeHBAlto)
            {
                lblSalidaHB.Text = "↑ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Red;
            }

            if (HB < 13.5m)
            {
                lblSalidaHB.Text = "↓ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Yellow;
            }

            if (HB <= porcentajeHBBajo)
            {
                lblSalidaHB.Text = "↓ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Red;
            }



            /*********************************HB**********************************************/



            /*********************************GBRBC**********************************************/

            decimal porcentajeGBRBCBajo = Convert.ToDecimal(3.9 * 0.80);
            decimal porcentajeGBRBCAlto = Convert.ToDecimal(5.6 * 1.25);




            if (GBRBC >= 3.9m && GBRBC <= 5.6m)
            {
                lblSalidaGBRBC.Text = GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Black;
            }


            if (GBRBC > 5.6m && GBRBC < porcentajeGBRBCAlto)
            {
                lblSalidaGBRBC.Text = "↑ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Yellow;
            }


            if (GBRBC >= porcentajeGBRBCAlto)
            {
                lblSalidaGBRBC.Text = "↑ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Red;
            }

            if (GBRBC < 3.9m)
            {
                lblSalidaGBRBC.Text = "↓ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Yellow;
            }

            if (GBRBC <= porcentajeGBRBCBajo)
            {
                lblSalidaGBRBC.Text = "↓ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Red;
            }

            /*********************************GBRBC**********************************************/



            /*********************************GBWB**********************************************/

            decimal porcentajeGBWBBajo = Convert.ToDecimal(9.0 * 0.45);
            decimal porcentajeGBWBCAlto = Convert.ToDecimal(30 * 1.30);




            if (GBWB >= 9m && GBWB <= 30.0m)
            {
                lblSalidaGBWB.Text = GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Black;
            }


            if (GBWB > 30.0m && GBWB < porcentajeGBWBCAlto)
            {
                lblSalidaGBWB.Text = "↑ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Yellow;
            }


            if (GBWB >= porcentajeGBWBCAlto)
            {
                lblSalidaGBWB.Text = "↑ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Red;
            }

            if (GBWB < 9m)
            {
                lblSalidaGBWB.Text = "↓ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Yellow;
            }

            if (GBWB <= porcentajeGBWBBajo)
            {
                lblSalidaGBWB.Text = "↓ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Red;
            }

            /*********************************GBWB**********************************************/
        }


        /*GRUPO ETARIO 1-3 DIAS*//*CORREGIDO*/
        private void alarmasGrupoEtario2()
        {
            decimal RDW = Convert.ToDecimal(txtRDW.Text, CultureInfo.InvariantCulture);
            decimal PLT = Convert.ToDecimal(txtPLT.Text, CultureInfo.InvariantCulture);
            decimal CHCM = Convert.ToDecimal(txtCHCM.Text, CultureInfo.InvariantCulture);
            decimal HCM = Convert.ToDecimal(txtHCM.Text, CultureInfo.InvariantCulture);
            decimal VCM = Convert.ToDecimal(txtVCM.Text, CultureInfo.InvariantCulture);
            decimal HTO = Convert.ToDecimal(txtHTO.Text, CultureInfo.InvariantCulture);
            decimal HB = Convert.ToDecimal(txtHB.Text, CultureInfo.InvariantCulture);
            decimal GBRBC = Convert.ToDecimal(txtGBRBC.Text, CultureInfo.InvariantCulture);
            decimal GBWB = Convert.ToDecimal(txtGBWB.Text, CultureInfo.InvariantCulture);


            /*******************************************************************/
            if (RDW > 15.0m && RDW <= 18.0m)
            {
                lblSalidaAlarmaRDW.Text = "↑ " + RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Yellow;
            }
            if (RDW > 18.0m)
            {
                lblSalidaAlarmaRDW.Text = "↑ " + RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Red;
            }
            if (RDW <= 15.0m)
            {
                lblSalidaAlarmaRDW.Text = RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Black;
            }
            /******************************************************************/

            /************************************************************************/
            if (PLT >= 150m && PLT <= 450m)
            {
                lblSalidaPLT.Text = PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Black;
            }

            if (PLT < 150m && PLT >= 100m)
            {
                lblSalidaPLT.Text = "↓ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Yellow;
            }

            if (PLT < 100m)
            {
                lblSalidaPLT.Text = "↓ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Red;
            }

            if (PLT >= 450m && PLT <= 600m)
            {
                lblSalidaPLT.Text = "↑ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Yellow;
            }

            if (PLT > 600m)
            {
                lblSalidaPLT.Text = "↑ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Red;
            }

            /************************************************************************************/

            /***************************************************************************************/

            if (CHCM >= 31m && CHCM <= 36m)
            {
                lblSalidaCHCM.Text = CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Black;
            }

            if (CHCM > 36m)
            {
                lblSalidaCHCM.Text = "↑ " + CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Red;
            }

            if (CHCM < 31m)
            {
                lblSalidaCHCM.Text = "↓ " + CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Yellow;
            }
            /**************************************************************************/

            /************************************************************************/
            //HCM
            decimal porcentaje = Convert.ToDecimal(31 * 0.8);



            if (HCM >= 31m && HCM <= 37m)
            {
                lblSalidaHCM.Text = HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Black;
            }


            if (HCM > 37m)
            {
                lblSalidaHCM.Text = "↑ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Yellow;
            }

            if (HCM < 31m)
            {
                lblSalidaHCM.Text = "↓ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Yellow;
            }

            if (HCM <= porcentaje)
            {
                lblSalidaHCM.Text = "↓ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Red;
            }

            /******************************************************************/



            /***********************VCM*************************************/

            decimal porcentajeVCMBajo = Convert.ToDecimal(95 * 0.88);
            decimal porcentajeVCMAlto = Convert.ToDecimal(121 * 1.10);




            if (VCM >= 95m && VCM <= 121m)
            {
                lblSalidaVCM.Text = VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Black;
            }


            if (VCM > 121m && VCM < porcentajeVCMAlto)
            {
                lblSalidaVCM.Text = "↑ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Yellow;
            }


            if (VCM >= porcentajeVCMAlto)
            {
                lblSalidaVCM.Text = "↑ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Red;
            }



            if (VCM < 95m)
            {
                lblSalidaVCM.Text = "↓ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Yellow;
            }

            if (VCM <= porcentajeVCMBajo)
            {
                lblSalidaVCM.Text = "↓ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Red;
            }


            /***********************************VCM*************************************/



            /*********************************HTO**********************************************/

            decimal porcentajeHTOBajo = Convert.ToDecimal(45 * 0.80);
            decimal porcentajeHTOAlto = Convert.ToDecimal(65 * 1.20);




            if (HTO >= 45m && HTO <= 65m)
            {
                lblSalidaHTO.Text = HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Black;
            }


            if (HTO > 65m && HTO < porcentajeHTOAlto)
            {
                lblSalidaHTO.Text = "↑ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Yellow;
            }


            if (HTO >= porcentajeHTOAlto)
            {
                lblSalidaHTO.Text = "↑ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Red;
            }

            if (HTO < 45m)
            {
                lblSalidaHTO.Text = "↓ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Yellow;
            }

            if (HTO <= porcentajeHTOBajo)
            {
                lblSalidaHTO.Text = "↓ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Red;
            }

            /*********************************HTO**********************************************/



            /*********************************HB**********************************************/

            decimal porcentajeHBBajo = Convert.ToDecimal(11.5 * 0.80);
            decimal porcentajeHBAlto = Convert.ToDecimal(22.5 * 1.20);




            if (HB >= 11.5m && HB <= 22.5m)
            {
                lblSalidaHB.Text = HB.ToString();
                lblSalidaHB.ForeColor = Color.Black;
            }


            if (HB > 22.5m && HB < porcentajeHBAlto)
            {
                lblSalidaHB.Text = "↑ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Yellow;
            }


            if (HB >= porcentajeHBAlto)
            {
                lblSalidaHB.Text = "↑ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Red;
            }

            if (HB < 11.5m)
            {
                lblSalidaHB.Text = "↓ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Yellow;
            }

            if (HB <= porcentajeHBBajo)
            {
                lblSalidaHB.Text = "↓ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Red;
            }



            /*********************************HB**********************************************/



            /*********************************GBRBC**********************************************/

            decimal porcentajeGBRBCBajo = Convert.ToDecimal(4.0 * 0.80);
            decimal porcentajeGBRBCAlto = Convert.ToDecimal(6.9 * 1.25);




            if (GBRBC >= 4.0m && GBRBC <= 6.9m)
            {
                lblSalidaGBRBC.Text = GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Black;
            }


            if (GBRBC > 6.9m && GBRBC < porcentajeGBRBCAlto)
            {
                lblSalidaGBRBC.Text = "↑ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Yellow;
            }


            if (GBRBC >= porcentajeGBRBCAlto)
            {
                lblSalidaGBRBC.Text = "↑ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Red;
            }

            if (GBRBC < 4.0m)
            {
                lblSalidaGBRBC.Text = "↓ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Yellow;
            }

            if (GBRBC <= porcentajeGBRBCBajo)
            {
                lblSalidaGBRBC.Text = "↓ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Red;
            }

            /*********************************GBRBC**********************************************/



            /*********************************GBWB**********************************************/

            decimal porcentajeGBWBBajo = Convert.ToDecimal(9.4 * 0.45);
            decimal porcentajeGBWBCAlto = Convert.ToDecimal(31 * 1.30);




            if (GBWB >= 9.4m && GBWB <= 31.0m)
            {
                lblSalidaGBWB.Text = GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Black;
            }


            if (GBWB > 31.0m && GBWB < porcentajeGBWBCAlto)
            {
                lblSalidaGBWB.Text = "↑ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Yellow;
            }


            if (GBWB >= porcentajeGBWBCAlto)
            {
                lblSalidaGBWB.Text = "↑ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Red;
            }

            if (GBWB < 9.4m)
            {
                lblSalidaGBWB.Text = "↓ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Yellow;
            }

            if (GBWB <= porcentajeGBWBBajo)
            {
                lblSalidaGBWB.Text = "↓ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Red;
            }

            /*********************************GBWB**********************************************/
        }


        /*GRUPO ETARIO 4-7 DIAS*//*CORREGIDO*/
        private void alarmasGrupoEtario3()
        {
            decimal RDW = Convert.ToDecimal(txtRDW.Text, CultureInfo.InvariantCulture);
            decimal PLT = Convert.ToDecimal(txtPLT.Text, CultureInfo.InvariantCulture);
            decimal CHCM = Convert.ToDecimal(txtCHCM.Text, CultureInfo.InvariantCulture);
            decimal HCM = Convert.ToDecimal(txtHCM.Text, CultureInfo.InvariantCulture);
            decimal VCM = Convert.ToDecimal(txtVCM.Text, CultureInfo.InvariantCulture);
            decimal HTO = Convert.ToDecimal(txtHTO.Text, CultureInfo.InvariantCulture);
            decimal HB = Convert.ToDecimal(txtHB.Text, CultureInfo.InvariantCulture);
            decimal GBRBC = Convert.ToDecimal(txtGBRBC.Text, CultureInfo.InvariantCulture);
            decimal GBWB = Convert.ToDecimal(txtGBWB.Text, CultureInfo.InvariantCulture);

            /*******************************************************************/
            if (RDW > 15.0m && RDW <= 18.0m)
            {
                lblSalidaAlarmaRDW.Text = "↑ " + RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Yellow;
            }
            if (RDW > 18.0m)
            {
                lblSalidaAlarmaRDW.Text = "↑ " + RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Red;
            }
            if (RDW <= 15.0m)
            {
                lblSalidaAlarmaRDW.Text = RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Black;
            }
            /******************************************************************/

            /************************************************************************/
            if (PLT >= 150m && PLT <= 450m)
            {
                lblSalidaPLT.Text = PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Black;
            }
            if (PLT < 150m && PLT >= 100m)
            {
                lblSalidaPLT.Text = "↓ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Yellow;
            }
            if (PLT < 100m)
            {
                lblSalidaPLT.Text = "↓ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Red;
            }

            if (PLT >= 450m && PLT <= 600m)
            {
                lblSalidaPLT.Text = "↑ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Yellow;
            }

            if (PLT > 600m)
            {
                lblSalidaPLT.Text = "↑ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Red;
            }

            /************************************************************************************/

            /***************************************************************************************/

            if (CHCM >= 31m && CHCM <= 36m)
            {
                lblSalidaCHCM.Text = CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Black;
            }

            if (CHCM > 36m)
            {
                lblSalidaCHCM.Text = "↑ " + CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Red;
            }

            if (CHCM < 31m)
            {
                lblSalidaCHCM.Text = "↓ " + CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Yellow;
            }
            /**************************************************************************/


            /************************************************************************/
            //HCM
            decimal porcentaje = Convert.ToDecimal(28 * 0.8);



            if (HCM >= 28m && HCM <= 40m)
            {
                lblSalidaHCM.Text = HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Black;
            }


            if (HCM > 40m)
            {
                lblSalidaHCM.Text = "↑ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Yellow;
            }

            if (HCM < 28m)
            {
                lblSalidaHCM.Text = "↓ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Yellow;
            }

            if (HCM <= porcentaje)
            {
                lblSalidaHCM.Text = "↓ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Red;
            }

            /******************************************************************/



            /***********************VCM*************************************/

            decimal porcentajeVCMBajo = (88m * 0.88m);
            decimal porcentajeVCMAlto = (126m * 1.10m);




            if (VCM >= 88m && VCM <= 126m)
            {
                lblSalidaVCM.Text = VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Black;
            }


            if (VCM > 126m && VCM < porcentajeVCMAlto)
            {
                lblSalidaVCM.Text = "↑ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Yellow;
            }


            if (VCM >= porcentajeVCMAlto)
            {
                lblSalidaVCM.Text = "↑ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Red;
            }



            if (VCM < 88m)
            {
                lblSalidaVCM.Text = "↓ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Yellow;
            }

            if (VCM <= porcentajeVCMBajo)
            {
                lblSalidaVCM.Text = "↓ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Red;
            }


            /***********************************VCM*************************************/



            /*********************************HTO**********************************************/

            decimal porcentajeHTOBajo = (42m * 0.80m);
            decimal porcentajeHTOAlto = (60m * 1.20m);




            if (HTO >= 42m && HTO <= 60m)
            {
                lblSalidaHTO.Text = HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Black;
            }


            if (HTO > 60m && HTO < porcentajeHTOAlto)
            {
                lblSalidaHTO.Text = "↑ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Yellow;
            }


            if (HTO >= porcentajeHTOAlto)
            {
                lblSalidaHTO.Text = "↑ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Red;
            }

            if (HTO < 42m)
            {
                lblSalidaHTO.Text = "↓ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Yellow;
            }

            if (HTO <= porcentajeHTOBajo)
            {
                lblSalidaHTO.Text = "↓ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Red;
            }

            /*********************************HTO**********************************************/



            /*********************************HB**********************************************/

            decimal porcentajeHBBajo = (13.5m * 0.80m);
            decimal porcentajeHBAlto = (22.5m * 1.20m);




            if (HB >= 13.5m && HB <= 22.5m)
            {
                lblSalidaHB.Text = HB.ToString();
                lblSalidaHB.ForeColor = Color.Black;
            }


            if (HB > 22.5m && HB < porcentajeHBAlto)
            {
                lblSalidaHB.Text = "↑ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Yellow;
            }


            if (HB >= porcentajeHBAlto)
            {
                lblSalidaHB.Text = "↑ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Red;
            }

            if (HB < 13.5m)
            {
                lblSalidaHB.Text = "↓ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Yellow;
            }

            if (HB <= porcentajeHBBajo)
            {
                lblSalidaHB.Text = "↓ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Red;
            }



            /*********************************HB**********************************************/



            /*********************************GBRBC**********************************************/

            decimal porcentajeGBRBCBajo = (3.9m * 0.80m);
            decimal porcentajeGBRBCAlto = (6.3m * 1.25m);




            if (GBRBC >= 3.9m && GBRBC <= 6.3m)
            {
                lblSalidaGBRBC.Text = GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Black;
            }


            if (GBRBC > 6.3m && GBRBC < porcentajeGBRBCAlto)
            {
                lblSalidaGBRBC.Text = "↑ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Yellow;
            }


            if (GBRBC >= porcentajeGBRBCAlto)
            {
                lblSalidaGBRBC.Text = "↑ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Red;
            }

            if (GBRBC < 3.9m)
            {
                lblSalidaGBRBC.Text = "↓ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Yellow;
            }

            if (GBRBC <= porcentajeGBRBCBajo)
            {
                lblSalidaGBRBC.Text = "↓ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Red;
            }

            /*********************************GBRBC**********************************************/



            /*********************************GBWB**********************************************/

            decimal porcentajeGBWBBajo = (9.4m * 0.45m);
            decimal porcentajeGBWBCAlto = (31m * 1.30m);




            if (GBWB >= 9.4m && GBWB <= 31.0m)
            {
                lblSalidaGBWB.Text = GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Black;
            }


            if (GBWB > 31.0m && GBWB < porcentajeGBWBCAlto)
            {
                lblSalidaGBWB.Text = "↑ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Yellow;
            }


            if (GBWB >= porcentajeGBWBCAlto)
            {
                lblSalidaGBWB.Text = "↑ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Red;
            }

            if (GBWB < 9.4m)
            {
                lblSalidaGBWB.Text = "↓ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Yellow;
            }

            if (GBWB <= porcentajeGBWBBajo)
            {
                lblSalidaGBWB.Text = "↓ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Red;
            }

            /*********************************GBWB**********************************************/
        }


        /*GRUPO ETARIO 8-15 DIAS*//*CORREGIDO*/
        private void alarmasGrupoEtario4()
        {
            decimal RDW = Convert.ToDecimal(txtRDW.Text, CultureInfo.InvariantCulture);
            decimal PLT = Convert.ToDecimal(txtPLT.Text, CultureInfo.InvariantCulture);
            decimal CHCM = Convert.ToDecimal(txtCHCM.Text, CultureInfo.InvariantCulture);
            decimal HCM = Convert.ToDecimal(txtHCM.Text, CultureInfo.InvariantCulture);
            decimal VCM = Convert.ToDecimal(txtVCM.Text, CultureInfo.InvariantCulture);
            decimal HTO = Convert.ToDecimal(txtHTO.Text, CultureInfo.InvariantCulture);
            decimal HB = Convert.ToDecimal(txtHB.Text, CultureInfo.InvariantCulture);
            decimal GBRBC = Convert.ToDecimal(txtGBRBC.Text, CultureInfo.InvariantCulture);
            decimal GBWB = Convert.ToDecimal(txtGBWB.Text, CultureInfo.InvariantCulture);

            /*******************************************************************/
            if (RDW > 15.0m && RDW <= 18.0m)
            {
                lblSalidaAlarmaRDW.Text = "↑ " + RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Yellow;
            }
            if (RDW > 18.0m)
            {
                lblSalidaAlarmaRDW.Text = "↑ " + RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Red;
            }
            if (RDW <= 15.0m)
            {
                lblSalidaAlarmaRDW.Text = RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Black;
            }
            /******************************************************************/

            /************************************************************************/
            if (PLT >= 150m && PLT <= 450m)
            {
                lblSalidaPLT.Text = PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Black;
            }
            if (PLT < 150m && PLT >= 100m)
            {
                lblSalidaPLT.Text = "↓ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Yellow;
            }
            if (PLT < 100m)
            {
                lblSalidaPLT.Text = "↓ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Red;
            }

            if (PLT >= 450m && PLT <= 600m)
            {
                lblSalidaPLT.Text = "↑ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Yellow;
            }

            if (PLT > 600m)
            {
                lblSalidaPLT.Text = "↑ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Red;
            }

            /************************************************************************************/

            /***************************************************************************************/

            if (CHCM >= 31m && CHCM <= 36m)
            {
                lblSalidaCHCM.Text = CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Black;
            }

            if (CHCM > 36m)
            {
                lblSalidaCHCM.Text = "↑ " + CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Red;
            }

            if (CHCM < 31m)
            {
                lblSalidaCHCM.Text = "↓ " + CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Yellow;
            }
            /**************************************************************************/


            /************************************************************************/
            //HCM
            decimal porcentaje = (28m * 0.8m);



            if (HCM >= 28m && HCM <= 40m)
            {
                lblSalidaHCM.Text = HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Black;
            }


            if (HCM > 40m)
            {
                lblSalidaHCM.Text = "↑ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Yellow;
            }

            if (HCM < 28m)
            {
                lblSalidaHCM.Text = "↓ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Yellow;
            }

            if (HCM <= porcentaje)
            {
                lblSalidaHCM.Text = "↓ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Red;
            }

            /******************************************************************/



            /***********************VCM*************************************/

            decimal porcentajeVCMBajo = (86m * 0.88m);
            decimal porcentajeVCMAlto = (124m * 1.10m);




            if (VCM >= 86m && VCM <= 124m)
            {
                lblSalidaVCM.Text = VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Black;
            }


            if (VCM > 124m && VCM < porcentajeVCMAlto)
            {
                lblSalidaVCM.Text = "↑ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Yellow;
            }


            if (VCM >= porcentajeVCMAlto)
            {
                lblSalidaVCM.Text = "↑ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Red;
            }



            if (VCM < 86m)
            {
                lblSalidaVCM.Text = "↓ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Yellow;
            }

            if (VCM <= porcentajeVCMBajo)
            {
                lblSalidaVCM.Text = "↓ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Red;
            }


            /***********************************VCM*************************************/



            /*********************************HTO**********************************************/

            decimal porcentajeHTOBajo = (39m * 0.80m);
            decimal porcentajeHTOAlto = (63m * 1.20m);




            if (HTO >= 39m && HTO <= 63m)
            {
                lblSalidaHTO.Text = HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Black;
            }


            if (HTO > 63m && HTO < porcentajeHTOAlto)
            {
                lblSalidaHTO.Text = "↑ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Yellow;
            }


            if (HTO >= porcentajeHTOAlto)
            {
                lblSalidaHTO.Text = "↑ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Red;
            }

            if (HTO < 39m)
            {
                lblSalidaHTO.Text = "↓ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Yellow;
            }

            if (HTO <= porcentajeHTOBajo)
            {
                lblSalidaHTO.Text = "↓ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Red;
            }

            /*********************************HTO**********************************************/



            /*********************************HB**********************************************/

            decimal porcentajeHBBajo = (12.5m * 0.80m);
            decimal porcentajeHBAlto = (20.5m * 1.20m);




            if (HB >= 12.5m && HB <= 20.5m)
            {
                lblSalidaHB.Text = HB.ToString();
                lblSalidaHB.ForeColor = Color.Black;
            }


            if (HB > 20.5m && HB < porcentajeHBAlto)
            {
                lblSalidaHB.Text = "↑ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Yellow;
            }


            if (HB >= porcentajeHBAlto)
            {
                lblSalidaHB.Text = "↑ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Red;
            }

            if (HB < 12.5m)
            {
                lblSalidaHB.Text = "↓ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Yellow;
            }

            if (HB <= porcentajeHBBajo)
            {
                lblSalidaHB.Text = "↓ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Red;
            }



            /*********************************HB**********************************************/



            /*********************************GBRBC**********************************************/

            decimal porcentajeGBRBCBajo = (3.6m * 0.80m);
            decimal porcentajeGBRBCAlto = (5.2m * 1.25m);




            if (GBRBC >= 3.6m && GBRBC <= 5.2m)
            {
                lblSalidaGBRBC.Text = GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Black;
            }


            if (GBRBC > 5.2m && GBRBC < porcentajeGBRBCAlto)
            {
                lblSalidaGBRBC.Text = "↑ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Yellow;
            }


            if (GBRBC >= porcentajeGBRBCAlto)
            {
                lblSalidaGBRBC.Text = "↑ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Red;
            }

            if (GBRBC < 3.6m)
            {
                lblSalidaGBRBC.Text = "↓ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Yellow;
            }

            if (GBRBC <= porcentajeGBRBCBajo)
            {
                lblSalidaGBRBC.Text = "↓ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Red;
            }

            /*********************************GBRBC**********************************************/



            /*********************************GBWB**********************************************/

            decimal porcentajeGBWBBajo = (5.0m * 0.45m);
            decimal porcentajeGBWBCAlto = (21.0m * 1.30m);




            if (GBWB >= 5.0m && GBWB <= 21.0m)
            {
                lblSalidaGBWB.Text = GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Black;
            }


            if (GBWB > 21.0m && GBWB < porcentajeGBWBCAlto)
            {
                lblSalidaGBWB.Text = "↑ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Yellow;
            }


            if (GBWB >= porcentajeGBWBCAlto)
            {
                lblSalidaGBWB.Text = "↑ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Red;
            }

            if (GBWB < 5.0m)
            {
                lblSalidaGBWB.Text = "↓ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Yellow;
            }

            if (GBWB <= porcentajeGBWBBajo)
            {
                lblSalidaGBWB.Text = "↓ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Red;
            }

            /*********************************GBWB**********************************************/
        }


        /*GRUPO ETARIO 16-30 DIAS*//*CORREGIDO*/
        private void alarmasGrupoEtario5()
        {
            decimal RDW = Convert.ToDecimal(txtRDW.Text, CultureInfo.InvariantCulture);
            decimal PLT = Convert.ToDecimal(txtPLT.Text, CultureInfo.InvariantCulture);
            decimal CHCM = Convert.ToDecimal(txtCHCM.Text, CultureInfo.InvariantCulture);
            decimal HCM = Convert.ToDecimal(txtHCM.Text, CultureInfo.InvariantCulture);
            decimal VCM = Convert.ToDecimal(txtVCM.Text, CultureInfo.InvariantCulture);
            decimal HTO = Convert.ToDecimal(txtHTO.Text, CultureInfo.InvariantCulture);
            decimal HB = Convert.ToDecimal(txtHB.Text, CultureInfo.InvariantCulture);
            decimal GBRBC = Convert.ToDecimal(txtGBRBC.Text, CultureInfo.InvariantCulture);
            decimal GBWB = Convert.ToDecimal(txtGBWB.Text, CultureInfo.InvariantCulture);

            /*******************************************************************/
            if (RDW > 15.0m && RDW <= 18.0m)
            {
                lblSalidaAlarmaRDW.Text = "↑ " + RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Yellow;
            }
            if (RDW > 18.0m)
            {
                lblSalidaAlarmaRDW.Text = "↑ " + RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Red;
            }
            if (RDW <= 15.0m)
            {
                lblSalidaAlarmaRDW.Text = RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Black;
            }
            /******************************************************************/

            /************************************************************************/
            if (PLT >= 150m && PLT <= 450m)
            {
                lblSalidaPLT.Text = PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Black;
            }
            if (PLT < 150m && PLT >= 100m)
            {
                lblSalidaPLT.Text = "↓ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Yellow;
            }
            if (PLT < 100m)
            {
                lblSalidaPLT.Text = "↓ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Red;
            }

            if (PLT >= 450m && PLT <= 600m)
            {
                lblSalidaPLT.Text = "↑ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Yellow;
            }

            if (PLT > 600m)
            {
                lblSalidaPLT.Text = "↑ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Red;
            }

            /************************************************************************************/

            /***************************************************************************************/

            if (CHCM >= 31m && CHCM <= 36m)
            {
                lblSalidaCHCM.Text = CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Black;
            }

            if (CHCM > 36m)
            {
                lblSalidaCHCM.Text = "↑ " + CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Red;
            }

            if (CHCM < 31m)
            {
                lblSalidaCHCM.Text = "↓ " + CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Yellow;
            }
            /**************************************************************************/


            /************************************************************************/
            //HCM
            decimal porcentaje = (28m * 0.8m);



            if (HCM >= 28m && HCM <= 40m)
            {
                lblSalidaHCM.Text = HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Black;
            }


            if (HCM > 40m)
            {
                lblSalidaHCM.Text = "↑ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Yellow;
            }

            if (HCM < 28m)
            {
                lblSalidaHCM.Text = "↓ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Yellow;
            }

            if (HCM <= porcentaje)
            {
                lblSalidaHCM.Text = "↓ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Red;
            }

            /******************************************************************/



            /***********************VCM*************************************/

            decimal porcentajeVCMBajo = (85m * 0.88m);
            decimal porcentajeVCMAlto = (117m * 1.10m);




            if (VCM >= 85m && VCM <= 117m)
            {
                lblSalidaVCM.Text = VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Black;
            }


            if (VCM > 117m && VCM < porcentajeVCMAlto)
            {
                lblSalidaVCM.Text = "↑ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Yellow;
            }


            if (VCM >= porcentajeVCMAlto)
            {
                lblSalidaVCM.Text = "↑ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Red;
            }



            if (VCM < 85m)
            {
                lblSalidaVCM.Text = "↓ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Yellow;
            }

            if (VCM <= porcentajeVCMBajo)
            {
                lblSalidaVCM.Text = "↓ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Red;
            }


            /***********************************VCM*************************************/



            /*********************************HTO**********************************************/

            decimal porcentajeHTOBajo = (31m * 0.80m);
            decimal porcentajeHTOAlto = (55m * 1.20m);




            if (HTO >= 31m && HTO <= 55m)
            {
                lblSalidaHTO.Text = HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Black;
            }


            if (HTO > 55m && HTO < porcentajeHTOAlto)
            {
                lblSalidaHTO.Text = "↑ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Yellow;
            }


            if (HTO >= porcentajeHTOAlto)
            {
                lblSalidaHTO.Text = "↑ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Red;
            }

            if (HTO < 31m)
            {
                lblSalidaHTO.Text = "↓ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Yellow;
            }

            if (HTO <= porcentajeHTOBajo)
            {
                lblSalidaHTO.Text = "↓ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Red;
            }

            /*********************************HTO**********************************************/



            /*********************************HB**********************************************/

            decimal porcentajeHBBajo = (10.0m * 0.80m);
            decimal porcentajeHBAlto = (18m * 1.20m);




            if (HB >= 10.0m && HB <= 18m)
            {
                lblSalidaHB.Text = HB.ToString();
                lblSalidaHB.ForeColor = Color.Black;
            }


            if (HB > 18m && HB < porcentajeHBAlto)
            {
                lblSalidaHB.Text = "↑ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Yellow;
            }


            if (HB >= porcentajeHBAlto)
            {
                lblSalidaHB.Text = "↑ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Red;
            }

            if (HB < 10.0m)
            {
                lblSalidaHB.Text = "↓ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Yellow;
            }

            if (HB <= porcentajeHBBajo)
            {
                lblSalidaHB.Text = "↓ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Red;
            }



            /*********************************HB**********************************************/



            /*********************************GBRBC**********************************************/

            decimal porcentajeGBRBCBajo = (3.0m * 0.80m);
            decimal porcentajeGBRBCAlto = (5.4m * 1.25m);




            if (GBRBC >= 3.0m && GBRBC <= 5.4m)
            {
                lblSalidaGBRBC.Text = GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Black;
            }


            if (GBRBC > 5.4m && GBRBC < porcentajeGBRBCAlto)
            {
                lblSalidaGBRBC.Text = "↑ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Yellow;
            }


            if (GBRBC >= porcentajeGBRBCAlto)
            {
                lblSalidaGBRBC.Text = "↑ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Red;
            }

            if (GBRBC < 3.0m)
            {
                lblSalidaGBRBC.Text = "↓ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Yellow;
            }

            if (GBRBC <= porcentajeGBRBCBajo)
            {
                lblSalidaGBRBC.Text = "↓ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Red;
            }

            /*********************************GBRBC**********************************************/



            /*********************************GBWB**********************************************/

            decimal porcentajeGBWBBajo = (5.0m * 0.45m);
            decimal porcentajeGBWBCAlto = (20.0m * 1.30m);




            if (GBWB >= 5.0m && GBWB <= 20.0m)
            {
                lblSalidaGBWB.Text = GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Black;
            }


            if (GBWB > 20.0m && GBWB < porcentajeGBWBCAlto)
            {
                lblSalidaGBWB.Text = "↑ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Yellow;
            }


            if (GBWB >= porcentajeGBWBCAlto)
            {
                lblSalidaGBWB.Text = "↑ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Red;
            }

            if (GBWB < 5.0m)
            {
                lblSalidaGBWB.Text = "↓ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Yellow;
            }

            if (GBWB <= porcentajeGBWBBajo)
            {
                lblSalidaGBWB.Text = "↓ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Red;
            }

            /*********************************GBWB**********************************************/
        }


        /*GRUPO ETARIO 1-2 MESES*//*CORREGIDO*/
        private void alarmasGrupoEtario6()
        {
            decimal RDW = Convert.ToDecimal(txtRDW.Text, CultureInfo.InvariantCulture);
            decimal PLT = Convert.ToDecimal(txtPLT.Text, CultureInfo.InvariantCulture);
            decimal CHCM = Convert.ToDecimal(txtCHCM.Text, CultureInfo.InvariantCulture);
            decimal HCM = Convert.ToDecimal(txtHCM.Text, CultureInfo.InvariantCulture);
            decimal VCM = Convert.ToDecimal(txtVCM.Text, CultureInfo.InvariantCulture);
            decimal HTO = Convert.ToDecimal(txtHTO.Text, CultureInfo.InvariantCulture);
            decimal HB = Convert.ToDecimal(txtHB.Text, CultureInfo.InvariantCulture);
            decimal GBRBC = Convert.ToDecimal(txtGBRBC.Text, CultureInfo.InvariantCulture);
            decimal GBWB = Convert.ToDecimal(txtGBWB.Text, CultureInfo.InvariantCulture);

            /*******************************************************************/
            if (RDW > 15.0m && RDW <= 18.0m)
            {
                lblSalidaAlarmaRDW.Text = "↑ " + RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Yellow;
            }
            if (RDW > 18.0m)
            {
                lblSalidaAlarmaRDW.Text = "↑ " + RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Red;
            }
            if (RDW <= 15.0m)
            {
                lblSalidaAlarmaRDW.Text = RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Black;
            }
            /******************************************************************/

            /************************************************************************/
            if (PLT >= 150m && PLT <= 450m)
            {
                lblSalidaPLT.Text = PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Black;
            }
            if (PLT < 150m && PLT >= 100m)
            {
                lblSalidaPLT.Text = "↓ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Yellow;
            }
            if (PLT < 100m)
            {
                lblSalidaPLT.Text = "↓ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Red;
            }

            if (PLT >= 450m && PLT <= 600m)
            {
                lblSalidaPLT.Text = "↑ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Yellow;
            }

            if (PLT > 600m)
            {
                lblSalidaPLT.Text = "↑ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Red;
            }

            /************************************************************************************/

            /***************************************************************************************/

            if (CHCM >= 31m && CHCM <= 36m)
            {
                lblSalidaCHCM.Text = CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Black;
            }

            if (CHCM > 36m)
            {
                lblSalidaCHCM.Text = "↑ " + CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Red;
            }

            if (CHCM < 31m)
            {
                lblSalidaCHCM.Text = "↓ " + CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Yellow;
            }
            /**************************************************************************/


            /************************************************************************/
            //HCM
            decimal porcentaje = (26m * 0.8m);



            if (HCM >= 26m && HCM <= 34m)
            {
                lblSalidaHCM.Text = HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Black;
            }


            if (HCM > 34m)
            {
                lblSalidaHCM.Text = "↑ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Yellow;
            }

            if (HCM < 26m)
            {
                lblSalidaHCM.Text = "↓ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Yellow;
            }

            if (HCM <= porcentaje)
            {
                lblSalidaHCM.Text = "↓ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Red;
            }

            /******************************************************************/



            /***********************VCM*************************************/

            decimal porcentajeVCMBajo = (77m * 0.88m);
            decimal porcentajeVCMAlto = (115m * 1.10m);




            if (VCM >= 77m && VCM <= 115m)
            {
                lblSalidaVCM.Text = VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Black;
            }


            if (VCM > 115m && VCM < porcentajeVCMAlto)
            {
                lblSalidaVCM.Text = "↑ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Yellow;
            }


            if (VCM >= porcentajeVCMAlto)
            {
                lblSalidaVCM.Text = "↑ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Red;
            }



            if (VCM < 77m)
            {
                lblSalidaVCM.Text = "↓ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Yellow;
            }

            if (VCM <= porcentajeVCMBajo)
            {
                lblSalidaVCM.Text = "↓ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Red;
            }


            /***********************************VCM*************************************/



            /*********************************HTO**********************************************/

            decimal porcentajeHTOBajo = (28m * 0.80m);
            decimal porcentajeHTOAlto = (42m * 1.20m);




            if (HTO >= 28m && HTO <= 42m)
            {
                lblSalidaHTO.Text = HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Black;
            }


            if (HTO > 42m && HTO < porcentajeHTOAlto)
            {
                lblSalidaHTO.Text = "↑ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Yellow;
            }


            if (HTO >= porcentajeHTOAlto)
            {
                lblSalidaHTO.Text = "↑ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Red;
            }

            if (HTO < 28m)
            {
                lblSalidaHTO.Text = "↓ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Yellow;
            }

            if (HTO <= porcentajeHTOBajo)
            {
                lblSalidaHTO.Text = "↓ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Red;
            }

            /*********************************HTO**********************************************/



            /*********************************HB**********************************************/

            decimal porcentajeHBBajo = (9.0m * 0.80m);
            decimal porcentajeHBAlto = (14.0m * 1.20m);




            if (HB >= 9.0m && HB <= 14.0m)
            {
                lblSalidaHB.Text = HB.ToString();
                lblSalidaHB.ForeColor = Color.Black;
            }


            if (HB > 14.0m && HB < porcentajeHBAlto)
            {
                lblSalidaHB.Text = "↑ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Yellow;
            }


            if (HB >= porcentajeHBAlto)
            {
                lblSalidaHB.Text = "↑ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Red;
            }

            if (HB < 9.0m)
            {
                lblSalidaHB.Text = "↓ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Yellow;
            }

            if (HB <= porcentajeHBBajo)
            {
                lblSalidaHB.Text = "↓ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Red;
            }



            /*********************************HB**********************************************/



            /*********************************GBRBC**********************************************/

            decimal porcentajeGBRBCBajo = (2.7m * 0.80m);
            decimal porcentajeGBRBCAlto = (4.9m * 1.25m);




            if (GBRBC >= 2.7m && GBRBC <= 4.9m)
            {
                lblSalidaGBRBC.Text = GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Black;
            }


            if (GBRBC > 4.9m && GBRBC < porcentajeGBRBCAlto)
            {
                lblSalidaGBRBC.Text = "↑ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Yellow;
            }


            if (GBRBC >= porcentajeGBRBCAlto)
            {
                lblSalidaGBRBC.Text = "↑ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Red;
            }

            if (GBRBC < 2.7m)
            {
                lblSalidaGBRBC.Text = "↓ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Yellow;
            }

            if (GBRBC <= porcentajeGBRBCBajo)
            {
                lblSalidaGBRBC.Text = "↓ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Red;
            }

            /*********************************GBRBC**********************************************/



            /*********************************GBWB**********************************************/

            decimal porcentajeGBWBBajo = (5.0m * 0.45m);
            decimal porcentajeGBWBCAlto = (19.5m * 1.30m);




            if (GBWB >= 5.0m && GBWB <= 19.5m)
            {
                lblSalidaGBWB.Text = GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Black;
            }


            if (GBWB > 19.5m && GBWB < porcentajeGBWBCAlto)
            {
                lblSalidaGBWB.Text = "↑ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Yellow;
            }


            if (GBWB >= porcentajeGBWBCAlto)
            {
                lblSalidaGBWB.Text = "↑ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Red;
            }

            if (GBWB < 5.0m)
            {
                lblSalidaGBWB.Text = "↓ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Yellow;
            }

            if (GBWB <= porcentajeGBWBBajo)
            {
                lblSalidaGBWB.Text = "↓ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Red;
            }

            /*********************************GBWB**********************************************/
        }


        /*GRUPO ETARIO 3-6 MESES*//*CORREGIDO*/
        private void alarmasGrupoEtario7()
        {
            decimal RDW = Convert.ToDecimal(txtRDW.Text, CultureInfo.InvariantCulture);
            decimal PLT = Convert.ToDecimal(txtPLT.Text, CultureInfo.InvariantCulture);
            decimal CHCM = Convert.ToDecimal(txtCHCM.Text, CultureInfo.InvariantCulture);
            decimal HCM = Convert.ToDecimal(txtHCM.Text, CultureInfo.InvariantCulture);
            decimal VCM = Convert.ToDecimal(txtVCM.Text, CultureInfo.InvariantCulture);
            decimal HTO = Convert.ToDecimal(txtHTO.Text, CultureInfo.InvariantCulture);
            decimal HB = Convert.ToDecimal(txtHB.Text, CultureInfo.InvariantCulture);
            decimal GBRBC = Convert.ToDecimal(txtGBRBC.Text, CultureInfo.InvariantCulture);
            decimal GBWB = Convert.ToDecimal(txtGBWB.Text, CultureInfo.InvariantCulture);

            /*******************************************************************/
            if (RDW > 15.0m && RDW <= 18.0m)
            {
                lblSalidaAlarmaRDW.Text = "↑ " + RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Yellow;
            }
            if (RDW > 18.0m)
            {
                lblSalidaAlarmaRDW.Text = "↑ " + RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Red;
            }
            if (RDW <= 15.0m)
            {
                lblSalidaAlarmaRDW.Text = RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Black;
            }
            /******************************************************************/

            /************************************************************************/
            if (PLT >= 150m && PLT <= 450m)
            {
                lblSalidaPLT.Text = PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Black;
            }
            if (PLT < 150m && PLT >= 100m)
            {
                lblSalidaPLT.Text = "↓ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Yellow;
            }
            if (PLT < 100m)
            {
                lblSalidaPLT.Text = "↓ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Red;
            }

            if (PLT >= 450m && PLT <= 600m)
            {
                lblSalidaPLT.Text = "↑ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Yellow;
            }

            if (PLT > 600m)
            {
                lblSalidaPLT.Text = "↑ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Red;
            }

            /************************************************************************************/

            /***************************************************************************************/

            if (CHCM >= 31m && CHCM <= 36m)
            {
                lblSalidaCHCM.Text = CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Black;
            }

            if (CHCM > 36m)
            {
                lblSalidaCHCM.Text = "↑ " + CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Red;
            }

            if (CHCM < 31m)
            {
                lblSalidaCHCM.Text = "↓ " + CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Yellow;
            }
            /**************************************************************************/


            /************************************************************************/
            //HCM
            decimal porcentaje = (25m * 0.8m);



            if (HCM >= 25m && HCM <= 35m)
            {
                lblSalidaHCM.Text = HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Black;
            }


            if (HCM > 35m)
            {
                lblSalidaHCM.Text = "↑ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Yellow;
            }

            if (HCM < 25m)
            {
                lblSalidaHCM.Text = "↓ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Yellow;
            }

            if (HCM <= porcentaje)
            {
                lblSalidaHCM.Text = "↓ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Red;
            }

            /******************************************************************/



            /***********************VCM*************************************/

            decimal porcentajeVCMBajo = (71m * 0.88m);
            decimal porcentajeVCMAlto = (114m * 1.10m);




            if (VCM >= 71m && VCM <= 114m)
            {
                lblSalidaVCM.Text = VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Black;
            }


            if (VCM > 114m && VCM < porcentajeVCMAlto)
            {
                lblSalidaVCM.Text = "↑ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Yellow;
            }


            if (VCM >= porcentajeVCMAlto)
            {
                lblSalidaVCM.Text = "↑ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Red;
            }



            if (VCM < 71m)
            {
                lblSalidaVCM.Text = "↓ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Yellow;
            }

            if (VCM <= porcentajeVCMBajo)
            {
                lblSalidaVCM.Text = "↓ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Red;
            }


            /***********************************VCM*************************************/



            /*********************************HTO**********************************************/

            decimal porcentajeHTOBajo = (29m * 0.80m);
            decimal porcentajeHTOAlto = (41m * 1.20m);




            if (HTO >= 29m && HTO <= 41m)
            {
                lblSalidaHTO.Text = HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Black;
            }


            if (HTO > 41m && HTO < porcentajeHTOAlto)
            {
                lblSalidaHTO.Text = "↑ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Yellow;
            }


            if (HTO >= porcentajeHTOAlto)
            {
                lblSalidaHTO.Text = "↑ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Red;
            }

            if (HTO < 29m)
            {
                lblSalidaHTO.Text = "↓ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Yellow;
            }

            if (HTO <= porcentajeHTOBajo)
            {
                lblSalidaHTO.Text = "↓ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Red;
            }

            /*********************************HTO**********************************************/



            /*********************************HB**********************************************/

            decimal porcentajeHBBajo = (9.5m * 0.80m);
            decimal porcentajeHBAlto = (13.5m * 1.20m);




            if (HB >= 9.5m && HB <= 13.5m)
            {
                lblSalidaHB.Text = HB.ToString();
                lblSalidaHB.ForeColor = Color.Black;
            }


            if (HB > 13.5m && HB < porcentajeHBAlto)
            {
                lblSalidaHB.Text = "↑ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Yellow;
            }


            if (HB >= porcentajeHBAlto)
            {
                lblSalidaHB.Text = "↑ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Red;
            }

            if (HB < 9.5m)
            {
                lblSalidaHB.Text = "↓ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Yellow;
            }

            if (HB <= porcentajeHBBajo)
            {
                lblSalidaHB.Text = "↓ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Red;
            }



            /*********************************HB**********************************************/



            /*********************************GBRBC**********************************************/

            decimal porcentajeGBRBCBajo = (3.1m * 0.80m);
            decimal porcentajeGBRBCAlto = (4.5m * 1.25m);




            if (GBRBC >= 3.1m && GBRBC <= 4.5m)
            {
                lblSalidaGBRBC.Text = GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Black;
            }


            if (GBRBC > 4.5m && GBRBC < porcentajeGBRBCAlto)
            {
                lblSalidaGBRBC.Text = "↑ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Yellow;
            }


            if (GBRBC >= porcentajeGBRBCAlto)
            {
                lblSalidaGBRBC.Text = "↑ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Red;
            }

            if (GBRBC < 3.1m)
            {
                lblSalidaGBRBC.Text = "↓ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Yellow;
            }

            if (GBRBC <= porcentajeGBRBCBajo)
            {
                lblSalidaGBRBC.Text = "↓ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Red;
            }

            /*********************************GBRBC**********************************************/



            /*********************************GBWB**********************************************/

            decimal porcentajeGBWBBajo = (5.0m * 0.45m);
            decimal porcentajeGBWBCAlto = (19.5m * 1.30m);




            if (GBWB >= 5.0m && GBWB <= 19.5m)
            {
                lblSalidaGBWB.Text = GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Black;
            }


            if (GBWB > 19.5m && GBWB < porcentajeGBWBCAlto)
            {
                lblSalidaGBWB.Text = "↑ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Yellow;
            }


            if (GBWB >= porcentajeGBWBCAlto)
            {
                lblSalidaGBWB.Text = "↑ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Red;
            }

            if (GBWB < 5.0m)
            {
                lblSalidaGBWB.Text = "↓ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Yellow;
            }

            if (GBWB <= porcentajeGBWBBajo)
            {
                lblSalidaGBWB.Text = "↓ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Red;
            }

            /*********************************GBWB**********************************************/
        }


        /*GRUPO ETARIO 7-12 MESES*//*CORREGIDO*/
        private void alarmasGrupoEtario8()
        {
            decimal RDW = Convert.ToDecimal(txtRDW.Text, CultureInfo.InvariantCulture);
            decimal PLT = Convert.ToDecimal(txtPLT.Text, CultureInfo.InvariantCulture);
            decimal CHCM = Convert.ToDecimal(txtCHCM.Text, CultureInfo.InvariantCulture);
            decimal HCM = Convert.ToDecimal(txtHCM.Text, CultureInfo.InvariantCulture);
            decimal VCM = Convert.ToDecimal(txtVCM.Text, CultureInfo.InvariantCulture);
            decimal HTO = Convert.ToDecimal(txtHTO.Text, CultureInfo.InvariantCulture);
            decimal HB = Convert.ToDecimal(txtHB.Text, CultureInfo.InvariantCulture);
            decimal GBRBC = Convert.ToDecimal(txtGBRBC.Text, CultureInfo.InvariantCulture);
            decimal GBWB = Convert.ToDecimal(txtGBWB.Text, CultureInfo.InvariantCulture);

            /*******************************************************************/
            if (RDW > 15.0m && RDW <= 18.0m)
            {
                lblSalidaAlarmaRDW.Text = "↑ " + RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Yellow;
            }
            if (RDW > 18.0m)
            {
                lblSalidaAlarmaRDW.Text = "↑ " + RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Red;
            }
            if (RDW <= 15.0m)
            {
                lblSalidaAlarmaRDW.Text = RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Black;
            }
            /******************************************************************/

            /************************************************************************/
            if (PLT >= 150m && PLT <= 450m)
            {
                lblSalidaPLT.Text = PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Black;
            }
            if (PLT < 150m && PLT >= 100m)
            {
                lblSalidaPLT.Text = "↓ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Yellow;
            }
            if (PLT < 100m)
            {
                lblSalidaPLT.Text = "↓ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Red;
            }

            if (PLT >= 450m && PLT <= 600m)
            {
                lblSalidaPLT.Text = "↑ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Yellow;
            }

            if (PLT > 600m)
            {
                lblSalidaPLT.Text = "↑ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Red;
            }

            /************************************************************************************/

            /***************************************************************************************/

            if (CHCM >= 31m && CHCM <= 36m)
            {
                lblSalidaCHCM.Text = CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Black;
            }

            if (CHCM > 36m)
            {
                lblSalidaCHCM.Text = "↑ " + CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Red;
            }

            if (CHCM < 31m)
            {
                lblSalidaCHCM.Text = "↓ " + CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Yellow;
            }
            /**************************************************************************/


            /************************************************************************/
            //HCM
            decimal porcentaje = (23m * 0.8m);



            if (HCM >= 23m && HCM <= 31m)
            {
                lblSalidaHCM.Text = HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Black;
            }


            if (HCM > 31m)
            {
                lblSalidaHCM.Text = "↑ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Yellow;
            }

            if (HCM < 23m)
            {
                lblSalidaHCM.Text = "↓ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Yellow;
            }

            if (HCM <= porcentaje)
            {
                lblSalidaHCM.Text = "↓ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Red;
            }

            /******************************************************************/



            /***********************VCM*************************************/

            decimal porcentajeVCMBajo = (70m * 0.88m);
            decimal porcentajeVCMAlto = (86m * 1.10m);




            if (VCM >= 70m && VCM <= 86m)
            {
                lblSalidaVCM.Text = VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Black;
            }


            if (VCM > 86m && VCM < porcentajeVCMAlto)
            {
                lblSalidaVCM.Text = "↑ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Yellow;
            }


            if (VCM >= porcentajeVCMAlto)
            {
                lblSalidaVCM.Text = "↑ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Red;
            }



            if (VCM < 70m)
            {
                lblSalidaVCM.Text = "↓ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Yellow;
            }

            if (VCM <= porcentajeVCMBajo)
            {
                lblSalidaVCM.Text = "↓ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Red;
            }


            /***********************************VCM*************************************/



            /*********************************HTO**********************************************/

            decimal porcentajeHTOBajo = (33m * 0.80m);
            decimal porcentajeHTOAlto = (39m * 1.20m);




            if (HTO >= 33m && HTO <= 39m)
            {
                lblSalidaHTO.Text = HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Black;
            }


            if (HTO > 39m && HTO < porcentajeHTOAlto)
            {
                lblSalidaHTO.Text = "↑ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Yellow;
            }


            if (HTO >= porcentajeHTOAlto)
            {
                lblSalidaHTO.Text = "↑ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Red;
            }

            if (HTO < 33m)
            {
                lblSalidaHTO.Text = "↓ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Yellow;
            }

            if (HTO <= porcentajeHTOBajo)
            {
                lblSalidaHTO.Text = "↓ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Red;
            }

            /*********************************HTO**********************************************/



            /*********************************HB**********************************************/

            decimal porcentajeHBBajo = (10.5m * 0.80m);
            decimal porcentajeHBAlto = (13.5m * 1.20m);




            if (HB >= 10.5m && HB <= 13.5m)
            {
                lblSalidaHB.Text = HB.ToString();
                lblSalidaHB.ForeColor = Color.Black;
            }


            if (HB > 13.5m && HB < porcentajeHBAlto)
            {
                lblSalidaHB.Text = "↑ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Yellow;
            }


            if (HB >= porcentajeHBAlto)
            {
                lblSalidaHB.Text = "↑ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Red;
            }

            if (HB < 10.5m)
            {
                lblSalidaHB.Text = "↓ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Yellow;
            }

            if (HB <= porcentajeHBBajo)
            {
                lblSalidaHB.Text = "↓ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Red;
            }



            /*********************************HB**********************************************/



            /*********************************GBRBC**********************************************/

            decimal porcentajeGBRBCBajo = (3.7m * 0.80m);
            decimal porcentajeGBRBCAlto = (5.3m * 1.25m);




            if (GBRBC >= 3.7m && GBRBC <= 5.3m)
            {
                lblSalidaGBRBC.Text = GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Black;
            }


            if (GBRBC > 5.3m && GBRBC < porcentajeGBRBCAlto)
            {
                lblSalidaGBRBC.Text = "↑ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Yellow;
            }


            if (GBRBC >= porcentajeGBRBCAlto)
            {
                lblSalidaGBRBC.Text = "↑ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Red;
            }

            if (GBRBC < 3.7m)
            {
                lblSalidaGBRBC.Text = "↓ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Yellow;
            }

            if (GBRBC <= porcentajeGBRBCBajo)
            {
                lblSalidaGBRBC.Text = "↓ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Red;
            }

            /*********************************GBRBC**********************************************/



            /*********************************GBWB**********************************************/

            decimal porcentajeGBWBBajo = (6.0m * 0.45m);
            decimal porcentajeGBWBCAlto = (17.5m * 1.30m);




            if (GBWB >= 6.0m && GBWB <= 17.5m)
            {
                lblSalidaGBWB.Text = GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Black;
            }


            if (GBWB > 17.5m && GBWB < porcentajeGBWBCAlto)
            {
                lblSalidaGBWB.Text = "↑ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Yellow;
            }


            if (GBWB >= porcentajeGBWBCAlto)
            {
                lblSalidaGBWB.Text = "↑ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Red;
            }

            if (GBWB < 6.0m)
            {
                lblSalidaGBWB.Text = "↓ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Yellow;
            }

            if (GBWB <= porcentajeGBWBBajo)
            {
                lblSalidaGBWB.Text = "↓ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Red;
            }

            /*********************************GBWB**********************************************/
        }


        /*GRUPO ETARIO 1-2 ANIOS*//*CORREGIDO*/
        private void alarmasGrupoEtario9()
        {
            decimal RDW = Convert.ToDecimal(txtRDW.Text, CultureInfo.InvariantCulture);
            decimal PLT = Convert.ToDecimal(txtPLT.Text, CultureInfo.InvariantCulture);
            decimal CHCM = Convert.ToDecimal(txtCHCM.Text, CultureInfo.InvariantCulture);
            decimal HCM = Convert.ToDecimal(txtHCM.Text, CultureInfo.InvariantCulture);
            decimal VCM = Convert.ToDecimal(txtVCM.Text, CultureInfo.InvariantCulture);
            decimal HTO = Convert.ToDecimal(txtHTO.Text, CultureInfo.InvariantCulture);
            decimal HB = Convert.ToDecimal(txtHB.Text, CultureInfo.InvariantCulture);
            decimal GBRBC = Convert.ToDecimal(txtGBRBC.Text, CultureInfo.InvariantCulture);
            decimal GBWB = Convert.ToDecimal(txtGBWB.Text, CultureInfo.InvariantCulture);

            /*******************************************************************/
            if (RDW > 15.0m && RDW <= 18.0m)
            {
                lblSalidaAlarmaRDW.Text = "↑ " + RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Yellow;
            }
            if (RDW > 18.0m)
            {
                lblSalidaAlarmaRDW.Text = "↑ " + RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Red;
            }
            if (RDW <= 15.0m)
            {
                lblSalidaAlarmaRDW.Text = RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Black;
            }
            /******************************************************************/

            /************************************************************************/
            if (PLT >= 150m && PLT <= 450m)
            {
                lblSalidaPLT.Text = PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Black;
            }
            if (PLT < 150m && PLT >= 100m)
            {
                lblSalidaPLT.Text = "↓ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Yellow;
            }
            if (PLT < 100m)
            {
                lblSalidaPLT.Text = "↓ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Red;
            }

            if (PLT >= 450m && PLT <= 600m)
            {
                lblSalidaPLT.Text = "↑ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Yellow;
            }

            if (PLT > 600m)
            {
                lblSalidaPLT.Text = "↑ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Red;
            }

            /************************************************************************************/

            /***************************************************************************************/

            if (CHCM >= 31m && CHCM <= 36m)
            {
                lblSalidaCHCM.Text = CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Black;
            }

            if (CHCM > 36m)
            {
                lblSalidaCHCM.Text = "↑ " + CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Red;
            }

            if (CHCM < 31m)
            {
                lblSalidaCHCM.Text = "↓ " + CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Yellow;
            }
            /**************************************************************************/


            /************************************************************************/
            //HCM
            decimal porcentaje = (23m * 0.8m);



            if (HCM >= 23m && HCM <= 31m)
            {
                lblSalidaHCM.Text = HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Black;
            }


            if (HCM > 31m)
            {
                lblSalidaHCM.Text = "↑ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Yellow;
            }

            if (HCM < 23m)
            {
                lblSalidaHCM.Text = "↓ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Yellow;
            }

            if (HCM <= porcentaje)
            {
                lblSalidaHCM.Text = "↓ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Red;
            }

            /******************************************************************/



            /***********************VCM*************************************/

            decimal porcentajeVCMBajo = (70m * 0.88m);
            decimal porcentajeVCMAlto = (86m * 1.10m);




            if (VCM >= 70m && VCM <= 86m)
            {
                lblSalidaVCM.Text = VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Black;
            }


            if (VCM > 86m && VCM < porcentajeVCMAlto)
            {
                lblSalidaVCM.Text = "↑ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Yellow;
            }


            if (VCM >= porcentajeVCMAlto)
            {
                lblSalidaVCM.Text = "↑ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Red;
            }



            if (VCM < 70m)
            {
                lblSalidaVCM.Text = "↓ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Yellow;
            }

            if (VCM <= porcentajeVCMBajo)
            {
                lblSalidaVCM.Text = "↓ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Red;
            }


            /***********************************VCM*************************************/



            /*********************************HTO**********************************************/

            decimal porcentajeHTOBajo = (33m * 0.80m);
            decimal porcentajeHTOAlto = (39m * 1.20m);




            if (HTO >= 33m && HTO <= 39m)
            {
                lblSalidaHTO.Text = HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Black;
            }


            if (HTO > 39m && HTO < porcentajeHTOAlto)
            {
                lblSalidaHTO.Text = "↑ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Yellow;
            }


            if (HTO >= porcentajeHTOAlto)
            {
                lblSalidaHTO.Text = "↑ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Red;
            }

            if (HTO < 33m)
            {
                lblSalidaHTO.Text = "↓ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Yellow;
            }

            if (HTO <= porcentajeHTOBajo)
            {
                lblSalidaHTO.Text = "↓ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Red;
            }

            /*********************************HTO**********************************************/



            /*********************************HB**********************************************/

            decimal porcentajeHBBajo = (10.5m * 0.80m);
            decimal porcentajeHBAlto = (13.5m * 1.20m);




            if (HB >= 10.5m && HB <= 13.5m)
            {
                lblSalidaHB.Text = HB.ToString();
                lblSalidaHB.ForeColor = Color.Black;
            }


            if (HB > 13.5m && HB < porcentajeHBAlto)
            {
                lblSalidaHB.Text = "↑ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Yellow;
            }


            if (HB >= porcentajeHBAlto)
            {
                lblSalidaHB.Text = "↑ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Red;
            }

            if (HB < 10.5m)
            {
                lblSalidaHB.Text = "↓ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Yellow;
            }

            if (HB <= porcentajeHBBajo)
            {
                lblSalidaHB.Text = "↓ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Red;
            }



            /*********************************HB**********************************************/



            /*********************************GBRBC**********************************************/

            decimal porcentajeGBRBCBajo = (3.7m * 0.80m);
            decimal porcentajeGBRBCAlto = (5.3m * 1.25m);




            if (GBRBC >= 3.7m && GBRBC <= 5.3m)
            {
                lblSalidaGBRBC.Text = GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Black;
            }


            if (GBRBC > 5.3m && GBRBC < porcentajeGBRBCAlto)
            {
                lblSalidaGBRBC.Text = "↑ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Yellow;
            }


            if (GBRBC >= porcentajeGBRBCAlto)
            {
                lblSalidaGBRBC.Text = "↑ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Red;
            }

            if (GBRBC < 3.7m)
            {
                lblSalidaGBRBC.Text = "↓ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Yellow;
            }

            if (GBRBC <= porcentajeGBRBCBajo)
            {
                lblSalidaGBRBC.Text = "↓ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Red;
            }

            /*********************************GBRBC**********************************************/



            /*********************************GBWB**********************************************/

            decimal porcentajeGBWBBajo = (6.0m * 0.45m);
            decimal porcentajeGBWBCAlto = (17.5m * 1.30m);




            if (GBWB >= 6.0m && GBWB <= 17.5m)
            {
                lblSalidaGBWB.Text = GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Black;
            }


            if (GBWB > 17.5m && GBWB < porcentajeGBWBCAlto)
            {
                lblSalidaGBWB.Text = "↑ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Yellow;
            }


            if (GBWB >= porcentajeGBWBCAlto)
            {
                lblSalidaGBWB.Text = "↑ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Red;
            }

            if (GBWB < 6.0m)
            {
                lblSalidaGBWB.Text = "↓ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Yellow;
            }

            if (GBWB <= porcentajeGBWBBajo)
            {
                lblSalidaGBWB.Text = "↓ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Red;
            }

            /*********************************GBWB**********************************************/
        }


        /*GRUPO ETARIO 3-6 ANIOS*//*CORREGIDO*/
        private void alarmasGrupoEtario10()
        {
            decimal RDW = Convert.ToDecimal(txtRDW.Text, CultureInfo.InvariantCulture);
            decimal PLT = Convert.ToDecimal(txtPLT.Text, CultureInfo.InvariantCulture);
            decimal CHCM = Convert.ToDecimal(txtCHCM.Text, CultureInfo.InvariantCulture);
            decimal HCM = Convert.ToDecimal(txtHCM.Text, CultureInfo.InvariantCulture);
            decimal VCM = Convert.ToDecimal(txtVCM.Text, CultureInfo.InvariantCulture);
            decimal HTO = Convert.ToDecimal(txtHTO.Text, CultureInfo.InvariantCulture);
            decimal HB = Convert.ToDecimal(txtHB.Text, CultureInfo.InvariantCulture);
            decimal GBRBC = Convert.ToDecimal(txtGBRBC.Text, CultureInfo.InvariantCulture);
            decimal GBWB = Convert.ToDecimal(txtGBWB.Text, CultureInfo.InvariantCulture);

            /*******************************************************************/
            if (RDW > 15.0m && RDW <= 18.0m)
            {
                lblSalidaAlarmaRDW.Text = "↑ " + RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Yellow;
            }
            if (RDW > 18.0m)
            {
                lblSalidaAlarmaRDW.Text = "↑ " + RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Red;
            }
            if (RDW <= 15.0m)
            {
                lblSalidaAlarmaRDW.Text = RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Black;
            }
            /******************************************************************/

            /************************************************************************/
            if (PLT >= 150m && PLT <= 450m)
            {
                lblSalidaPLT.Text = PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Black;
            }
            if (PLT < 150m && PLT >= 100m)
            {
                lblSalidaPLT.Text = "↓ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Yellow;
            }
            if (PLT < 100m)
            {
                lblSalidaPLT.Text = "↓ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Red;
            }

            if (PLT >= 450m && PLT <= 600m)
            {
                lblSalidaPLT.Text = "↑ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Yellow;
            }

            if (PLT > 600m)
            {
                lblSalidaPLT.Text = "↑ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Red;
            }

            /************************************************************************************/

            /***************************************************************************************/

            if (CHCM >= 31m && CHCM <= 36m)
            {
                lblSalidaCHCM.Text = CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Black;
            }

            if (CHCM > 36m)
            {
                lblSalidaCHCM.Text = "↑ " + CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Red;
            }

            if (CHCM < 31m)
            {
                lblSalidaCHCM.Text = "↓ " + CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Yellow;
            }
            /**************************************************************************/


            /************************************************************************/
            //HCM
            decimal porcentaje = (24m * 0.8m);



            if (HCM >= 24m && HCM <= 30m)
            {
                lblSalidaHCM.Text = HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Black;
            }


            if (HCM > 30m)
            {
                lblSalidaHCM.Text = "↑ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Yellow;
            }

            if (HCM < 24m)
            {
                lblSalidaHCM.Text = "↓ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Yellow;
            }

            if (HCM <= porcentaje)
            {
                lblSalidaHCM.Text = "↓ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Red;
            }

            /******************************************************************/



            /***********************VCM*************************************/

            decimal porcentajeVCMBajo = (75m * 0.88m);
            decimal porcentajeVCMAlto = (87m * 1.10m);




            if (VCM >= 75m && VCM <= 87m)
            {
                lblSalidaVCM.Text = VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Black;
            }


            if (VCM > 87m && VCM < porcentajeVCMAlto)
            {
                lblSalidaVCM.Text = "↑ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Yellow;
            }


            if (VCM >= porcentajeVCMAlto)
            {
                lblSalidaVCM.Text = "↑ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Red;
            }



            if (VCM < 75m)
            {
                lblSalidaVCM.Text = "↓ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Yellow;
            }

            if (VCM <= porcentajeVCMBajo)
            {
                lblSalidaVCM.Text = "↓ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Red;
            }


            /***********************************VCM*************************************/



            /*********************************HTO**********************************************/

            decimal porcentajeHTOBajo = (31m * 0.80m);
            decimal porcentajeHTOAlto = (43m * 1.20m);




            if (HTO >= 31m && HTO <= 43m)
            {
                lblSalidaHTO.Text = HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Black;
            }


            if (HTO > 43m && HTO < porcentajeHTOAlto)
            {
                lblSalidaHTO.Text = "↑ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Yellow;
            }


            if (HTO >= porcentajeHTOAlto)
            {
                lblSalidaHTO.Text = "↑ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Red;
            }

            if (HTO < 31m)
            {
                lblSalidaHTO.Text = "↓ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Yellow;
            }

            if (HTO <= porcentajeHTOBajo)
            {
                lblSalidaHTO.Text = "↓ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Red;
            }

            /*********************************HTO**********************************************/



            /*********************************HB**********************************************/

            decimal porcentajeHBBajo = (11.5m * 0.80m);
            decimal porcentajeHBAlto = (13.5m * 1.20m);




            if (HB >= 11.5m && HB <= 13.5m)
            {
                lblSalidaHB.Text = HB.ToString();
                lblSalidaHB.ForeColor = Color.Black;
            }


            if (HB > 11.5m && HB < porcentajeHBAlto)
            {
                lblSalidaHB.Text = "↑ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Yellow;
            }


            if (HB >= porcentajeHBAlto)
            {
                lblSalidaHB.Text = "↑ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Red;
            }

            if (HB < 11.5m)
            {
                lblSalidaHB.Text = "↓ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Yellow;
            }

            if (HB <= porcentajeHBBajo)
            {
                lblSalidaHB.Text = "↓ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Red;
            }



            /*********************************HB**********************************************/



            /*********************************GBRBC**********************************************/

            decimal porcentajeGBRBCBajo = (3.9m * 0.80m);
            decimal porcentajeGBRBCAlto = (5.3m * 1.25m);




            if (GBRBC >= 3.9m && GBRBC <= 5.3m)
            {
                lblSalidaGBRBC.Text = GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Black;
            }


            if (GBRBC > 5.3m && GBRBC < porcentajeGBRBCAlto)
            {
                lblSalidaGBRBC.Text = "↑ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Yellow;
            }


            if (GBRBC >= porcentajeGBRBCAlto)
            {
                lblSalidaGBRBC.Text = "↑ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Red;
            }

            if (GBRBC < 3.9m)
            {
                lblSalidaGBRBC.Text = "↓ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Yellow;
            }

            if (GBRBC <= porcentajeGBRBCBajo)
            {
                lblSalidaGBRBC.Text = "↓ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Red;
            }

            /*********************************GBRBC**********************************************/



            /*********************************GBWB**********************************************/

            decimal porcentajeGBWBBajo = (5.5m * 0.45m);
            decimal porcentajeGBWBCAlto = (15.5m * 1.30m);




            if (GBWB >= 5.5m && GBWB <= 15.5m)
            {
                lblSalidaGBWB.Text = GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Black;
            }


            if (GBWB > 15.5m && GBWB < porcentajeGBWBCAlto)
            {
                lblSalidaGBWB.Text = "↑ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Yellow;
            }


            if (GBWB >= porcentajeGBWBCAlto)
            {
                lblSalidaGBWB.Text = "↑ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Red;
            }

            if (GBWB < 5.5m)
            {
                lblSalidaGBWB.Text = "↓ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Yellow;
            }

            if (GBWB <= porcentajeGBWBBajo)
            {
                lblSalidaGBWB.Text = "↓ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Red;
            }

            /*********************************GBWB**********************************************/
        }


        /*GRUPO ETARIO 7-12 ANIOS*//*CORREGIDO*/
        private void alarmasGrupoEtario11()
        {
            decimal RDW = Convert.ToDecimal(txtRDW.Text, CultureInfo.InvariantCulture);
            decimal PLT = Convert.ToDecimal(txtPLT.Text, CultureInfo.InvariantCulture);
            decimal CHCM = Convert.ToDecimal(txtCHCM.Text, CultureInfo.InvariantCulture);
            decimal HCM = Convert.ToDecimal(txtHCM.Text, CultureInfo.InvariantCulture);
            decimal VCM = Convert.ToDecimal(txtVCM.Text, CultureInfo.InvariantCulture);
            decimal HTO = Convert.ToDecimal(txtHTO.Text, CultureInfo.InvariantCulture);
            decimal HB = Convert.ToDecimal(txtHB.Text, CultureInfo.InvariantCulture);
            decimal GBRBC = Convert.ToDecimal(txtGBRBC.Text, CultureInfo.InvariantCulture);
            decimal GBWB = Convert.ToDecimal(txtGBWB.Text, CultureInfo.InvariantCulture);

            /*******************************************************************/
            if (RDW > 15.0m && RDW <= 18.0m)
            {
                lblSalidaAlarmaRDW.Text = "↑ " + RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Yellow;
            }
            if (RDW > 18.0m)
            {
                lblSalidaAlarmaRDW.Text = "↑ " + RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Red;
            }
            if (RDW <= 15.0m)
            {
                lblSalidaAlarmaRDW.Text = RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Black;
            }
            /******************************************************************/

            /************************************************************************/
            if (PLT >= 150m && PLT <= 450m)
            {
                lblSalidaPLT.Text = PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Black;
            }
            if (PLT < 150m && PLT >= 100m)
            {
                lblSalidaPLT.Text = "↓ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Yellow;
            }
            if (PLT < 100m)
            {
                lblSalidaPLT.Text = "↓ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Red;
            }

            if (PLT >= 450m && PLT <= 600m)
            {
                lblSalidaPLT.Text = "↑ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Yellow;
            }

            if (PLT > 600m)
            {
                lblSalidaPLT.Text = "↑ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Red;
            }

            /************************************************************************************/

            /***************************************************************************************/

            if (CHCM >= 31m && CHCM <= 36m)
            {
                lblSalidaCHCM.Text = CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Black;
            }

            if (CHCM > 36m)
            {
                lblSalidaCHCM.Text = "↑ " + CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Red;
            }

            if (CHCM < 31m)
            {
                lblSalidaCHCM.Text = "↓ " + CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Yellow;
            }
            /**************************************************************************/


            /************************************************************************/
            //HCM
            decimal porcentaje = (25m * 0.8m);



            if (HCM >= 25m && HCM <= 33m)
            {
                lblSalidaHCM.Text = HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Black;
            }


            if (HCM > 33m)
            {
                lblSalidaHCM.Text = "↑ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Yellow;
            }

            if (HCM < 25m)
            {
                lblSalidaHCM.Text = "↓ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Yellow;
            }

            if (HCM <= porcentaje)
            {
                lblSalidaHCM.Text = "↓ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Red;
            }

            /******************************************************************/



            /***********************VCM*************************************/

            decimal porcentajeVCMBajo = (77m * 0.88m);
            decimal porcentajeVCMAlto = (95m * 1.10m);




            if (VCM >= 77m && VCM <= 95m)
            {
                lblSalidaVCM.Text = VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Black;
            }


            if (VCM > 95m && VCM < porcentajeVCMAlto)
            {
                lblSalidaVCM.Text = "↑ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Yellow;
            }


            if (VCM >= porcentajeVCMAlto)
            {
                lblSalidaVCM.Text = "↑ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Red;
            }



            if (VCM < 77m)
            {
                lblSalidaVCM.Text = "↓ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Yellow;
            }

            if (VCM <= porcentajeVCMBajo)
            {
                lblSalidaVCM.Text = "↓ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Red;
            }


            /***********************************VCM*************************************/



            /*********************************HTO**********************************************/

            decimal porcentajeHTOBajo = (35m * 0.80m);
            decimal porcentajeHTOAlto = (45m * 1.20m);




            if (HTO >= 35m && HTO <= 45m)
            {
                lblSalidaHTO.Text = HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Black;
            }


            if (HTO > 45m && HTO < porcentajeHTOAlto)
            {
                lblSalidaHTO.Text = "↑ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Yellow;
            }


            if (HTO >= porcentajeHTOAlto)
            {
                lblSalidaHTO.Text = "↑ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Red;
            }

            if (HTO < 35m)
            {
                lblSalidaHTO.Text = "↓ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Yellow;
            }

            if (HTO <= porcentajeHTOBajo)
            {
                lblSalidaHTO.Text = "↓ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Red;
            }

            /*********************************HTO**********************************************/



            /*********************************HB**********************************************/

            decimal porcentajeHBBajo = (11.5m * 0.80m);
            decimal porcentajeHBAlto = (15.5m * 1.20m);




            if (HB >= 11.5m && HB <= 15.5m)
            {
                lblSalidaHB.Text = HB.ToString();
                lblSalidaHB.ForeColor = Color.Black;
            }


            if (HB > 15.5m && HB < porcentajeHBAlto)
            {
                lblSalidaHB.Text = "↑ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Yellow;
            }


            if (HB >= porcentajeHBAlto)
            {
                lblSalidaHB.Text = "↑ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Red;
            }

            if (HB < 11.5m)
            {
                lblSalidaHB.Text = "↓ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Yellow;
            }

            if (HB <= porcentajeHBBajo)
            {
                lblSalidaHB.Text = "↓ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Red;
            }



            /*********************************HB**********************************************/



            /*********************************GBRBC**********************************************/

            decimal porcentajeGBRBCBajo = (4.0m * 0.80m);
            decimal porcentajeGBRBCAlto = (5.2m * 1.25m);




            if (GBRBC >= 4.0m && GBRBC <= 5.2m)
            {
                lblSalidaGBRBC.Text = GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Black;
            }


            if (GBRBC > 5.2m && GBRBC < porcentajeGBRBCAlto)
            {
                lblSalidaGBRBC.Text = "↑ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Yellow;
            }


            if (GBRBC >= porcentajeGBRBCAlto)
            {
                lblSalidaGBRBC.Text = "↑ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Red;
            }

            if (GBRBC < 4.0m)
            {
                lblSalidaGBRBC.Text = "↓ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Yellow;
            }

            if (GBRBC <= porcentajeGBRBCBajo)
            {
                lblSalidaGBRBC.Text = "↓ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Red;
            }

            /*********************************GBRBC**********************************************/



            /*********************************GBWB**********************************************/

            decimal porcentajeGBWBBajo = (5.0m * 0.45m);
            decimal porcentajeGBWBCAlto = (13.5m * 1.30m);




            if (GBWB >= 5.0m && GBWB <= 13.5m)
            {
                lblSalidaGBWB.Text = GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Black;
            }


            if (GBWB > 13.5m && GBWB < porcentajeGBWBCAlto)
            {
                lblSalidaGBWB.Text = "↑ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Yellow;
            }


            if (GBWB >= porcentajeGBWBCAlto)
            {
                lblSalidaGBWB.Text = "↑ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Red;
            }

            if (GBWB < 5.0m)
            {
                lblSalidaGBWB.Text = "↓ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Yellow;
            }

            if (GBWB <= porcentajeGBWBBajo)
            {
                lblSalidaGBWB.Text = "↓ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Red;
            }

            /*********************************GBWB**********************************************/
        }


        /*GRUPO ETARIO 13-18 ANIOS MUJERES*//*CORREGIDO*/
        private void alarmasGrupoEtario12()
        {
            decimal RDW = Convert.ToDecimal(txtRDW.Text, CultureInfo.InvariantCulture);
            decimal PLT = Convert.ToDecimal(txtPLT.Text, CultureInfo.InvariantCulture);
            decimal CHCM = Convert.ToDecimal(txtCHCM.Text, CultureInfo.InvariantCulture);
            decimal HCM = Convert.ToDecimal(txtHCM.Text, CultureInfo.InvariantCulture);
            decimal VCM = Convert.ToDecimal(txtVCM.Text, CultureInfo.InvariantCulture);
            decimal HTO = Convert.ToDecimal(txtHTO.Text, CultureInfo.InvariantCulture);
            decimal HB = Convert.ToDecimal(txtHB.Text, CultureInfo.InvariantCulture);
            decimal GBRBC = Convert.ToDecimal(txtGBRBC.Text, CultureInfo.InvariantCulture);
            decimal GBWB = Convert.ToDecimal(txtGBWB.Text, CultureInfo.InvariantCulture);

            /*******************************************************************/
            if (RDW > 15.0m && RDW <= 18.0m)
            {
                lblSalidaAlarmaRDW.Text = "↑ " + RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Yellow;
            }
            if (RDW > 18.0m)
            {
                lblSalidaAlarmaRDW.Text = "↑ " + RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Red;
            }
            if (RDW <= 15.0m)
            {
                lblSalidaAlarmaRDW.Text = RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Black;
            }
            /******************************************************************/

            /************************************************************************/
            if (PLT >= 150m && PLT <= 450m)
            {
                lblSalidaPLT.Text = PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Black;
            }
            if (PLT < 150m && PLT >= 100m)
            {
                lblSalidaPLT.Text = "↓ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Yellow;
            }
            if (PLT < 100m)
            {
                lblSalidaPLT.Text = "↓ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Red;
            }

            if (PLT >= 450m && PLT <= 600m)
            {
                lblSalidaPLT.Text = "↑ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Yellow;
            }

            if (PLT > 600m)
            {
                lblSalidaPLT.Text = "↑ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Red;
            }

            /************************************************************************************/

            /***************************************************************************************/

            if (CHCM >= 31m && CHCM <= 36m)
            {
                lblSalidaCHCM.Text = CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Black;
            }

            if (CHCM > 36m)
            {
                lblSalidaCHCM.Text = "↑ " + CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Red;
            }

            if (CHCM < 31m)
            {
                lblSalidaCHCM.Text = "↓ " + CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Yellow;
            }
            /**************************************************************************/


            /************************************************************************/
            //HCM
            decimal porcentaje = (25m * 0.8m);



            if (HCM >= 25m && HCM <= 35m)
            {
                lblSalidaHCM.Text = HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Black;
            }


            if (HCM > 35m)
            {
                lblSalidaHCM.Text = "↑ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Yellow;
            }

            if (HCM < 25m)
            {
                lblSalidaHCM.Text = "↓ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Yellow;
            }

            if (HCM <= porcentaje)
            {
                lblSalidaHCM.Text = "↓ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Red;
            }

            /******************************************************************/



            /***********************VCM*************************************/

            decimal porcentajeVCMBajo = (78m * 0.88m);
            decimal porcentajeVCMAlto = (102m * 1.10m);




            if (VCM >= 78m && VCM <= 102m)
            {
                lblSalidaVCM.Text = VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Black;
            }


            if (VCM > 102m && VCM < porcentajeVCMAlto)
            {
                lblSalidaVCM.Text = "↑ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Yellow;
            }


            if (VCM >= porcentajeVCMAlto)
            {
                lblSalidaVCM.Text = "↑ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Red;
            }



            if (VCM < 78m)
            {
                lblSalidaVCM.Text = "↓ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Yellow;
            }

            if (VCM <= porcentajeVCMBajo)
            {
                lblSalidaVCM.Text = "↓ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Red;
            }


            /***********************************VCM*************************************/



            /*********************************HTO**********************************************/

            decimal porcentajeHTOBajo = (36m * 0.80m);
            decimal porcentajeHTOAlto = (46m * 1.20m);




            if (HTO >= 36m && HTO <= 46m)
            {
                lblSalidaHTO.Text = HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Black;
            }


            if (HTO > 46m && HTO < porcentajeHTOAlto)
            {
                lblSalidaHTO.Text = "↑ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Yellow;
            }


            if (HTO >= porcentajeHTOAlto)
            {
                lblSalidaHTO.Text = "↑ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Red;
            }

            if (HTO < 36m)
            {
                lblSalidaHTO.Text = "↓ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Yellow;
            }

            if (HTO <= porcentajeHTOBajo)
            {
                lblSalidaHTO.Text = "↓ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Red;
            }

            /*********************************HTO**********************************************/



            /*********************************HB**********************************************/

            decimal porcentajeHBBajo = (12.0m * 0.80m);
            decimal porcentajeHBAlto = (16.0m * 1.20m);




            if (HB >= 12.0m && HB <= 16.0m)
            {
                lblSalidaHB.Text = HB.ToString();
                lblSalidaHB.ForeColor = Color.Black;
            }


            if (HB > 16.0m && HB < porcentajeHBAlto)
            {
                lblSalidaHB.Text = "↑ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Yellow;
            }


            if (HB >= porcentajeHBAlto)
            {
                lblSalidaHB.Text = "↑ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Red;
            }

            if (HB < 12.0m)
            {
                lblSalidaHB.Text = "↓ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Yellow;
            }

            if (HB <= porcentajeHBBajo)
            {
                lblSalidaHB.Text = "↓ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Red;
            }



            /*********************************HB**********************************************/



            /*********************************GBRBC**********************************************/

            decimal porcentajeGBRBCBajo = (4.4m * 0.80m);
            decimal porcentajeGBRBCAlto = (5.4m * 1.25m);




            if (GBRBC >= 4.4m && GBRBC <= 5.4m)
            {
                lblSalidaGBRBC.Text = GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Black;
            }


            if (GBRBC > 5.4m && GBRBC < porcentajeGBRBCAlto)
            {
                lblSalidaGBRBC.Text = "↑ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Yellow;
            }


            if (GBRBC >= porcentajeGBRBCAlto)
            {
                lblSalidaGBRBC.Text = "↑ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Red;
            }

            if (GBRBC < 4.4m)
            {
                lblSalidaGBRBC.Text = "↓ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Yellow;
            }

            if (GBRBC <= porcentajeGBRBCBajo)
            {
                lblSalidaGBRBC.Text = "↓ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Red;
            }

            /*********************************GBRBC**********************************************/



            /*********************************GBWB**********************************************/

            decimal porcentajeGBWBBajo = (4.5m * 0.45m);
            decimal porcentajeGBWBCAlto = (13.0m * 1.30m);




            if (GBWB >= 4.5m && GBWB <= 13.0m)
            {
                lblSalidaGBWB.Text = GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Black;
            }


            if (GBWB > 13.0m && GBWB < porcentajeGBWBCAlto)
            {
                lblSalidaGBWB.Text = "↑ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Yellow;
            }


            if (GBWB >= porcentajeGBWBCAlto)
            {
                lblSalidaGBWB.Text = "↑ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Red;
            }

            if (GBWB < 4.5m)
            {
                lblSalidaGBWB.Text = "↓ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Yellow;
            }

            if (GBWB <= porcentajeGBWBBajo)
            {
                lblSalidaGBWB.Text = "↓ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Red;
            }

            /*********************************GBWB**********************************************/
        }


        /*GRUPO ETARIO 13-18 ANIOS HOMBRES*//*CORREGIDO*/
        private void alarmasGrupoEtario13()
        {
            decimal RDW = Convert.ToDecimal(txtRDW.Text, CultureInfo.InvariantCulture);
            decimal PLT = Convert.ToDecimal(txtPLT.Text, CultureInfo.InvariantCulture);
            decimal CHCM = Convert.ToDecimal(txtCHCM.Text, CultureInfo.InvariantCulture);
            decimal HCM = Convert.ToDecimal(txtHCM.Text, CultureInfo.InvariantCulture);
            decimal VCM = Convert.ToDecimal(txtVCM.Text, CultureInfo.InvariantCulture);
            decimal HTO = Convert.ToDecimal(txtHTO.Text, CultureInfo.InvariantCulture);
            decimal HB = Convert.ToDecimal(txtHB.Text, CultureInfo.InvariantCulture);
            decimal GBRBC = Convert.ToDecimal(txtGBRBC.Text, CultureInfo.InvariantCulture);
            decimal GBWB = Convert.ToDecimal(txtGBWB.Text, CultureInfo.InvariantCulture);

            /*******************************************************************/
            if (RDW > 15.0m && RDW <= 18.0m)
            {
                lblSalidaAlarmaRDW.Text = "↑ " + RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Yellow;
            }
            if (RDW > 18.0m)
            {
                lblSalidaAlarmaRDW.Text = "↑ " + RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Red;
            }
            if (RDW <= 15.0m)
            {
                lblSalidaAlarmaRDW.Text = RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Black;
            }
            /******************************************************************/

            /************************************************************************/
            if (PLT >= 150m && PLT <= 450m)
            {
                lblSalidaPLT.Text = PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Black;
            }
            if (PLT < 150m && PLT >= 100m)
            {
                lblSalidaPLT.Text = "↓ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Yellow;
            }
            if (PLT < 100m)
            {
                lblSalidaPLT.Text = "↓ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Red;
            }

            if (PLT >= 450m && PLT <= 600m)
            {
                lblSalidaPLT.Text = "↑ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Yellow;
            }

            if (PLT > 600m)
            {
                lblSalidaPLT.Text = "↑ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Red;
            }

            /************************************************************************************/

            /***************************************************************************************/

            if (CHCM >= 31m && CHCM <= 36m)
            {
                lblSalidaCHCM.Text = CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Black;
            }

            if (CHCM > 36m)
            {
                lblSalidaCHCM.Text = "↑ " + CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Red;
            }

            if (CHCM < 31m)
            {
                lblSalidaCHCM.Text = "↓ " + CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Yellow;
            }
            /**************************************************************************/


            /************************************************************************/
            //HCM
            decimal porcentaje = (25m * 0.8m);



            if (HCM >= 25m && HCM <= 35m)
            {
                lblSalidaHCM.Text = HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Black;
            }


            if (HCM > 35m)
            {
                lblSalidaHCM.Text = "↑ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Yellow;
            }

            if (HCM < 25m)
            {
                lblSalidaHCM.Text = "↓ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Yellow;
            }

            if (HCM <= porcentaje)
            {
                lblSalidaHCM.Text = "↓ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Red;
            }

            /******************************************************************/



            /***********************VCM*************************************/

            decimal porcentajeVCMBajo = (78m * 0.88m);
            decimal porcentajeVCMAlto = (98m * 1.10m);




            if (VCM >= 78m && VCM <= 98m)
            {
                lblSalidaVCM.Text = VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Black;
            }


            if (VCM > 98m && VCM < porcentajeVCMAlto)
            {
                lblSalidaVCM.Text = "↑ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Yellow;
            }


            if (VCM >= porcentajeVCMAlto)
            {
                lblSalidaVCM.Text = "↑ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Red;
            }



            if (VCM < 78m)
            {
                lblSalidaVCM.Text = "↓ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Yellow;
            }

            if (VCM <= porcentajeVCMBajo)
            {
                lblSalidaVCM.Text = "↓ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Red;
            }


            /***********************************VCM*************************************/



            /*********************************HTO**********************************************/

            decimal porcentajeHTOBajo = (37m * 0.80m);
            decimal porcentajeHTOAlto = (49m * 1.20m);




            if (HTO >= 37m && HTO <= 49m)
            {
                lblSalidaHTO.Text = HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Black;
            }


            if (HTO > 49m && HTO < porcentajeHTOAlto)
            {
                lblSalidaHTO.Text = "↑ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Yellow;
            }


            if (HTO >= porcentajeHTOAlto)
            {
                lblSalidaHTO.Text = "↑ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Red;
            }

            if (HTO < 37m)
            {
                lblSalidaHTO.Text = "↓ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Yellow;
            }

            if (HTO <= porcentajeHTOBajo)
            {
                lblSalidaHTO.Text = "↓ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Red;
            }

            /*********************************HTO**********************************************/



            /*********************************HB**********************************************/

            decimal porcentajeHBBajo = (13.0m * 0.80m);
            decimal porcentajeHBAlto = (16.0m * 1.20m);




            if (HB >= 13.0m && HB <= 16.0m)
            {
                lblSalidaHB.Text = HB.ToString();
                lblSalidaHB.ForeColor = Color.Black;
            }


            if (HB > 16.0m && HB < porcentajeHBAlto)
            {
                lblSalidaHB.Text = "↑ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Yellow;
            }


            if (HB >= porcentajeHBAlto)
            {
                lblSalidaHB.Text = "↑ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Red;
            }

            if (HB < 13.0m)
            {
                lblSalidaHB.Text = "↓ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Yellow;
            }

            if (HB <= porcentajeHBBajo)
            {
                lblSalidaHB.Text = "↓ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Red;
            }



            /*********************************HB**********************************************/



            /*********************************GBRBC**********************************************/

            decimal porcentajeGBRBCBajo = (4.5m * 0.80m);
            decimal porcentajeGBRBCAlto = (5.3m * 1.25m);




            if (GBRBC >= 4.5m && GBRBC <= 5.3m)
            {
                lblSalidaGBRBC.Text = GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Black;
            }


            if (GBRBC > 5.3m && GBRBC < porcentajeGBRBCAlto)
            {
                lblSalidaGBRBC.Text = "↑ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Yellow;
            }


            if (GBRBC >= porcentajeGBRBCAlto)
            {
                lblSalidaGBRBC.Text = "↑ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Red;
            }

            if (GBRBC < 4.5m)
            {
                lblSalidaGBRBC.Text = "↓ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Yellow;
            }

            if (GBRBC <= porcentajeGBRBCBajo)
            {
                lblSalidaGBRBC.Text = "↓ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Red;
            }

            /*********************************GBRBC**********************************************/



            /*********************************GBWB**********************************************/

            decimal porcentajeGBWBBajo = (4.5m * 0.45m);
            decimal porcentajeGBWBCAlto = (13.0m * 1.30m);




            if (GBWB >= 4.5m && GBWB <= 13.0m)
            {
                lblSalidaGBWB.Text = GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Black;
            }


            if (GBWB > 13.0m && GBWB < porcentajeGBWBCAlto)
            {
                lblSalidaGBWB.Text = "↑ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Yellow;
            }


            if (GBWB >= porcentajeGBWBCAlto)
            {
                lblSalidaGBWB.Text = "↑ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Red;
            }

            if (GBWB < 4.5m)
            {
                lblSalidaGBWB.Text = "↓ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Yellow;
            }

            if (GBWB <= porcentajeGBWBBajo)
            {
                lblSalidaGBWB.Text = "↓ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Red;
            }

            /*********************************GBWB**********************************************/
        }


        /*GRUPO ETARIO 19-99 ANIOS MUJERES*//*CORREGIDO*/
        private void alarmasGrupoEtario14()
        {
            decimal RDW = Convert.ToDecimal(txtRDW.Text, CultureInfo.InvariantCulture);
            decimal PLT = Convert.ToDecimal(txtPLT.Text, CultureInfo.InvariantCulture);
            decimal CHCM = Convert.ToDecimal(txtCHCM.Text, CultureInfo.InvariantCulture);
            decimal HCM = Convert.ToDecimal(txtHCM.Text, CultureInfo.InvariantCulture);
            decimal VCM = Convert.ToDecimal(txtVCM.Text, CultureInfo.InvariantCulture);
            decimal HTO = Convert.ToDecimal(txtHTO.Text, CultureInfo.InvariantCulture);
            decimal HB = Convert.ToDecimal(txtHB.Text, CultureInfo.InvariantCulture);
            decimal GBRBC = Convert.ToDecimal(txtGBRBC.Text, CultureInfo.InvariantCulture);
            decimal GBWB = Convert.ToDecimal(txtGBWB.Text, CultureInfo.InvariantCulture);

            /*******************************************************************/
            if (RDW > 15.0m && RDW <= 18.0m)
            {
                lblSalidaAlarmaRDW.Text = "↑ " + RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Yellow;
            }
            if (RDW > 18.0m)
            {
                lblSalidaAlarmaRDW.Text = "↑ " + RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Red;
            }
            if (RDW <= 15.0m)
            {
                lblSalidaAlarmaRDW.Text = RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Black;
            }
            /******************************************************************/

            /************************************************************************/
            if (PLT >= 150m && PLT <= 450m)
            {
                lblSalidaPLT.Text = PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Black;
            }
            if (PLT < 150m && PLT >= 100m)
            {
                lblSalidaPLT.Text = "↓ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Yellow;
            }
            if (PLT < 100m)
            {
                lblSalidaPLT.Text = "↓ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Red;
            }

            if (PLT >= 450m && PLT <= 600m)
            {
                lblSalidaPLT.Text = "↑ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Yellow;
            }

            if (PLT > 600m)
            {
                lblSalidaPLT.Text = "↑ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Red;
            }

            /************************************************************************************/

            /***************************************************************************************/

            if (CHCM >= 31m && CHCM <= 36m)
            {
                lblSalidaCHCM.Text = CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Black;
            }

            if (CHCM > 36m)
            {
                lblSalidaCHCM.Text = "↑ " + CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Red;
            }

            if (CHCM < 31m)
            {
                lblSalidaCHCM.Text = "↓ " + CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Yellow;
            }
            /**************************************************************************/


            /************************************************************************/
            //HCM
            decimal porcentaje = (26m * 0.8m);



            if (HCM >= 26m && HCM <= 34m)
            {
                lblSalidaHCM.Text = HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Black;
            }


            if (HCM > 34m)
            {
                lblSalidaHCM.Text = "↑ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Yellow;
            }

            if (HCM < 26m)
            {
                lblSalidaHCM.Text = "↓ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Yellow;
            }

            if (HCM <= porcentaje)
            {
                lblSalidaHCM.Text = "↓ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Red;
            }

            /******************************************************************/



            /***********************VCM*************************************/

            decimal porcentajeVCMBajo = (80m * 0.88m);
            decimal porcentajeVCMAlto = (100m * 1.10m);




            if (VCM >= 80m && VCM <= 100m)
            {
                lblSalidaVCM.Text = VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Black;
            }


            if (VCM > 100m && VCM < porcentajeVCMAlto)
            {
                lblSalidaVCM.Text = "↑ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Yellow;
            }



            if (VCM >= porcentajeVCMAlto)
            {
                lblSalidaVCM.Text = "↑ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Red;
            }




            if (VCM < 80m)
            {
                lblSalidaVCM.Text = "↓ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Yellow;
            }

            if (VCM <= porcentajeVCMBajo)
            {
                lblSalidaVCM.Text = "↓ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Red;
            }


            /***********************************VCM*************************************/



            /*********************************HTO**********************************************/

            decimal porcentajeHTOBajo = (36m * 0.80m);
            decimal porcentajeHTOAlto = (46m * 1.20m);




            if (HTO >= 36m && HTO <= 46m)
            {
                lblSalidaHTO.Text = HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Black;
            }


            if (HTO > 46m && HTO < porcentajeHTOAlto)
            {
                lblSalidaHTO.Text = "↑ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Yellow;
            }


            if (HTO >= porcentajeHTOAlto)
            {
                lblSalidaHTO.Text = "↑ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Red;
            }

            if (HTO < 36m)
            {
                lblSalidaHTO.Text = "↓ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Yellow;
            }

            if (HTO <= porcentajeHTOBajo)
            {
                lblSalidaHTO.Text = "↓ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Red;
            }

            /*********************************HTO**********************************************/



            /*********************************HB**********************************************/

            decimal porcentajeHBBajo = (12.0m * 0.80m);
            decimal porcentajeHBAlto = (16.0m * 1.20m);




            if (HB >= 12.0m && HB <= 16.0m)
            {
                lblSalidaHB.Text = HB.ToString();
                lblSalidaHB.ForeColor = Color.Black;
            }


            if (HB > 16.0m && HB < porcentajeHBAlto)
            {
                lblSalidaHB.Text = "↑ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Yellow;
            }


            if (HB >= porcentajeHBAlto)
            {
                lblSalidaHB.Text = "↑ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Red;
            }

            if (HB < 12.0m)
            {
                lblSalidaHB.Text = "↓ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Yellow;
            }

            if (HB <= porcentajeHBBajo)
            {
                lblSalidaHB.Text = "↓ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Red;
            }



            /*********************************HB**********************************************/



            /*********************************GBRBC**********************************************/

            decimal porcentajeGBRBCBajo = (4.0m * 0.80m);
            decimal porcentajeGBRBCAlto = (5.2m * 1.25m);




            if (GBRBC >= 4.0m && GBRBC <= 5.2m)
            {
                lblSalidaGBRBC.Text = GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Black;
            }


            if (GBRBC > 5.2m && GBRBC < porcentajeGBRBCAlto)
            {
                lblSalidaGBRBC.Text = "↑ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Yellow;
            }


            if (GBRBC >= porcentajeGBRBCAlto)
            {
                lblSalidaGBRBC.Text = "↑ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Red;
            }

            if (GBRBC < 4.0m)
            {
                lblSalidaGBRBC.Text = "↓ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Yellow;
            }

            if (GBRBC <= porcentajeGBRBCBajo)
            {
                lblSalidaGBRBC.Text = "↓ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Red;
            }

            /*********************************GBRBC**********************************************/



            /*********************************GBWB**********************************************/

            decimal porcentajeGBWBBajo = (4.5m * 0.45m);
            decimal porcentajeGBWBCAlto = (11.0m * 1.30m);




            if (GBWB >= 4.5m && GBWB <= 11.0m)
            {
                lblSalidaGBWB.Text = GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Black;
            }


            if (GBWB > 11.0m && GBWB < porcentajeGBWBCAlto)
            {
                lblSalidaGBWB.Text = "↑ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Yellow;
            }


            if (GBWB >= porcentajeGBWBCAlto)
            {
                lblSalidaGBWB.Text = "↑ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Red;
            }

            if (GBWB < 4.5m)
            {
                lblSalidaGBWB.Text = "↓ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Yellow;
            }

            if (GBWB <= porcentajeGBWBBajo)
            {
                lblSalidaGBWB.Text = "↓ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Red;
            }

            /*********************************GBWB**********************************************/
        }


        /*GRUPO ETARIO 19-99 ANIOS HOMBRES*//*CORREGIDO*/
        private void alarmasGrupoEtario15()
        {
            decimal RDW = Convert.ToDecimal(txtRDW.Text, CultureInfo.InvariantCulture);
            decimal PLT = Convert.ToDecimal(txtPLT.Text, CultureInfo.InvariantCulture);
            decimal CHCM = Convert.ToDecimal(txtCHCM.Text, CultureInfo.InvariantCulture);
            decimal HCM = Convert.ToDecimal(txtHCM.Text, CultureInfo.InvariantCulture);
            decimal VCM = Convert.ToDecimal(txtVCM.Text, CultureInfo.InvariantCulture);
            decimal HTO = Convert.ToDecimal(txtHTO.Text, CultureInfo.InvariantCulture);
            decimal HB = Convert.ToDecimal(txtHB.Text, CultureInfo.InvariantCulture);
            decimal GBRBC = Convert.ToDecimal(txtGBRBC.Text, CultureInfo.InvariantCulture);
            decimal GBWB = Convert.ToDecimal(txtGBWB.Text, CultureInfo.InvariantCulture);

            /*******************************************************************/
            if (RDW > 15.0m && RDW <= 18.0m)
            {
                lblSalidaAlarmaRDW.Text = "↑ " + RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Yellow;
            }
            if (RDW > 18.0m)
            {
                lblSalidaAlarmaRDW.Text = "↑ " + RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Red;
            }
            if (RDW <= 15.0m)
            {
                lblSalidaAlarmaRDW.Text = RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Black;
            }
            /******************************************************************/

            /************************************************************************/
            if (PLT >= 150m && PLT <= 450m)
            {
                lblSalidaPLT.Text = PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Black;
            }
            if (PLT < 150m && PLT >= 100m)
            {
                lblSalidaPLT.Text = "↓ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Yellow;
            }
            if (PLT < 100m)
            {
                lblSalidaPLT.Text = "↓ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Red;
            }

            if (PLT >= 450m && PLT <= 600m)
            {
                lblSalidaPLT.Text = "↑ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Yellow;
            }

            if (PLT > 600m)
            {
                lblSalidaPLT.Text = "↑ " + PLT.ToString();
                lblSalidaPLT.ForeColor = Color.Red;
            }

            /************************************************************************************/

            /***************************************************************************************/

            if (CHCM >= 31m && CHCM <= 36m)
            {
                lblSalidaCHCM.Text = CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Black;
            }

            if (CHCM > 36m)
            {
                lblSalidaCHCM.Text = "↑ " + CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Red;
            }

            if (CHCM < 31m)
            {
                lblSalidaCHCM.Text = "↓ " + CHCM.ToString();
                lblSalidaCHCM.ForeColor = Color.Yellow;
            }
            /**************************************************************************/


            /************************************************************************/
            //HCM
            decimal porcentaje = (25m * 0.8m);



            if (HCM >= 25m && HCM <= 35m)
            {
                lblSalidaHCM.Text = HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Black;
            }


            if (HCM > 35m)
            {
                lblSalidaHCM.Text = "↑ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Yellow;
            }

            if (HCM < 25m)
            {
                lblSalidaHCM.Text = "↓ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Yellow;
            }

            if (HCM <= porcentaje)
            {
                lblSalidaHCM.Text = "↓ " + HCM.ToString();
                lblSalidaHCM.ForeColor = Color.Red;
            }

            /******************************************************************/



            /***********************VCM*************************************/

            decimal porcentajeVCMBajo = (80m * 0.88m);
            decimal porcentajeVCMAlto = (100m * 1.10m);




            if (VCM >= 80m && VCM <= 100m)
            {
                lblSalidaVCM.Text = VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Black;
            }


            if (VCM > 100m && VCM < porcentajeVCMAlto)
            {
                lblSalidaVCM.Text = "↑ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Yellow;
            }


            if (VCM >= porcentajeVCMAlto)
            {
                lblSalidaVCM.Text = "↑ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Red;
            }



            if (VCM < 80m)
            {
                lblSalidaVCM.Text = "↓ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Yellow;
            }

            if (VCM <= porcentajeVCMBajo)
            {
                lblSalidaVCM.Text = "↓ " + VCM.ToString();
                lblSalidaVCM.ForeColor = Color.Red;
            }


            /***********************************VCM*************************************/



            /*********************************HTO**********************************************/

            decimal porcentajeHTOBajo = (36m * 0.80m);
            decimal porcentajeHTOAlto = (46m * 1.20m);




            if (HTO >= 36m && HTO <= 46m)
            {
                lblSalidaHTO.Text = HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Black;
            }


            if (HTO > 46m && HTO < porcentajeHTOAlto)
            {
                lblSalidaHTO.Text = "↑ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Yellow;
            }


            if (HTO >= porcentajeHTOAlto)
            {
                lblSalidaHTO.Text = "↑ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Red;
            }

            if (HTO < 36m)
            {
                lblSalidaHTO.Text = "↓ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Yellow;
            }

            if (HTO <= porcentajeHTOBajo)
            {
                lblSalidaHTO.Text = "↓ " + HTO.ToString();
                lblSalidaHTO.ForeColor = Color.Red;
            }

            /*********************************HTO**********************************************/



            /*********************************HB**********************************************/

            decimal porcentajeHBBajo = (13.0m * 0.80m);
            decimal porcentajeHBAlto = (16.0m * 1.20m);




            if (HB >= 13.0m && HB <= 16.0m)
            {
                lblSalidaHB.Text = HB.ToString();
                lblSalidaHB.ForeColor = Color.Black;
            }


            if (HB > 16.0m && HB < porcentajeHBAlto)
            {
                lblSalidaHB.Text = "↑ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Yellow;
            }


            if (HB >= porcentajeHBAlto)
            {
                lblSalidaHB.Text = "↑ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Red;
            }

            if (HB < 13.0m)
            {
                lblSalidaHB.Text = "↓ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Yellow;
            }

            if (HB <= porcentajeHBBajo)
            {
                lblSalidaHB.Text = "↓ " + HB.ToString();
                lblSalidaHB.ForeColor = Color.Red;
            }



            /*********************************HB**********************************************/



            /*********************************GBRBC**********************************************/

            decimal porcentajeGBRBCBajo = (4.5m * 0.80m);
            decimal porcentajeGBRBCAlto = (5.3m * 1.25m);




            if (GBRBC >= 4.5m && GBRBC <= 5.3m)
            {
                lblSalidaGBRBC.Text = GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Black;
            }


            if (GBRBC > 5.3m && GBRBC < porcentajeGBRBCAlto)
            {
                lblSalidaGBRBC.Text = "↑ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Yellow;
            }


            if (GBRBC >= porcentajeGBRBCAlto)
            {
                lblSalidaGBRBC.Text = "↑ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Red;
            }

            if (GBRBC < 4.5m)
            {
                lblSalidaGBRBC.Text = "↓ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Yellow;
            }

            if (GBRBC <= porcentajeGBRBCBajo)
            {
                lblSalidaGBRBC.Text = "↓ " + GBRBC.ToString();
                lblSalidaGBRBC.ForeColor = Color.Red;
            }

            /*********************************GBRBC**********************************************/



            /*********************************GBWB**********************************************/

            decimal porcentajeGBWBBajo = (4.5m * 0.45m);
            decimal porcentajeGBWBCAlto = (11.0m * 1.30m);




            if (GBWB >= 4.5m && GBWB <= 11.0m)
            {
                lblSalidaGBWB.Text = GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Black;
            }


            if (GBWB > 11.0m && GBWB < porcentajeGBWBCAlto)
            {
                lblSalidaGBWB.Text = "↑ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Yellow;
            }


            if (GBWB >= porcentajeGBWBCAlto)
            {
                lblSalidaGBWB.Text = "↑ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Red;
            }

            if (GBWB < 4.5m)
            {
                lblSalidaGBWB.Text = "↓ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Yellow;
            }

            if (GBWB <= porcentajeGBWBBajo)
            {
                lblSalidaGBWB.Text = "↓ " + GBWB.ToString();
                lblSalidaGBWB.ForeColor = Color.Red;
            }

            /*********************************GBWB**********************************************/
        }



        private int totalElementosContados()
        {
            int total = (cBlasto + cPromielocito + cMielocitoNeutrofilo + cMetamielocitoNeutrofilo + cNeutrofiloCayado
                        + cNeutrofiloSegmentado + cLinfocitos + cMonocitos + cEosinofilos + cBasofilos + cLinfocitosReactivos
                        + cCelulasPlasmaticas);
            return total;
        }



        public void total()
        {
            int total = (cBlasto + cPromielocito + cMielocitoNeutrofilo + cMetamielocitoNeutrofilo + cNeutrofiloCayado
                        + cNeutrofiloSegmentado + cLinfocitos + cMonocitos + cEosinofilos + cBasofilos + cLinfocitosReactivos
                        + cCelulasPlasmaticas);


            if (total == 100)
            {
                MetroFramework.MetroMessageBox.Show(this, "El conteo de elementos alcanzo los 100", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Question);
                btnPararConteo.Enabled = true;
            }
        }




        private void FormContadorElementos_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Q:
                    cBlasto++;
                    lblBlasto.Text = cBlasto.ToString();
                    lblUltimaTecla.Text = Keys.Q.ToString();
                    total();
                    mostrarPorcentaje();
                    alertaEritroblastos();
                    lblTotalElementos.Text = totalElementosContados().ToString();
                    break;
                case Keys.W:
                    cPromielocito++;
                    lblPromielocito.Text = cPromielocito.ToString();
                    lblUltimaTecla.Text = Keys.W.ToString();
                    total();
                    mostrarPorcentaje();
                    alertaEritroblastos();
                    lblTotalElementos.Text = totalElementosContados().ToString();
                    break;
                case Keys.E:
                    cMielocitoNeutrofilo++;
                    lblMielNeutrofilo.Text = cMielocitoNeutrofilo.ToString();
                    lblUltimaTecla.Text = Keys.E.ToString();
                    total();
                    mostrarPorcentaje();
                    alertaEritroblastos();
                    lblTotalElementos.Text = totalElementosContados().ToString();
                    break;
                case Keys.R:
                    cMetamielocitoNeutrofilo++;
                    lblMetaMielNeutrofilo.Text = cMetamielocitoNeutrofilo.ToString();
                    lblUltimaTecla.Text = Keys.R.ToString();
                    total();
                    mostrarPorcentaje();
                    alertaEritroblastos();
                    lblTotalElementos.Text = totalElementosContados().ToString();
                    break;
                case Keys.F:
                    cNeutrofiloCayado++;
                    lblNeutCayado.Text = cNeutrofiloCayado.ToString();
                    lblUltimaTecla.Text = Keys.F.ToString();
                    total();
                    mostrarPorcentaje();
                    alertaEritroblastos();
                    lblTotalElementos.Text = totalElementosContados().ToString();
                    break;
                case Keys.A:
                    cNeutrofiloSegmentado++;
                    lblNeutSegmentado.Text = cNeutrofiloSegmentado.ToString();
                    lblUltimaTecla.Text = Keys.A.ToString();
                    total();
                    mostrarPorcentaje();
                    alertaEritroblastos();
                    lblTotalElementos.Text = totalElementosContados().ToString();
                    break;
                case Keys.S:
                    cLinfocitos++;
                    lblLinfocitos.Text = cLinfocitos.ToString();
                    lblUltimaTecla.Text = Keys.S.ToString();
                    total();
                    mostrarPorcentaje();
                    alertaEritroblastos();
                    lblTotalElementos.Text = totalElementosContados().ToString();
                    break;
                case Keys.D:
                    cMonocitos++;
                    lblMonocito.Text = cMonocitos.ToString();
                    lblUltimaTecla.Text = Keys.D.ToString();
                    total();
                    mostrarPorcentaje();
                    alertaEritroblastos();
                    lblTotalElementos.Text = totalElementosContados().ToString();
                    break;
                case Keys.Z:
                    cEosinofilos++;
                    lblEosinofilos.Text = cEosinofilos.ToString();
                    lblUltimaTecla.Text = Keys.Z.ToString();
                    total();
                    mostrarPorcentaje();
                    alertaEritroblastos();
                    lblTotalElementos.Text = totalElementosContados().ToString();
                    break;
                case Keys.X:
                    cBasofilos++;
                    lblBasofilos.Text = cBasofilos.ToString();
                    lblUltimaTecla.Text = Keys.X.ToString();
                    total();
                    mostrarPorcentaje();
                    alertaEritroblastos();
                    lblTotalElementos.Text = totalElementosContados().ToString();
                    break;
                case Keys.C:
                    cLinfocitosReactivos++;
                    lblLinfReactivo.Text = cLinfocitosReactivos.ToString();
                    lblUltimaTecla.Text = Keys.C.ToString();
                    total();
                    mostrarPorcentaje();
                    alertaEritroblastos();
                    lblTotalElementos.Text = totalElementosContados().ToString();
                    break;
                case Keys.V:
                    cCelulasPlasmaticas++;
                    lblCelPlasmatica.Text = cCelulasPlasmaticas.ToString();
                    lblUltimaTecla.Text = Keys.V.ToString();
                    total();
                    mostrarPorcentaje();
                    alertaEritroblastos();
                    lblTotalElementos.Text = totalElementosContados().ToString();
                    break;
                case Keys.L:
                    cEritroblasto++;
                    lblEritroblastos.Text = cEritroblasto.ToString();
                    lblUltimaTecla.Text = Keys.L.ToString();
                    totalMasEritroblastos();
                    alertaEritroblastos();
                    break;
            }
        }





        private void btnValidarFormLeucocitaria_Click(object sender, EventArgs e)
        {

            if (bandera == false)
            {
                if (MetroFramework.MetroMessageBox.Show(this, "Desea validar la fórmula leucocitaria?", "Recuento visual", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Decimal bl = 100m * cBlasto / totalElementosContados();
                    Decimal pm = 100m * cPromielocito / totalElementosContados();
                    Decimal mo = 100m * cMielocitoNeutrofilo / totalElementosContados();
                    Decimal mt = 100m * cMetamielocitoNeutrofilo / totalElementosContados();
                    Decimal C = 100m * cNeutrofiloCayado / totalElementosContados();
                    Decimal S = 100m * cNeutrofiloSegmentado / totalElementosContados();
                    Decimal E = 100m * cEosinofilos / totalElementosContados();
                    Decimal B = 100m * cBasofilos / totalElementosContados();
                    Decimal L = 100m * cLinfocitos / totalElementosContados();
                    Decimal MN = 100m * cMonocitos / totalElementosContados();
                    Decimal linReac = 100m * cLinfocitosReactivos / totalElementosContados();
                    Decimal cplasm = 100m * cCelulasPlasmaticas / totalElementosContados();
                    Decimal eritBlasto = 100m * cEritroblasto / totalElementosContados();



                    Decimal gb = Convert.ToDecimal(txtGlobulosBlancos.Text, CultureInfo.InvariantCulture);
                    NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;


                    lblBL.Text = bl.ToString("N", nfi);
                    lblPm.Text = pm.ToString("N", nfi);
                    lblmo.Text = mo.ToString("N", nfi);
                    lblmt.Text = mt.ToString("N", nfi);
                    lblC.Text = C.ToString("N", nfi);
                    lblS.Text = S.ToString("N", nfi);
                    lblE.Text = E.ToString("N", nfi);
                    lblB.Text = B.ToString("N", nfi);
                    lblL.Text = L.ToString("N", nfi);
                    lblMN.Text = MN.ToString("N", nfi);
                    lblLR.Text = linReac.ToString("N", nfi);
                    lblCP.Text = cplasm.ToString("N", nfi);
                    lblEb.Text = eritBlasto.ToString("N", nfi);


                    Decimal salidaBL = bl * gb / 100m;
                    Decimal salidapm = pm * gb / 100m;
                    Decimal salidamo = mo * gb / 100m;
                    Decimal salidamt = mt * gb / 100m;
                    Decimal salidaC = C * gb / 100m;
                    Decimal salidaS = S * gb / 100m;
                    Decimal salidaE = E * gb / 100m;
                    Decimal salidaB = B * gb / 100m;
                    Decimal salidaL = L * gb / 100m;
                    Decimal salidaMN = MN * gb / 100m;
                    Decimal salidaLR = linReac * gb / 100m;
                    Decimal salidaCP = cplasm * gb / 100m;



                    lblSalidaBL.Text = salidaBL.ToString("N", nfi);
                    lblSalidaPm.Text = salidapm.ToString("N", nfi);
                    lblSalidamo.Text = salidamo.ToString("N", nfi);
                    lblSalidamt.Text = salidamt.ToString("N", nfi);
                    lblSalidaC.Text = salidaC.ToString("N", nfi);
                    lblSalidaS.Text = salidaS.ToString("N", nfi);
                    lblSalidaE.Text = salidaE.ToString("N", nfi);
                    lblSalidaB.Text = salidaB.ToString("N", nfi);
                    lblSalidaL.Text = salidaL.ToString("N", nfi);
                    lblSalidaMN.Text = salidaMN.ToString("N", nfi);
                    lblSalidaLR.Text = salidaLR.ToString("N", nfi);
                    lblSalidaCP.Text = salidaCP.ToString("N", nfi);

                    btnRetomarRecuento.Enabled = false;
                    btnValidarFormLeucocitaria.Enabled = false;
                    groupBoxRecReticulocitos.Enabled = true;
                    txtPorcReticulocitos.Enabled = true;
                    txtPorcReticulocitos.Focus();
                    btnCalcValorAbsoluto.Enabled = true;
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Se ha detectado una cantidad de ERITROBLASTOS,anormal, es necesario recalcular los GB.");
                button1.Focus();
            }
        }


        private void btnPausarConteo_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Pausar el conteo visual?", "Recuento visual", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.KeyPreview = false;
                btnPlay.Enabled = true;
                btnHabilitarEdicion.Enabled = false;
                btnPausarConteo.Enabled = false;
                btnPlay.Focus();
                //btnValidarFormLeucocitaria.Enabled = true;
            }
            else
            {

            }

        }


        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Desea continuar con el recuento?", "Recuento visual", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.KeyPreview = true;
                btnPausarConteo.Enabled = true;
                btnPlay.Enabled = false;
                btnHabilitarEdicion.Enabled = true;
                btnPausarConteo.Focus();
            }
            else
            {

            }

        }



        /*
        private void AnimacionOn()
        {
            pbxOFF.Hide();
            pbxON.Visible = true;
            lblMicrofono.Text = "ON";
        }


        private void AnimacionOff()
        {
            pbxON.Hide();
            pbxOFF.Visible = true;
            lblMicrofono.Text = "OFF";
            btnPausarConteo.Hide();
          //  btnConteoPorVoz.Visible = true;
        }
        */




        private bool validar(int v)
        {
            if (v == 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "No se puede seguir restando.", "Error");
                return false;
            }
            return true;
        }


        private void Escuchar()
        {

            Choices opcionesVoz = new Choices();
            opcionesVoz.Add(new string[] { "restar celula uno", "mostrar grupo oculto", "ocultar grupo" });
            Grammar gramatica = new Grammar(new GrammarBuilder(opcionesVoz));

            try
            {
                reco.SetInputToDefaultAudioDevice();
                reco.LoadGrammar(gramatica);
                reco.SpeechRecognized += lector;
                reco.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch (Exception)
            {
                MetroFramework.MetroMessageBox.Show(this, "error con el dispositivo de audio");
            }

        }



        public void lector(object sender, SpeechRecognizedEventArgs e)
        {

            if (e.Result.Text == "restar celula uno")
            {

                if (cBlasto == 0)
                {
                    MessageBox.Show("No se puede seguir restando", "Error");
                }
                else
                {
                    cBlasto--;
                    lblBlasto.Text = cBlasto.ToString();
                    lblUltimaTecla.Text = Keys.Q.ToString();
                    total();
                }

            }

        }


        private void btnHabilitarEdicion_Click(object sender, EventArgs e)
        {
            if (groupBoxBtsBorrar.Enabled != true)
            {
                if (MetroFramework.MetroMessageBox.Show(this, "Desea habilitar el borrado manual de los valores del contador?", "NOTIFICACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    groupBoxBtsBorrar.Enabled = true;
                }
            }
            else
            {
                groupBoxBtsBorrar.Enabled = false;
            }
        }


        private void btnHabilitarEdicion_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnHabilitarEdicion, "Habilita o deshabilita la edición de los valores de los elementos detectados.");
           
        }


        private void btnBorrarBlasto_Click(object sender, EventArgs e)
        {
            if (validar(cBlasto) != true)
            {

            }
            else
            {
                cBlasto--;
                lblBlasto.Text = cBlasto.ToString();
                lblUltimoElemBorrado.Text = Keys.Q.ToString();
                lblTotalElementos.Text = totalElementosContados().ToString();
                totalMasEritroblastos();
                total();
                alertaEritroblastos();
                mostrarPorcentaje();
                if (totalElementosContados() < 100)
                {
                    button1.Enabled = false;
                    btnPararConteo.Enabled = false;
                }
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            if (validar(cPromielocito) != true)
            {

            }
            else
            {
                cPromielocito--;
                lblPromielocito.Text = cPromielocito.ToString();
                lblUltimoElemBorrado.Text = Keys.W.ToString();
                lblTotalElementos.Text = totalElementosContados().ToString();
                total();
                alertaEritroblastos();
                mostrarPorcentaje();
                if (totalElementosContados() < 100)
                {
                    button1.Enabled = false;
                    btnPararConteo.Enabled = false;
                }
            }
        }


        private void btnBorrarMielocito_Click(object sender, EventArgs e)
        {
            if (validar(cMielocitoNeutrofilo) != true)
            {

            }
            else
            {
                cMielocitoNeutrofilo--;
                lblMielNeutrofilo.Text = cMielocitoNeutrofilo.ToString();
                lblUltimoElemBorrado.Text = Keys.E.ToString();
                lblTotalElementos.Text = totalElementosContados().ToString();
                total();
                alertaEritroblastos();
                mostrarPorcentaje();
                if (totalElementosContados() < 100)
                {
                    button1.Enabled = false;
                    btnPararConteo.Enabled = false;
                }
            }
        }


        private void btnBorrarMetamNeutrofilo_Click(object sender, EventArgs e)
        {
            if (validar(cMetamielocitoNeutrofilo) != true)
            {

            }
            else
            {
                cMetamielocitoNeutrofilo--;
                lblMetaMielNeutrofilo.Text = cMetamielocitoNeutrofilo.ToString();
                lblUltimoElemBorrado.Text = Keys.R.ToString();
                lblTotalElementos.Text = totalElementosContados().ToString();
                total();
                alertaEritroblastos();
                mostrarPorcentaje();
                if (totalElementosContados() < 100)
                {
                    button1.Enabled = false;
                    btnPararConteo.Enabled = false;
                }
            }
        }


        private void btnBorrarNeutCayado_Click(object sender, EventArgs e)
        {
            if (validar(cNeutrofiloCayado) != true)
            {

            }
            else
            {
                cNeutrofiloCayado--;
                lblNeutCayado.Text = cNeutrofiloCayado.ToString();
                lblUltimoElemBorrado.Text = Keys.F.ToString();
                lblTotalElementos.Text = totalElementosContados().ToString();
                total();
                alertaEritroblastos();
                mostrarPorcentaje();
                if (totalElementosContados() < 100)
                {
                    button1.Enabled = false;
                    btnPararConteo.Enabled = false;
                }
            }
        }


        private void btnBorrarNeutroSegmentado_Click(object sender, EventArgs e)
        {
            if (validar(cNeutrofiloSegmentado) != true)
            {

            }
            else
            {
                cNeutrofiloSegmentado--;
                lblNeutSegmentado.Text = cNeutrofiloSegmentado.ToString();
                lblUltimoElemBorrado.Text = Keys.A.ToString();
                lblTotalElementos.Text = totalElementosContados().ToString();
                total();
                alertaEritroblastos();
                mostrarPorcentaje();
                if (totalElementosContados() < 100)
                {
                    button1.Enabled = false;
                    btnPararConteo.Enabled = false;
                }
            }
        }


        private void btnBorrarEosinofilos_Click(object sender, EventArgs e)
        {
            if (validar(cEosinofilos) != true)
            {

            }
            else
            {
                cEosinofilos--;
                lblEosinofilos.Text = cEosinofilos.ToString();
                lblUltimoElemBorrado.Text = Keys.Z.ToString();
                lblTotalElementos.Text = totalElementosContados().ToString();
                total();
                alertaEritroblastos();
                mostrarPorcentaje();
                if (totalElementosContados() < 100)
                {
                    button1.Enabled = false;
                    btnPararConteo.Enabled = false;
                }
            }
        }


        private void btnBorrarBasofilos_Click(object sender, EventArgs e)
        {
            if (validar(cBasofilos) != true)
            {

            }
            else
            {
                cBasofilos--;
                lblBasofilos.Text = cBasofilos.ToString();
                lblUltimoElemBorrado.Text = Keys.X.ToString();
                lblTotalElementos.Text = totalElementosContados().ToString();
                total();
                alertaEritroblastos();
                mostrarPorcentaje();
                if (totalElementosContados() < 100)
                {
                    button1.Enabled = false;
                    btnPararConteo.Enabled = false;
                }
            }
        }


        private void btnBorrarLinfocitos_Click(object sender, EventArgs e)
        {
            if (validar(cLinfocitos) != true)
            {

            }
            else
            {
                cLinfocitos--;
                lblLinfocitos.Text = cLinfocitos.ToString();
                lblUltimoElemBorrado.Text = Keys.S.ToString();
                lblTotalElementos.Text = totalElementosContados().ToString();
                total();
                alertaEritroblastos();
                mostrarPorcentaje();
                if (totalElementosContados() < 100)
                {
                    button1.Enabled = false;
                    btnPararConteo.Enabled = false;
                }
            }
        }


        private void btnBorrarMonocito_Click(object sender, EventArgs e)
        {
            if (validar(cMonocitos) != true)
            {

            }
            else
            {
                cMonocitos--;
                lblMonocito.Text = cMonocitos.ToString();
                lblUltimoElemBorrado.Text = Keys.D.ToString();
                lblTotalElementos.Text = totalElementosContados().ToString();
                total();
                alertaEritroblastos();
                mostrarPorcentaje();
                if (totalElementosContados() < 100)
                {
                    button1.Enabled = false;
                    btnPararConteo.Enabled = false;
                }
            }
        }


        private void btnBorrarLinfReactivo_Click(object sender, EventArgs e)
        {
            if (validar(cLinfocitosReactivos) != true)
            {

            }
            else
            {
                cLinfocitosReactivos--;
                lblLinfReactivo.Text = cLinfocitosReactivos.ToString();
                lblUltimoElemBorrado.Text = Keys.C.ToString();
                lblTotalElementos.Text = totalElementosContados().ToString();
                total();
                alertaEritroblastos();
                mostrarPorcentaje();
                if (totalElementosContados() < 100)
                {
                    button1.Enabled = false;
                    btnPararConteo.Enabled = false;
                }
            }
        }


        private void btnBorrarCelPlasmatica_Click(object sender, EventArgs e)
        {
            if (validar(cCelulasPlasmaticas) != true)
            {

            }
            else
            {
                cCelulasPlasmaticas--;
                lblCelPlasmatica.Text = cCelulasPlasmaticas.ToString();
                lblUltimoElemBorrado.Text = Keys.V.ToString();
                lblTotalElementos.Text = totalElementosContados().ToString();
                total();
                alertaEritroblastos();
                mostrarPorcentaje();
                if (totalElementosContados() < 100)
                {
                    button1.Enabled = false;
                    btnPararConteo.Enabled = false;
                }
            }
        }


        private void btnBorrarEritroblastos_Click(object sender, EventArgs e)
        {
            if (validar(cEritroblasto) != true)
            {

            }
            else
            {
                cEritroblasto--;
                lblEritroblastos.Text = cEritroblasto.ToString();
                lblUltimoElemBorrado.Text = Keys.L.ToString();
                totalMasEritroblastos();
                bandera = false;
                if (cEritroblasto < Convert.ToDecimal(lblSalidaPorc.Text, CultureInfo.InvariantCulture))
                {
                    button1.Enabled = false;
                }
            }
        }


        private void btnCalcValorAbsoluto_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPorcReticulocitos.Text))
            {
                decimal rbc = Convert.ToDecimal(txtGBRBC.Text, CultureInfo.InvariantCulture);
                decimal porcRetic = Convert.ToDecimal(txtPorcReticulocitos.Text, CultureInfo.InvariantCulture);
                decimal calculo = Convert.ToDecimal(rbc * porcRetic / 100, CultureInfo.InvariantCulture);
                decimal calculoValorAbsoluto = Convert.ToDecimal(calculo * 1000, CultureInfo.InvariantCulture);
                // NumberFormatInfo asociado con la cultura en-US.
                NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
                // Mostrar un valor con el separador por defecto (".").
                Decimal miNum = calculo;


                lblCalValAbsSalida.Text = calculoValorAbsoluto.ToString("N", nfi);
                btnCalcValorAbsoluto.Enabled = false;
                txtPorcReticulocitos.Enabled = false;
                btnSiguiente.Enabled = true;
                btnSiguiente.Focus();
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "El campo porcentaje esta esta vacio.");
                txtPorcReticulocitos.Focus();
            }
        }



        /*----- AL DETECTARSE ERITROBLASTOS SE CAMBIAN VALORES ----INFORMATIVO CORRECCION DE GB----- */
        private decimal recalcularValores()
        {
            decimal total = Convert.ToDecimal(totalElementosContados(), CultureInfo.InstalledUICulture);
            // decimal diezPorCientoDeltotal
            decimal a = Convert.ToDecimal((cEritroblasto + total), CultureInfo.InstalledUICulture);
            decimal gb = Convert.ToDecimal(txtGlobulosBlancos.Text, CultureInfo.InvariantCulture);
            decimal salida;
            salida = Convert.ToDecimal(gb * total / a, CultureInfo.InvariantCulture);
            return salida;
        }




        private void button1_Click(object sender, EventArgs e)
        {
            MetroFramework.MetroMessageBox.Show(this, "Se Corregira el Valor de GB");
            decimal num = recalcularValores();
            // NumberFormatInfo asociado con la cultura en-US.
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;

            // Mostrar un valor con el separador por defecto (".").
            Decimal myInt = num;

            //Console.WriteLine(myInt.ToString("N", nfi));
            txtGlobulosBlancos.Text = myInt.ToString("N", nfi);
            txtGBWB.Text = myInt.ToString("N", nfi);
            cargarDatosHemograma();
            button1.Enabled = false;
            bandera = false;
        }

        private void btnPararConteo_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Desea terminar con el proceso de recuento visual?", "Recuento visual", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.KeyPreview = false;
                btnPlay.Enabled = false;
                btnPausarConteo.Enabled = false;
                btnPararConteo.Enabled = false;
                btnHabilitarEdicion.Enabled = false;
                btnRetomarRecuento.Enabled = true;
                btnValidarFormLeucocitaria.Enabled = true;
                btnValidarFormLeucocitaria.Focus();
                btnActivarVoz.Enabled = false;
            }
            else
            {

            }
        }

        private void btnCancelarRecuento_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Desea retomar el proceso de recuento visual?", "Recuento visual", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.KeyPreview = true;
                btnPlay.Enabled = false;
                btnPausarConteo.Enabled = true;
                btnPararConteo.Enabled = true;
                btnHabilitarEdicion.Enabled = true;
                btnRetomarRecuento.Enabled = false;
                btnValidarFormLeucocitaria.Enabled = false;
                btnActivarVoz.Enabled = true;
                this.Focus();
            }
            else
            {

            }
        }

        private void mostrarDatosEritroblastos(bool x)
        {
            FormAlteracionesPorSerie nuevo = new FormAlteracionesPorSerie();
            nuevo.label49.Visible = x;
            nuevo.label52.Visible = x;
            nuevo.lblEb.Visible = x;
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {

            if (MetroFramework.MetroMessageBox.Show(this, "Desea proseguir hacia el siguiente paso.?", "Notificación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FormAlteracionesPorSerie nuevo = new FormAlteracionesPorSerie();
                /********************VALORES HEMOGRAMA*********************/
                nuevo.lblCodigoGE.Text = this.lblCodigoGE.Text;
                nuevo.lblCodigoGenero.Text = this.lblCodigoGenero.Text;
                nuevo.txtRDW.Text = this.txtRDW.Text;
                nuevo.txtPLT.Text = this.txtPLT.Text;
                nuevo.txtCHCM.Text = this.txtCHCM.Text;
                nuevo.txtHCM.Text = this.txtHCM.Text;
                nuevo.txtVCM.Text = this.txtVCM.Text;
                nuevo.txtHTO.Text = this.txtHTO.Text;
                nuevo.txtHB.Text = this.txtHB.Text;
                nuevo.txtGBRBC.Text = this.txtGBRBC.Text;
                nuevo.txtGBWB.Text = this.txtGBWB.Text;
                nuevo.txtVPM.Text = this.txtVPM.Text;
                nuevo.lblSalidaVPM.Text = this.lblSalidaVPM.Text;
                nuevo.lblPaciente.Text = this.lblPaciente.Text;
                nuevo.LBLNroDoc.Text = this.LBLNroDoc.Text;
                //this.Hide();
                /***********************************************************/



                /******************VALORES CONTEO VISUAL********************/
                nuevo.lblBL.Text = this.lblBL.Text;
                nuevo.lblPm.Text = this.lblPm.Text;
                nuevo.lblmo.Text = this.lblmo.Text;
                nuevo.lblmt.Text = this.lblmt.Text;
                nuevo.lblC.Text = this.lblC.Text;
                nuevo.lblS.Text = this.lblS.Text;
                nuevo.lblE.Text = this.lblE.Text;
                nuevo.lblB.Text = this.lblB.Text;
                nuevo.lblL.Text = this.lblL.Text;
                nuevo.lblMN.Text = this.lblMN.Text;
                nuevo.lblLR.Text = this.lblLR.Text;
                nuevo.lblCP.Text = this.lblCP.Text;
                nuevo.lblEb.Text = this.lblEb.Text;

                nuevo.lblSalidaBL.Text = this.lblSalidaBL.Text;
                nuevo.lblSalidaPm.Text = this.lblSalidaPm.Text;
                nuevo.lblSalidamo.Text = this.lblSalidamo.Text;
                nuevo.lblSalidamt.Text = this.lblSalidamt.Text;
                nuevo.lblSalidaC.Text = this.lblSalidaC.Text;
                nuevo.lblSalidaS.Text = this.lblSalidaS.Text;
                nuevo.lblSalidaE.Text = this.lblSalidaE.Text;
                nuevo.lblSalidaB.Text = this.lblSalidaB.Text;
                nuevo.lblSalidaL.Text = this.lblSalidaL.Text;
                nuevo.lblSalidaMN.Text = this.lblSalidaMN.Text;
                nuevo.lblSalidaLR.Text = this.lblSalidaLR.Text;
                nuevo.lblSalidaCP.Text = this.lblSalidaCP.Text;

                nuevo.lblValorAbsoluto.Text = this.lblCalValAbsSalida.Text;
                nuevo.lblSalidaPorUsadoReti.Text = this.txtPorcReticulocitos.Text;


                if (cEritroblasto > 0)
                {
                    nuevo.label49.Visible = true;
                    nuevo.label52.Visible = true;
                    nuevo.lblEb.Visible = true;
                }
                else if (cEritroblasto == 0)
                {
                    nuevo.label49.Visible = false;
                    nuevo.label52.Visible = false;
                    nuevo.lblEb.Visible = false;
                }

                /***********************************************************/

              // this.Hide();
                this.Dispose();
                nuevo.ShowDialog();
            }
            else
            {

            }
        }

        private void txtPorcReticulocitos_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && txtPorcReticulocitos.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void lblUltimoElemBorrado_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(lblUltimoElemBorrado, "Muestra la letra correspondiente al último elemento borrado.");

        }

        private void btnPausarConteo_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnPausarConteo, "Pausar el conteo.");
        }

        private void btnPararConteo_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnPararConteo, "Se detiene el conteo para poder efectuar para validar la FL");
        }

        private void btnPlay_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnPlay, "Se retoma el conteo.");
        }

        private void btnRestablecer_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnRestablecer, "Establecer los valores por defecto.");
        }

        private void btnRetomarRecuento_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnRetomarRecuento, "Habilita al operador seguir con el conteo");
        }

        private void btnRestablecer_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Desea reiniciar los valores del contador?", "NOTIFICACION", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                restablecerValores();
            }
            else
            {

            }
            
        }

        private void restablecerValores()
        {
            cBlasto = 0;
            cPromielocito = 0;
            cMielocitoNeutrofilo = 0;
            cMetamielocitoNeutrofilo = 0;
            cNeutrofiloCayado = 0;
            cNeutrofiloSegmentado = 0;
            cLinfocitos = 0;
            cMonocitos = 0;
            cEosinofilos = 0;
            cBasofilos = 0;
            cLinfocitosReactivos = 0;
            cCelulasPlasmaticas = 0;
            cEritroblasto = 0;
            bandera = false;
            foreach (Control t in this.groupBox4.Controls)
            {
                if (t is Label)
                    ((Label)t).Text = "0";
            }

            foreach (Control t in this.groupBox3.Controls)
            {
                if (t is Label)
                    ((Label)t).Text = "...";
            }

            foreach (Control t in this.groupBox5.Controls)
            {
                if (t is Label)
                    ((Label)t).Text = "...";
            }
            lblUltimaTecla.Text = "...";
            lblUltimoElemBorrado.Text = "...";
            lblTotalElementos.Text = "0";
            lblSalidaPorc.Text = "0";
            lblTotalMasEritrob.Text = "0";
            txtPorcReticulocitos.Text = "";
            lblCalValAbsSalida.Text = "...";
            btnPararConteo.Enabled = false;
            btnValidarFormLeucocitaria.Enabled = false;
            groupBoxRecReticulocitos.Enabled = false;
            btnSiguiente.Enabled = false;
            txtGlobulosBlancos.Text = gb;
            txtGBWB.Text = gb;
            cargarDatosHemograma();
            button1.Enabled = false;
            this.KeyPreview = true;
            btnHabilitarEdicion.Enabled = true;
            btnActivarVoz.Enabled = true;
        }

        private void btnActivarVoz_Click(object sender, EventArgs e)
        {
            try
            {
                if (MetroFramework.MetroMessageBox.Show(this, "Desea activar el reconocimiento de voz?", "Activar Microfono", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    activarVoz();
                    lblMicrofono.Text = "ON";
                    lblMicrofono.BackColor = Color.Green;
                    btnActivarVoz.Hide();
                }
            }
            catch(Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, "El dispositivo no pudo ser iniciado correctamente por diferentes causas, si el sistema se encuentra en otro idioma, consulte a su técnico. " + ex.ToString() , "Opciones de voz error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void btnDesactivarMicrofono_Click(object sender, EventArgs e)
        {
            reco.RecognizeAsyncStop();
            lblMicrofono.Text = "OFF";
            lblMicrofono.BackColor = Color.Red;
            btnActivarVoz.Show();
        }

        private void eventoReloj(object sender, EventArgs e)
        {
            DateTime hoy = DateTime.Now;
            lblHoraActual.Text = hoy.ToString("H:mm");
        }

        private void fechaActual()
        {
            txtFecha.Text = DateTime.Today.ToShortDateString();
            Fecha.fecha = txtFecha.Text;
        }

        private void btnGuardarConteo_Click(object sender, EventArgs e)
        {
            if(totalElementosContados()<100)
            {
                MetroFramework.MetroMessageBox.Show(this, "Los elementos deben ser 100 para poder guardar", "Guardar datos contador");
            }
            else
            {
                Conteo.fecha = txtFecha.Text;
                Conteo.hora = lblHoraActual.Text;
                Conteo.paciente = lblPaciente.Text;
                Conteo.dni = LBLNroDoc.Text;
                Conteo.blasto = Convert.ToInt32(lblBlasto.Text);
                Conteo.promielocito = Convert.ToInt32(lblPromielocito.Text);
                Conteo.mielNeutro = Convert.ToInt32(lblMielNeutrofilo.Text);
                Conteo.metamielNeutro = Convert.ToInt32(lblMetaMielNeutrofilo.Text);
                Conteo.neutCayado = Convert.ToInt32(lblNeutCayado.Text);
                Conteo.neuSegm = Convert.ToInt32(lblNeutSegmentado.Text);
                Conteo.eosinofilo = Convert.ToInt32(lblEosinofilos.Text);
                Conteo.basofilo = Convert.ToInt32(lblBasofilos.Text);
                Conteo.linfocito = Convert.ToInt32(lblLinfocitos.Text);
                Conteo.monocito = Convert.ToInt32(lblMonocito.Text);
                Conteo.linfReac = Convert.ToInt32(lblLinfReactivo.Text);
                Conteo.celPLasmatica = Convert.ToInt32(lblCelPlasmatica.Text);
                Conteo.eritroblasto = Convert.ToInt32(lblEritroblastos.Text);
                FormConteoGuardar nuevo = new FormConteoGuardar();
                nuevo.ShowDialog();
            }
        }

        private void btnMostrarConteos_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnMostrarConteos, "Listado Con los conteos efectuados");
        }

        private void btnMostrarConteos_Click(object sender, EventArgs e)
        {
            FormListadoConteos nueva = new FormListadoConteos();
            nueva.fecha = this.txtFecha.Text;
            nueva.dni = this.LBLNroDoc.Text;
            nueva.ShowDialog();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Se volvera a la Selección de pacientes", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
               // this.Close();
                this.Dispose();
                FormHematoHome nuevo = new FormHematoHome();
                nuevo.ShowDialog();
            }
            else
            {
                
            }  
        }

    

     
    }
}

