using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace servidorPagos
{
    public class Deuda
    {
        public string Entidad { get; set; } // "CESSA" o "ELAPAS"
        public string Codigo { get; set; }
        public string Concepto { get; set; }
        public decimal Monto { get; set; }
        public string ci { get; set; } // CI del usuario
    }
}