 $(document).on('ready', funcMain);
 $(document).on('ready', loop); // tengo que cargar primero la forma asincrona de checar donde esta el archivo
 								//se usa para sacar normalmente dondeesta la raiz de mis archivos
 								//pd: fue horrible crear este metodo para que funcionara
 								//se usa este metodo por que el metodo sincrono lo van a quitar
 								//pero sigue funcionando la funcion es raiz(); 

let arr_lines;// es un arregol se usa en la funcion carga y la funcion buscar se usa para guardar el contenido del txt
var arr_encontrados;//es un arreglo se usa en la funcion buscar y guarda los elementos encontrados


var bandera=0;//se usa para la funcion loop y sirve para que cuando es encontrado ela archivo en la funcion recursiva no siga haciedo otras operaciones
var cantidad_carp="";//se usa para la funcion loop y sirve para guardar los ../../../ para regresar el numero de carpetas
var arch = "js/invoice.js";//se usa para la funcion loop y este es el archivo abuscar
var contador_ciclos=0;//se usa para saber cuantos ciclos recursibos y pararlo  para que no sea infinito
var devolver="";//se usa para la funcion loop y aqui se guarda los ../../../../ definitivos para llegar a la al archivo que buscamos

function loop() //es una funcion recursiba funcion asincrona de request para sacar el numero
{
	// alert("entro funcion loop");      //chequeo si entro a la funcion
	var request = new XMLHttpRequest();  // crea la variable tipo request
	var url = cantidad_carp+arch;//guarda cada las variable que ese modificaran en cada ciclo recursivo "ES UNA FUNCION RECURSIBA LA FUNCION LOOP" 
	var url2= cantidad_carp;//todo esto es por que es un metodo asincrono lo use asi creo que se puede optimisar el codigo pero mellevo algo de tiempo que me canse y lo deje asi

	if (contador_ciclos >= 6) //sirve para que no el ciclo recursivo no sea infinito y se pueda salir
	{
		//alert("contador_ciclos: "+contador_ciclos);   //chequeo si paro el ciclado
		return;
	}
	contador_ciclos=contador_ciclos+1;

	request.open("HEAD", url);
	request.onreadystatechange = function() 
	{
		if(request.readyState === XMLHttpRequest.DONE && request.status === 200) 
		{

			bandera=1;
			//alert("encontrado:"+url);  //muestra la ruta que de donde se encuentra el archivoencontrado:../../../js/invoice.js
			//alert("url2: "+url2)		//muestra la cantidad de carpetas  url2: ../../../
			devolver=url2;
			//alert("devolver"+devolver);		// muestra lo que guardo devolver que es la variable que se utilisara
			carga();
			
		}
		else
		{
			cantidad_carp="../"+cantidad_carp;
			loop();
		}
	}
	request.send();
	return;
}




function raiz()
{
 	var temp0="";
 	var cont=0;
 	for (var i = 0; i < 20; i++) 
 	{
 		var http = new XMLHttpRequest();
   		http.open('HEAD',arch+temp0, false);
   		http.send();
   		if (http.status!=404) 
   		{
   			break;
   		} 
   		else 
   		{
   			temp0="../"+temp0;
   		}
   		
 	}
 	return temp0;
}




function carga()
{
	//alert("entro a carga: "+ devolver);  //checa si si tienle contenido la variable devolver   entro a carga: ../../../
	alert("raiz sincrona aun funge si aparese ../  o mas:  "+raiz()) // este es el metodo sincrono  se puede intercanviar en la linea de abajo con la variable devolver
								// quedaria asi si lo intercanvias //fetch(raiz() +'6.txt')
	//fetch(raiz() +'6.txt')//carga la el archivo 6.txt metodo sincrono  // posdata el metodo sincrono en un futuro dejara de servir
	fetch(devolver +'6.txt')//carga la el archivo 6.txt metodo metodo asincrono
  	.then(res => res.text())
  	.then(content => 
  	{
    	arr_lines = content.split(/\n/);//splitea el achivo
    	arr_lines.forEach(arr_lines => console.log(line));//esto solo sirve para visualisarlo en el console lo puedes quitar
  	});	
}

function buscar(texto)
{
	var busqueda=[texto];
	var acumulador=["0"];
	var arreglo;
	var contador=0;
	for (var i = 0; i < arr_lines.length; i++) //pasa por todas las lineas
	{
	arreglo=arr_lines[i].split("&");//splitea la linea con & y la agrega en arreglo temporal para ser comparada
		if (busqueda[0]==arreglo[0]) //digamos que uno es por codigo y el siguiente else if es por nombre
		{

			acumulador[contador]=arr_lines[i];//si si lo va agregando en u arreglo
			contador++;//aumenta para la siguiente celda que sea agregada
		}
		/* buscar en otra parte del arreglo
						else if (busqueda[0]==arreglo[1]) //digamos que aqui lo compara por el nombre
						{
							acumulador[contador]=arreglo[i];//si si lo va agregando en u arreglo
							contador++;//aumenta para la siguiente celda que sea agregada
							}
	   */
	}
	if (contador>0) //si encontro 
	{
		arr_encontrados=acumulador;// pasa lo de el arreglo acumulado a arr_encontrados
	}
}

