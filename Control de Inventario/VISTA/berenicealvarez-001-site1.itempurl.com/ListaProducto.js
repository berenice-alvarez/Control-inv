$(document).ready(function () {


    VISTA.servicios.wsProductos.getAll(onComplete_cargarlista);

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
            { "targets": [2,3,4,5,6,7], "searchable": false }
        ],
        columns: [

            { title: "Codigo", data: "Codigo", render: $.fn.dataTable.render.text() },
            { title: "Nombre", data: "Nombre", render: $.fn.dataTable.render.text() },
            { title: "Cantidad", data: "Cantidad", render: $.fn.dataTable.render.text() },
            { title: "PrecioCosto", data: "PrecioCosto", render: $.fn.dataTable.render.text() },
            { title: "PrecioPublico", data: "PrecioPublico", render: $.fn.dataTable.render.text() },
            { title: "PrecioMayoreo", data: "PrecioMayoreo", render: $.fn.dataTable.render.text() },
            { title: "Categoria", data: "Categoria", render: $.fn.dataTable.render.text() },
            { title: "", "defaultContent": "<button type='button' class='editar btn btn-info btn-xs'>Editar</button>" }            
        ]
    }); 
}

function update() {


}

$(document).on('click', '.editar', function (e) {
    e.preventDefault();
    var id = $(this).parent().parent().children().first().text();
    console.log(id);
    localStorage.Usr = id;
    location.href= "ProductEdit.aspx"
    
    //$(this).parent().parent().remove();
});

function editar(response) {
    var producto = JSON.parse(response);

}