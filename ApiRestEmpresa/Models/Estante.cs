using System;
using System.Collections.Generic;

namespace ApiRestEmpresa.Models
{
    public partial class Estante
    {
        public Estante()
        {
            CatalogoInventarios = new HashSet<CatalogoInventario>();
        }

        public int IdEstante { get; set; }
        public string Estante1 { get; set; } = null!;

        public virtual ICollection<CatalogoInventario> CatalogoInventarios { get; set; }
    }
}
