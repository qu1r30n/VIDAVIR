  <?php 
class modelo
{
	function root_path($this_directory)
	{ 
	    $archivos = scandir($this_directory); 
	    $atras = ""; 
	    $cuenta = 0; 
	    while (true)
	    { 
	        foreach($archivos as $actual)
	        { 
	            if ($actual == "modelo.php")
	            { 
	                if ($cuenta == 0) 
	                return "./"; 
	                return $atras; 
	            } 
	        } 
	        $cuenta++; 
	        $atras = $atras . "../"; 
	        $archivos = scandir($atras);
	    }
	}

	function arriba1($this_directory)
	{
		$ir_rais=modelo::root_path($this_directory);
		echo "
		
		<head>
		<title></title>
		<meta name=\"viewport\" content=\"width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0\">
		<!-- Versión compilada y comprimida del CSS de Bootstrap -->
		<link rel=\"stylesheet\" href=\"".$ir_rais."css/bootstrap.min.css\">
		 
		<!-- Tema opcional -->
		<link rel=\"stylesheet\" href=\"".$ir_rais."css/bootstrap-theme.min.css\">
		
		<link rel=\"stylesheet\" type=\"text/css\" href=\"".$ir_rais."css/estilos.css\">
		</head>
		<!--0------------------------------------------------------------------------------------------------>
		<body>
			<!-- Versión compilada y comprimida del JavaScript de Bootstrap -->
			<script src=\"".$ir_rais."js/jquery-3.3.1.min.js\"></script>
			<script src=\"".$ir_rais."js/bootstrap.min.js\"></script>
		<!--1----------------------------------------------------------------------------------------------->
			<header>
				<div>
					<h1>QUIREON</h1>
				</div>
			</header>";
			
	}
	
	function arriba2($this_directory,$arr_nom_bot,$boton_pos_grupo,$arr_url,$arr_bot_grup)
	{
		$ir_rais=modelo::root_path($this_directory);
		$cantidad_botones=count($arr_nom_bot);
		$cantidad_grupos=count($arr_bot_grup);

		$contenido="<!--botones del header-------------------------------------------------------------->
			<div class=\"row\">
				<div class=\"col-sm-12\">";

		$tipo_boton[0]="btn-primary";
		$tipo_boton[1]="btn-success";
		$tipo_boton[2]="btn-info";
		$tipo_boton[3]="btn-danger";
		$tipo_boton[4]="btn-warning";

		$cantidad_tipos=count($tipo_boton);
		$contador=0;

		for ($i=0; $i < $cantidad_grupos ; $i++) 
		{
			if ($contador>=$cantidad_tipos) 
			{
				$contador=0;
			}
			$contenido=$contenido."<div class=\"btn-group\"> 
			<!-- btn group 2, primary -->
      		<button type=\"button\" class=\"btn ".$tipo_boton[$contador]." dropdown-toggle\" data-toggle=\"dropdown\">
	                ".$arr_bot_grup[$i]." <span class=\"caret\"></span></button>

			    <ul class=\"dropdown-menu\" role=\"menu\">";

			for ($j=0; $j < $cantidad_botones ; $j++) 
			{ 
				if ($boton_pos_grupo[$j]==$i) 
				{
					$contenido=$contenido."<li><a href=\"./".$arr_url[$j]."\">".$arr_nom_bot[$j]."</a></li>";
				}
			}

			$contenido=$contenido."</ul>
				</div><!-- /btn-group -->";

			$contador++;
			
		}

		$contenido=$contenido."	
				</div>
			</div>";


		
		echo $contenido;
	}


