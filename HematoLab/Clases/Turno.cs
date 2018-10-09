using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HematoLab.Clases
{
    class Turno
    {
        public int ordenNro { get; set; }
        public int dni { get; set; }
        public int estado { get; set; }
        public int idHora { get; set; }
        public int cod_tipo_examen { get; set; }
        public string observaciones { get; set; }
    }
}
