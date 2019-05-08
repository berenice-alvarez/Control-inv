function insert() {
    console.log($("#txtNombre").val());
    console.log($("#txtCantidad").val());
    console.log($("#txtPrecioCosto").val());
    console.log($("#txtPrecioVenta").val());
    console.log($("#txtPrecioMayoreo").val());
    console.log($("#cmbCategoria").val());
    VISTA.servicios.wsProductos.insert2($("#txtNombre").val(), $("#txtCantidad").val(),
        $("#txtPrecioCosto").val(), $("#txtPrecioVenta").val(), $("#txtPrecioMayoreo").val(),
        $("#cmbCategoria").val(), onSuccess, onError);
}

function onSuccess() {
    alert("Exito");
}
function onError() {
    alert("Error");
}