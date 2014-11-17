$(document).ready(function () {
    $.ajax({
        url: '/reporte/crear',
        type: "GET",
        dataType: "json",
        success: function (data) {
            //var json = $.parseJSON(data);
            var json = [{
                "codigo": "B14_1",
                "campo": "campo 2",
                "analisis": [
                    {
                        "nombre": "Nitrogeno",
                        "valor": "7.56"
                    }, {
                        "nombre": "Materia Seca",
                        "valor": "5.23"
                    }]
            }, {
                "codigo": "B13_1",
                "campo": "campo 3",
                "analisis": [
                    {
                        "nombre": "Acido",
                        "valor": "7.56"
                    }, {
                        "nombre": "Neutro",
                        "valor": "5.23"
                    }]
            }];
            $('#content').append('');

            /*
            $(".cmbName").append("<option value='0'></option>");
            jQuery.each(json, function (val, i) {
                $(".cmbName").append("<option value='" + i.id + "'>" + i.nombre + "</option>");
            });
            */
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
});