<?php
	//--OPERACIONES BASE----------------------------------------------------
	include("../var_g.php");
	include("../operaciones_b.php");
	//--DATOS DE CONTROL--------------------------------------------------------
	$minimo_comp_usuario=0;
	$minimo_comp=0;
	$des_porce_usuario=0;
	$com_niv_pat=0;
	$com_niv1=10;
	$com_niv2=10;
	$com_niv3=10;

	//--CONSIGUE DATOS QUE ES EL ID Y EL DIN-PAPAGOS -----------------------------------------------
	$id_p=$_POST['id-p'];
	$din_p=$_POST['din-p'];
	$num_tab=$_POST['curso_t'];
	$tabla=$arr_tabla_usar_sistema_VG[$num_tab];
	
	//--FUNCION PARA HACER EL PAGO DE COMICION-----------------------------------------------------
	function comision($nom_tab,$id,$din,$porcen)
	{
		$dat_us=op_b::seleccionar("*",$nom_tab,"id=".$id);
		$se_pagara=$din*($porcen/100);
		$colum[0]="SE_PAGARA";
		$valores[0]=$dat_us[9]+$se_pagara;
		$colum2[0]="ID";
		$compara[0]="==";
		$valores2[0]=$id;
		$op_log[0]="";
		op_b::editar($nom_tab,$colum,$valores,$colum2,$compara,$valores2,$op_log);
	}
	//--FUNCION PARA LA COMPRA SIN COMICION--------------------------------
	function compra($nom_tab,$id,$din)
	{
		$dat_us=op_b::seleccionar("*",$nom_tab,"id=".$id);
		$dinero=$din+$dat_us[8];
		$colum[0]="DINERO";
		$valores[0]=$dinero;
		$colum2[0]="ID";
		$compara[0]="==";
		$valores2[0]=$id;
		$op_log[0]="";
		op_b::editar($nom_tab,$colum,$valores,$colum2,$compara,$valores2,$op_log);
	}
	//--SACA LOS DATOS DE USUARIO,PATROCINADOR, NIVEL 1,2,3----------------------------------------------
		
		$dat_us=op_b::seleccionar("*",$tabla,"id=".$id_p);
		$dat_pat=op_b::seleccionar("*",$dat_us[2],"id=".$dat_us[3]);
		$dat_l1=op_b::seleccionar("*",$dat_us[1],"id=".$dat_us[4]);
		$dat_l2=op_b::seleccionar("*",$dat_us[1],"id=".$dat_us[5]);
		$dat_l3=op_b::seleccionar("*",$dat_us[1],"id=".$dat_us[6]);

	//--COMICIONES-----------------------------------------------------------------------
		if ($dat_us[2]!=$dat_us[1])// si la tabla del patrocinador y la del usuario son diferentes le da la comicion a patrocinador si no no por que si son iguales el nivel1 y el patrosinador serian la misma persona y le tocaria doble pago
		{
			if ($dat_us[8]>=$minimo_comp_usuario) //SI ES MAYOR O IGUAL AL MINIMO DE COMPRA HACE SU DESCUENTO
			{
				$costo=$din_p-($din_p*($des_porce_usuario/100));//LE RESTA EL DESCUENTO
				compra($dat_us[1],$dat_us[0],$costo);//LO PASA A DONDE VA EL DINERO
				comision($dat_us[1],$dat_us[0],$din_p,$des_porce_usuario);//PASA LA COMICION EN EL PAGO DE COMICION
			}
			else//SI NO PASA DIRECTO LA COMPRA A DONDE VA EL DINERO SIN EL DESCUENTO
			{
				compra($dat_us[1],$dat_us[0],$din_p);
			}
			
			if ($dat_pat[8]>=$minimo_comp) //SI EL PATROCINADOR TIENE IGUAL O MAYOR EL MINIMO D COMPRA TENDRA LA COMICION
			{
				comision($dat_pat[1],$dat_pat[0],$din_p,$com_niv_pat);
			}
			
			if ($dat_l1[8]>=$minimo_comp) //SI EL NIVEL1 TIENE IGUAL O MAYOR EL MINIMO D COMPRA TENDRA LA COMICION
			{
				comision($dat_l1[1],$dat_l1[0],$din_p,$com_niv1);
			}
			if ($dat_l2[8]>=$minimo_comp) //SI EL NIVEL2 TIENE IGUAL O MAYOR EL MINIMO D COMPRA TENDRA LA COMICION
			{
				comision($dat_l2[1],$dat_l2[0],$din_p,$com_niv2);
			}
			if ($dat_l3[8]>=$minimo_comp) //SI NIVEL3 TIENE IGUAL O MAYOR EL MINIMO D COMPRA TENDRA LA COMICION
			{
				comision($dat_l3[1],$dat_l3[0],$din_p,$com_niv3);
			}
		}

		else//son iguales la tabla del usuario y patrocinador entonces son la misma persona el patrocinador y el nivel1 poreso no se le da comicion al patrocinador
		{
			if ($dat_us[8]>=$minimo_comp_usuario) //SI ES MAYOR O IGUAL AL MINIMO DE COMPRA HACE SU DESCUENTO
			{
				$costo=$din_p-($din_p*($des_porce_usuario/100));//LE RESTA EL DESCUENTO
				compra($dat_us[1],$dat_us[0],$costo);//LO PASA A DONDE VA EL DINERO
				comision($dat_us[1],$dat_us[0],$din_p,$des_porce_usuario);//PASA LA COMICION EN EL PAGO DE COMICION
			}
			else//SI NO PASA DIRECTO LA COMPRA A DONDE VA EL DINERO SIN EL DESCUENTO
			{
				compra($dat_us[1],$dat_us[0],$din_p);
			}
			
			if ($dat_l1[8]>=$minimo_comp) //SI EL NIVEL1 TIENE IGUAL O MAYOR EL MINIMO D COMPRA TENDRA LA COMICION
			{
				comision($dat_l1[1],$dat_l1[0],$din_p,$com_niv1);
			}
			if ($dat_l2[8]>=$minimo_comp) //SI EL NIVEL2 TIENE IGUAL O MAYOR EL MINIMO D COMPRA TENDRA LA COMICION
			{
				comision($dat_l2[1],$dat_l2[0],$din_p,$com_niv2);
			}
			if ($dat_l3[8]>=$minimo_comp) //SI NIVEL3 TIENE IGUAL O MAYOR EL MINIMO D COMPRA TENDRA LA COMICION
			{
				comision($dat_l3[1],$dat_l3[0],$din_p,$com_niv3);
			}
		}
	//--YA UNAVES LOS DATOS AN SIDO MODIFICADOS VOLVERLOS A GUARDAR PARA POSTERIORES REVICIONES-----------------
		$dat_us=op_b::seleccionar("*",$tabla,"id=".$id_p);
		$dat_pat=op_b::seleccionar("*",$dat_us[2],"id=".$dat_us[3]);
		$dat_l1=op_b::seleccionar("*",$dat_us[1],"id=".$dat_us[4]);
		$dat_l2=op_b::seleccionar("*",$dat_us[1],"id=".$dat_us[5]);
		$dat_l3=op_b::seleccionar("*",$dat_us[1],"id=".$dat_us[6]);
	//-------------------------------------------------------------------------

?>