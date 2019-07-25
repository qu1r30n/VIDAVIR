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
    public partial class compras : Form
    {
        char[] G_parametros = { '|' };


        public compras()
        {
            InitializeComponent();
        }

        private void btn_guardar_compra_Click(object sender, EventArgs e)
        {
            tex_base bas = new tex_base();
            operaciones_archivos op = new operaciones_archivos();
            DateTime fecha_hora = DateTime.Now;
            Decimal cantidad = Convert.ToDecimal(txt_cantidad_gastada.Text);
            string poductos_ya_unidos = txt_razon.Text + G_parametros[0] + txt_quien_facturo.Text;
            string direccion1= "ventas\\" + fecha_hora.ToString("yyyy") + "\\" + fecha_hora.ToString("MM") + "\\dias\\g_" + fecha_hora.ToString("dd-MM-yyyy") + ".txt", 
                   direccion2= "ventas\\" + fecha_hora.ToString("yyyy") + "\\" + fecha_hora.ToString("MM") + "\\g_" + fecha_hora.ToString("MM") + ".txt",
                   direccion3= "ventas\\" + fecha_hora.ToString("yyyy") + "\\g_" + fecha_hora.ToString("yyyy") + ".txt",
                   direccion4= "ventas\\g_total_años.txt",
                   direccion5 = "ventas\\total_en_juego.txt";

            DialogResult boton = MessageBox.Show("seguro que quieres realisar la compra de:   " + txt_cantidad_gastada.Text + "   ?", "Alerta", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (boton == DialogResult.OK)
            {
                string [] cantidades_en_juego=bas.leer(direccion5),cantidades_en_juego_espliteada;
                Decimal dinero_ganado=0,dinero_gastado=0;

                cantidades_en_juego_espliteada = cantidades_en_juego[0].Split(G_parametros);
                dinero_ganado = Convert.ToInt32(cantidades_en_juego_espliteada[1]);

                cantidades_en_juego_espliteada = cantidades_en_juego[0].Split(G_parametros);
                dinero_ganado = Convert.ToInt32(cantidades_en_juego_espliteada[1]);

                if (dinero_ganado>=dinero_gastado+cantidad)
                {
                    bas.agregar(direccion1, fecha_hora.ToString("dd-MM-yyyy HH:mm:ss") + G_parametros[0] + poductos_ya_unidos + G_parametros[0] + cantidad, null);//muestra total cada horas
                    op.actualisar_resumen_venta(direccion2, fecha_hora.ToString("dd"), cantidad);//muestra total de cada dias
                    op.actualisar_resumen_venta(direccion3, fecha_hora.ToString("MM"), cantidad);//muestra total de cada mes
                    op.actualisar_resumen_venta(direccion4, fecha_hora.ToString("yyyy"), cantidad);//muestra total de cada año
                    op.actualisar_resumen_venta(direccion5, "dinero_gastado: ", cantidad);//muestra total de cada año
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
