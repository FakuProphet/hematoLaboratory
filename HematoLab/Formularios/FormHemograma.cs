using HematoLab.Clases;
using HematoLab.Gestores;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace HematoLab.Formularios
{
    public partial class FormHemograma : MetroFramework.Forms.MetroForm
    {


        GestorHemato gestor;


        public FormHemograma()
        {
            InitializeComponent();
            gestor = new GestorHemato();
        }


        private void FormHemograma_Load(object sender, EventArgs e)
        {
            cargarCombos();
            txtGBWB.Focus();
          //  mostrarDatosPaciente();
        }

        void mostrarDatosPaciente()
        {
            lblNroOrden.Text = DatoDTO.numeroDeOrden.ToString();
            lblGEN.Text = DatoDTO.codigoGenero.ToString();
            lblGET.Text = DatoDTO.codigoGrupoEtario.ToString();
            lblPAC.Text = DatoDTO.codigoPaciente.ToString();
        }
        
        private void cargarCombos()
        {
            cargarCombo(cboGrupoEtario,"GrupoEtario");
            cargarCombo(cboGenero, "Generos");
            cargarCombo(cboEdadEn, "EdadEn");
            cboGenero.SelectedValue = DatoDTO.codigoGenero;
        }


        private void cargarCombo(ComboBox combo, string nombreTabla)
        {
            DataTable tabla = new DataTable();
            tabla = gestor.consultarTabla(nombreTabla);
            combo.DataSource = tabla;
            combo.DisplayMember = tabla.Columns[1].ColumnName;
            combo.ValueMember = tabla.Columns[0].ColumnName;
            combo.DropDownStyle = ComboBoxStyle.DropDownList;
            combo.SelectedIndex = 0;
        }


        private bool validar()
        {
            bool b = false;
            
            if (string.IsNullOrEmpty(txtGBWB.Text))
            {
                MessageBox.Show("Debe completar el campo GBWB");
                b = false;
                txtGBWB.Focus();
            }

            else if (string.IsNullOrEmpty(txtGBRBC.Text))
            {
                MessageBox.Show("Debe completar el campo GBRBC");
                b = false;
                txtGBRBC.Focus();
            }

            else if (string.IsNullOrEmpty(txtHB.Text))
            {
                MessageBox.Show("Debe completar el campo HB");
                b = false;
                txtHB.Focus();
            }

            else if (string.IsNullOrEmpty(txtHTO.Text))
            {
                MessageBox.Show("Debe completar el campo HTO");
                b = false;
                txtHTO.Focus();
            }

            else if (string.IsNullOrEmpty(txtVCM.Text))
            {
                MessageBox.Show("Debe completar el campo VCM");
                b = false;
                txtVCM.Focus();
            }

            else if (string.IsNullOrEmpty(txtHCM.Text))
            {
                MessageBox.Show("Debe completar el campo HCM");
                b = false;
                txtHCM.Focus();
            }

            else if (string.IsNullOrEmpty(txtCHCM.Text))
            {
                MessageBox.Show("Debe completar el campo CHCM");
                b = false;
                txtCHCM.Focus();
            }

            else if (string.IsNullOrEmpty(txtRDW.Text))
            {
                MessageBox.Show("Debe completar el campo RDW");
                b = false;
                txtRDW.Focus();
            }

            else if (string.IsNullOrEmpty(txtPLT.Text))
            {
                MessageBox.Show("Debe completar el campo PLT");
                b = false;
                txtPLT.Focus();
            }
           
            else if (string.IsNullOrEmpty(txtVPM.Text))
            {
                MessageBox.Show("Debe completar el campo VPM");
                b = false;
                txtVPM.Focus();
            }
            else
            {
                b = true;
            }

            return b;
        }


        private void btnAnalizar_Click(object sender, EventArgs e)
        {
           if(validar())
           {
                int grupoEtario = Convert.ToInt32(cboGrupoEtario.SelectedValue);
                int genero = Convert.ToInt32(cboGenero.SelectedValue);

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

                btnSiguiente.Enabled = true;
                btnCancelar.Enabled = true;
                btnAnalizar.Enabled = false;
                bloquearCampos(false);
                lblSalidaVPM.Text = txtVPM.Text;
            }
        }


        private void bloquearCampos(bool x)
        {
            txtGBWB.Enabled = x;
            txtGBRBC.Enabled = x;
            txtHB.Enabled = x;
            txtHTO.Enabled = x;
            txtVCM.Enabled = x;
            txtHCM.Enabled = x;
            txtCHCM.Enabled = x;
            txtRDW.Enabled = x;
            txtPLT.Enabled = x;
            txtVPM.Enabled = x;
        }

        private void txtRDW_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if(ch == 46 && txtRDW.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }

            if(!Char.IsDigit(ch) && ch!=8 && ch!=46 )
            {
                e.Handled = true;
            }
        }


        private void txtPLT_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && txtPLT.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }


        private void txtCHCM_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && txtCHCM.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }


        private void txtHCM_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && txtHCM.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }


        private void txtVCM_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && txtVCM.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }


        private void txtHTO_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && txtHTO.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }


        private void txtHB_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && txtHB.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }


        private void txtGBRBC_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && txtGBRBC.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }


        private void txtGBWB_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && txtGBWB.Text.IndexOf('.') != -1)
            {
                e.Handled = true;
                return;
            }

            if (!Char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
            }
        }


        private void txtVPM_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (ch == 46 && txtVPM.Text.IndexOf('.') != -1)
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


        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            
           
            if (!Char.IsDigit(ch) && ch != 8 )
            {
                e.Handled = true;
            }

        }


        public bool validarEdad()
        {
            int valor = Convert.ToInt32(cboEdadEn.SelectedValue);
            bool bandera = false;

            if(valor==1)
            {
                if(Convert.ToInt32(txtEdad.Text)>30)
                {
                    MessageBox.Show("El valor no puede ser mayor a 30 dias.","Error");
                    bandera = false;
                    txtEdad.Focus();
                }
            }
            else
            {
                bandera = true;
            }
            if (valor == 2)
            {
                if (Convert.ToInt32(txtEdad.Text) > 12)
                {
                    MessageBox.Show("El valor no puede ser mayor a 12 meses.", "Error");
                    bandera = false;
                    txtEdad.Focus();
                }
            }
            else
            {
                bandera = true;
            }
            

            return bandera;
        }



        private void btnCalcularGrupoEtario_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtEdad.Text))
            {

                int parametro = Convert.ToInt32(cboEdadEn.SelectedValue);
                int edad = Convert.ToInt32(txtEdad.Text);

                if (validarEdad())
                {
                    // AMBOS SEXOS
                    if (cboGenero.SelectedIndex == 0 || cboGenero.SelectedIndex == 1)
                    {
                        //Calculos por dias
                        if (parametro == 1)
                        {

                            if (edad == 0)
                            {
                                cboGrupoEtario.SelectedValue = 1;
                            }

                            if (edad > 0 && edad <= 3)
                            {
                                cboGrupoEtario.SelectedValue = 2;
                            }

                            if (edad > 3 && edad <= 7)
                            {
                                cboGrupoEtario.SelectedValue = 3;
                            }

                            if (edad > 7 && edad <= 15)
                            {
                                cboGrupoEtario.SelectedValue = 4;
                            }

                            if (edad > 15 && edad <= 30)
                            {
                                cboGrupoEtario.SelectedValue = 5;
                            }

                        }
                        //Calculos por Meses
                        if (parametro == 2)
                        {
                            if (edad > 0 && edad <= 2)
                            {
                                cboGrupoEtario.SelectedValue = 6;
                            }

                            if (edad > 2 && edad <= 6)
                            {
                                cboGrupoEtario.SelectedValue = 7;
                            }

                            if (edad > 6 && edad <= 12)
                            {
                                cboGrupoEtario.SelectedValue = 8;
                            }

                        }

                        //calculo por años
                        if (parametro == 3)
                        {
                            if (edad > 0 && edad <= 2)
                            {
                                cboGrupoEtario.SelectedValue = 9;
                            }

                            if (edad > 2 && edad <= 6)
                            {
                                cboGrupoEtario.SelectedValue = 10;
                            }

                            if (edad > 6 && edad <= 12)
                            {
                                cboGrupoEtario.SelectedValue = 11;
                            }

                            if (edad > 12 && edad <= 18)
                            {
                                cboGrupoEtario.SelectedValue = 12;
                            }

                            if (edad > 18 && edad <= 99)
                            {
                                cboGrupoEtario.SelectedValue = 13;
                            }

                            if (edad > 99)
                            {
                                cboGrupoEtario.SelectedValue = 13;
                            }

                        }


                    }
                }
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Campo edad vacio");
                txtEdad.Focus();
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
                lblSalidaAlarmaRDW.Text = "↑ "+ RDW.ToString("00.0");
                lblSalidaAlarmaRDW.ForeColor = Color.Yellow;
            }
            if (RDW > 18.0m)
            {
                lblSalidaAlarmaRDW.Text = "↑ "+ RDW.ToString("00.0");
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


        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Desea proseguir hacia el siguiente paso.?", "Iniciar proceso recuento visual", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            { 
                FormContadorElementos nuevoFCE = new FormContadorElementos();
                nuevoFCE.lblCodigoGE.Text = cboGrupoEtario.SelectedValue.ToString();
                nuevoFCE.lblCodigoGenero.Text = cboGenero.SelectedValue.ToString();
                nuevoFCE.txtRDW.Text = this.txtRDW.Text;
                nuevoFCE.txtPLT.Text = this.txtPLT.Text;
                nuevoFCE.txtCHCM.Text = this.txtCHCM.Text;
                nuevoFCE.txtHCM.Text = this.txtHCM.Text;
                nuevoFCE.txtVCM.Text = this.txtVCM.Text;
                nuevoFCE.txtHTO.Text = this.txtHTO.Text;
                nuevoFCE.txtHB.Text = this.txtHB.Text;
                nuevoFCE.txtGBRBC.Text = this.txtGBRBC.Text;
                nuevoFCE.txtGBWB.Text = this.txtGBWB.Text;
                nuevoFCE.txtVPM.Text = this.txtVPM.Text;
                nuevoFCE.txtGlobulosBlancos.Text = this.txtGBWB.Text;
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

      

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            bloquearCampos(true);
            btnAnalizar.Enabled = true;
            btnSiguiente.Enabled = false;
            btnCancelar.Enabled = false;
            txtGBWB.Focus();
        }

      

        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btnEditarEdad,"Permite editar la edad");
        }

        private void btnEditarEdad_Click(object sender, EventArgs e)
        {
            if(!txtEdad.Enabled)
            {
                txtEdad.Enabled = true;
            }
            else
            {
                txtEdad.Enabled = false;
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            if (MetroFramework.MetroMessageBox.Show(this, "Se volvera a la Selección de pacientes", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
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
