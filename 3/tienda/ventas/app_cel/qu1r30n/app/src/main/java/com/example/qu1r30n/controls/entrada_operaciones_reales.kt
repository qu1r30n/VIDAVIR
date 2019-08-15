package controls
import model.base
import operadores_extra_globales.var_glob

class controles
{
    fun cargar():String
    {
        val bas = base()
        val G_variables=var_glob()

        val leido = bas.leer(G_variables.G_archivo_inventario)
        return leido
    }

    fun comparar_codigo_de_barras(parametros: String, valor_espliteo: String = "¬"):String
    {

        //val espliteado[0] codigo de barras
        //val espliteado[1] costo unitario
        //val espliteado[2] cantidad

        //0) id|1) producto|2) costo|3) codigo de barras|4) catidad|5) costo de compra|6) marca|7)
        //espliteado[0]=direccion
        //espliteado[1]=columna a comparar
        //espliteado[2]= texto con e    l que se va a comparar
        //espliteado[3]= que columan va a retornar

        val espliteado=parametros.split(valor_espliteo)
        val producto=espliteado[0]
        val costo_unitario=espliteado[1]
        val cantidad=espliteado[2]

        val bas = base()
        val G_variables=var_glob()

        val valores_base=bas.seleccionar("${G_variables.G_archivo_inventario}¬3¬${producto}¬0|1|2|3|4|5|6|7").split("\n")
        if(valores_base.size > 0)
        {
            if(valores_base[5] > espliteado[1])
            {
                return "1) ES MAS BARATO"
            }
            else if(valores_base[5] == espliteado[1])
            {
                return "2) cuesta lo mismo"
            }
            else
            {
                return "3) es mas caro"
            }
        }
        else
        {
            return "0) no se encontro"
        }
    }
    fun agregar(parametros: String, valor_espliteo: String = "¬"):String
    {
        val espliteado=parametros.split(valor_espliteo)
        val producto=espliteado[0]
        val costo_unitario=espliteado[1]
        val cantidad=espliteado[2]

        val bas = base()
        val G_variables=var_glob()

        val valores_base=bas.seleccionar("${G_variables.G_archivo_inventario}¬3¬${producto}¬0|1|2|3|4|5|6|7").split("\n")
        if(valores_base.size > 0)
        {
            bas.incrementar("${G_variables.G_archivo_inventario}¬3¬${producto}¬4¬${espliteado[2]}")
            return "1) agregado"
        }
        else{return "0) no encontrado"}
    }
    
}