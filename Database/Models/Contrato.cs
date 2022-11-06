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
        public decimal Idactividad { get; set; }
        public string Vigente { get; set; } = null!;

        public virtual Actividad IdactividadNavigation { get; set; } = null!;
        public virtual Cliente RutclienteNavigation { get; set; } = null!;
    }
}
