namespace tienda
{
    partial class respaldo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_donde_guardar = new System.Windows.Forms.Button();
            this.btn_respaldar = new System.Windows.Forms.Button();
            this.lbl_direccion = new System.Windows.Forms.Label();
            this.btn_usar_respaldo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_donde_guardar
            // 
            this.btn_donde_guardar.Location = new System.Drawing.Point(12, 12);
            this.btn_donde_guardar.Name = "btn_donde_guardar";
            this.btn_donde_guardar.Size = new System.Drawing.Size(75, 36);
            this.btn_donde_guardar.TabIndex = 0;
            this.btn_donde_guardar.Text = "dond guardarlos";
            this.btn_donde_guardar.UseVisualStyleBackColor = true;
            this.btn_donde_guardar.Click += new System.EventHandler(this.btn_donde_guardar_Click);
            // 
            // btn_respaldar
            // 
            this.btn_respaldar.Location = new System.Drawing.Point(12, 122);
            this.btn_respaldar.Name = "btn_respaldar";
            this.btn_respaldar.Size = new System.Drawing.Size(75, 45);
            this.btn_respaldar.TabIndex = 1;
            this.btn_respaldar.Text = "respaldar";
            this.btn_respaldar.UseVisualStyleBackColor = true;
            this.btn_respaldar.Click += new System.EventHandler(this.btn_respaldar_Click);
            // 
            // lbl_direccion
            // 
            this.lbl_direccion.AutoSize = true;
            this.lbl_direccion.Location = new System.Drawing.Point(9, 70);
            this.lbl_direccion.MaximumSize = new System.Drawing.Size(300, 0);
            this.lbl_direccion.Name = "lbl_direccion";
            this.lbl_direccion.Size = new System.Drawing.Size(283, 26);
            this.lbl_direccion.TabIndex = 2;
            this.lbl_direccion.Text = "oprime boton donde guararlos para buscar donde poner el respaldo";
            // 
            // btn_usar_respaldo
            // 
            this.btn_usar_respaldo.Location = new System.Drawing.Point(181, 122);
            this.btn_usar_respaldo.Name = "btn_usar_respaldo";
            this.btn_usar_respaldo.Size = new System.Drawing.Size(75, 45);
            this.btn_usar_respaldo.TabIndex = 3;
            this.btn_usar_respaldo.Text = "usar respaldo";
            this.btn_usar_respaldo.UseVisualStyleBackColor = true;
            this.btn_usar_respaldo.Click += new System.EventHandler(this.btn_usar_respaldo_Click);
            // 
            // respaldo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 261);
            this.Controls.Add(this.btn_usar_respaldo);
            this.Controls.Add(this.lbl_direccion);
            this.Controls.Add(this.btn_respaldar);
            this.Controls.Add(this.btn_donde_guardar);
            this.Name = "respaldo";
            this.Text = "respaldo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_donde_guardar;
        private System.Windows.Forms.Button btn_respaldar;
        private System.Windows.Forms.Label lbl_direccion;
        private System.Windows.Forms.Button btn_usar_respaldo;
    }
}