

namespace HematoLab.Clases
{
    class Administrativo
    {
        private int legajo;
        public int pLegajo
        {
            get { return legajo; }
            set { legajo = value; }
        }

        private string nombre;
        public string pNombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string apellido;
        public string pApellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        private int dni;
        public int pNroDoc
        {
            get { return dni; }
            set { dni = value; }
        }

        private int tipoDoc;
        public int pTipoDoc
        {
            get { return tipoDoc; }
            set { tipoDoc = value; }
        }

        private int edad;
        public int pEdad
        {
            get { return edad; }
            set { edad = value; }
        }

        private int genero;
        public int pIdGenero
        {
            get { return genero; }
            set { genero = value; }
        }

        private int turno;
        public int pIdTurnoDeTrabajo
        {
            get { return turno; }
            set { turno = value; }
        }

        private string email;
        public string pEmail
        {
            get { return email; }
            set { email = value; }
        }

        private string fechaNacimiento;
        public string pFechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        private string fechaRegistro;
        public string pAltaEnSistema
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
        }

        public Administrativo(int legajo, int pLegajo, string nombre, string pNombre, string apellido, string pApellido, int dni, int pNroDoc, int tipoDoc, int pTipoDoc, int edad, int pEdad, int genero, int pIdGenero, int turno, int pIdTurnoDeTrabajo, string email, string pEmail, string fechaNacimiento, string pFechaNacimiento)
        {
            this.legajo = legajo;
            this.pLegajo = pLegajo;
            this.nombre = nombre;
            this.pNombre = pNombre;
            this.apellido = apellido;
            this.pApellido = pApellido;
            this.dni = dni;
            this.pNroDoc = pNroDoc;
            this.tipoDoc = tipoDoc;
            this.pTipoDoc = pTipoDoc;
            this.edad = edad;
            this.pEdad = pEdad;
            this.genero = genero;
            this.pIdGenero = pIdGenero;
            this.turno = turno;
            this.pIdTurnoDeTrabajo = pIdTurnoDeTrabajo;
            this.email = email;
            this.pEmail = pEmail;
            this.fechaNacimiento = fechaNacimiento;
            this.pFechaNacimiento = pFechaNacimiento;
        }

        public Administrativo(){}


        public string toStringPNM()
        {
            return pNroDoc.ToString();
        }
    }
}
