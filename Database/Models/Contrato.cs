using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class Contrato
    {
        public decimal Idcontrato { get; set; }
        public string Descripcion { get; set; } = null!;
        public decimal Valor { get; set; }
        public DateTime Fechacontrato { get; set; }
        public decimal Idpago { get; set; }
        public string Rutcliente { get; set; } = null!;
        public decimal? Idactividad { get; set; }
        public string Vigente { get; set; } = null!;
        public decimal? Asesoria { get; set; }
        public decimal? Capacitacion { get; set; }
        public decimal? AsesoriaDisponible { get; set; }
        public decimal? CapacitacionDisponible { get; set; }
        public decimal? AsesoriaExtra { get; set; }
        public decimal? CapacitacionExtra { get; set; }

        public virtual Actividad IdactividadNavigation { get; set; } = null!;
        public virtual Cliente RutclienteNavigation { get; set; } = null!;
    }
}
