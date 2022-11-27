using AutoMapper;
using Database;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace Business.Util
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            MapperWrapper.Initialize(cfg =>
            {
                cfg.CreateMap<Database.Models.Usuario, DTO.Usuario>().ReverseMap();
                cfg.CreateMap<Database.Models.CheckList, DTO.CheckList>().ReverseMap();
                cfg.CreateMap<Database.Models.PerfilUsuario, DTO.PerfilUsuario>().ReverseMap();
                cfg.CreateMap<Database.Models.Profesional, DTO.Profesional>().ReverseMap();
                cfg.CreateMap<Database.Models.Cliente, DTO.Cliente>().ReverseMap();
                cfg.CreateMap<Database.Models.Actividad, DTO.Actividad>().ReverseMap();
                cfg.CreateMap<Database.Models.Pago, DTO.Pago>().ReverseMap();
                cfg.CreateMap<Database.Models.Contrato, DTO.Contrato>().ReverseMap();
                cfg.CreateMap<Database.Models.Rubro, DTO.Rubro>().ReverseMap();
                cfg.CreateMap<Database.Models.TipoActividad, DTO.TipoActividad>().ReverseMap();
            });

            MapperWrapper.AssertConfigurationIsValid();
        }
    }

    /*
     Como usarlo:
        Business.Util.AutoMapperConfig.Configure();
        Business.Util.MapperWrapper.Mapper.Map<Foo2>(Foo1);
     */
}
