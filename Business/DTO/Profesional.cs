using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public partial class Profesional
    {
        public string Rutprofesional { get; set; } = null!;
        public string Primernombre { get; set; } = null!;
        public string? Segundonombre { get; set; }
        public string Primerapellido { get; set; } = null!;
        public string Segundoapellido { get; set; } = null!;
        public string Numerocontacto { get; set; } = null!;
        public string Isvigente { get; set; } = null!;


        public Profesional()
        {
        }



    }
}
