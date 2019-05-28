function ingresar() {    
    VISTA.servicios.wsUsuarios.ingresar($("#txtUser").val(), $("#txtPassword").val(),onSuccess, onError);
}

function onSuccess() {    
    
    alert("Usuario correcto");
    location.href = "ListaProducto.aspx";
    //Response.Redirect("ListaProducto.aspx");
}
function onError() {
    alert("Usuario y/o contraseña incorrectos");
}
