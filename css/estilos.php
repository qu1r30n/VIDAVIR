<?php
	
	class estilos
{
	function url_link($nombre_fichero)
	{
		$canselar_siclo=30;
		$cont=1;
		$existe_o_no=false;
		while ($existe_o_no == false)
		{ 
			$existe_o_no=file_exists($nombre_fichero);
			if ($existe_o_no) 
			{
				break;
			}
			if ($cont==$canselar_siclo) 
			{
				break;
			}
			$nombre_fichero="../".$nombre_fichero;
		}

		return $nombre_fichero;

	}
}

?>