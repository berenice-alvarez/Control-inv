$(document).ready(function () {
    VISTA.servicios.wsInventario.ReporteInventario(onComplete_cargarLista);
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
            { title: "Código producto", data: "CodigoPro", render: $.fn.dataTable.render.text() },
            { title: "Nombre producto", data: "Nombre", render: $.fn.dataTable.render.text() },
            { title: "Cantidad", data: "Cantidad", render: $.fn.dataTable.render.text() },
            { title: "Inconsistensias", data: "Inco", render: $.fn.dataTable.render.text() },
            { title: "Usuario", data: "NombreEmp", render: $.fn.dataTable.render.text() },
            { title: "Fecha", data: "Fecha", render: $.fn.dataTable.render.text() }            
        ]
    });
}