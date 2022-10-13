using AutoMapper;
using Database;

namespace Business.Util
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            MapperWrapper.Initialize(cfg =>
            {
                cfg.CreateMap<Database.Models.Usuario, DTO.Usuario>();
                cfg.CreateMap<Database.Models.CheckList, DTO.CheckList>();
                cfg.CreateMap<Database.Models.PerfilUsuario, DTO.PerfilUsuario>();

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
