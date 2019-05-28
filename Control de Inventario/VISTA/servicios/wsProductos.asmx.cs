using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using DATOS.daos;
using DATOS.modelo;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace VISTA.servicios
{
    /// <summary>
    /// Descripción breve de wsProductos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class wsProductos : System.Web.Services.WebService
    {

        [WebMethod]
        public string getAll()
        {
            ProductoDAO dao;
            dao = new ProductoDAO();
            List<Producto> lista;
            lista = dao.getAll();
            String strJSON;

            strJSON = JsonConvert.SerializeObject(lista,
                          new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            return strJSON;
        }
        [WebMethod]
        public Boolean insert(Producto pr)
        {
            ProductoDAO dao = new ProductoDAO();
            Boolean resultado = dao.insert(pr);
            return resultado;
        }

        [WebMethod]
        public Boolean insert2(string nombre_pr, int cant_pro, decimal precioCos, decimal precioPub, decimal precioMay, int cat)
        {
            return insert(new Producto() { Nombre = nombre_pr, Cantidad = cant_pro, PrecioCosto = precioCos, PrecioPublico = precioPub, PrecioMayoreo = precioMay, Categoria = cat});
        }
        
        [WebMethod]
        public void llenar()
        {
            CategoriaDAO dao;
            dao = new CategoriaDAO();
            List<Categoria> lista;
            lista = dao.Llenar();
            //            String strJSON;

            //strJSON = JsonConvert.SerializeObject(lista,
            //              new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            JavaScriptSerializer jsr = new JavaScriptSerializer();
            Context.Response.Output.Write(jsr.Serialize(lista));

            //return strJSON;

        }
    }
}
