using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class TipoActividad
    {
        public TipoActividad()
        {
            Actividads = new HashSet<Actividad>();
        }

        public decimal Idtipoactividad { get; set; }
        public string Descripcion { get; set; } = null!;
        public decimal Montoactividad { get; set; }

        public virtual ICollection<Actividad> Actividads { get; set; }
    }
}