function funcMain()
{
	$("#add_row").on('click',newRowTable);

	$("loans_table").on('click','.fa-eraser',deleteProduct);
	
	$("body").on('click',".fa-eraser",deleteProduct);
}


function funcEliminarProductosso()
{
	//Obteniendo la fila que se esta eliminando
	var a=this.parentNode.parentNode;
	//Obteniendo el array de todos loe elementos columna en esa fila
	//var b=a.getElementsByTagName("td");
	var cantidad=a.getElementsByTagName("td")
	console.log(a);

	$(this).parent().parent().fadeOut("slow",function(){$(this).remove();});
}


function deleteProduct()
{
	//Guardando la referencia del objeto presionado
	var _this = this;
	//Obtener las filas los datos de la fila que se va a elimnar
	var array_fila=getRowSelected(_this);

	//Restar esos datos a los totales mostrados al finales
	//calculateTotals(cantidad, precio, subtotal, impuesto, totalneto, accioneliminar)
	calculateTotals(array_fila[3],array_fila[4],array_fila[5],array_fila[6],array_fila[7],2)

	$(this).parent().parent().fadeOut(0,function(){$(this).remove();});
}


function editProduct()
{
	var _this = this;
	var array_fila=getRowSelected(_this);
	console.log(array_fila[0]+" - "+array_fila[1]+" - "+array_fila[2]+" - "+array_fila[3]+" - "+array_fila[4]+" - "+array_fila[5]+" - "+array_fila[6]+" - "+array_fila[7]);
	//Codigo de editar una fila lo pueden agregar aqui
}



function getRowSelected(objectPressed)
{
	//Obteniendo la linea que se esta eliminando
	var a=objectPressed.parentNode.parentNode;
	//b=(fila).(obtener elementos de clase columna y traer la posicion 0).(obtener los elementos de tipo parrafo y traer la posicion0).(contenido en el nodo)
	var numero=a.getElementsByTagName("td")[0].getElementsByTagName("p")[0].innerHTML;
	var codigo=a.getElementsByTagName("td")[1].getElementsByTagName("p")[0].innerHTML;
	var descripcion=a.getElementsByTagName("td")[2].getElementsByTagName("p")[0].innerHTML;
	var cantidad=a.getElementsByTagName("td")[3].getElementsByTagName("p")[0].innerHTML;
	var precio=a.getElementsByTagName("td")[4].getElementsByTagName("p")[0].innerHTML;
	var subtotal=a.getElementsByTagName("td")[5].getElementsByTagName("p")[0].innerHTML;
	var impuesto=a.getElementsByTagName("td")[6].getElementsByTagName("p")[0].innerHTML;
	var total=a.getElementsByTagName("td")[7].getElementsByTagName("p")[0].innerHTML;

	var array_fila = [numero, codigo, descripcion, cantidad, precio, subtotal, impuesto, total];

	return array_fila;
	//console.log(numero+' '+codigo+' '+descripcion);
}



function newRowTable()
{
	var descripcion=document.getElementById("descripcion").value;
	buscar(descripcion);
    var arr_encontrados_s=arr_encontrados[0].split("&");

	var numero=(arr_encontrados_s[0]);
	var codigo=arr_encontrados_s[1];
	var descripcion=arr_encontrados_s[2];
	var cantidad=arr_encontrados_s[3];
	var precio=arr_encontrados_s[4];
	var subtotal=(arr_encontrados_s[3]*arr_encontrados_s[4]);
	var impuesto=(subtotal*0);
	var total_n=(subtotal+impuesto);

	var name_table=document.getElementById("tabla_factura");

    var row = name_table.insertRow(0+1);
    var cell1 = row.insertCell(0);
    var cell2 = row.insertCell(1);
    var cell3 = row.insertCell(2);
    var cell4 = row.insertCell(3);
    var cell5 = row.insertCell(4);
    var cell6 = row.insertCell(5);
    var cell7 = row.insertCell(6);
    var cell8 = row.insertCell(7);
    var cell9 = row.insertCell(8);

    

    cell1.innerHTML = '<p name="numero_f[]" class="non-margin">'+numero+'</p>';
    cell2.innerHTML = '<p name="codigo_p[]" class="non-margin">'+codigo+'</p>';
    cell3.innerHTML = '<p name="descuento_p[]" class="non-margin">'+descripcion+'</p>';
    cell4.innerHTML = '<p name="cantidad_p[]" class="non-margin">'+cantidad+'</p>';
    cell5.innerHTML = '<p name="precio_p[]" class="non-margin">'+precio+'</p>';
    cell6.innerHTML = '<p name="subtotal_p[]" class="non-margin">'+subtotal+'</p>';
    cell7.innerHTML = '<p name="impuesto_p[]" class="non-margin">'+impuesto+'</p>';
    cell8.innerHTML = '<p name="total_p[]" class="non-margin">'+total_n+'</p>';
    cell9.innerHTML = '<span class="icon fa-eraser"><b>borrar</b></span>';

    //Para calcular los totales enviando los parametros
    //calculateTotals(cantidad, precio, subtotal, impuesto, total_n, 1);
    //Para calcular los totales sin enviar los parametros, solo adquiriendo los datos de la columna con mismo tipo de datos
    
    calculateTotalsBySumColumn(cantidad, precio, subtotal, impuesto, total_n, 1)
}

