using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class Actividad
    {
        public Actividad()
        {
            Contratos = new HashSet<Contrato>();
        }

        public decimal Idactividad { get; set; }
        public string Descripcion { get; set; } = null!;
        public DateTime? Fechainicio { get; set; }
        public DateTime? Fechatermino { get; set; }
        public DateTime? Horainicio { get; set; }
        public DateTime? Horatermino { get; set; }
        public decimal? Cantidadasistente { get; set; }
        public DateTime? Fecharegistro { get; set; }
        public string? Direccion { get; set; }
        public decimal Idtipoactividad { get; set; }
        public string Rutcliente { get; set; } = null!;
        public string? Rutprofesional { get; set; } = null!;
        public decimal? Idcheck { get; set; }

        public virtual CheckList? IdcheckNavigation { get; set; }
        public virtual TipoActividad IdtipoactividadNavigation { get; set; } = null!;
        public virtual Cliente RutclienteNavigation { get; set; } = null!;
        public virtual Profesional RutprofesionalNavigation { get; set; } = null!;
        public virtual ICollection<Contrato> Contratos { get; set; }
    }
}
