

namespace HematoLab.Clases
{
    class Profesional
    {

        private int legajo;
        public int pLegajo
        {
            get { return legajo; }
            set { legajo = value; }
        }




        private string matricula;
        public string pMatricula
        {
            get { return matricula; }
            set { matricula = value; }
        }

        private int idTurnoTrabajo;
        public int pIdTurnoTrabajo
        {
            get { return idTurnoTrabajo; }
            set { idTurnoTrabajo = value; }
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

        private int edad;
        public int pEdad
        {
            get { return edad; }
            set { edad = value; }
        }

        private int idGenero;
        public int pIdGenero
        {
            get { return idGenero; }
            set { idGenero = value; }
        }

        private string fechaNacimiento;
        public string pFechaNac
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

        private string fechaRegistro;
        public string pFechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
        }
        private int nroDocumento;
        public int pNroDoc
        {
            get { return nroDocumento; }
            set { nroDocumento = value; }
        }

        private int tipoDocumento;
        public int pTipoDoc
        {
            get { return tipoDocumento; }
            set { tipoDocumento = value; }
        }

        private string email;
        public string pEmail
        {
            get { return email; }
            set { email = value; }
        }

        private int especialidad;
        public int pIdEspecialidad
        {
            get { return especialidad; }
            set { especialidad = value; }
        }

        private int tituloAcademico;
        public int pTituloAcademico
        {
            get { return tituloAcademico; }
            set { tituloAcademico = value; }
        }

        public Profesional(string matricula, int idTurnoTrabajo, string nombre, string apellido, int edad, int idGenero, string fechaNacimiento, string fechaRegistro, int nroDocumento, int tipoDocumento, string email, int especialidad, int tituloAcademico)
        {
            this.matricula = matricula;
            this.idTurnoTrabajo = idTurnoTrabajo;
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.idGenero = idGenero;
            this.fechaNacimiento = fechaNacimiento;
            this.fechaRegistro = fechaRegistro;
            this.nroDocumento = nroDocumento;
            this.tipoDocumento = tipoDocumento;
            this.email = email;
            this.especialidad = especialidad;
            this.tituloAcademico = tituloAcademico;
        }

        public Profesional()
        {

        }

       

        public string toStringProfesional()
        {
            return pNroDoc.ToString();
        }



    }
}
