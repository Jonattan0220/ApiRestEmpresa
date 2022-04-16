using System;
using System.Collections.Generic;

namespace ApiRestEmpresa.Models
{
    public partial class MovimientoInventario
    {
        public int IdMovimientoInventario { get; set; }
        public string CodMovimientoInventario { get; set; } = null!;
        public int IdCatalogoInventario { get; set; }
        public int IdTipoMovInventario { get; set; }
        public int IdOrden { get; set; }

        public virtual CatalogoInventario IdCatalogoInventarioNavigation { get; set; } = null!;
        public virtual Orden IdOrdenNavigation { get; set; } = null!;
        public virtual TipoMovimientoInventario IdTipoMovInventarioNavigation { get; set; } = null!;
    }
}
