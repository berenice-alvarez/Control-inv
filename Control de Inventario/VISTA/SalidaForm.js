$(document).ready(function () {
    VISTA.servicios.wsSalidas.getAll(onComplete_cargarlista);
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
    var razon = "";
    var radios = document.getElementsByName('MotivoSalida');
    for (var i = 0, length = radios.length; i < length; i++) {
        if (radios[i].checked) {
            razon = radios[i].value;
            break;
        }
    }
    var fila = "<tr><td>" + codigo + "</td><td>" + cantidad + "</td><td>" + fecha + "</td><td>" + razon;
    VISTA.servicios.wsSalidas.Registrar(codigo,cantidad,razon,fecha);
    var btn = document.createElement("TR");
    btn.innerHTML = fila;
    document.getElementById("tblProducto").appendChild(btn);
    $("#txtCodigo").val("");
    $("#txtCantidad").val("");
}
