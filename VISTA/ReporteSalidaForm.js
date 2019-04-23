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
            { title: "Código producto", data: "codigoProducto", render: $.fn.dataTable.render.text() },
            { title: "Cantidad", data: "cantidadProductos", render: $.fn.dataTable.render.text() },
            { title: "Razón de salida", data: "razonSalida", render: $.fn.dataTable.render.text() },
            { title: "Código usuario", data: "codigoUsuario", render: $.fn.dataTable.render.text() },
            { title: "Fecha", data: "fecha", render: $.fn.dataTable.render.text() }
        ]
    });
}