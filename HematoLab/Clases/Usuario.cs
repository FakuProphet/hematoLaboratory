

namespace HematoLab.Clases
{
    class Usuario
    {
       public int legajo { get; set; }
       public string usuario { get; set; }
       public string pass { get; set; }
       public int tipoUsuario { get; set; }
       public int estado { get; set; }

        public Usuario(int legajo, string usuario, string pass, int tipoUsuario, int estado)
        {
            this.legajo = legajo;
            this.usuario = usuario;
            this.pass = pass;
            this.tipoUsuario = tipoUsuario;
            this.estado = estado;
        }

        public Usuario() { }

        public string toStringUsuario()
        {
            return legajo.ToString();
        }



    }
}
