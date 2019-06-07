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
    public partial class area_principal : Form
    {
        string direc_tem="";
        char[] G_parametros = { '|' };
        public area_principal()
        {
            InitializeComponent();
            try
            {
                
                DateTime fecha_hora = DateTime.Now;//guarda la fecha y hora de ahurita
                tex_base bas = new tex_base();//bas es la clase tex_base
                direc_tem = "ventas\\" + fecha_hora.ToString("yyyy") + "\\" + fecha_hora.ToString("MM") + "\\" + fecha_hora.ToString("MM") + ".txt";//direccion del archivo de hoy
                cmb_año.Text = fecha_hora.ToString("yyyy");//el combo box del año contendra el año de hoy
                cmb_mes.Text = fecha_hora.ToString("MM");//el combo box del mes contendra el mes de hoy
                combo_a("ventas\\total_años.txt");//extrae de total_años.txt  todos los años  que se a generedado archivos
                combo_m("ventas\\" + fecha_hora.ToString("yyyy") + "\\" + fecha_hora.ToString("yyyy") + ".txt");// extrae de el año actual todos los meses que se a generedado archivos
                combo_d("ventas\\" + fecha_hora.ToString("yyyy") + "\\" + fecha_hora.ToString("MM") + "\\" + fecha_hora.ToString("MM") + ".txt");// extrae del mes actual todos los dias  que se a generedado archivos

                grafica(direc_tem, fecha_hora.ToString("yyyy-MM"),false);//hace una graficacion de año-mes

                if (cmb_año.Items.Count==0)//si el archivo no tiene lineas  quiere decir que no tendra el combobox  items  y si  los items son igual a 0 entra y manda un mensaje
                {
                    MessageBox.Show("no estan los archivos has una venta y reinicia el programa para ver los graficos");//hace el mensaje
                }
                rdb_ventas.Checked = true; //pone por defecto el radio buton en ventas
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        #region botones y combobox
        private void btn_inventario_Click(object sender, EventArgs e)
        {
            lbl_ganancia.Visible = false;//pone invisible el label de ganancia
            txt_ganancia.Visible = false;//pone invisible el textbox de ganancia

            inventario invent = new inventario();//invent sera el form inventario
            invent.Show();//muestra el form inventario
        }

        private void btn_nueva_venta_Click(object sender, EventArgs e)
        {
            lbl_ganancia.Visible = false;//pone invisible el label de ganancia
            txt_ganancia.Visible = false;//pone invisible el textbox de ganancia

            ventas nuev_vent = new ventas();//nuev_vent sera el form ventas
            nuev_vent.Show();//muestra el form ventas

        }

        private void btn_empleados_Click(object sender, EventArgs e)
        {
            lbl_ganancia.Visible = false;//pone invisible el label de ganancia
            txt_ganancia.Visible = false;//pone invisible el textbox de ganancia

            empleados empl = new empleados();//nuev_vent sera el form empleados
            empl.Show();// muestra el form empleados
        }

        private void btn_compras_Click(object sender, EventArgs e)
        {
            lbl_ganancia.Visible = false;
            txt_ganancia.Visible = false;

            compras comp = new compras();
            comp.Show();
        }

        private void btn_respaldo_Click(object sender, EventArgs e)
        {
            lbl_ganancia.Visible = false;
            txt_ganancia.Visible = false;

            respaldo respaldo = new respaldo();
            respaldo.Show();
        }

        private void btn_pedidos_Click(object sender, EventArgs e)
        {
            lbl_ganancia.Visible = false;
            txt_ganancia.Visible = false;

            pedidos pedi = new pedidos();
            pedi.Show();
        }

        private void btn_comparar_Click(object sender, EventArgs e)
        {
            lbl_ganancia.Visible = false;
            txt_ganancia.Visible = false;

            comparar comp = new comparar(this);
            if (rdb_ventas.Checked)
            {
                comparar.checkbox_en_uso = "0";
                modelo_grafica(cmb_año.Text, cmb_mes.Text, cmb_dia.Text, true);
            }
            else if (rdb_productos.Checked)
            {
                comparar.checkbox_en_uso = "1";
                modelo_grafica_productos(cmb_año.Text, cmb_mes.Text, cmb_dia.Text, true);
            }

            else if (rdb_gastos.Checked)
            {
                comparar.checkbox_en_uso = "2";
                modelo_grafica_gastos(cmb_año.Text, cmb_mes.Text, cmb_dia.Text, true);
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

        private void rdb_ventas_CheckedChanged(object sender, EventArgs e)
        {
            lbl_ganancia.Visible = false;
            txt_ganancia.Visible = false;

            if (rdb_ventas.Checked)
            {
                modelo_grafica(cmb_año.Text, cmb_mes.Text, cmb_dia.Text, false);
            }
        }

        private void rdb_productos_CheckedChanged(object sender, EventArgs e)
        {
            lbl_ganancia.Visible = false;
            txt_ganancia.Visible = false;

            if (rdb_productos.Checked)
            {
                modelo_grafica_productos(cmb_año.Text, cmb_mes.Text, cmb_dia.Text, false);
            }
        }

        private void rdb_gastos_CheckedChanged(object sender, EventArgs e)
        {
            lbl_ganancia.Visible = false;
            txt_ganancia.Visible = false;

            if (rdb_gastos.Checked)
            {
                modelo_grafica_gastos(cmb_año.Text, cmb_mes.Text, cmb_dia.Text, false);
            }
        }

        private void btn_ganancias_Click(object sender, EventArgs e)
        {
            DateTime fecha_hora = DateTime.Now;
            operaciones_archivos op = new operaciones_archivos();
            modelo_grafica_ganancias(cmb_año.Text, cmb_mes.Text, cmb_dia.Text, true);
            lbl_ganancia.Visible = true;
            txt_ganancia.Visible = true;

        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------
        public void modelo_grafica(string c_año="",string c_mes="",string c_dia="",bool comparacion=false)
        {
            comparar comp = new comparar(this);
            lst_ventas.Items.Clear();


            if (c_año == "" && c_mes == "" && c_dia == "")
            {
                comp.direccion_grafica = "ventas\\total_años.txt";
                comp.palabra_reconocimiento = "total_años";

                if (comparacion==false)
                {
                    grafica(comp.direccion_grafica, "total_años", comparacion);
                }
                else
                {
                    comp.Show();
                }
                
            }

            else if (c_año != "" && c_mes == "" && c_dia == "")
            {
                comp.direccion_grafica = "ventas\\" + c_año + "\\" + c_año + ".txt";
                comp.palabra_reconocimiento = c_año;

                if (comparacion == false)
                {
                    grafica(comp.direccion_grafica, c_año, comparacion);
                }
                else
                {
                    comp.Show();
                }
            }

            else if (c_año != "" && c_mes != "" && c_dia == "")
            {
                comp.direccion_grafica = "ventas\\" + c_año + "\\" + c_mes + "\\" + c_mes + ".txt";
                comp.palabra_reconocimiento = c_año + "-" + c_mes;

                if (comparacion == false)
                {
                    grafica(comp.direccion_grafica, c_año + "-" + c_mes, comparacion);
                }
                else
                {
                    comp.Show();
                }
            }

            else if (c_año != "" && c_mes != "" && c_dia != "")
            {
                comp.direccion_grafica = "ventas\\" + c_año + "\\" + c_mes + "\\" + "dias\\" + c_dia + "-" + c_mes + "-" + c_año + ".txt";
                comp.palabra_reconocimiento = c_año + "-" + c_mes + "-" + c_dia;

                if (comparacion==false)
                {
                    grafica_horas(comp.direccion_grafica, 0, c_año + "-" + c_mes + "-" + c_dia, comparacion);
                }
                else
                {
                    comp.Show();
                }
            }
            else
            {
                MessageBox.Show("error verifica que los combobox");
            }
        }

        public void modelo_grafica_productos(string c_año = "", string c_mes = "", string c_dia = "",bool comparacion = false)
        {
            comparar comp = new comparar(this);
            lst_ventas.Items.Clear();





            if (c_año == "" && c_mes == "" && c_dia == "")
            {
                comp.direccion_grafica = "ventas\\p_total_años.txt";
                comp.palabra_reconocimiento = "p_total_años";
                if (comparacion == false)
                {
                    grafica(comp.direccion_grafica, "p_total_años", comparacion);
                }
                else
                {
                    comp.Show();
                }
                
            }

            else if (c_año != "" && c_mes == "" && c_dia == "")
            {
                comp.direccion_grafica = "ventas\\" + c_año + "\\p_" + c_año + ".txt";
                comp.palabra_reconocimiento = "p_" + c_año;
                if (comparacion == false)
                {
                    grafica(comp.direccion_grafica, "p_" + c_año, comparacion);
                }
                else
                {
                    comp.Show();
                }
            }

            else if (c_año != "" && c_mes != "" && c_dia == "")
            {

                comp.direccion_grafica = "ventas\\" + c_año + "\\" + c_mes + "\\p_" + c_mes + ".txt";
                comp.palabra_reconocimiento = "p_" + c_año + "-" + c_mes;

                if (comparacion == false)
                {
                    grafica(comp.direccion_grafica, "p_" + c_año + "-" + c_mes, comparacion);
                }
                else
                {
                    comp.Show();
                }
            }

            else if (c_año != "" && c_mes != "" && c_dia != "")
            {
                comp.direccion_grafica = "ventas\\" + c_año + "\\" + c_mes + "\\" + "dias\\p_" + c_dia + "-" + c_mes + "-" + c_año + ".txt";
                comp.palabra_reconocimiento = "p_" + c_año + "-" + c_mes + "-" + c_dia;

                if (comparacion == false)
                {
                    grafica(comp.direccion_grafica, "p_" + c_año + "-" + c_mes + "-" + c_dia, comparacion);
                }
                else
                {
                    comp.Show();
                }
            }
            else
            {
                MessageBox.Show("error verifica que los combobox");
            }
        }

        public void modelo_grafica_gastos(string c_año = "", string c_mes = "", string c_dia = "",bool comparacion = false)
        {
            comparar comp = new comparar(this);
            lst_ventas.Items.Clear();





            if (c_año == "" && c_mes == "" && c_dia == "")
            {

                comp.direccion_grafica = "ventas\\g_total_años.txt";
                comp.palabra_reconocimiento = "g_total_años";

                if (comparacion == false)
                {
                    grafica(comp.direccion_grafica, "g_total_años", comparacion);
                }
                else
                {
                    comp.Show();
                }


            }

            else if (c_año != "" && c_mes == "" && c_dia == "")
            {
                comp.direccion_grafica = "ventas\\" + c_año + "\\g_" + c_año + ".txt";
                comp.palabra_reconocimiento = "g_" + c_año;
                if (comparacion == false)
                {
                    grafica(comp.direccion_grafica, "g_" + c_año, comparacion);
                }
                else
                {
                    comp.Show();
                }


            }

            else if (c_año != "" && c_mes != "" && c_dia == "")
            {

                comp.direccion_grafica = "ventas\\" + c_año + "\\" + c_mes + "\\g_" + c_mes + ".txt";
                comp.palabra_reconocimiento = "g_" + c_año + "-" + c_mes;
                if (comparacion == false)
                {
                    grafica(comp.direccion_grafica, "g_" + c_año + "-" + c_mes, comparacion);
                }
                else
                {
                    comp.Show();
                }
            }

            else if (c_año != "" && c_mes != "" && c_dia != "")
            {
                

                comp.direccion_grafica = "ventas\\" + c_año + "\\" + c_mes + "\\" + "dias\\g_" + c_dia + "-" + c_mes + "-" + c_año + ".txt";
                comp.palabra_reconocimiento = "g_" + c_año + "-" + c_mes + "-" + c_dia;
                if (comparacion == false)
                {
                    grafica_horas(comp.direccion_grafica, 1, "g_" + c_año + "-" + c_mes + "-" + c_dia, comparacion);
                }
                else
                {
                    comp.Show();
                }
            }
            else
            {
                MessageBox.Show("error verifica que los combobox");
            }
        }

        public void modelo_grafica_ganancias(string c_año = "", string c_mes = "", string c_dia = "", bool comparacion = true)
        {

            string direc,direc2, nom_serie,nom_serie2;
            lst_ventas.Items.Clear();
            if (c_año == "" && c_mes == "" && c_dia == "")
            {
                grafica_ganancias("ventas\\total_años.txt", "ventas\\g_total_años.txt", "total_venta", "total_gasto", comparacion);
            }

            else if (c_año != "" && c_mes == "" && c_dia == "")
            {
                direc = "ventas\\" + c_año + "\\" + c_año + ".txt";
                direc2 = "ventas\\" + c_año + "\\g_" + c_año + ".txt";
                nom_serie = c_año;
                nom_serie2 = "g_" + c_año;
                grafica_ganancias(direc,direc2,nom_serie ,nom_serie2, comparacion);
            }
            else if (c_año != "" && c_mes != "" && c_dia == "")
            {
                direc = "ventas\\" + c_año + "\\" + c_mes + "\\" + c_mes + ".txt";
                direc2 = "ventas\\" + c_año + "\\" + c_mes + "\\g_" + c_mes + ".txt";
                nom_serie = c_año + "-" + c_mes;
                nom_serie2 = "g_" + c_año + "-" + c_mes;
                grafica_ganancias(direc,direc2,nom_serie,nom_serie2, comparacion);
            }
            else if (c_año != "" && c_mes != "" && c_dia != "")
            {
                direc = "ventas\\" + c_año + "\\" + c_mes + "\\" + "dias\\" + c_dia + "-" + c_mes + "-" + c_año + ".txt";
                direc2 = "ventas\\" + c_año + "\\" + c_mes + "\\" + "dias\\g_" + c_dia + "-" + c_mes + "-" + c_año + ".txt";
                nom_serie = c_año + "-" + c_mes + "-" + c_dia;
                nom_serie2 = "g_" + c_año + "-" + c_mes + "-" + c_dia;
                grafica_horas_ganancias(direc,direc2,nom_serie,nom_serie2, 0, comparacion);
            }
            else
            {
                MessageBox.Show("error verifica que los combobox");
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------------

        public void grafica(string FILE_NAME,string nombre_serie="Serie1",bool comparacion = false)
        {
            if (comparacion==false)
            {
                chrt_ventas.Series.Clear();
            }
            try
            {
                chrt_ventas.Series.Add(nombre_serie);
            }
            catch (Exception)
            {

                throw;
            }

            chrt_ventas.Series[nombre_serie].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            operaciones_archivos op = new operaciones_archivos();

            string[] esplitedo, historial;

            historial = op.revicion_total(FILE_NAME);

            for (int i = 0; i < historial.Length - 1; i++)
            {
                esplitedo = historial[i].Split(';');
                chrt_ventas.Series[0].Points.AddXY(esplitedo[0], esplitedo[1]);
                lst_ventas.Items.Add(esplitedo[0] + ";" + esplitedo[1]);
            }
            txt_total.Text = "" + historial[historial.Length - 1];
        }
        public void grafica_horas(string FILE_NAME, int decicion = 0, string nombre_serie = "Serie1",bool comparacion = false)
        {
            if (comparacion==false)
            {
                chrt_ventas.Series.Clear();
            }

            try
            {
                chrt_ventas.Series.Add(nombre_serie);
            }
            catch (Exception)
            {

                throw;
            }
            


            chrt_ventas.Series[nombre_serie].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            operaciones_archivos op = new operaciones_archivos();

            string[] esplitedo, historial;

            if (decicion == 0)
            {
                historial = op.revicion_total_horas(FILE_NAME);
            }
            else
            {
                historial = op.revicion_total_horas(FILE_NAME, 1);
            }


            for (int i = 0; i < historial.Length - 1; i++)
            {
                esplitedo = historial[i].Split(G_parametros);
                chrt_ventas.Series[0].Points.AddXY(esplitedo[0], esplitedo[2]);
                if (decicion == 0)
                {
                    lst_ventas.Items.Add(esplitedo[0] + G_parametros[0] + esplitedo[2]);
                }
                else
                {
                    lst_ventas.Items.Add(esplitedo[0] + ": "+ esplitedo[1] + ": " + esplitedo[2]);
                }
            }
            txt_total.Text = "" + historial[historial.Length - 1];
        }

        public void grafica_para_comparar(string FILE_NAME, string FILE_NAME2, string nombre_serie, string nombre_serie2, bool comparacion = false)
        {
            chrt_ventas.Series.Clear();
            try
            {
                chrt_ventas.Series.Add(nombre_serie);
                chrt_ventas.Series.Add(nombre_serie2);
            }
            catch (Exception)
            {

                MessageBox.Show("tienen que ser diferentes las fechas de comparacion");
                return;
            }
            
            chrt_ventas.Series[nombre_serie].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chrt_ventas.Series[nombre_serie2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            operaciones_archivos op = new operaciones_archivos();

            string[] esplitedo = { "", "" }, esplitedo2 = { "", "" }, historial, historial2;
            int cual_es_mayor=0;
            historial = op.revicion_total(FILE_NAME);
            historial2 = op.revicion_total(FILE_NAME2);

            if (historial.Length>=historial2.Length)
            {
                cual_es_mayor = historial.Length;
            }
            else
            {
                cual_es_mayor = historial2.Length;
            }
            int cual_anotar = 0;
            for (int i = 0; i < cual_es_mayor - 1; i++)
            {
                if (i < historial.Length - 1)
                {
                    esplitedo = historial[i].Split(';');
                    chrt_ventas.Series[0].Points.AddXY(esplitedo[0], esplitedo[1]);
                    cual_anotar = cual_anotar + 1;
                }
                if (i < historial2.Length - 1)
                {
                    esplitedo2 = historial2[i].Split(';');
                    chrt_ventas.Series[1].Points.AddXY(esplitedo2[0], esplitedo2[1]);
                    cual_anotar = cual_anotar + 2;
                }

                switch (cual_anotar)
                {
                    case 1:
                        lst_ventas.Items.Add(esplitedo[0] + ";" + esplitedo[1] + "          ");
                        break;
                    case 2:
                        lst_ventas.Items.Add("          " + esplitedo2[0] + ";" + esplitedo2[1]);
                        break;
                    case 3:
                        lst_ventas.Items.Add(esplitedo[0] + ";" + esplitedo[1] + "          " + esplitedo2[0] + ";" + esplitedo2[1]);
                        break;
                    default:
                        MessageBox.Show("error switch");
                        break;
                }

                cual_anotar = 0;
            }
            txt_total.Text = "" + historial[historial.Length - 1];
            txt_total.Text = txt_total.Text+ ";  " + historial2[historial2.Length - 1];
        }
        
        public void grafica_horas_para_comparar(string FILE_NAME,string FILE_NAME2, string nombre_serie, string nombre_serie2, int decicion = 0, bool comparacion = false)
        {
            if (comparacion == false)
            {
                chrt_ventas.Series.Clear();
            }

            try
            {
                chrt_ventas.Series.Add(nombre_serie);
            }
            catch (Exception)
            {

                
            }
            chrt_ventas.Series[nombre_serie].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            operaciones_archivos op = new operaciones_archivos();

            string[] esplitedo, historial;

            if (decicion == 0)
            {
                historial = op.revicion_total_horas(FILE_NAME);
            }
            else
            {
                historial = op.revicion_total_horas(FILE_NAME, 1);
            }

            for (int i = 0; i < historial.Length - 1; i++)
            {
                esplitedo = historial[i].Split(G_parametros);
                chrt_ventas.Series[0].Points.AddXY(esplitedo[0], esplitedo[1]);
                if (decicion == 0)
                {
                    lst_ventas.Items.Add(esplitedo[0] + G_parametros[0] + esplitedo[1]);
                }
                else
                {
                    lst_ventas.Items.Add(esplitedo[1] + ": " + esplitedo[2]);
                }
            }
            txt_total.Text = "" + historial[historial.Length - 1];
        }

        public void grafica_ganancias(string FILE_NAME, string FILE_NAME2, string nombre_serie, string nombre_serie2, bool comparacion = false)
        {
            chrt_ventas.Series.Clear();
            try
            {
                chrt_ventas.Series.Add(nombre_serie);
                chrt_ventas.Series.Add(nombre_serie2);
            }
            catch (Exception)
            {

                MessageBox.Show("tienen que ser diferentes las fechas de comparacion");
                return;
            }

            chrt_ventas.Series[nombre_serie].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chrt_ventas.Series[nombre_serie2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            operaciones_archivos op = new operaciones_archivos();

            string[] esplitedo = { "", "" }, esplitedo2 = { "", "" }, historial, historial2;
            int cual_es_mayor = 0;
            historial = op.revicion_total(FILE_NAME);
            historial2 = op.revicion_total(FILE_NAME2);

            if (historial.Length >= historial2.Length)
            {
                cual_es_mayor = historial.Length;
            }
            else
            {
                cual_es_mayor = historial2.Length;
            }

            int cual_anotar = 0;
            for (int i = 0; i < cual_es_mayor; i++)
            {
                if (i < historial.Length)
                {
                    esplitedo = historial[i].Split(';');
                    chrt_ventas.Series[0].Points.AddXY(esplitedo[0], esplitedo[1]);
                    cual_anotar = cual_anotar + 1;
                }
                if (i < historial2.Length)
                {
                    esplitedo2 = historial2[i].Split(';');
                    chrt_ventas.Series[1].Points.AddXY(esplitedo2[0], esplitedo2[1]);
                    cual_anotar = cual_anotar + 2;
                }

                    switch (cual_anotar)
                    {
                        case 1:
                            lst_ventas.Items.Add(esplitedo[0] + ";" + esplitedo[1] + "          ");
                            break;
                        case 2:
                            lst_ventas.Items.Add("          " + esplitedo2[0] + ";" + esplitedo2[1]);
                            break;
                        case 3:
                            lst_ventas.Items.Add(esplitedo[0] + ";" + esplitedo[1] + "          " + esplitedo2[0] + ";" + esplitedo2[1]);
                            break;
                        default:
                            MessageBox.Show("error switch");
                            break;
                    }
                
                cual_anotar = 0;
            }
            esplitedo = historial[historial.Length - 1].Split(';');
            esplitedo2 = historial2[historial2.Length - 1].Split(';');

            txt_total.Text = "ventas: " + esplitedo[1];
            txt_total.Text = txt_total.Text + ";  " + "gastos: " + esplitedo2[1];
            txt_ganancia.Text = "" + (Convert.ToDouble(esplitedo[1]) - Convert.ToDouble(esplitedo2[1]));
        }

        public void grafica_horas_ganancias(string FILE_NAME, string FILE_NAME2, string nombre_serie, string nombre_serie2, int decicion = 0, bool comparacion = false)
        {

            if (comparacion == false)
            {
                chrt_ventas.Series.Clear();
            }
            try
            {
                chrt_ventas.Series.Clear();
                chrt_ventas.Series.Add(nombre_serie);
            }
            catch (Exception){}
            
            chrt_ventas.Series[nombre_serie].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            operaciones_archivos op = new operaciones_archivos();

            string[] esplitedo, historial;

            if (decicion == 0)
            {
                historial = op.revicion_total_horas(FILE_NAME);
            }
            else
            {
                historial = op.revicion_total_horas(FILE_NAME, 1);
            }

            for (int i = 0; i < historial.Length - 1; i++)
            {
                esplitedo = historial[i].Split(G_parametros);
                chrt_ventas.Series[0].Points.AddXY(esplitedo[0], esplitedo[1]);
                if (decicion == 0)
                {
                    lst_ventas.Items.Add(esplitedo[0] + G_parametros[0] + esplitedo[1]);
                }
                else
                {
                    lst_ventas.Items.Add(esplitedo[1] + ": " + esplitedo[2]);
                }
            }
            txt_total.Text = "" + historial[historial.Length - 1];
        }


        //-------------------------------------------------------------------------------------------------------------------------------------------------------

        public void combo_a(string FILE_NAME)
        {
            lbl_ganancia.Visible = false;
            txt_ganancia.Visible = false;

            string temp;
            cmb_año.Items.Clear();//limpia contenido del combo
            operaciones_archivos op = new operaciones_archivos();//op es la clase operaciones de archivos
            DateTime fecha_hora = DateTime.Now;//contiene la fecha y hora de hoy
            string[] archivos = op.revicion_total(FILE_NAME);//revisa todo el contenido del archivo
            string[] espliteado;//es una arreglo
            for (int i = 0; i < archivos.Length-1; i++)
            {
                temp = archivos[i];
                espliteado = temp.Split(';');
                cmb_año.Items.Add(espliteado[0]);
            }
        }

        public void combo_m(string FILE_NAME)
        {
            lbl_ganancia.Visible = false;
            txt_ganancia.Visible = false;

            string temp;
            cmb_mes.Items.Clear();
            operaciones_archivos op = new operaciones_archivos();
            DateTime fecha_hora = DateTime.Now;
            string[] archivos = op.revicion_total(FILE_NAME);
            string[] espliteado;
            for (int i = 0; i < archivos.Length - 1; i++)
            {
                temp = archivos[i];
                espliteado = temp.Split(';');
                cmb_mes.Items.Add(espliteado[0]);
            }
           
        }

        public void combo_d(string FILE_NAME)
        {
            lbl_ganancia.Visible = false;
            txt_ganancia.Visible = false;

            string temp;
            cmb_dia.Items.Clear();
            operaciones_archivos op = new operaciones_archivos();
            DateTime fecha_hora = DateTime.Now;
            string[] archivos = op.revicion_total(FILE_NAME);
            string[] espliteado;
            for (int i = 0; i < archivos.Length - 1; i++)
            {
                temp = archivos[i];
                espliteado = temp.Split(';');
                cmb_dia.Items.Add(espliteado[0]);
            }
        }
    }
}
