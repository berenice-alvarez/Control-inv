using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DATOS.modelo;
using DATOS.daos;

namespace VISTA
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((string)Session["usuario"] == "")
            {
                Response.Redirect("Inicio.aspx");
            }
            else {
                UsuarioDAO dao = new UsuarioDAO();
                Usuario usu = new Usuario();                
                String usuario = Convert.ToString(Session["usuario"]);
                usu=dao.getOne(usuario);
                lblUsuario.Text = Convert.ToString(usu.Nombre + " " + usu.ApellidoPaterno + " " + usu.ApellidoMaterno);
                Session.Add("codigo", usu.Codigo);
            }
        }

        protected void CerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Remove("usuario");
            Response.Redirect("Inicio.aspx");
        }
    }
}