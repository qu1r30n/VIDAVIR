<?php
session_start();
//------------------------------------------------------
include("var_g.php");
include("operaciones_b.php");
//----------------------------------------------------------
$id_us_ac=$_POST['usu-ac'];
$password=$_POST['pass-ac'];
$num_tab=$_POST['curso_t'];
$tabla=$arr_tabla_usar_sistema_VG[$num_tab];
//-------------------------------------------------------
$dat_us=op_b::seleccionar("*",$tabla,"id=".$id_us_ac);
//--------------------------------------------------------

if ($dat_us[0]==$id_us_ac && $dat_us[25]==$password ) 
{

	$_SESSION["us"]=$id_us_ac;
	$_SESSION["ger"]=$dat_us[24];

	switch ($dat_us[24]) {
		case '1':
				 ?>
		         <META HTTP-EQUIV="REFRESH" CONTENT="0;URL=1/index.php">;
		         <?PHP
			break;
		case '2':
				 ?>
		         <META HTTP-EQUIV="REFRESH" CONTENT="0;URL=2/index.php">;
		         <?PHP
		         
			break;
		case '3': 
		         ?>
		         <META HTTP-EQUIV="REFRESH" CONTENT="0;URL=3/index.php">;
		         <?PHP
		         
			break;
		case '4':
				 ?>
		         <META HTTP-EQUIV="REFRESH" CONTENT="0;URL=4/index.php">;
		         <?PHP
		         
			break;
		default:
			     ?>
		         <META HTTP-EQUIV="REFRESH" CONTENT="0;URL=5/index.php">;
		         <?PHP
		         
			break;
	}
}
?>