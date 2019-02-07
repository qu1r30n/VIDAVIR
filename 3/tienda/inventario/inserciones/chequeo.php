<?php

        $a=$_POST['CODIGO'];
        $b=$_POST['PRODUCTO'];
        $c=$_POST['COSTO_A_VENDER'];
        $d=$_POST['CANTIDAD'];
        $e=$_POST['UBICACION_PRODUCTO'];
        $f=$_POST['CADUCIDAD'];
        $g=$_POST['COSTO_COMPRADO'];


    echo "
        <html>
            <head>
                <meta content='text/html; charset=utf-8' http-equiv='Content-Type' />
                <title>Procesando...</title>
                <script type='text/javascript'>
                    function enviarForm(){
                        document.nameForm.submit();
                    }
                </script>
            </head>
            <body onLoad='javascript:enviarForm();'>
                <form name='nameForm' action='insercion.php' method='post'>
                    <input type='hidden' name='CODIGO' value='".$a."'/>
                    <input type='hidden' name='PRODUCTO' value='".$b."'/>
                    <input type='hidden' name='COSTO_A_VENDER' value='".$c."'/>
                    <input type='hidden' name='CANTIDAD' value='".$d."'/>
                    <input type='hidden' name='UBICACION_PRODUCTO' value='".$e."'/>
                    <input type='hidden' name='CADUCIDAD' value='".$f."'/> 
                    <input type='hidden' name='COSTO_COMPRADO' value='".$g."'/> 
                </form>
            </body>
        </html>";


?>