<?php  

class grafica
{
	
	function graficar($arr_nom_columnas,$arr_cantidad,$caracter_espliteo,$nom_div="chart_div")
	{
		echo "<script type=\"text/javascript\" src=\"https://www.gstatic.com/charts/loader.js\"></script>
    		  <script type=\"text/javascript\">
    		  google.charts.load('current', {packages: ['corechart', 'line']});
      		  google.charts.setOnLoadCallback(drawLogScales);

      		  function drawLogScales() {
      			var data = new google.visualization.DataTable();
      			data.addColumn('number', 'X');//es en que parte de x estaran las columnas
    		  ";
            
    		
    		$cantidad_columnas=count($arr_nom_columnas);
    		$cantidad_cantidades=count($arr_cantidad);
            // data.addColumn('number', 'Cats');
            $temp="0,";
            for ($i=0; $i < $cantidad_columnas ; $i++) 
            { 
                echo " data.addColumn('number','".$arr_nom_columnas[$i]."');";
                if ($i<$cantidad_columnas-1) 
                {
                    $temp=$temp."0,";
                } 
                else 
                {
                    $temp=$temp."0";
                }
                
            }

                // data.addRows([
                // [0, 0, 0],    [1, 10, 5],   [2, 23, 15],  [3, 17, 9]
                // ]);

            $cadena="data.addRows([[".$temp."],";
    		for ($i=0; $i < $cantidad_cantidades ; $i++) 
    		{
                $cantidades=explode($caracter_espliteo,$arr_cantidad[$i]);
                $arr_cantidad[$i]=implode(",", $cantidades);

                if ($i<$cantidad_cantidades-1) 
                {
                    $cadena=$cadena."[".($i+1).",".$arr_cantidad[$i]."],";
                }
                else
                {
                    $cadena=$cadena."[".($i+1).",".$arr_cantidad[$i]."] ]);";   
                }
    		}
            echo $cadena;

            echo "var options = 
                {
                    hAxis: {
                      title: 'Time',
                      logScale: true
                    },
                    vAxis: {
                      title: 'Popularity',
                      logScale: false
                    },
                    colors: ['#a52714', '#097138']
                };
                var chart = new google.visualization.LineChart(document.getElementById('".$nom_div."'));
                chart.draw(data, options);
                }
                </script>
                <div id=".$nom_div."></div>
                ";
                echo htmlspecialchars($cadena);
	}
}
?>