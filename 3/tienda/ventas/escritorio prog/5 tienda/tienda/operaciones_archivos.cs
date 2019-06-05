using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace tienda
{
    class operaciones_archivos
    {
        static public string direccion_programa = System.Windows.Forms.Application.ExecutablePath.ToString();

        string G_palabra = "",G_temp = "";
        char[] G_parametros = { '|' };


        public string[] revicion_total(string FILE_NAME)
        {
            string[] linea;
            ArrayList lista = new ArrayList();
            double total = 0;
            StreamReader sr = new StreamReader(FILE_NAME);
            while (sr.Peek() >= 0)//verificamos si hay mas lineas a leer
            {
                G_palabra = sr.ReadLine();//leemos linea y lo guardamos en palabra
                if (G_palabra != null)
                {
                    linea = G_palabra.Split(';');
                    lista.Add(linea[0] + ";" + linea[1]);
                    total = total + Convert.ToDouble(linea[1]);
                }
            }
            string[] list_string = new string[lista.Count + 1];
            for (int op = 0; op < lista.Count; op++)
            {
                list_string[op] = "" + (lista[op]);
            }
            list_string[lista.Count] = "total;" + total;
            sr.Close();
            return list_string;//devuelve la lista para ser usada
        }

        public string[] revicion_total_horas(string FILE_NAME,int decicion=0)
        {
            string[] linea;
            string union = "";
            ArrayList lista = new ArrayList();
            double total = 0;
            StreamReader sr = new StreamReader(FILE_NAME);
            while (sr.Peek() >= 0)//verificamos si hay mas lineas a leer
            {
                G_palabra = sr.ReadLine();//leemos linea y lo guardamos en palabra
                if (G_palabra != null)
                {
                    linea = G_palabra.Split(G_parametros);
                    if (decicion==0)
                    {
                        lista.Add(linea[0] + G_parametros[0] + linea[2]);
                        total = total + Convert.ToDouble(linea[2]);
                    }
                    else
                    {
                        for (int i = 0; i < linea.Length; i++)
                        {
                            if (i<linea.Length-1)
                            {
                                union = union + linea[i] + G_parametros[0];
                            }
                            else
                            {
                                union = union + linea[i];
                            }
                            
                        }
                        lista.Add(union);
                        total = total + Convert.ToDouble(linea[1]);
                    }
                    
                }
            }
            string[] list_string = new string[lista.Count + 1];
            for (int op = 0; op < lista.Count; op++)
            {
                list_string[op] = "" + (lista[op]);
            }
            list_string[lista.Count] = "total;" + total;
            sr.Close();
            return list_string;//devuelve la lista para ser usada
        }

        public string[] contenido_directorio(string FILE_NAME,string decicion=null)
        {
            ArrayList lista = new ArrayList();
            DirectoryInfo di = new DirectoryInfo(FILE_NAME);

            if (decicion==null)
            {
                foreach (var fi in di.GetFiles())
                {
                    lista.Add("" + fi);
                }
            }

            else
            {
                foreach (var fi in di.GetFiles(FILE_NAME))
                {
                    lista.Add("" + fi);
                }
            }

            string[] list_string = new string[lista.Count];
            for (int op = 0; op < lista.Count; op++)
            {
                list_string[op] = "" + (lista[op]);
            }

            return list_string;//devuelve la lista para ser usada
        }

        public void actualisar_resumen_venta(string FILE_NAME,string fecha ,double precio)
        {
            char[] parametros2 = { '/', '\\' };
            tex_base bas = new tex_base();
            bool bol=false;
            string[] G_linea,linea, temp = { "", "" };
            G_linea = FILE_NAME.Split(parametros2);//esplitea la direccion
            G_temp = G_linea[0];//temp es igual al primer directorio
            bas.crear_archivo_y_directorio(FILE_NAME);
            for (int i = 1; i < G_linea.Length; i++)//checa si es el ultimo directorio 
            {
                if (i == G_linea.Length - 1)//si llego al archivo le va a colocar un temp_ y el nombre del archivo
                {
                    G_linea[i] = "temp_" + G_linea[i];
                }
                G_temp = G_temp + "\\" + G_linea[i];//le pone la barrita para pasarselo a la funcion de crear achivos
            }
            bas.crear_archivo_y_directorio(G_temp);//creamos el archivo temporal

            StreamReader sr = new StreamReader(FILE_NAME);//abrimos el archivo a leer
            StreamWriter sw = new StreamWriter(G_temp,true);//abrimos el archivo a escribir
            try
            {
                while (sr.Peek() >= 0)//verificamos si hay mas lineas a leer
                {
                    G_palabra = sr.ReadLine();//leemos linea y lo guardamos en palabra
                    if (G_palabra != null)
                    {
                        linea = G_palabra.Split(';');

                        if (linea[0] != fecha)
                        {
                            sw.WriteLine(linea[0] + ";" + linea[1]);
                        }
                        else
                        {
                            sw.WriteLine(fecha + ";" + (precio + Convert.ToDouble(linea[1])));
                            bol = true;

                        }
                    }
                }
                if (bol == false)
                {
                    sw.WriteLine(fecha + ";" + precio);
                }
            }
            catch (Exception)
            {
                sw.WriteLine(fecha + ";" + precio);

            }
            
            sr.Close();
            sr.Dispose();
            sw.Close();
            sw.Dispose();
            Thread.Sleep(20);
            File.Delete(FILE_NAME);//borramos el archivo original
            Thread.Sleep(20);
            File.Move(G_temp, FILE_NAME);//renombramos el archivo temporal por el que tenia el original
        }
        
        public void actualisar_inventario(string FILE_NAME, string fecha, double precio)
        {
            tex_base bas = new tex_base();
            string[] G_linea, linea;
            G_linea = FILE_NAME.Split('\\');//esplitea la direccion
            G_temp = G_linea[0];//temp es igual al primer directorio
            bas.crear_archivo_y_directorio(FILE_NAME);
            for (int i = 1; i < G_linea.Length; i++)//checa si es el ultimo directorio 
            {
                if (i == G_linea.Length - 1)//si llego al archivo le va a colocar un temp_ y el nombre del archivo
                {
                    G_linea[i] = "temp_" + G_linea[i];
                }
                G_temp = G_temp + "\\" + G_linea[i];//le pone la barrita para pasarselo a la funcion de crear achivos
            }
            bas.crear_archivo_y_directorio(G_temp);//creamos el archivo temporal

            StreamReader sr = new StreamReader(FILE_NAME);//abrimos el archivo a leer
            StreamWriter sw = new StreamWriter(G_temp, true);//abrimos el archivo a escribir
            try
            {
                while (sr.Peek() >= 0)//verificamos si hay mas lineas a leer
                {
                    G_palabra = sr.ReadLine();//leemos linea y lo guardamos en palabra
                    if (G_palabra != null)
                    {
                        linea = G_palabra.Split(G_parametros);

                        if (linea[0] != fecha)
                        {
                            sw.WriteLine(linea[0] + G_parametros[0] + linea[1] + G_parametros[0] + linea[2] + G_parametros[0] + linea[3]);
                        }
                        else
                        {
                            if (0 <= precio + Convert.ToDouble(linea[3]))
                            {
                                sw.WriteLine(fecha + G_parametros[0] + linea[1] + G_parametros[0] + linea[2] + G_parametros[0] + (precio + Convert.ToDouble(linea[3])));
                            }
                            else
                            {
                                sw.WriteLine(fecha + G_parametros[0] + linea[1] + G_parametros[0] + linea[2] + G_parametros[0] + linea[3]);
                                System.Windows.Forms.MessageBox.Show("ya se acabo o falta poco para acabarse el producto: " + linea[1]);
                            }

                        }
                    }
                }
            }
            catch (Exception e)
            {
                
            }
            
            sr.Close();
            sw.Close();
            Thread.Sleep(1);
            File.Delete(FILE_NAME);//borramos el archivo original
            Thread.Sleep(1);
            File.Move(G_temp, FILE_NAME);//renombramos el archivo temporal por el que tenia el original
        }

        public void actualisar_pedido(string FILE_NAME, string DATOS)
        {

            dat_comp.bandera = false;
            tex_base bas = new tex_base();
            string[] G_linea, linea,dat_esplit=DATOS.Split(G_parametros);
            G_linea = FILE_NAME.Split('\\');//esplitea la direccion
            G_temp = G_linea[0];//temp es igual al primer directorio
            bas.crear_archivo_y_directorio(FILE_NAME);
            for (int i = 1; i < G_linea.Length; i++)//checa si es el ultimo directorio 
            {
                if (i == G_linea.Length - 1)//si llego al archivo le va a colocar un temp_ y el nombre del archivo
                {
                    G_linea[i] = "temp_" + G_linea[i];
                }
                G_temp = G_temp + "\\" + G_linea[i];//le pone la barrita para pasarselo a la funcion de crear achivos
            }
            bas.crear_archivo_y_directorio(G_temp);//creamos el archivo temporal

            StreamReader sr = new StreamReader(FILE_NAME);//abrimos el archivo a leer
            StreamWriter sw = new StreamWriter(G_temp, true);//abrimos el archivo a escribir
            try
            {
                while (sr.Peek() >= 0)//verificamos si hay mas lineas a leer
                {
                    G_palabra = sr.ReadLine();//leemos linea y lo guardamos en palabra
                    
                    if (G_palabra != null)
                    {
                        linea = G_palabra.Split(G_parametros);

                        if (linea[1] != dat_esplit[1])
                        {
                            sw.WriteLine(linea[0] + G_parametros + linea[1] + G_parametros + linea[2]);
                        }
                        else
                        {
                            if (0 <= Convert.ToDouble(linea[2]))
                            {
                                double cant1 = Convert.ToDouble(linea[2]);
                                double cant2 = Convert.ToDouble(dat_esplit[2]);
                                sw.WriteLine(linea[0] + G_parametros[0] + linea[1] + G_parametros[0] + (cant1+cant2));
                                dat_comp.bandera = true;
                            }
                            else
                            {
                                sw.WriteLine(linea[0] + G_parametros + linea[1] + G_parametros + linea[2]);
                                System.Windows.Forms.MessageBox.Show("ya se acabo o falta poco para acabarse el producto: " + linea[0]+ G_parametros[0] + linea[1]);
                            }

                        }
                    }
                }
                

            }
            catch (Exception e)
            {

            }

            sr.Close();
            sw.Close();
            Thread.Sleep(1);
            File.Delete(FILE_NAME);//borramos el archivo original
            Thread.Sleep(1);
            File.Move(G_temp, FILE_NAME);//renombramos el archivo temporal por el que tenia el original
        }

        public void ExecuteCommand(string _Command)
        {
            //Indicamos que deseamos inicializar el proceso cmd.exe junto a un comando de arranque. 
            //(/C, le indicamos al proceso cmd que deseamos que cuando termine la tarea asignada se cierre el proceso).
            //Para mas informacion consulte la ayuda de la consola con cmd.exe /? 
            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", "/c " + _Command);

            procStartInfo.RedirectStandardOutput = true;// Indicamos que la salida del proceso se redireccione en un Stream
            procStartInfo.UseShellExecute = false;

            procStartInfo.CreateNoWindow = false;//Indica que el proceso no despliegue una pantalla negra (El proceso se ejecuta en background)

            System.Diagnostics.Process proc = new System.Diagnostics.Process();//Inicializa el proceso
            proc.StartInfo = procStartInfo;
            proc.Start();

            string result = proc.StandardOutput.ReadToEnd(); //Consigue la salida de la Consola(Stream) y devuelve una cadena de texto

        }

        public void respaldos_ventas(string direccion_a_copiar, string direccion_a_pegar, bool copiar_sub_directorios)
        {

            //Now Create all of the directories

            string[] direccion_carpeta = Directory.GetDirectories(direccion_a_copiar, "*", SearchOption.AllDirectories);

            if (0 != direccion_carpeta.Length)
            {
                for (int i = 0; i < direccion_carpeta.Length; i++)
                {
                    Directory.CreateDirectory(direccion_carpeta[i].Replace(direccion_a_copiar, direccion_a_pegar));
                }
            }
            else
            {
                Directory.CreateDirectory(direccion_a_pegar);
            }
            //Copy all the files & Replaces any files with the same name
            string[] newPath = Directory.GetFiles(direccion_a_copiar, "*.*", SearchOption.AllDirectories);

            for (int i = 0; i < newPath.Length; i++)
            {
                File.Copy(newPath[i], newPath[i].Replace(direccion_a_copiar, direccion_a_pegar), true);
            }
        }

        public void respaldo_inventario(string direccion_a_copiar, string direccion_a_pegar)
        {
            //Now Create all of the directories

            string [] direccion_carpeta = Directory.GetDirectories(direccion_a_copiar, "*", SearchOption.AllDirectories);

            if (0!=direccion_carpeta.Length)
            {
                for (int i = 0; i < direccion_carpeta.Length; i++)               
                {
                    Directory.CreateDirectory(direccion_carpeta[i].Replace(direccion_a_copiar, direccion_a_pegar));
                }
            }
            else
            {
                Directory.CreateDirectory(direccion_a_pegar + "\\respaldo\\inf\\inventario");
            }
            //Copy all the files & Replaces any files with the same name
            string []newPath = Directory.GetFiles(direccion_a_copiar, "*.*", SearchOption.AllDirectories);

            for (int i = 0; i < newPath.Length; i++)
            {
                File.Copy(newPath[i], newPath[i].Replace(direccion_a_copiar, direccion_a_pegar), true);
            }
        }

        public void eliminar_carpeta(string direccion)
        {
            try
            {
                Directory.Delete(direccion, true);
            }
            catch (Exception)
            {

            }
            
        }

        public void pedido (string FILE_NAME,string[]agregar)
        {
            tex_base bas = new tex_base();
            operaciones_archivos op = new operaciones_archivos();
            bas.crear_archivo_y_directorio(FILE_NAME);

            for (int i = 0; i < agregar.Length; i++)
            {
                op.actualisar_pedido(FILE_NAME, agregar[i]);
                if (!dat_comp.bandera)
                {
                    bas.agregar(FILE_NAME, agregar[i]);
                }
            }
        }
    }
}
