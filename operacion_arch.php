<?php
class op_archivos
{
	function eliminar($archivo,$palabra_buscar,$separador,$columna = 1)
	{
		
		$abrir = fopen($archivo,'r+');
		$contenido = fread($abrir,filesize($archivo));
		fclose($abrir);
		// Separar linea por linea
		$contenido3 = explode("\n",$contenido);
		$cantidad_lineas=count($contenido);
		$cont_temp=-1;

			if(is_numeric($columna)) 
			{
				for ($j=0; $j < $cantidad_lineas ; $j++) 
				{ 
					// Separar linea por celdas
					$contenido2 = explode($separador,$contenido[$j]);
					
					 //busca la palabra para sustituirla
					 	if ($contenido2[$columna]!=$palabra_buscar) 
					 	{
					 		$cont_temp=$cont_temp+1;
					 		$contenido[$cont_temp]=$contenido3[$j];
					 	}
				}
			}
			else
			{
				$numero_columna="";
				$contenido2 = explode($separador,$contenido3[0]);
				$cantidad_celdas= count($contenido2);
				 //busca la palabra para sustituirla
				 for ($i=0; $i < $cantidad_celdas ; $i++) 
				 { 
				 	if ($contenido2[$i]==$columna) 
				 	{
				 		$numero_columna=$i;
				 	}
				 }

				for ($j=0; $j < $cantidad_lineas ; $j++) 
				{ 
					// Separar linea por celdas
					$contenido2 = explode($separador,$contenido[$j]);
					
					 //busca la palabra para saltarla
					 	if ($contenido2[$numero_columna]!=$palabra_buscar) 
					 	{
					 		$cont_temp=$cont_temp+1;
					 		$contenido[$cont_temp]=$contenido3[$j];
					 	}
				}

			}
			
		//eliminar archivo
		unlink($archivo);
		// Guardar Archivo
		$abrir = fopen($archivo,'w');
		fwrite($abrir,$contenido);
		fclose($abrir);
	}

	function seleccionar($archivo,$palabra_buscar,$separador,$columna = 1)
	{
		$abrir = fopen($archivo,'r+');
		$contenido = fread($abrir,filesize($archivo));
		fclose($abrir);
		// Separar linea por linea
		$contenido3 = explode("\n",$contenido);
		$cantidad_lineas=count($contenido);
		$cont_temp=-1;

			if(is_numeric($columna)) 
			{
				for ($j=0; $j < $cantidad_lineas ; $j++) 
				{ 
					// Separar linea por celdas
					$contenido2 = explode($separador,$contenido[$j]);
					
					 //busca la palabra para sustituirla
					 	if ($contenido2[$columna]==$palabra_buscar) 
					 	{
					 		$cont_temp=$cont_temp+1;
					 		$contenido[$cont_temp]=$contenido3[$j];
					 	}
				}
			}
			else
			{
				$numero_columna="";
				$contenido2 = explode($separador,$contenido3[0]);
				$cantidad_celdas= count($contenido2);
				 //busca la palabra para sustituirla
				 for ($i=0; $i < $cantidad_celdas ; $i++) 
				 { 
				 	if ($contenido2[$i]==$columna) 
				 	{
				 		$numero_columna=$i;
				 	}
				 }

				for ($j=0; $j < $cantidad_lineas ; $j++) 
				{ 
					// Separar linea por celdas
					$contenido2 = explode($separador,$contenido[$j]);
					
					 //busca la palabra para saltarla
					 	if ($contenido2[$numero_columna]==$palabra_buscar) 
					 	{
					 		$cont_temp=$cont_temp+1;
					 		$contenido[$cont_temp]=$contenido3[$j];
					 	}
				}

			}
			
		
		return $contenido;	
	}

	function editar($archivo,$palabra_buscar,$separador,$palabra_editar,$columna = NULL)
	{
		$abrir = fopen($archivo,'r+');
		$contenido = fread($abrir,filesize($archivo));
		fclose($abrir);
		// Separar linea por linea
		$contenido = explode("\n",$contenido);
		$cantidad_lineas=count($contenido);
		
		if ($columna==NULL) 
		{
			for ($j=0; $j < $cantidad_lineas ; $j++) 
			{ 
 				$contenido2 = explode($separador,$contenido[$j]);
				$cantidad_celdas= count($contenido2);
				 //busca la palabra para sustituirla
				 for ($i=0; $i < $cantidad_celdas ; $i++) 
				 { 
				 	if ($contenido2[$i]==$palabra_buscar) 
				 	{
				 		$contenido2[$i]=$palabra_editar; // Modificar las celdas deseada
				 	}
				 }
				//unir archivo
			 	$contenido[$j] = implode($separador,$contenido2);
			}
		}
		else
		{
			if(is_numeric($columna)) 
			{
				for ($j=0; $j < $cantidad_lineas ; $j++) 
				{ 
					// Separar linea por celdas
					$contenido2 = explode($separador,$contenido[$j]);
					
					 //busca la palabra para sustituirla
					 	if ($contenido2[$columna]==$palabra_buscar) 
					 	{
					 		$contenido2[$columna]=$palabra_editar; // Modificar las celdas deseada
					 	}
					 
					//unir archivo
				 	$contenido[$j] = implode($separador,$contenido2);
				}
			}
			else
			{
				$numero_columna="";
				$contenido2 = explode($separador,$contenido[0]);
				$cantidad_celdas= count($contenido2);
				 //busca la palabra para sustituirla
				 for ($i=0; $i < $cantidad_celdas ; $i++) 
				 { 
				 	if ($contenido2[$i]==$palabra_buscar) 
				 	{
				 		$numero_columna=$i;
				 	}
				 }

				 for ($j=0; $j < $cantidad_lineas ; $j++) 
				{ 
					// Separar linea por celdas
					$contenido2 = explode($separador,$contenido[$j]);
					
					 //busca la palabra para sustituirla
					 	if ($contenido2[$numero_columna]==$palabra_buscar) 
					 	{
					 		$contenido2[$numero_columna]=$palabra_editar; // Modificar las celdas deseada
					 	}
					 
					//unir archivo
				 	$contenido[$j] = implode($separador,$contenido2);
				}

			}
				
		}	

			// Unir archivo
			$contenido = implode("\r\n",$contenido);
		 
		// Guardar Archivo
		$abrir = fopen($archivo,'w');
		fwrite($abrir,$contenido);
		fclose($abrir);
	}

	function leer($nombre_fichero)
	{
		$gestor = fopen($nombre_fichero, "r");
		$contenido = fread($gestor, filesize($nombre_fichero));
		fclose($gestor);
		return $contenido;
	}
	
	function crea_escribe($ubicacion_arch,$texto)
	{	

		$car_arch = op_archivos::espliteos_dierecciones($ubicacion_arch);
		$carpeta = $car_arch[0];

		if (!file_exists($carpeta)) 
		{
    		mkdir($carpeta, 0777, true);
		}
		$fp = fopen(($car_arch[0].$car_arch[1]),'a'); 
		fwrite($fp,$texto.PHP_EOL);
		fclose($fp);
	}

	function espliteos_dierecciones($ubicacion_archivos)
	{
		$carpetas="";
		$direccion= explode("/",$ubicacion_archivos);
		$can_car=(count($direccion)-2);
		for ($i=0; $i <= $can_car; $i++) 
		{ 
			$carpetas=$carpetas.$direccion[$i]."/";
		}
		$arreglo[0]=$carpetas;
		$arreglo[1]=$direccion[$can_car+1];
		return($arreglo);
	}
}
?>
