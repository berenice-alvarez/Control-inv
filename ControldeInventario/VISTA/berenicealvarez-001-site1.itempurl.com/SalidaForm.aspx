<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SalidaForm.aspx.cs" Inherits="VISTA.SalidaForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="SalidaForm.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <asp:ServiceReference Path="~/servicios/wsSalidas.asmx" />
            </Services>
        </asp:ScriptManager>
    <h3 style="text-align:center">Nueva Salida de Productos</h3>
     <div class="container" style="margin-top:3%">
          <div class="row">
            <div class="col">
                <div class="form-group">                            
                    <input type="number" class="form-control" id="txtCodigo" aria-describedby="emailHelp" placeholder="Codigo del producto"/>
                </div>
                <div class="form-group">                            
                    <input type="number" class="form-control" id="txtCantidad" aria-describedby="emailHelp" placeholder="Cantidad"/>
                </div>
                <div class="form-group">                            
                    <input type="text" class="form-control" id="txtFecha" aria-describedby="emailHelp" disabled="true"/>
                </div>
                <div class="col">
              <asp:Label ID="Label1" runat="server" Text="Motivo/Razon">Motivo/Razón:</asp:Label>
              <br />
              <input id="rbdSa" type="radio" name="MotivoSalida" value="Salida a tienda" checked/> Salida a tienda
              <input id="rbdDe" type="radio" name="MotivoSalida" value="Defecto"/>Defecto
              <input id="rbdCa" type="radio" name="MotivoSalida" value="Cambio"/>Cambio
              </div>
              <div class="col" style="text-align:center">
                 <button type="button" class="btn btn-primary" style="width:120px; font-weight:500" onclick="guardar()">Agregar</button>
              </div> 
            </div>
            <div class="col">                
              <table  id="example" class="table table-striped table-bordered small" style="margin: 0 auto; width:90%" >  
              </table>  
            </div>
          </div>                               
         <div class="row" style="margin-top:2%">
            <table class="table table-hover">
              <thead>
                <tr>
                  <th scope="col">Codigo</th>                  
                  <th scope="col">Cantidad</th>
                  <th scope="col">Fecha</th>
                  <th scope="col">Motivo/Razon</th>                  
                </tr>
              </thead>
              <tbody id="tblProducto">                              
              </tbody>
            </table>
          </div>   
        </div>                 
    <div  class="container">
    <div class="row" style="margin-top:5%">
              <div class="col">              
              </div>
               <div class="col" style="text-align:center">               
                  <button type="button" class="btn btn-info" data-toggle="modal" data-target="#miModal">Finalizar</button>
             </div>
             <div class="col">              
             </div>
              </div>
        </div>
    <div class="modal" tabindex="-1" role="dialog" id="miModal">
             <div class="modal-dialog" role="document">
                 <div class="modal-content">
                     <div class="modal-header">
                        <h5 class="modal-title text-center">Finalizar</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                          <span aria-hidden="true">&times;</span>
                        </button>
                     </div>
                     <div class="modal-body">                                                                          
                          <p>¿Finalizar registro de entradas?</p>                                                
                     </div>
                     <div class="modal-footer">
                         <asp:button type="button" class="btn btn-info" runat="server" onclick="btnAceptar_click" Text="Aceptar"></asp:button>
                         <button type="button" class="btn btn-danger" data-dismiss="modal" runat="server">Cancelar</button>                         
                     </div>
                 </div>
             </div>
        </div> 
</asp:Content>
