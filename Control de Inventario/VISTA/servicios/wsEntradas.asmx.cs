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
    /// Descripción breve de wsEntradas
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class wsEntradas : System.Web.Services.WebService
    {

        [WebMethod]
        public string getOne(int Id)
        {
            ProductoDAO dao = new ProductoDAO();                         
            String nombre = dao.Buscar2(Id).Nombre;
            return nombre;
        }
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

        [WebMethod(EnableSession = true)]
        public bool Registrar(int id, int can, decimal precio,decimal subt, string fech) {
            int codUsuario = Convert.ToInt32(Session["codigo"]);
            bool resultado = false;
            EntradaDAO dao = new EntradaDAO();
            resultado = dao.Registrar(id, can, precio,subt, codUsuario, fech);
            return resultado;
        }
        [WebMethod]
        public string getAllReporte()
        {
            ReporteEntradasDAO dao;
            dao = new ReporteEntradasDAO();
            List<ReporteEntradas> lista;
            lista = dao.getAll();
            String strJSON;

            strJSON = JsonConvert.SerializeObject(lista, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            return strJSON;
        }
    }
}
