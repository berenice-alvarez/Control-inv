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
           <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
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
        <div style="background-color:rgb(155, 152, 152); margin-left:20%;margin-right:20%; margin-top:2.5%;margin-bottom:2.5%"class="row justify-content-center"  >
            <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                <ol class="carousel-indicators">
                    <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                    <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                    <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                </ol>
                <div class="carousel-inner">
                    <div class="carousel-item active">
                        <img class="d-block w-100" style="height:500px; width:30px" src="img/image.png" alt="First slide"/>
                    </div>
                    <div class="carousel-item">
                        <img class="d-block w-100" style="height:500px; width:30px" src="img/image1.png" alt="First slide"/>
                    </div>
                    <div class="carousel-item">
                        <img class="d-block w-100" style="height:500px; width:30px" src="img/image2.png" alt="First slide"/>
                    </div>
                </div>
                <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>            
        </div>
        
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
     <script type="text/javascript">
        $('.carousel').carousel({
        interval: 5000
     })
    </script>
    </form>   
</body>   
</html>
