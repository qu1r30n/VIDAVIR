namespace tienda
{
    partial class ventas
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
            this.txt_buscar_producto = new System.Windows.Forms.TextBox();
            this.lst_ventas = new System.Windows.Forms.ListBox();
            this.btn_eliminar_seleccionado = new System.Windows.Forms.Button();
            this.btn_eliminar_todo = new System.Windows.Forms.Button();
            this.btn_procesar_venta = new System.Windows.Forms.Button();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.btn_elim_ultimo = new System.Windows.Forms.Button();
            this.pb_product = new System.Windows.Forms.PictureBox();
            this.lbl_cuenta = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pb_product)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_buscar_producto
            // 
            this.txt_buscar_producto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_buscar_producto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_buscar_producto.Location = new System.Drawing.Point(0, 275);
            this.txt_buscar_producto.Name = "txt_buscar_producto";
            this.txt_buscar_producto.Size = new System.Drawing.Size(150, 20);
            this.txt_buscar_producto.TabIndex = 0;
            this.txt_buscar_producto.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txt_buscar_producto_PreviewKeyDown);
            // 
            // lst_ventas
            // 
            this.lst_ventas.FormattingEnabled = true;
            this.lst_ventas.Location = new System.Drawing.Point(0, 0);
            this.lst_ventas.Name = "lst_ventas";
            this.lst_ventas.Size = new System.Drawing.Size(239, 251);
            this.lst_ventas.TabIndex = 7;
            // 
            // btn_eliminar_seleccionado
            // 
            this.btn_eliminar_seleccionado.Location = new System.Drawing.Point(245, 104);
            this.btn_eliminar_seleccionado.Name = "btn_eliminar_seleccionado";
            this.btn_eliminar_seleccionado.Size = new System.Drawing.Size(86, 42);
            this.btn_eliminar_seleccionado.TabIndex = 6;
            this.btn_eliminar_seleccionado.Text = "eliminar seleccionado";
            this.btn_eliminar_seleccionado.UseVisualStyleBackColor = true;
            this.btn_eliminar_seleccionado.Click += new System.EventHandler(this.btn_eliminar_seleccionado_Click);
            // 
            // btn_eliminar_todo
            // 
            this.btn_eliminar_todo.Location = new System.Drawing.Point(245, 152);
            this.btn_eliminar_todo.Name = "btn_eliminar_todo";
            this.btn_eliminar_todo.Size = new System.Drawing.Size(75, 23);
            this.btn_eliminar_todo.TabIndex = 5;
            this.btn_eliminar_todo.Text = "eliminar todo";
            this.btn_eliminar_todo.UseVisualStyleBackColor = true;
            this.btn_eliminar_todo.Click += new System.EventHandler(this.btn_eliminar_todo_Click);
            // 
            // btn_procesar_venta
            // 
            this.btn_procesar_venta.Location = new System.Drawing.Point(245, 231);
            this.btn_procesar_venta.Name = "btn_procesar_venta";
            this.btn_procesar_venta.Size = new System.Drawing.Size(75, 23);
            this.btn_procesar_venta.TabIndex = 1;
            this.btn_procesar_venta.Text = "procesar venta";
            this.btn_procesar_venta.UseVisualStyleBackColor = true;
            this.btn_procesar_venta.Click += new System.EventHandler(this.btn_procesar_venta_Click);
            // 
            // btn_agregar
            // 
            this.btn_agregar.Location = new System.Drawing.Point(156, 272);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(75, 23);
            this.btn_agregar.TabIndex = 2;
            this.btn_agregar.Text = "agregar";
            this.btn_agregar.UseVisualStyleBackColor = true;
            this.btn_agregar.Click += new System.EventHandler(this.btn_agregar_Click);
            // 
            // btn_elim_ultimo
            // 
            this.btn_elim_ultimo.Location = new System.Drawing.Point(245, 185);
            this.btn_elim_ultimo.Name = "btn_elim_ultimo";
            this.btn_elim_ultimo.Size = new System.Drawing.Size(75, 40);
            this.btn_elim_ultimo.TabIndex = 4;
            this.btn_elim_ultimo.Text = "eliminar ultimo";
            this.btn_elim_ultimo.UseVisualStyleBackColor = true;
            this.btn_elim_ultimo.Click += new System.EventHandler(this.btn_elim_ultimo_Click);
            // 
            // pb_product
            // 
            this.pb_product.Location = new System.Drawing.Point(242, 3);
            this.pb_product.Name = "pb_product";
            this.pb_product.Size = new System.Drawing.Size(103, 95);
            this.pb_product.TabIndex = 7;
            this.pb_product.TabStop = false;
            // 
            // lbl_cuenta
            // 
            this.lbl_cuenta.AutoSize = true;
            this.lbl_cuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cuenta.Location = new System.Drawing.Point(237, 268);
            this.lbl_cuenta.Name = "lbl_cuenta";
            this.lbl_cuenta.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_cuenta.Size = new System.Drawing.Size(24, 25);
            this.lbl_cuenta.TabIndex = 3;
            this.lbl_cuenta.Text = "$";
            // 
            // ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 323);
            this.Controls.Add(this.lbl_cuenta);
            this.Controls.Add(this.pb_product);
            this.Controls.Add(this.btn_elim_ultimo);
            this.Controls.Add(this.btn_agregar);
            this.Controls.Add(this.btn_procesar_venta);
            this.Controls.Add(this.btn_eliminar_todo);
            this.Controls.Add(this.btn_eliminar_seleccionado);
            this.Controls.Add(this.lst_ventas);
            this.Controls.Add(this.txt_buscar_producto);
            this.Name = "ventas";
            this.Text = "ventas";
            ((System.ComponentModel.ISupportInitialize)(this.pb_product)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_buscar_producto;
        private System.Windows.Forms.ListBox lst_ventas;
        private System.Windows.Forms.Button btn_eliminar_seleccionado;
        private System.Windows.Forms.Button btn_eliminar_todo;
        private System.Windows.Forms.Button btn_procesar_venta;
        private System.Windows.Forms.Button btn_agregar;
        private System.Windows.Forms.Button btn_elim_ultimo;
        private System.Windows.Forms.PictureBox pb_product;
        private System.Windows.Forms.Label lbl_cuenta;
    }
}