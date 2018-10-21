using System;
using System.Windows.Forms;



namespace HematoLab.Formularios
{
    public partial class FormSplash : Form
    {
        public FormSplash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            rectangleShape2.Width += 10;
            if(rectangleShape2.Width>=554)
            {
                timer1.Stop();
                this.Hide();
                FormLogin fl = new FormLogin();
                fl.ShowDialog();
                
            }
        }

       
       
    }
}
