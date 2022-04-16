using System;
using System.Collections.Generic;

namespace ApiRestEmpresa.Models
{
    public partial class TipoOrden
    {
        public TipoOrden()
        {
            Ordens = new HashSet<Orden>();
        }

        public int IdTipoOrden { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Orden> Ordens { get; set; }
    }
}
