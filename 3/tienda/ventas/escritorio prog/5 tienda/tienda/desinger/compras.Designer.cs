namespace tienda
{
    partial class compras
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_razon = new System.Windows.Forms.TextBox();
            this.txt_quien_facturo = new System.Windows.Forms.TextBox();
            this.txt_cantidad_gastada = new System.Windows.Forms.TextBox();
            this.btn_guardar_compra = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "razon de compra";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "cantidad gastada";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "quien facturo(si no hubo factura no poner nada)";
            // 
            // txt_razon
            // 
            this.txt_razon.Location = new System.Drawing.Point(12, 25);
            this.txt_razon.Name = "txt_razon";
            this.txt_razon.Size = new System.Drawing.Size(386, 20);
            this.txt_razon.TabIndex = 3;
            // 
            // txt_quien_facturo
            // 
            this.txt_quien_facturo.Location = new System.Drawing.Point(15, 77);
            this.txt_quien_facturo.Name = "txt_quien_facturo";
            this.txt_quien_facturo.Size = new System.Drawing.Size(229, 20);
            this.txt_quien_facturo.TabIndex = 4;
            // 
            // txt_cantidad_gastada
            // 
            this.txt_cantidad_gastada.Location = new System.Drawing.Point(15, 120);
            this.txt_cantidad_gastada.Name = "txt_cantidad_gastada";
            this.txt_cantidad_gastada.Size = new System.Drawing.Size(100, 20);
            this.txt_cantidad_gastada.TabIndex = 5;
            // 
            // btn_guardar_compra
            // 
            this.btn_guardar_compra.Location = new System.Drawing.Point(15, 147);
            this.btn_guardar_compra.Name = "btn_guardar_compra";
            this.btn_guardar_compra.Size = new System.Drawing.Size(111, 34);
            this.btn_guardar_compra.TabIndex = 6;
            this.btn_guardar_compra.Text = "guarda compra";
            this.btn_guardar_compra.UseVisualStyleBackColor = true;
            this.btn_guardar_compra.Click += new System.EventHandler(this.btn_guardar_compra_Click);
            // 
            // compras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 193);
            this.Controls.Add(this.btn_guardar_compra);
            this.Controls.Add(this.txt_cantidad_gastada);
            this.Controls.Add(this.txt_quien_facturo);
            this.Controls.Add(this.txt_razon);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "compras";
            this.Text = "compras";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_razon;
        private System.Windows.Forms.TextBox txt_quien_facturo;
        private System.Windows.Forms.TextBox txt_cantidad_gastada;
        private System.Windows.Forms.Button btn_guardar_compra;
    }
}