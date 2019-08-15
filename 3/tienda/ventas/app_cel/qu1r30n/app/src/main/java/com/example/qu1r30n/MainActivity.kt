package com.example.qu1r30n

import android.Manifest
import android.Manifest.permission.WRITE_EXTERNAL_STORAGE
import android.app.Activity
import android.content.Intent
import android.content.pm.PackageManager
import android.os.Build
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.text.TextUtils
import android.widget.Toast
import androidx.annotation.RequiresApi
import androidx.core.app.ActivityCompat
import androidx.core.content.ContextCompat
import com.example.qu1r30n.controls.Producto_Activiti
import com.example.qu1r30n.operadores_extra_globales.Producto_var
import kotlinx.android.synthetic.main.activity_main.*
import model.base

class MainActivity : AppCompatActivity() {

    @RequiresApi(Build.VERSION_CODES.M)
    override fun onCreate(savedInstanceState: Bundle?)
    {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        //----------------------------------------------------------------------------------




        //----------------------------------------------------------------------------------

        //val pru1 = base()
        //pru1.crear_archivo_directorio("$filesDir/1/hola2.txt")

        /* list_adapter_comun
        //var lista=findViewById<ListView>(R.id.lst_view_produc)
        //val items = arrayOf<String>("1","2","3")
        //val adapter_product = ArrayAdapter(this,android.R.layout.simple_expandable_list_item_1,items)
        //lista.adapter=adapter_product
        */

        //list adapter complejo
        val pro= Producto_var("primer_produc", 100.0, "de quireon", R.drawable.camara)
        val pro2= Producto_var("segundo_produc", 2000.0, "de quireon", R.drawable.pc)
        val lista_de_productos = listOf<Producto_var>(pro,pro2)

        val adapter2 = ProductosAdapter(this,lista_de_productos)
        lst_view_produc.adapter=adapter2

        lst_view_produc.setOnItemClickListener { parent, view, position, id ->
            val intent = Intent(this, Producto_Activiti::class.java)
            intent.putExtra("producto", lista_de_productos[position])
            startActivity(intent)
        }
    }


    fun Activity.isHasPermission(vararg permissions: String): Boolean {
        return if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M)
            permissions.all { singlePermission ->
                applicationContext.checkSelfPermission(singlePermission) == PackageManager.PERMISSION_GRANTED
            }
        else true
    }

    fun Activity.askPermission(vararg permissions: String, @IntRange(from = 0) requestCode: Int) =
        ActivityCompat.requestPermissions(this, permissions, requestCode)
}
