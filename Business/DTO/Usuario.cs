namespace Business.DTO
{
    public partial class Usuario
    {
        public Usuario()
        {

        }
        public decimal Idusuario { get; set; }
        public string Correo { get; set; } = null!;
        public string Contrasenahashed { get; set; } = null!;
        public string Ishabilitado { get; set; } = null!;
        public decimal Idperfil { get; set; }
        public string? Rutcliente { get; set; }
        public string? Rutprofesional { get; set; }
    }
}
