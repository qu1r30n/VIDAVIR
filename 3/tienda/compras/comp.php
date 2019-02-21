<?php  
include("../../../modelo.php");
$dir_raiz=modelo::root_path(dirname(__FILE__));
include($dir_raiz."operaciones_tienda.php");

$arr_codigos=$_POST["arr_codi2"];
operaciones_tienda::compras($arr_codigos);

?>