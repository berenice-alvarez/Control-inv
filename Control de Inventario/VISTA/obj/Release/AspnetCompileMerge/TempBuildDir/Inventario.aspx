<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Inventario.aspx.cs" Inherits="VISTA.Inventario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Inventario.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <asp:ServiceReference Path="~/servicios/wsInventario.asmx" />
            </Services>
        </asp:ScriptManager>             
    <h3 style="text-align:center">Realizar Inventario</h3>
        <table  id="example" class="table table-striped table-bordered small" style="margin: 0 auto; width:90%" >  
        </table>   
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
                          <p>¿Ha finalizado el registro de inventario?
                              NOTA:
                              Se recomienda no cerrar ni actualizar la pagina si no se ha finalizado el registro ya que los cambios realizados se han guardado en la base de datos
                          </p>                                                
                     </div>
                     <div class="modal-footer">
                         <asp:button type="button" class="btn btn-info" runat="server" onclick="btnAceptar_click" Text="Aceptar"></asp:button>
                         <button type="button" class="btn btn-danger" data-dismiss="modal" runat="server">Cancelar</button>                         
                     </div>
                 </div>
             </div>
        </div> 
</asp:Content>
