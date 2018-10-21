

namespace HematoLab.Clases
{
    class AnalisisDTO
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
        public int edad { get; set; }
        public string realizado { get; set; }


        public AnalisisDTO(int nroOrden, string paciente, string fecha, string hora, string estado, string observaciones,int nroDoc, string grupoEtario, int edad, string realizado)
        {
            this.nroOrden = nroOrden;
            this.paciente = paciente;
            this.fecha = fecha;
            this.hora = hora;
            this.estado = estado;
            this.observaciones = observaciones;
            this.nroDoc = nroDoc;
            this.grupoEtario = grupoEtario;
            this.edad = edad;
            this.realizado = realizado;
        }

        public AnalisisDTO() { }

        public string toStringAnalisis()
        {
            return "Nro de Documento: " + nroDoc +' '+ "Fecha: " + fecha ;
        }
    }
}
