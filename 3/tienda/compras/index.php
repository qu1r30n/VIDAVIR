<?php
session_start();
include("../../../modelo.php");
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
				
		<form method="post" action="#">
										<div>

											</div>

											<div >
												<input type="text" name="descripcion" id="descripcion" value="" placeholder="Descripcion Producto"/>
												<input type="button" value="Agregar" id="add_row"/>
											</div>
										</div>
										<br>
										<br>

										<div>
											<table id="tabla_factura">
												<thead>
													<tr>
														<th>Codigo</th>
														<th>Producto</th>
														<th>Descripción</th>
														<th>Cantidad</th>
														<th>Precio</th>
														<th>Subtotal</th>
														<th>Impuesto</th>
														<th>Total</th>
														<td>Acción</td>
													</tr>
												</thead>
												<tbody id="content_table">
													<tr>
														<td></td>
														<td></td>
														<td></td>
														<td></td>
														<td></td>
														<td></td>
														<td></td>
														<td></td>
														<td></td>
													</tr>
												</tbody>
												<tfoot>
													<tr>
														<td colspan="3"></td>
														<td id="total_catidad">0.00</td>
														<td id="total_precio">0.00</td>
														<td id="total_subtotales">0.00</td>
														<td id="total_impuesto">0.00</td>
														<td id="total_total">0.00</td>
													</tr> 
												</tfoot>
											</table>
										</div>
		</form>
		<form id="codi" action="chequeo.php" method="post">
				<input type="hidden" id="variable" name="arr_codi"><br>
				<input type="button" onclick="env_cod()" value="enviar">
		</form>
								
	</section>

	<!-- Scripts -->
	<?php
	echo "<script src=\"".$dir_raiz."js/jquery-latest.js\"></script>";
	echo "<script src=\"".$dir_raiz."js/invoice.js\"></script>";
	?>

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