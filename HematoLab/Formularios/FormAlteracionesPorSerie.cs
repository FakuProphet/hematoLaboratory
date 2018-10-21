using HematoLab.Clases;
using HematoLab.Gestores;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace HematoLab.Formularios
{
    public partial class FormAlteracionesPorSerie : Form
    {

        GestorHemato miGestor;

        public FormAlteracionesPorSerie()
        {
            InitializeComponent();
            miGestor = new GestorHemato();
        }

        private void FormAlteracionesPorSerie_Load(object sender, EventArgs e)
        {
            cargarDatosHemograma();
            nombreYLegajoProfesional();
            cboSeleccionSerie.SelectedIndex = 0;
            combosValorPorDefecto();
        }

        private void nombreYLegajoProfesional()
        {
            ULD nuevo = new ULD();
            nuevo = miGestor.GetNombreRealUsuarioLogueado(UserLoguedInn.usuario);
            if (nuevo != null)
            {
                lblRealizadoPor.Text = nuevo.nombreCompleto.ToString().ToUpper();
                lblLegajo.Text = nuevo.legajoSistema.ToString();
                DatoDTO.legajoDigitalProfesional = Convert.ToInt32(lblLegajo.Text);
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

      

       

        private void cboAltLeucocitos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int parametro = cboAlt1L.SelectedIndex;
           
                if (parametro==1)
                {
                    cboAltSev1L.Enabled = true;
                    cboAltSev1L.SelectedIndex=1;
                }
                else
                {
                    cboAltSev1L.Enabled = false;
                    cboAltSev1L.SelectedIndex = 0;
                }
            
        }

        private void cboNeutrofilos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int parametro = cboAlt2L.SelectedIndex;

            if (parametro == 1)
            {
                cboAltSev2L.Enabled = true;
                cboAltSev2L.SelectedIndex = 1;
            }
            else
            {
                cboAltSev2L.Enabled = false;
                cboAltSev2L.SelectedIndex = 0;
            }

        }

        private void cboEritrocitariaAlt1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int parametro = cboAlt1E.SelectedIndex;

            if (parametro == 0)
            {
                cboAltSev1E.Enabled = false;
                cboAltSev1E.SelectedIndex = 0;
            }
            if(parametro==1)
            {
                cboAltSev1E.Enabled = true;
                cboAltSev1E.SelectedIndex = 1;
            }
        }

     
        private void cboPlaquetariaAlteraciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            int parametro = cboAlt1P.SelectedIndex;

            if(parametro==0)
            {
                cboAlt1SevP.Enabled = false;
                cboAlt1SevP.SelectedIndex = 0;
            }
            if(parametro>0)
            {
                cboAlt1SevP.Enabled = true;
                cboAlt1SevP.SelectedIndex = 1;
            }
        }

        private void cboSeleccionSerie_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = cboSeleccionSerie.SelectedIndex;

            if(indice==0)
            {
                gpbSerieEritrocitaria.Enabled = false;
                gpbSerieLeucocitaria.Enabled = false;
                gpbSeriePlaquetaria.Enabled = false;
            }
            if (indice == 1)
            {
                gpbSerieEritrocitaria.Enabled = false;
                gpbSerieLeucocitaria.Enabled = true;
                gpbSeriePlaquetaria.Enabled = false;
            }
            if (indice == 2)
            {
                gpbSerieEritrocitaria.Enabled = true;
                gpbSerieLeucocitaria.Enabled = false;
                gpbSeriePlaquetaria.Enabled = false;
            }
            if (indice == 3)
            {
                gpbSerieEritrocitaria.Enabled = false;
                gpbSerieLeucocitaria.Enabled = false;
                gpbSeriePlaquetaria.Enabled = true;
            }
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {


            try
            {

                if (!string.IsNullOrEmpty(txtObsSerieLeuc.Text))
                {
                    string paciente = lblPaciente.Text;
                    int dni = Convert.ToInt32(LBLNroDoc.Text);
                    int nroOrden = DatoDTO.numeroDeOrden;

                    Estudio nuevo = new Estudio();
                    nuevo.legajoProfesional = Convert.ToInt32(lblLegajo.Text);
                    nuevo.numeroDocumento = Convert.ToInt32(LBLNroDoc.Text);
                    nuevo.codigoGenero = DatoDTO.codigoGenero;
                    nuevo.codigoGrupoEtario = DatoDTO.codigoGrupoEtario;
                    nuevo.cantidadGBWB = txtGBWB.Text;
                    nuevo.cantidadGRRBC = txtGBRBC.Text;
                    nuevo.cantidadHB = txtHB.Text;
                    nuevo.cantidadHTO = txtHTO.Text;
                    nuevo.cantidadVCM = txtVCM.Text;
                    nuevo.cantidadHCM = txtHCM.Text;
                    nuevo.cantidadCHCM = txtCHCM.Text;
                    nuevo.cantidadRDW = txtRDW.Text;
                    nuevo.cantidadPLT = txtPLT.Text;
                    nuevo.cantidadVPM = txtVPM.Text;
                    nuevo.cantidadBlasto = lblBL.Text;
                    nuevo.cantidadPromielocito = lblPm.Text;
                    nuevo.cantidadMielocito = lblmo.Text;
                    nuevo.cantidadMetamielocito = lblmt.Text;
                    nuevo.cantidadNeutrofiloCayado = lblC.Text;
                    nuevo.cantidadNeutrofiloSegmetado = lblS.Text;
                    nuevo.cantidadEosinofilos = lblE.Text;
                    nuevo.cantidadBasofilos = lblB.Text;
                    nuevo.cantidadLinfocitos = lblL.Text;
                    nuevo.cantidadMonocito = lblMN.Text;
                    nuevo.cantidadLinfocitoReactivo = lblLR.Text;
                    nuevo.cantidadCelulaPlasmatica = lblCP.Text;
                    nuevo.cantidadEritroblasto = lblEb.Text;
                    nuevo.Alt1L = cboAlt1L.Text;
                    nuevo.Alt1SevL = cboAltSev1L.Text;
                    nuevo.Alt2L = cboAlt2L.Text;
                    nuevo.Alt2SevL = cboAltSev2L.Text;
                    if (ckbEosinofilia.Checked)
                    {
                        nuevo.eosinofilia = ckbEosinofilia.Text;
                    }
                    else
                    {
                        nuevo.eosinofilia = "s/p";
                    }

                    if (ckbMonocitosis.Checked)
                    {
                        nuevo.monocitosis = ckbMonocitosis.Text;
                    }
                    else
                    {
                        nuevo.monocitosis = "s/p";
                    }
                    nuevo.Alt3L = cboAlt3L.Text;
                    if (ckbGTNC.Checked)
                    {
                        nuevo.GTNC = ckbGTNC.Text;
                    }
                    else
                    {
                        nuevo.GTNC = "s/p";
                    }

                    if (ckbSOVNS.Checked)
                    {
                        nuevo.SOVNS = ckbSOVNS.Text;
                    }
                    else
                    {
                        nuevo.SOVNS = "s/p";
                    }

                    if (ckbSOSG.Checked)
                    {
                        nuevo.SOSG = ckbSOSG.Text;
                    }
                    else
                    {
                        nuevo.SOSG = "s/p";
                    }

                    if (ckbSOCD.Checked)
                    {
                        nuevo.SOCD = ckbSOCD.Text;
                    }
                    else
                    {
                        nuevo.SOCD = "s/p";
                    }

                    nuevo.observacionesSerieLeucocitaria = txtObsSerieLeuc.Text;
                    nuevo.Alt1E = cboAlt1E.Text;
                    nuevo.Alt1SevE = cboAltSev1E.Text;
                    nuevo.Alt2E = cboAlt2E.Text;
                    nuevo.Alt2SevE = cboAltSev2E.Text;
                    nuevo.Alt3E = cboAlt3E.Text;
                    nuevo.Alt3SevE = cboAltSev3E.Text;
                    nuevo.Alt4E = cboAlt4E.Text;
                    nuevo.Alt4SevE = cboAltSev4E.Text;
                    nuevo.Alt5E = cboAlt5E.Text;
                    nuevo.Alt5SevE = cboAltSev5E.Text;
                    nuevo.Alt6E = cboAlt6E.Text;
                    nuevo.Alt6SevE = cboAltSev6E.Text;

                    if (ckbEsferocitos.Checked)
                    {
                        nuevo.esferocitos = ckbEsferocitos.Text;
                    }
                    else
                    {
                        nuevo.esferocitos = "s/p";
                    }
                    if (ckbDacriocitos.Checked)
                    {
                        nuevo.dacriocitos = ckbDacriocitos.Text;
                    }
                    else
                    {
                        nuevo.dacriocitos = "s/p";
                    }
                    if (ckbTargetCell.Checked)
                    {
                        nuevo.targetCell = ckbTargetCell.Text;
                    }
                    else
                    {
                        nuevo.targetCell = "s/p";
                    }
                    if (ckbEstomatocitos.Checked)
                    {
                        nuevo.estomatocitos = ckbEstomatocitos.Text;
                    }
                    else
                    {
                        nuevo.estomatocitos = "s/p";
                    }
                    if (ckbEsquistocitos.Checked)
                    {
                        nuevo.esquistocitos = ckbEsquistocitos.Text;
                        nuevo.esquistocitosPorcentaje = txtPorcEsquistocitos.Text + "%";
                    }
                    else
                    {
                        nuevo.esquistocitos = "s/p";
                      //  txtPorcEsquistocitos.Text="";
                    }
                    //if(!ckbEsquistocitos.Checked)
                    //{
                    //    txtPorcEsquistocitos.Text="";
                    //}

                    if (ckbEliptocitos.Checked)
                    {
                        nuevo.eliptocitos = ckbEliptocitos.Text;
                    }
                    else
                    {
                        nuevo.eliptocitos = "s/p";
                    }
                    if (ckbDrepanocitos.Checked)
                    {
                        nuevo.drepanocitos = ckbDrepanocitos.Text;
                    }
                    else
                    {
                        nuevo.drepanocitos = "s/p";
                    }
                    if (ckbEquinocito.Checked)
                    {
                        nuevo.equinocito = ckbEquinocito.Text;
                    }
                    else
                    {
                        nuevo.equinocito = "s/p";
                    }
                    if (ckbPunteadoBasofilo.Checked)
                    {
                        nuevo.punteadoBasofilo = ckbPunteadoBasofilo.Text;
                    }
                    else
                    {
                        nuevo.punteadoBasofilo = "s/p";
                    }
                    if (ckbAnillosDeCabot.Checked)
                    {
                        nuevo.anillosDeCabot = ckbAnillosDeCabot.Text;
                    }
                    else
                    {
                        nuevo.anillosDeCabot = "s/p";
                    }
                    if (ckbCuerposDeHJ.Checked)
                    {
                        nuevo.cuerposDeHJ = ckbCuerposDeHJ.Text;
                    }
                    else
                    {
                        nuevo.cuerposDeHJ = "s/p";
                    }
                    nuevo.obsSerieEritrocitaria = txtObsSerieEritrocitaria.Text;
                    nuevo.Alt1P = cboAlt1P.Text;
                    nuevo.Alt1SevP = cboAlt1SevP.Text;

                    if (ckbMacroplaquetas.Checked)
                    {
                        nuevo.macroplaquetas = ckbMacroplaquetas.Text;
                    }
                    else
                    {
                        nuevo.macroplaquetas = "s/p";
                    }
                    nuevo.obsSeriePlaquetaria = txtObservacionesPlaquetaria.Text;
                    nuevo.valAbsReti = lblValorAbsoluto.Text;

                    if (ckbEsquistocitos.Checked && String.IsNullOrEmpty(txtPorcEsquistocitos.Text))
                    {
                        MetroFramework.MetroMessageBox.Show(this, "El campo de valor porcentaje de esquistocitos no debe esta estar vacio", "Campo vacio", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        txtPorcEsquistocitos.Focus();
                    }
                    else
                    {
                        if (MetroFramework.MetroMessageBox.Show(this, "Desea concluir el estudio del paciente: " + paciente.ToString().ToUpper() + " documento número: " + dni.ToString() + " ?", "Estudio Hematológico", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string query = "insert into Estudios(legajoProfesional,dni,codGrupoEtario,genero,gbwb,grrbc,hb,hto,vcm,hcm,chcm,rdw,plt,vpm," +
                             "blastos,promielocitos,mielocitos,metamielocitos,neutrofilosCallados,neutrofilosSegmentados,eosinofilos,basofilos,linfocitos," +
                             "monocitos,celulasPlasmaticas,linfocitosReactivos,eritroblasto,alt1L,alt1SevL,alt2L,alt2SevL,eosinofilias,monocitosis,alt3L," +
                             "gtnc,sovns,sosg,socd,obsSerieLeuc,alt1E,alt1SevE,alt2E,alt2SevE,alt3E,alt3SevE,alt4E,alt4SevE,alt5E,alt5SevE,alt6E,alt6SevE," +
                             "esferocitos,dacriocitos,targetCell,estomatocitos,esquistocitos,esquistocitosPorc,eliptocitos,drepanocitos,equinocito,punteadobasofilo," +
                             "anillosDeCabot,cuerposDeHJ,obsSerieEritro,alt1P,alt1SevP,macroplaquetas,obsSeriePlaq,valAbsReti)values("

                             + nuevo.legajoProfesional + ","
                             + nuevo.numeroDocumento + ","
                             + nuevo.codigoGrupoEtario + ","
                             + nuevo.codigoGenero + ",'"
                             + nuevo.cantidadGBWB + "','"
                             + nuevo.cantidadGRRBC + "','"
                             + nuevo.cantidadHB + "','"
                             + nuevo.cantidadHTO + "','"
                             + nuevo.cantidadVCM + "','"
                             + nuevo.cantidadHCM + "','"
                             + nuevo.cantidadCHCM + "','"
                             + nuevo.cantidadRDW + "','"
                             + nuevo.cantidadPLT + "','"
                             + nuevo.cantidadVPM + "','"
                             + nuevo.cantidadBlasto + "','"
                             + nuevo.cantidadPromielocito + "','"
                             + nuevo.cantidadMielocito + "','"
                             + nuevo.cantidadMetamielocito + "','"
                             + nuevo.cantidadNeutrofiloCayado + "','"
                             + nuevo.cantidadNeutrofiloSegmetado + "','"
                             + nuevo.cantidadEosinofilos + "','"
                             + nuevo.cantidadBasofilos + "','"
                             + nuevo.cantidadLinfocitos + "','"
                             + nuevo.cantidadMonocito + "','"
                             + nuevo.cantidadCelulaPlasmatica + "','"
                             + nuevo.cantidadLinfocitoReactivo + "','"
                             + nuevo.cantidadEritroblasto + "','"
                             + nuevo.Alt1L + "','"
                             + nuevo.Alt1SevL + "','"
                             + nuevo.Alt2L + "','"
                             + nuevo.Alt2SevL + "','"
                             + nuevo.eosinofilia + "','"
                             + nuevo.monocitosis + "','"
                             + nuevo.Alt3L + "','"
                             + nuevo.GTNC + "','"
                             + nuevo.SOVNS + "','"
                             + nuevo.SOSG + "','"
                             + nuevo.SOCD + "','"
                             + nuevo.observacionesSerieLeucocitaria + "','"
                             + nuevo.Alt1E + "','"
                             + nuevo.Alt1SevE + "','"
                             + nuevo.Alt2E + "','"
                             + nuevo.Alt2SevE + "','"
                             + nuevo.Alt3E + "','"
                             + nuevo.Alt3SevE + "','"
                             + nuevo.Alt4E + "','"
                             + nuevo.Alt4SevE + "','"
                             + nuevo.Alt5E + "','"
                             + nuevo.Alt5SevE + "','"
                             + nuevo.Alt6E + "','"
                             + nuevo.Alt6SevE + "','"
                             + nuevo.esferocitos + "','"
                             + nuevo.dacriocitos + "','"
                             + nuevo.targetCell + "','"
                             + nuevo.estomatocitos + "','"
                             + nuevo.esquistocitos + "','"
                             + nuevo.esquistocitosPorcentaje + "','"
                             + nuevo.eliptocitos + "','"
                             + nuevo.drepanocitos + "','"
                             + nuevo.equinocito + "','"
                             + nuevo.punteadoBasofilo + "','"
                             + nuevo.anillosDeCabot + "','"
                             + nuevo.cuerposDeHJ + "','"
                             + nuevo.obsSerieEritrocitaria + "','"
                             + nuevo.Alt1P + "','"
                             + nuevo.Alt1SevP + "','"
                             + nuevo.macroplaquetas + "','"
                             + nuevo.obsSeriePlaquetaria + "','"
                             + nuevo.valAbsReti + "'"
                              + ")";

                            miGestor.actualizarBD(query);
                            miGestor.ConcluirEstudio(1, DatoDTO.numeroDeOrden);
                            MetroFramework.MetroMessageBox.Show(this, "Se ha registrado exitosamente el estudio, se vuelve a la selección de pacientes.", "Registrar estudio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                            this.Dispose();
                            FormHematoHome frmHematoHome = new FormHematoHome();
                            frmHematoHome.ShowDialog();
                        }
                    }

                }

                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "El campo de valor de eritrosedimentación no debe esta estar vacio", "Campo vacio", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    txtObsSerieLeuc.Focus();
                }
            }
            catch (Exception exc)
            {
                MetroFramework.MetroMessageBox.Show(this, "El estudio no se ha registrado: " + exc.ToString() , "Error al registrar estudio", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
          
        }

        private void cboAlt2E_SelectedIndexChanged(object sender, EventArgs e)
        {
            int parametro = cboAlt2E.SelectedIndex;

            if (parametro == 0)
            {
                cboAltSev2E.Enabled = false;
                cboAltSev2E.SelectedIndex = 0;
            }
            if (parametro > 0)
            {
                cboAltSev2E.Enabled = true;
                cboAltSev2E.SelectedIndex = 1;
            }
        }

        private void cboAlt3E_SelectedIndexChanged(object sender, EventArgs e)
        {
            int parametro = cboAlt3E.SelectedIndex;

            if (parametro == 0)
            {
                cboAltSev3E.Enabled = false;
                cboAltSev3E.SelectedIndex = 0;
            }
            if (parametro > 0)
            {
                cboAltSev3E.Enabled = true;
                cboAltSev3E.SelectedIndex = 1;
            }
        }

        private void cboAlt4E_SelectedIndexChanged(object sender, EventArgs e)
        {
            int parametro = cboAlt4E.SelectedIndex;

            if (parametro == 0)
            {
                cboAltSev4E.Enabled = false;
                cboAltSev4E.SelectedIndex = 0;
            }
            if (parametro > 0)
            {
                cboAltSev4E.Enabled = true;
                cboAltSev4E.SelectedIndex = 1;
            }
        }

        private void cboAlt5E_SelectedIndexChanged(object sender, EventArgs e)
        {
            int parametro = cboAlt5E.SelectedIndex;

            if (parametro == 0)
            {
                cboAltSev5E.Enabled = false;
                cboAltSev5E.SelectedIndex = 0;
            }
            if (parametro > 0)
            {
                cboAltSev5E.Enabled = true;
                cboAltSev5E.SelectedIndex = 1;
            }
        }

        private void cboAlt6E_SelectedIndexChanged(object sender, EventArgs e)
        {
            int parametro = cboAlt6E.SelectedIndex;

            if (parametro == 0)
            {
                cboAltSev6E.Enabled = false;
                cboAltSev6E.SelectedIndex = 0;
            }
            if (parametro > 0)
            {
                cboAltSev6E.Enabled = true;
                cboAltSev6E.SelectedIndex = 1;
            }
        }

        private void combosValorPorDefecto()
        {
            cboAlt1E.SelectedIndex = 0;
            cboAlt2E.SelectedIndex = 0;
            cboAlt3E.SelectedIndex = 0;
            cboAlt4E.SelectedIndex = 0;
            cboAlt5E.SelectedIndex = 0;
            cboAlt6E.SelectedIndex = 0;
            cboAltSev1E.SelectedIndex = 0;
            cboAltSev2E.SelectedIndex = 0;
            cboAltSev3E.SelectedIndex = 0;
            cboAltSev4E.SelectedIndex = 0;
            cboAltSev5E.SelectedIndex = 0;
            cboAltSev6E.SelectedIndex = 0;

            cboAlt1P.SelectedIndex = 0;
            cboAlt1SevP.SelectedIndex = 0;

            cboAlt1L.SelectedIndex = 0;
            cboAlt2L.SelectedIndex = 0;
            cboAlt3L.SelectedIndex = 0;
            cboAltSev1L.SelectedIndex = 0;
            cboAltSev2L.SelectedIndex = 0;
        }

        private void txtPorcEsquistocitos_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && txtPorcEsquistocitos.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Desea volver nuevamente al contador y analizador de elementos?", "Volver Contador elementos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FormContadorElementos nuevoFCE = new FormContadorElementos();
                nuevoFCE.lblCodigoGE.Text = this.lblCodigoGE.Text;
                nuevoFCE.lblCodigoGenero.Text = this.lblCodigoGenero.Text;
                nuevoFCE.txtRDW.Text = this.txtRDW.Text;
                nuevoFCE.txtPLT.Text = this.txtPLT.Text;
                nuevoFCE.txtCHCM.Text = this.txtCHCM.Text;
                nuevoFCE.txtHCM.Text = this.txtHCM.Text;
                nuevoFCE.txtVCM.Text = this.txtVCM.Text;
                nuevoFCE.txtHTO.Text = this.txtHTO.Text;
                nuevoFCE.txtHB.Text = this.txtHB.Text;
                nuevoFCE.txtGBRBC.Text = this.txtGBRBC.Text;
                nuevoFCE.txtGBWB.Text = GB.valorGB.ToString();
                nuevoFCE.txtVPM.Text = this.txtVPM.Text;
                nuevoFCE.txtGlobulosBlancos.Text = GB.valorGB.ToString();
                nuevoFCE.lblSalidaVPM.Text = this.lblSalidaVPM.Text;
                nuevoFCE.lblPaciente.Text = this.lblPaciente.Text;
                nuevoFCE.LBLNroDoc.Text = this.LBLNroDoc.Text;
                this.Dispose();
                nuevoFCE.ShowDialog();
            }
            else
            {

            }
        }
        

        private void cboAltSev1E_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboAltSev1E.SelectedIndex==0)
            {
                cboAlt1E.SelectedIndex = 0;
                cboAltSev1E.Enabled = false;
                cboAlt1E.Focus();
            }
        }

        private void ckbEsquistocitos_CheckedChanged(object sender, EventArgs e)
        {
            if(ckbEsquistocitos.Checked)
            {
                txtPorcEsquistocitos.Enabled = true;
                txtPorcEsquistocitos.Focus();
            }
            else
            {
                txtPorcEsquistocitos.Enabled = false;
                txtPorcEsquistocitos.Clear();
            }
        }

        private void cboAltSev2E_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAltSev2E.SelectedIndex == 0)
            {
                cboAlt2E.SelectedIndex = 0;
                cboAltSev2E.Enabled = false;
                cboAlt2E.Focus();
            }
        }

        private void cboAltSev3E_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAltSev3E.SelectedIndex == 0)
            {
                cboAlt3E.SelectedIndex = 0;
                cboAltSev3E.Enabled = false;
                cboAlt3E.Focus();
            }
        }

        private void cboAltSev4E_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAltSev4E.SelectedIndex == 0)
            {
                cboAlt4E.SelectedIndex = 0;
                cboAltSev4E.Enabled = false;
                cboAlt4E.Focus();
            }
        }

        private void cboAltSev5E_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAltSev5E.SelectedIndex == 0)
            {
                cboAlt5E.SelectedIndex = 0;
                cboAltSev5E.Enabled = false;
                cboAlt5E.Focus();
            }
        }

        private void cboAltSev6E_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAltSev6E.SelectedIndex == 0)
            {
                cboAlt6E.SelectedIndex = 0;
                cboAltSev6E.Enabled = false;
                cboAlt6E.Focus();
            }
        }

        private void cboAlt1SevP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboAlt1SevP.SelectedIndex == 0)
            {
                cboAlt1P.SelectedIndex = 0;
                cboAlt1SevP.Enabled = false;
                cboAlt1P.Focus();
            }
        }

        int x = 0;
        int y = 0;
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button!= MouseButtons.Left)
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

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtObsSerieLeuc_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            //{
            //    MessageBox.Show("Solo se permiten numeros.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    e.Handled = true;
            //    txtObsSerieLeuc.Focus();
            //    return;
            //}
            char ch = e.KeyChar;

            if (ch == 46 && txtObsSerieLeuc.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
            if (e.KeyChar == '-')
            {

                e.Handled = false;

            }
        }



      

        //private void btnVolver_Click(object sender, EventArgs e)
        //{
        //    if (MetroFramework.MetroMessageBox.Show(this, "Desea abandonar y volver a iniciar el estudio nuevamente?", "Reiniciar Estudio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //    {
        //        this.Close();
        //        this.Dispose();
        //    }
        //    else
        //    {

        //    }
        //}
    }
}
