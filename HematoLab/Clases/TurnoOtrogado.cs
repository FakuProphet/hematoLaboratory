

namespace HematoLab.Clases
{
    class TurnoOtrogado
    {
        public string hora { get; set; }
        public string estado { get; set; }



        public TurnoOtrogado(string Hora,string Estado)
        {
            this.hora = Hora;
            this.estado = Estado;
        }

        public TurnoOtrogado(){ }

        public string toStringTurnoOtorgado()
        {
            return hora.ToString();
        }
    }
}
