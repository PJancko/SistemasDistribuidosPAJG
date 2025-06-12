using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace notificadorPago
{
    public class Factura
    {
        public string Empresa { get; set; }
        public string NroFactura { get; set; }
        public string CI { get; set; }
        public string NombreCompleto { get; set; }
        public string Periodo { get; set; }
        public decimal Monto { get; set; }
        public string Estado { get; set; }
    }
}