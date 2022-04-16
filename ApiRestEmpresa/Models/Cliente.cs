using System;
using System.Collections.Generic;

namespace ApiRestEmpresa.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Facturas = new HashSet<Factura>();
        }

        public int IdCliente { get; set; }
        public string CodCliente { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string? TelefonoFijo { get; set; }
        public string? TelefonoMovil { get; set; }
        public string? Email { get; set; }
        public int? EstratoSocioeconomico { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
