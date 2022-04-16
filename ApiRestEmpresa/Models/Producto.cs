using System;
using System.Collections.Generic;

namespace ApiRestEmpresa.Models
{
    public partial class Producto
    {
        public Producto()
        {
            CatalogoInventarios = new HashSet<CatalogoInventario>();
        }

        public int IdProducto { get; set; }
        public string CodProducto { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int IdEstado { get; set; }
        public int IdProveedor { get; set; }

        public virtual Estado IdEstadoNavigation { get; set; } = null!;
        public virtual Proveedor IdProveedorNavigation { get; set; } = null!;
        public virtual ICollection<CatalogoInventario> CatalogoInventarios { get; set; }
    }
}
