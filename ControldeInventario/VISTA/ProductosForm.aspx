<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProductosForm.aspx.cs" Inherits="VISTA.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="ProductosForm.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <asp:ServiceReference Path="~/servicios/wsProductos.asmx" />
            </Services>
        </asp:ScriptManager>
    <h3 style="text-align:center">Nuevo Producto</h3>
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
               <select class="form-control" tabindex="7" id="cmbCategoria">
                <option value="1">Ganchos</option>
                  <option value="2">Cromados</option>
                  <option value="3">Cascadas</option>                  
              </select>
              </div>
            </div>
          </div>          
            <div class="row" style="margin-top:5%">
            <div class="col">              
            </div>
            <div class="col" style="text-align:center">               
               <input type="button" class="btn btn-info" style="width:120px; font-weight:500" tabindex="8" value="Registrar" onclick="insert()">
               <button type="button" class="btn btn-danger" style="width:120px;font-weight:500" tabindex="9">Cancelar</button>
            </div>
            <div class="col">              
            </div>
          </div>
        </div>
</asp:Content>
