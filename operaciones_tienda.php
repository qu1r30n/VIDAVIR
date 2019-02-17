<?php  
class operaciones_tienda
{
	function venta($arr_codigos)
	{
		include("operacion_arch.php");
		include("operaciones_b_tien.php");
		include("var_g.php");

		date_default_timezone_set("America/Mexico_City"); 
		$url = "http://".$_SERVER["SERVER_NAME"].$_SERVER["REQUEST_URI"];  
		$acum=0;
		$año = date("Y");
		$mes = date("m");
		$dia = date("d");
		$hora= date("G");
		$concil="conciliacion_".$año;
		$arreglo=explode("&",$arr_codigos);
		$direccion_arch="regis/operaciones/".$año."/".$mes."/".$dia.".txt";

		for ($i=0; $i < count($arreglo) ; $i++) 
		{
			$temp=op_b::seleccionar("CODIGO,PRODUCTO,COSTO_VENTA","inventario","codigo=".$arreglo[$i]);
			$producto=implode("&", $temp);
			op_archivos::crea_escribe($direccion_arch,$producto."&".$hora);
			$acum=$acum+$temp[2];

			//--decrementa el inventario------------------------------------------------------------------------------------
			$arr_colum[0]="CANTIDAD";//estos son los que editara
			$arr_valores[0]="CANTIDAD-1";//estos son los que editara
			$arr_colum2[0]="CODIGO";
			$arr_compara[0]="=";
			$arr_valores2[0]=$arreglo[$i];
			$arr_op_log[0]="";
			op_b::editar("inventario",$arr_colum,$arr_valores,$arr_colum2,$arr_compara,$arr_valores2,$arr_op_log);
			//--------------------------------------------------------------------------------------
		}

		unset($arr_colum,$arr_valores,$arr_colum2,$arr_compara,$arr_valores2,$arr_op_log);

		$existe=op_b::mysql_table_existe($concil);


		if ($existe=="true") 
		{
			$din=op_b::seleccionar("venta ",$concil,"mes=".$mes." && dia=".$dia);

			if ($din[0]) 
			{

				$arr_colum[0]="venta";//estos son los que editara
				$arr_valores[0]="venta + ".$acum;//estos son los que editara
				$arr_colum2[0]="mes";
				$arr_compara[0]="=";
				$arr_valores2[0]=$mes;
				$arr_op_log[0]="&&";
				$arr_colum2[1]="dia";
				$arr_compara[1]="=";
				$arr_valores2[1]=$dia;
				op_b::editar($concil,$arr_colum,$arr_valores,$arr_colum2,$arr_compara,$arr_valores2,$arr_op_log);
				unset($arr_colum,$arr_valores,$arr_colum2,$arr_compara,$arr_valores2,$arr_op_log);

				$arr_colum[0]="dinero";//estos son los que editara
				$arr_valores[0]="dinero + ".$acum;//estos son los que editara
				$arr_colum2[0]="id";
				$arr_compara[0]="=";
				$arr_valores2[0]="1";
				$arr_op_log[0]="";
				op_b::editar("acum_tot",$arr_colum,$arr_valores,$arr_colum2,$arr_compara,$arr_valores2,$arr_op_log);
				unset($arr_colum,$arr_valores,$arr_colum2,$arr_compara,$arr_valores2,$arr_op_log);
			} 
			else 
			{
				$h0colum[0]="id";$h0valores[0]="";
				$h0colum[1]="mes";$h0valores[1]=$mes;
				$h0colum[2]="dia";$h0valores[2]=$dia;
				$h0colum[3]="venta";$h0valores[3]=$acum;
				op_b::insertar($concil,$h0colum,$h0valores);

				unset($h0colum,$h0valores);

				$arr_colum[0]="dinero";//estos son los que editara
				$arr_valores[0]="dinero + ".$acum;//estos son los que editara
				$arr_colum2[0]="id";
				$arr_compara[0]="=";
				$arr_valores2[0]="1";
				$arr_op_log[0]="";
				op_b::editar("acum_tot",$arr_colum,$arr_valores,$arr_colum2,$arr_compara,$arr_valores2,$arr_op_log);
				unset($arr_colum,$arr_valores,$arr_colum2,$arr_compara,$arr_valores2,$arr_op_log);
			}
		} 
		else 
		{
			$arr_col[0]="id";$arr_tip[0]="int";$arr_cant[0]="10";$arr_aut_inc[0]=1;
			$arr_col[1]="mes";$arr_tip[1]="int";$arr_cant[1]="2";$arr_aut_inc[1]=0;
			$arr_col[2]="dia";$arr_tip[2]="int";$arr_cant[2]="2";$arr_aut_inc[2]=0;
			$arr_col[3]="venta";$arr_tip[3]="DOUBLE";$arr_cant[3]="255,2";$arr_aut_inc[3]=0;
			op_b::crear_tab($arr_database_VG[1],$concil,$arr_col,$arr_tip,$arr_cant,0,$arr_aut_inc);
			unset($arr_col,$arr_tip,$arr_cant,$arr_aut_inc);

			$h0colum[0]="id";$h0valores[0]="";
			$h0colum[1]="mes";$h0valores[1]=$mes;
			$h0colum[2]="dia";$h0valores[2]=$dia;
			$h0colum[3]="venta";$h0valores[3]=$acum;
			op_b::insertar($concil,$h0colum,$h0valores);
			unset($h0colum,$h0valores);

			$arr_colum[0]="dinero";//estos son los que editara
			$arr_valores[0]="dinero + ".$acum;//estos son los que editara
			$arr_colum2[0]="id";
			$arr_compara[0]="=";
			$arr_valores2[0]="1";
			$arr_op_log[0]="";
			op_b::editar("acum_tot",$arr_colum,$arr_valores,$arr_colum2,$arr_compara,$arr_valores2,$arr_op_log);
			unset($arr_colum,$arr_valores,$arr_colum2,$arr_compara,$arr_valores2,$arr_op_log);
		}
	}




