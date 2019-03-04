<?php
	include("../../../../modelo.php");
	$dir_raiz=modelo::root_path(dirname(__FILE__));
	include($dir_raiz."operacion_arch.php");
	include($dir_raiz."operaciones_b_tien.php");
	include($dir_raiz."var_g.php");

	$tabla="inventario";
	$archivo=$dir_raiz.$arc_VG[0];

	$codigo=$_POST["CODIGO"];
	$producto=$_POST["PRODUCTO"];
	$costo=$_POST["COSTO_A_VENDER"];
	$cantidad=$_POST["CANTIDAD"];
	$ubicacion_producto=$_POST["UBICACION_PRODUCTO"];
	$caducidad=$_POST["CADUCIDAD"];
	$costo_comprado=$_POST["COSTO_COMPRADO"];
	//ID	CODIGO	PRODUCTO	COSTO_VENTA	CANTIDAD	UBICACION	CADUCIDAD	COSTO_COMPRA
	$arr_icolum[0]="ID";
	$arr_ivalor[0]="NULL";
	$arr_icolum[1]="CODIGO";
	$arr_ivalor[1]=$codigo;
	$arr_icolum[2]="PRODUCTO";
	$arr_ivalor[2]=$producto;
	$arr_icolum[3]="COSTO_VENTA";
	$arr_ivalor[3]=$costo;
	$arr_icolum[4]="CANTIDAD";
	$arr_ivalor[4]=$cantidad;
	$arr_icolum[5]="UBICACION";
	$arr_ivalor[5]=$ubicacion_producto;
	$arr_icolum[6]="CADUCIDAD";
	$arr_ivalor[6]=$caducidad;
	$arr_icolum[7]="COSTO_COMPRA";
	$arr_ivalor[7]=$costo_comprado;
	$arr_icolum[8]="COSTO_COMPRA_RECIENTE";
	$arr_ivalor[8]="0";

	$existe=op_b::mysql_table_existe($tabla);	

	if ($existe=="true") 
		{
			$cantidad_prod=op_b::seleccionar("CANTIDAD",$tabla,"CODIGO = ".$codigo);

			if ($cantidad_prod[0]) 
			{
				?>
				<script type="text/javascript">
					if (confirm("este codigo ya esta en la base de datos ¿quieres sumarle la cantidad?")) 
					{
						<?php
						$arr_colum[0]="CANTIDAD";//estos son los que editara
						$arr_valores[0]="CANTIDAD + ".$cantidad;//estos son los que editara
						$arr_colum2[0]="CODIGO ";
						$arr_compara[0]="=";
						$arr_valores2[0]=$codigo;
						$arr_op_log[0]="";
						op_b::editar($tabla,$arr_colum,$arr_valores,$arr_colum2,$arr_compara,$arr_valores2,$arr_op_log);
						
						op_archivos::incrementar($archivo,"&","CODIGO",$codigo,$arr_colum[0],$cantidad);
						unset($arr_colum,$arr_valores,$arr_colum2,$arr_compara,$arr_valores2,$arr_op_log);
						?>
					}
				</script>
				
				<?php
			} 
			else 
			{
				op_b::insertar($tabla,$arr_icolum,$arr_ivalor);
				op_archivos::crea_escribe($archivo,$codigo."&".$producto."&descripcion falta&".$cantidad."&".$costo);
			}
		} 
		else 
		{
			$arr_col[0]="id";$arr_tip[0]="int";$arr_cant[0]="10";$arr_aut_inc[0]=1;
			$arr_col[1]="CODIGO";$arr_tip[1]="int";$arr_cant[1]="10";$arr_aut_inc[1]=0;
			$arr_col[2]="PRODUCTO";$arr_tip[2]="varchar";$arr_cant[2]="90";$arr_aut_inc[2]=0;
			$arr_col[3]="COSTO_VENTA";$arr_tip[3]="DOUBLE";$arr_cant[3]="255,2";$arr_aut_inc[3]=0;
			$arr_col[4]="CANTIDAD";$arr_tip[4]="int";$arr_cant[4]="10";$arr_aut_inc[4]=0;
			$arr_col[5]="UBICACION";$arr_tip[5]="varchar";$arr_cant[5]="90";$arr_aut_inc[5]=0;
			$arr_col[6]="CADUCIDAD";$arr_tip[6]="varchar";$arr_cant[6]="15";$arr_aut_inc[6]=0;
			$arr_col[7]="COSTO_COMPRA";$arr_tip[7]="DOUBLE";$arr_cant[7]="255,2";$arr_aut_inc[7]=0;
			$arr_col[8]="COSTO_COMPRA_RECIENTE";$arr_tip[8]="DOUBLE";$arr_cant[8]="255,2";$arr_aut_inc[8]=0;
			op_b::crear_tab($arr_database_VG[1],$tabla,$arr_col,$arr_tip,$arr_cant,0,$arr_aut_inc);

			unset($arr_col,$arr_tip,$arr_cant,$arr_aut_inc);

			op_b::insertar($tabla,$arr_icolum,$arr_ivalor);
		}

?>