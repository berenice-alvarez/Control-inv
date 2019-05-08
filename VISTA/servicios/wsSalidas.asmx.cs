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
    /// Descripción breve de wsSalidas
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    [System.Web.Script.Services.ScriptService]
    public class wsSalidas : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
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
        [WebMethod]
        public bool Registrar(int id, int can, string razon,int codUsu, string fech)
        {
            bool resultado = false;
            SalidaDAO dao = new SalidaDAO();
            resultado = dao.Registrar(id, can, razon, codUsu, fech);
            return resultado;
        }

        //[WebMethod]
       // public string getAllReporte()
        //{
            //ReporteSalidasDAO dao;
            //dao = new ReporteSalidasDAO();
           // List<ReporteSalidas> lista;
           // lista = dao.getAll();
            //String strJSON;

           // strJSON = JsonConvert.SerializeObject(lista, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

            //return strJSON;
        //}
    }
}
