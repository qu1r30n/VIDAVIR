package model


import android.content.Context
import android.widget.Toast
import operadores_extra_globales.var_glob
import java.io.File
import androidx.appcompat.app.AppCompatActivity


class base
{
    fun crear_archivo_directorio(direccion_archivo: String)
    {

        val arc=File(direccion_archivo).createNewFile()
        /*
        //direccion directorios

        var carpetas = ""
        val temp = direccion_archivo.split("/")
        for (i in temp.indices)
        {
            if (i.equals(temp.size - 1))
            {
                break
            }
            carpetas = carpetas + temp[i] + "/"
        }

        //direccion carpetas
        val direcccion_carpetas = File(carpetas)
        direcccion_carpetas.mkdirs()

        val archivo = File(direccion_archivo)

        // create a new file
        val fos : FileOutputStream = FileOutputStream(direccion_archivo)
        val tex1="hola por enesima ves".toCharArray()
        var acum=""
        for (temp in tex1)
        {
            acum=acum+temp.toInt()
        }
        fos.write(acum.toInt())
        /*val fue_creado: Boolean = archivo.createNewFile()
        if (fue_creado)
        {
            println(direccion_archivo + "  is created successfully.")
        }
        else
        {
            println(direccion_archivo + " already exists.")
        }
        */
        */
    }


    fun leer(parametros: String, valor_espliteo: String = "¬"): String
    {
        //espliteado[0] direccion archivo
        //espliteado[1] orden en el que se van a mostrar
        val glob = var_glob()
        val espliteado = parametros.split(valor_espliteo)
        val direccion = espliteado[0]
        val orden = espliteado[1]
        val contenido = File(direccion).readLines()

        var contenido_texto = ""
        if (espliteado.size >= 2)
        {
            //variabla G_valor_espliteo[1] ="|" espliteado[1] ordenado
            val orden_espliteado = orden.split(glob.G_valor_espliteo[1])
            for (lineas in contenido)
            {
                //variabla G_valor_espliteo[1] ="|"
                val columnas = lineas.split(glob.G_valor_espliteo[1])
                for (indice in orden_espliteado.indices)
                {
                    if (indice.equals(orden_espliteado.size - 1))
                    {
                        contenido_texto = contenido_texto + columnas[orden_espliteado[indice].toInt()] + "\n"
                    }
                    else
                    {
                        contenido_texto = contenido_texto + columnas[orden_espliteado[indice].toInt()] + "|"
                    }
                }
            }
        }
        else
        {
            for (lineas in contenido)
            {
                contenido_texto = contenido_texto + lineas + "\n"
            }
        }
        return contenido_texto
    }

    fun seleccionar(parametros: String, valor_espliteo: String = "¬"): String {
        //0) id|1) producto|2) costo|3) codigo de barras|4) catidad|5) costo de compra|6) marca|7)

        //espliteado[0]=direccion
        //espliteado[1]=columna a comparar
        //espliteado[2]= texto con el que se va a comparar
        //espliteado[3]= que columan va a retornar


        val glob = var_glob()
        val espliteado = parametros.split(valor_espliteo)
        val direccion = espliteado[0]
        val columna_a_comparar = espliteado[1].toInt()
        val comparar = espliteado[2]
        val colum_retornara = espliteado[3].split(glob.G_valor_espliteo[1])
        val contenido = File(direccion).readLines()
        var contenido_texto = ""

        //saca toda la fila del archivo
        for (lineas in contenido) {
            //variabla G_valor_espliteo[1] ="|"
            val columnas = lineas.split(glob.G_valor_espliteo[1])
            //saca cada columna en indice
            for (indice in columnas.indices) {
                //se compara solo la columna deceada y se compara el texto dentro de la celda
                if (indice.equals(columna_a_comparar) && comparar == columnas[indice]) {
                    //se guardan todos las columnas que se van a retornar
                    for (celda in colum_retornara) {
                        contenido_texto = contenido_texto + columnas[celda.toInt()] + glob.G_valor_espliteo[1]
                    }
                    contenido_texto = contenido_texto + "\n"//termina la fila y agrega una nueva
                }
            }
        }
        //retorna las columnas seleccionadas
        return contenido_texto
    }

