package com.example.prumi

import android.Manifest
import android.content.Context
import android.os.Build
import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import kotlinx.android.synthetic.main.activity_main.*


class MainActivity : AppCompatActivity() {
    private val codigo_pedido_permiso = 123
    private lateinit var CONTROLADOR_PERMISOS : ManagePermissions

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        // Inicialice una lista de permisos necesarios para solicitar tiempo de ejecución
        val lista_de_permisos = listOf<String>(
            Manifest.permission.READ_EXTERNAL_STORAGE
        )

        // Inicializar una nueva instancia de la clase ManagePermissions
        CONTROLADOR_PERMISOS = ManagePermissions(this,lista_de_permisos,codigo_pedido_permiso)
        CONTROLADOR_PERMISOS.checar_permisos()
    }
}
