<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ReporteInventario.aspx.cs" Inherits="VISTA.ReporteInventario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="ReporteInventario.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Services>
            <asp:ServiceReference Path="~/servicios/wsInventario.asmx" />
        </Services>
    </asp:ScriptManager>
    <h3 style="text-align:center">Reportes de Inventarios</h3>
    <table id="cargaDatos" class="table table-striped table-bordered small" style="margin: 0 auto; width: 90%">
    </table>
</asp:Content>
