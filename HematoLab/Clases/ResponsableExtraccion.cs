using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HematoLab.Clases
{
    class ResponsableExtraccion
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

        private int titulo;
        public int pTitulo
        {
            get { return titulo; }
            set { titulo = value; }
        }



        public ResponsableExtraccion(string matricula, int idTurnoTrabajo, string nombre, string apellido, int edad, int idGenero, string fechaNacimiento, int nroDocumento, int tipoDocumento, string email, int titulo)
        {
            this.matricula = matricula;
            this.idTurnoTrabajo = idTurnoTrabajo;
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.idGenero = idGenero;
            this.fechaNacimiento = fechaNacimiento;
            this.nroDocumento = nroDocumento;
            this.tipoDocumento = tipoDocumento;
            this.email = email;
            this.titulo = titulo;
        }

        public ResponsableExtraccion(){}


        public string toStringResponsableExtraccion()
        {
            return pNroDoc.ToString();
        }




    }
}
