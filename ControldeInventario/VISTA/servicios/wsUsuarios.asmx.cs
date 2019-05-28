using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DATOS.modelo;
using DATOS.daos;
using Newtonsoft.Json;

namespace VISTA.servicios
{
    /// <summary>
    /// Descripción breve de wsUsuarios
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]

    public class wsUsuarios : System.Web.Services.WebService
    {        
        [WebMethod]
        public string getAll()
        {
            UsuarioDAO dao;
            dao = new UsuarioDAO();
            List<Usuario> lista;
            lista = dao.getAll();
            String strJSON;

            strJSON = JsonConvert.SerializeObject(lista,
                          new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            return strJSON;
        }
        [WebMethod]
        public Boolean insert(Usuario us)
        {
            UsuarioDAO dao = new UsuarioDAO();
            Boolean resultado = dao.insert(us);
            return resultado;
        }

        [WebMethod]
        public Boolean insert2(string nombre_pr,string apePat, string apeMat, string tel, string ema, string contra, string usua,string niv)
        {
            return insert(new Usuario() { Nombre = nombre_pr, ApellidoPaterno=apePat,ApellidoMaterno=apeMat,Telefono=tel,
            Email=ema,Password=contra,User=usua,Nivel=niv});
        }
        
        [WebMethod(EnableSession =true)]
        public bool ingresar(String usu, String pass) {            
            UsuarioDAO nd = new UsuarioDAO();
            if (nd.Ingresar(usu, pass) == true)
            {
                Session.Add("usuario", usu);
                return true;
            }
            else {
                return false;
            }
            
        }
    }
}
