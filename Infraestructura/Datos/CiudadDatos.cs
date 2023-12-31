﻿using Infraestructura.Conexiones;
using Infraestructura.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura.Datos
{
    public class CiudadDatos
    {
        private ConexionDB conexion;
        public CiudadDatos(string cadenaConexion) 
        {
            conexion = new ConexionDB(cadenaConexion);
            
        }
        public void insertarCiudad(CiudadModel ciudad)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand("INSERT INTO ciudad(nombre_ciudad) "+ "VALUES(@nombre_ciudad)", conn);
            comando.Parameters.AddWithValue("nombre_ciudad", ciudad.nombre_ciudad);
            comando.ExecuteNonQuery();
        }

        public CiudadModel obtenerCiudadPorId(int id) 
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"Select * From ciudad where id_ciudad = {id}", conn);
            using var reader = comando.ExecuteReader();
            if(reader.Read())
            {
                return new CiudadModel
                {
                    id_ciudad = reader.GetInt32("id_ciudad"),
                    nombre_ciudad = reader.GetString("nombre_ciudad")
                };
            }
            return null;
        }

        public void modificarCiudad(CiudadModel ciudad)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"UPDATE ciudad SET nombre_ciudad = '{ciudad.nombre_ciudad}' WHERE id_ciudad = { ciudad.id_ciudad}", conn);
            comando.ExecuteNonQuery();

        }

        public void eliminarCiudad(CiudadModel ciudad)
        {
            var conn = conexion.GetConexion();
            var comando = new Npgsql.NpgsqlCommand($"DELETE FROM ciudad WHERE id_ciudad = {ciudad.id_ciudad}", conn);
            comando.ExecuteNonQuery();
        }
    }
}
