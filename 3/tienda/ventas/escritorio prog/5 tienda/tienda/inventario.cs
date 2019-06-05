using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tienda
{
    public partial class inventario : Form
    {
        char[] G_parametros = { '|' };
        public inventario()
        {
            InitializeComponent();
            tex_base bas = new tex_base();
            bas.crear_archivo_y_directorio("inf\\inventario\\invent.txt", "id,producto,precio,cantidad");
            string [] imprimir = bas.leer("inf\\inventario\\invent.txt", "0|1|2|3",""+ G_parametros[0]);
            for (int i = 0; i < imprimir.Length; i++)
            {
                lst_productos.Items.Add(imprimir[i]);
            }
            
        } 

        private void btn_agregar_Click(object sender, EventArgs e)
        {
            txt_edit_id_producto.Hide();
            txt_edit_nombre.Hide();
            txt_edit_precio.Hide();
            txt_edit_cantidad.Hide();
            lbl_edit_id_producto.Hide();
            lbl_edit_producto.Hide();
            lbl_edit_precio.Hide();
            lbl_edit_cantidad.Hide();
            btn_edit_por.Hide();

            tex_base bas = new tex_base();
            bas.crear_archivo_y_directorio("inf\\inventario\\invent.txt", "id,producto,precio,cantidad");
            if ("" != txt_precio.Text && "" != txt_nombre.Text)
            {
                bas.agregar("inf\\inventario\\invent.txt", txt_id_producto.Text + G_parametros[0] + txt_nombre.Text + G_parametros + txt_precio.Text + G_parametros + txt_cantidad.Text, "id,producto,precio,cantidad");
                lst_productos.Items.Clear();
                string[] imprimir = bas.leer("inf\\inventario\\invent.txt", "0|1|2|3", "" + G_parametros[0]);
                for (int i = 0; i < imprimir.Length; i++)
                {
                    lst_productos.Items.Add(imprimir[i]);
                }

            }
            else
            {
                MessageBox.Show("no estan llenas las casillas del producto o el precio");
            }
        }
        
        private void btn_editar_Click(object sender, EventArgs e)
        {
            txt_edit_id_producto.Show();
            txt_edit_nombre.Show();
            txt_edit_precio.Show();
            txt_edit_cantidad.Show();
            lbl_edit_id_producto.Show();
            lbl_edit_producto.Show();
            lbl_edit_precio.Show();
            lbl_edit_cantidad.Show();
            btn_edit_por.Show();
            
            

        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            txt_edit_id_producto.Hide();
            txt_edit_nombre.Hide();
            txt_edit_precio.Hide();
            txt_edit_cantidad.Hide();
            lbl_edit_id_producto.Hide();
            lbl_edit_producto.Hide();
            lbl_edit_precio.Hide();
            lbl_edit_cantidad.Hide();
            btn_edit_por.Hide();

            tex_base bas = new tex_base();
            bas.crear_archivo_y_directorio("inf\\inventario\\invent.txt", "id,producto,precio");
            bas.eliminar("inf\\inventario\\invent.txt", txt_nombre.Text);
            lst_productos.Items.Clear();
            string [] leido = bas.leer("inf\\inventario\\invent.txt", "0|1|2|3",""+ G_parametros[0]);
            foreach (var item in leido)
            {
                lst_productos.Items.Add(item);
            }
        }


        private void btn_edit_por_Click(object sender, EventArgs e)
        {
            tex_base bas = new tex_base();
            bas.crear_archivo_y_directorio("inf\\inventario\\invent.txt", "id,producto,precio");
            if ("" != txt_precio.Text && "" != txt_nombre.Text)
            {
                
                MessageBox.Show(bas.editar("inf\\inventario\\invent.txt", txt_id_producto.Text + G_parametros[0] + txt_nombre.Text + G_parametros + txt_precio.Text + G_parametros + txt_cantidad.Text,txt_edit_id_producto.Text +G_parametros + txt_edit_nombre.Text + G_parametros + txt_edit_precio.Text + G_parametros + txt_edit_cantidad.Text, "0,1,2,3"));

                lst_productos.Items.Clear();

                foreach (var item in bas.leer("inf\\inventario\\invent.txt", "0|1|2|3", "" + G_parametros[0]))
                {
                    lst_productos.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("no estan llenas las casillas del producto o el precio");
            }
            txt_edit_id_producto.Hide();
            txt_edit_nombre.Hide();
            txt_edit_precio.Hide();
            txt_edit_cantidad.Hide();
            lbl_edit_id_producto.Hide();
            lbl_edit_producto.Hide();
            lbl_edit_precio.Hide();
            lbl_edit_cantidad.Hide();
            btn_edit_por.Hide();

        }

        private void lst_productos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string temp = "";
            string[] temp2;
            temp = "" + lst_productos.SelectedItem;
            temp2 = temp.Split(G_parametros);
            txt_id_producto.Text = temp2[0];
            txt_nombre.Text = temp2[1];
            txt_precio.Text = temp2[2];
            txt_cantidad.Text = temp2[3];
            txt_edit_id_producto.Text = temp2[0];
            txt_edit_nombre.Text = temp2[1];
            txt_edit_precio.Text = temp2[2];
            txt_edit_cantidad.Text = temp2[3];
        }
    }
}
