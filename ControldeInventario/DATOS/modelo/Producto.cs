using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS.modelo
{
    public class Producto
    {
        public int Codigo { get; set; }
        public String Nombre { get; set; }
        public int Cantidad { get; set; }
        public Decimal PrecioCosto { get; set; }
        public Decimal PrecioPublico { get; set; }
        public Decimal PrecioMayoreo { get; set; }
        public int Categoria { get; set; }        
    }
}
