<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListaCategorias.aspx.cs" Inherits="VISTA.ListaCategorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="ListaCategorias.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <asp:ServiceReference Path="~/servicios/wsCategorias.asmx" />
            </Services>
        </asp:ScriptManager> 
        <h3 style="text-align:center">Lista de Categorias</h3>
        <table  id="example" class="table table-striped table-bordered small" style="margin: 0 auto; width:90%" >  
        </table>  
</asp:Content>
