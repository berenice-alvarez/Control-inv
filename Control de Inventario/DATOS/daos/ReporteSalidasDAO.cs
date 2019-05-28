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
    public class ReporteSalidasDAO
    {
        public List<ReporteSalidas> getAll()
        {
            List<ReporteSalidas> lista = new List<ReporteSalidas>();
            Conexion con = new Conexion();

            DataSet datos = con.LLenaComboGrid("SELECT * FROM ReporteSalidas");
            DataTable dt = datos.Tables[0];
            ReporteSalidas re;
            foreach (DataRow r in dt.Rows)
            {
                re = new ReporteSalidas();
                re.codigo = (int)r.ItemArray[0];
                re.codigoPro = (int)r.ItemArray[1];
                re.nombrePro = (string)r.ItemArray[2];
                re.cantidadPro = (int)r.ItemArray[3];
                re.razonSalida = (string)r.ItemArray[4];
                re.fecha = (string)r.ItemArray[5];
                re.nombreEm = (string)r.ItemArray[6];
                lista.Add(re);
            }

            return lista;
        }

    }
}
