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
    /// Descripción breve de wsInventario
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class wsInventario : System.Web.Services.WebService
    {
        [WebMethod]
        public string getAll()
        {
            InventarioDAO dao;
            dao = new InventarioDAO();
            List<Inventarios> lista;
            lista = dao.getAllInventario();
            String strJSON;

            strJSON = JsonConvert.SerializeObject(lista,
                          new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            return strJSON;
        }

        [WebMethod]
        public string ReporteInventario()
        {
            InventarioDAO dao;
            dao = new InventarioDAO();
            List<Inventarios> lista;
            lista = dao.getAll();
            String strJSON;

            strJSON = JsonConvert.SerializeObject(lista,
                          new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            return strJSON;
        }
        [WebMethod]
        public bool update(string id, string cant)
        {
            int codigo = Convert.ToInt32(id);
            int cantidad = Convert.ToInt32(cant);
            InventarioDAO dao;
            dao = new InventarioDAO();
            bool resultado = false;
            resultado = dao.updateProducto(codigo, cantidad);
            return resultado;
        }
        [WebMethod(EnableSession = true)]
        public bool insert(string id, string cant, string inco,string fecha)
        {
            int codigo = Convert.ToInt32(id);
            int cantidad = Convert.ToInt32(cant);
            int inconsistencias = Convert.ToInt32(inco);
            int codUsuario = Convert.ToInt32(Session["codigo"]);
            InventarioDAO dao;
            dao = new InventarioDAO();
            bool resultado = false;
            resultado = dao.insert(codigo,cantidad,inconsistencias,codUsuario,fecha);
            return resultado;
        }
    }
}
