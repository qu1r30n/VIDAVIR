package com.example.qu1r30n


import android.content.Context
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Toast
import com.example.qu1r30n.controls.Producto_Activiti
import com.example.qu1r30n.controls.controles
import com.example.qu1r30n.operadores_extra_globales.Producto_var
import kotlinx.android.synthetic.main.activity_main.*
import operadores_extra_globales.var_glob

class MainActivity : AppCompatActivity() {
    val glob = var_glob()



    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        /*prueba
        // Initialize a list of required permissions to request runtime
        val lista = listOf<String>(
            Manifest.permission.WRITE_EXTERNAL_STORAGE,
            Manifest.permission.READ_EXTERNAL_STORAGE
        )

            glob.G_controlPermisos=controlador_de_permisos(this,lista,glob.G_codigo_peticion_permiso)
        glob.G_controlPermisos.checando_permisos()

        //crear archivo-----------------------------------------------------------------------------
        val pru1 = base()
        //pru1.crear_archivo_directorio(this,"/sdcard/qu1r30n/hola1.txt")
        //pru1.agregar("/sdcard/qu1r30n/hola1.txt¬que paso mi qu1r30n")

        btn_checar.setOnClickListener{
            pru1.crear_archivo_directorio(this,glob.G_direccion_base)
            val tex_imp=pru1.agregar(glob.G_direccion_base+"¬que paso mi qu1r30n¬0¬hi ho hi ho")
            toast(tex_imp)
        }

        //------------------------------------------------------------------------------------------
        */
        /* list_adapter_comun
        //var lista=findViewById<ListView>(R.id.lst_view_produc)
        //val items = arrayOf<String>("1","2","3")
        //val adapter_product = ArrayAdapter(this,android.R.layout.simple_expandable_list_item_1,items)
        //lista.adapter=adapter_product
        */


        btn_checar.setOnClickListener{
            controles(this).inicio()
        }

        //list adapter complejo
        val pro = Producto_var("primer_produc", 100.0, "de quireon", glob.G_direccion_img)
        val pro2 = Producto_var("segundo_produc", 2000.0, "de quireon", glob.G_direccion_img)
        val lista_de_productos = listOf<Producto_var>(pro, pro2)

        val adapter2 = ProductosAdapter(this, lista_de_productos)
        lst_view_produc.adapter = adapter2


        lst_view_produc.setOnItemClickListener { parent, view, position, id ->
            val intent = Intent(this, Producto_Activiti::class.java)
            intent.putExtra("producto", lista_de_productos[position])
            startActivity(intent)
        }
        //----------------------------------------------------------------------------------

    }



    // Recibe el resultado de la solicitud de permisos
    override fun onRequestPermissionsResult(solicitud_de_codigo: Int, permisos: Array<String>,
                                            resultados_concedidos: IntArray) {
        when (solicitud_de_codigo) {
            glob.G_codigo_peticion_permiso ->{
                val permiso_aceptado_denegado = glob.G_controlPermisos.proceso_permiso_resultado(solicitud_de_codigo,permisos,resultados_concedidos)

                if(permiso_aceptado_denegado){
                    // Do the task now
                    toast("permiso otorgado.")
                }else{
                    toast("permiso denegado.")
                }
                return
            }
        }
    }


}


// Extension function to show toast message
fun Context.toast(message: String) {
    Toast.makeText(this, message, Toast.LENGTH_SHORT).show()
}