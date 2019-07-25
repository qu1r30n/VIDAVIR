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
            decimal total = 0;
            decimal total_compra = 0;
            StreamReader sr = new StreamReader(FILE_NAME);
            while (sr.Peek() >= 0)//verificamos si hay mas lineas a leer
            {
                G_palabra = sr.ReadLine();//leemos linea y lo guardamos en palabra
                if (G_palabra != null)
                {
                    linea = G_palabra.Split(G_parametros);
                    lista.Add(linea[0] + G_parametros[0] + linea[1]);
                    total = total + Convert.ToDecimal(linea[1]);
                    total_compra = total_compra + Convert.ToDecimal(linea[2]);

                }
            }
            string[] list_string = new string[lista.Count + 1];
            for (int op = 0; op < lista.Count; op++)
            {
                list_string[op] = "" + (lista[op]);
            }
            list_string[lista.Count] = "total|" + total+ "  |total_compra|"+total_compra+"  |ganancia_real|"+(total-total_compra);
            sr.Close();
            return list_string;//devuelve la lista para ser usada
        }

        public string[] revicion_total_horas(string FILE_NAME,int decicion=0)
        {
            string[] linea;
            string union = "";
            ArrayList lista = new ArrayList();
            decimal total = 0;
            decimal total_compra = 0;
            StreamReader sr = new StreamReader(FILE_NAME);
            while (sr.Peek() >= 0)//verificamos si hay mas lineas a leer
            {
                G_palabra = sr.ReadLine();//leemos linea y lo guardamos en palabra
                if (G_palabra != null)
                {
                    linea = G_palabra.Split(G_parametros);
                    if (decicion==0)
                    {
                        lista.Add(linea[0] + G_parametros[0] + G_parametros[0] + linea[2]);
                        total = total + Convert.ToDecimal(linea[2]);
                        total_compra = total_compra + Convert.ToDecimal(linea[4]);
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
                        union = "";
                        total = total + Convert.ToDecimal(linea[2]);
                        total_compra = total_compra + Convert.ToDecimal(linea[4]);
                    }
                    
                }
            }
            string[] list_string = new string[lista.Count + 1];
            for (int op = 0; op < lista.Count; op++)
            {
                list_string[op] = "" + (lista[op]);
            }
            list_string[lista.Count] = "total|" + total + "  |total_compra|" + total_compra + "  |ganancia_real|" + (total - total_compra);
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

        public void actualisar_resumen_venta(string FILE_NAME,string fecha ,decimal precio,decimal costos_de_compra=0)
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
                    //por aqui empesamos para poderlo comparar
                    if (G_palabra != null)
                    {
                        linea = G_palabra.Split(G_parametros);

                        if (linea[0] != fecha)
                        {
                            sw.WriteLine(linea[0] + G_parametros[0] + linea[1] + G_parametros[0] + (costos_de_compra + Convert.ToDecimal(linea[2])));
                        }
                        else
                        {
                            sw.WriteLine(fecha + G_parametros[0] + (precio + Convert.ToDecimal(linea[1])) + G_parametros[0] + (costos_de_compra + Convert.ToDecimal(linea[2])));
                            bol = true;

                        }
                    }
                }
                if (bol == false)
                {
                    sw.WriteLine(fecha + G_parametros[0] + precio + G_parametros[0] + costos_de_compra);
                }
            }
            catch (Exception)
            {
                sw.WriteLine(fecha + G_parametros[0] + precio + G_parametros[0] + costos_de_compra);

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


        public void actualisar_resumen_compras(string FILE_NAME, string fecha, decimal precio)
        {
            char[] parametros2 = { '/', '\\' };
            tex_base bas = new tex_base();
            bool bol = false;
            string[] G_linea, linea, temp = { "", "" };
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
            StreamWriter sw = new StreamWriter(G_temp, true);//abrimos el archivo a escribir
            try
            {
                while (sr.Peek() >= 0)//verificamos si hay mas lineas a leer
                {
                    G_palabra = sr.ReadLine();//leemos linea y lo guardamos en palabra
                    //por aqui empesamos para poderlo comparar
                    if (G_palabra != null)
                    {
                        linea = G_palabra.Split(G_parametros);

                        if (linea[0] != fecha)
                        {
                            sw.WriteLine(linea[0] + G_parametros[0] + linea[1] );
                        }
                        else
                        {
                            sw.WriteLine(fecha + G_parametros[0] + (precio + Convert.ToDecimal(linea[1]))+G_parametros[0]+"0");
                            bol = true;

                        }
                    }
                }
                if (bol == false)
                {
                    sw.WriteLine(fecha + G_parametros[0] + precio + G_parametros[0] + "0");
                }
            }
            catch (Exception)
            {
                sw.WriteLine(fecha + G_parametros[0] + precio + G_parametros[0] + "0");

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


        public void actualisar_ganancia_real(string FILE_NAME, string fecha, decimal precio, decimal costo_compra = 0)
        {
            char[] parametros2 = { '/', '\\' };
            tex_base bas = new tex_base();
            bool bol = false;
            string[] G_linea, linea, temp = { "", "" };
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
            StreamWriter sw = new StreamWriter(G_temp, true);//abrimos el archivo a escribir
            try
            {
                while (sr.Peek() >= 0)//verificamos si hay mas lineas a leer
                {
                    G_palabra = sr.ReadLine();//leemos linea y lo guardamos en palabra
                    //por aqui empesamos para poderlo comparar
                    if (G_palabra != null)
                    {
                        linea = G_palabra.Split(G_parametros);

                        if (linea[0] != fecha)
                        {
                            sw.WriteLine(linea[0] + G_parametros[0] + linea[1]);
                        }
                        else
                        {
                            sw.WriteLine(fecha + G_parametros[0] + ((precio-costo_compra) + Convert.ToDecimal(linea[1])));
                            bol = true;

                        }
                    }
                }
                if (bol == false)
                {
                    sw.WriteLine(fecha + G_parametros[0] + (precio - costo_compra));
                }
            }
            catch (Exception)
            {
                sw.WriteLine(fecha + G_parametros[0] + (precio - costo_compra));

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

        public void actualisar_inventario(string FILE_NAME, string id_produc_act, decimal cantidad_a_act)
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
                    string temp = "";
                    G_palabra = sr.ReadLine();//leemos linea y lo guardamos en palabra
                    if (G_palabra != null)
                    {
                        linea = G_palabra.Split(G_parametros);

                        if (linea[0] != id_produc_act)
                        {
                            temp = "";
                            for (int i = 0; i < linea.Length; i++)
                            {
                                if (i < (linea.Length-1))
                                {
                                    temp = temp + linea[i] + G_parametros[0];
                                }
                                else
                                {
                                    temp = temp + linea[i];
                                }
                            }
                            sw.WriteLine(temp);
                        }
                        else
                        {
                            if (0 <= cantidad_a_act + Convert.ToDecimal(linea[4]))
                            {
                                temp = "";
                                for (int i = 0; i < linea.Length; i++)
                                {
                                    if (i < (linea.Length - 1))
                                    {
                                        if (i == 4)//la columna de cantidad de producto
                                        {
                                            temp = temp + (cantidad_a_act + Convert.ToDecimal(linea[i])) + G_parametros[0];
                                        }
                                        else
                                        {
                                            temp = temp + linea[i] + G_parametros[0];
                                        }
                                    }
                                    else
                                    {
                                        temp = temp + linea[i];
                                    }
                                }

                                sw.WriteLine(temp);
                            }
                            else
                            {

                                temp = "";
                                for (int i = 0; i < linea.Length; i++)
                                {
                                    if (i < (linea.Length - 1))
                                    {
                                        if (i == 4)//la columna de cantidad de producto
                                        {
                                            temp = temp + (cantidad_a_act + Convert.ToDecimal(linea[i])) + G_parametros[0];
                                        }
                                        else
                                        {
                                            temp = temp + linea[i] + G_parametros[0];
                                        }
                                    }
                                    else
                                    {
                                        temp = temp + linea[i];
                                    }
                                }

                                sw.WriteLine(temp);

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
                            if (0 <= Convert.ToDecimal(linea[2]))
                            {
                                decimal cant1 = Convert.ToDecimal(linea[2]);
                                decimal cant2 = Convert.ToDecimal(dat_esplit[2]);
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

        public void actualisar_costo_compra(string FILE_NAME, string id_produc_act, decimal cantidad_a_act)
        {
            int columna_modificar = 5;
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

                    string temp = "";
                    G_palabra = sr.ReadLine();//leemos linea y lo guardamos en palabra
                    if (G_palabra != null)
                    {
                        linea = G_palabra.Split(G_parametros);

                        if (linea[0] != id_produc_act)
                        {
                            temp = "";
                            for (int i = 0; i < linea.Length; i++)
                            {
                                if (i < (linea.Length - 1))
                                {
                                    temp = temp + linea[i] + G_parametros[0];
                                }
                                else
                                {
                                    temp = temp + linea[i];
                                }
                            }
                            sw.WriteLine(temp);
                        }


                        else
                        {
                            temp = "";
                            for (int i = 0; i < linea.Length; i++)
                            {
                                if (i < (linea.Length - 1))
                                {
                                    if (i == columna_modificar)//la columna de cantidad de producto
                                    {
                                        temp = temp + cantidad_a_act + G_parametros[0];//se le suma la cantidad
                                    }
                                    else
                                    {
                                        temp = temp + linea[i] + G_parametros[0];
                                    }
                                }
                                else
                                {
                                    temp = temp + linea[i];
                                }
                            }
                            sw.WriteLine(temp);
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

    }
}
