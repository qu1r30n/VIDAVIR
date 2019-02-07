/*Reconocimiento global de webkitSpeech */
(function() {
	'use strict';

	// verifica el soporte (solo webkit)
	if (!('webkitSpeechRecognition' in window)) return;

	var mensage_defaul_hablar = 'HABLA AHORA';
	// segundos para esperar más entrada después de la última
  	var tiempo_espera_desconectar = 6;

	function mayuscula(str) {
		return str.charAt(0).toUpperCase() + str.slice(1);
	}

	var elementos_entrada = document.getElementsByClassName('speech-input');

	[].forEach.call(elementos_entrada, function(entrada_elemento) {
		var paciencia = parseInt(entrada_elemento.dataset.paciencia, 10) || tiempo_espera_desconectar;
		var micBtn, micIcon, holderIcon, nueva_envoltura;
		var debe_mayuscula = true;

		// recopilar datos de entrada
		var siguiente_nodo = entrada_elemento.nextSibling;
		var padre = entrada_elemento.parentNode;
		var inputRightBorder = parseInt(getComputedStyle(entrada_elemento).borderRightWidth, 10);
		var buttonSize = 0.8 * (entrada_elemento.dataset.buttonsize || entrada_elemento.offsetHeight);

		// tamaño máximo predeterminado para textareas
		if (!entrada_elemento.dataset.buttonsize && entrada_elemento.tagName === 'TEXTAREA' && buttonSize > 26) {
			buttonSize = 26;
		}

		// create wrapper if not present
		var envoltura = entrada_elemento.parentNode;
		if (!envoltura.classList.contains('si-envoltura')) {
			envoltura = document.createElement('div');
			envoltura.classList.add('si-envoltura');
			envoltura.appendChild(padre.removeChild(entrada_elemento));
			nueva_envoltura = true;
		}

		// crear botón de micrófono si no está presente
		micBtn = envoltura.querySelector('.si-btn');
		if (!micBtn) {
			micBtn = document.createElement('button');
			micBtn.type = 'button';
			micBtn.classList.add('si-btn');
			micBtn.textContent = 'speech input';
			micIcon = document.createElement('span');
			holderIcon = document.createElement('span');
			micIcon.classList.add('si-mic');
			holderIcon.classList.add('si-holder');
			micBtn.appendChild(micIcon);
			micBtn.appendChild(holderIcon);
			envoltura.appendChild(micBtn);

			// Tamaño y posición del micrófono y entrada.
			micBtn.style.cursor = 'pointer';
			micBtn.style.top = 0.125 * buttonSize + 'px';
			micBtn.style.height = micBtn.style.width = buttonSize + 'px';
			entrada_elemento.style.paddingRight = buttonSize - inputRightBorder + 'px';
		}

		// añadir envoltura donde estaba la entrada
		if (nueva_envoltura) padre.insertBefore(envoltura, siguiente_nodo);

		// reconocimiento de configuración
		var prefix = '';
		var isSentence;
		var reconociendo = false;
		var tiempo_fuera;
		var antiguo_marcador_posición = null;
		var reconocimiento = new webkitSpeechRecognition();
		reconocimiento.continuous = true;
		reconocimiento.interimResults = true;

		// si el atributo lang se establece en el campo, use ese
		// (por defecto usa el idioma del elemento raíz)
		if (entrada_elemento.lang) reconocimiento.lang = entrada_elemento.lang;

		function reiniciar_tiempo() {
			tiempo_fuera = setTimeout(function() {
				reconocimiento.stop();
			}, paciencia * 1000);
		}

		reconocimiento.onstart = function() {
			antiguo_marcador_posición = entrada_elemento.placeholder;
			entrada_elemento.placeholder = entrada_elemento.dataset.ready || mensage_defaul_hablar;
			reconociendo = true;
			micBtn.classList.add('listening');
			reiniciar_tiempo();
		};

		reconocimiento.onend = function() {
			console.log (entrada_elemento.value);
			reconociendo = false;
			clearTimeout(tiempo_fuera);
			micBtn.classList.remove('listening');
			if (antiguo_marcador_posición !== null) entrada_elemento.placeholder = antiguo_marcador_posición;

			// Si el <input> tiene datos-instant-submit y un valor,
			if (entrada_elemento.dataset.instantSubmit !== undefined && entrada_elemento.value) {
				// enviar el formulario en el que está (si está en uno).
				if (entrada_elemento.form) entrada_elemento.form.submit();
			}
		};

		reconocimiento.onresult = function(event) {
			clearTimeout(tiempo_fuera);

			// obtener objeto de lista de resultados de reconocimiento de voz
			var resultado_lista = event.results;

			// ir a través de cada objeto SpeechRecognitionResult en la lista
			var transcripción_final = '';
			var transcripción_provisional = '';
			for (var i = event.resultIndex; i < resultado_lista.length; ++i) {
				var resultado = resultado_lista[i];

				// obtener el primer objeto SpeechRecognitionAlternative de este resultado
				var firstAlternative = resultado[0];

				if (resultado.isFinal) {
					transcripción_final = firstAlternative.transcript;
				} else {
					transcripción_provisional += firstAlternative.transcript;
				}
			}

			// mayúscula transcripción si comienzo de nueva oración
			var transcripcion = transcripción_final || transcripción_provisional;
			transcripcion = !prefix || isSentence ? mayuscula(transcripcion) : transcripcion;


			// añadir la transcripción al valor de entrada en caché
			//entrada_elemento.value = prefix + transcripcion; //los agrega con el anterior

			entrada_elemento.value = transcripcion; //para que no los agregue con el anterior 

			// coloca el cursor y desplaza hasta el final
			entrada_elemento.focus();
			if (entrada_elemento.tagName === 'INPUT') {
				entrada_elemento.scrollLeft = entrada_elemento.scrollWidth;
			} else {
				entrada_elemento.scrollTop = entrada_elemento.scrollHeight;
			}

			reiniciar_tiempo();
		};

		micBtn.addEventListener('click', function(event) 
		{
			event.preventDefault();

			// parar y salir si ya va
			if (reconociendo) {
				reconocimiento.stop();
				return;
			}

			// Almacenar en caché el valor de entrada actual al que se añadirá la nueva transcripción
			var termina_espacio_blanco = entrada_elemento.value.slice(-1).match(/\s/);
			prefix = !entrada_elemento.value || termina_espacio_blanco ? entrada_elemento.value : entrada_elemento.value + ' ';

			// verifica si el valor termina con una oración
			isSentence = prefix.trim().slice(-1).match(/[\.\?\!]/);

			// reiniciar el reconocimiento
			reconocimiento.start();
		}, false);
	});
})();
//..............................................................................






