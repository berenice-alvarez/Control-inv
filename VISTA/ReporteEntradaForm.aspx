<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ReporteEntradaForm.aspx.cs" Inherits="VISTA.ReporteEntradaForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="ReporteEntradaForm.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Services>
            <asp:ServiceReference Path="~/servicios/wsEntradas.asmx" />
        </Services>
    </asp:ScriptManager>

    <table id="cargaDatos" class="table table-striped table-bordered small" style="margin: 0 auto; width: 90%">
    </table>
</asp:Content>