function env_cod()
{
	var temp="";
	var array_cod=document.getElementsByName("codigo_p[]");
	for (var i = 0; i < array_cod.length; i++) {
		if (i < (array_cod.length-1)) 
		{
			temp=temp+""+array_cod[i].innerHTML+"&";
		}
		else
		{
			temp=temp+""+array_cod[i].innerHTML;
		}
	}
	console.log(temp);
	document.getElementById("variable").value=""+temp;
	document.getElementById("codi").submit();
}

function calculateTotalsBySumColumn()
{
	var total_cantidad=0;
	var array_cantidades=document.getElementsByName("cantidad_p[]");
	for (var i=0; i<array_cantidades.length; i++) {
		total_cantidad+=parseFloat(array_cantidades[i].innerHTML);
	}
	document.getElementById("total_catidad").innerHTML=total_cantidad;


	var total_precios=0;
	var array_precios=document.getElementsByName("precio_p[]");
	for (var i=0; i<array_precios.length; i++) {
		total_precios+=parseFloat(array_precios[i].innerHTML);
	}
	document.getElementById("total_precio").innerHTML=total_precios;


	var subtotales=0;
	var array_subtotales=document.getElementsByName("subtotal_p[]");
	for (var i=0; i<array_subtotales.length; i++) {
		subtotales+=parseFloat(array_subtotales[i].innerHTML);
	}
	document.getElementById("total_subtotales").innerHTML=subtotales;


	var total_impuesto=0;
	var array_impuestos=document.getElementsByName("impuesto_p[]");
	for (var i=0; i<array_impuestos.length; i++) {
		total_impuesto+=parseFloat(array_impuestos[i].innerHTML);
	}
	document.getElementById("total_impuesto").innerHTML=total_impuesto;

	var totales_n=0;
	var array_totalesn=document.getElementsByName("total_p[]");
	for (var i=0; i<array_totalesn.length; i++) {
		totales_n+=parseFloat(array_totalesn[i].innerHTML);
	}
	document.getElementById("total_total").innerHTML=totales_n;
}



function calculateTotals(cantidad, precio, subtotal, impuesto, totaln, accion)
{
	//funcTotalsConParametro(cantidad, precio,subtotal,impuesto,total_n);
	var t_cantidad=parseFloat(document.getElementById("total_catidad").innerHTML);
	var t_precio=parseFloat(document.getElementById("total_precio").innerHTML);
	var t_subtotal=parseFloat(document.getElementById("total_subtotales").innerHTML);
	var t_impuesto=parseFloat(document.getElementById("total_impuesto").innerHTML);
	var t_total=parseFloat(document.getElementById("total_total").innerHTML);

	//accion=1		Sumarle al los totales
	//accion=2		Restarle al los totales
	if (accion==1) {
		document.getElementById("total_catidad").innerHTML=parseFloat(t_cantidad)+parseFloat(cantidad);
		document.getElementById("total_precio").innerHTML=parseFloat(t_precio)+parseFloat(precio);
		document.getElementById("total_subtotales").innerHTML=parseFloat(t_subtotal)+parseFloat(subtotal);
		document.getElementById("total_impuesto").innerHTML=parseFloat(t_impuesto)+parseFloat(impuesto);
		document.getElementById("total_total").innerHTML=parseFloat(t_total)+parseFloat(totaln);
	}else if(accion==2){
		document.getElementById("total_catidad").innerHTML=parseFloat(t_cantidad)-parseFloat(cantidad);
		document.getElementById("total_precio").innerHTML=parseFloat(t_precio)-parseFloat(precio);
		document.getElementById("total_subtotales").innerHTML=parseFloat(t_subtotal)-parseFloat(subtotal);
		document.getElementById("total_impuesto").innerHTML=parseFloat(t_impuesto)-parseFloat(impuesto);
		document.getElementById("total_total").innerHTML=parseFloat(t_total)-parseFloat(totaln);
	}else{
		alert('Accion Invalida');
	}
}



function format(input)
{
	var num = input.value.replace(/\,/g,'');
	if(!isNaN(num)){
		input.value = num;
	}
	else{ alert('Solo se permiten numeros');
		input.value = input.value.replace(/[^\d\.]*/g,'');
	}
}