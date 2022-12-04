using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface
{
    public class ReportClienteContratoModel
    {
        public ReportClienteContratoModel()
        {

        }

        public string? Rutcliente { get; set; } = null!;
        public string? Razonsocial { get; set; } = null!;
        public string? Rubro { get; set; }

        public decimal? Asesorias { get; set; }
        public decimal? AsesoriasDisponible { get; set; }
        public decimal? AsesoriasExtra { get; set; }

        public decimal? Capacitaciones { get; set; }
        public decimal? CapacitacionesDisponible { get; set; }
        public decimal? CapacitacionesExtra { get; set; }
        

    }
}
