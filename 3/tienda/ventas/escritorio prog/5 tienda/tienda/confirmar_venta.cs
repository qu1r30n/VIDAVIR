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
        public double cantidad { get; set; }
        DateTime fecha_hora = DateTime.Now;
        

        public confirmar_venta()
        {
            InitializeComponent();
        }
        private void btn_pagar_Click(object sender, EventArgs e)
        {
            string productos_sacado_linea,poductos_ya_unidos="";
            tex_base bas = new tex_base();
            operaciones_archivos op = new operaciones_archivos();
            bas.crear_archivo_y_directorio("ventas\\" + fecha_hora.ToString("yyyy") + "\\" + fecha_hora.ToString("MM") + "\\dias\\" + fecha_hora.ToString("dd-MM-yyyy") + ".txt", null,null);
            
            for (int jug = 0; jug < arra_lis.Count; jug++)
            {
                productos_sacado_linea = "" + arra_lis[jug];
                if (jug < arra_lis.Count - 1)
                {
                    if (productos_sacado_linea!="")
                    {
                        poductos_ya_unidos = poductos_ya_unidos + productos_sacado_linea + "@";
                    }
                    
                }
                else
                {
                    if (productos_sacado_linea!="")
                    {
                        poductos_ya_unidos = poductos_ya_unidos + productos_sacado_linea;
                    }
                }
            }

            if (txt_dinero.Text == "")
            {
                txt_dinero.Text = "" + 0;
            }
            double temp = Convert.ToDouble(txt_dinero.Text);
            if (temp >= cantidad)
            {
                bas.agregar("ventas\\" + fecha_hora.ToString("yyyy") + "\\" + fecha_hora.ToString("MM") + "\\dias\\" + fecha_hora.ToString("dd-MM-yyyy") + ".txt", fecha_hora.ToString("dd-MM-yyyy HH:mm:ss") + " ," + cantidad + " ," + poductos_ya_unidos, null);//muestra total cada horas
                op.actualisar_resumen_venta("ventas\\" + fecha_hora.ToString("yyyy") + "\\" + fecha_hora.ToString("MM") + "\\" + fecha_hora.ToString("MM") + ".txt", fecha_hora.ToString("dd"), cantidad);//muestra total de cada dias
                op.actualisar_resumen_venta("ventas\\" + fecha_hora.ToString("yyyy") + "\\" + fecha_hora.ToString("yyyy") + ".txt", fecha_hora.ToString("MM"), cantidad);//muestra total de cada mes
                op.actualisar_resumen_venta("ventas\\total_años.txt", fecha_hora.ToString("yyyy"), cantidad);//muestra total de cada año
                op.actualisar_resumen_venta("ventas\\total_en_juego.txt","dinero_hay: ", cantidad);//muestra total de cada año

                for (int i = 0; i < ids_productos.Count; i++)
                {
                    op.actualisar_resumen_venta("ventas\\" + fecha_hora.ToString("yyyy") + "\\" + fecha_hora.ToString("MM") + "\\dias\\p_" + fecha_hora.ToString("dd-MM-yyyy") + ".txt", "" + ids_productos[i], 1);
                    op.actualisar_inventario("inf\\inventario\\invent.txt", ""+ids_productos[i], -1);
                    op.actualisar_resumen_venta("ventas\\" + fecha_hora.ToString("yyyy") + "\\" + fecha_hora.ToString("MM") + "\\p_" + fecha_hora.ToString("MM") + ".txt", "" + ids_productos[i], 1);//muestra total de cada dias
                    op.actualisar_resumen_venta("ventas\\" + fecha_hora.ToString("yyyy") + "\\p_" + fecha_hora.ToString("yyyy") + ".txt", "" + ids_productos[i], 1);//muestra total de cada mes
                    op.actualisar_resumen_venta("ventas\\p_total_años.txt", "" + ids_productos[i], 1);//muestra total de cada año
                }
                MessageBox.Show("CAMBIO: " + (temp - cantidad));
                this.Close();
            }
            else
            {
                MessageBox.Show("FALTA: " + (cantidad - temp));
            }
                 
        }
    }
}
