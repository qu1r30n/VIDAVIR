namespace tienda
{
    partial class area_principal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name=
        /// disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btn_inventario = new System.Windows.Forms.Button();
            this.btn_nueva_venta = new System.Windows.Forms.Button();
            this.btn_empleados = new System.Windows.Forms.Button();
            this.chrt_ventas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lst_ventas = new System.Windows.Forms.ListBox();
            this.cmb_mes = new System.Windows.Forms.ComboBox();
            this.cmb_año = new System.Windows.Forms.ComboBox();
            this.cmb_dia = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_total = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_compras = new System.Windows.Forms.Button();
            this.btn_respaldo = new System.Windows.Forms.Button();
            this.btn_pedidos = new System.Windows.Forms.Button();
            this.btn_comparar = new System.Windows.Forms.Button();
            this.rdb_ventas = new System.Windows.Forms.RadioButton();
            this.rdb_productos = new System.Windows.Forms.RadioButton();
            this.rdb_gastos = new System.Windows.Forms.RadioButton();
            this.btn_ganancias = new System.Windows.Forms.Button();
            this.txt_ganancia = new System.Windows.Forms.TextBox();
            this.lbl_ganancia = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chrt_ventas)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_inventario
            // 
            this.btn_inventario.Location = new System.Drawing.Point(16, 32);
            this.btn_inventario.Name = "btn_inventario";
            this.btn_inventario.Size = new System.Drawing.Size(75, 23);
            this.btn_inventario.TabIndex = 0;
            this.btn_inventario.Text = "inventario";
            this.btn_inventario.UseVisualStyleBackColor = true;
            this.btn_inventario.Click += new System.EventHandler(this.btn_inventario_Click);
            // 
            // btn_nueva_venta
            // 
            this.btn_nueva_venta.Location = new System.Drawing.Point(16, 63);
            this.btn_nueva_venta.Name = "btn_nueva_venta";
            this.btn_nueva_venta.Size = new System.Drawing.Size(75, 37);
            this.btn_nueva_venta.TabIndex = 2;
            this.btn_nueva_venta.Text = "NUEVA VENTA";
            this.btn_nueva_venta.UseVisualStyleBackColor = true;
            this.btn_nueva_venta.Click += new System.EventHandler(this.btn_nueva_venta_Click);
            // 
            // btn_empleados
            // 
            this.btn_empleados.Location = new System.Drawing.Point(16, 166);
            this.btn_empleados.Name = "btn_empleados";
            this.btn_empleados.Size = new System.Drawing.Size(75, 23);
            this.btn_empleados.TabIndex = 3;
            this.btn_empleados.Text = "empleados";
            this.btn_empleados.UseVisualStyleBackColor = true;
            this.btn_empleados.Click += new System.EventHandler(this.btn_empleados_Click);
            // 
            // chrt_ventas
            // 
            chartArea1.Name = "ChartArea1";
            this.chrt_ventas.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chrt_ventas.Legends.Add(legend1);
            this.chrt_ventas.Location = new System.Drawing.Point(116, 3);
            this.chrt_ventas.Name = "chrt_ventas";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chrt_ventas.Series.Add(series1);
            this.chrt_ventas.Size = new System.Drawing.Size(403, 300);
            this.chrt_ventas.TabIndex = 5;
            this.chrt_ventas.Text = "ventas";
            // 
            // lst_ventas
            // 
            this.lst_ventas.FormattingEnabled = true;
            this.lst_ventas.Location = new System.Drawing.Point(649, 3);
            this.lst_ventas.Name = "lst_ventas";
            this.lst_ventas.Size = new System.Drawing.Size(420, 303);
            this.lst_ventas.TabIndex = 6;
            // 
            // cmb_mes
            // 
            this.cmb_mes.FormattingEnabled = true;
            this.cmb_mes.Location = new System.Drawing.Point(521, 66);
            this.cmb_mes.Name = "cmb_mes";
            this.cmb_mes.Size = new System.Drawing.Size(121, 21);
            this.cmb_mes.TabIndex = 12;
            this.cmb_mes.SelectedIndexChanged += new System.EventHandler(this.cmb_mes_SelectedIndexChanged);
            // 
            // cmb_año
            // 
            this.cmb_año.FormattingEnabled = true;
            this.cmb_año.Location = new System.Drawing.Point(522, 19);
            this.cmb_año.Name = "cmb_año";
            this.cmb_año.Size = new System.Drawing.Size(121, 21);
            this.cmb_año.TabIndex = 13;
            this.cmb_año.SelectedIndexChanged += new System.EventHandler(this.cmb_año_SelectedIndexChanged);
            // 
            // cmb_dia
            // 
            this.cmb_dia.FormattingEnabled = true;
            this.cmb_dia.Location = new System.Drawing.Point(521, 106);
            this.cmb_dia.Name = "cmb_dia";
            this.cmb_dia.Size = new System.Drawing.Size(121, 21);
            this.cmb_dia.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(522, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "año";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(522, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "mes";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(522, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "dia";
            // 
            // txt_total
            // 
            this.txt_total.Location = new System.Drawing.Point(116, 321);
            this.txt_total.Name = "txt_total";
            this.txt_total.Size = new System.Drawing.Size(283, 20);
            this.txt_total.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(117, 305);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "total";
            // 
            // btn_compras
            // 
            this.btn_compras.Location = new System.Drawing.Point(16, 106);
            this.btn_compras.Name = "btn_compras";
            this.btn_compras.Size = new System.Drawing.Size(75, 42);
            this.btn_compras.TabIndex = 22;
            this.btn_compras.Text = "NUEVA COMPRA";
            this.btn_compras.UseVisualStyleBackColor = true;
            this.btn_compras.Click += new System.EventHandler(this.btn_compras_Click);
            // 
            // btn_respaldo
            // 
            this.btn_respaldo.Location = new System.Drawing.Point(16, 287);
            this.btn_respaldo.Name = "btn_respaldo";
            this.btn_respaldo.Size = new System.Drawing.Size(75, 23);
            this.btn_respaldo.TabIndex = 23;
            this.btn_respaldo.Text = "Respaldo";
            this.btn_respaldo.UseVisualStyleBackColor = true;
            this.btn_respaldo.Click += new System.EventHandler(this.btn_respaldo_Click);
            // 
            // btn_pedidos
            // 
            this.btn_pedidos.Location = new System.Drawing.Point(16, 194);
            this.btn_pedidos.Name = "btn_pedidos";
            this.btn_pedidos.Size = new System.Drawing.Size(75, 23);
            this.btn_pedidos.TabIndex = 24;
            this.btn_pedidos.Text = "pedidos";
            this.btn_pedidos.UseVisualStyleBackColor = true;
            this.btn_pedidos.Click += new System.EventHandler(this.btn_pedidos_Click);
            // 
            // btn_comparar
            // 
            this.btn_comparar.Location = new System.Drawing.Point(521, 202);
            this.btn_comparar.Name = "btn_comparar";
            this.btn_comparar.Size = new System.Drawing.Size(75, 23);
            this.btn_comparar.TabIndex = 25;
            this.btn_comparar.Text = "comparar";
            this.btn_comparar.UseVisualStyleBackColor = true;
            this.btn_comparar.Click += new System.EventHandler(this.btn_comparar_Click);
            // 
            // rdb_ventas
            // 
            this.rdb_ventas.AutoSize = true;
            this.rdb_ventas.Location = new System.Drawing.Point(525, 133);
            this.rdb_ventas.Name = "rdb_ventas";
            this.rdb_ventas.Size = new System.Drawing.Size(57, 17);
            this.rdb_ventas.TabIndex = 26;
            this.rdb_ventas.TabStop = true;
            this.rdb_ventas.Text = "ventas";
            this.rdb_ventas.UseVisualStyleBackColor = true;
            this.rdb_ventas.CheckedChanged += new System.EventHandler(this.rdb_ventas_CheckedChanged);
            // 
            // rdb_productos
            // 
            this.rdb_productos.AutoSize = true;
            this.rdb_productos.Location = new System.Drawing.Point(525, 156);
            this.rdb_productos.Name = "rdb_productos";
            this.rdb_productos.Size = new System.Drawing.Size(72, 17);
            this.rdb_productos.TabIndex = 27;
            this.rdb_productos.TabStop = true;
            this.rdb_productos.Text = "productos";
            this.rdb_productos.UseVisualStyleBackColor = true;
            this.rdb_productos.CheckedChanged += new System.EventHandler(this.rdb_productos_CheckedChanged);
            // 
            // rdb_gastos
            // 
            this.rdb_gastos.AutoSize = true;
            this.rdb_gastos.Location = new System.Drawing.Point(525, 179);
            this.rdb_gastos.Name = "rdb_gastos";
            this.rdb_gastos.Size = new System.Drawing.Size(56, 17);
            this.rdb_gastos.TabIndex = 28;
            this.rdb_gastos.TabStop = true;
            this.rdb_gastos.Text = "gastos";
            this.rdb_gastos.UseVisualStyleBackColor = true;
            this.rdb_gastos.CheckedChanged += new System.EventHandler(this.rdb_gastos_CheckedChanged);
            // 
            // btn_ganancias
            // 
            this.btn_ganancias.Location = new System.Drawing.Point(525, 231);
            this.btn_ganancias.Name = "btn_ganancias";
            this.btn_ganancias.Size = new System.Drawing.Size(75, 23);
            this.btn_ganancias.TabIndex = 29;
            this.btn_ganancias.Text = "ganancias";
            this.btn_ganancias.UseVisualStyleBackColor = true;
            this.btn_ganancias.Click += new System.EventHandler(this.btn_ganancias_Click);
            // 
            // txt_ganancia
            // 
            this.txt_ganancia.Location = new System.Drawing.Point(417, 321);
            this.txt_ganancia.Name = "txt_ganancia";
            this.txt_ganancia.Size = new System.Drawing.Size(183, 20);
            this.txt_ganancia.TabIndex = 30;
            this.txt_ganancia.Visible = false;
            // 
            // lbl_ganancia
            // 
            this.lbl_ganancia.AutoSize = true;
            this.lbl_ganancia.Location = new System.Drawing.Point(414, 305);
            this.lbl_ganancia.Name = "lbl_ganancia";
            this.lbl_ganancia.Size = new System.Drawing.Size(51, 13);
            this.lbl_ganancia.TabIndex = 31;
            this.lbl_ganancia.Text = "ganancia";
            this.lbl_ganancia.Visible = false;
            // 
            // area_principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 353);
            this.Controls.Add(this.lbl_ganancia);
            this.Controls.Add(this.txt_ganancia);
            this.Controls.Add(this.btn_ganancias);
            this.Controls.Add(this.rdb_gastos);
            this.Controls.Add(this.rdb_productos);
            this.Controls.Add(this.rdb_ventas);
            this.Controls.Add(this.btn_comparar);
            this.Controls.Add(this.btn_pedidos);
            this.Controls.Add(this.btn_respaldo);
            this.Controls.Add(this.btn_compras);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_total);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmb_dia);
            this.Controls.Add(this.cmb_año);
            this.Controls.Add(this.cmb_mes);
            this.Controls.Add(this.lst_ventas);
            this.Controls.Add(this.chrt_ventas);
            this.Controls.Add(this.btn_empleados);
            this.Controls.Add(this.btn_nueva_venta);
            this.Controls.Add(this.btn_inventario);
            this.Name = "area_principal";
            this.Text = "area_principal";
            ((System.ComponentModel.ISupportInitialize)(this.chrt_ventas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_inventario;
        private System.Windows.Forms.Button btn_nueva_venta;
        private System.Windows.Forms.Button btn_empleados;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrt_ventas;
        private System.Windows.Forms.ComboBox cmb_mes;
        private System.Windows.Forms.ComboBox cmb_año;
        private System.Windows.Forms.ComboBox cmb_dia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_total;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_compras;
        private System.Windows.Forms.Button btn_respaldo;
        private System.Windows.Forms.Button btn_pedidos;
        private System.Windows.Forms.Button btn_comparar;
        public System.Windows.Forms.ListBox lst_ventas;
        private System.Windows.Forms.RadioButton rdb_ventas;
        private System.Windows.Forms.RadioButton rdb_productos;
        private System.Windows.Forms.RadioButton rdb_gastos;
        private System.Windows.Forms.Button btn_ganancias;
        private System.Windows.Forms.TextBox txt_ganancia;
        private System.Windows.Forms.Label lbl_ganancia;
    }
}