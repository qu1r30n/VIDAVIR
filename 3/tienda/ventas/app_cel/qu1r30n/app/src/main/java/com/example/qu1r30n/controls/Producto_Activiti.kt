package com.example.qu1r30n.controls

import android.net.Uri
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import com.example.qu1r30n.R
import com.example.qu1r30n.operadores_extra_globales.Producto_var
import kotlinx.android.synthetic.main.activity_producto__activiti.*
import kotlinx.android.synthetic.main.item_img_producto.view.*
import operadores_extra_globales.var_glob

class Producto_Activiti : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_producto__activiti)

        val glob=var_glob()

        val producto = intent.getSerializableExtra("producto") as Producto_var

        txt_nom_produ_activ.text = producto.nombre
        txt_precio_produ_activ.text = "$${producto.precio}"
        txt_descripcion_produ_activ.text = producto.descripcion

        val img: Uri = Uri.parse(producto.imagen)

        img_produc_activ.setImageURI(img)
    }
}
