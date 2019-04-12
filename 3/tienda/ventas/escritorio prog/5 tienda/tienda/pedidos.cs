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


        public pedidos()
        {
            InitializeComponent();
            tex_base bas = new tex_base();
            bas.crear_archivo_y_directorio("inf\\inventario\\invent.txt", "id,producto,precio");
            string[] imprimir = bas.leer("inf\\inventario\\invent.txt", "1,0", ",");
            for (int i = 1; i < imprimir.Length; i++)
            {
                txt_buscar_producto.AutoCompleteCustomSource.Add("" + imprimir[i]);
            }
        }
        private void btn_agregar_Click(object sender, EventArgs e)
        {
            if ("" != txt_buscar_producto.Text && "" != txt_cantidad.Text)
            {
                lst_ventas.Items.Add(txt_buscar_producto.Text + "," + txt_cantidad.Text);
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
    }
}


