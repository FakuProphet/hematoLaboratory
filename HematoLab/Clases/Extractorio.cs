using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HematoLab.Clases
{
    class Extractorio
    {
        public int nroOrden { get; set; }
        public int idPaciente { get; set; }
        public string fecha { get; set; }
        public int hora { get; set; }
        public int idEstado { get; set; }
        public string observaciones { get; set; }
        public int extraccion { get; set; }
        public int citilogico { get; set; }
        public int eritrosedimentacion { get; set; }
        public int reticulocitos { get; set; }

        public Extractorio(int nroOrden, int idPaciente, string fecha, int hora, int idEstado, string observaciones, int extraccion, int citilogico, int eritrosedimentacion, int reticulocitos)
        {
            this.nroOrden = nroOrden;
            this.idPaciente = idPaciente;
            this.fecha = fecha;
            this.hora = hora;
            this.idEstado = idEstado;
            this.observaciones = observaciones;
            this.extraccion = extraccion;
            this.citilogico = citilogico;
            this.eritrosedimentacion = eritrosedimentacion;
            this.reticulocitos = reticulocitos;
        }

        public Extractorio() { }

        public string toStringExtractorio()
        {
            return "Nro de orden: " + nroOrden;
        }
    }
}
