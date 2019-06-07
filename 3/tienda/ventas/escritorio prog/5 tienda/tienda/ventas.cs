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
    public partial class ventas : Form
    {

        char[] G_parametros = { '|' };
        public ventas()
        {
            InitializeComponent();
            tex_base bas = new tex_base();
            bas.crear_archivo_y_directorio("inf\\inventario\\invent.txt", "id,producto,precio");
            string [] imprimir = bas.leer("inf\\inventario\\invent.txt", "1|0|2|3", "|");

            for (int i = 1; i < imprimir.Length; i++)
            {
                txt_buscar_producto.AutoCompleteCustomSource.Add("" + imprimir[i]);
            }

            string[] imprimir2 = bas.leer("inf\\inventario\\invent.txt", "3|0|2|1", "|");

            for (int i = 1; i < imprimir2.Length; i++)
            {
                txt_buscar_producto.AutoCompleteCustomSource.Add("" + imprimir2[i]);
            }

        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            string temporal = "";
            string[] temporal_s;
            double total = 0;

            if (txt_buscar_producto.Text != "")
            {
                lst_ventas.Items.Add(txt_buscar_producto.Text);
                txt_buscar_producto.Text = "";
                for (int coll = 0; coll < lst_ventas.Items.Count; coll++)
                {
                    temporal = "" + lst_ventas.Items[coll];
                    temporal_s = temporal.Split(G_parametros);

                    if (temporal_s[0] != "")
                    {
                        total = total + Convert.ToDouble(temporal_s[2]);
                    }

                }
                lbl_cuenta.Text = "" + total;
            }
        }

        private void btn_eliminar_todo_Click(object sender, EventArgs e)
        {
            string temporal = "";
            string[] temporal_s;
            double total = 0;

            try
            {
                lst_ventas.Items.Clear();
                for (int coll = 0; coll < lst_ventas.Items.Count; coll++)
                {
                    temporal = "" + lst_ventas.Items[coll];
                    temporal_s = temporal.Split(G_parametros);

                    if (temporal_s[0] != "")
                    {
                        total = total + Convert.ToDouble(temporal_s[2]);
                    }

                }
                lbl_cuenta.Text = "" + total;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btn_eliminar_seleccionado_Click(object sender, EventArgs e)
        {
            string temporal = "";
            string[] temporal_s;
            double total = 0;

            try
            {
                lst_ventas.Items.RemoveAt(lst_ventas.SelectedIndex);
                for (int coll = 0; coll < lst_ventas.Items.Count; coll++)
                {
                    temporal = "" + lst_ventas.Items[coll];
                    temporal_s = temporal.Split(G_parametros);

                    if (temporal_s[0] != "")
                    {
                        total = total + Convert.ToDouble(temporal_s[2]);
                    }

                }
                lbl_cuenta.Text = "" + total;
            }
            catch (Exception)
            {

                throw;
            }
            

        }

        private void txt_buscar_producto_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            string temporal = "";
            string[] temporal_s;
            double total = 0;

            if (txt_buscar_producto.Text != "")
            {
                if (e.KeyValue == (char)(Keys.Enter))
                {
                    lst_ventas.Items.Add(txt_buscar_producto.Text);
                    txt_buscar_producto.Text = "";
                    for (int coll = 0; coll < lst_ventas.Items.Count; coll++)
                    {
                        temporal = "" + lst_ventas.Items[coll];
                        temporal_s = temporal.Split(G_parametros);

                        if (temporal_s[0] != "")
                        {
                            total = total + Convert.ToDouble(temporal_s[2]);
                        }

                    }
                    lbl_cuenta.Text = "" + total;
                }
            }


        }

        private void btn_elim_ultimo_Click(object sender, EventArgs e)
        {
            string temporal = "";
            string[] temporal_s;
            double total = 0;
            try
            {
                lst_ventas.Items.Remove(lst_ventas.Items[lst_ventas.Items.Count - 1]);
                for (int coll = 0; coll < lst_ventas.Items.Count; coll++)
                {
                    temporal = "" + lst_ventas.Items[coll];
                    temporal_s = temporal.Split(G_parametros);

                    if (temporal_s[0] != "")
                    {
                        total = total + Convert.ToDouble(temporal_s[2]);
                    }
                    
                }
                lbl_cuenta.Text = "" + total;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btn_procesar_venta_Click(object sender, EventArgs e)
        {
            string temporal="";
            string[] temporal_s;
            double total=0;
            DateTime fecha_hora = DateTime.Now;
            confirmar_venta cv = new confirmar_venta();
            operaciones_archivos op = new operaciones_archivos();
            cv.arra_lis.Clear();
            cv.ids_productos.Clear();
            for (int coll = 0; coll < lst_ventas.Items.Count; coll++)
            {
                temporal=""+lst_ventas.Items[coll];
                temporal_s = temporal.Split(G_parametros);
                
                
                cv.arra_lis.Add(""+temporal_s[0]);
                cv.ids_productos.Add(""+temporal_s[1]);
                if (temporal_s[0]!="")
                {
                    
                    total = total + Convert.ToDouble(temporal_s[2]);
                }

            }
            
            cv.cantidad = total;
            cv.lbl_total.Text = ""+total;
            lst_ventas.Items.Clear();
            cv.Show();   
        }
    }
}

