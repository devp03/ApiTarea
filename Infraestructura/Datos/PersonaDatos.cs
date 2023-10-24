using Infraestructura.Conexiones;
using Infraestructura.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Datos
{
    public class PersonaDatos
    {
        private ConexionDB conexion;
        public PersonaDatos(string cadenaCnexion)
        { 
            conexion = new ConexionDB(cadenaCnexion);
        }
        public void insertarPersona(PersonaModel persona)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"INSERT INTO personas(nombre_persona, apellido_persona, direccion, email, celular, edad, fk_ciudad) "
                + "VALUES(@nombre_persona, @apellido_persona, @direccion, @email, @celular, @edad, @fk_ciudad )", conn);
            comando.Parameters.AddWithValue("nombre_persona", persona.nombre_persona);
            comando.Parameters.AddWithValue("apellido_persona", persona.apellido_persona);
            comando.Parameters.AddWithValue("direccion", persona.direccion);
            comando.Parameters.AddWithValue("email", persona.email);
            comando.Parameters.AddWithValue("celular", persona.celular);
            comando.Parameters.AddWithValue("edad", persona.edad);
            comando.Parameters.AddWithValue("fk_ciudad", persona.fk_ciudad);
            comando.ExecuteNonQuery();
        }

        public PersonaModel obtenerPersonaPorId(int id)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"Select * From personas where id_persona = {id}", conn);
            using var reader = comando.ExecuteReader();
            if (reader.Read())
            {
                return new PersonaModel
                {
                    id_persona = reader.GetInt32("id_persona"),
                    nombre_persona = reader.GetString("nombre_persona"),
                    apellido_persona = reader.GetString("apellido_persona"),
                    direccion = reader.GetString("direccion"),
                    email = reader.GetString("email"),
                    celular = reader.GetString("celular"),
                    edad = reader.GetInt32("edad"),
                    fk_ciudad = reader.GetInt32("fk_ciudad")
                };
            }
            return null;
        }

        public void modificarPersona(PersonaModel persona)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"UPDATE personas SET nombre_persona = '{persona.nombre_persona}' WHERE id_ciudad = {persona.id_persona}", conn);
            comando.ExecuteNonQuery();

        }

        public void eliminarPersona(PersonaModel persona)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"DELETE FROM personas WHERE id_persona = {persona.id_persona}", conn);
            comando.ExecuteNonQuery();
        }
    }
}
