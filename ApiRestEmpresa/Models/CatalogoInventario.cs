using System;
using System.Collections.Generic;

namespace ApiRestEmpresa.Models
{
    public partial class CatalogoInventario
    {
        public CatalogoInventario()
        {
            MovimientoInventarios = new HashSet<MovimientoInventario>();
        }

        public int IdCatalogoInventario { get; set; }
        public string CodInventario { get; set; } = null!;
        public long Cantidad { get; set; }
        public int IdProducto { get; set; }
        public int IdUbicacion { get; set; }
        public int IdEstante { get; set; }

        public virtual Estante IdEstanteNavigation { get; set; } = null!;
        public virtual Producto IdProductoNavigation { get; set; } = null!;
        public virtual Ubicacion IdUbicacionNavigation { get; set; } = null!;
        public virtual ICollection<MovimientoInventario> MovimientoInventarios { get; set; }
    }
}
