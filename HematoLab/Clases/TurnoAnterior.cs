

namespace HematoLab.Clases
{
    class TurnoAnterior
    {
        public string paciente { get; set; }
        public string obraSocial { get; set; }
        public string fechaUltimaVisita { get; set; }
        public int codigoEstado { get; set; }
        public int eritro { get; set; }
        public int reti { get; set; }
        public int cito { get; set; }
        public string observaciones { get; set; }
        public int nroDoc { get; set; }

        public TurnoAnterior(string paciente, string obraSocial, string fechaUltimaVisita, int codigoEstado, int eritro, int reti, int cito, string observaciones, int nroDoc)
        {
            this.paciente = paciente;
            this.obraSocial = obraSocial;
            this.fechaUltimaVisita = fechaUltimaVisita;
            this.codigoEstado = codigoEstado;
            this.eritro = eritro;
            this.reti = reti;
            this.cito = cito;
            this.observaciones = observaciones;
            this.nroDoc = nroDoc;
        }

        public TurnoAnterior() { }
    }
}
