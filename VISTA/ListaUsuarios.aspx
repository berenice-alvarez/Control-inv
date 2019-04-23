<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListaUsuarios.aspx.cs" Inherits="VISTA.ListaUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="ListaUsuarios.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <asp:ServiceReference Path="~/servicios/wsUsuarios.asmx" />
            </Services>
        </asp:ScriptManager> 
        <br />
        <table  id="example" class="table table-striped table-bordered small" style="margin: 0 auto; width:90%; margin-top:2%; " >  
        </table> 
</asp:Content>
