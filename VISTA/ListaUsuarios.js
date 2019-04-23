$(document).ready(function () {


    VISTA.servicios.wsUsuarios.getAll(onComplete_cargarlista);

});

function onComplete_cargarlista(response) {  
    var dataSet = JSON.parse(response);
    tabla = $('#example').dataTable({
        data: dataSet,
        "lengthMenu": [[8], [8]],
        "bLengthChange": false,
        "info": false,
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