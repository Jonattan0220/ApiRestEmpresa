using System;
using System.Collections.Generic;

namespace ApiRestEmpresa.Models
{
    public partial class Proveedor
    {
        public Proveedor()
        {
            Productos = new HashSet<Producto>();
        }

        public int IdProveedor { get; set; }
        public string CodProveedor { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public bool Estado { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
