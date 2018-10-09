using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HematoLab.Clases
{
    class Paciente
    {
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int edad { get; set; }
        public string fechaNacimiento { get; set; }
        public string nacionalidad { get; set; }
        public int grupoEtario { get; set; }
        public int genero { get; set; }
        public string fechaRegistro { get; set; }
        public int numeroDocumento { get; set; }
        public int tipoDocumento { get; set; }
        public string email { get; set; }
        public string obraSocial { get; set; }
        public int estadoCivil { get; set; }
        public int provincia { get; set; }
        public int localidad { get; set; }
        public string calle { get; set; }
        public int numeroCalle { get; set; }
        public string barrio { get; set; }
        public string telefonoFijo { get; set; }
        public string telefonoCelular { get; set; }


        public Paciente(int codigo, string nombre, string apellido, int edad, string fechaNacimiento, string nacionalidad, int grupoEtario, int genero, string fechaRegistro, int numeroDocumento, int tipoDocumento, string email, string obraSocial, int estadoCivil, int provincia, int  localidad, string calle, int numeroCalle, string barrio, string telefonoFijo, string telefonoCelular)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.fechaNacimiento = fechaNacimiento;
            this.nacionalidad = nacionalidad;
            this.grupoEtario = grupoEtario;
            this.genero = genero;
            this.fechaRegistro = fechaRegistro;
            this.numeroDocumento = numeroDocumento;
            this.tipoDocumento = tipoDocumento;
            this.email = email;
            this.obraSocial = obraSocial;
            this.estadoCivil = estadoCivil;
            this.provincia = provincia;
            this.localidad = localidad;
            this.calle = calle;
            this.numeroCalle = numeroCalle;
            this.barrio = barrio;
            this.telefonoFijo = telefonoFijo;
            this.telefonoCelular = telefonoCelular;
        }

        public Paciente(){}


        public string toStringPaciente()
        {
            return numeroDocumento.ToString();
        }

    }
}
