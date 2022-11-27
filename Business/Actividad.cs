using Business.Util;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public partial class Actividad
    {
        #region Create
        
        public static bool? Create(DTO.Actividad nuevaActividad)
        {
            try
            {
                AutoMapperConfig.Configure();

                using (ModelContext context = new ModelContext())
                {
                    Database.Models.Actividad? actividadContext = context.Actividad
                       .FirstOrDefault(a => a.Idactividad.Equals(nuevaActividad.Idactividad));

                    if (actividadContext != null)
                    {
                        return false;
                    }

                    Database.Models.Actividad actividadDB = 
                        MapperWrapper.Mapper.Map<Database.Models.Actividad>(nuevaActividad);

                    context.Actividad.Add(actividadDB);
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
        
        public static bool? Update(DTO.Actividad ActivityUpdate)
        {
            try
            {
                using (ModelContext context = new ModelContext())
                {
                    Database.Models.Actividad? actividadContext = context.Actividad
                       .FirstOrDefault(a => a.Idactividad.Equals(ActivityUpdate.Idactividad));

                    if (actividadContext == null)
                    {
                        return false;
                    }

                    actividadContext.Descripcion = ActivityUpdate.Descripcion;
                    actividadContext.Fechainicio = ActivityUpdate.Fechainicio;
                    actividadContext.Fechatermino = ActivityUpdate.Fechatermino;
                    actividadContext.Horainicio = ActivityUpdate.Horainicio;
                    actividadContext.Horatermino = ActivityUpdate.Horatermino;
                    actividadContext.Cantidadasistente = ActivityUpdate.Cantidadasistente;
                    actividadContext.Fecharegistro = ActivityUpdate.Fecharegistro;
                    actividadContext.Direccion = ActivityUpdate.Direccion;
                    actividadContext.Rutprofesional = ActivityUpdate.Rutprofesional;

                    context.Actividad.Update(actividadContext);
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

        #region ReadAll
        public static List<DTO.Actividad>? ReadAll()
        {
            try
            {
                AutoMapperConfig.Configure();
                using (ModelContext context = new ModelContext())
                {
                    List<Database.Models.Actividad> actividadContext = context.Actividad.ToList();

                    if (actividadContext.Any())
                    {
                        List<DTO.Actividad> actividadResponse =
                        MapperWrapper.Mapper.Map<List<Database.Models.Actividad>, List<DTO.Actividad>>(actividadContext);

                        return actividadResponse;
                    }
                    return new List<DTO.Actividad>();
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

        public static DTO.Actividad? Read(decimal idActividad)
        {
            try
            {
                AutoMapperConfig.Configure();
                using (ModelContext context = new ModelContext())
                {
                    Database.Models.Actividad? actividadContext =
                        context.Actividad.FirstOrDefault(p => p.Idactividad == idActividad);

                    if (actividadContext == null)
                    {
                        return new DTO.Actividad();
                    }

                    DTO.Actividad actividadResponse =
                        MapperWrapper.Mapper.Map<DTO.Actividad>(actividadContext);

                    return actividadResponse;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;

            }
        }

        public static DTO.Actividad? Read(string Descripcion)
        {
            try
            {
                AutoMapperConfig.Configure();
                using (ModelContext context = new ModelContext())
                {
                    Database.Models.Actividad? actividadContext =
                        context.Actividad.FirstOrDefault(p => p.Descripcion.Equals(Descripcion));

                    if (actividadContext == null)
                    {
                        return new DTO.Actividad();
                    }

                    DTO.Actividad actividadResponse =
                        MapperWrapper.Mapper.Map<DTO.Actividad>(actividadContext);

                    return actividadResponse;
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
