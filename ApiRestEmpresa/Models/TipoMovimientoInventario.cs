using System;
using System.Collections.Generic;

namespace ApiRestEmpresa.Models
{
    public partial class TipoMovimientoInventario
    {
        public TipoMovimientoInventario()
        {
            MovimientoInventarios = new HashSet<MovimientoInventario>();
        }

        public int IdTipoMovInventario { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<MovimientoInventario> MovimientoInventarios { get; set; }
    }
}
