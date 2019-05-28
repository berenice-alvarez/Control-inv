using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DATOS.daos;
using DATOS.modelo;
using Newtonsoft.Json;

namespace VISTA.servicios
{
    /// <summary>
    /// Descripción breve de wsCategorias
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class wsCategorias : System.Web.Services.WebService
    {
        [WebMethod]
        public string getAll()
        {
            CategoriaDAO dao;
            dao = new CategoriaDAO();
            List<Categoria> lista;
            lista = dao.getAll();
            String strJSON;
            strJSON = JsonConvert.SerializeObject(lista,
                          new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            return strJSON;
        }

        [WebMethod]
        public bool Registrar(string nomb, string desc) {
            CategoriaDAO dao = new CategoriaDAO();
            bool resultado = false;
            resultado = dao.Registrar(nomb,desc);
            return resultado;
        }
    }
}