    fun editar(parametros: String, valor_espliteo: String = "¬"): String
    {
        //espliteado[0]=direccion
        //espliteado[1]=columna a comparar
        //espliteado[2]=texto con el que se va a comparar
        //espliteado[3]=que columan va a editar
        //espliteado[4]=texto que va a editar

        val glob = var_glob()
        val espliteado = parametros.split(valor_espliteo)
        val direccion = espliteado[0]
        val columna_a_comparar = espliteado[1].toInt()
        val comparar = espliteado[2]
        //numero de columna que editara
        val num_coumna_editar = espliteado[3].split(glob.G_valor_espliteo[1])
        //numero de columna que editara
        val tex_coumna_editar = espliteado[4].split(glob.G_valor_espliteo[1])
        val archivo = File(direccion)
        val contenido = archivo.readLines()
        var contenido_total_retornar = ""

        var cont_lineas = 0
        //saca toda la fila del archivo  estamos en proceso de BUSQUEDA PARA COMPARAR
        for (A_lineas in contenido)
        {
            var contenido_linea_retoranar = ""
            //variabla G_valor_espliteo[1] ="|"
            val columnas_archivo = A_lineas.split(glob.G_valor_espliteo[1])
            var bandera2 = 0
            var cont_A_columna = 0
            //saca cada A_columna de la fila estamos en proceso de BUSQUEDA PARA COMPARAR
            for (A_columna in columnas_archivo)
            {
                //compara num col y contenido si encuentra el buscado borra  contenido_linea_retornara y empesara a guardar
                if (cont_A_columna == columna_a_comparar && comparar == columnas_archivo[cont_A_columna])
                {
                    contenido_linea_retoranar = ""
                    bandera2 = 1
                    var cont_A_dato_archivo = 0
                    //saca contenido la A_columna del archivo
                    for (A_dato_archivo in columnas_archivo)
                    {
                        var bandera = 0
                        var cont_A_num_a_modificar = 0
                        //saca numero A_columna a editar
                        for (A_num_a_modificar in num_coumna_editar)
                        {
                            //compara el numero a modificar con en el numero de celda que va
                            if (cont_A_dato_archivo == A_num_a_modificar.toInt() && bandera != 2)
                            {
                                if (cont_A_dato_archivo < columnas_archivo.size - 1)
                                {
                                    //modifica con el texto
                                    contenido_linea_retoranar = contenido_linea_retoranar + tex_coumna_editar[cont_A_num_a_modificar] + glob.G_valor_espliteo[1]
                                }
                                else
                                {
                                    //modifica con el texto
                                    contenido_linea_retoranar = contenido_linea_retoranar + tex_coumna_editar[cont_A_num_a_modificar]
                                }
                                bandera = 1
                            }
                            else if (cont_A_num_a_modificar == num_coumna_editar.size - 1 && bandera != 1)
                            {
                                if (cont_A_dato_archivo < columnas_archivo.size - 1)
                                {
                                    //modifica con el texto
                                    contenido_linea_retoranar = contenido_linea_retoranar + A_dato_archivo + glob.G_valor_espliteo[1]
                                }
                                else
                                {
                                    //modifica con el texto
                                    contenido_linea_retoranar = contenido_linea_retoranar + A_dato_archivo
                                }
                                bandera = 1
                            }
                            cont_A_num_a_modificar++
                        }
                        cont_A_dato_archivo++
                    }
                }
                else if (bandera2 != 1)
                {
                    if (cont_A_columna < columnas_archivo.size - 1)
                    {
                        contenido_linea_retoranar = contenido_linea_retoranar + A_columna + glob.G_valor_espliteo[1]
                    }
                    else
                    {
                        contenido_linea_retoranar = contenido_linea_retoranar + A_columna
                    }
                }
                cont_A_columna++
            }
            contenido_total_retornar = contenido_total_retornar + contenido_linea_retoranar + "\n"
            println("fila: ${A_lineas}")
            cont_lineas++
        }
        archivo.writeText(contenido_total_retornar)
        return "modificados"
    }

    fun eliminar(parametros: String, valor_espliteo: String = "¬"): String
    {
        //espliteado[0]=direccion
        //espliteado[1]=columna a comparar
        //espliteado[2]=texto con el que se va a comparar


        val glob = var_glob()
        val espliteado = parametros.split(valor_espliteo)
        val direccion = espliteado[0]
        val columna_a_comparar = espliteado[1].toInt()
        val comparar = espliteado[2]

        val archivo = File(direccion)
        val contenido = archivo.readLines()
        var contenido_total_retornar = ""

        var cont_lineas = 0
        //saca toda la fila del archivo  estamos en proceso de BUSQUEDA PARA COMPARAR
        for (A_lineas in contenido)
        {
            var contenido_linea_retoranar = ""
            //variabla G_valor_espliteo[1] ="|"
            val columnas_archivo = A_lineas.split(glob.G_valor_espliteo[1])
            var bandera = 0
            var cont_A_columna = 0
            //saca cada A_columna de la fila estamos en proceso de BUSQUEDA PARA COMPARAR
            for (A_columna in columnas_archivo)
            {
                //compara num col y contenido
                if (cont_A_columna == columna_a_comparar && comparar == columnas_archivo[cont_A_columna])
                {
                    bandera=1
                    break
                }
                cont_A_columna++
            }
            if (bandera==1)
            {
                bandera=0
                continue
            }
            else
            {
                contenido_total_retornar = contenido_total_retornar + A_lineas + "\n"
            }
            cont_lineas++
        }
        archivo.writeText(contenido_total_retornar)
        return "eliminado"
    }

