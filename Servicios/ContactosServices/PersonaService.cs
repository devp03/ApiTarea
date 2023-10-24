using Infraestructura.Datos;
using Infraestructura.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.ContactosServices
{
    public class PersonaService
    {
        PersonaDatos personaDatos;
        public PersonaService(string cadenaConexion)
        {
            personaDatos = new PersonaDatos(cadenaConexion);
        }
        public void insertarPersona(PersonaModel persona)
        {
            validarDatos(persona);
            personaDatos.insertarPersona(persona);
        }

        public PersonaModel obtenerPersonaPorId(int id)
        {
            return personaDatos.obtenerPersonaPorId(id);
        }

        public void modificarPersona(PersonaModel persona)
        {
            validarDatos(persona);
            personaDatos.modificarPersona(persona);
        }

        public void eliminarPersona(PersonaModel persona)
        {
            validarDatos(persona);
            personaDatos.eliminarPersona(persona);
        }

        private void validarDatos(PersonaModel persona)
        {
            if (persona.edad <=0)
            {
                throw new Exception("La edad debe ser mayor a 0");
            }
        }
    }
}

