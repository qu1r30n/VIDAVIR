<?php
session_start();
include("../../../../modelo.php");
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
		$arr_nom_btn[0]="boton1"; $arr_pos_grup[0]="0"; $arr_url[0]="index.php";
		$arr_nom_btn[1]="boton2"; $arr_pos_grup[1]="1"; $arr_url[1]="index.php";
		$arr_nom_btn[2]="boton3"; $arr_pos_grup[2]="2"; $arr_url[2]="index.php";
		$arr_nom_btn[3]="boton4"; $arr_pos_grup[3]="3"; $arr_url[3]="index.php";
		$arr_nom_btn[4]="boton5"; $arr_pos_grup[4]="4"; $arr_url[4]="index.php";
		$arr_nom_btn[5]="boton6"; $arr_pos_grup[5]="4"; $arr_url[5]="index.php";
		$arr_nom_btn[6]="boton7"; $arr_pos_grup[6]="0"; $arr_url[6]="index.php";
		$arr_nom_btn[7]="boton8"; $arr_pos_grup[7]="1"; $arr_url[7]="index.php";
		$arr_nom_btn[8]="boton9"; $arr_pos_grup[8]="2"; $arr_url[8]="index.php";
		$arr_nom_btn[9]="boton10"; $arr_pos_grup[9]="3"; $arr_url[9]="index.php";
		

		$arr_btn_grupo[0]="principal";$arr_btn_grupo[1]="secundario";$arr_btn_grupo[2]="terciario";$arr_btn_grupo[3]="cuaternario";
		modelo::arriba2(dirname(__FILE__),$arr_nom_btn,$arr_pos_grup,$arr_url,$arr_btn_grupo);
		modelo::pub(dirname(__FILE__));
?>
		
<!------------------------------>
		<section class="main row">
				<article>
					<FORM method="post" action="chequeo.php">
					<label>CODIGO</label>
					<input type="text" name="CODIGO">
					<br>
					<label>PRODUCTO</label>
					<input type="text" name="PRODUCTO">
					<br>
					<label>COSTO A VENDER</label>
					<input type="text" name="COSTO_A_VENDER">
					<br>
					<label>CANTIDAD</label>
					<input type="text" name="CANTIDAD">
					<br>
					<label>UBICACION DEL PRODUCTO</label>
					<input type="text" name="UBICACION_PRODUCTO">
					<br>
					<label>CADUCIDAD</label>
					<input type="text" name="CADUCIDAD">
					<br>
					<label>COSTO COMPRADO</label>
					<input type="text" name="COSTO_COMPRADO">
					<br>
					<button class="btn btn-primary">registrar</button>
				</FORM>
				</article>
		</section>

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