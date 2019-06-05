using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tienda
{
    class tex_base
    {
        
        string G_palabra = "", G_entrando = "", G_temp = "";
        
        char[] G_parametros = { '|' };
        string[]  G_linea, G_buscar, G_remplasar;

        public void crear_archivo_y_directorio(string FILE_NAME, string columnas=null,string valor_inicial=null)//FILE_NAME la direccion del archivo    columnas: es para crearlas y se separan la columnas por un '|' valor_inicial: no se utilisa en este programa era para poner un tipo eslogan o un titulo  pero en este programa no lo nesesite
        {
            char[] parametro2 = { '/', '\\' };//estos seran los parametros de separacion de el split
            G_entrando = "";
            string[] path = FILE_NAME.Split(parametro2);//spliteamos la direccion

            for (int i = 0; i < path.Length; i++)//pasamos por todas las los directorios y archivo
            {
                if (i < path.Length - 1)//el path muestra 6 palabras que fueron espliteadas se le resta uno por que los arreglos empiesan desde 0 y solo se le pone el menor que por que la ultima palabra es el archivo
                {
                    G_entrando = G_entrando + path[i] + "\\"; // va acumulando los directorios a los que va a entrar ejemplo: ventas\\   ventas\\2016    ventas\\2016\\        ventas\\2016\\11      ventas\\2016\\11\\dias\\  y no muestra el ultimo por que es el archivo y en el if  le dijimos que lo dejara en el penultimo
                    if (!Directory.Exists(G_entrando))//si el directorio no existe entrara y lo creara
                    {

                        Directory.CreateDirectory(G_entrando);//crea el directorio
                        
                    }
                }
            }

            if (!File.Exists(FILE_NAME))//si el archivo no existe entra y lo crea
            {
               FileStream fs0 = new FileStream(FILE_NAME, FileMode.CreateNew);//crea una variable tipo filestream "fs0"  y crea el archivo
               fs0.Close();//cierra fs0 para que se pueda usar despues

                StreamWriter sw = new StreamWriter(FILE_NAME, true);//crea una variable de tipo streamWrite para escribir en el archivo y el true es para escribir asta abajo

                if (valor_inicial != null)// si al llamar a la funcion  le pusiste valor_inicial las escribe //se utilisa para que sea como un titulo o un eslogan pero lo utilisaremos en este prog
                {
                    sw.WriteLine(valor_inicial);//escribe aqui el valor inicial si es que lo pusiste
                }

                sw.Close();//sierra el sw para ser usado despues //es importantisimo cerrarlos por que si no cierras uno  sera un relajo despues por que el debuguer no te indica donde quedo abierto
                if (columnas != null)//si al llamar a la funcion le pusistes columnas a agregar//recuerda que se separan por comas
                {
                    agregar(FILE_NAME, columnas, null);//agrega las columnas
                    columnas = null;//al terminar pone la columna denuevo a null
                }

            }
        }


        public string[] seleccionar(string FILE_NAME, string buscar0, string posiciones=null)
        {
            int cantidad = 0;
            string[] improbisado = { "" }; //improbisado eliminar este codigo
            if (posiciones != null)//si hay columnas que posiciones se van a seleccionar
            {
                ArrayList lista = new ArrayList(); //crea un array list llamado lista
                G_buscar = buscar0.Split(G_parametros);//esplitea buscar0 y lo guarda en buscar
                string [] col = convierte_nom_col_a_numeros(posiciones, FILE_NAME).Split(G_parametros);//convierte el nombre de las columnas a el numero de la posision de las columnas
                int[] col_num = new int[col.Length];//crea un array de las columnas en tipo entero con un espasio de la cantidad que se saco de la funcion convierte_nom_col_a_numeros
                for (int opa = 0; opa < col.Length; opa++)//convierte todos los numeros de la columna a enteros por que estaban en string
                {
                    col_num[opa] = Convert.ToInt32(col[opa]);//convierte la celda a entero y lo guarda
                }
                
                    StreamReader sr = new StreamReader(FILE_NAME);//abre el archivo de la ruta puesta
                try
                {
                    while (sr.Peek() >= 0)//verifica si ya termino de leer las lineas del archivo
                    {
                        G_linea = sr.ReadLine().Split(G_parametros);//lee una linea del archivo y lo esplitea

                        for (int j = 0; j < G_buscar.Length; j++)//el for de buscar
                        {

                            for (int i = 0; i < posiciones.Length; i++)//el for de linea
                            {
                                if (G_linea[col_num[i]] == G_buscar[j])//si buscar es igual a linea
                                {
                                    cantidad = cantidad + 1;//le suma uno a cantidad 
                                    break;//y termina el proceso del for de la linea para que cambie al siguiente  bus dato a buscar si hay varios
                                }
                            }
                        }

                        if (cantidad == G_buscar.Length)//si cantidad es igual a la cantidad de datos a buscar
                        {
                            foreach (string item2 in G_linea)//pasa por todas las celdas de linea
                            {
                                G_palabra = G_palabra + item2 + G_parametros[0]; //y las guarda en un string llamado palabra
                            }
                            lista.Add(G_palabra);//lo aggrega en una fila del arraylist lista
                        }
                        cantidad = 0;//lo vuelve cero para cuando cambie de linea en el archibo no se convine con los datos anteriores
                    }

                   

                }
                catch (Exception )
                {

                }
                sr.Close();//cierra stringread
                string[] list_string = new string[lista.Count];//crea un array tipo string y le crea la cantidad de espacios que tiene lista
                for (int op = 0; op < list_string.Length; op++)//pasa del arraylist a array tipo string todo lo que esta dentro del for 
                {
                    list_string[op] = "" + (lista[op]);
                }
                return list_string;//devuelve la lista para ser usada
            }


            else { 
                ArrayList lista = new ArrayList();
                G_buscar = buscar0.Split(G_parametros[0]);//esplitea buscar0 y lo guarda en buscar
                try
                {
                    StreamReader sr = new StreamReader(FILE_NAME);//abre el archivo de la ruta puesta
                    while (sr.Peek() >= 0)//verifica si ya termino de leer las lineas del archivo
                    {
                        G_linea = sr.ReadLine().Split(G_parametros[0]);//lee una linea del archivo y lo esplitea

                        for (int j = 0; j < G_buscar.Length; j++)//el for de buscar
                        {

                            for (int i = 0; i < G_linea.Length; i++)//el for de linea
                            {
                                if (G_linea[i] == G_buscar[j])//si buscar es igual a linea
                                {
                                    cantidad = cantidad + 1;//le suma uno a cantidad 
                                    break;//y termina el proceso del for de la linea para que cambie al siguiente  bus dato a buscar si hay varios
                                }
                            }
                        }
                        if (cantidad == G_buscar.Length)//si cantidad es igual a la cantidad de datos a buscar
                        {
                            foreach (string item2 in G_linea)//pasa por todas las celdas de linea
                            {
                                G_palabra = G_palabra + item2 + G_parametros[0]; //y las guarda en un string llamado palabra
                            }
                            lista.Add(G_palabra);//lo aggrega en una fila del arraylist lista
                        }
                        cantidad = 0;//lo vuelve cero para cuando cambie de linea en el archibo no se convine con los datos anteriores
                    }

                    sr.Close();//cierra stringread

                }
                catch (Exception )
                {

                }
                string[] list_string = new string[lista.Count];
                for (int op = 0; op < list_string.Length; op++)
                {
                    list_string[op] = "" + (lista[op]);
                }
                return list_string;//devuelve la lista para ser usada
            }
        }

        public string editar(string FILE_NAME, string buscar0, string remplasar0,string posiciones=null)
        {

            int cont=0;
            
                if (posiciones!=null)
                {
                    posiciones = convierte_nom_col_a_numeros(posiciones, FILE_NAME);
                }
                string [] pos_str = posiciones.Split(G_parametros);
                int[] pos_in = new int[pos_str.Length];
               
                for (int kl = 0; kl < pos_in.Length; kl++)
                {
                    pos_in[kl] = Convert.ToInt32(pos_str[kl]);
                }
                G_buscar = buscar0.Split(G_parametros);//espliteamos la busqueda
                G_remplasar = remplasar0.Split(G_parametros);//esplitemos remplasar
                G_linea = FILE_NAME.Split('\\');//esplitea la direccion
                G_temp = G_linea[0];//temp es igual al primer directorio
                for (int i = 1; i < G_linea.Length; i++)//checa si es el ultimo directorio 
                {
                    if (i == G_linea.Length - 1)//si llego al archivo le va a colocar un temp_ y el nombre del archivo
                    {
                        G_linea[i] = "temp_" + G_linea[i];
                    }
                    G_temp = G_temp + "\\" + G_linea[i];//le pone la barrita para pasarselo a la funcion de crear achivos
                }
                crear_archivo_y_directorio(G_temp);//creamos el archivo temporal

                StreamReader sr = new StreamReader(FILE_NAME);//abrimos el archivo a leer
                StreamWriter sw = new StreamWriter(G_temp);//abrimos el archivo a escribir
            try { 
                string[] temp = new string[G_buscar.Length];
                while (sr.Peek() >= 0)//verificamos si hay mas lineas a leer
                {
                    
                    G_palabra = sr.ReadLine();//leemos linea y lo guardamos en palabra
                    G_linea = G_palabra.Split(G_parametros);//palabra la spliteamos y la guardamos en linea
                    if (G_palabra != "")//si palabra es "" se salta todo el proceso por que no se por que aparecen varios con ""
                    {
                        if (posiciones != null)
                        {
                            cont = 0;
                            for (int i = 0; i < G_buscar.Length; i++)//igual recorremos busqueda
                            {
                                for (int j = 0; j < G_buscar.Length; j++)//recorremos linea
                                {
                                    if (G_linea[pos_in[j]] == G_buscar[i])//si linea y busqueda son iguales
                                    {
                                        cont = cont + 1;
                                        if (cont == G_buscar.Length)
                                        {
                                            for (int pl = 0; pl < G_buscar.Length; pl++)
                                            {
                                                G_linea[pos_in[pl]] = G_remplasar[pl];//remplasamos la palabra de linea de su posision
                                            }




                                            G_palabra = "";
                                            for (int z = 0; z < G_linea.Length; z++)
                                            {
                                              
                                                if (z < G_linea.Length - 1)
                                                {
                                                    G_palabra = G_palabra + G_linea[z] + G_parametros[0];
                                                }
                                                else
                                                {
                                                    G_palabra = G_palabra + G_linea[z];
                                                }

                                            }
                                        }
                                    }
                                }
                            }
                        }

                        else
                        {
                            for (int i = 0; i < G_buscar.Length; i++)//igual recorremos linea
                            {
                                for (int j = 0; j < G_linea.Length; j++)//recorremos busqueda
                                {
                                    if (G_linea[j] == G_buscar[i])//si linea y busqueda son iguales
                                    {
                                        G_linea[j] = G_remplasar[i];//remplasamos la palabra de linea de su posision
                                        G_palabra = "";
                                        for (int kl = 0; kl < G_linea.Length; kl++)
                                        {
                                            if (kl < G_linea.Length - 1)
                                            {
                                                G_palabra = G_palabra + G_linea[kl] + G_parametros[0];
                                            }
                                            else
                                            {
                                                G_palabra = G_palabra + G_linea[kl];
                                            }
                                        }



                                    }
                                }
                            }
                        }
                        sw.WriteLine(G_palabra);//escribimos en el ARCHIVO TEMPORAL
                    }
                }

                sw.Close();//cerramos el archivo de escritura que es EL TEMPORAL
                sr.Close();//cerramos el archivo de lectura
                File.Delete(FILE_NAME);//borramos el archivo original
                File.Move(G_temp, FILE_NAME);//renombramos el archivo temporal por el que tenia el original
            }

            catch (Exception e)
            {
                sw.Close();//cerramos el archivo de escritura que es EL TEMPORAL
                sr.Close();//cerramos el archivo de lectura
                return "ERROR: " + e;
            }
            sw.Close();//cerramos el archivo de escritura que es EL TEMPORAL
            sr.Close();//cerramos el archivo de lectura
            return "se remplaso " + buscar0 + " por " + remplasar0;//retornamos que todo fue un exito
        }


        public string agregar(string FILE_NAME, string agregando, string posisiones=null)
        {

            string[] columna, resultado, temp = { "" };
            if (posisiones != null)
            {
                columna = leer_columnas(FILE_NAME);
                resultado = new string[columna.Length];
            }
            else
            {

                columna = leer(FILE_NAME, null, "");
                resultado = new string[columna.Length];
            }


            string[] agreg_spl = agregando.Split(G_parametros);

            agregando = "";

            if (posisiones != null)
            {
                posisiones=convierte_nom_col_a_numeros(posisiones, FILE_NAME);
                string[] pos_spli = posisiones.Split(G_parametros);
                try
                {
                    int[] pos_ent = new int[pos_spli.Length];//declara pos_ent CON LA CANTIDAD Length DE POS_SPLIT
                    

                    for (int i = 0; i < pos_spli.Length; i++)
                    {
                        pos_ent[i] = Convert.ToInt32(pos_spli[i]);//SI NO LO CONVIERTE EN ENTERO SE VA AL CATCH
                    }

                    for (int i = 0; i < pos_ent.Length; i++)
                    {
                        for (int j = 0; j < columna.Length; j++)
                        {
                            if (pos_ent[i] == j)
                            {
                                resultado[j] = agreg_spl[i];
                            }
                            else
                            {
                                if (resultado[j] == null)
                                {
                                    resultado[j] = "0";
                                }
                            }
                        }
                    }
                    for (int k = 0; k < resultado.Length; k++)
                    {
                        if (k < resultado.Length - 1)
                        {
                            agregando = agregando + resultado[k] + G_parametros[0];
                        }
                        else
                        {
                            agregando = agregando + resultado[k];
                        }
                    }
                }
                #region (no se utilisa) era para comparara las columnas por su nombre
                catch (Exception)
                {
                    
                    return "error de columna";
                    /*                    for (int i = 0; i < pos_spli.Length; i++)
                                        {
                                            for (int j = 0; j < columna.Length; j++)
                                            {
                                                if (columna[j] == pos_spli[i])
                                                {
                                                    resultado[j] = agreg_spl[cont];
                                                    cont++;//no se si lleva este o otro
                                                }
                                                else
                                                {
                                                    if (resultado[j] == null)
                                                    {
                                                        resultado[j] = "0";
                                                    }
                                                }

                                            }
                                        }
                                        */
                }
                #endregion
            }
            else
            {
                for (int kok = 0; kok < agreg_spl.Length; kok++)
                {
                    if (kok < agreg_spl.Length - 1)
                    {
                        agregando = agregando + agreg_spl[kok] + G_parametros[0];
                    }
                    else
                    {
                        agregando = agregando + agreg_spl[kok];
                    }
                }
            }

            StreamWriter sw = new StreamWriter(FILE_NAME, true);

            sw.WriteLine(agregando);
            sw.Close();
            return "agregado: " + agregando;
        }


        public string eliminar(string FILE_NAME, string buscar)
        {
            bool bandera = true;
            G_linea = FILE_NAME.Split('\\');
            G_temp = G_linea[0];
            for (int i = 1; i < G_linea.Length; i++)
            {
                if (i == G_linea.Length - 1)
                {
                    G_linea[i] = "temp_" + G_linea[i];
                }
                G_temp = G_temp + "\\" + G_linea[i];
            }
            crear_archivo_y_directorio(G_temp);

            StreamReader sr = new StreamReader(FILE_NAME);
            StreamWriter sw = new StreamWriter(G_temp, true);
            int cont=0;
            while (sr.Peek() >= 0)
            {
                cont++;
                G_palabra = sr.ReadLine();
                if (G_palabra != "")
                {
                    G_linea = G_palabra.Split(G_parametros);

                    for (int i = 0; i < G_linea.Length; i++)
                    {
                        
                        if (G_linea[i] == buscar)
                        {
                            bandera = false;
                        }

                    }
                    if (bandera)
                    {
                        sw.WriteLine(G_palabra);
                        
                    }
                    bandera = true;

                }

            }
            sw.Close();
            sr.Close();
            try
            {
                File.Delete(FILE_NAME);
                File.Move(G_temp, FILE_NAME);
            }
            catch { }
            return buscar;
        }

        public string[] leer_columnas(string FILE_NAME)
        {
            string[] linea,tem= {""};
            StreamReader sr = new StreamReader(FILE_NAME);

            G_palabra = sr.ReadLine();
            try
            {
                linea = G_palabra.Split(G_parametros);
            }
            catch (Exception)
            {
                linea =tem;
            }
            

            sr.Close();

            return linea;
        }


        public string[] leer(string FILE_NAME, string pos_string=null,string separador=null)
        {
            ArrayList linea = new ArrayList();
            ArrayList resultado = new ArrayList();
            string[] pos_split;
            int[] posiciones;

            StreamReader sr = new StreamReader(FILE_NAME);

            if (pos_string == null)
            {
                
                while ((G_palabra = sr.ReadLine()) != null)
                {
                    if (G_palabra != "")
                    {
                        linea.Add(G_palabra);
                    }
                }
            }

            else
            {
                pos_split = pos_string.Split(G_parametros);
                posiciones = new int[pos_split.Length];
                for (int i = 0; i < posiciones.Length; i++)
                {
                    posiciones[i] = Convert.ToInt32(pos_split[i]);
                }

                for (int i = 0; (G_palabra = sr.ReadLine()) != null; i++)
                {
                    string[] spl_linea = G_palabra.Split(G_parametros);

                    G_palabra = "";
                    for (int j = 0; j < posiciones.Length; j++)
                    {
                        if (j < posiciones.Length - 1)
                        {
                            G_palabra = G_palabra + spl_linea[posiciones[j]] + separador;
                        }
                        else
                        {
                            G_palabra = G_palabra + spl_linea[posiciones[j]];
                        }

                    }
                    resultado.Add(G_palabra);
                }
                sr.Close();
                string[] t = new string[resultado.Count];
                for (int mnm = 0; mnm < resultado.Count; mnm++)
                {
                    t[mnm]=""+resultado[mnm];
                }
                return t;
            }
            sr.Close();
            string[] t2 = new string[linea.Count];
            for (int mnm = 0; mnm < linea.Count; mnm++)
            {
                t2[mnm] = "" + linea[mnm];
            }
            return t2;
        }

        public string convierte_nom_col_a_numeros(string nom_columnas, string FILE_NAME)
        {
            bool decicion = false;
            string result = "";
            string[] cantidad = leer_columnas(FILE_NAME);
            string[] col_spli = nom_columnas.Split(G_parametros);
            leer_columnas(FILE_NAME);

            for (int z = 0; z < col_spli.Length; z++)
            {
                for (int y = 0; y < cantidad.Length; y++)
                {
                    if (cantidad[y] == col_spli[z])
                    {
                        if (z < col_spli.Length - 1) //sele pone coma mientras no sea el ultimo
                        {
                            result = result + y + G_parametros[0];
                            decicion = true;
                        }
                        else//si es el ultimo no se le pone coma
                        {
                            result = result + y;
                            decicion = true;
                        }

                    }
                }
                if (decicion == false)
                {
                    int temp = Convert.ToInt32(col_spli[z]);
                    for (int y = 0; y < cantidad.Length; y++)
                    {
                        if (temp == y)
                        {
                            if (z < col_spli.Length - 1) //sele pone coma mientras no sea el ultimo
                            {
                                result = result + y + G_parametros[0];
                                decicion = true;
                            }
                            else//si es el ultimo no se le pone coma
                            {
                                result = result + y;
                                decicion = true;
                            }
                        }
                    }

                }
                if (decicion == false)
                {
                    return "error_columna";
                }
                decicion = false;
            }


            return result;//editar
        }

    }
}