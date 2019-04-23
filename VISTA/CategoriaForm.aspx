<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CategoriaForm.aspx.cs" Inherits="VISTA.CategoriaForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="CategoriaForm.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <asp:ServiceReference Path="~/servicios/wsCategorias.asmx" />
            </Services>
        </asp:ScriptManager>
    <div class="container" style="margin-top:5%">          
            <div class="row" style="margin-top:5%">
            <div class="col">
              <div class="form-group">                            
                <input type="text" class="form-control" id="txtNombre" aria-describedby="emailHelp" placeholder="Nombre" tabindex="2"/>
              </div>
            </div>
            <div class="col">
              <div class="form-group">                            
                <input type="text" class="form-control" id="txtDescripcion" aria-describedby="emailHelp" placeholder="Descripción" tabindex="5"/>
              </div>
            </div>
          </div>                             
            <div class="row" style="margin-top:5%">
            <div class="col">              
            </div>
            <div class="col" style="text-align:center">               
               <button type="button" class="btn btn-info" style="width:120px; font-weight:500" tabindex="8" onclick="insert()">Registrar</button>
               <button type="button" class="btn btn-danger" style="width:120px;font-weight:500" tabindex="9">Cancelar</button>
            </div>
            <div class="col">              
            </div>
          </div>
        </div>
</asp:Content>
