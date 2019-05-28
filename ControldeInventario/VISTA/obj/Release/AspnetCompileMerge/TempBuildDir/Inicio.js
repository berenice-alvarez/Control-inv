function ingresar() {    
    VISTA.servicios.wsUsuarios.ingresar($("#txtUser").val(), $("#txtPassword").val(),onSuccess, onError);
}

function onSuccess() {     
    location.href = "ListaProducto.aspx";
}
function onError() {
    alert("Usuario y/o contraseña incorrectos");
}
