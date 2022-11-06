using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public partial class Actividad
    {

        public decimal Idactividad { get; set; }
        public string Descripcion { get; set; } = null!;
        public DateTime Fechainicio { get; set; }
        public DateTime Fechatermino { get; set; }
        public DateTime Horainicio { get; set; }
        public DateTime Horatermino { get; set; }
        public decimal? Cantidadasistente { get; set; }
        public DateTime? Fecharegistro { get; set; }
        public string? Direccion { get; set; }
        public decimal Idtipoactividad { get; set; }
        public string Rutcliente { get; set; } = null!;
        public string Rutprofesional { get; set; } = null!;
        public decimal? Idcheck { get; set; }


        public Actividad()

        {

        }
    }
}