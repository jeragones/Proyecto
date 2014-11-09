var datos = [];
var values = [];
var datoC = [];

$(document).ready(

    function () {

        //Antes de ir a la acción Post del submit, se agregan los ingenieros y labs modificados
        $("#formCreateContract").submit(function (eventObj) {
            var inputs = document.getElementsByName('IdDato'),
               names = [].map.call(inputs, function (input) {
                   datos.push(input.value);
               });

            var inputsvalues = document.getElementsByName('Resultado'),
                   names2 = [].map.call(inputsvalues, function (input) {
                       values.push(input.value);
                   });

            for (i = 0; i < datos.length; i++) {
                datoC.push({ id: datos[i], valor: values[i] });
            };
            datos.push
            var jsonDatos = { "Datos": datoC };
            var jsonAnalisis = { "analisis": jsAnalisis }

            // Json de los ingenieros que va a tener el contrato
            $('<input />').attr('type', 'hidden')
                .attr('name', "jsonDatos")
                .attr('value', JSON.stringify(jsonDatos))
                .appendTo('#formCreateContract');

            $('<input />').attr('type', 'hidden')
                .attr('name', "jsonAnalisis")
                .attr('value', JSON.stringify(jsonAnalisis))
                .appendTo('#formCreateContract');


            return true;
        })
    });
