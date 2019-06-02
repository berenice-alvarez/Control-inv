var actual;
$(document).ready(function () {
    actual = localStorage.Usr;
    VISTA.servicios.wsProductos.edit(actual, editar);
});
var clave2;
function editar(response) {
    
    alert("prueba");
    var producto = JSON.parse(response);
    clave2 = producto.Codigo;
    $("#txtNombre").val(producto.Nombre);
    $("#txtCantidad").val(producto.Cantidad);
    $("#txtPrecioCosto").val(producto.PrecioCosto);
    $("#txtPrecioVenta").val(producto.PrecioPublico);
    $("#txtPrecioMayoreo").val(producto.PrecioMayoreo);
    $("#cboEjemplo").val(producto.categoria);
}
function update() {
    console.log(clave2);
    console.log($("#txtNombre").val());
    console.log($("#txtCantidad").val());
    console.log($("#txtPrecioCosto").val());
    console.log($("#txtPrecioVenta").val());
    console.log($("#txtPrecioMayoreo").val());
    console.log($("#cboEjemplo").val());
    alert("update 3");
   
    VISTA.servicios.wsProductos.update3(clave2, $("#txtNombre").val(), $("#txtCantidad").val(), $("#txtPrecioCosto").val(),
        $("txtPrecioVenta").val(), $("txtPrecioMayoreo").val(), $("#cmbEjemplo").val(),success());
   
}
function success(response) {
    alert(response);
    alert("success");
}

function error(response){
    alert("error");
}

function regresar() {
    location.href = "ListaProducto.aspx";
}