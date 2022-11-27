using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public partial class TipoActividad
    {
        public decimal Idtipoactividad { get; set; }
        public string Descripcion { get; set; } = null!;
        public decimal Montoactividad { get; set; }

        public TipoActividad()
        {

        }
    }
}
