namespace tienda
{
    partial class inventario
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
            this.lst_productos = new System.Windows.Forms.ListBox();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.txt_precio = new System.Windows.Forms.TextBox();
            this.btn_editar = new System.Windows.Forms.Button();
            this.btn_agregar = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_edit_por = new System.Windows.Forms.Button();
            this.txt_edit_nombre = new System.Windows.Forms.TextBox();
            this.txt_edit_precio = new System.Windows.Forms.TextBox();
            this.lbl_producto = new System.Windows.Forms.Label();
            this.lbl_precio = new System.Windows.Forms.Label();
            this.lbl_edit_producto = new System.Windows.Forms.Label();
            this.lbl_edit_precio = new System.Windows.Forms.Label();
            this.txt_cantidad = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_id_producto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_edit_id_producto = new System.Windows.Forms.TextBox();
            this.lbl_edit_id_producto = new System.Windows.Forms.Label();
            this.txt_edit_cantidad = new System.Windows.Forms.TextBox();
            this.lbl_edit_cantidad = new System.Windows.Forms.Label();
            this.txt_codigo = new System.Windows.Forms.TextBox();
            this.txt_edit_codigo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_edit_codigo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lst_productos
            // 
            this.lst_productos.FormattingEnabled = true;
            this.lst_productos.Location = new System.Drawing.Point(0, 0);
            this.lst_productos.Name = "lst_productos";
            this.lst_productos.Size = new System.Drawing.Size(171, 212);
            this.lst_productos.TabIndex = 0;
            this.lst_productos.SelectedIndexChanged += new System.EventHandler(this.lst_productos_SelectedIndexChanged);
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(243, 41);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(100, 20);
            this.txt_nombre.TabIndex = 1;
            // 
            // txt_precio
            // 
            this.txt_precio.Location = new System.Drawing.Point(349, 41);
            this.txt_precio.Name = "txt_precio";
            this.txt_precio.Size = new System.Drawing.Size(100, 20);
            this.txt_precio.TabIndex = 2;
            // 
            // btn_editar
            // 
            this.btn_editar.Location = new System.Drawing.Point(258, 67);
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(75, 23);
            this.btn_editar.TabIndex = 3;
            this.btn_editar.Text = "editar";
            this.btn_editar.UseVisualStyleBackColor = true;
            this.btn_editar.Click += new System.EventHandler(this.btn_editar_Click);
            // 
            // btn_agregar
            // 
            this.btn_agregar.Location = new System.Drawing.Point(177, 67);
            this.btn_agregar.Name = "btn_agregar";
            this.btn_agregar.Size = new System.Drawing.Size(75, 23);
            this.btn_agregar.TabIndex = 4;
            this.btn_agregar.Text = "agregar";
            this.btn_agregar.UseVisualStyleBackColor = true;
            this.btn_agregar.Click += new System.EventHandler(this.btn_agregar_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.Location = new System.Drawing.Point(339, 67);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(75, 23);
            this.btn_eliminar.TabIndex = 5;
            this.btn_eliminar.Text = "eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = true;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btn_edit_por
            // 
            this.btn_edit_por.Location = new System.Drawing.Point(180, 200);
            this.btn_edit_por.Name = "btn_edit_por";
            this.btn_edit_por.Size = new System.Drawing.Size(75, 23);
            this.btn_edit_por.TabIndex = 6;
            this.btn_edit_por.Text = "editar ";
            this.btn_edit_por.UseVisualStyleBackColor = true;
            this.btn_edit_por.Visible = false;
            this.btn_edit_por.Click += new System.EventHandler(this.btn_edit_por_Click);
            // 
            // txt_edit_nombre
            // 
            this.txt_edit_nombre.Location = new System.Drawing.Point(243, 156);
            this.txt_edit_nombre.Name = "txt_edit_nombre";
            this.txt_edit_nombre.Size = new System.Drawing.Size(100, 20);
            this.txt_edit_nombre.TabIndex = 7;
            this.txt_edit_nombre.Visible = false;
            // 
            // txt_edit_precio
            // 
            this.txt_edit_precio.Location = new System.Drawing.Point(349, 156);
            this.txt_edit_precio.Name = "txt_edit_precio";
            this.txt_edit_precio.Size = new System.Drawing.Size(100, 20);
            this.txt_edit_precio.TabIndex = 8;
            this.txt_edit_precio.Visible = false;
            // 
            // lbl_producto
            // 
            this.lbl_producto.AutoSize = true;
            this.lbl_producto.Location = new System.Drawing.Point(243, 25);
            this.lbl_producto.Name = "lbl_producto";
            this.lbl_producto.Size = new System.Drawing.Size(49, 13);
            this.lbl_producto.TabIndex = 9;
            this.lbl_producto.Text = "producto";
            // 
            // lbl_precio
            // 
            this.lbl_precio.AutoSize = true;
            this.lbl_precio.Location = new System.Drawing.Point(346, 25);
            this.lbl_precio.Name = "lbl_precio";
            this.lbl_precio.Size = new System.Drawing.Size(36, 13);
            this.lbl_precio.TabIndex = 9;
            this.lbl_precio.Text = "precio";
            // 
            // lbl_edit_producto
            // 
            this.lbl_edit_producto.AutoSize = true;
            this.lbl_edit_producto.Location = new System.Drawing.Point(243, 140);
            this.lbl_edit_producto.Name = "lbl_edit_producto";
            this.lbl_edit_producto.Size = new System.Drawing.Size(49, 13);
            this.lbl_edit_producto.TabIndex = 9;
            this.lbl_edit_producto.Text = "producto";
            this.lbl_edit_producto.Visible = false;
            // 
            // lbl_edit_precio
            // 
            this.lbl_edit_precio.AutoSize = true;
            this.lbl_edit_precio.Location = new System.Drawing.Point(346, 140);
            this.lbl_edit_precio.Name = "lbl_edit_precio";
            this.lbl_edit_precio.Size = new System.Drawing.Size(36, 13);
            this.lbl_edit_precio.TabIndex = 9;
            this.lbl_edit_precio.Text = "precio";
            this.lbl_edit_precio.Visible = false;
            // 
            // txt_cantidad
            // 
            this.txt_cantidad.Location = new System.Drawing.Point(561, 41);
            this.txt_cantidad.Name = "txt_cantidad";
            this.txt_cantidad.Size = new System.Drawing.Size(100, 20);
            this.txt_cantidad.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(558, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "cantidad";
            // 
            // txt_id_producto
            // 
            this.txt_id_producto.Location = new System.Drawing.Point(176, 41);
            this.txt_id_producto.Name = "txt_id_producto";
            this.txt_id_producto.Size = new System.Drawing.Size(61, 20);
            this.txt_id_producto.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "id producto";
            // 
            // txt_edit_id_producto
            // 
            this.txt_edit_id_producto.Location = new System.Drawing.Point(176, 156);
            this.txt_edit_id_producto.Name = "txt_edit_id_producto";
            this.txt_edit_id_producto.Size = new System.Drawing.Size(61, 20);
            this.txt_edit_id_producto.TabIndex = 12;
            this.txt_edit_id_producto.Visible = false;
            // 
            // lbl_edit_id_producto
            // 
            this.lbl_edit_id_producto.AutoSize = true;
            this.lbl_edit_id_producto.Location = new System.Drawing.Point(177, 140);
            this.lbl_edit_id_producto.Name = "lbl_edit_id_producto";
            this.lbl_edit_id_producto.Size = new System.Drawing.Size(60, 13);
            this.lbl_edit_id_producto.TabIndex = 13;
            this.lbl_edit_id_producto.Text = "id producto";
            this.lbl_edit_id_producto.Visible = false;
            // 
            // txt_edit_cantidad
            // 
            this.txt_edit_cantidad.Location = new System.Drawing.Point(561, 156);
            this.txt_edit_cantidad.Name = "txt_edit_cantidad";
            this.txt_edit_cantidad.Size = new System.Drawing.Size(100, 20);
            this.txt_edit_cantidad.TabIndex = 10;
            this.txt_edit_cantidad.Visible = false;
            // 
            // lbl_edit_cantidad
            // 
            this.lbl_edit_cantidad.AutoSize = true;
            this.lbl_edit_cantidad.Location = new System.Drawing.Point(558, 140);
            this.lbl_edit_cantidad.Name = "lbl_edit_cantidad";
            this.lbl_edit_cantidad.Size = new System.Drawing.Size(48, 13);
            this.lbl_edit_cantidad.TabIndex = 11;
            this.lbl_edit_cantidad.Text = "cantidad";
            this.lbl_edit_cantidad.Visible = false;
            // 
            // txt_codigo
            // 
            this.txt_codigo.Location = new System.Drawing.Point(455, 41);
            this.txt_codigo.Name = "txt_codigo";
            this.txt_codigo.Size = new System.Drawing.Size(100, 20);
            this.txt_codigo.TabIndex = 14;
            // 
            // txt_edit_codigo
            // 
            this.txt_edit_codigo.Location = new System.Drawing.Point(455, 156);
            this.txt_edit_codigo.Name = "txt_edit_codigo";
            this.txt_edit_codigo.Size = new System.Drawing.Size(100, 20);
            this.txt_edit_codigo.TabIndex = 15;
            this.txt_edit_codigo.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(452, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "codigo";
            // 
            // lbl_edit_codigo
            // 
            this.lbl_edit_codigo.AutoSize = true;
            this.lbl_edit_codigo.Location = new System.Drawing.Point(452, 140);
            this.lbl_edit_codigo.Name = "lbl_edit_codigo";
            this.lbl_edit_codigo.Size = new System.Drawing.Size(39, 13);
            this.lbl_edit_codigo.TabIndex = 17;
            this.lbl_edit_codigo.Text = "codigo";
            this.lbl_edit_codigo.Visible = false;
            // 
            // inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 261);
            this.Controls.Add(this.lbl_edit_codigo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_edit_codigo);
            this.Controls.Add(this.txt_codigo);
            this.Controls.Add(this.lbl_edit_id_producto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_edit_id_producto);
            this.Controls.Add(this.txt_id_producto);
            this.Controls.Add(this.lbl_edit_cantidad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_edit_cantidad);
            this.Controls.Add(this.txt_cantidad);
            this.Controls.Add(this.lbl_edit_precio);
            this.Controls.Add(this.lbl_edit_producto);
            this.Controls.Add(this.lbl_precio);
            this.Controls.Add(this.lbl_producto);
            this.Controls.Add(this.txt_edit_precio);
            this.Controls.Add(this.txt_edit_nombre);
            this.Controls.Add(this.btn_edit_por);
            this.Controls.Add(this.btn_eliminar);
            this.Controls.Add(this.btn_agregar);
            this.Controls.Add(this.btn_editar);
            this.Controls.Add(this.txt_precio);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.lst_productos);
            this.Name = "inventario";
            this.Text = "inventario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lst_productos;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.TextBox txt_precio;
        private System.Windows.Forms.Button btn_editar;
        private System.Windows.Forms.Button btn_agregar;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.Button btn_edit_por;
        private System.Windows.Forms.TextBox txt_edit_nombre;
        private System.Windows.Forms.TextBox txt_edit_precio;
        private System.Windows.Forms.Label lbl_producto;
        private System.Windows.Forms.Label lbl_precio;
        private System.Windows.Forms.Label lbl_edit_producto;
        private System.Windows.Forms.Label lbl_edit_precio;
        private System.Windows.Forms.TextBox txt_cantidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_id_producto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_edit_id_producto;
        private System.Windows.Forms.Label lbl_edit_id_producto;
        private System.Windows.Forms.TextBox txt_edit_cantidad;
        private System.Windows.Forms.Label lbl_edit_cantidad;
        private System.Windows.Forms.TextBox txt_codigo;
        private System.Windows.Forms.TextBox txt_edit_codigo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_edit_codigo;
    }
}