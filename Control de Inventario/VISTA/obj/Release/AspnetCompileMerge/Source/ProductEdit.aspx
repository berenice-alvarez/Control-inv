<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProductEdit.aspx.cs" Inherits="VISTA.ProductEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="ProductEdit.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <asp:ServiceReference Path="~/servicios/wsProductos.asmx" />
            </Services>
        </asp:ScriptManager>
    <h3 style="text-align:center">Editar Producto</h3>
     <div class="container" style="margin-top:5%">          
            <div class="row" style="margin-top:5%">
            <div class="col">
              <div class="form-group">                            
                <input type="text" class="form-control" id="txtNombre" aria-describedby="emailHelp" placeholder="Nombre" tabindex="2"/>
              </div>
            </div>
            <div class="col">
              <div class="form-group">                            
                <input type="text" class="form-control" id="txtPrecioVenta" aria-describedby="emailHelp" placeholder="PrecioVenta" tabindex="5"/>
              </div>
            </div>
          </div>
            <div class="row" style="margin-top:5%">
            <div class="col">
              <div class="form-group">                            
                <input type="text" class="form-control" id="txtCantidad" aria-describedby="emailHelp" placeholder="Cantidad" tabindex="3"/>
              </div>
            </div>
            <div class="col">
              <div class="form-group">                            
                <input type="text" class="form-control" id="txtPrecioMayoreo" aria-describedby="emailHelp" placeholder="PrecioMayoreo" tabindex="6"/>
              </div>
            </div>
          </div>
         <div class="row" style="margin-top:5%">
            <div class="col">
              <div class="form-group">                            
                <input type="text" class="form-control" id="txtPrecioCosto" aria-describedby="emailHelp" placeholder="PrecioCosto" tabindex="4"/> 
              </div>
            </div>
            <div class="col">
              <div class="form-group">                            
               <select class="form-control" tabindex="7" id="cboEjemplo">
                   <option value="">Seleccione uno...</option>
              </select>
              </div>
            </div>
          </div>          
            <div class="row" style="margin-top:5%">
            <div class="col">              
            </div>
            <div class="col" style="text-align:center">               
               <input type="button" class="btn btn-info" style="width:120px; font-weight:500" tabindex="8" value="Actualizar" onclick="update()">
               <button type="button" class="btn btn-danger" style="width:120px;font-weight:500" tabindex="9" onclick="regresar()">Cancelar</button>
            </div>
            <div class="col">              
            </div>
          </div>
        </div>
    <script type="text/javascript">
        function getCategoria() {
            var ddlCategoria = document.getElementById("cboEjemplo");
            var ajax = new XMLHttpRequest();
            ajax.onreadystatechange = function () {
            if (ajax.status == 200 && ajax.readyState == 4) {                
                var categoria = JSON.parse(this.responseText);                
                for (var i = 0; i < categoria.length; i++) {                    
                    var opt = document.createElement("option");
                    opt.value = categoria[i].codigo;
                    opt.text = categoria[i].nombre;                    
                    ddlCategoria.appendChild(opt);  
                }
            }
        }
          ajax.open("GET", "http://localhost:56311/servicios/wsProductos.asmx/llenar", true);
          //  ajax.open("GET", "http://berenicealvarez-001-site1.itempurl.com/servicios/wsProductos.asmx/llenar", true);
            ajax.send();
        }
        getCategoria();
    </script>
</asp:Content>
