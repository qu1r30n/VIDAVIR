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
    public partial class ventana_emergente : Form
    {
        public string[] arraytextbox;
        int origen = 0;
        char[] G_parametros = { '|' };


        public  ventana_emergente()
        {
            InitializeComponent();
            arraytextbox = new string[1];
            
        }

        public void proceso_ventana_emergente(string[] nom_datos_recolectados,int modificara,char caracter_spliteo='°')
        {
            origen = modificara;
            int x = 120;
            int y = 0;
            int ancho = 100;
            int alto = 50;
            int acumleft = 0;
            int separacion_y = 15;
            int contador_en_horisontal_txtbox = 0; ;
            if (nom_datos_recolectados.Length != 0)
            {
                for (int i = 0; i < nom_datos_recolectados.Length; i++)
                {
                    Label lb = new Label();
                    TextBox txt = new TextBox();




                    if (contador_en_horisontal_txtbox <= 4)
                    {
                        lb.Top = y;
                        lb.Left = acumleft;

                        txt.Top = y + separacion_y;
                        txt.Left = acumleft;

                    }
                    else
                    {
                        contador_en_horisontal_txtbox = 0;
                        y = y + 40;
                        acumleft = 0;
                        lb.Top = y;
                        lb.Left = acumleft;

                        txt.Top = y + separacion_y;
                        txt.Left = acumleft;
                    }

                    contador_en_horisontal_txtbox = contador_en_horisontal_txtbox + 1;

                    

                    string[] espliteado = nom_datos_recolectados[i].Split(caracter_spliteo);
                    if (espliteado.Length == 2)
                    {
                        txt.Text = espliteado[1];
                        nom_datos_recolectados[i]= espliteado[0];
                    }
                    lb.Text = nom_datos_recolectados[i];

                    txt.Width = ancho;
                    txt.Height = alto;

                    lb.AutoSize = true;
                    this.Controls.Add(lb);//le agrega un indice al control para luego utilisarlo por su indise en  la funcion devolver string
                    this.Controls.Add(txt);//le agrega un indice al control para luego utilisarlo por su indise en  la funcion devolver string
                    acumleft = acumleft + x;
                }
                Button btn_aceptar = new Button();
                Button btn_cancelar = new Button();

                btn_aceptar.Width = ancho;
                btn_aceptar.Height = alto;
                btn_aceptar.Top = y+60;
                btn_aceptar.Left = x;

                btn_aceptar.Name = "btn_aceptar_1";
                btn_cancelar.Name = "btn_cancelar_1";

                btn_aceptar.Text = "aceptar";
                btn_cancelar.Text = "cancelar";
                this.Controls.Add(btn_aceptar);//le agrega un indice al control para luego utilisarlo por su indise en  la funcion devolver string
                //this.Controls.Add(btn_cancelar);

                btn_aceptar.Click += new EventHandler(devolver_string);
            }
            else { MessageBox.Show("no has puesto ningun dato"); }
        }


        private void devolver_string(object sender, EventArgs e)
        {
            int i = 0;
            tex_base bas = new tex_base();
            string temp2 = "";

            foreach (var obj in this.Controls)//checa cuantos objeto del tipo textbox  y pone el arreglo global conforme a la cantidad de textbox
            {
                if (obj is TextBox)
                {
                    arraytextbox = new string[i + 1];
                    i++;
                }
            }

            i = 0;
            foreach (var obj in this.Controls) //aqui agrega añ arreglo global "arraytextbox" la informacion
            {
                
                if (obj is TextBox)
                {
                    
                    TextBox temp = (TextBox)obj;
                    arraytextbox[i] = temp.Text;
                    temp2 = temp2 + temp.Text+G_parametros[0];
                    i++;
                }    
            }

            bas.crear_archivo_y_directorio("inf\\inventario\\cosas_no_estaban.txt");
            switch (origen)
            {
                case 0:
                    bas.agregar("inf\\inventario\\cosas_no_estaban.txt", "movimiento origen: " +origen+ G_parametros[0] + temp2);
                    break;
                case 1:
                    bas.agregar("inf\\inventario\\cosas_no_estaban.txt", "movimiento origen: " + origen + G_parametros[0] + temp2);
                    bas.agregar("inf\\inventario\\invent.txt", temp2);
                    break;
                default:
                    bas.agregar("inf\\inventario\\cosas_no_estaban.txt", "movimiento origen: " + origen + G_parametros[0] + temp2);
                    break;
            }

            this.Close();
        }
    }
}