using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Actividads = new HashSet<Actividad>();
            Contratos = new HashSet<Contrato>();
            Usuarios = new HashSet<Usuario>();
        }

        public string Rutcliente { get; set; } = null!;
        public string Razonsocial { get; set; } = null!;
        public string? Numerocontacto { get; set; }
        public string Ismoroso { get; set; } = null!;
        public decimal Idrubro { get; set; }

        public virtual Rubro IdrubroNavigation { get; set; } = null!;
        public virtual ICollection<Actividad> Actividads { get; set; }
        public virtual ICollection<Contrato> Contratos { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
