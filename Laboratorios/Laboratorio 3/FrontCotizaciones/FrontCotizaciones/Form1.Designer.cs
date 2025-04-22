namespace FrontCotizaciones
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
            label1 = new Label();
            txtFechaConsulta = new TextBox();
            btnConsultar = new Button();
            lblResultadoConsulta = new Label();
            label2 = new Label();
            txtFechaRegistro = new TextBox();
            label3 = new Label();
            txtMonto = new TextBox();
            btnRegistrar = new Button();
            lblResultadoRegistro = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(58, 138);
            label1.Name = "label1";
            label1.Size = new Size(153, 20);
            label1.TabIndex = 0;
            label1.Text = "Fecha (YYYY-MM-DD)";
            // 
            // txtFechaConsulta
            // 
            txtFechaConsulta.Location = new Point(58, 186);
            txtFechaConsulta.Name = "txtFechaConsulta";
            txtFechaConsulta.Size = new Size(125, 27);
            txtFechaConsulta.TabIndex = 1;
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(139, 260);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(94, 29);
            btnConsultar.TabIndex = 2;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // lblResultadoConsulta
            // 
            lblResultadoConsulta.AutoSize = true;
            lblResultadoConsulta.Location = new Point(245, 189);
            lblResultadoConsulta.Name = "lblResultadoConsulta";
            lblResultadoConsulta.Size = new Size(75, 20);
            lblResultadoConsulta.TabIndex = 3;
            lblResultadoConsulta.Text = "Resultado";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(451, 138);
            label2.Name = "label2";
            label2.Size = new Size(153, 20);
            label2.TabIndex = 4;
            label2.Text = "Fecha (YYYY-MM-DD)";
            // 
            // txtFechaRegistro
            // 
            txtFechaRegistro.Location = new Point(451, 186);
            txtFechaRegistro.Name = "txtFechaRegistro";
            txtFechaRegistro.Size = new Size(125, 27);
            txtFechaRegistro.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(451, 243);
            label3.Name = "label3";
            label3.Size = new Size(53, 20);
            label3.TabIndex = 6;
            label3.Text = "Monto";
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(451, 284);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(125, 27);
            txtMonto.TabIndex = 7;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(451, 339);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(94, 29);
            btnRegistrar.TabIndex = 8;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // lblResultadoRegistro
            // 
            lblResultadoRegistro.AutoSize = true;
            lblResultadoRegistro.Location = new Point(686, 189);
            lblResultadoRegistro.Name = "lblResultadoRegistro";
            lblResultadoRegistro.Size = new Size(75, 20);
            lblResultadoRegistro.TabIndex = 9;
            lblResultadoRegistro.Text = "Resultado";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(526, 65);
            label4.Name = "label4";
            label4.Size = new Size(126, 38);
            label4.TabIndex = 10;
            label4.Text = "Registrar";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(139, 65);
            label5.Name = "label5";
            label5.Size = new Size(134, 38);
            label5.TabIndex = 11;
            label5.Text = "Consultar";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(lblResultadoRegistro);
            Controls.Add(btnRegistrar);
            Controls.Add(txtMonto);
            Controls.Add(label3);
            Controls.Add(txtFechaRegistro);
            Controls.Add(label2);
            Controls.Add(lblResultadoConsulta);
            Controls.Add(btnConsultar);
            Controls.Add(txtFechaConsulta);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtFechaConsulta;
        private Button btnConsultar;
        private Label lblResultadoConsulta;
        private Label label2;
        private TextBox txtFechaRegistro;
        private Label label3;
        private TextBox txtMonto;
        private Button btnRegistrar;
        private Label lblResultadoRegistro;
        private Label label4;
        private Label label5;
    }
}
