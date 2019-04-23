<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="VISTA.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <title></title>   
    <link href="<%= ResolveClientUrl("~/Content/bootstrap.min.css") %>" rel="stylesheet" type="text/css" /> 
    <script src="<%= ResolveClientUrl("~/Scripts/jquery-3.3.1.min.js") %>" type="text/javascript"></script>
    <script src="<%= ResolveClientUrl("~/Scripts/bootstrap.min.js") %>" type="text/javascript"></script>

    <script src="Inicio.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <asp:ServiceReference Path="~/servicios/wsUsuarios.asmx" />
            </Services>
        </asp:ScriptManager> 
       <nav class="navbar navbar-expand-lg navbar-light bg-info text-white">
          <div class="collapse navbar-collapse" id="navbarSupportedContent">
            <ul class="navbar-nav mr-auto ">                          
            </ul>
            <ul class="navbar-nav justify-content-end">            
              <li class="nav-item">               
                <button type="button" class="btn btn-light" data-toggle="modal" data-target="#miModal">Iniciar Sesión</button>
              </li>
            </ul>
          </div>
        </nav>
        <div class="modal" tabindex="-1" role="dialog" id="miModal">
             <div class="modal-dialog" role="document">
                 <div class="modal-content">
                     <div class="modal-header">
                        <h5 class="modal-title text-center">Iniciar Sesión</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                          <span aria-hidden="true">&times;</span>
                        </button>
                     </div>
                     <div class="modal-body">                                                                          
                          <div class="form-group">                            
                            <input type="text" class="form-control" id="txtUser" aria-describedby="emailHelp" placeholder="Usuario"  runat="server"/>
                          </div>
                          <div class="form-group">                            
                            <input type="password" class="form-control" id="txtPassword" placeholder="Contraseña" runat="server"/>
                          </div>                                                  
                     </div>
                     <div class="modal-footer">
                         <button type="button" class="btn btn-info" runat="server" onclick="ingresar()">Iniciar</button>
                         <button type="button" class="btn btn-danger" data-dismiss="modal" runat="server">Cancelar</button>                         
                     </div>
                 </div>
             </div>
        </div>        
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
