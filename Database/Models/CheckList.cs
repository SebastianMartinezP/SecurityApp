using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class CheckList
    {
        public CheckList()
        {
            Actividads = new HashSet<Actividad>();
        }

        public decimal Idcheck { get; set; }
        public string? Isseniales { get; set; }
        public string? Iselementoseguridad { get; set; }
        public string? Ismaterial { get; set; }
        public string? Isredagua { get; set; }
        public string? Isluminaria { get; set; }
        public string? Isseguro { get; set; }
        public string? Istrabajoseguro { get; set; }
        public string Descripcion { get; set; } = null!;
        public DateTime Fecharegistro { get; set; }

        public virtual ICollection<Actividad> Actividads { get; set; }
    }
}
