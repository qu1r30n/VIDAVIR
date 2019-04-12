namespace tienda
{
    partial class confirmar_venta
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
            this.lbl_titulo_total = new System.Windows.Forms.Label();
            this.lbl_total = new System.Windows.Forms.Label();
            this.lbl_dinero = new System.Windows.Forms.Label();
            this.txt_dinero = new System.Windows.Forms.TextBox();
            this.btn_pagar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_titulo_total
            // 
            this.lbl_titulo_total.AutoSize = true;
            this.lbl_titulo_total.Location = new System.Drawing.Point(31, 13);
            this.lbl_titulo_total.Name = "lbl_titulo_total";
            this.lbl_titulo_total.Size = new System.Drawing.Size(66, 13);
            this.lbl_titulo_total.TabIndex = 0;
            this.lbl_titulo_total.Text = "total a pagar";
            // 
            // lbl_total
            // 
            this.lbl_total.AutoSize = true;
            this.lbl_total.Location = new System.Drawing.Point(31, 31);
            this.lbl_total.Name = "lbl_total";
            this.lbl_total.Size = new System.Drawing.Size(13, 13);
            this.lbl_total.TabIndex = 1;
            this.lbl_total.Text = "$";
            // 
            // lbl_dinero
            // 
            this.lbl_dinero.AutoSize = true;
            this.lbl_dinero.Location = new System.Drawing.Point(168, 13);
            this.lbl_dinero.Name = "lbl_dinero";
            this.lbl_dinero.Size = new System.Drawing.Size(74, 13);
            this.lbl_dinero.TabIndex = 2;
            this.lbl_dinero.Text = "dinero que dio";
            // 
            // txt_dinero
            // 
            this.txt_dinero.Location = new System.Drawing.Point(171, 28);
            this.txt_dinero.Name = "txt_dinero";
            this.txt_dinero.Size = new System.Drawing.Size(100, 20);
            this.txt_dinero.TabIndex = 3;
            // 
            // btn_pagar
            // 
            this.btn_pagar.Location = new System.Drawing.Point(277, 12);
            this.btn_pagar.Name = "btn_pagar";
            this.btn_pagar.Size = new System.Drawing.Size(75, 50);
            this.btn_pagar.TabIndex = 4;
            this.btn_pagar.Text = "pagar";
            this.btn_pagar.UseVisualStyleBackColor = true;
            this.btn_pagar.Click += new System.EventHandler(this.btn_pagar_Click);
            // 
            // confirmar_venta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 74);
            this.Controls.Add(this.btn_pagar);
            this.Controls.Add(this.txt_dinero);
            this.Controls.Add(this.lbl_dinero);
            this.Controls.Add(this.lbl_total);
            this.Controls.Add(this.lbl_titulo_total);
            this.Name = "confirmar_venta";
            this.Text = "confirmar_venta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_titulo_total;
        private System.Windows.Forms.Label lbl_dinero;
        private System.Windows.Forms.TextBox txt_dinero;
        private System.Windows.Forms.Button btn_pagar;
        public System.Windows.Forms.Label lbl_total;
    }
}