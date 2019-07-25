namespace tienda
{
    partial class agregar_producto
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
            this.label2 = new System.Windows.Forms.Label();
            this.txt_producto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_precio_vent = new System.Windows.Forms.TextBox();
            this.lbl_codigo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_cantidad = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_precio_comp = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_marca = new System.Windows.Forms.TextBox();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.lbl_id = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "producto";
            // 
            // txt_producto
            // 
            this.txt_producto.Location = new System.Drawing.Point(121, 66);
            this.txt_producto.Name = "txt_producto";
            this.txt_producto.Size = new System.Drawing.Size(100, 20);
            this.txt_producto.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "precio de venta";
            // 
            // txt_precio_vent
            // 
            this.txt_precio_vent.Location = new System.Drawing.Point(227, 66);
            this.txt_precio_vent.Name = "txt_precio_vent";
            this.txt_precio_vent.Size = new System.Drawing.Size(100, 20);
            this.txt_precio_vent.TabIndex = 4;
            // 
            // lbl_codigo
            // 
            this.lbl_codigo.AutoSize = true;
            this.lbl_codigo.Location = new System.Drawing.Point(345, 66);
            this.lbl_codigo.Name = "lbl_codigo";
            this.lbl_codigo.Size = new System.Drawing.Size(39, 13);
            this.lbl_codigo.TabIndex = 7;
            this.lbl_codigo.Text = "codigo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "cantidad";
            // 
            // txt_cantidad
            // 
            this.txt_cantidad.Location = new System.Drawing.Point(15, 123);
            this.txt_cantidad.Name = "txt_cantidad";
            this.txt_cantidad.Size = new System.Drawing.Size(100, 20);
            this.txt_cantidad.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(118, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "precio de compra";
            // 
            // txt_precio_comp
            // 
            this.txt_precio_comp.Location = new System.Drawing.Point(121, 123);
            this.txt_precio_comp.Name = "txt_precio_comp";
            this.txt_precio_comp.Size = new System.Drawing.Size(100, 20);
            this.txt_precio_comp.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(224, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "marca";
            // 
            // txt_marca
            // 
            this.txt_marca.Location = new System.Drawing.Point(227, 123);
            this.txt_marca.Name = "txt_marca";
            this.txt_marca.Size = new System.Drawing.Size(100, 20);
            this.txt_marca.TabIndex = 12;
            // 
            // btn_agregar
            // 
            this.btn_agregar.Location = new System.Drawing.Point(333, 107);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(100, 37);
            this.btn_agregar.TabIndex = 14;
            this.btn_agregar.Text = "agregar";
            this.btn_agregar.UseVisualStyleBackColor = true;
            this.btn_agregar.Click += new System.EventHandler(this.btn_agregar_Click);
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.Location = new System.Drawing.Point(12, 66);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(15, 13);
            this.lbl_id.TabIndex = 1;
            this.lbl_id.Text = "id";
            // 
            // agregar_producto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 212);
            this.Controls.Add(this.btn_agregar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_marca);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_precio_comp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_cantidad);
            this.Controls.Add(this.lbl_codigo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_precio_vent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_producto);
            this.Controls.Add(this.lbl_id);
            this.Name = "agregar_producto";
            this.Text = "agregar_producto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_producto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_precio_vent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_cantidad;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_precio_comp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_marca;
        private System.Windows.Forms.Button btn_agregar;
        public System.Windows.Forms.Label lbl_codigo;
        private System.Windows.Forms.Label lbl_id;
    }
}