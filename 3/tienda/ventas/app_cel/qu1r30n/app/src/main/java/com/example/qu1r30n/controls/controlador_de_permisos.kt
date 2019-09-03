package com.example.qu1r30n.controls

import android.app.Activity
import android.app.AlertDialog
import android.content.pm.PackageManager
import androidx.core.app.ActivityCompat
import androidx.core.content.ContextCompat
import com.example.qu1r30n.toast


class controlador_de_permisos(val activity: Activity, val lista_de_permisos: List<String>, val codigo_de_peticion:Int) {

    // Verificar permisos en tiempo de ejecución
    fun checando_permisos() {
        if (permiso_aceptado_o_no() != PackageManager.PERMISSION_GRANTED) {
            mostrar_alerta_de_dialogo()
        } else {
            activity.toast("Permisos ya otorgados..")
        }
    }


    // Verificar el estado de los permisos
    private fun permiso_aceptado_o_no(): Int {
        // PERMISSION_GRANTED : Constant Value: 0
        // PERMISSION_DENIED : Constant Value: -1
        var contador = 0;
        for (permiso in lista_de_permisos) {
            contador += ContextCompat.checkSelfPermission(activity, permiso)
        }
        return contador
    }


    // Encuentra el primer permiso denegado
    private fun permiso_denegado(): String {
        for (permiso in lista_de_permisos) {
            if (ContextCompat.checkSelfPermission(activity, permiso) == PackageManager.PERMISSION_DENIED) return permiso
        }
        return ""
    }


    // Mostrar diálogo de alerta para solicitar permisos
    private fun mostrar_alerta_de_dialogo() {
        val builder = AlertDialog.Builder(activity)
        builder.setTitle("nesesita permisos")
        builder.setMessage("\n" + "Se requieren algunos permisos para realizar la tarea.")
        builder.setPositiveButton("OK", { dialog, which -> solicitar_permisos() })
        builder.setNeutralButton("Cancelar", null)
        val dialog = builder.create()
        dialog.show()
    }


    // Solicitar los permisos en tiempo de ejecución
    private fun solicitar_permisos() {
        val permiso = permiso_denegado()
        if (ActivityCompat.shouldShowRequestPermissionRationale(activity, permiso)) {
            // Show an explanation asynchronously
            activity.toast("explicacion de la solicitud.")
        } else {
            ActivityCompat.requestPermissions(activity, lista_de_permisos.toTypedArray(), codigo_de_peticion)
        }
    }


    // Resultado de permisos de proceso
    fun proceso_permiso_resultado(solicitud_De_codigo: Int, permissions: Array<String>,
                                  conceder_resultados: IntArray): Boolean {
        var resultado = 0
        if (conceder_resultados.isNotEmpty()) {
            for (item in conceder_resultados) {
                resultado += item
            }
        }
        if (resultado == PackageManager.PERMISSION_GRANTED) return true
        return false
    }
}