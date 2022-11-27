using Business.Util;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public partial class Contrato
    {
        #region Create

        public static bool? Create(DTO.Contrato newContrato)
        {
            try
            {
                AutoMapperConfig.Configure();

                using (ModelContext context = new ModelContext())
                {
                    Database.Models.Contrato? contratoContext = context.Contrato
                       .FirstOrDefault(a => a.Idcontrato == newContrato.Idcontrato);

                    if (contratoContext != null)
                    {
                        return false;
                    }

                    Database.Models.Contrato contratoDB =
                        MapperWrapper.Mapper.Map<Database.Models.Contrato>(newContrato);

                    contratoDB.Fechacontrato = DateTime.Today;

                    context.Contrato.Add(contratoDB);
                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        #endregion

        #region Update

        public static bool? Update(DTO.Contrato contratoUpdate)
        {
            try
            {
                AutoMapperConfig.Configure();

                using (ModelContext context = new ModelContext())
                {
                    Database.Models.Contrato? contratoContext = context.Contrato
                       .FirstOrDefault(a => a.Idcontrato == contratoUpdate.Idcontrato);

                    if (contratoContext == null)
                    {
                        return false;
                    }

                    contratoContext.Vigente = contratoUpdate.Vigente;
                    contratoContext.Valor = contratoUpdate.Valor;
                    contratoContext.Descripcion = contratoUpdate.Descripcion;

                    context.Contrato.Update(contratoContext);
                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        #endregion

        #region Read

        public static DTO.Contrato? Read(decimal idContrato)
        {
            try
            {
                AutoMapperConfig.Configure();
                using (ModelContext context = new ModelContext())
                {
                    Database.Models.Contrato? contratoContext = 
                        context.Contrato.FirstOrDefault(p => p.Idcontrato == idContrato);

                    if (contratoContext == null)
                    {
                        return new DTO.Contrato();
                    }

                    DTO.Contrato contratoReponse = 
                        MapperWrapper.Mapper.Map<DTO.Contrato>(contratoContext);

                    return contratoReponse;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;

            }
        }

        #endregion

        #region ReadAll

        public static List<DTO.Contrato>? ReadAll()
        {
            try
            {
                AutoMapperConfig.Configure();
                using (ModelContext context = new ModelContext())
                {
                    List<Database.Models.Contrato> contratoContext = context.Contrato.ToList();

                    if (contratoContext.Any())
                    {
                        List<DTO.Contrato> contratoResponse =
                            MapperWrapper.Mapper.Map<List<Database.Models.Contrato>, List<DTO.Contrato>>(contratoContext);

                        return contratoResponse;
                    }
                    return new List<DTO.Contrato>();
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
