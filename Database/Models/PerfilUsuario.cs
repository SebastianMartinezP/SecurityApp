using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class PerfilUsuario
    {
        public PerfilUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public decimal Idperfil { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
