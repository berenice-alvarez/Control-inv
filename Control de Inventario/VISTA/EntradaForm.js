$(document).ready(function () {
    VISTA.servicios.wsEntradas.getAll(onComplete_cargarlista);    
});

function onComplete_cargarlista(response) {

    var n = new Date();    
    y = n.getFullYear();    
    m = n.getMonth() + 1;   
    d = n.getDate();
    var fecha = (d + "/" + m + "/" + y);
    
    $("#txtFecha").val(fecha);
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
        "lengthMenu": [[3], [3]],
        "bLengthChange": false,
        "info": false,
        "columnDefs": [
            { "targets": [2, 3], "searchable": false }
        ],
        columns: [

            { title: "Codigo", data: "Codigo", render: $.fn.dataTable.render.text() },
            { title: "Nombre", data: "Nombre", render: $.fn.dataTable.render.text() },
            { title: "Cantidad", data: "Cantidad", render: $.fn.dataTable.render.text() },
            { title: "Precio", data: "PrecioCosto", render: $.fn.dataTable.render.text() }            
        ]
    });
}

function guardar() {
    var codigo = $("#txtCodigo").val();
    var cantidad = $("#txtCantidad").val();
    var precioUnitario = $("#txtPrecioUnitario").val();
    var fecha = $("#txtFecha").val();    
    var subtotal = $("#txtSubtotal").val();
    var fila = "<tr><td>" + codigo + "</td><td>" + cantidad + "</td><td>" + precioUnitario +
        "</td><td>" + subtotal + "</td><td>" + fecha + "</td></tr>";
    
    var btn = document.createElement("TR");
    btn.innerHTML = fila;
    document.getElementById("tblProducto").appendChild(btn);

    VISTA.servicios.wsEntradas.Registrar(codigo, cantidad, precioUnitario, subtotal, fecha);

    $("#txtCodigo").val("");
    $("#txtCantidad").val("");
    $("#txtPrecioUnitario").val("");
    $("#txtSubtotal").val("");
}
function Registrar() {
    VISTA.servicios.wsEntradas.Registrar(lista);
}
function calcular() {
    var cantidad = $("#txtCantidad").val();
    var precioUnitario = $("#txtPrecioUnitario").val();
    var subtotal = (cantidad * precioUnitario);
    $("#txtSubtotal").val(subtotal);
}