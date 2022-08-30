using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Database.Models
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options) : base(options)
        {
        }

        public virtual DbSet<Database.Models.Actividad> Actividad { get; set; } = null!;
        public virtual DbSet<Database.Models.CanalPago> CanalPago { get; set; } = null!;
        public virtual DbSet<Database.Models.CheckList> CheckList { get; set; } = null!;
        public virtual DbSet<Database.Models.Cliente> Cliente { get; set; } = null!;
        public virtual DbSet<Database.Models.ComprobantePago> ComprobantePago { get; set; } = null!;
        public virtual DbSet<Database.Models.Contrato> Contrato { get; set; } = null!;
        public virtual DbSet<Database.Models.HistorialActividad> HistorialActividad { get; set; } = null!;
        public virtual DbSet<Database.Models.Pago> Pago { get; set; } = null!;
        public virtual DbSet<Database.Models.PerfilUsuario> PerfilUsuario { get; set; } = null!;
        public virtual DbSet<Database.Models.Profesional> Profesional { get; set; } = null!;
        public virtual DbSet<Database.Models.Rubro> Rubro { get; set; } = null!;
        public virtual DbSet<Database.Models.TipoActividad> TipoActividad { get; set; } = null!;
        public virtual DbSet<Database.Models.Usuario> Usuario { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseOracle("User Id=C##Security;Password=sec123;Data Source=localhost:1521/xe;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##SECURITY").UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<Database.Models.Actividad>(entity =>
            {
                entity.HasKey(e => e.Idactividad)
                    .HasName("SYS_C007613");

                entity.ToTable("ACTIVIDAD");

                entity.Property(e => e.Idactividad)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDACTIVIDAD");

                entity.Property(e => e.Cantidadasistente)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CANTIDADASISTENTE");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("DIRECCION");

                entity.Property(e => e.Fechainicio)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHAINICIO");

                entity.Property(e => e.Fecharegistro)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHAREGISTRO");

                entity.Property(e => e.Fechatermino)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHATERMINO");

                entity.Property(e => e.Horainicio)
                    .HasColumnType("DATE")
                    .HasColumnName("HORAINICIO");

                entity.Property(e => e.Horatermino)
                    .HasColumnType("DATE")
                    .HasColumnName("HORATERMINO");

                entity.Property(e => e.Idcheck)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("IDCHECK");

                entity.Property(e => e.Idtipoactividad)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("IDTIPOACTIVIDAD");

                entity.Property(e => e.Rutcliente)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("RUTCLIENTE");

                entity.Property(e => e.Rutprofesional)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("RUTPROFESIONAL");

                entity.HasOne(d => d.IdcheckNavigation)
                    .WithMany(p => p.Actividads)
                    .HasForeignKey(d => d.Idcheck)
                    .HasConstraintName("ACTIVIDAD_CHECK_LIST_FK");

                entity.HasOne(d => d.IdtipoactividadNavigation)
                    .WithMany(p => p.Actividads)
                    .HasForeignKey(d => d.Idtipoactividad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ACTIVIDAD_TIPO_ACTIVIDAD_FK");

                entity.HasOne(d => d.RutclienteNavigation)
                    .WithMany(p => p.Actividads)
                    .HasForeignKey(d => d.Rutcliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ACTIVIDAD_CLIENTE_FK");

                entity.HasOne(d => d.RutprofesionalNavigation)
                    .WithMany(p => p.Actividads)
                    .HasForeignKey(d => d.Rutprofesional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ACTIVIDAD_PROFESIONAL_FK");
            });

            modelBuilder.Entity<Database.Models.CanalPago>(entity =>
            {
                entity.HasKey(e => e.Idcanalpago)
                    .HasName("SYS_C007616");

                entity.ToTable("CANAL_PAGO");

                entity.Property(e => e.Idcanalpago)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDCANALPAGO");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");
            });

            modelBuilder.Entity<Database.Models.CheckList>(entity =>
            {
                entity.HasKey(e => e.Idcheck)
                    .HasName("SYS_C007620");

                entity.ToTable("CHECK_LIST");

                entity.Property(e => e.Idcheck)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDCHECK");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.Fecharegistro)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHAREGISTRO");

                entity.Property(e => e.Iselementoseguridad)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISELEMENTOSEGURIDAD")
                    .IsFixedLength();

                entity.Property(e => e.Isluminaria)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISLUMINARIA")
                    .IsFixedLength();

                entity.Property(e => e.Ismaterial)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISMATERIAL")
                    .IsFixedLength();

                entity.Property(e => e.Isredagua)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISREDAGUA")
                    .IsFixedLength();

                entity.Property(e => e.Isseguro)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISSEGURO")
                    .IsFixedLength();

                entity.Property(e => e.Isseniales)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISSENIALES")
                    .IsFixedLength();

                entity.Property(e => e.Istrabajoseguro)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISTRABAJOSEGURO")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Database.Models.Cliente>(entity =>
            {
                entity.HasKey(e => e.Rutcliente)
                    .HasName("SYS_C007624");

                entity.ToTable("CLIENTE");

                entity.Property(e => e.Rutcliente)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("RUTCLIENTE");

                entity.Property(e => e.Idrubro)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("IDRUBRO");

                entity.Property(e => e.Ismoroso)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISMOROSO")
                    .IsFixedLength();

                entity.Property(e => e.Numerocontacto)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NUMEROCONTACTO");

                entity.Property(e => e.Razonsocial)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("RAZONSOCIAL");

                entity.HasOne(d => d.IdrubroNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.Idrubro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CLIENTE_RUBRO_FK");
            });

            modelBuilder.Entity<Database.Models.ComprobantePago>(entity =>
            {
                entity.HasKey(e => e.Idcomprobante)
                    .HasName("SYS_C007679");

                entity.ToTable("COMPROBANTE_PAGO");

                entity.Property(e => e.Idcomprobante)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDCOMPROBANTE");

                entity.Property(e => e.Fecharegistro)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHAREGISTRO");

                entity.Property(e => e.Fechavalida)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("FECHAVALIDA");

                entity.Property(e => e.Monto)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MONTO");

                entity.Property(e => e.Numerotarjeta)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("NUMEROTARJETA");

                entity.Property(e => e.Pintarjeta)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("PINTARJETA");

                entity.Property(e => e.Tipomoneda)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TIPOMONEDA");

                entity.Property(e => e.Valoruf)
                    .HasColumnType("NUMBER(10,2)")
                    .HasColumnName("VALORUF");

                entity.Property(e => e.Valorusd)
                    .HasColumnType("NUMBER(10,2)")
                    .HasColumnName("VALORUSD");

                entity.Property(e => e.Valorutm)
                    .HasColumnType("NUMBER(10,2)")
                    .HasColumnName("VALORUTM");
            });

            modelBuilder.Entity<Database.Models.Contrato>(entity =>
            {
                entity.HasKey(e => e.Idcontrato)
                    .HasName("SYS_C007632");

                entity.ToTable("CONTRATO");

                entity.Property(e => e.Idcontrato)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDCONTRATO");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.Fechacontrato)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHACONTRATO");

                entity.Property(e => e.Idactividad)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("IDACTIVIDAD");

                entity.Property(e => e.Idpago)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("IDPAGO");

                entity.Property(e => e.Rutcliente)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("RUTCLIENTE");

                entity.Property(e => e.Valor)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("VALOR");

                entity.HasOne(d => d.IdactividadNavigation)
                    .WithMany(p => p.Contratos)
                    .HasForeignKey(d => d.Idactividad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRATO_ACTIVIDAD_FK");

                entity.HasOne(d => d.RutclienteNavigation)
                    .WithMany(p => p.Contratos)
                    .HasForeignKey(d => d.Rutcliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTRATO_CLIENTE_FK");
            });

            modelBuilder.Entity<Database.Models.HistorialActividad>(entity =>
            {
                entity.HasKey(e => e.Idhistorial)
                    .HasName("SYS_C007635");

                entity.ToTable("HISTORIAL_ACTIVIDAD");

                entity.Property(e => e.Idhistorial)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDHISTORIAL");

                entity.Property(e => e.Cantaccidentesasistidos)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CANTACCIDENTESASISTIDOS");

                entity.Property(e => e.Cantcapacitaciones)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CANTCAPACITACIONES");

                entity.Property(e => e.Fecharegistro)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHAREGISTRO");

                entity.Property(e => e.Rutprofesional)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("RUTPROFESIONAL");

                entity.HasOne(d => d.RutprofesionalNavigation)
                    .WithMany(p => p.HistorialActividads)
                    .HasForeignKey(d => d.Rutprofesional)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("HIS_ACTIVIDAD_PRO_FK");
            });

            modelBuilder.Entity<Database.Models.Pago>(entity =>
            {
                entity.HasKey(e => e.Idpago)
                    .HasName("SYS_C007685");

                entity.ToTable("PAGO");

                entity.Property(e => e.Idpago)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDPAGO");

                entity.Property(e => e.Fecharegistro)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHAREGISTRO");

                entity.Property(e => e.Idcanalpago)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("IDCANALPAGO");

                entity.Property(e => e.Idcomprobante)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("IDCOMPROBANTE");

                entity.Property(e => e.Montopago)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MONTOPAGO");

                entity.HasOne(d => d.IdcomprobanteNavigation)
                    .WithMany(p => p.Pagos)
                    .HasForeignKey(d => d.Idcomprobante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PAGO_COMPROBANTE_PAGO_FK");
            });

            modelBuilder.Entity<Database.Models.PerfilUsuario>(entity =>
            {
                entity.HasKey(e => e.Idperfil)
                    .HasName("SYS_C007638");

                entity.ToTable("PERFIL_USUARIO");

                entity.Property(e => e.Idperfil)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDPERFIL");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");
            });

            modelBuilder.Entity<Database.Models.Profesional>(entity =>
            {
                entity.HasKey(e => e.Rutprofesional)
                    .HasName("SYS_C007644");

                entity.ToTable("PROFESIONAL");

                entity.Property(e => e.Rutprofesional)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("RUTPROFESIONAL");

                entity.Property(e => e.Isvigente)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISVIGENTE")
                    .IsFixedLength();

                entity.Property(e => e.Numerocontacto)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NUMEROCONTACTO");

                entity.Property(e => e.Primerapellido)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("PRIMERAPELLIDO");

                entity.Property(e => e.Primernombre)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("PRIMERNOMBRE");

                entity.Property(e => e.Segundoapellido)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("SEGUNDOAPELLIDO");

                entity.Property(e => e.Segundonombre)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("SEGUNDONOMBRE");
            });

            modelBuilder.Entity<Database.Models.Rubro>(entity =>
            {
                entity.HasKey(e => e.Idrubro)
                    .HasName("SYS_C007647");

                entity.ToTable("RUBRO");

                entity.Property(e => e.Idrubro)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDRUBRO");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");
            });

            modelBuilder.Entity<Database.Models.TipoActividad>(entity =>
            {
                entity.HasKey(e => e.Idtipoactividad)
                    .HasName("SYS_C007651");

                entity.ToTable("TIPO_ACTIVIDAD");

                entity.Property(e => e.Idtipoactividad)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDTIPOACTIVIDAD");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPCION");

                entity.Property(e => e.Montoactividad)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("MONTOACTIVIDAD");
            });

            modelBuilder.Entity<Database.Models.Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario)
                    .HasName("SYS_C007657");

                entity.ToTable("USUARIO");

                entity.Property(e => e.Idusuario)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IDUSUARIO");

                entity.Property(e => e.Contrasenahashed)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("CONTRASENAHASHED");

                entity.Property(e => e.Correo)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("CORREO");

                entity.Property(e => e.Idperfil)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("IDPERFIL");

                entity.Property(e => e.Ishabilitado)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISHABILITADO")
                    .IsFixedLength();

                entity.Property(e => e.Rutcliente)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("RUTCLIENTE");

                entity.Property(e => e.Rutprofesional)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("RUTPROFESIONAL");

                entity.HasOne(d => d.IdperfilNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Idperfil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("USUARIO_PERFIL_USUARIO_FK");

                entity.HasOne(d => d.RutclienteNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Rutcliente)
                    .HasConstraintName("USUARIO_CLIENTE_FK");

                entity.HasOne(d => d.RutprofesionalNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Rutprofesional)
                    .HasConstraintName("USUARIO_PROFESIONAL_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
