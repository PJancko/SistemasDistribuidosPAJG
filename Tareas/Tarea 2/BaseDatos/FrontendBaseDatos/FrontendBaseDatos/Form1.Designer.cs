namespace FrontendBaseDatos
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
            txtNombre = new TextBox();
            txtId = new TextBox();
            txtEdad = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dgvPersonas = new DataGridView();
            btnAgregar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnListar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPersonas).BeginInit();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(175, 118);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(125, 27);
            txtNombre.TabIndex = 0;
            // 
            // txtId
            // 
            txtId.Location = new Point(175, 66);
            txtId.Name = "txtId";
            txtId.Size = new Size(125, 27);
            txtId.TabIndex = 1;
            // 
            // txtEdad
            // 
            txtEdad.Location = new Point(175, 171);
            txtEdad.Name = "txtEdad";
            txtEdad.Size = new Size(125, 27);
            txtEdad.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(98, 66);
            label1.Name = "label1";
            label1.Size = new Size(22, 20);
            label1.TabIndex = 3;
            label1.Text = "Id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(98, 118);
            label2.Name = "label2";
            label2.Size = new Size(64, 20);
            label2.TabIndex = 4;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(98, 171);
            label3.Name = "label3";
            label3.Size = new Size(43, 20);
            label3.TabIndex = 5;
            label3.Text = "Edad";
            // 
            // dgvPersonas
            // 
            dgvPersonas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPersonas.Location = new Point(390, 66);
            dgvPersonas.Name = "dgvPersonas";
            dgvPersonas.RowHeadersWidth = 51;
            dgvPersonas.Size = new Size(327, 272);
            dgvPersonas.TabIndex = 6;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(68, 239);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(94, 29);
            btnAgregar.TabIndex = 7;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(226, 239);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(94, 29);
            btnActualizar.TabIndex = 8;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(68, 309);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 29);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnListar
            // 
            btnListar.Location = new Point(226, 309);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(94, 29);
            btnListar.TabIndex = 10;
            btnListar.Text = "Listar";
            btnListar.UseVisualStyleBackColor = true;
            btnListar.Click += btnListar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnListar);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(btnAgregar);
            Controls.Add(dgvPersonas);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtEdad);
            Controls.Add(txtId);
            Controls.Add(txtNombre);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvPersonas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNombre;
        private TextBox txtId;
        private TextBox txtEdad;
        private Label label1;
        private Label label2;
        private Label label3;
        private DataGridView dgvPersonas;
        private Button btnAgregar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnListar;
    }
}
