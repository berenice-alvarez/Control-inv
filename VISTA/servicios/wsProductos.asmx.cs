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
    }
}
