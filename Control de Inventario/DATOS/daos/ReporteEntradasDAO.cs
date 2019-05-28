using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATOS.util;
using DATOS.modelo;
using System.Data;

namespace DATOS.daos
{
    public class ReporteEntradasDAO
    {
        public List<ReporteEntradas> getAll()
        {
            List<ReporteEntradas> lista = new List<ReporteEntradas>();
            Conexion con = new Conexion();

            DataSet datos = con.LLenaComboGrid("SELECT * FROM ReporteEntrada");
            DataTable dt = datos.Tables[0];
            ReporteEntradas re;
            foreach (DataRow r in dt.Rows)
            {
                re = new ReporteEntradas();
                re.codigo = (int)r.ItemArray[0];
                re.codigoPro = (int)r.ItemArray[1];
                re.nombrePro = (string)r.ItemArray[2];
                re.cantidadPro = (int)r.ItemArray[3];
                re.precioUnitario = (decimal)r.ItemArray[4];
                re.subtotal = (decimal)r.ItemArray[5];
                re.fecha = (string)r.ItemArray[6];
                re.nombreEm = (string)r.ItemArray[7];
                lista.Add(re);
            }

            return lista;
        }
    }
}
