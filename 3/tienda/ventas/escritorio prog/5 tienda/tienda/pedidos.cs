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
            string[] imprimir = bas.leer("inf\\inventario\\invent.txt", "1|0|3", ""+G_parametros[0]);
            string[] imprimir2 = bas.leer("inf\\inventario\\invent.txt", "3|0|1", "" + G_parametros[0]);

            for (int i = 1; i < imprimir.Length; i++)
            {
                txt_buscar_producto.AutoCompleteCustomSource.Add("" + imprimir[i]);
                txt_buscar_producto.AutoCompleteCustomSource.Add("" + imprimir2[i]);
            }
        }
        private void btn_agregar_Click(object sender, EventArgs e)
        {
            if ("" != txt_buscar_producto.Text && "" != txt_cantidad.Text)
            {
                lst_ventas.Items.Add(txt_buscar_producto.Text + G_parametros[0] + txt_cantidad.Text);
                txt_buscar_producto.Text = "";
                txt_cantidad.Text = "";
            }
            else
            {
                MessageBox.Show("llena las casillas producto y cantidad");
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


        }

        private void txt_buscar_producto_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyValue == (char)(Keys.Enter))
            {
                
                    ProcessDialogKey(Keys.Tab);
                
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

            DateTime fecha_hora = DateTime.Now;
            operaciones_archivos op = new operaciones_archivos(); 

            for (int coll = 0; coll < lst_ventas.Items.Count; coll++)
            {
                temporal = "" + lst_ventas.Items[coll];
                temporal_s = temporal.Split(G_parametros);

                if (temporal_s[0] != "")
                {

                    total = total + Convert.ToDecimal(temporal_s[3]);

                }
                op.actualisar_resumen_venta_compra("ventas\\total_en_juego.txt", temporal_s[1], temporal_s[2], Convert.ToDecimal(temporal_s[3]));
                op.actualisar_inventario("inf\\inventario\\invent.txt", "" + temporal_s[1], Convert.ToDecimal(temporal_s[3]));                
            }
        }
    }
}