<?php
//-VARIABLES Y OPERACIONES_B----------------------------------------------------
	include("var_g.php");
	include("operaciones_b.php");

//-INFORMACION DE ENTRADA------------------------------------------------
	$id_patro_r=$_POST['id_patro-r'];
	$password_r_r=$_POST['pass-r'];
	$nom_r=$_POST['nombre-r'];
	$ap_p_r=$_POST['ap-p-r'];
	$ap_m_r=$_POST['ap-m-r'];
	$fecha_nacimiento_r=$_POST['fecha-nacimiento-r'];
	$pais_r=$_POST['pais-r'];
	$estado_r=$_POST['estado-r'];
	$dinero_r=$_POST['dinero-r'];
	$municipio_r=$_POST['municipio-r'];
	$colonia_r=$_POST['colonia-r'];
	$direccion_r=$_POST['direccion-r'];
	$tel_r=$_POST['tel-r'];
	$num_cuen_r=$_POST['num-cue-r'];
	$nom_ban_r=$_POST['nom-ban-r'];
	$num_tab_PAT=$_POST['tab-pat-reg'];
	$tabla_PAT=$arr_tabla_usar_sistema_VG[$num_tab_PAT];
	$num_tab=$_POST['curso_t'];
	$tabla=$arr_tabla_usar_sistema_VG[$num_tab];
//--SELECCIONA TOTAL NIVEL DE USUARIOS Y NIVEL-----------------------------------------------------
$total_niv_us=op_b::seleccionar("*","total_niv_us","id=1");
//--SELECCIONA TODOS LOS DATOS DEL PATROCINADOR----------------------------------------------------
$dat_pat=op_b::seleccionar("*",$tabla,"id=".$id_patro_r);
//---SI NIVEL DEL PATROCINADOR LE SUMAS 1 Y ES MAYOR AL TOTAL DE NIVELES ENTONES-----------------
if (($dat_pat[7]+1)>$total_niv_us[2])
{


//--EDITA TOTAL DE ID'S Y TOTAL DE NIVELES EN TABLA TOT_NIV_US ----------------------------------------
	$colum[0]="ID_TOTAL_VERTICAL";
	$valores[0]=($total_niv_us[1]+1);
	$colum[1]="TOTAL_NIVEL_VERTICAL";
	$valores[1]=($total_niv_us[2]+1);
	$colum2[0]="id";
	$compara[0]="==";
	$valores2[0]="1";
	$op_log[0]="";


	op_b::editar("total_niv_us",$colum,$valores,$colum2,$compara,$valores2,$op_log);
//--INSERTA UN NUEVO NIVEL EN TABLA TOTAL_HOR ---------------------------------------------------------
	$h0colum[0]="NIVEL_reg";
	$h0valores[0]=($dat_pat[7]+1);
	$h0colum[1]="ID_TOTAL_HORISONTAL";
	$h0valores[1]="1";

	op_b::insertar("total_hor",$h0colum,$h0valores);
//-------------------------------------------------------------------------------------------------------
}

else
{
//---AUMENTA UNO AL ID_TOTAL_VERTICAL Y DEJA NORMAL EL TOTAL NIVEL EN LA TABLA TOTAL_NIV_US ----------------
	$colum[0]="ID_TOTAL_VERTICAL";
	$valores[0]=($total_niv_us[1]+1);
	$colum[1]="TOTAL_NIVEL_VERTICAL";
	$valores[1]=($total_niv_us[2]);
	$colum2[0]="id";
	$compara[0]="==";
	$valores2[0]="1";
	$op_log[0]="";
	
	op_b::editar("total_niv_us",$colum,$valores,$colum2,$compara,$valores2,$op_log);
//---SELECCIONA TODO DE LA TABLA TOTAL_HOR DEL NIVEL DEL USUARIO O NIVEL DESPUES DE DATOS DEL PATROCINADOR ---
	$tot_hor=op_b::seleccionar("*","total_hor","id=".($dat_pat[7]+1));
//--AUMENTA EL ID_TOTAL_HORISONTAL DLE NIVEL QUE LE SIGUE AL PATROSINADOR O DEL USUARIO--------------------------
	$hcolum[0]="ID_TOTAL_HORISONTAL";
	$hvalores[0]=($tot_hor[2]+1);
	$hcolum2[0]="NIVEL_reg";
	$hcompara[0]="==";
	$hvalores2[0]=($dat_pat[7]+1);
	$hop_log[0]="";

	op_b::editar("total_hor",$hcolum,$hvalores,$hcolum2,$hcompara,$hvalores2,$hop_log);
//-----------------------------------------------------------------------------------------------------------------
}
//--SELECCIONA TODO DE TOTAL_HOR DEL NIVEL DEL USUARIO O LO QUE ES IGUAL EL NIVEL QUE LE SIGUE AL PATROCINADOR -
$tot_hor=op_b::seleccionar("*","total_hor","id=".($dat_pat[7]+1));
//--SELECCIONA EL TOTAL DE NIVELES Y TOTAL DE USURIOS QUE ES LO QUE TIENE ESA TABLA -----------------------
$total_niv_us=op_b::seleccionar("*","total_niv_us","id=1");
//--INSERTA EL USUARIO-----------------------------------------------------

$icolum[0]= "id";
$ivalor[0]= "NULL";
$icolum[1]= "NOM_TABLA_USU";
$ivalor[1]= $tabla;
$icolum[2]= "NOM_TAB_PAT";
$ivalor[2]= $tabla_PAT;
$icolum[3]= "ID_PATRO";
$ivalor[3]= $id_patro_r;
$icolum[4]= "1_LINEA";
$ivalor[4]= $id_patro_r;
$icolum[5]= "2_LINEA";
$ivalor[5]= $dat_pat[4];
$icolum[6]= "3_LINEA";
$ivalor[6]= $dat_pat[5];
$icolum[7]= "NIVEL";
$ivalor[7]= ($dat_pat[7]+1);
$icolum[8]= "DINERO";
$ivalor[8]= $dinero_r;
$icolum[9]= "SE_PAGARA";
$ivalor[9]= "0";
$icolum[10]= "PUNTOS";
$ivalor[10]= "0";
$icolum[11]= "ID_NIVEL_HORISONTAL";
$ivalor[11]= $tot_hor[2];
$icolum[12]= "NOMBRE";
$ivalor[12]= $nom_r;
$icolum[13]= "APELLIDO_P";
$ivalor[13]= $ap_p_r;
$icolum[14]= "APELLIDO_M";
$ivalor[14]= $ap_m_r;
$icolum[15]= "DIRECCION";
$ivalor[15]= $direccion_r;
$icolum[16]= "CIUDAD";
$ivalor[16]= $municipio_r;
$icolum[17]= "ESTADO";
$ivalor[17]= $estado_r;
$icolum[18]= "COLONIA";
$ivalor[18]= $colonia_r;
$icolum[19]= "PAIS";
$ivalor[19]= $pais_r;
$icolum[20]= "TELEFONO";
$ivalor[20]= $tel_r;
$icolum[21]= "FECHA_DE_NACIMIENTO";
$ivalor[21]= $fecha_nacimiento_r;
$icolum[22]= "NUMERO_CUENTA";
$ivalor[22]= $num_cuen_r;
$icolum[23]= "NOMBRE_DE_BANCO";
$ivalor[23]= $nom_ban_r;
$icolum[24]= "GERARQUIA";
$ivalor[24]= "2";
$icolum[25]= "SAP";
$ivalor[25]= $password_r_r;

op_b::insertar($tabla,$icolum,$ivalor);

?>