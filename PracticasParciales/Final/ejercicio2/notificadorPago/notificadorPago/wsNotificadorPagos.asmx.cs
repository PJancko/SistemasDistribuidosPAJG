using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Net.Http;
using RabbitMQ.Client;


namespace notificadorPago
{
    /// <summary>
    /// Descripción breve de wsNotificadorPagos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsNotificadorPagos : System.Web.Services.WebService
    {

        [WebMethod]
        public Factura[] ConsultarDeudas(string ci)
        {
            var todas = new List<Factura>();
            var http = new HttpClient();

            // CESSA
            var cessaResp = http.GetAsync($"http://localhost:8000/api/facturas/{ci}").Result;
            if (cessaResp.IsSuccessStatusCode)
            {
                var json = cessaResp.Content.ReadAsStringAsync().Result;
                // Reemplazar snake_case con PascalCase
                json = json.Replace("nro_factura", "NroFactura")
                           .Replace("nombre_completo", "NombreCompleto");
                var facturas = new JavaScriptSerializer().Deserialize<List<Factura>>(json);
                foreach (var f in facturas) f.Empresa = "Cessa";
                todas.AddRange(facturas);
            }

            // ELAPAS
            var elapasResp = http.GetAsync($"http://localhost:3001/facturas/{ci}").Result;
            if (elapasResp.IsSuccessStatusCode)
            {
                var json = elapasResp.Content.ReadAsStringAsync().Result;
                json = json.Replace("nro_factura", "NroFactura")
                           .Replace("nombre_completo", "NombreCompleto");
                var facturas = new JavaScriptSerializer().Deserialize<List<Factura>>(json);
                foreach (var f in facturas) f.Empresa = "Elapas";
                todas.AddRange(facturas);
            }

            // ENTEL - GraphQL
            var query = new
            {
                query = $"{{ facturasPorCI(ci: \"{ci}\") {{ nro_factura ci nombre_completo periodo monto estado }} }}"
            };
            var jsonBody = new JavaScriptSerializer().Serialize(query);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            var entelResp = http.PostAsync("http://localhost:3002/graphql", content).Result;

            if (entelResp.IsSuccessStatusCode)
            {
                var json = entelResp.Content.ReadAsStringAsync().Result;
                dynamic parsed = new JavaScriptSerializer().DeserializeObject(json);
                var facturas = parsed["data"]["facturasPorCI"];

                foreach (var f in facturas)
                {
                    todas.Add(new Factura
                    {
                        Empresa = "Entel",
                        NroFactura = f["nro_factura"],
                        CI = f["ci"],
                        NombreCompleto = f["nombre_completo"],
                        Periodo = f["periodo"],
                        Monto = Convert.ToDecimal(f["monto"]),
                        Estado = f["estado"]
                    });
                }
            }

            return todas.ToArray();
        }

        [WebMethod]
        public string Pagar(Factura[] facturas)
        {
            var http = new HttpClient();

            foreach (var f in facturas)
            {
                if (f.Empresa == "Cessa")
                    http.PutAsync($"http://localhost:8000/api/facturas/{f.NroFactura}", null).Wait();

                else if (f.Empresa == "Elapas")
                    http.PutAsync($"http://localhost:3001/facturas/{f.NroFactura}", null).Wait();

                else if (f.Empresa == "Entel")
                {
                    var mutation = new
                    {
                        query = $"mutation {{ pagarFactura(nro_factura: \"{f.NroFactura}\") }}"
                    };
                    var jsonBody = new JavaScriptSerializer().Serialize(mutation);
                    var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                    http.PostAsync("http://localhost:3002/graphql", content).Wait();
                }

                f.Estado = "Pagado";
            }

            PublicarEnRabbitMQ(facturas);
            return "Facturas pagadas y notificadas correctamente.";
        }
        private void PublicarEnRabbitMQ(Factura[] facturas)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "pagos", durable: false, exclusive: false, autoDelete: false, arguments: null);

                var payload = new JavaScriptSerializer().Serialize(new
                {
                    usuario = facturas[0].NombreCompleto,
                    ci = facturas[0].CI,
                    facturasPagadas = facturas
                });

                var body = Encoding.UTF8.GetBytes(payload);
                channel.BasicPublish(exchange: "", routingKey: "pagos", basicProperties: null, body: body);
            }
        }


    }
}
