using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net.Http.Formatting; // para ReadAsAsync



namespace OficinaTramites
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnEmitir_Click(object sender, EventArgs e)
        {

            lblEstadoServicios.Text = "Iniciando verificación...\n";

            string ci = txtCi.Text.Trim();
            string nombres = txtNombres.Text.Trim();
            string primerApellido = txtPrimerApellido.Text.Trim();
            string segundoApellido = txtSegundoApellido.Text.Trim();
            string titulo = txtTitulo.Text.Trim();

            // Llamada a SEGIP (SOAP)
            lblEstadoServicios.Text += "Verificando datos con SEGIP...\n";
            wsSegip.wsSegipSoapClient client = new wsSegip.wsSegipSoapClient(wsSegip.wsSegipSoapClient.EndpointConfiguration.wsSegipSoap12);
            var persona = client.ObtenerDatos(ci);
            if (persona == null ||
                persona.Nombres != nombres ||
                persona.PrimerApellido != primerApellido ||
                persona.SegundoApellido != segundoApellido)
            {
                lblEstadoServicios.Text += "Datos no válidos en SEGIP\n";
                MessageBox.Show("Los datos no coinciden con SEGIP");
                return;
            }
            lblEstadoServicios.Text += "Datos verificados con SEGIP\n";

            // Llamada a SEDUCA (GraphQL)
            lblEstadoServicios.Text += "Verificando si es bachiller en SEDUCA...\n";
            var isBachiller = await VerificarBachillerAsync(ci);
            if (!isBachiller)
            {
                lblEstadoServicios.Text += "No es bachiller según SEDUCA\n";
                MessageBox.Show("La persona no está registrada como bachiller en SEDUCA.");
                return;
            }
            lblEstadoServicios.Text += "Verificado como bachiller en SEDUCA\n";

            // Llamada a ACADEMICO (REST)
            lblEstadoServicios.Text += "Verificando si ya tiene título en ACADEMICO...\n";
            bool yaRegistrado = await VerificarEnAcademico(ci);
            if (yaRegistrado)
            {
                lblEstadoServicios.Text += "Ya tiene un título registrado\n";
                MessageBox.Show("Esta persona ya tiene un título registrado.");
                return;
            }
            lblEstadoServicios.Text += "Registrando título en ACADEMICO...\n";
            await RegistrarTitulo(ci, nombres, primerApellido, segundoApellido, titulo);
            lblEstadoServicios.Text += "Título registrado con éxito en ACADEMICO\n";
            MessageBox.Show("Título emitido exitosamente.");
        }
        private async Task<bool> VerificarBachillerAsync(string ci)
        {
            var query = new
            {
                query = @"query($ci: String!) {
                    persona(ci: $ci) {
                        EsBachiller
                    }
                 }",
                variables = new { ci = ci }
            };

            var client = new HttpClient();
            var response = await client.PostAsJsonAsync("http://localhost:4000/graphql", query);
            var result = await response.Content.ReadAsAsync<dynamic>();

            return result.data?.persona != null && result.data.persona.EsBachiller == true;
        }
        private async Task<bool> VerificarEnAcademico(string ci)
        {
            var client = new HttpClient();
            var response = await client.GetAsync("http://localhost:8000/api/titulos");
            var data = await response.Content.ReadAsAsync<List<dynamic>>();

            return data.Any(t => t["ci"] == ci);
        }

        private async Task RegistrarTitulo(string ci, string nombres, string primerApellido, string segundoApellido, string titulo)
        {
            var client = new HttpClient();
            var body = new
            {
                ci = ci,
                nombres = nombres,
                primerApellido = primerApellido,
                segundoApellido = segundoApellido,
                titulo = titulo,
                fecha_emision = DateTime.Now.ToString("yyyy-MM-dd")
            };

            await client.PostAsJsonAsync("http://localhost:8000/api/titulos", body);
        }

    }
}