	function gastos($gasto=0,$declaracion)
	{
		include("operacion_arch.php");
		include("operaciones_b_tien.php");
		include("var_g.php");

		date_default_timezone_set("America/Mexico_City"); 
		$url = "http://".$_SERVER["SERVER_NAME"].$_SERVER["REQUEST_URI"];  
		
		$año = date("Y");
		$mes = date("m");
		$dia = date("d");
		$hora= date("G");
		$concil="gastos_".$año;

		$direccion_arch="regis/operaciones/".$año."/".$mes."/".$dia."_gastos.txt";

		op_archivos::crea_escribe($direccion_arch,"000&".$declaracion."&".$gasto."&".$hora);

		$existe=op_b::mysql_table_existe($concil);
		
		if ($existe=="true") 
		{
			$din=op_b::seleccionar("gastos ",$concil,"mes=".$mes." && dia=".$dia);

			if ($din[0]) 
			{
				$arr_colum[0]="gastos";//estos son los que editara
				$arr_valores[0]="gastos + ".$gasto;//estos son los que editara
				$arr_colum2[0]="mes";
				$arr_compara[0]="=";
				$arr_valores2[0]=$mes;
				$arr_op_log[0]="&&";
				$arr_colum2[1]="dia";
				$arr_compara[1]="=";
				$arr_valores2[1]=$dia;
				op_b::editar($concil,$arr_colum,$arr_valores,$arr_colum2,$arr_compara,$arr_valores2,$arr_op_log);
				unset($arr_colum,$arr_valores,$arr_colum2,$arr_compara,$arr_valores2,$arr_op_log);

				$arr_colum[0]="dinero";//estos son los que editara
				$arr_valores[0]="dinero - ".$gasto;//estos son los que editara
				$arr_colum2[0]="id";
				$arr_compara[0]="=";
				$arr_valores2[0]="1";
				$arr_op_log[0]="";
				op_b::editar("acum_tot",$arr_colum,$arr_valores,$arr_colum2,$arr_compara,$arr_valores2,$arr_op_log);
				unset($arr_colum,$arr_valores,$arr_colum2,$arr_compara,$arr_valores2,$arr_op_log);
			} 
			else 
			{
				$h0colum[0]="id";$h0valores[0]="";
				$h0colum[1]="mes";$h0valores[1]=$mes;
				$h0colum[2]="dia";$h0valores[2]=$dia;
				$h0colum[3]="venta";$h0valores[3]=$gasto*-1;
				op_b::insertar($concil,$h0colum,$h0valores);
				unset($h0colum,$h0valores);

				$arr_colum[0]="dinero";//estos son los que editara
				$arr_valores[0]="dinero - ".$gasto;//estos son los que editara
				$arr_colum2[0]="id";
				$arr_compara[0]="=";
				$arr_valores2[0]="1";
				$arr_op_log[0]="";
				op_b::editar("acum_tot",$arr_colum,$arr_valores,$arr_colum2,$arr_compara,$arr_valores2,$arr_op_log);
				unset($arr_colum,$arr_valores,$arr_colum2,$arr_compara,$arr_valores2,$arr_op_log);
			}
		} 
		else 
		{
			$arr_col[0]="id";$arr_tip[0]="int";$arr_cant[0]="10";$arr_aut_inc[0]=1;
			$arr_col[1]="mes";$arr_tip[1]="int";$arr_cant[1]="2";$arr_aut_inc[1]=0;
			$arr_col[2]="dia";$arr_tip[2]="int";$arr_cant[2]="2";$arr_aut_inc[2]=0;
			$arr_col[3]="venta";$arr_tip[3]="DOUBLE";$arr_cant[3]="255,2";$arr_aut_inc[3]=0;
			op_b::crear_tab($arr_database_VG[1],"conciliacion_".$año,$arr_col,$arr_tip,$arr_cant,0,$arr_aut_inc);

			$h0colum[0]="id";$h0valores[0]="";
			$h0colum[1]="mes";$h0valores[1]=$mes;
			$h0colum[2]="dia";$h0valores[2]=$dia;
			$h0colum[3]="venta";$h0valores[3]=$gasto*-1;
			op_b::insertar($concil,$h0colum,$h0valores);
			unset($h0colum,$h0valores);

			$arr_colum[0]="dinero";//estos son los que editara
			$arr_valores[0]="dinero-".$gasto;//estos son los que editara
			$arr_colum2[0]="id";
			$arr_compara[0]="=";
			$arr_valores2[0]="1";
			$arr_op_log[0]="";
			op_b::editar("acum_tot",$arr_colum,$arr_valores,$arr_colum2,$arr_compara,$arr_valores2,$arr_op_log);
			unset($arr_colum,$arr_valores,$arr_colum2,$arr_compara,$arr_valores2,$arr_op_log);
		}
	}


