using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tienda
{
    public partial class agregar_producto : Form
    {
        char[] G_parametros = { '|' };
        public agregar_producto()
        {
            InitializeComponent();

            tex_base bas = new tex_base();
            string[] imprimir = bas.leer("inf\\inventario\\invent.txt", "0|1|2|3|4|5|6|7", "" + G_parametros[0]);
            lbl_id.Text = "" + imprimir.Length;
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            tex_base bas = new tex_base();
            operaciones_archivos op = new operaciones_archivos();
            DateTime fecha_hora = DateTime.Now;
            Decimal precio_compra = Convert.ToDecimal(txt_precio_comp.Text);
            string poductos_ya_unidos = lbl_id.Text + G_parametros[0] + txt_producto.Text;
            string direccion1 = "ventas\\" + fecha_hora.ToString("yyyy") + "\\" + fecha_hora.ToString("MM") + "\\dias\\g_" + fecha_hora.ToString("dd-MM-yyyy") + ".txt",
                   direccion2 = "ventas\\" + fecha_hora.ToString("yyyy") + "\\" + fecha_hora.ToString("MM") + "\\g_" + fecha_hora.ToString("MM") + ".txt",
                   direccion3 = "ventas\\" + fecha_hora.ToString("yyyy") + "\\g_" + fecha_hora.ToString("yyyy") + ".txt",
                   direccion4 = "ventas\\g_total_años.txt",
                   direccion5 = "ventas\\total_en_juego.txt";
            decimal total_compra = Convert.ToDecimal(txt_cantidad.Text) * Convert.ToDecimal(txt_precio_comp.Text);
            DialogResult boton = MessageBox.Show("seguro que quieres realisar la compra de:   " + total_compra + "   ?", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (boton == DialogResult.OK)
            {
                string[] cantidades_en_juego = bas.leer(direccion5), cantidades_en_juego_espliteada;
                Decimal dinero_ganado = 0, dinero_gastado = 0;

                cantidades_en_juego_espliteada = cantidades_en_juego[0].Split(G_parametros);
                dinero_ganado = Convert.ToDecimal(cantidades_en_juego_espliteada[1]);

                cantidades_en_juego_espliteada = cantidades_en_juego[0].Split(G_parametros);
                dinero_ganado = Convert.ToDecimal(cantidades_en_juego_espliteada[1]);

                if (dinero_ganado >= dinero_gastado + precio_compra)
                {
                    bas.agregar("inf\\inventario\\invent.txt",lbl_id.Text+"|"+txt_producto.Text + "|" +txt_precio_vent.Text + "|" +lbl_codigo.Text + "|" +txt_cantidad.Text + "|" +txt_precio_comp.Text + "|" +txt_marca.Text + "|");
                    bas.agregar(direccion1, fecha_hora.ToString("dd-MM-yyyy HH:mm:ss") + G_parametros[0] + poductos_ya_unidos + G_parametros[0] + total_compra, null);//muestra total cada horas
                    op.actualisar_resumen_venta(direccion2, fecha_hora.ToString("dd"), total_compra);//muestra total de cada dias
                    op.actualisar_resumen_venta(direccion3, fecha_hora.ToString("MM"), total_compra);//muestra total de cada mes
                    op.actualisar_resumen_venta(direccion4, fecha_hora.ToString("yyyy"), total_compra);//muestra total de cada año
                    op.actualisar_resumen_venta(direccion5, "dinero_gastado: ", total_compra);//muestra total de cada año
                }
                else
                {
                    MessageBox.Show("no se tiene tanto dinero en juego");
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("cancelado");
                this.Close();
            }
        }
    }
}