<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaProducto.aspx.cs" Inherits="VISTA.ListaProducto" MasterPageFile="~/MasterPage.Master" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <script src="ListaProducto.js"></script>
</asp:Content>
<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">       
    <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <asp:ServiceReference Path="~/servicios/wsProductos.asmx" />
            </Services>
        </asp:ScriptManager> 
        <h3 style="text-align:center">Lista de Productos</h3>    
        <table  id="example" class="table table-striped table-bordered small" style="margin: 0 auto; width:90%" >  
        </table>       
</asp:Content>


