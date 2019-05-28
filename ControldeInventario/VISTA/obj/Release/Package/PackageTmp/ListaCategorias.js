$(document).ready(function () {


    VISTA.servicios.wsCategorias.getAll(onComplete_cargarlista);

});

function onComplete_cargarlista(response) {

    //alert("onComplete_cargarlista + " + response);
    var dataSet = JSON.parse(response);

    tabla = $('#example').dataTable({
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