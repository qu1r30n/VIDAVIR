package com.example.prumi
import android.Manifest
import android.content.Context
import android.os.Build
import android.os.Bundle
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import kotlinx.android.synthetic.main.activity_main.*
import java.io.BufferedWriter
import java.io.File
import java.io.FileOutputStream
import java.io.OutputStreamWriter




class MainActivity : AppCompatActivity() {
    private val PermissionsRequestCode = 123
    private lateinit var managePermissions: ManagePermissions

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        // Initialize a list of required permissions to request runtime
        val list = listOf<String>(
            Manifest.permission.WRITE_EXTERNAL_STORAGE,
            Manifest.permission.READ_EXTERNAL_STORAGE
        )

        // Initialize a new instance of ManagePermissions class
        managePermissions = ManagePermissions(this,list,PermissionsRequestCode)

        // Button to check permissions states
        btn_chequeo_permisos.setOnClickListener{
            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M)
                managePermissions.checkPermissions()
        }


        btn_crear.setOnClickListener {
            val mydirName = "ext" // guardar carpeta
            val ExtFileName = "tmp.txt" // nombre de archivo
            toast("hola1")
            // nombre del archivo de registro de almacenamiento externo actual (incluida la ruta)
            val extFilePath: String
            val myDir = "/sdcard/download/" + mydirName
            val dir = File(myDir)
            dir.mkdirs()
            val dir_total = myDir+"/"+ExtFileName
            toast("hola2")
            //--------------------------

            val file = File(dir_total)
            try {
                FileOutputStream(file, true).use({ fileOutputStream ->
                    OutputStreamWriter(fileOutputStream, "UTF-8").use({ outputStreamWriter ->
                        BufferedWriter(outputStreamWriter).use({ bw ->
                            bw.write("hola como tan"+"\n")
                            toast("creando archivo")
                            bw.flush()
                        })
                    })
                })
            } catch (e: Exception) {
                toast("error: "+e)
                e.printStackTrace()
            }

            //--------------------------


        }

    }


    // Receive the permissions request result
    override fun onRequestPermissionsResult(requestCode: Int, permissions: Array<String>,
                                            grantResults: IntArray) {
        when (requestCode) {
            PermissionsRequestCode ->{
                val isPermissionsGranted = managePermissions
                    .processPermissionsResult(requestCode,permissions,grantResults)

                if(isPermissionsGranted){
                    // Do the task now
                    toast("Permissions granted.")
                }else{
                    toast("Permissions denied.")
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