using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS.modelo
{
    public class Entrada
    {
        public int codigo { get; set; }
        public int codigoProducto { get; set; }
        public int cantidadProductos { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal subtotal { get; set; }
        public int codigoUsuario { get; set; }
        public DateTime fecha { get; set; }
    }
}
