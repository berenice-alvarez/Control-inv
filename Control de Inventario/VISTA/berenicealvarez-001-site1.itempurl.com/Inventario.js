var fecha="";
$(document).ready(function () {
    var n = new Date();
    y = n.getFullYear();
    m = n.getMonth() + 1;
    d = n.getDate();
    fecha = (d + "/" + m + "/" + y);
    VISTA.servicios.wsInventario.getAll(onComplete_cargarlista);

});
var tabla;
var cont = 0;
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
        "lengthMenu": [[9], [9]],
        "bLengthChange": false,
        "info": false,
        "columnDefs": [
            { "targets": [2, 3, 4], "searchable": false }
        ],
        columns: [
            { title: "Codigo", data: "Codigo", render: $.fn.dataTable.render.text() },
            { title: "Nombre Producto", data: "Nombre", render: $.fn.dataTable.render.text() },
            { title: "Cantidad", name:"Can",data: "Cantidad",render: $.fn.dataTable.render.text()},     
            { title: "Categoria", data: "Categoria", render: $.fn.dataTable.render.text() },     
            {
                title: "Inconsistencias", data: null,
                render: function (data, type, row) {
                    return '<input type="number" value="0" id="cant"/>';
                }
            },
            { title: "Acción", "defaultContent": "<button type='button' id='btnListo' class='hecho btn btn-success btn-xs'>Listo</button>    <button type='button' id='btnCorregir' class='corregir btn btn-danger btn-xs'>Corregir</button>   <button type='button' id='btnGuardar' class='guardar btn btn-primary btn-xs'>Guardar</button>"}
        ]
    });
}

$(document).on('click', '.hecho', function (e) {
    e.preventDefault();             
    $(this).parents("tr").find('#cant').attr('disabled', 'disabled');
    $(this).parents("tr").find('#btnListo').attr('disabled', 'disabled');
});
$(document).on('click', '.corregir', function (e) {
    e.preventDefault();    
    $(this).parents("tr").find('#cant').removeAttr('disabled');
    $(this).parents("tr").find('#btnListo').removeAttr('disabled');
});
$(document).on('click', '.guardar', function (e) {
    e.preventDefault();
    var id = $(this).parent().parent().children().first().text();
    var valor = $(this).parents("tr").find('#cant').val();
    var cantidad = $(this).parent().parent().find("td:eq(2)").text();    
    $(this).parents("tr").find('#cant').attr('disabled', 'disabled');
    $(this).parents("tr").find('#btnListo').attr('disabled', 'disabled');
    $(this).parents("tr").find('#btnCorregir').attr('disabled', 'disabled');
    $(this).parents("tr").find('#btnGuardar').attr('disabled', 'disabled');
    VISTA.servicios.wsInventario.update(id, valor);
    VISTA.servicios.wsInventario.insert(id,cantidad,valor,fecha);
    //$(this).parent().parent().remove();
});
window.onbeforeunload = function (e) {
    return "";
};
