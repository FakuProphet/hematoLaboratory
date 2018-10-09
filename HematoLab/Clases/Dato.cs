using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HematoLab.Clases
{
    class Dato
    {
        /*ES SOLO PARA PASAR LOS DATOS
         ENTRE FORMULARIOS Y SOLO LLAMAR AL OBJETO 
         COMO DATO*/
        public int legajo { get; set; }
        public int tipoPersona { get; set; }

        public Dato(int legajo, int tipoPersona)
        {
            this.legajo = legajo;
            this.tipoPersona = tipoPersona;
        }

        public Dato(){}
    }
}
