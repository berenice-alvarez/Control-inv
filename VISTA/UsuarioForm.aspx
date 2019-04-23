<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UsuarioForm.aspx.cs" Inherits="VISTA.UsuarioForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="UsuarioForm.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <asp:ServiceReference Path="~/servicios/wsUsuarios.asmx" />
            </Services>
        </asp:ScriptManager>
    <div class="container" style="margin-top:5%">
          <div class="row">
            <div class="col">
              <div class="form-group">                            
                <input type="text" class="form-control" id="txtNombre" aria-describedby="emailHelp" placeholder="Nombre" tabindex="2"/>
              </div>
            </div>
            <div class="col">
              <div class="form-group">                            
                <input type="text" class="form-control" id="txtUsuario" aria-describedby="emailHelp" placeholder="Usuario" tabindex="7"/>
              </div>
            </div>
          </div>
            <div class="row" style="margin-top:2%">
            <div class="col">
              <div class="form-group">                            
                <input type="text" class="form-control" id="txtApellidoPaterno" aria-describedby="emailHelp" placeholder="Apellido Paterno" tabindex="3"/>
              </div>
            </div>
            <div class="col">
              <div class="form-group">                            
                <input type="password" class="form-control" id="txtContraseña" aria-describedby="emailHelp" placeholder="Contraseña" tabindex="8"/>
              </div>
            </div>
          </div>
            <div class="row" style="margin-top:2%">
            <div class="col">
              <div class="form-group">                            
                <input type="text" class="form-control" id="txtApellidoMaterno" aria-describedby="emailHelp" placeholder="Apellido Materno" tabindex="4"/>
              </div>
            </div>
            <div class="col">
              <div class="form-group">                            
                <input type="password" class="form-control" id="txtConfirmarContrasea" aria-describedby="emailHelp" placeholder="Confirmar Contraseña" tabindex="9"/>
              </div>
            </div>
          </div>
        <div class="row" style="margin-top:2%">
            <div class="col">
              <div class="form-group">                            
                <input type="text" class="form-control" id="txtTelefono" aria-describedby="emailHelp" placeholder="Telefono"tabindex="5"/>
              </div>
            </div>
            <div class="col">
              <select class="form-control" tabindex="10" id="cmbNivel">
                <option>Administrador</option>
                <option>Empleado</option>
              </select>
            </div>
          </div>
        <div class="row" style="margin-top:2%">
            <div class="col">
                <div class="form-group">                            
                    <input type="text" class="form-control" id="txtEmail" aria-describedby="emailHelp" placeholder="Email" tabindex="6"/>
                </div>
            </div>
            <div class="col">
              
            </div>
          </div>          
            <div class="row" style="margin-top:5%">
            <div class="col">              
            </div>
            <div class="col" style="text-align:center">               
               <button type="button" class="btn btn-info" style="width:120px; font-weight:500" tabindex="11" onclick="insert()">Registrar</button>
               <button type="button" class="btn btn-danger" style="width:120px;font-weight:500" tabindex="12" >Cancelar</button>
            </div>
            <div class="col">              
            </div>
          </div>
        </div>
</asp:Content>
