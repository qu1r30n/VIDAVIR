<?php
	class op_b
	{
		
		public function crear_bd($nombre)
		{
			include("var_g.php");

			$connection = mysqli_connect($arr_servername_VG[0],$arr_username_VG[0],$arr_password_VG[0]);
   
		   	if (!$connection) 
		   	{
		      die('Could not connect: ' . mysqli_error());
		   	}
		   
		   	$sql = 'CREATE DATABASE '.$nombre;
		   
		   	if (mysqli_query($connection,$sql)) 
		    {
		      echo "Database my_db created successfully\n";
		    } 
		    else 
		    {
		      echo 'Error creating database: ' . mysqli_error() . "\n";
		    }
		    mysqli_close($connection);
		}

		public function crear_tab($nombre_bd,$nom_tab,$arr_col,$arr_tip,$arr_cant,$col_indice,$arr_aut_inc)
		{
			$columnas="";
			include("var_g.php");
			$connection = mysqli_connect($arr_servername_VG[0],$arr_username_VG[0],$arr_password_VG[0],$nombre_bd);
			$cantidad_columnas=count($arr_col);
		   if (!$connection) 
		   {
		      die('Could not connect: ' . mysqli_error());
		   }

		   for ($i=0; $i < $cantidad_columnas ; $i++) 
		   {

		   		
		   		if ($i==$col_indice)
		   		{
		   			$columnas=$columnas.$arr_col[$i]." ".$arr_tip[$i]."(".$arr_cant[$i].") PRIMARY KEY ";
		   		}
		   		else
		   		{
		   			$columnas=$columnas.$arr_col[$i]." ".$arr_tip[$i]."(".$arr_cant[$i].") ";
		   		}

		   		if ($i < $cantidad_columnas-1)
		   		{
		   			if ($arr_aut_inc[$i] == 1)
			   		{
			   			$columnas=$columnas." AUTO_INCREMENT ,";
			   		}
			   		else
			   		{
			   			$columnas=$columnas.",";
			   		}
		   		}
		   		else 
		   		{
		   			if ($arr_aut_inc[$i] == 1)
			   		{
			   			$columnas=$columnas." PRIMARY KEY";
			   		}
			   		else
			   		{
			   			$columnas=$columnas;
			   		}
		   		}
		   		

		   		
		   }

		   $sql ="create table ".$nom_tab."( ".$columnas.");";
		   echo "<br>".$sql;
		   mysqli_query($connection,$sql);
		   mysqli_close($connection);
		}

		function mysql_table_existe($tableName)
		{
			include("var_g.php"); 
			$conn=mysqli_connect($arr_servername_VG[0],$arr_username_VG[0],$arr_password_VG[0]);
			//-------------------------------------------------------
			$result = mysqli_query($conn,"SHOW TABLES FROM ".$arr_database_VG[0]." LIKE '".$tableName."';");
			mysqli_close($conn);
	        if($result->num_rows >= 1) 
			{
				return "true";
			}
			else
			{
				return "false";
			}

		}


		public function seleccionar($sele,$fro,$wer)
		{
			include("var_g.php"); 
			$conn=mysqli_connect($arr_servername_VG[0],$arr_username_VG[0],$arr_password_VG[0],$arr_database_VG[0]);
			//-------------------------------------------------------
			$consulta="SELECT".$sele."FROM ".$fro." WHERE ".$wer;
			echo $consulta."<br>";
			$resultados=mysqli_query($conn,$consulta);
			$dat_us=mysqli_fetch_row($resultados);
			//--------------------------------------------------------
			mysqli_close($conn);	
			return $dat_us;
		}


		public function insertar($nom_tab,$arr_colum,$arr_valores)
		{
			include("var_g.php"); 
			$cantidad_columnas=count($arr_colum);
			$cantidad_valores=count($arr_valores);
			//-- comando insert ----------------------------------------------------------------------------------
			$insertar = "INSERT INTO ".$nom_tab." (";
			for ($i=0; $i < $cantidad_columnas; $i++)
			{ 
				if($i<$cantidad_columnas-1)
				{
					$insertar=$insertar.$arr_colum[$i].", ";
				}
				else
				{
					$insertar=$insertar.$arr_colum[$i].") VALUES ('";
				}
			}
			for ($i2=0; $i2 < $cantidad_valores ; $i2++) 
			{ 
				if($i2<$cantidad_valores-1)
				{
					$insertar=$insertar.$arr_valores[$i2]."','";
				}
				else
				{
					$insertar=$insertar.$arr_valores[$i2]."');";
				}	
			}
			//----------------------------------------------------------------------------------
			echo "<br><br><br>".$insertar."<br><br><br>";
			$conexion = mysqli_connect($arr_servername_VG[0],$arr_username_VG[0],$arr_password_VG[0],$arr_database_VG[0]);
			mysqli_query($conexion,$insertar);
			mysqli_close($conexion);
		}


		public function editar($nom_tab,$arr_colum,$arr_valores,$arr_colum2,$compara,$arr_valores2,$op_log)
		{
			include("var_g.php"); 
			//- comando eidtar ------------------------------------------------------------------------------
			$cantidad_columnas=count($arr_colum);
			$cantidad_valores=count($arr_valores);
			$cantidad_columnas2=count($arr_colum2);
			$cantidad_compara=count($compara);
			$cantidad_valores2=count($arr_valores2);
			$cantidad_op_log=count($op_log);

			$editar = "UPDATE ".$nom_tab." SET ";
			for ($i=0; $i < $cantidad_columnas; $i++)
			{ 
				if($i<$cantidad_columnas-1)
				{
					$editar=$editar.$arr_colum[$i]."= ".$arr_valores[$i].", ";
				}
				else
				{
					$editar=$editar.$arr_colum[$i]."= ".$arr_valores[$i]." WHERE";
				}
			}

			for ($i=0; $i < $cantidad_columnas2; $i++)
			{ 
				if($i<$cantidad_columnas2-1)
				{
					$editar=$editar." ".$arr_colum2[$i]." ".$compara[$i]." ".$arr_valores2[$i]." ".$op_log[$i];
				}
				else
				{
					$editar=$editar." ".$arr_colum2[$i]." = ".$arr_valores2[$i].";";
				}
			}
			echo "<br><br><br><br>".$editar."<br><br><br><br>";
			//----------------------------------------------------------------------------------------- 
			$conexion = mysqli_connect($arr_servername_VG[0],$arr_username_VG[0],$arr_password_VG[0],$arr_database_VG[0]);
			mysqli_query($conexion,$editar);
			mysqli_close($conexion);
		}

		public function eliminar($nom_tab,$id)
		{
			include("var_g.php"); 
			$comando="DELETE FROM ".$nom_tab." WHERE id = " . $id;
			$conexion = mysqli_connect($arr_servername_VG[0],$arr_username_VG[0],$arr_password_VG[0],$arr_database_VG[0]);
			mysqli_query($conexion,$comando);
			mysqli_close($conexion);
		}
	}
?>