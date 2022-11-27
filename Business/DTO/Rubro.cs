using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public partial class Rubro
    {
        public decimal Idrubro { get; set; }
        public string Descripcion { get; set; } = null!;
        public Rubro()
        {

        }
    }
}
