using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DATOS.daos;

namespace VISTA
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Add("Usuario", "");
        }
        public void btnIniciarSesion_click(object sender, EventArgs e)
        {
            String usuario = txtUser.Value.ToString();
            String pass = txtPassword.Value.ToString();

            UsuarioDAO nd = new UsuarioDAO();
            if (nd.Ingresar(usuario, pass) == true)
            {

                Response.Redirect("ListaProducto.aspx");
            }
            else
            {
                Label1.Text = "Algo salio mal en usuario y/o contraseña";
            }
        }
    }
}