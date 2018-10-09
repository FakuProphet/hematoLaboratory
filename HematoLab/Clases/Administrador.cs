using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HematoLab.Clases
{
    class Administrador
    {
        public int codigo { get; set; }
        public string userAdmin { get; set; }
        public string passAdmin { get; set; }

        public Administrador(int codigo, string userAdmin, string passAdmin)
        {
            this.codigo = codigo;
            this.userAdmin = userAdmin;
            this.passAdmin = passAdmin;
        }

        public Administrador() { }
    }
}
