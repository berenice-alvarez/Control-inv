$(document).ready(function () {


    VISTA.servicios.wsSalidas.getAll(onComplete_cargarlista);

});

function onComplete_cargarlista(response) {

    var n = new Date();
    //Año
    y = n.getFullYear();
    //Mes
    m = n.getMonth() + 1;
    //Día
    d = n.getDate();
    var fecha = (d + "/" + m + "/" + y);
    $("#txtFecha").val(fecha);
    var dataSet = JSON.parse(response);

    tabla = $('#example').dataTable({
        data: dataSet,
        "lengthMenu": [[3], [3]],
        "bLengthChange": false,
        "info": false,
        columns: [

            { title: "Codigo", data: "Codigo", render: $.fn.dataTable.render.text() },
            { title: "Nombre", data: "Nombre", render: $.fn.dataTable.render.text() },
            { title: "Cantidad", data: "Cantidad", render: $.fn.dataTable.render.text() }
        ]
    });
}

function guardar() {
    var codigo = $("#txtCodigo").val();
    var cantidad = $("#txtCantidad").val();
    var fecha = $("#txtFecha").val();
    var empleado = 1;
    var razon = "";
    var radios = document.getElementsByName('MotivoSalida');
    for (var i = 0, length = radios.length; i < length; i++) {
        if (radios[i].checked) {
            razon = radios[i].value;
            break;
        }
    }
    var fila = "<tr><td>" + codigo + "</td><td>" + cantidad + "</td><td>" + fecha + "</td><td>" + razon;
    VISTA.servicios.wsSalidas.Registrar(codigo,cantidad,razon,empleado,fecha);
    var btn = document.createElement("TR");
    btn.innerHTML = fila;
    document.getElementById("tblProducto").appendChild(btn);
    $("#txtCodigo").val("");
    $("#txtCantidad").val("");
}
