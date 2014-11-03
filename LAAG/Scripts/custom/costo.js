
var lstAnalysis = [];
var costo = 0;

function cost(element) {
    if (element.checked) {
        $.ajax({
            url: '/costo/precio',
            type: "POST",
            dataType: "json",
            data: {
                id: $(element).val(),
                cost: $(".lblCost").val(),
                op: "true"
            },
            success: function (data) {
                var json = $.parseJSON(data);
                $(".lblCost").val(json);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });
    } else {
        $.ajax({
            url: '/costo/precio',
            type: "POST",
            dataType: "json",
            data: {
                id: $(element).val(),
                cost: $(".lblCost").val(),
                op: "false"
            },
            success: function (data) {
                var json = $.parseJSON(data);
                $(".lblCost").val(json);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });
    }
}

function eliminar(id) {
    $.ajax({
        url: '/Costo/Agregar',
        type: "GET",
        dataType: "json",
        data: {
            id: id
        },
        success: function (data) {
            var json = $.parseJSON(data);
            $(".cmbAnalysis").append("<option value='" + json[0] + "'>" + json[1] + "</option>");
            $('#tblAnalisis tr#' + id).remove();
            $(".lblCost").val(parseInt($(".lblCost").val()) - parseInt(json[2]));
        },
        error: function (xhr, textStatus, errorThrown) {
            alert(errorThrown);
        }
    })
}

$(document).ready(function () {

    $.ajax({
        url: '/costo/clientes',
        type: "GET",
        dataType: "json",
        success: function (data) {
            var json = $.parseJSON(data);
            $(".cmbName").append("<option value='0'></option>");
            jQuery.each(json, function (val, i) {
                $(".cmbName").append("<option value='" + i.id + "'>" + i.nombre + "</option>");
            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });

    $.ajax({
        url: '/costo/provincia',
        type: "GET",
        dataType: "json",
        success: function (data) {
            var json = $.parseJSON(data);
            $(".cmbProvince").append("<option value='0'></option>");
            jQuery.each(json, function (val, i) {
                $(".cmbProvince").append("<option value='" + i.id + "'>" + i.nombre + "</option>");
            });
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });

    $.ajax({
        url: '/costo/categorias',
        type: "GET",
        dataType: "json"
    }).success(function (data) {
        var json = $.parseJSON(data);
        $(".cmbCategory").append("<option value='0'></option>");
        jQuery.each(json, function (val, i) {
            $(".cmbCategory").append("<option value='" + i.id + "'>" + i.nombre + "</option>");
        });
    }).error(function (jqXHR, textStatus, errorThrown) {
        alert(errorThrown);
    });

    $(".lblCost").val("0");
    $("#step-2").hide();

    $("#btnNext").click(function () {
        var percent = 50;
        $(".progress-bar").css("width", percent + "%").attr("aria-valuenow", percent);
        $("#step-2").show();
        $("#step-1").hide();
    });

    $("#btnBack").click(function () {
        var percent = 0;
        $(".progress-bar").css("width", percent + "%").attr("aria-valuenow", percent);
        $("#step-1").show();
        $("#step-2").hide();
    });

    $(".cmbProvince").change(function () {
        $.ajax({
            url: '/costo/canton',
            type: "POST",
            dataType: "json",
            data: {
                id: $(this).val()
            },
            success: function (data) {
                var json = $.parseJSON(data);
                alert(data);
                $(".cmbCanton").empty();
                $(".cmbCanton").append("<option value='0'></option>");
                jQuery.each(json, function (val, i) {
                    $(".cmbCanton").append("<option value='" + i.id + "'>" + i.nombre + "</option>");
                });
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });
    });

    $(".cmbCanton").change(function () {
        $.ajax({
            url: '/costo/distrito',
            type: "POST",
            dataType: "json",
            data: {
                id: $(this).val()
            },
            success: function (data) {
                var json = $.parseJSON(data);
                alert(data);
                $(".cmbDistrict").empty();
                $(".cmbDistrict").append("<option value='0'></option>");
                jQuery.each(json, function (val, i) {
                    $(".cmbDistrict").append("<option value='" + i.id + "'>" + i.nombre + "</option>");
                });
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });
    });

    $(".cmbCategory").change(function () {
        $('#tblBody').empty();
        lstAnalysis = [];
        $(".lblCost").val("0");
        $.ajax({
            url: '/costo/categoria',
            type: "POST",
            dataType: "json",
            data: {
                id: $(this).val()
            },
            success: function (data) {
                var json = $.parseJSON(data);
                $(".cmbAnalysis").empty();
                $(".cmbAnalysis").append("<option value='0'></option>");
                jQuery.each(json, function (val, i) {
                    $(".cmbAnalysis").append("<option value='" + i.id + "'>" + i.nombre + "</option>");
                });
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });
    });

    $(".cmbAnalysis").change(function () {
        $.ajax({
            url: '/costo/analisis',
            type: "POST",
            dataType: "json",
            data: {
                id: $(this).val(),
                idCategoria: $(".cmbCategory").val(),
                categoria: $(".cmbCategory option:selected").text()
            },
            success: function (data) {
                var json = $.parseJSON(data);
                lstAnalysis.push(json[0].id);
                
                var fila = '<tr id="' + json[0].id + '">' +
                               '<td>' + json[0].codigo + '</td> ' +
                               '<td>' + json[0].Nombre + '</td> ' +
                               '<td>' + json[0].categoria + '</td>' +
                               '<td>' + json[0].Costo + '</td>' +
                               '<td> <a class="remove btn btn-danger" onclick="eliminar(' + json[0].id + ')">Quitar</a> </td>' +
                           '</tr>';
                
                //Agrega el analisis a la tabla
                $('#tblBody:last').append(fila);
                
                $(".lblCost").val(parseInt($(".lblCost").val()) + parseInt(json[0].Costo));
                //Elimina el analisis del dropdownlist
                $(".cmbAnalysis option:selected").remove();
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });
    });

    $("#formCreateCost").submit(function (eventObj) {
        var muestra = { id: $(".cmbName").val(), nombre: $(".cmbName option:selected").text(), provincia: $(".cmbProvince").val(), canton: $(".cmbCanton").val(), distrito: $(".cmbDistrict").val(), direccion: $(".txtAddress").val(), campo: $(".txtField").val() };
        var jsonDatos = { "id": lstAnalysis, "muestra": muestra };
        // Json de los ingenieros que va a tener el contrato
        $('<input />').attr('type', 'hidden')
            .attr('name', "jsonDatos")
            .attr('value', JSON.stringify(jsonDatos))
            .appendTo('#formCreateCost');
        return true;
    });
});