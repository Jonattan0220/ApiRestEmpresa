using System;
using System.Collections.Generic;

namespace ApiRestEmpresa.Models
{
    public partial class Ubicacion
    {
        public Ubicacion()
        {
            CatalogoInventarios = new HashSet<CatalogoInventario>();
        }

        public int IdUbicacion { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<CatalogoInventario> CatalogoInventarios { get; set; }
    }
}
