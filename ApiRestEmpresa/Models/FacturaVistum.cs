using System;
using System.Collections.Generic;

namespace ApiRestEmpresa.Models
{
    public partial class FacturaVistum
    {
        public int IdFactura { get; set; }
        public string CodFactura { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public long PrecioUnitario { get; set; }
        public long PrecioTotal { get; set; }
        public int IdOrden { get; set; }
        public string CodOrden { get; set; } = null!;
        public string TipoOrden { get; set; } = null!;
        public int IdCliente { get; set; }
        public string CodCliente { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string? TelefonoFijo { get; set; }
        public string? TelefonoMovil { get; set; }
        public string? Email { get; set; }
        public int? EstratoSocioeconomico { get; set; }
    }
}
