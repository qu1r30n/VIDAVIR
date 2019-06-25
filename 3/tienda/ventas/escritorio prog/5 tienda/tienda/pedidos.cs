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
    public partial class pedidos : Form
    {
        char[] G_parametros = { '|' };

        public pedidos()
        {
            InitializeComponent();
            tex_base bas = new tex_base();
            bas.crear_archivo_y_directorio("inf\\inventario\\invent.txt", "id|producto|precio|codigo|cantidad|compra|marca|");
            string[] imprimir = bas.leer("inf\\inventario\\invent.txt", "1|0|2|3|4|5|6|7", "" + G_parametros[0]);

            for (int i = 1; i < imprimir.Length; i++)
            {
                txt_buscar_producto.AutoCompleteCustomSource.Add("" + imprimir[i]);
            }

            string[] imprimir2 = bas.leer("inf\\inventario\\invent.txt", "3|0|2|1|4|5|6|7", "" + G_parametros[0]);

            for (int i = 1; i < imprimir2.Length; i++)
            {
                txt_buscar_producto.AutoCompleteCustomSource.Add("" + imprimir2[i]);
            }
        }
        private void btn_agregar_Click(object sender, EventArgs e)
        {            
            bool bandera = false;

            if ("" != txt_buscar_producto.Text && "" != txt_cantidad.Text)
            {
                for (int i = 0; i < txt_buscar_producto.AutoCompleteCustomSource.Count; i++)
                {

                    if (txt_buscar_producto.Text == ("" + txt_buscar_producto.AutoCompleteCustomSource[i].ToString()))
                    {
                        string[] espliteado = txt_buscar_producto.Text.Split(G_parametros[0]);

                        if (Convert.ToDecimal(espliteado[5]) > 0)
                        {
                            txt_buscar_producto.Text = txt_buscar_producto.Text + txt_costo_unitario.Text+ G_parametros[0]+txt_cantidad.Text;
                            lst_ventas.Items.Add(txt_buscar_producto.Text);
                            txt_buscar_producto.Text = "";
                            txt_cantidad.Text = "";
                            txt_costo_unitario.Text = "";

                        }
                        else
                        {
                            ventana_emergente vtm = new ventana_emergente();
                            string[] datos = { "costo" };
                            string[] infoextra = { espliteado[1] };
                            string cost=vtm.proceso_ventana_emergente(datos, 2, infoextra);
                            MessageBox.Show("se cambio precio de: " + espliteado[0]+"   a :"+cost);
                            recargar_texbox();
                            txt_buscar_producto.Text = "";
                            txt_cantidad.Text = "";
                            txt_costo_unitario.Text = "";

                        }

                        bandera = true;
                    }

                }

                if (bandera == false)
                {

                    tex_base bas = new tex_base();
                    string[] cantidad_produc = bas.leer("inf\\inventario\\invent.txt", "0", "" + G_parametros[0]);//el 0 solo regresa la primera columna que creo es el id
                    string[] espliteado = txt_buscar_producto.Text.Split(G_parametros);
                    //------------------------------------------------------------
                    ventana_emergente vent_emergent = new ventana_emergente();


                    string[] enviar = { "id°" + (cantidad_produc.Length), "producto", "precio", "codigo°" + espliteado[0], "cantidad", "compra", "marca" };
                    string mensage = vent_emergent.proceso_ventana_emergente(enviar, 1);//el uno significa que modificara el inventario
                    MessageBox.Show("se agrego: "+mensage);
                    //-------------------------------------------------------------
                    recargar_texbox();
                    txt_buscar_producto.Text = "";
                    txt_cantidad.Text = "";
                    txt_costo_unitario.Text = "";

                }

                total_label();
                

            }
            else
            {
                MessageBox.Show("llena las casillas producto y cantidad");
            }



            txt_buscar_producto.Focus();
        }
        private void total_label()
        {
            string temporal = "";
            string[] temporal_s;
            decimal total = 0;
            decimal total_cost_com = 0;

            for (int coll = 0; coll < lst_ventas.Items.Count; coll++)
            {
                temporal = "" + lst_ventas.Items[coll];
                temporal_s = temporal.Split(G_parametros);

                if (temporal_s[0] != "")
                {
                    total = total + (Convert.ToDecimal(temporal_s[7]) * Convert.ToDecimal(temporal_s[8]));
                    total_cost_com = total_cost_com + Convert.ToDecimal(temporal_s[5]);
                }
            }
            lbl_cuenta.Text = "" + total;
            txt_buscar_producto.Focus();
        }

        private void recargar_texbox()
        {
            tex_base bas = new tex_base();
            string[] imprimir = bas.leer("inf\\inventario\\invent.txt", "1|0|2|3|4|5|6|7", "" + G_parametros[0]);
            txt_buscar_producto.AutoCompleteCustomSource.Clear();
            for (int k = 1; k < imprimir.Length; k++)
            {
                txt_buscar_producto.AutoCompleteCustomSource.Add("" + imprimir[k]);
            }

            string[] imprimir2 = bas.leer("inf\\inventario\\invent.txt", "3|0|2|1|4|5|6|7", "" + G_parametros[0]);

            for (int k = 1; k < imprimir2.Length; k++)
            {
                txt_buscar_producto.AutoCompleteCustomSource.Add("" + imprimir2[k]);
            }
        }

        private void btn_eliminar_todo_Click(object sender, EventArgs e)
        {
            try
            {
                lst_ventas.Items.Clear();
            }
            catch (Exception)
            {

                throw;
            }
            total_label();
            txt_buscar_producto.Focus();
        }

        private void btn_eliminar_seleccionado_Click(object sender, EventArgs e)
        {
            try
            {
                lst_ventas.Items.RemoveAt(lst_ventas.SelectedIndex);
            }
            catch (Exception)
            {

                throw;
            }
            total_label();
            txt_buscar_producto.Focus();

        }

        private void txt_buscar_producto_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyValue == (char)(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void btn_elim_ultimo_Click(object sender, EventArgs e)
        {
            try
            {
                lst_ventas.Items.Remove(lst_ventas.Items[lst_ventas.Items.Count - 1]);
            }
            catch (Exception)
            {

                throw;
            }
            total_label();
            txt_buscar_producto.Focus();
        }

        private void btn_procesar_venta_Click(object sender, EventArgs e)
        {



            #region codigo para guarar la lista en un archivo
            /* 
                ponero en una carpeta la lista de pedido
             
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog()==DialogResult.OK)
                {
                    MessageBox.Show(fbd.SelectedPath);
                }
                else
                {
                    return;
                }


                DateTime fecha_hora = DateTime.Now;
                operaciones_archivos op = new operaciones_archivos();
                tex_base bas = new tex_base();
                string[] lista_pedido = new string[lst_ventas.Items.Count];
                for (int i = 0; i < lst_ventas.Items.Count; i++)
                {
                    lista_pedido[i] = "" + lst_ventas.Items[i];
                }
                op.pedido(fbd.SelectedPath + "\\ped_" + fecha_hora.ToString("dd-MM-yyyy")+".txt", lista_pedido);

          
                lst_ventas.Items.Clear();
                }
            */
            #endregion

            string temporal = "";
            string[] temporal_s;
            decimal total = 0;
            int bandera = 0;
            string productos_ya_unidos = "", ids_ya_unidos = "";
            DateTime fecha_hora = DateTime.Now;
            operaciones_archivos op = new operaciones_archivos();

            for (int coll = 0; coll < lst_ventas.Items.Count; coll++)
            {
                temporal = "" + lst_ventas.Items[coll];
                temporal_s = temporal.Split(G_parametros);
                if (temporal_s[0] != "")
                {

                    total = total + (Convert.ToDecimal(temporal_s[5]) * Convert.ToDecimal(temporal_s[8]));

                }
                if (Convert.ToDecimal(temporal_s[5]) < Convert.ToDecimal(temporal_s[7]))
                {
                    DialogResult result = MessageBox.Show("producto: " + temporal_s[0] + "precio anterior: " + temporal_s[5] + "  precio actual: " + temporal_s[7], "Hi", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        ids_ya_unidos = ids_ya_unidos + temporal_s[1];
                        productos_ya_unidos = productos_ya_unidos + temporal_s[0];
                        op.actualisar_costo_compra("inf\\inventario\\invent.txt", "" + temporal_s[1], Convert.ToDecimal(temporal_s[7]));
                        op.actualisar_inventario("inf\\inventario\\invent.txt", "" + temporal_s[1], Convert.ToDecimal(temporal_s[8]));
                    }
                }
                else
                {
                    ids_ya_unidos = ids_ya_unidos + temporal_s[1];
                    productos_ya_unidos = productos_ya_unidos + temporal_s[0];
                    op.actualisar_costo_compra("inf\\inventario\\invent.txt", "" + temporal_s[1], Convert.ToDecimal(temporal_s[7]));
                    op.actualisar_inventario("inf\\inventario\\invent.txt", "" + temporal_s[1], Convert.ToDecimal(temporal_s[8]));
                }
            }

            modelo_actualisacion_de_compras(fecha_hora.ToString("yyyy"), fecha_hora.ToString("MM"), fecha_hora.ToString("dd"), fecha_hora.ToString("dd-MM-yyyy"), fecha_hora.ToString("HH:mm:ss"), ids_ya_unidos, total, productos_ya_unidos);
        

            


            lst_ventas.Items.Clear();
            txt_buscar_producto.Focus();
        }

        private void Txt_cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }

        private void modelo_actualisacion_de_compras(string año, string mes, string dia, string dia_mes_año, string hora, string ids_ya_unidos="", decimal cantidad=1, string poductos_ya_unidos="", decimal cost_comp=1)
        {
            tex_base bas = new tex_base();
            operaciones_archivos op = new operaciones_archivos();
            string[] cantidades_en_juego = bas.leer("ventas\\total_en_juego.txt"), cantidades_en_juego_espliteada;
            Decimal dinero_ganado = 0, dinero_gastado = 0;

            cantidades_en_juego_espliteada = cantidades_en_juego[0].Split(G_parametros);
            dinero_ganado = Convert.ToInt32(cantidades_en_juego_espliteada[1]);

            if (dinero_ganado >= dinero_gastado)
            {

                bas.agregar("ventas\\" + año + "\\" + mes + "\\dias\\g_" + dia_mes_año + ".txt", hora + " |" + ids_ya_unidos + " |" + cantidad + " |" + poductos_ya_unidos, null);//muestra total cada horas
                op.actualisar_resumen_compras("ventas\\" + año + "\\" + mes + "\\g_" + mes + ".txt", dia, cantidad);//muestra total de cada dias
                op.actualisar_resumen_compras("ventas\\" + año + "\\g_" + año + ".txt", mes, cantidad);//muestra total de cada mes
                op.actualisar_resumen_compras("ventas\\g_total_años.txt", año, cantidad);//muestra total de cada año
                op.actualisar_resumen_compras("ventas\\total_en_juego.txt", "dinero_hay: ", -1 * cantidad);//muestra total de cada año
                op.actualisar_ganancia_real("ventas\\ganancia_real.txt", "dinero_hay: ", -1 * cantidad);//muestra ganancia real
            }
        }
    }
}