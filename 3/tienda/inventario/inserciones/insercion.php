<?php
	include("../../../../modelo.php");
	$dir_raiz=modelo::root_path(dirname(__FILE__));
	$tabla="inventario";

	include($dir_raiz."operaciones_b_tien.php");

	$codigo=$_POST['CODIGO'];
	$producto=$_POST['PRODUCTO'];
	$costo=$_POST['COSTO_A_VENDER'];
	$cantidad=$_POST['CANTIDAD'];
	$ubicacion_producto=$_POST['UBICACION_PRODUCTO'];
	$caducidad=$_POST['CADUCIDAD'];
	$costo_comprado=$_POST['COSTO_COMPRADO'];
	//ID	CODIGO	PRODUCTO	COSTO_VENTA	CANTIDAD	UBICACION	CADUCIDAD	COSTO_COMPRA
	$icolum[0]="ID";
	$ivalor[0]="NULL";
	$icolum[1]="CODIGO";
	$ivalor[1]=$codigo;
	$icolum[2]="PRODUCTO";
	$ivalor[2]=$producto;
	$icolum[3]="COSTO_VENTA";
	$ivalor[3]=$costo;
	$icolum[4]="CANTIDAD";
	$ivalor[4]=$cantidad;
	$icolum[5]="UBICACION";
	$ivalor[5]=$ubicacion_producto;
	$icolum[6]="CADUCIDAD";
	$ivalor[6]=$caducidad;
	$icolum[7]="COSTO_COMPRA";
	$ivalor[7]=$costo_comprado;
	

	op_b::insertar($tabla,$icolum,$ivalor);

?>