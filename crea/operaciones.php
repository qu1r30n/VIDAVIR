<?php
class Create_database
{
	protected $pdo;
	
	public function __construct()
	{

		include("../var_g.php");
		$this->pdo = new PDO("mysql:host=".$arr_servername_VG[0].";",$arr_username_VG[0],$arr_password_VG[0] );
	}
	//creamos la base de datos y las tablas que necesitemos
	public function my_db()
	{
        //creamos la base de datos si no existe
		$crear_db = $this->pdo->prepare('CREATE DATABASE IF NOT EXISTS QU1R30N COLLATE utf8_spanish_ci');
		$crear_db->execute();
		
		//decimos que queremos usar la tabla que acabamos de crear
		if($crear_db):
		$use_db = $this->pdo->prepare('USE QU1R30N');
		$use_db->execute();
		endif;
//--------------------------------------------------------------------------------------------------
		//si se ha creado la base de datos y estamos en uso de ella creamos las tablas
		if($use_db):
		//creamos la tabla usuarios
		$crear_tb_users = $this->pdo->prepare('
						CREATE TABLE IF NOT EXISTS SISTEMA (
						id int(11) NOT NULL AUTO_INCREMENT,
						NOM_TABLA_USU varchar(100) COLLATE utf8_spanish_ci NOT NULL,
						NOM_TAB_PAT varchar(100) COLLATE utf8_spanish_ci NOT NULL,
						ID_PATRO varchar(100) COLLATE utf8_spanish_ci NOT NULL,
						1_LINEA varchar(100) COLLATE utf8_spanish_ci NOT NULL,
						2_LINEA varchar(100) COLLATE utf8_spanish_ci NOT NULL,
						3_LINEA varchar(100) COLLATE utf8_spanish_ci NOT NULL,
						NIVEL varchar(100) COLLATE utf8_spanish_ci NOT NULL,
						DINERO varchar(100) COLLATE utf8_spanish_ci NOT NULL,
						SE_PAGARA varchar(100) COLLATE utf8_spanish_ci NOT NULL,
						PUNTOS varchar(100) COLLATE utf8_spanish_ci NOT NULL,
						ID_NIVEL_HORISONTAL varchar(100) COLLATE utf8_spanish_ci NOT NULL,
						NOMBRE varchar(100) COLLATE utf8_spanish_ci NOT NULL,
						APELLIDO_P varchar(100) COLLATE utf8_spanish_ci NOT NULL,
						APELLIDO_M varchar(100) COLLATE utf8_spanish_ci NOT NULL,
						DIRECCION varchar(100) COLLATE utf8_spanish_ci NOT NULL,
						CIUDAD varchar(100) COLLATE utf8_spanish_ci NOT NULL,
						ESTADO varchar(100) COLLATE utf8_spanish_ci NOT NULL,
						COLONIA varchar(100) COLLATE utf8_spanish_ci NOT NULL,
						PAIS varchar(100) COLLATE utf8_spanish_ci NOT NULL,
						TELEFONO varchar(100) COLLATE utf8_spanish_ci NOT NULL,
						FECHA_DE_NACIMIENTO varchar(100) COLLATE utf8_spanish_ci NOT NULL,
						NUMERO_CUENTA varchar(100) COLLATE utf8_spanish_ci NOT NULL,
						NOMBRE_DE_BANCO varchar(100) COLLATE utf8_spanish_ci NOT NULL,
						GERARQUIA varchar(100) COLLATE utf8_spanish_ci NOT NULL,
						SAP varchar(100) COLLATE utf8_spanish_ci NOT NULL,
						PRIMARY KEY (id)
					    )');
		$crear_tb_users->execute();
//----------------------------------------------------------------------
		$crear_id_niv_tot = $this->pdo->prepare('
						CREATE TABLE IF NOT EXISTS TOTAL_NIV_US (
						id int(11) NOT NULL AUTO_INCREMENT,
						ID_TOTAL_VERTICAL varchar(100) COLLATE utf8_spanish_ci NOT NULL,
						TOTAL_NIVEL_VERTICAL varchar(100) COLLATE utf8_spanish_ci NOT NULL,				
						PRIMARY KEY (id)
					    )');
		$crear_id_niv_tot->execute();
//----------------------------------------------------------------------
		$crear_to_horisont = $this->pdo->prepare('
						CREATE TABLE IF NOT EXISTS TOTAL_HOR (
						id int(11) NOT NULL AUTO_INCREMENT,
						NIVEL_reg varchar(100) COLLATE utf8_spanish_ci NOT NULL,
						ID_TOTAL_HORISONTAL varchar(100) COLLATE utf8_spanish_ci NOT NULL,
						PRIMARY KEY (id)
					    )');
		$crear_to_horisont->execute();
//----------------------------------------------------------------------

		endif;
	}
}
//ejecutamos la función my_db para crear nuestra bd y las tablas
$db = new Create_database();
$db->my_db();
?>