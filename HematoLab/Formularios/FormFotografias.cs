using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using HematoLab.Gestores;

namespace HematoLab.Formularios
{
    public partial class FormFotografias : MetroFramework.Forms.MetroForm
    {

        GestorImagen accesoImagen = new GestorImagen();
        private bool existeDispositivo = false;
        private FilterInfoCollection camara;
        private VideoCaptureDevice elementoCaptura = null;



        public FormFotografias()
        {
            InitializeComponent();
        }

        private void FormFotografias_Load(object sender, EventArgs e)
        {
            cargarImagen();
            buscarDispositivos();
            OpcionesFoto();
        }

        private void noExisteCamara(bool x)
        {
            this.cmbCamaras.Enabled = x;
            this.btnAF.Enabled = x;
            this.btnAcF.Enabled = x;
            this.btnIniciar.Enabled = x;
            this.btnDetener.Enabled = x;
        }

        public void buscarDispositivos()
        {
            camara = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (camara.Count == 0)
            {
                existeDispositivo = false;
                //btnAF.Enabled = false;
            }
            else
            {
                existeDispositivo = true;
                cargarCamaras(camara);
            }
        }

        public void cargarCamaras(FilterInfoCollection dispositivos)
        {
            for (int i = 0; i < dispositivos.Count; i++)
            {
                cmbCamaras.Items.Add(dispositivos[i].Name.ToString());
                cmbCamaras.Text = cmbCamaras.Items[i].ToString();
            }
        }

        private void cargarImagen()
        {
            int tipoPersonal = Convert.ToInt32 (txtTipoPersonal.Text);
            string t1 = "FotografiasProfesionales";
            string t2 = "FotografiasNoMedicos";
            string t3 = "FotografiasTecnicos";

            if (tipoPersonal == 1)//profesionales
            {
                accesoImagen.verImagen(PBMostrarImagen, Convert.ToInt32(lblLegajo.Text),t1);
            }
            if (tipoPersonal == 2 )//personal  no medico
            {
                accesoImagen.verImagen(PBMostrarImagen, Convert.ToInt32(lblLegajo.Text), t2);
            }
            if (tipoPersonal == 3)//personal tecnico
            {
                accesoImagen.verImagen(PBMostrarImagen, Convert.ToInt32(lblLegajo.Text), t3);
            }

        }


        private void OpcionesFoto()
        {

            if (existeDispositivo)
            {

                if (PBMostrarImagen.Image == null)
                {
                    btnAF.Enabled = true;
                    btnAcF.Enabled = false;
                }


                if (PBMostrarImagen.Image != null)
                {
                    btnAcF.Enabled = true;
                    btnAF.Enabled = false;
                }

            }

            else
            {
                btnAcF.Enabled = false;
                btnAF.Enabled = false;
            }

        }

        public void TerminarFuenteDeVideo()
        {
            if (!(elementoCaptura == null))
                if (elementoCaptura.IsRunning)
                {
                    elementoCaptura.SignalToStop();
                    elementoCaptura = null;
                    pictureBox1.Image = null;
                    txtEstado.Text = "";
                }
        }




        public void Video_NuevoFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap Imagen = (Bitmap)eventArgs.Frame.Clone();
            PBMostrarImagen.Image = Imagen;
        }

        private void apagarCamara()
        {
            TerminarFuenteDeVideo();
            txtEstado.Text = "Dispositivo Detenido…";
            btnIniciar.Text = "Iniciar";
            btnDetener.Enabled = false;
         //   pictureBox1.Image.Dispose();
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            apagarCamara();
            
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (btnIniciar.Text == "Iniciar")
            {
                if (existeDispositivo)
                {
                    elementoCaptura = new VideoCaptureDevice(camara[cmbCamaras.SelectedIndex].MonikerString);
                    elementoCaptura.NewFrame += new NewFrameEventHandler(Video_NuevoFrame);
                    elementoCaptura.Start();
                    txtEstado.Text = "Ejecutando Dispositivo…";
                    btnIniciar.Text = "Capturar";
                    btnDetener.Enabled = true;
                }
                else
                {
                    txtEstado.Text = "No Hay Camaras Conectadas";
                    PBMostrarImagen.Image = null;
                }
            }
            else
            {
                if (elementoCaptura.IsRunning)
                {
                    TerminarFuenteDeVideo();
                    txtEstado.Text = "Dispositivo Detenido…";
                    btnIniciar.Text = "Iniciar";
                    btnDetener.Enabled = false;
                }
            }
        }

