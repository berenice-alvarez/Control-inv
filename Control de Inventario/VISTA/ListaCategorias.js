$(document).ready(function () {


    VISTA.servicios.wsCategorias.getAll(onComplete_cargarlista);

});

function onComplete_cargarlista(response) {

    //alert("onComplete_cargarlista + " + response);
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
        "lengthMenu": [[9], [9]],
        "bLengthChange": false,
        "info": false,
        "columnDefs": [
            { "targets": [2], "searchable": false }
        ],
        columns: [

            { title: "Codigo", data: "codigo", render: $.fn.dataTable.render.text() },
            { title: "Nombre", data: "nombre", render: $.fn.dataTable.render.text() },
            { title: "Descripción", data: "descripcion", render: $.fn.dataTable.render.text() }
        ]
    });
}