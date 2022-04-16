using System;
using System.Collections.Generic;

namespace ApiRestEmpresa.Models
{
    public partial class Factura
    {
        public int IdFactura { get; set; }
        public string CodFactura { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public long PrecioUnitario { get; set; }
        public long PrecioTotal { get; set; }
        public int IdOrden { get; set; }
        public int IdCliente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual Orden IdOrdenNavigation { get; set; } = null!;
    }
}