	function compras($arr_codigos,$arr_precios_actuales)
	{
		include("operacion_arch.php");
		include("operaciones_b_tien.php");
		include("var_g.php");

		date_default_timezone_set("America/Mexico_City"); 
		$url = "http://".$_SERVER["SERVER_NAME"].$_SERVER["REQUEST_URI"];  
		$acum=0;
		$año = date("Y");
		$mes = date("m");
		$dia = date("d");
		$hora= date("G");
		$concil="gastos_".$año;

		$arreglo=explode("&",$arr_codigos);
		$direccion_arch="regis/operaciones/".$año."/".$mes."/".$dia."_compras.txt";

		for ($i=0; $i < count($arreglo) ; $i++) 
		{
			$temp=op_b::seleccionar("CODIGO,PRODUCTO,COSTO_COMPRA","inventario","codigo=".$arreglo[$i]);
			$producto=implode("&", $temp);
			//falta aqui tiene que comparar el precio  y checar si sube o baja y decidir
			//si se saltan o se detienen las compras y hacer una lista para ver cual subio o bajo
			//y comparar que otra te lo da a mejor precio 


			op_archivos::crea_escribe($direccion_arch,$producto."&".$hora);
			$acum=$acum+$temp[2];

			//--incrementa inventario------------------------------------------------------------------------------------
			$arr_colum[0]="CANTIDAD";//estos son los que editara
			$arr_valores[0]="CANTIDAD+1";//estos son los que editara
			$arr_colum2[0]="CODIGO";
			$arr_compara[0]="=";
			$arr_valores2[0]=$arreglo[$i];
			$arr_op_log[0]="";
			op_b::editar("inventario",$arr_colum,$arr_valores,$arr_colum2,$arr_compara,$arr_valores2,$arr_op_log);
			//--------------------------------------------------------------------------------------
		}

		unset($arr_colum,$arr_valores,$arr_colum2,$arr_compara,$arr_valores2,$arr_op_log);

		$existe=op_b::mysql_table_existe($concil);
		
		$din2=op_b::seleccionar("dinero ","acum_tot","id=1");
		
		if ($existe=="true") 
		{
			$din=op_b::seleccionar("gastos ",$concil,"mes=".$mes." && dia=".$dia);

			if ($din[0]) 
			{
				$arr_colum[0]="gastos";//estos son los que editara
				$arr_valores[0]="gastos + ".$gasto;//estos son los que editara
				$arr_colum2[0]="mes";
				$arr_compara[0]="=";
				$arr_valores2[0]=$mes;
				$arr_op_log[0]="&&";
				$arr_colum2[1]="dia";
				$arr_compara[1]="=";
				$arr_valores2[1]=$dia;
				op_b::editar($concil,$arr_colum,$arr_valores,$arr_colum2,$arr_compara,$arr_valores2,$arr_op_log);
				unset($arr_colum,$arr_valores,$arr_colum2,$arr_compara,$arr_valores2,$arr_op_log);

				$arr_colum[0]="dinero";//estos son los que editara
				$arr_valores[0]="dinero - ".$acum;//estos son los que editara
				$arr_colum2[0]="id";
				$arr_compara[0]="=";
				$arr_valores2[0]="1";
				$arr_op_log[0]="";
				op_b::editar("acum_tot",$arr_colum,$arr_valores,$arr_colum2,$arr_compara,$arr_valores2,$arr_op_log);
				unset($arr_colum,$arr_valores,$arr_colum2,$arr_compara,$arr_valores2,$arr_op_log);
			} 
			else 
			{
				$h0colum[0]="id";$h0valores[0]="";
				$h0colum[1]="mes";$h0valores[1]=$mes;
				$h0colum[2]="dia";$h0valores[2]=$dia;
				$h0colum[3]="venta";$h0valores[3]=$gasto*-1;
				op_b::insertar($concil,$h0colum,$h0valores);
				unset($h0colum,$h0valores);

				$arr_colum[0]="dinero";//estos son los que editara
				$arr_valores[0]="dinero - ".$acum;//estos son los que editara
				$arr_colum2[0]="id";
				$arr_compara[0]="=";
				$arr_valores2[0]="1";
				$arr_op_log[0]="";
				op_b::editar("acum_tot",$arr_colum,$arr_valores,$arr_colum2,$arr_compara,$arr_valores2,$arr_op_log);
				unset($arr_colum,$arr_valores,$arr_colum2,$arr_compara,$arr_valores2,$arr_op_log);
			}
		} 
		else 
		{
			$arr_col[0]="id";$arr_tip[0]="int";$arr_cant[0]="10";$arr_aut_inc[0]=1;
			$arr_col[1]="mes";$arr_tip[1]="int";$arr_cant[1]="2";$arr_aut_inc[1]=0;
			$arr_col[2]="dia";$arr_tip[2]="int";$arr_cant[2]="2";$arr_aut_inc[2]=0;
			$arr_col[3]="venta";$arr_tip[3]="DOUBLE";$arr_cant[3]="255,2";$arr_aut_inc[3]=0;
			op_b::crear_tab($arr_database_VG[1],"conciliacion_".$año,$arr_col,$arr_tip,$arr_cant,0,$arr_aut_inc);

			$h0colum[0]="id";$h0valores[0]="";
			$h0colum[1]="mes";$h0valores[1]=$mes;
			$h0colum[2]="dia";$h0valores[2]=$dia;
			$h0colum[3]="venta";$h0valores[3]=$gasto*-1;
			op_b::insertar($concil,$h0colum,$h0valores);
			unset($h0colum,$h0valores);

			$arr_colum[0]="dinero";//estos son los que editara
			$arr_valores[0]="dinero-".$acum;//estos son los que editara
			$arr_colum2[0]="id";
			$arr_compara[0]="=";
			$arr_valores2[0]="1";
			$arr_op_log[0]="";
			op_b::editar("acum_tot",$arr_colum,$arr_valores,$arr_colum2,$arr_compara,$arr_valores2,$arr_op_log);
			unset($arr_colum,$arr_valores,$arr_colum2,$arr_compara,$arr_valores2,$arr_op_log);
		}
	}

}	
?>	