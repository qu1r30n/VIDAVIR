<?php

$cont=0;
$x=0;//acumulador de todas las x
$y=0;//acumulador de todas las y
$xy=0;//acumulador de todas las xy
$x__2=0;////acumulador de todas las x elevado a la 2
$y__2=0;////acumulador de todas las y elevado a la 2
$divisor=0;
$dividendo=0;

function obtencion_datos($txt_datos)
{
    global $cont,$x,$y,$xy,$x__2,$y__2,$divisor,$dividendo;   
    $arr_datos=explode("\n",$txt_datos);
    for ($i=0; $i < count($arr_datos) ; $i++)
    {
        if ($arr_datos[$i]) 
        {
            $arr_xoy=explode(",",$arr_datos[$i]);
            if (is_numeric($arr_xoy[0]) && is_numeric($arr_xoy[1])) 
            {
                $cont=$cont+1;
                $x=$x+$arr_xoy[0];
                $y=$y+$arr_xoy[1];
                $xy=$xy+($arr_xoy[0]*$arr_xoy[1]);
                $x__2=$x__2+($arr_xoy[0]*$arr_xoy[0]);
                $y__2=$y__2+($arr_xoy[1]*$arr_xoy[1]);
            }
        }
    }
    echo("x=".$x."<br>y=".$y."<br>xy=".$xy."<br>x__2=".$x__2."<br>y__2=".$y__2."<br>");
}

function coeficiente_correlacion($txt_datos)
{
    obtencion_datos($txt_datos);
    global $cont,$x,$y,$xy,$x__2,$y__2,$divisor,$dividendo;
    $divisor=($cont*$xy)-($x*$y);
    echo("coeficiente de correlacion");// formula  https://scontent.fmex10-2.fna.fbcdn.net/v/t1.0-9/58419948_2010770322378171_1229097190597591040_n.jpg?_nc_cat=103&_nc_ht=scontent.fmex10-2.fna&oh=e9ecf1197eed8ecc4639deb722bf67a6&oe=5D2CDBA8
    echo("divisor  ($cont*$xy)-($x*$y)   : ".$divisor."<br>");

    $dividendo=SQRT(($cont*$x__2)-($x*$x))*SQRT(($cont*$y__2)-($y*$y));
    echo("dividendo  SQRT(($cont*$x__2)-($x*$x))*SQRT(($cont*$y__2)-($y*$y))  = ".$dividendo);

    $total_formula=($divisor/$dividendo);
    echo("<br>".$total_formula);
    return $total_formula;
}

function m_pendiente_op()
{
    # code...
}
function m_pendiente($txt_datos)
{
    if ($cont==0) 
    {
        obtencion_datos($txt_datos);
    }
}

function b_termino_independiente($txt_datos)
{

}

function regresión_lineal($txt_datos)
{
    global $cont,$x,$y,$xy,$x__2,$y__2,$divisor,$dividendo;
    coeficiente_correlacion($txt_datos);
}


$dat="1,23\n5,18\n7,17";

?>