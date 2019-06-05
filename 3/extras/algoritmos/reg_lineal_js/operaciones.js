var cont=0;
var x=0;//acumulador de todas las x
var y=0;//acumulador de todas las y
var xy=0;//acumulador de todas las xy
var x__2=0;////acumulador de todas las x elevado a la 2
var y__2=0;////acumulador de todas las y elevado a la 2
var divisor=0;
var dividendo=0;
var total_formula=0;

function obtencion_datos(txt_datos)
{
    var arr_datos=txt_datos.split("\n");
    for (i=0; i < arr_datos.length ; i++)
    {
        if (arr_datos[i]) 
        {
            var arr_xoy=arr_datos[i].split(",");
            arr_xoy[0]=parseFloat(arr_xoy[0]);
            arr_xoy[1]=parseFloat(arr_xoy[1]);
            if (!isNaN(arr_xoy[0]) && !isNaN(arr_xoy[1])) 
            {
                cont=cont+1;
                x=x+arr_xoy[0];
                y=y+arr_xoy[1];
                xy=xy+(arr_xoy[0]*arr_xoy[1]);
                x__2=x__2+(arr_xoy[0]*arr_xoy[0]);
                y__2=y__2+(arr_xoy[1]*arr_xoy[1]);
            }
        }
    }
    alert("x="+x+"\ny="+y+"\nxy="+xy+"\nx__2="+x__2+"\ny__2="+y__2+"\n");
}


function coeficiente_correlacion(txt_datos)
{
	alert("hola2");
    obtencion_datos(txt_datos);
    divisor=(cont*xy)-(x*y);
    dividendo=Math.sqrt((cont*x__2)-(x*x))*Math.sqrt((cont*y__2)-(y*y));
    alert("divisor  (cont*xy)-(x*y)   : "+divisor+"\n----------------------------------\ndividendo  Math.sqrt((cont*x__2)-(x*x))*Math.sqrt((cont*y__2)-(y*y))  : "+dividendo);
    total_formula=(divisor/dividendo);
    alert("\n"+total_formula);
}

function m_pendiente_op(txt_datos)
{
	var c1=(cont*x__2);
	alert(c1);
	var c2=(x*x);
	alert(c2);
	divisor=(cont*xy)-(x*y);
	dividendo=(cont*x__2)-(x*x);
	alert("(cont*xy)-(x*y)   : "+divisor+"\n----------------------------------\n(cont*x__2)-(x*x) : "+dividendo);
	total_formula=divisor/dividendo;
	alert(total_formula);
}
function m_pendiente(txt_datos)
{
    if (cont==0) 
    {
        obtencion_datos(txt_datos);
        m_pendiente_op(txt_datos);
    }
    else
    {
    	m_pendiente_op(txt_datos);
    }
}

function b_term_independiente_op(txt_datos)
{
	divisor=(y*x__2)-(x*xy);
	dividendo=(cont*x__2)-(x*x);
	alert("divisor  (y*x__2)-(x*(x*y)   : "+divisor+"\n----------------------------------\ndividendo  (cont*x__2)-(x*x) : "+dividendo);
    total_formula=(divisor/dividendo);
    alert("\n"+total_formula);
}

function b_term_independiente(txt_datos)
{
	if (cont==0) 
    {
        obtencion_datos(txt_datos);
        b_term_independiente_op(txt_datos);
    }
    else
    {
    	b_term_independiente_op(txt_datos);
    }
}

function regresión_lineal(txt_datos,z) 
{
	m_pendiente(txt_datos);
	var m=total_formula;
	b_term_independiente(txt_datos);
	var b=total_formula;
    alert("m="+m+"\nb="+b+"\nz="+z);
	var y=(m*z)+b;

    alert("resultado regresin: "+y )
}