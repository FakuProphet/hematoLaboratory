using HematoLab.Gestores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HematoLab.Formularios
{
    public partial class FormStickerExtractorio : MetroFramework.Forms.MetroForm
    {

        GestorSticker g;

        public FormStickerExtractorio()
        {
            InitializeComponent();
            g = new GestorSticker();
        }

        private void FormStickerExtractorio_Load(object sender, EventArgs e)
        {
            numerarSticker();
        }


        private void numerarSticker()
        {
            int nro = g.GetNumeroSticker();
            lblNroSticker.Text = nro.ToString();
            lblStickerDup.Text = nro.ToString();
        }


        private void btnImprimirSticker_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog guarda = new SaveFileDialog();
                guarda.Filter = "Imagen jpg|*.jpg";
                guarda.ShowDialog();
                if (guarda.FileName != "")
                {
                    Bitmap bm = new Bitmap(groupBoxPrueba.Width, groupBoxPrueba.Height);
                    groupBoxPrueba.DrawToBitmap(bm, new Rectangle(0, 0, groupBoxPrueba.Width, groupBoxPrueba.Height));
                    FileStream flujo = new FileStream(guarda.FileName, FileMode.Create, FileAccess.Write);
                    bm.Save(flujo, System.Drawing.Imaging.ImageFormat.Bmp);
                    flujo.Close();
                    bm.Dispose();
                    int nroDoc = Convert.ToInt32(lblDni.Text);
                    int nroSticker = Convert.ToInt32(lblNroSticker.Text);
                    g.saveDatosSticker(nroSticker, nroDoc);
                    MetroFramework.MetroMessageBox.Show(this, "Sticker generado exitosamente.", "Impresion sticker");
                    this.Close();
                }
            }
            catch(Exception error)
            {
                MetroFramework.MetroMessageBox.Show(this, "Se ha producido un error: " + error.ToString(), "Error");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
