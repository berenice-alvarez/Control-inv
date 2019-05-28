
function insertP() {
    VISTA.servicios.wsProductos.insert2($("#txtNombre").val(), $("#txtCantidad").val(), $("#txtPrecioCosto").val(),
        $("txtPrecioVenta").val(), $("txtPrecioMayoreo").val(), $("#cmbCategoria").val(), onSuccess, onError);    
}

function insert() {
    var Producto = new Object();
    Producto.Nombre = $("txtNombre").val();
    Producto.Cantidad = $("txtCantidad").val();
    Producto.PrecioCosto = $("txtPrecioCosto").val();
    Producto.PrecioPublico = $("txtPrecioMayoreo").val();
    Producto.PrecioMayoreo = $("txtPrecioMayoreo").val();
    Producto.Categoria = $("cmbCategoria").val();
    VISTA.servicios.wsProductos.insert(Producto, onSuccess,onError);

}
function onSuccess() {
    alert("Exito");
}
function onError() {
    alert("Error");
}