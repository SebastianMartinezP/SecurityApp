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
