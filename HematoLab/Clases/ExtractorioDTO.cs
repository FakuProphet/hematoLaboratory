using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HematoLab.Clases
{
    class ExtractorioDTO
    {
        public int nroOrden { get; set; }
        public string paciente { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public string estado { get; set; }
        public string observaciones { get; set; }
        public int extraccion { get; set; }
        public int citilogico { get; set; }
        public int eritrosedimentacion { get; set; }
        public int reticulocitos { get; set; }
        public int nroDoc { get; set; }
        public string grupoEtario { get; set; }

        public ExtractorioDTO(int nroOrden, string paciente, string fecha, string hora, string estado, string observaciones, int extraccion, int citilogico, int eritrosedimentacion, int reticulocitos, int nroDoc, string grupoEtario)
        {
            this.nroOrden = nroOrden;
            this.paciente = paciente;
            this.fecha = fecha;
            this.hora = hora;
            this.estado = estado;
            this.observaciones = observaciones;
            this.extraccion = extraccion;
            this.citilogico = citilogico;
            this.eritrosedimentacion = eritrosedimentacion;
            this.reticulocitos = reticulocitos;
            this.nroDoc = nroDoc;
            this.grupoEtario = grupoEtario;
        }

        public ExtractorioDTO() { }

        public string toStringExtractorio()
        {
            return "Nro de orden: " + nroOrden;
        }
    }
}
