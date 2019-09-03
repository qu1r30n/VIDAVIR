package com.example.qu1r30n.controls
import android.Manifest
import android.app.Activity
import com.example.qu1r30n.controls.controlador_de_permisos
import com.example.qu1r30n.toast
import model.base
import operadores_extra_globales.var_glob

class controles(var activity: Activity)
{
    val glob = var_glob()


    fun inicio(){
        // Initialize a list of required permissions to request runtime
        val lista = listOf<String>(
            Manifest.permission.WRITE_EXTERNAL_STORAGE,
            Manifest.permission.READ_EXTERNAL_STORAGE,
            Manifest.permission.CAMERA
        )

        glob.G_controlPermisos=controlador_de_permisos(activity,lista,glob.G_codigo_peticion_permiso)
        glob.G_controlPermisos.checando_permisos()

        //crear archivo-----------------------------------------------------------------------------
        val pru1 = base()

        pru1.crear_archivo_directorio(activity,glob.G_direccion_base)
        //pru1.agregar(glob.G_direccion_base+"¬que paso mi qu1r30n")
        val tex_imp=pru1.editar(glob.G_direccion_base+"¬0¬que paso mi qu1r30n¬0¬hi ho hi ho")
        activity.toast(tex_imp)

    }


    fun cargar():String
    {
        val bas = base()

        val leido = bas.leer(glob.G_direccion_base)
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


        val valores_base=bas.seleccionar("${glob.G_direccion_base}¬3¬${producto}¬0|1|2|3|4|5|6|7").split("\n")
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


        val valores_base=bas.seleccionar("${glob.G_direccion_base}¬3¬${producto}¬0|1|2|3|4|5|6|7").split("\n")
        if(valores_base.size > 0)
        {
            bas.incrementar("${glob.G_direccion_base}¬3¬${producto}¬4¬${espliteado[2]}")
            return "1) agregado"
        }
        else{return "0) no encontrado"}
    }
    
}