using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class Usuario
    {
        public decimal Idusuario { get; set; }
        public string Correo { get; set; } = null!;
        public string Contrasenahashed { get; set; } = null!;
        public string Ishabilitado { get; set; } = null!;
        public decimal Idperfil { get; set; }
        public string? Rutcliente { get; set; }
        public string? Rutprofesional { get; set; }

        public virtual PerfilUsuario IdperfilNavigation { get; set; } = null!;
        public virtual Cliente? RutclienteNavigation { get; set; }
        public virtual Profesional? RutprofesionalNavigation { get; set; }
    }
}
