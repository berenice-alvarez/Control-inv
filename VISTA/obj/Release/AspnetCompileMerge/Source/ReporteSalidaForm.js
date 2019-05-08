$(document).ready(function () {
    VISTA.servicios.wsSalidas.getAllReporte(onComplete_cargarLista);
});

function onComplete_cargarLista(response) {
    var dataSet = JSON.parse(response);

    tabla = $('#cargaDatos').dataTable({
        data: dataSet,
        "info": false,
        "bLengthChange": false,
        columns: [
            { title: "Código", data: "codigo", render: $.fn.dataTable.render.text() },
            { title: "Código producto", data: "codigoPro", render: $.fn.dataTable.render.text() },
            { title: "Nombre producto", data: "nombrePro", render: $.fn.dataTable.render.text() },
            { title: "Cantidad", data: "cantidadPro", render: $.fn.dataTable.render.text() },
            { title: "Razón de salida", data: "razonSalida", render: $.fn.dataTable.render.text() },           
            { title: "Fecha", data: "fecha", render: $.fn.dataTable.render.text() },
            { title: "Empleado", data: "nombreEm", render: $.fn.dataTable.render.text() }
        ]
    });
}