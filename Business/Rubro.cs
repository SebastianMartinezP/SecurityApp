using Business.Util;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public partial class Rubro
    {
        #region ReadAll

        public static List<DTO.Rubro>? ReadAll()
        {
            try
            {
                AutoMapperConfig.Configure();
                using (ModelContext context = new ModelContext())
                {
                    List<Database.Models.Rubro> rubroContext = context.Rubro.ToList();

                    if (rubroContext.Any())
                    {
                        List<DTO.Rubro> rubroResponse =
                            MapperWrapper.Mapper.Map<List<Database.Models.Rubro>, List<DTO.Rubro>>(rubroContext);

                        return rubroResponse;
                    }
                    return new List<DTO.Rubro>();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;

            }
        }

        #endregion

        public static DTO.Rubro? Read(decimal id)
        {
            try
            {
                AutoMapperConfig.Configure();
                using (ModelContext context = new ModelContext())
                {
                    Database.Models.Rubro? rubroContext =
                        context.Rubro.FirstOrDefault(x => x.Idrubro == id);

                    if (rubroContext == null)
                    {
                        return new DTO.Rubro();
                    }

                    DTO.Rubro rubroResponse =
                        MapperWrapper.Mapper.Map<DTO.Rubro>(rubroContext);

                    return rubroResponse;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public static DTO.Rubro? Read(string descripcion)
        {
            try
            {
                AutoMapperConfig.Configure();
                using (ModelContext context = new ModelContext())
                {
                    Database.Models.Rubro? rubroContext =
                        context.Rubro.FirstOrDefault(x => x.Descripcion.Equals(descripcion));

                    if (rubroContext == null)
                    {
                        return new DTO.Rubro();
                    }

                    DTO.Rubro rubroResponse =
                        MapperWrapper.Mapper.Map<DTO.Rubro>(rubroContext);

                    return rubroResponse;
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
