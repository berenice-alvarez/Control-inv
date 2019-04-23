$(document).ready(function () {


    VISTA.servicios.wsEntradas.getAll(onComplete_cargarlista);
    GetUserName();
});

function onComplete_cargarlista(response) {

    var n = new Date();
    //Año
    y = n.getFullYear();
    //Mes
    m = n.getMonth() + 1;
    //Día
    d = n.getDate();
    var fecha = (y + "-" + m + "-" + d);
    
    $("#txtFecha").val(fecha);
    var dataSet = JSON.parse(response);

    tabla = $('#example').dataTable({
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
    var empleado = 1;
    var subtotal = $("#txtSubtotal").val();
    var fila = "<tr><td>" + codigo + "</td><td>" + cantidad + "</td><td>" + precioUnitario +
        "</td><td>" + subtotal + "</td><td>" + fecha + "</td></tr>";
    
    var btn = document.createElement("TR");
    btn.innerHTML = fila;
    document.getElementById("tblProducto").appendChild(btn);

    VISTA.servicios.wsEntradas.Registrar(codigo, cantidad, precioUnitario, subtotal, empleado, fecha);

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
function GetUserName() {

    var username = '<%= Session["UserName"] %>';
    alert(username);
}