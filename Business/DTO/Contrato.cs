using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public partial class Contrato
    {
        public Contrato()
        {

        }

        public decimal Idcontrato { get; set; }
        public string Descripcion { get; set; } = null!;
        public decimal Valor { get; set; }
        public DateTime Fechacontrato { get; set; }
        public decimal Idpago { get; set; }
        public string Rutcliente { get; set; } = null!;
        public decimal Idactividad { get; set; }
        public string Vigente { get; set; } = null!;
        public decimal? Asesoria { get; set; }
        public decimal? Capacitacion { get; set; }
        public decimal? AsesoriaDisponible { get; set; }
        public decimal? CapacitacionDisponible { get; set; }
        public decimal? AsesoriaExtra { get; set; }
        public decimal? CapacitacionExtra { get; set; }
    }
}
