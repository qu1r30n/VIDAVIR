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
            recargar_texbox();
        }

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            string temporal = "";
            string[] temporal_s;
            decimal total = 0;
            decimal total_cost_com = 0;
            bool bandera = false;

            if (txt_buscar_producto.Text != "")
            {
                for (int i = 0; i < txt_buscar_producto.AutoCompleteCustomSource.Count; i++)
                {

                    if (txt_buscar_producto.Text == ("" + txt_buscar_producto.AutoCompleteCustomSource[i].ToString()))
                    {
                        lst_ventas.Items.Add(txt_buscar_producto.Text);
                        txt_buscar_producto.Text = "";
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

                    //-------------------------------------------------------------
                    string[] enviar = { "id°" + (cantidad_produc.Length), "producto", "precio", "codigo°" + espliteado[0], "cantidad", "compra", "marca" };
                    string mensage=vent_emergent.proceso_ventana_emergente(enviar, 1);//el uno significa que modificara el inventario
                    MessageBox.Show(mensage);
                }

                for (int coll = 0; coll < lst_ventas.Items.Count; coll++)
                {
                    temporal = "" + lst_ventas.Items[coll];
                    temporal_s = temporal.Split(G_parametros);

                    if (temporal_s[0] != "")
                    {
                        total = total + Convert.ToDecimal(temporal_s[2]);
                        total_cost_com = total_cost_com + Convert.ToDecimal(temporal_s[5]);
                    }
                }
                lbl_cuenta.Text = "" + total;
                txt_buscar_producto.Focus();

            }
        }

        private void btn_eliminar_todo_Click(object sender, EventArgs e)
        {
            string temporal = "";
            string[] temporal_s;
            decimal total = 0;
            decimal total_cost_com = 0;

            try
            {
                lst_ventas.Items.Clear();
                for (int coll = 0; coll < lst_ventas.Items.Count; coll++)
                {
                    temporal = "" + lst_ventas.Items[coll];
                    temporal_s = temporal.Split(G_parametros);

                    if (temporal_s[0] != "")
                    {
                        total = total + Convert.ToDecimal(temporal_s[2]);
                        total_cost_com = total_cost_com + Convert.ToDecimal(temporal_s[5]);
                    }

                }
                lbl_cuenta.Text = "" + total;
            }
            catch (Exception)
            {

                throw;
            }
            txt_buscar_producto.Focus();
        }

        private void btn_eliminar_seleccionado_Click(object sender, EventArgs e)
        {
            string temporal = "";
            string[] temporal_s;
            decimal total = 0;
            decimal total_cost_com = 0;

            try
            {
                lst_ventas.Items.RemoveAt(lst_ventas.SelectedIndex);
                for (int coll = 0; coll < lst_ventas.Items.Count; coll++)
                {
                    temporal = "" + lst_ventas.Items[coll];
                    temporal_s = temporal.Split(G_parametros);

                    if (temporal_s[0] != "")
                    {
                        total = total + Convert.ToDecimal(temporal_s[2]);
                        total_cost_com = total_cost_com + Convert.ToDecimal(temporal_s[5]);
                    }

                }
                lbl_cuenta.Text = "" + total;
            }
            catch (Exception)
            {

                throw;
            }

            txt_buscar_producto.Focus();
        }

        private void txt_buscar_producto_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            string temporal = "";
            string[] temporal_s;
            decimal total = 0;
            decimal total_cost_com = 0;
            bool bandera = false;

            if (txt_buscar_producto.Text != "")
            {
                if (e.KeyValue == (char)(Keys.Enter))
                {
                    for (int i = 0; i < txt_buscar_producto.AutoCompleteCustomSource.Count; i++)
                    {

                        if (txt_buscar_producto.Text == (""+txt_buscar_producto.AutoCompleteCustomSource[i].ToString()))
                        {
                            lst_ventas.Items.Add(txt_buscar_producto.Text);
                            txt_buscar_producto.Text = "";
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

                        //-------------------------------------------------------------
                        string[] enviar = { "id°" + (cantidad_produc.Length), "producto", "precio", "codigo°" + espliteado[0],  "cantidad", "compra", "marca" };
                        string mensage = vent_emergent.proceso_ventana_emergente(enviar, 1);//el uno significa que modificara el inventario
                        MessageBox.Show("ya se agrego el producto: "+mensage);
                        txt_buscar_producto.Text = "";
                        }
                    
                    for (int coll = 0; coll < lst_ventas.Items.Count; coll++)
                    {
                        temporal = "" + lst_ventas.Items[coll];
                        temporal_s = temporal.Split(G_parametros);

                        if (temporal_s[0] != "")
                        {
                            total = total + Convert.ToDecimal(temporal_s[2]);
                            total_cost_com = total_cost_com + Convert.ToDecimal(temporal_s[5]);
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
            decimal total = 0;
            decimal total_cost_com = 0;
            try
            {
                lst_ventas.Items.Remove(lst_ventas.Items[lst_ventas.Items.Count - 1]);
                for (int coll = 0; coll < lst_ventas.Items.Count; coll++)
                {
                    temporal = "" + lst_ventas.Items[coll];
                    temporal_s = temporal.Split(G_parametros);

                    if (temporal_s[0] != "")
                    {
                        total = total + Convert.ToDecimal(temporal_s[2]);
                        total_cost_com = total_cost_com + Convert.ToDecimal(temporal_s[5]);
                    }
                    
                }
                lbl_cuenta.Text = "" + total;
            }
            catch (Exception)
            {

                throw;
            }
            txt_buscar_producto.Focus();
        }

        private void btn_procesar_venta_Click(object sender, EventArgs e)
        {
            string temporal="";
            string[] temporal_s;
            decimal total=0;
            decimal total_cost_com = 0;

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

                    total = total + Convert.ToDecimal(temporal_s[2]);
                    total_cost_com = total_cost_com + Convert.ToDecimal(temporal_s[5]);
                }

            }
            
            cv.cantidad = total;
            cv.cost_comp = total_cost_com;
            cv.lbl_total.Text = "" + total;
            cv.txt_dinero.Text = "" + total;
            
            lst_ventas.Items.Clear();
            txt_buscar_producto.Focus();
            cv.Show();   
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
    }
}

