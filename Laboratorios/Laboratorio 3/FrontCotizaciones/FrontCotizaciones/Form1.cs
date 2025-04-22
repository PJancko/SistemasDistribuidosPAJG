namespace FrontCotizaciones
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                var servicio = new rsCotizacion.wsCotizacionSoapClient(rsCotizacion.wsCotizacionSoapClient.EndpointConfiguration.wsCotizacionSoap12);
                string fecha = txtFechaConsulta.Text;
                string resultado = servicio.ObtenerCotizacion(fecha);
                lblResultadoConsulta.Text = resultado;
            }
            catch (Exception ex)
            {
                lblResultadoConsulta.Text = "Error: " + ex.Message;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                var servicio = new rsCotizacion.wsCotizacionSoapClient(rsCotizacion.wsCotizacionSoapClient.EndpointConfiguration.wsCotizacionSoap12); // Usa el namespace generado
                string fecha = txtFechaRegistro.Text;
                decimal monto = decimal.Parse(txtMonto.Text);
                string resultado = servicio.RegistrarCotizacion(fecha, monto);
                lblResultadoRegistro.Text = resultado;
            }
            catch (Exception ex)
            {
                lblResultadoRegistro.Text = "Error: " + ex.Message;
            }
        }
    }
}
