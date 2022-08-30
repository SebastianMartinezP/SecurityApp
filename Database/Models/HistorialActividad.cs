using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class HistorialActividad
    {
        public decimal Idhistorial { get; set; }
        public decimal? Cantcapacitaciones { get; set; }
        public decimal? Cantaccidentesasistidos { get; set; }
        public DateTime? Fecharegistro { get; set; }
        public string Rutprofesional { get; set; } = null!;

        public virtual Profesional RutprofesionalNavigation { get; set; } = null!;
    }
}