	function pub($this_directory)
	{
		$ir_rais=modelo::root_path($this_directory);
		echo "<!--parte publicitaria---------------------------------------------------------------------------------->
			<div class=\"col-md-12\">publicidad publicidad <br> publicidad publicidad </div>
			<div class=\"container\">"
			;
	}
	function abajo($this_directory)
	{
		$ir_rais=modelo::root_path($this_directory);
		include($ir_rais."var_g.php");
		echo "
		<!---parte baja de la pagina----------------------------------------------------------------------------------->
				<div class=\"row\">
					<div class=\"color1 col-xs-12 col-sm-6 col-md-3\">
						<p class=\"lead\"><a href=".$ir_rais."".$MANGAS_VG.">MANGAS</a></p>
						<p><strong><a href=".$ir_rais."".$EL_QUIREONENSE_VG.">EL QUIREONENSE</a></strong></p>
						<p><strong><a href=".$ir_rais."".$DIOSES_AZTECAS_VG.">DIOSES AZTECAS</a></strong></p>
						<p><strong><a href=".$ir_rais."".$DIOSES_DEL_MUNDO_VG.">DIOSES DEL MUNDO</a></strong></p>
						<p><strong><a href=".$ir_rais."".$REDES_VG.">REDES</a></strong></p>
						<p><strong><a href=".$ir_rais."".$EL_INVOCADOR_VG.">EL INVOCADOR</a></strong></p>
						<p><strong><a href=".$ir_rais."".$DIOSES_MAYAS_VG.">DIOSES MAYAS</a></strong></p>
					</div>
					<div class=\"col-xs-12 col-sm-6 col-md-3 text-center\">
						<p class=\"lead\"><a href=".$ir_rais."".$CURSOS_VG.">CURSOS</a></p>
						<p><b><a href=".$ir_rais."".$PROGRAMACION_VG.">PROGRAMACION</a></b></p>
						<p><b><a href=".$ir_rais."".$DISEÑO_VG.">DISEÑO</a></b></p>
						<p><b><a href=".$ir_rais."".$REDES_CURSO_VG.">REDES</a></b></p>
						<p><b><a href=".$ir_rais."".$creacion_de_videojuegos_VG.">creacion de videojuegos</a></b></p>
						<p><b><a href=".$ir_rais."".$seguridad_informatica_VG.">seguridad informatica</a></b></p>
						<p><b><a href=".$ir_rais."".$electronica_digital_VG.">electronica digital</a></b></p>
					</div>
					<div class=\"color1 col-xs-12 col-sm-6 col-md-3 text-right\">
						<p class=\"lead\"><a href=".$ir_rais."".$MAPA_DEL_SITIO_VG.">MAPA DEL SITIO</a></p>
						<p><b><a href=".$ir_rais."".$FOROS_VG.">FOROS</a></b></p>
						<p><b><a href=".$ir_rais."".$DONACIONES_VG.">DONACIONES</a></b></p>
						<p><b><a href=".$ir_rais."".$NEGOCIOS_VG.">NEGOCIOS</a></b></p>
						<p><b><a href=".$ir_rais."".$CODIGOS_DE_PROLLECTOS_VG.">CODIGOS DE PROLLECTOS</a></b></p>
						<p><b><a href=".$ir_rais."".$MUSICA_PARA_PROGRAMAR_VG.">MUSICA PARA PROGRAMAR</a></b></p>
						<p><b><a href=".$ir_rais."".$JUEGOS_VG.">JUEGOS</a></b></p>
					</div>
					<div class=\"col-xs-12 col-sm-6 col-md-3 text-justify\"> 
						<p class=\"lead\"><a href=".$ir_rais."".$EVENTOS_VG.">EVENTOS</a></p>
						<p><B><a href=".$ir_rais."".$COMPETENCIAS_VG.">COMPETENCIAS</a></B></p>
						<p><B><a href=".$ir_rais."".$SORTEOS_VG.">SORTEOS</a></B></p>
						<p><B><a href=".$ir_rais."".$INVESTIGACIONES_VG.">INVESTIGACIONES</a></B></p>
						<p><B><a href=".$ir_rais."".$PRESENTACIONES_VG.">PRESENTACIONES</a></B></p>
						<p><B><a href=".$ir_rais."".$CONCIERTOS_VG.">CONCIERTOS</a></B></p>
						<p><B><a href=".$ir_rais."".$EVENTOS_SOCIALES_VG.">EVENTOS SOCIALES</a></B></p>
					</div>
				</div>
		<!----------------------------------------------------------------------------------------------------------->
				<div class=\"row\">
					<blockquote class=\"blockquote-reverse\">
						<p>
							AGRADECIMIENTOS A:
							<footer>MI FAMILIA Q ME A APOLLADO, A  TODOS MIS AMIGOS QUE ME HAN AGUANTADO, Y A MI NOVIA POR ESTAR AQUI
								<cite title=\"Fuente\"><br>con todo corazon gracias</cite> 
							</footer>
						</p>
					</blockquote>
				</div>
			</div>
		</body>
		";
	}
}

?>

<!-- 
<!DOCTYPEhtml>
<html>
<?php
 //modelo::arriba1();
 //modelo::arriba2();
 //modelo::pub();
 //modelo::abajo();
?>

</html> -->