﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATOS.modelo
{
    public class ReporteEntradas
    {
        public int codigo { get; set; }
        public int codigoPro { get; set; }
        public string nombrePro { get; set; }
        public int cantidadPro { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal subtotal { get; set; }
        public string fecha { get; set; }
        public string nombreEm { get; set; }
    }
}
