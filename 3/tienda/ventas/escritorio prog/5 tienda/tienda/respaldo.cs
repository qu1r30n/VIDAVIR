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
    public partial class respaldo : Form
    {
        string direccion="";
        bool dec = false;
        char[] G_parametros = { '|' };
        public respaldo()
        {
            InitializeComponent();
        }

        private void btn_donde_guardar_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(fbd.SelectedPath);
                direccion = fbd.SelectedPath;
                lbl_direccion.Text = direccion;
                dec = true;
                fbd.Reset();
            }
            else
            {
                return;
            }
        }

        private void btn_respaldar_Click(object sender, EventArgs e)
        {
            DateTime fecha_hora = DateTime.Now;
            if (dec==true)
            {
                operaciones_archivos op = new operaciones_archivos();
                op.respaldos_ventas("ventas", direccion + "\\respaldo_"+ fecha_hora.ToString("dd-MM-yyyy") +"\\ventas", true);
                op.respaldo_inventario("inf\\inventario", direccion + "\\respaldo\\inf\\inventario");
                lbl_direccion.Text = "oprime boton donde guararlos para buscar donde poner el respaldo";
                dec = false;
            }
        }

        private void btn_usar_respaldo_Click(object sender, EventArgs e)
        {
            if (dec == true)
            {
                operaciones_archivos op = new operaciones_archivos();
                op.eliminar_carpeta(".\\ventas");
                op.eliminar_carpeta(".\\inf\\inventario");
                op.respaldos_ventas(direccion, ""+ G_parametros[0], true);
                op.respaldo_inventario(direccion, "inf");
                lbl_direccion.Text = "oprime boton donde guararlos para buscar donde poner el respaldo";
                dec = false;
            }
        }
    }
}
