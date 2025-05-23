using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using System.Net.Http;

namespace servidorPagos
{
    /// <summary>
    /// Descripción breve de wsServidorPagos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsServidorPagos : System.Web.Services.WebService
    {

        [WebMethod]
        public List<Deuda> verDeuda(string ci, string PrimerApellido, string SegundoApellido, string nombres)
        {
            var deudas = new List<Deuda>();

            try
            {
                var httpClient = new HttpClient();  

                var query = new
                {
                    query = $@"query {{
                        persona(ci: ""{ci}"") {{
                            ci
                            nombres
                            PrimerApellido
                            SegundoApellido
                            deudas {{
                                Entidad
                                Codigo
                                Concepto
                                Monto
                            }}
                        }}
                    }}"
                };

                var content = new StringContent(JsonConvert.SerializeObject(query), Encoding.UTF8, "application/json");
                var response = httpClient.PostAsync("http://localhost:4000/graphql", content).Result;

                if (!response.IsSuccessStatusCode)
                {
                    return deudas;
                }

                var json = response.Content.ReadAsStringAsync().Result;
                dynamic result = JsonConvert.DeserializeObject(json);
                var persona = result?.data?.persona;

                if (persona == null)
                {
                    return deudas;
                }

                if ((string)persona.PrimerApellido != PrimerApellido ||
                    (string)persona.SegundoApellido != SegundoApellido ||
                    (string)persona.nombres != nombres)
                {
                    return deudas;
                }

                foreach (var d in persona.deudas)
                {
                    deudas.Add(new Deuda
                    {
                        Entidad = d.Entidad,
                        Codigo = d.Codigo,
                        Concepto = d.Concepto,
                        Monto = (decimal)d.Monto,
                        ci = persona.ci
                    });
                }
            }
            catch
            {
                return deudas;
            }

            return deudas;
        }

        [WebMethod]
        public bool PagarDeuda(Deuda c)
        {
            try
            {
                var httpClient = new HttpClient();

                string baseUrl;
                if (c.Entidad == "CESSA")
                {
                    baseUrl = "http://localhost:8000/api/facturas";
                }
                else if (c.Entidad == "ELAPAS")
                {
                    baseUrl = "http://localhost:8001/api/facturas"; 
                }
                else
                {
                    return false;
                }

                var payload = new
                {
                    ci = c.ci,
                    descripcion = c.Concepto,
                    monto = c.Monto
                };

                var content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

                var response = httpClient.PostAsync(baseUrl, content).Result;

                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

    }
}
