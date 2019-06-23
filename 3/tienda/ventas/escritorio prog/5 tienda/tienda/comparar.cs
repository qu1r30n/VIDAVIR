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
    public partial class comparar : Form
    {
        char[] G_parametros = { '|' };

        string direc_tem = "";

        public string direccion_grafica { get; set; }

        public string palabra_reconocimiento { get; set; }

        public static string checkbox_en_uso;

        //----------------------------------------------
        private area_principal _parent;
        public comparar(area_principal parent)
        {

            _parent = parent;
            //---------------------------------------------------

            InitializeComponent();
            rdb_ventas.Checked = true;
            try
            {
                DateTime fecha_hora = DateTime.Now;
                cmb_año.Text = fecha_hora.ToString("yyyy");
                cmb_mes.Text = fecha_hora.ToString("MM");

                combo_a("ventas\\total_años.txt");
                combo_m("ventas\\" + cmb_año.Text + "\\" + cmb_año.Text + ".txt");
                combo_d("ventas\\" + cmb_año.Text + "\\" + cmb_mes.Text + "\\" + cmb_mes.Text + ".txt");


                tex_base bas = new tex_base();

                direc_tem = "ventas\\" + fecha_hora.ToString("yyyy") + "\\" + fecha_hora.ToString("MM") + "\\" + fecha_hora.ToString("MM") + ".txt";

                if (cmb_año.Items.Count == 0)
                {
                    MessageBox.Show("no estan los archivos as una venta y reinicia el programa para ver los graficos");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btn_comparar_Click(object sender, EventArgs e)
        {

            if (rdb_ventas.Checked)
            {
                if (checkbox_en_uso=="0")
                {
                    modelo_grafica(cmb_año.Text, cmb_mes.Text, cmb_dia.Text, true);
                }
                else
                {
                    MessageBox.Show("tienen que ser del mismo tipo las graficas ejemplo ventas y ventas");
                }
                
            }
            else if(rdb_productos.Checked)
            {
                if (checkbox_en_uso == "1")
                {
                    modelo_grafica_productos(cmb_año.Text, cmb_mes.Text, cmb_dia.Text, true);
                }
                else
                {
                    MessageBox.Show("tienen que ser del mismo tipo las graficas ejemplo ventas y ventas");
                }
            }


            else if(rdb_gastos.Checked)
            {
                if (checkbox_en_uso == "2")
                {
                    modelo_grafica_gastos(cmb_año.Text, cmb_mes.Text, cmb_dia.Text, true);
                }
                else
                {
                    MessageBox.Show("tienen que ser del mismo tipo las graficas ejemplo ventas y ventas");
                }
            }
            this.Close();
        }

        public void combo_a(string FILE_NAME)
        {
            string temp;
            cmb_año.Items.Clear();
            operaciones_archivos op = new operaciones_archivos();
            DateTime fecha_hora = DateTime.Now;
            string[] archivos = op.revicion_total(FILE_NAME);
            string[] espliteado;
            for (int i = 0; i < archivos.Length - 1; i++)
            {
                temp = archivos[i];
                espliteado = temp.Split(G_parametros);
                cmb_año.Items.Add(espliteado[0]);
            }
        }

        private void cmb_año_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo_m("ventas\\" + cmb_año.Text + "\\" + cmb_año.Text + ".txt");
        }

        private void cmb_mes_SelectedIndexChanged(object sender, EventArgs e)
        {
            combo_d("ventas\\" + cmb_año.Text + "\\" + cmb_mes.Text + "\\" + cmb_mes.Text + ".txt");
        }

        public void combo_m(string FILE_NAME)
        {
            string temp;
            cmb_mes.Items.Clear();
            operaciones_archivos op = new operaciones_archivos();
            DateTime fecha_hora = DateTime.Now;
            string[] archivos = op.revicion_total(FILE_NAME);
            string[] espliteado;
            for (int i = 0; i < archivos.Length - 1; i++)
            {
                temp = archivos[i];
                espliteado = temp.Split(G_parametros);
                cmb_mes.Items.Add(espliteado[0]);
            }

        }

        public void combo_d(string FILE_NAME)
        {
            string temp;
            cmb_dia.Items.Clear();
            operaciones_archivos op = new operaciones_archivos();
            DateTime fecha_hora = DateTime.Now;
            string[] archivos = op.revicion_total(FILE_NAME);
            string[] espliteado;
            for (int i = 0; i < archivos.Length - 1; i++)
            {
                temp = archivos[i];
                espliteado = temp.Split(G_parametros);
                cmb_dia.Items.Add(espliteado[0]);
            }
        }


        public void modelo_grafica(string c_año = "", string c_mes = "", string c_dia = "", bool comparacion = true)
        {

            _parent.lst_ventas.Items.Clear();
            if (c_año == "" && c_mes == "" && c_dia == "")
            {
               _parent.grafica_para_comparar(direccion_grafica, "ventas\\total_años.txt",palabra_reconocimiento,"total_años", comparacion);
            }

            else if (c_año != "" && c_mes == "" && c_dia == "")
            {
                _parent.grafica_para_comparar(direccion_grafica, "ventas\\" + c_año + "\\" + c_año + ".txt",palabra_reconocimiento, c_año, comparacion);
            }
            else if (c_año != "" && c_mes != "" && c_dia == "")
            {
                _parent.grafica_para_comparar(direccion_grafica, "ventas\\" + c_año + "\\" + c_mes + "\\" + c_mes + ".txt",palabra_reconocimiento, c_año + "-" + c_mes, comparacion);
            }
            else if (c_año != "" && c_mes != "" && c_dia != "")
            {
                _parent.grafica_horas_para_comparar(direccion_grafica, "ventas\\" + c_año + "\\" + c_mes + "\\" + "dias\\" + c_dia + "-" + c_mes + "-" + c_año + ".txt", palabra_reconocimiento, c_año + "-" + c_mes + "-" + c_dia, 0, comparacion);
            }
            else
            {
                MessageBox.Show("error verifica que los combobox");
            }
        }

        public void modelo_grafica_productos(string c_año = "", string c_mes = "", string c_dia = "", bool comparacion = false)
        {
            _parent.lst_ventas.Items.Clear();
            if (c_año == "" && c_mes == "" && c_dia == "")
            {
                _parent.grafica_para_comparar(direccion_grafica,"ventas\\p_total_años.txt",palabra_reconocimiento, "p_total_años", comparacion);
            }

            else if (c_año != "" && c_mes == "" && c_dia == "")
            {
                _parent.grafica_para_comparar(direccion_grafica,"ventas\\" + c_año + "\\p_" + c_año + ".txt",palabra_reconocimiento, "p_" + c_año, comparacion);
            }
            else if (c_año != "" && c_mes != "" && c_dia == "")
            {
                _parent.grafica_para_comparar(direccion_grafica,"ventas\\" + c_año + "\\" + c_mes + "\\p_" + c_mes + ".txt",palabra_reconocimiento, "p_" + c_año + "-" + c_mes, comparacion);
            }
            else if (c_año != "" && c_mes != "" && c_dia != "")
            {
                _parent.grafica_horas_para_comparar(direccion_grafica,"ventas\\" + c_año + "\\" + c_mes + "\\" + "dias\\p_" + c_dia + "-" + c_mes + "-" + c_año + ".txt",palabra_reconocimiento,"p_" + c_año + "-" + c_mes + "-" + c_dia, 0, comparacion);
            }
            else
            {
                MessageBox.Show("error verifica que los combobox");
            }
        }

        public void modelo_grafica_gastos(string c_año = "", string c_mes = "", string c_dia = "", bool comparacion = false)
        {
            _parent.lst_ventas.Items.Clear();
            if (c_año == "" && c_mes == "" && c_dia == "")
            {
                _parent.grafica_para_comparar(direccion_grafica,"ventas\\g_total_años.txt",palabra_reconocimiento, "g_total_años", comparacion);
            }

            else if (c_año != "" && c_mes == "" && c_dia == "")
            {
                _parent.grafica_para_comparar(direccion_grafica,"ventas\\" + c_año + "\\g_" + c_año + ".txt",palabra_reconocimiento, "g_" + c_año, comparacion);
            }
            else if (c_año != "" && c_mes != "" && c_dia == "")
            {
                _parent.grafica_para_comparar(direccion_grafica,"ventas\\" + c_año + "\\" + c_mes + "\\g_" + c_mes + ".txt",palabra_reconocimiento, "g_" + c_año + "-" + c_mes, comparacion);
            }
            else if (c_año != "" && c_mes != "" && c_dia != "")
            {
                _parent.grafica_horas_para_comparar(direccion_grafica,"ventas\\" + c_año + "\\" + c_mes + "\\" + "dias\\g_" + c_dia + "-" + c_mes + "-" + c_año + ".txt", palabra_reconocimiento, "g_" + c_año + "-" + c_mes + "-" + c_dia, 1, comparacion);
            }
            else
            {
                MessageBox.Show("error verifica que los combobox");
            }
        }

    }
}

