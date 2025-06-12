using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using MySql.Data.MySqlClient;


namespace ServicioSegip
{
    /// <summary>
    /// Descripción breve de wsSegip
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsSegip : System.Web.Services.WebService
    {
        [WebMethod]
        public bool VerificarDatos(string ci, string nombres, string primerApellido, string segundoApellido)
        {
            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlSegip"].ConnectionString))
            {
                conn.Open();
                string query = @"SELECT * FROM personas 
                         WHERE ci = @ci AND nombres = @nombres AND primer_apellido = @pa AND segundo_apellido = @sa";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ci", ci);
                cmd.Parameters.AddWithValue("@nombres", nombres);
                cmd.Parameters.AddWithValue("@pa", primerApellido);
                cmd.Parameters.AddWithValue("@sa", segundoApellido);
                var reader = cmd.ExecuteReader();
                return reader.HasRows;
            }
        }

        [WebMethod]
        public Persona ObtenerDatos(string ci)
        {
            using (var conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlSegip"].ConnectionString))
            {
                conn.Open();
                string query = "SELECT * FROM personas WHERE ci = @ci LIMIT 1";
                var cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ci", ci);

                var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return new Persona
                    {
                        CI = reader["ci"].ToString(),
                        Nombres = reader["nombres"].ToString(),
                        PrimerApellido = reader["primer_apellido"].ToString(),
                        SegundoApellido = reader["segundo_apellido"].ToString()
                    };
                }
            }
            return null;
        }
    }
}
