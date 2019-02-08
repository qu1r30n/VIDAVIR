<?php
session_start();
include("../../modelo.php");
$dir_raiz=modelo::root_path(dirname(__FILE__));
include($dir_raiz."var_g.php");
?>
<!DOCTYPEhtml>
<html>
<?php 
if (isset($_SESSION["ger"])) {
	if($_SESSION["ger"]==3)
	{
		modelo::arriba1(dirname(__FILE__));
		$arr_nom_btn[0]="compras"; $arr_pos_grup[0]="0"; $arr_url[0]="compras";
		$arr_nom_btn[1]="graficos"; $arr_pos_grup[1]="0"; $arr_url[1]="graficos";
		$arr_nom_btn[2]="inventario"; $arr_pos_grup[2]="0"; $arr_url[2]="inventario";
		$arr_nom_btn[3]="ventas"; $arr_pos_grup[3]="0"; $arr_url[3]="ventas";
		$arr_nom_btn[4]="boton5"; $arr_pos_grup[4]="1"; $arr_url[4]="index.php";
		$arr_nom_btn[5]="boton6"; $arr_pos_grup[5]="2"; $arr_url[5]="index.php";
		$arr_nom_btn[6]="boton7"; $arr_pos_grup[6]="3"; $arr_url[6]="index.php";
		$arr_nom_btn[7]="boton8"; $arr_pos_grup[7]="1"; $arr_url[7]="index.php";
		$arr_nom_btn[8]="boton9"; $arr_pos_grup[8]="2"; $arr_url[8]="index.php";
		$arr_nom_btn[9]="boton10"; $arr_pos_grup[9]="3"; $arr_url[9]="index.php";
		

		$arr_btn_grupo[0]="principal";$arr_btn_grupo[1]="secundario";$arr_btn_grupo[2]="terciario";$arr_btn_grupo[3]="cuaternario";
		modelo::arriba2(dirname(__FILE__),$arr_nom_btn,$arr_pos_grup,$arr_url,$arr_btn_grupo);
		modelo::pub(dirname(__FILE__));
?>
<!------------------------------>


<!---aqui codigo a agregar-->


<!------------------------------>
<?php
		modelo::abajo(dirname(__FILE__));
	}
	else
	{
		echo "Acceso Restringido";
	}
}
else{
		echo "Acceso Restringido";
	}
	
?>

</html>