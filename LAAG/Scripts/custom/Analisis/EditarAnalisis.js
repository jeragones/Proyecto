var ingenieros = [];
var datos = [];
var ids = [];

// Array que contendrá los id de los laboratorios del proyecto
var laboratorios = [];
document.getElementById('idCategoria').value = modelo

function obtenerids() {
    for (var i = 1; i < document.getElementById('tbIngenieros').rows.length; i++)
    {
        datos.push(parseInt(document.getElementById('tbIngenieros').rows[i].id))
    }
}

function eliminarlos() {
    for (var i = 0; i < datos.length; i++) {
        $("#dllDatos option[value='" + datos[i] + "']").remove()
    }
}

$(document).ready(
    
    function () {
        obtenerids(),
    eliminarlos(),
        // Función que permite agregar una fila con los detalles del ingeniero seleccionado en la sección Ingenieros del Wizard
        $('#btnAgregarDato').click(function () {
            var dd = document.getElementById('dllDatos')
            var _id = dd.options[dd.selectedIndex].value;

            // Este ajax se realiza una acción de cobtrolador donde envía el id del ingeniero a buscar y recibe como retorno un JSON con los detalles del Ingeniero
            $.ajax({
                url: '/Analisis/DatoDetalles/',
                type: "GET",
                dataType: "json",
                data: {
                    id: _id
                },
                success: function (data) {
                    var json = $.parseJSON(data);
                    datos.push(_id.toString());

                    // Impresion del json devuelto por el controller
                    //console.log(data);

                    var fila = '<tr id=' + json.IdDato + '><td>' + json.Nombre + '</td> ';
                    fila += '<td>' + json.unidadMedida + '</td>';
                    fila += '<td> <button class="remove btn btn-danger" onclick=" eliminarDato(' + json.IdDato + ')">Quitar Dato</button> </td></tr>';

                    //Agrega el ingeniero a la tabla htlm
                    $('#tbIngenieros > tbody:last').append(fila);

                    //Elimina el ingeniero del dropdownlist
                    $("#dllDatos option:selected").remove();

                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            })
        }),

        // Función que permite quitar una fila con los detalles del ingeniero seleccionado en la sección Ingenieros del Wizard
        $(document).on("click", "#tbIngenieros button.remove", function () {
            $(this).parents("tr").remove();
        }),


        //Antes de ir a la acción Post del submit, se agregan los ingenieros y labs modificados
        $("#formCreateContract").submit(function (eventObj) {
            var jsonDatos = { "Datos": datos };

            // Json de los ingenieros que va a tener el contrato
            $('<input />').attr('type', 'hidden')
                .attr('name', "jsonDatos")
                .attr('value', JSON.stringify(jsonDatos))
                .appendTo('#formCreateContract');


            return true;
        })
    });


function eliminarDato(_id) {
    $.ajax({
        url: '/Analisis/DatoDetalles/',
        type: "GET",
        dataType: "json",
        data: {
            id: _id
        },
        success: function (data) {
            var json = $.parseJSON(data);
            for (var i = datos.length - 1; i >= 0; i--) {
                if (datos[i] == _id) {
                    datos.splice(i, 1);
                }
            }
            // ingenieros.splice(ingenieros.indexOf(_id), 1);
            $("<option value=" + json.IdDato + ">" + json.Nombre + "</option>").appendTo("#dllDatos");
        },
        error: function (xhr, textStatus, errorThrown) {
            if (xhr.status == 400) {
                // Bad request
                alert('Error: Consulta inválida.\nVerifique que seleccionó un Dato.');
            }
            else if (xhr.status === 401) {
                // Unauthorized error
                alert('Error: Acceso denegado.\n Verifique que tenga privilegios para realizar la operación.');
            }
            else if (xhr.status == 404) {
                // Not found
                alert('Error: no se encontraron los detalles del Dato.\nVerifique que existe el Dato.');
            }
            else if (xhr.status == 500) {
                // Server side error
                alert('Error del servidor.\n Espere unos segundos y vuelva a reitentar.');
            }
            else {
                alert('Error: \n' + errorThrown + 'Reitente de nuevo.');
            }
        }
    })
}