    fun agregar(parametros: String, valor_espliteo: String = "¬"): String
    {
        //espliteado[0]=direccion
        //espliteado[1]=texto a agregar


        val glob = var_glob()
        val espliteado = parametros.split(valor_espliteo)
        val direccion = espliteado[0]
        val agregar_texto= espliteado[1]
        val archivo = File(direccion)
        archivo.appendText(agregar_texto)



        return ""
    }

    fun incrementar(parametros: String, valor_espliteo: String = "¬"): String
    {
        //espliteado[0]=direccion
        //espliteado[1]=columna a comparar
        //espliteado[2]=texto con el que se va a comparar
        //espliteado[3]=que columan va a editar
        //espliteado[4]=texto que va a editar

        val glob = var_glob()
        val espliteado = parametros.split(valor_espliteo)
        val direccion = espliteado[0]
        val columna_a_comparar = espliteado[1].toInt()
        val comparar = espliteado[2]
        //numero de columna que editara
        val num_coumna_editar = espliteado[3].split(glob.G_valor_espliteo[1])
        //numero de columna que editara
        val tex_coumna_editar = espliteado[4].split(glob.G_valor_espliteo[1])
        val archivo = File(direccion)
        val contenido = archivo.readLines()
        var contenido_total_retornar = ""

        var cont_lineas = 0
        //saca toda la fila del archivo  estamos en proceso de BUSQUEDA PARA COMPARAR
        for (A_lineas in contenido)
        {
            var contenido_linea_retoranar = ""
            //variabla G_valor_espliteo[1] ="|"
            val columnas_archivo = A_lineas.split(glob.G_valor_espliteo[1])
            var bandera2 = 0
            var cont_A_columna = 0
            //saca cada A_columna de la fila estamos en proceso de BUSQUEDA PARA COMPARAR
            for (A_columna in columnas_archivo)
            {
                //compara num col y contenido si encuentra el buscado borra  contenido_linea_retornara y empesara a guardar
                if (cont_A_columna == columna_a_comparar && comparar == columnas_archivo[cont_A_columna])
                {
                    contenido_linea_retoranar = ""
                    bandera2 = 1
                    var cont_A_dato_archivo = 0
                    //saca contenido la A_columna del archivo
                    for (A_dato_archivo in columnas_archivo)
                    {
                        var bandera = 0
                        var cont_A_num_a_modificar = 0
                        //saca numero A_columna a editar
                        for (A_num_a_modificar in num_coumna_editar)
                        {
                            //compara el numero a modificar con en el numero de celda que va
                            if (cont_A_dato_archivo == A_num_a_modificar.toInt() && bandera != 2)
                            {
                                if (cont_A_dato_archivo < columnas_archivo.size - 1)
                                {
                                    //modifica con el texto
                                    contenido_linea_retoranar = contenido_linea_retoranar + (A_dato_archivo.toInt()+tex_coumna_editar[cont_A_num_a_modificar].toInt()) + glob.G_valor_espliteo[1]
                                }
                                else
                                {
                                    //modifica con el texto
                                    contenido_linea_retoranar = contenido_linea_retoranar + (A_dato_archivo.toInt()+tex_coumna_editar[cont_A_num_a_modificar].toInt())
                                }
                                bandera = 1
                            }
                            else if (cont_A_num_a_modificar == num_coumna_editar.size - 1 && bandera != 1)
                            {
                                if (cont_A_dato_archivo < columnas_archivo.size - 1)
                                {
                                    //modifica con el texto
                                    contenido_linea_retoranar = contenido_linea_retoranar + A_dato_archivo + glob.G_valor_espliteo[1]
                                }
                                else
                                {
                                    //modifica con el texto
                                    contenido_linea_retoranar = contenido_linea_retoranar + A_dato_archivo
                                }
                                bandera = 1
                            }
                            cont_A_num_a_modificar++
                        }
                        cont_A_dato_archivo++
                    }
                }
                else if (bandera2 != 1)
                {
                    if (cont_A_columna < columnas_archivo.size - 1)
                    {
                        contenido_linea_retoranar = contenido_linea_retoranar + A_columna + glob.G_valor_espliteo[1]
                    }
                    else
                    {
                        contenido_linea_retoranar = contenido_linea_retoranar + A_columna
                    }
                }
                cont_A_columna++
            }
            contenido_total_retornar = contenido_total_retornar + contenido_linea_retoranar + "\n"
            println("fila: ${A_lineas}")
            cont_lineas++
        }
        archivo.writeText(contenido_total_retornar)
        return "modificados"
    }

}