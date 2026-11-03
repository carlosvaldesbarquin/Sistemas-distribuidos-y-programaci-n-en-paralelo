namespace CalculadoraForms
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNumero1 = new System.Windows.Forms.Label();
            this.lblNumero2 = new System.Windows.Forms.Label();
            this.lblResultado = new System.Windows.Forms.Label();
            this.txtNumero1 = new System.Windows.Forms.TextBox();
            this.txtNumero2 = new System.Windows.Forms.TextBox();
            this.btnSumar = new System.Windows.Forms.Button();
            this.cmbOperacion = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblNumero1
            // 
            this.lblNumero1.AutoSize = true;
            this.lblNumero1.Location = new System.Drawing.Point(272, 27);
            this.lblNumero1.Name = "lblNumero1";
            this.lblNumero1.Size = new System.Drawing.Size(97, 16);
            this.lblNumero1.TabIndex = 0;
            this.lblNumero1.Text = "Primer Numero";
            // 
            // lblNumero2
            // 
            this.lblNumero2.AutoSize = true;
            this.lblNumero2.Location = new System.Drawing.Point(266, 96);
            this.lblNumero2.Name = "lblNumero2";
            this.lblNumero2.Size = new System.Drawing.Size(113, 16);
            this.lblNumero2.TabIndex = 1;
            this.lblNumero2.Text = "Segundo Numero";
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Location = new System.Drawing.Point(260, 216);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(147, 16);
            this.lblResultado.TabIndex = 2;
            this.lblResultado.Text = "Esperando operacion...";
            // 
            // txtNumero1
            // 
            this.txtNumero1.Location = new System.Drawing.Point(269, 55);
            this.txtNumero1.Name = "txtNumero1";
            this.txtNumero1.Size = new System.Drawing.Size(100, 22);
            this.txtNumero1.TabIndex = 3;
            // 
            // txtNumero2
            // 
            this.txtNumero2.Location = new System.Drawing.Point(269, 126);
            this.txtNumero2.Name = "txtNumero2";
            this.txtNumero2.Size = new System.Drawing.Size(100, 22);
            this.txtNumero2.TabIndex = 4;
            // 
            // btnSumar
            // 
            this.btnSumar.Location = new System.Drawing.Point(281, 169);
            this.btnSumar.Name = "btnSumar";
            this.btnSumar.Size = new System.Drawing.Size(75, 23);
            this.btnSumar.TabIndex = 5;
            this.btnSumar.Text = "Calcular";
            this.btnSumar.UseVisualStyleBackColor = true;
            this.btnSumar.Click += new System.EventHandler(this.btnSumar_Click);
            // 
            // cmbOperacion
            // 
            this.cmbOperacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperacion.FormattingEnabled = true;
            this.cmbOperacion.Items.AddRange(new object[] {
            "SUMAR",
            "RESTAR",
            "MULTIPLICAR",
            "DIVIDIR"});
            this.cmbOperacion.Location = new System.Drawing.Point(385, 88);
            this.cmbOperacion.Name = "cmbOperacion";
            this.cmbOperacion.Size = new System.Drawing.Size(121, 24);
            this.cmbOperacion.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cmbOperacion);
            this.Controls.Add(this.btnSumar);
            this.Controls.Add(this.txtNumero2);
            this.Controls.Add(this.txtNumero1);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.lblNumero2);
            this.Controls.Add(this.lblNumero1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNumero1;
        private System.Windows.Forms.Label lblNumero2;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.TextBox txtNumero1;
        private System.Windows.Forms.TextBox txtNumero2;
        private System.Windows.Forms.Button btnSumar;
        private System.Windows.Forms.ComboBox cmbOperacion;
    }
}

