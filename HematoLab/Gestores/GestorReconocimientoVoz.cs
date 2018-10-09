using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;

namespace HematoLab.Gestores
{
    class GestorReconocimientoVoz

    {
        SpeechRecognitionEngine reconocimiento_de_voz = new SpeechRecognitionEngine();
        Choices opcionesVoz = new Choices();

        private void activarVoz()
        {
            opcionesVoz.Add(new string[] { "pausarcontador", "reaundarcontador"});
            Grammar gramatica = new Grammar(new GrammarBuilder(opcionesVoz));
            reconocimiento_de_voz.SetInputToDefaultAudioDevice(); // Usaremos el microfono predeterminado del sistema
            reconocimiento_de_voz.LoadGrammar(gramatica); //Carga la gramatica de Windows
            reconocimiento_de_voz.SpeechRecognized += te_escucho; // Controlador de eventos. Se ejecutara al reconocer
            reconocimiento_de_voz.RecognizeAsync(RecognizeMode.Multiple);
        }



        void te_escucho(object sender, SpeechRecognizedEventArgs e)
        {

            if (e.Result.Text == "pausarcontador")
            {
                
            }
            if (e.Result.Text == "reanudarcontador")
            {
              //  label2.Text = c2.ToString();
            }
        }
    }
}
