using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public partial class Pago
    {
        public Pago()
        {

        }
        public decimal Idpago { get; set; }
        public DateTime Fecharegistro { get; set; }
        public decimal Montopago { get; set; }
        public decimal Idcomprobante { get; set; }
        public decimal Idcanalpago { get; set; }
    }
}
