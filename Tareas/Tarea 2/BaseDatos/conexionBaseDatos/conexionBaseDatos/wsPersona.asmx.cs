using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using MySql.Data.MySqlClient;

namespace conexionBaseDatos
{
    /// <summary>
    /// Descripción breve de wsPersona
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsPersona : System.Web.Services.WebService
    {
        string conexion = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;

        [WebMethod]
        public List<Persona> ObtenerPersonas()
        {
            List<Persona> personas = new List<Persona>();

            using (MySqlConnection con = new MySqlConnection(conexion))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM persona", con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    personas.Add(new Persona
                    {
                        id = reader.GetInt32("id"),
                        nombre = reader.GetString("nombre"),
                        edad = reader.GetInt32("edad")
                    });
                }
            }

            return personas;
        }

        [WebMethod]
        public string AgregarPersona(string nombre, int edad)
        {
            using (MySqlConnection con = new MySqlConnection(conexion))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO persona (nombre, edad) VALUES (@nombre, @edad)", con);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@edad", edad);
                cmd.ExecuteNonQuery();
            }
            return "Persona agregada con éxito";
        }

        [WebMethod]
        public string ActualizarPersona(int id, string nombre, int edad)
        {
            using (MySqlConnection con = new MySqlConnection(conexion))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE persona SET nombre=@nombre, edad=@edad WHERE id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@edad", edad);
                cmd.ExecuteNonQuery();
            }
            return "Persona actualizada";
        }

        [WebMethod]
        public string EliminarPersona(int id)
        {
            using (MySqlConnection con = new MySqlConnection(conexion))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM persona WHERE id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            return "Persona eliminada";
        }
    }
}
