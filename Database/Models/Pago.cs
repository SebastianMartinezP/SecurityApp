using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class Pago
    {
        public decimal Idpago { get; set; }
        public DateTime Fecharegistro { get; set; }
        public decimal Montopago { get; set; }
        public decimal Idcomprobante { get; set; }
        public decimal Idcanalpago { get; set; }

        public virtual ComprobantePago IdcomprobanteNavigation { get; set; } = null!;
    }
}
