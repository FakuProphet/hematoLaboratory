

namespace HematoLab.Clases
{
    class ULD
    {
        /*Es solo para q contenga el nombre real del usuario logueado*/
        public string nombreCompleto { get; set; }
        public int legajoSistema { get; set; }

        public ULD(string nombreCompleto, int legajoSistema)
        {
            this.nombreCompleto = nombreCompleto;
            this.legajoSistema = legajoSistema;
        }

        public ULD() { }

        
    }
}
