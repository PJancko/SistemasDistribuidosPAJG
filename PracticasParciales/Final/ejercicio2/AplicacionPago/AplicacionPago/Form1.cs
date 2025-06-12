namespace AplicacionPago
{
    public partial class Form1 : Form
    {

        rsFacturas.wsPlataformaPagoSoapClient cliente = new rsFacturas.wsPlataformaPagoSoapClient(rsFacturas.wsPlataformaPagoSoapClient.EndpointConfiguration.wsPlataformaPagoSoap12);

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string ci = txtCI.Text.Trim();
            if (string.IsNullOrEmpty(ci)) return;

            try
            {
                var facturas = cliente.ConsultarDeudas(ci);
                dvgFacturas.DataSource = facturas;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar deudas: " + ex.Message);
            }
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (dvgFacturas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una factura para pagar.");
                return;
            }

            try
            {
                // Obtener la factura seleccionada
                var factura = (rsFacturas.Factura)dvgFacturas.SelectedRows[0].DataBoundItem;

                // Enviar solo esa factura en un array de 1 elemento
                string respuesta = cliente.Pagar(new rsFacturas.Factura[] { factura });

                MessageBox.Show(respuesta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al pagar: " + ex.Message);
            }
        }
    }
}
