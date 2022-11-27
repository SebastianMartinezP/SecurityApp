using Business.Util;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public partial class TipoActividad
    {
        #region ReadAll

        public static List<DTO.TipoActividad>? ReadAll()
        {
            try
            {
                AutoMapperConfig.Configure();
                using (ModelContext context = new ModelContext())
                {
                    List<Database.Models.TipoActividad> tipoActividadContext = 
                        context.TipoActividad.ToList();

                    if (tipoActividadContext.Any())
                    {
                        List<DTO.TipoActividad> tipoActividadResponse =
                            MapperWrapper.Mapper
                            .Map<
                                List<Database.Models.TipoActividad>, 
                                List<DTO.TipoActividad>
                                >(tipoActividadContext);

                        return tipoActividadResponse;
                    }
                    return new List<DTO.TipoActividad>();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;

            }
        }

        #endregion

        public static DTO.TipoActividad? Read(decimal id)
        {
            try
            {
                AutoMapperConfig.Configure();
                using (ModelContext context = new ModelContext())
                {
                    Database.Models.TipoActividad? tipoActividadContext =
                        context.TipoActividad.FirstOrDefault(x => x.Idtipoactividad == id);

                    if (tipoActividadContext == null)
                    {
                        return new DTO.TipoActividad();
                    }

                    DTO.TipoActividad tipoActividadResponse =
                        MapperWrapper.Mapper.Map<DTO.TipoActividad>(tipoActividadContext);

                    return tipoActividadResponse;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public static DTO.TipoActividad? Read(string descripcion)
        {
            try
            {
                AutoMapperConfig.Configure();
                using (ModelContext context = new ModelContext())
                {
                    Database.Models.TipoActividad? tipoActividadContext =
                        context.TipoActividad.FirstOrDefault(x => x.Descripcion.Equals(descripcion));

                    if (tipoActividadContext == null)
                    {
                        return new DTO.TipoActividad();
                    }

                    DTO.TipoActividad tipoActividadResponse =
                        MapperWrapper.Mapper.Map<DTO.TipoActividad>(tipoActividadContext);

                    return tipoActividadResponse;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
    }
}
