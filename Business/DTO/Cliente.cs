using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public partial class Cliente
    {

        public string Rutcliente { get; set; } = null!;
        public string Razonsocial { get; set; } = null!;
        public string? Numerocontacto { get; set; }
        public string Ismoroso { get; set; } = null!;
        public decimal Idrubro { get; set; }

        public Cliente()
        {

        }

    }
}