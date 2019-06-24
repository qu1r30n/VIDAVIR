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
        
        char[] G_parametros = { '|' };


        public  ventana_emergente()
        {
            InitializeComponent();
            
            
        }

        public string proceso_ventana_emergente(string[] nom_datos_recolectados, int modificara=0, string[] infoextra = null, char caracter_spliteo = '°')
        {
            string[] arraytextbox;
            arraytextbox = new string[1];
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
                btn_aceptar.DialogResult = DialogResult.OK;
                this.ShowDialog();



                //----------------------------------------------------------------------------------------------------------------------------
                if (btn_aceptar.DialogResult ==DialogResult)
                {
                    int K = 0;
                    tex_base bas = new tex_base();
                    operaciones_archivos op = new operaciones_archivos();
                    string temp2 = "";

                    foreach (var obj in this.Controls)//checa cuantos objeto del tipo textbox  y pone el arreglo global conforme a la cantidad de textbox
                    {
                        if (obj is TextBox)
                        {
                            arraytextbox = new string[K + 1];
                            K++;
                        }
                    }

                    K = 0;
                    foreach (var obj in this.Controls) //aqui agrega añ arreglo global "arraytextbox" la informacion
                    {

                        if (obj is TextBox)
                        {

                            TextBox temp = (TextBox)obj;
                            arraytextbox[K] = temp.Text;
                            temp2 = temp2 + temp.Text + G_parametros[0];
                            K++;
                        }
                    }

                    bas.crear_archivo_y_directorio("inf\\inventario\\cosas_no_estaban.txt");
                    switch (modificara)
                    {
                        case 0:
                            bas.agregar("inf\\inventario\\cosas_no_estaban.txt", "movimiento origen: " + modificara + G_parametros[0] + temp2);
                            break;
                        case 1:
                            bas.agregar("inf\\inventario\\cosas_no_estaban.txt", "movimiento origen: " + modificara + G_parametros[0] + temp2);
                            bas.agregar("inf\\inventario\\invent.txt", temp2);
                            break;
                        default:
                            bas.agregar("inf\\inventario\\cosas_no_estaban.txt", "movimiento origen: " + modificara + G_parametros[0] + temp2);
                            break;
                    }

                    this.Close();
                }
                //------------------------------------------------------------------------------------------------------------------

            }
            else { MessageBox.Show("no has puesto ningun dato"); }

            string union = "";
            if (arraytextbox[0]!=null)
            {
                for (int i = 0; i < arraytextbox.Length; i++)
                {
                    union = union + arraytextbox[i] + G_parametros[0];
                }
            }
            return union;
        }



        public static string InputBox(string title="aqui tu titulo", string promptText="aqui la pregunta", string value="aqui el valor")
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return value;
        }

    }
}