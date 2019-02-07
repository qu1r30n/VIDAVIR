boton = document.getElementById("miboton");
var bandera=false;
var reconocimiento = new webkitSpeechRecognition();
var tiempo_fuera=0;//este nomas es para que nos e desconecte antes de presionar denuevo el boton

boton.addEventListener("click",function(event) 
{
    clearTimeout(tiempo_fuera);//este nomas es para que nos e desconecte antes de presionar denuevo el boton fue una odisea descubrir esta solucion

    
    if (!('webkitSpeechRecognition' in window)) 
    {
        alert("tu navegador no soporta reconocimiento usa chomer");
    }


    var elementos_entrada = document.getElementsByClassName('speech-input');//los input text que tiene la clase speech-input para editarlo y agregar valero
    var mensage_defaul_hablar = 'HABLA AHORA';
    // segundos para esperar más entrada después de la última
    var tiempo_espera_desconectar = 6;

    [].forEach.call(elementos_entrada, function(entrada_elemento) 
    {
        var paciencia = parseInt(entrada_elemento.dataset.paciencia, 10) || tiempo_espera_desconectar;

        // Defina si se devuelven resultados continuos para cada reconocimiento // o solo un resultado. Por defecto es falso
        reconocimiento.continuous = true;
        // Controla si deben devolverse resultados provisionales // Los resultados provisionales son resultados que aún no son definitivos. // (por ejemplo, la propiedad SpeechRecognitionResult.isFinal es falsa)
        reconocimiento.interimResults = true;
        // Devuelve y establece el idioma del reconocimiento de voz actual. // Si no se especifica, este valor predeterminado es el valor del atributo lang HTML // o la configuración de idioma del agente de usuario si eso tampoco está establecido. // Hay muchos idiomas compatibles (ve a los idiomas compatibles al final del artículo)
        reconocimiento.lang = "es-MX";
        
        //-------------------------------------------------------------------------------
        
        function reiniciar_tiempo() 
        {
            tiempo_fuera = setTimeout(function(){reconocimiento.stop();}, paciencia * 1000);
        }
        // Se dispara cuando ocurre un error con el reconocimiento de voz. // Con todos los siguientes códigos erro: // información bloqueada // información denegada // ningún discurso // abortado // captura de audio // red // No permitido // servicio no permitido // mala gramática // idioma no admitido // reconocimiento_ superposición
        reconocimiento.onerror = function(event) 
        {
            console.error(event);
        }
        // se ejecutará cuando el reconocimiento de voz // el servicio ha comenzado a escuchar el audio entrante
        reconocimiento.onstart = function() 
        {
            bandera=true;
            console.log('Speech reconocimiento service has started');
            entrada_elemento.placeholder = entrada_elemento.dataset.ready || mensage_defaul_hablar;
            reiniciar_tiempo();
        }
        // ejecutar cuando el servicio de reconocimiento de voz se ha desconectado // (automáticamente o forzado con reconocimiento.stop ())
        reconocimiento.onend = function() 
        {
            bandera=false;
            console.log('Speech reconocimiento service disconnected');
            hola();
        }
        // Este evento se activa cuando el servicio de reconocimiento de voz // devuelve un resultado - una palabra o frase ha sido positiva // reconocido y esto ha sido comunicado a su aplicación
        reconocimiento.onresult = function(event) 
        {
            clearTimeout(tiempo_fuera);
            var transcripción_provisional = '';
            var transcripción_final = '';

            for (var i = event.resultIndex; i < event.results.length; ++i) 
            {
                // Verificar si el texto reconocido es el último con la propiedad isFinal
                if (event.results[i].isFinal) 
                {
                    transcripción_final += event.results[i][0].transcript;
                } 
                else 
                {
                    transcripción_provisional += event.results[i][0].transcript;
                }
            }    
            var transcripcion = transcripción_final || transcripción_provisional;
            entrada_elemento.value = transcripcion;

            // coloca el cursor y desplaza hasta el final
            entrada_elemento.focus();
            if (entrada_elemento.tagName === 'INPUT')
            {
                entrada_elemento.scrollLeft = entrada_elemento.scrollWidth;
            } 
            else 
            {
                entrada_elemento.scrollTop = entrada_elemento.scrollHeight;
            }
            
            // Elige qué resultado puede ser útil para ti
            console.log("Interim: ", transcripción_provisional);
            console.log("Final: ",transcripción_final);
            console.log("Simple: ", event.results[0][0].transcript);
            reiniciar_tiempo();
        }
        if (bandera) 
        {
            reconocimiento.stop();
        } 
        else 
        {
            reconocimiento.start();
        }
    });
    
},false);