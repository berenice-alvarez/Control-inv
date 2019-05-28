$(document).ready(function () {
    VISTA.servicios.wsEntradas.getAllReporte(onComplete_cargarLista);
});

function onComplete_cargarLista(response) {
    var dataSet = JSON.parse(response);
    tabla = $('#cargaDatos').dataTable({
        language: {
            "decimal": "",
            "emptyTable": "No hay información",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        data: dataSet,
        "info": false,
        "bLengthChange": false,
        columns: [
            { title: "Código de Entrada", data: "codigo", render: $.fn.dataTable.render.text() },
            { title: "Código producto", data: "codigoPro", render: $.fn.dataTable.render.text() },
            { title: "Nombre producto", data: "nombrePro", render: $.fn.dataTable.render.text() },
            { title: "Cantidad", data: "cantidadPro", render: $.fn.dataTable.render.text() },
            { title: "Precio unitario", data: "precioUnitario", render: $.fn.dataTable.render.text() },
            { title: "Subtotal",data:"subtotal", render: $.fn.dataTable.render.text() },            
            { title: "Fecha", data: "fecha", render: $.fn.dataTable.render.text() },
            { title: "Empleado", data: "nombreEm", render: $.fn.dataTable.render.text() },
        ]
    });
}