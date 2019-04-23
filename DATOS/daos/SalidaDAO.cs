using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATOS.modelo;
using DATOS.util;
using MySql.Data.MySqlClient;
using System.Data;

namespace DATOS.daos
{
    public class SalidaDAO
    {
        public List<Salida> getAllReporte()
        {
            List<Salida> lista = new List<Salida>();
            Conexion con = new Conexion();

            DataSet datos = con.LLenaComboGrid("SELECT * FROM Salida;");
            DataTable dt = datos.Tables[0];
            Salida s;
            foreach (DataRow r in dt.Rows)
            {
                s = new Salida();
                s.codigo = (int)r.ItemArray[0];
                s.codigoProducto = (int)r.ItemArray[1];
                s.cantidadProductos = (int)r.ItemArray[2];
                s.razonSalida = (string)r.ItemArray[3];
                s.fecha = (DateTime)r.ItemArray[4];
                s.codigoUsuario = (int)r.ItemArray[5];                
                lista.Add(s);
            }
            return lista;
        }
    }
}
