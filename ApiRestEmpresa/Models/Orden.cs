using System;
using System.Collections.Generic;

namespace ApiRestEmpresa.Models
{
    public partial class Orden
    {
        public Orden()
        {
            Facturas = new HashSet<Factura>();
            MovimientoInventarios = new HashSet<MovimientoInventario>();
        }

        public int IdOrden { get; set; }
        public string CodOrden { get; set; } = null!;
        public int IdTipoOrden { get; set; }

        public virtual TipoOrden IdTipoOrdenNavigation { get; set; } = null!;
        public virtual ICollection<Factura> Facturas { get; set; }
        public virtual ICollection<MovimientoInventario> MovimientoInventarios { get; set; }
    }
}
