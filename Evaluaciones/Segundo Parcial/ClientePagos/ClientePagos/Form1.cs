namespace ClientePagos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            rsServidorPagos.wsServidorPagosSoapClient cliente = new rsServidorPagos.wsServidorPagosSoapClient(rsServidorPagos.wsServidorPagosSoapClient.EndpointConfiguration.wsServidorPagosSoap12);
            string ci = txtCi.Text.Trim();
            string nombres = txtNombre.Text.Trim();
            string primerApellido = txtPrimerApellido.Text.Trim();
            string segundoApellido = txtSegundoApellido.Text.Trim();

            var lista = cliente.verDeuda(ci, primerApellido, segundoApellido, nombres);
            dgvDeudas.DataSource = lista;
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            if (dgvDeudas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una deuda para pagar.");
                return;
            }

            var row = dgvDeudas.SelectedRows[0];
            rsServidorPagos.wsServidorPagosSoapClient cliente = new rsServidorPagos.wsServidorPagosSoapClient(rsServidorPagos.wsServidorPagosSoapClient.EndpointConfiguration.wsServidorPagosSoap12);

            var deuda = new rsServidorPagos.Deuda
            {
                Entidad = row.Cells["Entidad"].Value.ToString(),
                Codigo = row.Cells["Codigo"].Value.ToString(),
                Concepto = row.Cells["Concepto"].Value.ToString(),
                Monto = Convert.ToDecimal(row.Cells["Monto"].Value)
            };

            bool pagado = cliente.PagarDeuda(deuda);
            if (pagado)
            {
                MessageBox.Show("Deuda pagada correctamente.");
                btnBuscar.PerformClick();
            }
            else
            {
                MessageBox.Show("Error al pagar la deuda.");
            }
        }
    }
}
