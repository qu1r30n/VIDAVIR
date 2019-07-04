namespace tienda
{
    partial class pedidos
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
            this.btn_elim_ultimo = new System.Windows.Forms.Button();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.btn_procesar_venta = new System.Windows.Forms.Button();
            this.btn_eliminar_todo = new System.Windows.Forms.Button();
            this.btn_eliminar_seleccionado = new System.Windows.Forms.Button();
            this.lst_ventas = new System.Windows.Forms.ListBox();
            this.txt_buscar_producto = new System.Windows.Forms.TextBox();
            this.lbl_producto = new System.Windows.Forms.Label();
            this.lbl_cantidad = new System.Windows.Forms.Label();
            this.txt_cantidad = new System.Windows.Forms.TextBox();
            this.lbl_cuenta = new System.Windows.Forms.Label();
            this.txt_costo_unitario = new System.Windows.Forms.TextBox();
            this.lbl_costo_unitario = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_elim_ultimo
            // 
            this.btn_elim_ultimo.Location = new System.Drawing.Point(904, 158);
            this.btn_elim_ultimo.Name = "btn_elim_ultimo";
            this.btn_elim_ultimo.Size = new System.Drawing.Size(75, 40);
            this.btn_elim_ultimo.TabIndex = 6;
            this.btn_elim_ultimo.Text = "eliminar ultimo";
            this.btn_elim_ultimo.UseVisualStyleBackColor = true;
            this.btn_elim_ultimo.Click += new System.EventHandler(this.btn_elim_ultimo_Click);
            // 
            // btn_agregar
            // 
            this.btn_agregar.Location = new System.Drawing.Point(12, 317);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(189, 23);
            this.btn_agregar.TabIndex = 5;
            this.btn_agregar.Text = "agregar";
            this.btn_agregar.UseVisualStyleBackColor = true;
            this.btn_agregar.Click += new System.EventHandler(this.btn_agregar_Click);
            // 
            // btn_procesar_venta
            // 
            this.btn_procesar_venta.Location = new System.Drawing.Point(904, 204);
            this.btn_procesar_venta.Name = "btn_procesar_venta";
            this.btn_procesar_venta.Size = new System.Drawing.Size(75, 23);
            this.btn_procesar_venta.TabIndex = 2;
            this.btn_procesar_venta.Text = "procesar venta";
            this.btn_procesar_venta.UseVisualStyleBackColor = true;
            this.btn_procesar_venta.Click += new System.EventHandler(this.btn_procesar_venta_Click);
            // 
            // btn_eliminar_todo
            // 
            this.btn_eliminar_todo.Location = new System.Drawing.Point(904, 125);
            this.btn_eliminar_todo.Name = "btn_eliminar_todo";
            this.btn_eliminar_todo.Size = new System.Drawing.Size(75, 23);
            this.btn_eliminar_todo.TabIndex = 7;
            this.btn_eliminar_todo.Text = "eliminar todo";
            this.btn_eliminar_todo.UseVisualStyleBackColor = true;
            this.btn_eliminar_todo.Click += new System.EventHandler(this.btn_eliminar_todo_Click);
            // 
            // btn_eliminar_seleccionado
            // 
            this.btn_eliminar_seleccionado.Location = new System.Drawing.Point(904, 77);
            this.btn_eliminar_seleccionado.Name = "btn_eliminar_seleccionado";
            this.btn_eliminar_seleccionado.Size = new System.Drawing.Size(86, 42);
            this.btn_eliminar_seleccionado.TabIndex = 8;
            this.btn_eliminar_seleccionado.Text = "eliminar seleccionado";
            this.btn_eliminar_seleccionado.UseVisualStyleBackColor = true;
            this.btn_eliminar_seleccionado.Click += new System.EventHandler(this.btn_eliminar_seleccionado_Click);
            // 
            // lst_ventas
            // 
            this.lst_ventas.FormattingEnabled = true;
            this.lst_ventas.Location = new System.Drawing.Point(12, 12);
            this.lst_ventas.Name = "lst_ventas";
            this.lst_ventas.Size = new System.Drawing.Size(886, 251);
            this.lst_ventas.TabIndex = 9;
            // 
            // txt_buscar_producto
            // 
            this.txt_buscar_producto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txt_buscar_producto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txt_buscar_producto.Location = new System.Drawing.Point(12, 288);
            this.txt_buscar_producto.Name = "txt_buscar_producto";
            this.txt_buscar_producto.Size = new System.Drawing.Size(104, 20);
            this.txt_buscar_producto.TabIndex = 1;
            this.txt_buscar_producto.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txt_buscar_producto_PreviewKeyDown);
            // 
            // lbl_producto
            // 
            this.lbl_producto.AutoSize = true;
            this.lbl_producto.Location = new System.Drawing.Point(9, 272);
            this.lbl_producto.Name = "lbl_producto";
            this.lbl_producto.Size = new System.Drawing.Size(49, 13);
            this.lbl_producto.TabIndex = 14;
            this.lbl_producto.Text = "producto";
            // 
            // lbl_cantidad
            // 
            this.lbl_cantidad.AutoSize = true;
            this.lbl_cantidad.Location = new System.Drawing.Point(119, 272);
            this.lbl_cantidad.Name = "lbl_cantidad";
            this.lbl_cantidad.Size = new System.Drawing.Size(48, 13);
            this.lbl_cantidad.TabIndex = 15;
            this.lbl_cantidad.Text = "cantidad";
            // 
            // txt_cantidad
            // 
            this.txt_cantidad.Location = new System.Drawing.Point(122, 288);
            this.txt_cantidad.Name = "txt_cantidad";
            this.txt_cantidad.Size = new System.Drawing.Size(79, 20);
            this.txt_cantidad.TabIndex = 3;
            this.txt_cantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_cantidad_KeyPress);
            // 
            // lbl_cuenta
            // 
            this.lbl_cuenta.AutoSize = true;
            this.lbl_cuenta.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_cuenta.Location = new System.Drawing.Point(207, 312);
            this.lbl_cuenta.Name = "lbl_cuenta";
            this.lbl_cuenta.Size = new System.Drawing.Size(30, 31);
            this.lbl_cuenta.TabIndex = 10;
            this.lbl_cuenta.Text = "$";
            // 
            // txt_costo_unitario
            // 
            this.txt_costo_unitario.Location = new System.Drawing.Point(207, 288);
            this.txt_costo_unitario.Name = "txt_costo_unitario";
            this.txt_costo_unitario.Size = new System.Drawing.Size(79, 20);
            this.txt_costo_unitario.TabIndex = 4;
            this.txt_costo_unitario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_costo_unitario_KeyPress);
            // 
            // lbl_costo_unitario
            // 
            this.lbl_costo_unitario.AutoSize = true;
            this.lbl_costo_unitario.Location = new System.Drawing.Point(204, 272);
            this.lbl_costo_unitario.Name = "lbl_costo_unitario";
            this.lbl_costo_unitario.Size = new System.Drawing.Size(70, 13);
            this.lbl_costo_unitario.TabIndex = 18;
            this.lbl_costo_unitario.Text = "costo unitario";
            // 
            // pedidos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 352);
            this.Controls.Add(this.txt_costo_unitario);
            this.Controls.Add(this.lbl_costo_unitario);
            this.Controls.Add(this.lbl_cuenta);
            this.Controls.Add(this.txt_cantidad);
            this.Controls.Add(this.lbl_cantidad);
            this.Controls.Add(this.lbl_producto);
            this.Controls.Add(this.btn_elim_ultimo);
            this.Controls.Add(this.btn_agregar);
            this.Controls.Add(this.btn_procesar_venta);
            this.Controls.Add(this.btn_eliminar_todo);
            this.Controls.Add(this.btn_eliminar_seleccionado);
            this.Controls.Add(this.lst_ventas);
            this.Controls.Add(this.txt_buscar_producto);
            this.Name = "pedidos";
            this.Text = "pedidos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_elim_ultimo;
        private System.Windows.Forms.Button btn_agregar;
        private System.Windows.Forms.Button btn_procesar_venta;
        private System.Windows.Forms.Button btn_eliminar_todo;
        private System.Windows.Forms.Button btn_eliminar_seleccionado;
        private System.Windows.Forms.ListBox lst_ventas;
        private System.Windows.Forms.TextBox txt_buscar_producto;
        private System.Windows.Forms.Label lbl_producto;
        private System.Windows.Forms.Label lbl_cantidad;
        private System.Windows.Forms.TextBox txt_cantidad;
        private System.Windows.Forms.Label lbl_cuenta;
        private System.Windows.Forms.TextBox txt_costo_unitario;
        private System.Windows.Forms.Label lbl_costo_unitario;
    }
}