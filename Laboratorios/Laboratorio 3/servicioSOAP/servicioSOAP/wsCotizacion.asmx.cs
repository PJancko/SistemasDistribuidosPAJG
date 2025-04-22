using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Services;
using MySql.Data.MySqlClient;

namespace servicioSOAP
{
    /// <summary>
    /// Descripción breve de wsCotizacion
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsCotizacion : System.Web.Services.WebService
    {

        // Leer la cadena de conexión desde web.config
        string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        [WebMethod]
        public string ObtenerCotizacion(string fecha)
        {
            string resultado = "No se encontró cotización";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT cotizacion FROM cotizaciones WHERE fecha = @fecha";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@fecha", fecha);

                    object cotizacion = cmd.ExecuteScalar();
                    if (cotizacion != null)
                        resultado = $"Cotización: {cotizacion}";
                }
            }
            catch (Exception ex)
            {
                resultado = "Error: " + ex.Message;
            }

            return resultado;
        }

        [WebMethod]
        public string RegistrarCotizacion(string fecha, decimal monto)
        {
            string resultado = "Error al registrar cotización";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "INSERT INTO cotizaciones (fecha, cotizacion, cotizacion_oficial) VALUES (@fecha, @monto, @oficial)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@fecha", fecha);
                    cmd.Parameters.AddWithValue("@monto", monto);
                    cmd.Parameters.AddWithValue("@oficial", 6.97m); // Puedes ajustar este valor si hace falta

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                        resultado = "Cotización registrada con éxito";
                }
            }
            catch (MySqlException ex) when (ex.Number == 1062)
            {
                resultado = "Ya existe una cotización para esa fecha.";
            }
            catch (Exception ex)
            {
                resultado = "Error: " + ex.Message;
            }

            return resultado;
        }

    }
}
