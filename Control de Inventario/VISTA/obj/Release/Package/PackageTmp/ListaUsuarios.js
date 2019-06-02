$(document).ready(function () {


    VISTA.servicios.wsUsuarios.getAll(onComplete_cargarlista);

});

function onComplete_cargarlista(response) {  
    var dataSet = JSON.parse(response);
    tabla = $('#example').dataTable({
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
        "lengthMenu": [[8], [8]],
        "bLengthChange": false,
        "info": false,
        "columnDefs": [
            { "targets": [2, 3, 4, 5,6], "searchable": false }
        ],
        columns: [

            { title: "Codigo", data: "Codigo", render: $.fn.dataTable.render.text() },
            { title: "Nombre", data: "Nombre", render: $.fn.dataTable.render.text() },
            { title: "ApellidoPaterno", data: "ApellidoPaterno", render: $.fn.dataTable.render.text() },
            { title: "ApellidoMaterno", data: "ApellidoMaterno", render: $.fn.dataTable.render.text() },
            { title: "Telefono", data: "Telefono", render: $.fn.dataTable.render.text() },
            { title: "Email", data: "Email", render: $.fn.dataTable.render.text() },
            { title: "Nivel", data: "Nivel", render: $.fn.dataTable.render.text() }            
        ]
    });
}