using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Util;
using System.Threading.Tasks;
using Database.Models;

namespace Business
{
    public partial class Profesional
    {
    #region Create
        public static bool? Create(DTO.Profesional NuevoProfesional)
        {
            try
            {
                AutoMapperConfig.Configure();

                using(ModelContext context = new ModelContext())
                {
                    Database.Models.Profesional? Profesional = context.Profesional
                       .FirstOrDefault(p => p.Rutprofesional.Equals(NuevoProfesional.Rutprofesional)); 


                    if (Profesional != null)
                    {
                        return false;
                    }

                    Database.Models.Profesional profesionalDB = MapperWrapper.Mapper.Map<Database.Models.Profesional>(NuevoProfesional);

                    context.Profesional.Add(profesionalDB);
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

        public static DTO.Profesional? ReadProfesional(string RutProfesional)
        {
            try
            {
                AutoMapperConfig.Configure();
                using (ModelContext context = new ModelContext())
                {
                    Database.Models.Profesional? Profesional = context.Profesional.FirstOrDefault
                        (p => p.Rutprofesional.Equals(RutProfesional));

                    if (Profesional == null )
                    {
                        return new DTO.Profesional();
                    }

                    DTO.Profesional profesionalResponse = MapperWrapper.Mapper.Map<DTO.Profesional>(Profesional);

                    return profesionalResponse;
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
         public static List<DTO.Profesional>?  ReadAllProfesional()
        {
            try
            {
                AutoMapperConfig.Configure();
                using (ModelContext context = new ModelContext())
                {
                    List <Database.Models.Profesional> profesionalContext = context.Profesional.ToList();

                    if (profesionalContext.Any())
                    {

                        List<DTO.Profesional> profesionalResponse = 
                        MapperWrapper.Mapper.Map< List<Database.Models.Profesional>, List<DTO.Profesional>>(profesionalContext);

                        return profesionalResponse;

                       
                    }

                    return new List<DTO.Profesional>();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
               
            }
        }

        #endregion

    #region Update
        public static bool? Update(DTO.Profesional profesionalUpdate)
        {
            try
            {
               

                using (ModelContext context = new ModelContext())
                {
                    Database.Models.Profesional? Profesional = context.Profesional
                       .FirstOrDefault(p => p.Rutprofesional.Equals(profesionalUpdate.Rutprofesional));


                    if (Profesional == null) // SI ES NULO NO PUEDE ACTUALIZAR
                    {
                        return false;
                    }

                   Profesional.Primernombre = profesionalUpdate.Primernombre;
                   Profesional.Segundonombre = profesionalUpdate.Segundonombre;
                   Profesional.Primerapellido = profesionalUpdate.Primerapellido;
                   Profesional.Segundoapellido = profesionalUpdate.Segundoapellido;
                   Profesional.Numerocontacto = profesionalUpdate.Numerocontacto;
                   Profesional.Isvigente = profesionalUpdate.Isvigente;

                    context.Profesional.Update(Profesional);
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

    #region Desabilitar

        public static bool? Disable(DTO.Profesional profesionalUpdate)
        {
            try
            {


                using (ModelContext context = new ModelContext())
                {
                    Database.Models.Profesional? Profesional = context.Profesional
                       .FirstOrDefault(p => p.Rutprofesional.Equals(profesionalUpdate.Rutprofesional));


                    if (Profesional == null) // SI ES NULO NO PUEDE ACTUALIZAR
                    {
                        return false;
                    }

                    Profesional.Isvigente = "0";

                    context.Profesional.Update(Profesional);
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



    }
}
