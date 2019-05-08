function insert() {       
    VISTA.servicios.wsCategorias.Registrar($("#txtNombre").val(), $("#txtDescripcion").val(), onSuccess, onError);
}
function onSuccess() {
    alert("Exito");
    $("#txtNombre").val("");
    $("#txtDescripcion").val("");
}
function onError() {
    alert("Error");
}