<?php
session_start();
include("../modelo.php");
include("../var_g.php");
?>
<!DOCTYPEhtml>
<html>
<?php 
if (isset($_SESSION["ger"])) {
	if($_SESSION["ger"]==3)
	{
		modelo::arriba1(dirname(__FILE__));

		$arr_nom_btn[0]="bolsa"; $arr_pos_grup[0]="0"; $arr_url[0]="bolsa";
		$arr_nom_btn[1]="programacion voz"; $arr_pos_grup[1]="0"; $arr_url[1]="prog_voz";
		$arr_nom_btn[2]="redireccionador"; $arr_pos_grup[2]="0"; $arr_url[2]="redireccionador";
		$arr_nom_btn[3]="tienda"; $arr_pos_grup[3]="1"; $arr_url[3]="tienda";
		$arr_nom_btn[4]="boton5"; $arr_pos_grup[4]="2"; $arr_url[4]="index.php";
		$arr_nom_btn[5]="boton6"; $arr_pos_grup[5]="3"; $arr_url[5]="index.php";
		$arr_nom_btn[6]="boton7"; $arr_pos_grup[6]="1"; $arr_url[6]="index.php";
		$arr_nom_btn[7]="boton8"; $arr_pos_grup[7]="2"; $arr_url[7]="index.php";
		$arr_nom_btn[8]="boton9"; $arr_pos_grup[8]="3"; $arr_url[8]="index.php";
		$arr_nom_btn[9]="boton10"; $arr_pos_grup[9]="3"; $arr_url[9]="index.php";
		

		$arr_btn_grupo[0]="principal";$arr_btn_grupo[1]="secundario";$arr_btn_grupo[2]="terciario";$arr_btn_grupo[3]="cuaternario";
		modelo::arriba2(dirname(__FILE__),$arr_nom_btn,$arr_pos_grup,$arr_url,$arr_btn_grupo);
		modelo::pub(dirname(__FILE__));
?>
<!----------------------------------------------------------->
		<aside class="col-xs-12 col-sm-12 col-md-12">
				<form action="pag.php" method="post">
					<b>id</b>
					<input type="text" name="id-p">
					<br>
					<b>cantidad</b>
					<input type="text" name="din-p">
					<br>
					<label>CURSO</label>
					<?php
						$cant_de_tab=count($arr_tabla_usar_sistema_VG);
						$comando="<select id='lista' name='curso_t' >";
						for ($i=0; $i < $cant_de_tab ; $i++) 
						{ 
							if ($i < $cant_de_tab-1) 
							{
								$comando=$comando." <option value='".$i."'>".$arr_tabla_usar_sistema_VG[$i]."</option>";
							}
							else
							{
								$comando=$comando." <option value='".$i."'>".$arr_tabla_usar_sistema_VG[$i]."</option></select>";
							}
						}
						echo $comando;
					?>
					<button class="btn btn-primary">compra</button>
				</form>
		</aside>
<!--------------------------------------------------------------->
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