        private void btnAcF_Click(object sender, EventArgs e)
        {
            int tipoPersonal = Convert.ToInt32(txtTipoPersonal.Text);
            string t1 = "FotografiasProfesionales";
            string t2 = "FotografiasNoMedicos";
            string t3 = "FotografiasTecnicos";

            if (btnIniciar.Text != "Capturar")
            {
                if (tipoPersonal == 1)
                {
                    if (txtEstado.Text != "")
                    {
                        int codigo = Convert.ToInt32(lblLegajo.Text);
                        if (accesoImagen.actualizar(codigo, PBMostrarImagen, t1))
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Foto actualizada correctamente.", "Actualización imagen");
                            this.Close();
                            this.Dispose();
                        }
                        else
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Problemas en la actualización.", "Actualización imagen");
                        }

                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Error de inicio de dispositivo...");
                    }
                }


                if (tipoPersonal == 2)
                {
                    if (txtEstado.Text != "")
                    {
                        int codigo = Convert.ToInt32(lblLegajo.Text);
                        if (accesoImagen.actualizar(codigo, PBMostrarImagen, t2))
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Foto actualizada correctamente.", "Actualización imagen");
                            this.Close();
                            this.Dispose();
                        }
                        else
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Problemas en la actualización.", "Actualización imagen");
                        }

                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Error de inicio de dispositivo...");
                    }
                }

                if (tipoPersonal == 3)
                {
                    if (txtEstado.Text != "")
                    {
                        int codigo = Convert.ToInt32(lblLegajo.Text);
                        if (accesoImagen.actualizar(codigo, PBMostrarImagen, t3))
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Foto actualizada correctamente.", "Actualización imagen");
                            this.Close();
                            this.Dispose();
                        }
                        else
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Problemas en la actualización.", "Actualización imagen");
                        }

                    }
                    else
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Error de inicio de dispositivo...");
                    }
                }

            }
            else 
            { 
                MetroFramework.MetroMessageBox.Show(this, "Primero debe realizar la captura o detener el dispositivo...");
            }
            
        }

        private void btnAF_Click(object sender, EventArgs e)
        {

            int tipoPersonal = Convert.ToInt32(txtTipoPersonal.Text);
            string t1 = "FotografiasProfesionales";
            string t2 = "FotografiasNoMedicos";
            string t3 = "FotografiasTecnicos";

            if (btnIniciar.Text != "Capturar")
            {
                if (tipoPersonal == 1)
                {
                   
                        if (txtEstado.Text != "")
                        {
                            int codigo = Convert.ToInt32(lblLegajo.Text);
                            if (accesoImagen.insertar(codigo, PBMostrarImagen, t1))
                            {
                                MetroFramework.MetroMessageBox.Show(this, "Foto agregada correctamente.", "Agregar foto");
                                this.Close();
                                this.Dispose();
                            }
                            else
                            {
                                MetroFramework.MetroMessageBox.Show(this, "Problemas en el guardado de la imagen.", "Agregar foto");
                            }
                        }
                        else
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Error de inicio de dispositivo...");
                        }
                    
                   
                }

              
                    if (tipoPersonal == 2)
                    {
                        if (txtEstado.Text != "")
                        {
                            int codigo = Convert.ToInt32(lblLegajo.Text);
                            if (accesoImagen.insertar(codigo, PBMostrarImagen, t2))
                            {
                                MetroFramework.MetroMessageBox.Show(this, "Foto agregada correctamente.", "Agregar foto");
                                this.Close();
                                this.Dispose();
                            }
                            else
                            {
                                MetroFramework.MetroMessageBox.Show(this, "Problemas en el guardado de la imagen.", "Agregar foto");
                            }
                        }
                        else
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Error de inicio de dispositivo...");
                        }
                    }
                
               



                    if (tipoPersonal == 3)
                    {
                   
                        if (txtEstado.Text != "")
                        {
                            int codigo = Convert.ToInt32(lblLegajo.Text);
                            if (accesoImagen.insertar(codigo, PBMostrarImagen, t3))
                            {
                                MetroFramework.MetroMessageBox.Show(this, "Foto agregada correctamente.", "Agregar foto");
                                this.Close();
                                this.Dispose();
                            }
                            else
                            {
                                MetroFramework.MetroMessageBox.Show(this, "Problemas en el guardado de la imagen.", "Agregar foto");
                            }
                        }
                        else
                        {
                            MetroFramework.MetroMessageBox.Show(this, "Error de inicio de dispositivo...");
                        }
                    }
             
                }

           
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Primero debe realizar la captura o detener el dispositivo...");
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            
              
                    if (txtEstado.Text == "Ejecutando Dispositivo…")
                    {
                        MetroFramework.MetroMessageBox.Show(this, "Asegurarse de detener el dispositivo antes de salir.", "Dispositivo encendido", MessageBoxButtons.OK, MessageBoxIcon.Hand);  
                    }
                    else
                    {
                        if (MetroFramework.MetroMessageBox.Show(this, "Desea abandonar y salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            this.Close();
                        }
                    }

                
               
            
            
        }

      
    }
}
