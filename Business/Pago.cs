using Business.Util;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public partial class Pago
    {
        #region ReadAll

        public static List<DTO.Pago>? ReadAllPago()
        {
            try
            {
                AutoMapperConfig.Configure();
                using (ModelContext context = new ModelContext())
                {
                    List<Database.Models.Pago> pagoContext = context.Pago.ToList();

                    if (pagoContext.Any())
                    {
                        List<DTO.Pago> pagoResponse =
                            MapperWrapper.Mapper.Map<List<Database.Models.Pago>, List<DTO.Pago>>(pagoContext);

                        return pagoResponse;
                    }
                    return new List<DTO.Pago>();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;

            }
        }

        #endregion
    }
}
