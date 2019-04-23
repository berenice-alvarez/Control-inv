function ingresar() {    
    VISTA.servicios.wsUsuarios.ingresar($("#txtUser").val(), $("#txtPassword").val(),onSuccess, onError);
}

function onSuccess() {
    alert("Exito");        
}
function onError() {
    alert("Usuario y/o contraseña incorrectos");    
}
