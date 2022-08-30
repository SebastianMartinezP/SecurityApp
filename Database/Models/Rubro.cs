using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class Rubro
    {
        public Rubro()
        {
            Clientes = new HashSet<Cliente>();
        }

        public decimal Idrubro { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
