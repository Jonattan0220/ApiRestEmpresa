using System;
using System.Collections.Generic;

namespace ApiRestEmpresa.Models
{
    public partial class Estado
    {
        public Estado()
        {
            Productos = new HashSet<Producto>();
        }

        public int IdEstado { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
