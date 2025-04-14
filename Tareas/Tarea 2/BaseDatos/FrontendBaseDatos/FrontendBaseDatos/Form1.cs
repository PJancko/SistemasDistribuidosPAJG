namespace FrontendBaseDatos
{
    public partial class Form1 : Form
    {

        rsPersona.wsPersonaSoapClient servicio = new rsPersona.wsPersonaSoapClient(rsPersona.wsPersonaSoapClient.EndpointConfiguration.wsPersonaSoap12);

        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            String nombre = txtNombre.Text;
            int edad = int.Parse(txtEdad.Text);

            String resultado = servicio.AgregarPersona(nombre, edad);
            MessageBox.Show(resultado);
            ListarPersonas();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            string nombre = txtNombre.Text;
            int edad = int.Parse(txtEdad.Text);

            string resultado = servicio.ActualizarPersona(id, nombre, edad);
            MessageBox.Show(resultado);
            ListarPersonas();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);

            string resultado = servicio.EliminarPersona(id);
            MessageBox.Show(resultado);
            ListarPersonas();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            ListarPersonas();
        }

        private void ListarPersonas()
        {
            var personas = servicio.ObtenerPersonas();
            dgvPersonas.DataSource = personas;
        }
    }
}
