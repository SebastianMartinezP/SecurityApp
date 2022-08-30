using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class ComprobantePago
    {
        public ComprobantePago()
        {
            Pagos = new HashSet<Pago>();
        }

        public decimal Idcomprobante { get; set; }
        public string Numerotarjeta { get; set; } = null!;
        public decimal Pintarjeta { get; set; }
        public string Fechavalida { get; set; } = null!;
        public DateTime Fecharegistro { get; set; }
        public decimal Monto { get; set; }
        public string Tipomoneda { get; set; } = null!;
        public decimal Valorusd { get; set; }
        public decimal Valoruf { get; set; }
        public decimal Valorutm { get; set; }

        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
