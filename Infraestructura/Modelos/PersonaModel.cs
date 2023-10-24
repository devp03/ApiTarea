using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Modelos
{
    public class PersonaModel
    {
        public int id_persona { get; set; }
        public string nombre_persona { get; set; }
        public string apellido_persona { get; set; }
        public string direccion { get;set; }
        public string email { get; set; }
        public string celular { get; set; }
        public int edad {get; set; }
        public int fk_ciudad { get; set; }

        public PersonaModel() { }
    }
}
