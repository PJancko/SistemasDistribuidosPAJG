namespace OficinaTramites
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
            txtNombres = new TextBox();
            txtPrimerApellido = new TextBox();
            txtSegundoApellido = new TextBox();
            txtTitulo = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            btnEmitir = new Button();
            lblEstadoServicios = new Label();
            SuspendLayout();
            // 
            // txtCi
            // 
            txtCi.Location = new Point(240, 66);
            txtCi.Name = "txtCi";
            txtCi.Size = new Size(125, 27);
            txtCi.TabIndex = 0;
            // 
            // txtNombres
            // 
            txtNombres.Location = new Point(240, 129);
            txtNombres.Name = "txtNombres";
            txtNombres.Size = new Size(125, 27);
            txtNombres.TabIndex = 1;
            // 
            // txtPrimerApellido
            // 
            txtPrimerApellido.Location = new Point(240, 184);
            txtPrimerApellido.Name = "txtPrimerApellido";
            txtPrimerApellido.Size = new Size(125, 27);
            txtPrimerApellido.TabIndex = 2;
            // 
            // txtSegundoApellido
            // 
            txtSegundoApellido.Location = new Point(240, 242);
            txtSegundoApellido.Name = "txtSegundoApellido";
            txtSegundoApellido.Size = new Size(125, 27);
            txtSegundoApellido.TabIndex = 3;
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(240, 304);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(125, 27);
            txtTitulo.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(59, 66);
            label1.Name = "label1";
            label1.Size = new Size(22, 20);
            label1.TabIndex = 5;
            label1.Text = "CI";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(59, 129);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 6;
            label2.Text = "Nombres";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(59, 184);
            label3.Name = "label3";
            label3.Size = new Size(113, 20);
            label3.TabIndex = 7;
            label3.Text = "Primer Apellido";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(59, 242);
            label4.Name = "label4";
            label4.Size = new Size(127, 20);
            label4.TabIndex = 8;
            label4.Text = "Segundo apellido";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(59, 304);
            label5.Name = "label5";
            label5.Size = new Size(47, 20);
            label5.TabIndex = 9;
            label5.Text = "Titulo";
            // 
            // btnEmitir
            // 
            btnEmitir.Location = new Point(553, 92);
            btnEmitir.Name = "btnEmitir";
            btnEmitir.Size = new Size(130, 44);
            btnEmitir.TabIndex = 10;
            btnEmitir.Text = "Emitir titulo";
            btnEmitir.UseVisualStyleBackColor = true;
            btnEmitir.Click += btnEmitir_Click;
            // 
            // lblEstadoServicios
            // 
            lblEstadoServicios.AutoSize = true;
            lblEstadoServicios.Location = new Point(573, 222);
            lblEstadoServicios.Name = "lblEstadoServicios";
            lblEstadoServicios.Size = new Size(89, 20);
            lblEstadoServicios.TabIndex = 11;
            lblEstadoServicios.Text = "Informacion";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblEstadoServicios);
            Controls.Add(btnEmitir);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtTitulo);
            Controls.Add(txtSegundoApellido);
            Controls.Add(txtPrimerApellido);
            Controls.Add(txtNombres);
            Controls.Add(txtCi);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtCi;
        private TextBox txtNombres;
        private TextBox txtPrimerApellido;
        private TextBox txtSegundoApellido;
        private TextBox txtTitulo;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnEmitir;
        private Label lblEstadoServicios;
    }
}
