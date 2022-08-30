using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class Profesional
    {
        public virtual ICollection<Actividad> Actividads { get; set; }
        public virtual ICollection<HistorialActividad> HistorialActividads { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }

        public Profesional()
        {
            Actividads = new HashSet<Actividad>();
            HistorialActividads = new HashSet<HistorialActividad>();
            Usuarios = new HashSet<Usuario>();
        }

        public string Rutprofesional { get; set; } = null!;
        public string Primernombre { get; set; } = null!;
        public string? Segundonombre { get; set; }
        public string Primerapellido { get; set; } = null!;
        public string Segundoapellido { get; set; } = null!;
        public string Numerocontacto { get; set; } = null!;
        public string Isvigente { get; set; } = null!;

    }
}
