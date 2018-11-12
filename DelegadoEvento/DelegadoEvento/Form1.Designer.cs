namespace DelegadoEvento
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblDato = new System.Windows.Forms.Label();
            this.btnDato = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDato
            // 
            this.lblDato.AutoSize = true;
            this.lblDato.Location = new System.Drawing.Point(119, 166);
            this.lblDato.Name = "lblDato";
            this.lblDato.Size = new System.Drawing.Size(30, 13);
            this.lblDato.TabIndex = 0;
            this.lblDato.Text = "Dato";
            // 
            // btnDato
            // 
            this.btnDato.Location = new System.Drawing.Point(104, 111);
            this.btnDato.Name = "btnDato";
            this.btnDato.Size = new System.Drawing.Size(75, 23);
            this.btnDato.TabIndex = 1;
            this.btnDato.Text = "Elegir Dato";
            this.btnDato.UseVisualStyleBackColor = true;
            this.btnDato.Click += new System.EventHandler(this.btnDato_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnDato);
            this.Controls.Add(this.lblDato);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDato;
        private System.Windows.Forms.Button btnDato;
    }
}

