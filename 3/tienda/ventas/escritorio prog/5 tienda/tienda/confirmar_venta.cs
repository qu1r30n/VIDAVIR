using System;
using System.Collections;
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
    public partial class confirmar_venta : Form
    {
        public ArrayList ids_productos = new ArrayList();
        public ArrayList arra_lis = new ArrayList();
        public ArrayList info_extra = new ArrayList();
        public decimal cantidad { get; set; }
        public decimal cost_comp { get; set; }

        DateTime fecha_hora = DateTime.Now;
        char[] G_parametros = { '|' };

        public confirmar_venta()
        {
            InitializeComponent();
        }
        private void btn_pagar_Click(object sender, EventArgs e)
        {
            string productos_sacado_linea,poductos_ya_unidos="";
            string ids_sacado_linea, ids_ya_unidos = "";
            tex_base bas = new tex_base();
            operaciones_archivos op = new operaciones_archivos();
            bas.crear_archivo_y_directorio("ventas\\" + fecha_hora.ToString("yyyy") + "\\" + fecha_hora.ToString("MM") + "\\dias\\" + fecha_hora.ToString("dd-MM-yyyy") + ".txt", null,null);
            
            for (int jug = 0; jug < arra_lis.Count; jug++)
            {
                productos_sacado_linea = "" + arra_lis[jug];
                ids_sacado_linea = "" + ids_productos[jug];

                if (jug < arra_lis.Count - 1)
                {
                    if (productos_sacado_linea!="")
                    {
                        poductos_ya_unidos = poductos_ya_unidos + productos_sacado_linea + "°";
                        ids_ya_unidos = ids_ya_unidos + ids_sacado_linea + "°";
                    }
                    
                }
                else
                {
                    if (productos_sacado_linea!="")
                    {
                        poductos_ya_unidos = poductos_ya_unidos + productos_sacado_linea;
                        ids_ya_unidos = ids_ya_unidos + ids_sacado_linea;
                    }
                }
            }

            if (txt_dinero.Text == "")
            {
                txt_dinero.Text = "" + 0;
            }
            decimal temp = Convert.ToDecimal(txt_dinero.Text);
            if (temp >= cantidad)
            {
                modelo_actualisacion_de_ventas(fecha_hora.ToString("yyyy"), fecha_hora.ToString("MM"), fecha_hora.ToString("dd"), fecha_hora.ToString("dd-MM-yyyy"), fecha_hora.ToString("HH:mm:ss"), ids_ya_unidos , cantidad, poductos_ya_unidos, cost_comp);

                for (int i = 0; i < ids_productos.Count; i++)
                {
                    modelo_actualisacion_de_ventas_e_inventario(fecha_hora.ToString("yyyy"), fecha_hora.ToString("MM"), fecha_hora.ToString("dd-MM-yyyy"), fecha_hora.ToString("HH:mm:ss"), ids_ya_unidos, cantidad, poductos_ya_unidos, cost_comp,i);
                }
                MessageBox.Show("CAMBIO: " + (temp - cantidad));
                
                this.Close();
            }
            else
            {
                MessageBox.Show("FALTA: " + (cantidad - temp));
            }
                 
        }

        private void modelo_actualisacion_de_ventas(string año, string mes,string dia, string dia_mes_año, string hora, string ids_ya_unidos, decimal cantidad, string poductos_ya_unidos, decimal cost_comp)
        {
            tex_base bas = new tex_base();
            operaciones_archivos op = new operaciones_archivos();

            bas.agregar("ventas\\" + año + "\\" + mes + "\\dias\\" + dia_mes_año + ".txt", hora + " |" + ids_ya_unidos + " |" + cantidad + " |" + poductos_ya_unidos + " |" + cost_comp, null);//muestra total cada horas
            op.actualisar_resumen_venta("ventas\\" + año + "\\" + mes + "\\" + mes + ".txt", dia, cantidad, cost_comp);//muestra total de cada dias
            op.actualisar_resumen_venta("ventas\\" + año + "\\" + año + ".txt", mes, cantidad, cost_comp);//muestra total de cada mes
            op.actualisar_resumen_venta("ventas\\total_años.txt", año, cantidad, cost_comp);//muestra total de cada año
            op.actualisar_resumen_venta("ventas\\total_en_juego.txt", "dinero_hay: ", cantidad, cost_comp);//muestra total de cada año
            op.actualisar_ganancia_real("ventas\\ganancia_real.txt", "dinero_hay: ", cantidad, cost_comp);//muestra ganancia real

        }

        private void modelo_actualisacion_de_ventas_e_inventario(string año, string mes, string dia_mes_año, string hora, string ids_ya_unidos, decimal cantidad, string poductos_ya_unidos, decimal cost_comp,int i)
        {
            tex_base bas = new tex_base();
            operaciones_archivos op = new operaciones_archivos();

            op.actualisar_resumen_venta("ventas\\" + año + "\\" + mes + "\\dias\\p_" + dia_mes_año + ".txt", "" + ids_productos[i], 1);
            op.actualisar_inventario("inf\\inventario\\invent.txt", "" + ids_productos[i], -1);
            op.actualisar_resumen_venta("ventas\\" + año + "\\" + mes + "\\p_" + mes + ".txt", "" + ids_productos[i], 1);//muestra total de cada dias
            op.actualisar_resumen_venta("ventas\\" + año + "\\p_" + año + ".txt", "" + ids_productos[i], 1);//muestra total de cada mes
            op.actualisar_resumen_venta("ventas\\p_total_años.txt", "" + ids_productos[i], 1);//muestra total de cada año

        }

        private void Txt_dinero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
    }
}
