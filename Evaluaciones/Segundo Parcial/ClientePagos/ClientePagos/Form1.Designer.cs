namespace ClientePagos
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtCi = new TextBox();
            txtNombre = new TextBox();
            txtPrimerApellido = new TextBox();
            txtSegundoApellido = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnBuscar = new Button();
            dgvDeudas = new DataGridView();
            btnPagar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDeudas).BeginInit();
            SuspendLayout();
            // 
            // txtCi
            // 
            txtCi.Location = new Point(213, 80);
            txtCi.Name = "txtCi";
            txtCi.Size = new Size(125, 27);
            txtCi.TabIndex = 0;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(213, 141);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(125, 27);
            txtNombre.TabIndex = 1;
            // 
            // txtPrimerApellido
            // 
            txtPrimerApellido.Location = new Point(213, 198);
            txtPrimerApellido.Name = "txtPrimerApellido";
            txtPrimerApellido.Size = new Size(125, 27);
            txtPrimerApellido.TabIndex = 2;
            // 
            // txtSegundoApellido
            // 
            txtSegundoApellido.Location = new Point(213, 262);
            txtSegundoApellido.Name = "txtSegundoApellido";
            txtSegundoApellido.Size = new Size(125, 27);
            txtSegundoApellido.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(78, 87);
            label1.Name = "label1";
            label1.Size = new Size(22, 20);
            label1.TabIndex = 4;
            label1.Text = "CI";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(78, 148);
            label2.Name = "label2";
            label2.Size = new Size(64, 20);
            label2.TabIndex = 5;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(78, 205);
            label3.Name = "label3";
            label3.Size = new Size(111, 20);
            label3.TabIndex = 6;
            label3.Text = "Primer apellido";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(78, 269);
            label4.Name = "label4";
            label4.Size = new Size(127, 20);
            label4.TabIndex = 7;
            label4.Text = "Segundo apellido";
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(139, 323);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(135, 85);
            btnBuscar.TabIndex = 8;
            btnBuscar.Text = "Obtener deudas";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += button1_Click;
            // 
            // dgvDeudas
            // 
            dgvDeudas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDeudas.Location = new Point(434, 87);
            dgvDeudas.Name = "dgvDeudas";
            dgvDeudas.RowHeadersWidth = 51;
            dgvDeudas.Size = new Size(300, 188);
            dgvDeudas.TabIndex = 9;
            // 
            // btnPagar
            // 
            btnPagar.Location = new Point(537, 306);
            btnPagar.Name = "btnPagar";
            btnPagar.Size = new Size(94, 29);
            btnPagar.TabIndex = 10;
            btnPagar.Text = "Pagar";
            btnPagar.UseVisualStyleBackColor = true;
            btnPagar.Click += btnPagar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnPagar);
            Controls.Add(dgvDeudas);
            Controls.Add(btnBuscar);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtSegundoApellido);
            Controls.Add(txtPrimerApellido);
            Controls.Add(txtNombre);
            Controls.Add(txtCi);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvDeudas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCi;
        private TextBox txtNombre;
        private TextBox txtPrimerApellido;
        private TextBox txtSegundoApellido;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button btnBuscar;
        private DataGridView dgvDeudas;
        private Button btnPagar;
    }
}
