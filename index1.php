<?php
	include("var_g.php");
	include("modelo.php");

?>
<!DOCTYPEhtml>
<html>
<?php 
	modelo::arriba1(dirname(__FILE__)); 
?>
<FORM method="post" action="chequeo.php">
					<label>USUARIO</label>
					<input type="text" name="usu-ac">
					<label>PASWORD</label>
					<input type="password" name="pass-ac">
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
					<button class="btn btn-primary">enviar</button>
</FORM>
<?php 
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
<section class="main row">
	<ARTICLE class="col-xs-12 col-sm-12 col-md-5">
		<iframe allowfullscreen="" frameborder="0" height="344" src="https://www.youtube.com/embed/8GPA6-l9mWo" width="459"></iframe>
	</ARTICLE>

	<ASIDE class="col-xs-12 col-sm-12 col-md-3">
		<p>EPISODIO 1</p>
		<p>EPISODIO 1</p>
		<p>EPISODIO 1</p>
		<p>EPISODIO 1</p>
		<p>EPISODIO 1</p>
		<p>EPISODIO 1</p>
		<p>EPISODIO 1</p>
	</ASIDE>
	<ASIDE class="col-xs-12 col-sm-12 col-md-4">
		<br>
		<FORM  action="insercion.php" method="post">
				<table>
					<tr><td colspan="2">REGISTRAR</td></tr>
					<tr>
						<td >
							<label>ID PATROCINADOR</label>
							<br>
							<input type="text" name="id_patro-r">
							<br>
							<label>UBICACION PATRO</label>
							<br>
								<?php
									$cant_de_tab=count($arr_tabla_usar_sistema_VG);
									$comando="<select id='lista' name='tab-pat-reg'>";
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
						<br>
							<label>PASWORD</label>
							<br>
							<input type="text" name="pass-r">
							<br>
							<label>CONFIRMAR PASWORD</label>
							<br>
							<input type="text" name="conf-pass-r">
							<br>
							<label>NOMBRE</label>
							<br>
							<input type="text" name="nombre-r">
							<br>
							<label>APELLIDO PATERNO</label>
							<br>
							<input type="text" name="ap-p-r">
						<br>
							<label>APELLIDO MATERNO</label>
							<br>
							<input type="text" name="ap-m-r">
							<br>
							<label>FECHA DE NACIMIENTO</label>
						<br>
							<input type="text" name="fecha-nacimiento-r">
						<br>
							<label>PAIS</label>
							<br>
							<input type="text" name="pais-r">
							<br>
							</td>
							<td>
							<label>CURSO</label>
						<br>
								<?php
									$cant_de_tab=count($arr_tabla_usar_sistema_VG);
									$comando="<select id='lista' name='curso_t'>";
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
							<br>
							<label>ESTADO</label>
							<br>
							<input type="text" name="estado-r">
							<br>
							<label>MUNICIPIO</label>
							<br>
							<input type="text" name="municipio-r">
							<br>
							<label>COLONIA</label>
							<br>
							<input type="text" name="colonia-r">
							<br>
							<label>DIRECCION</label>
							<br>
							<input type="text" name="direccion-r">
							<br>
							<label>TELEFONO</label>
							<br>
							<input type="text" name="tel-r">
							<br>
							<label>DINERO INSCRIPCION</label>
							<br>
							<input type="text" name="dinero-r">
							<br>
							<label>NUMERO DE CUENTA BANCO</label>
							<br>
							<input type="text" name="num-cue-r">
							<br>
							<label>NOMBRE BANCO</label>
							<br>
							<input type="text" name="nom-ban-r">
							<br>
							<button class="btn btn-primary btn-group-justified">enviar</button>
						</td>
					</tr>
				</table>
		</FORM>
	</ASIDE>
</section>	

<?php 
modelo::abajo(dirname(__FILE__));
?>

</html>