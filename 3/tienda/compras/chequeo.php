<?php

		$codigos=$_POST["arr_codi"];


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
                <form name='nameForm' action='comp.php' method='post'>
                	<input type='hidden' name='arr_codi2' value='".$codigos."'/>
                </form>
            </body>
        </html>";


?>	
