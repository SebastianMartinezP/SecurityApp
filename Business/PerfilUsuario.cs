using System;
using System.Collections.Generic;
using System.Linq;
using Database.Models;
using Business.Util;

namespace Business.DTO
{
    public partial class PerfilUsuario
    {

        #region Create
        public static bool? Create(DTO.PerfilUsuario p)
        {
            try
            {
                using (ModelContext context = new ModelContext())
                {
                    Database.Models.PerfilUsuario? perfilUsuario = 
                        context.PerfilUsuario.FirstOrDefault(x => x.Descripcion.Equals(p.Descripcion));

                    if (perfilUsuario != null) // encontró un registro existente, no guardar.
                    {
                        return false;
                    }

                    Database.Models.PerfilUsuario profile =
                        MapperWrapper.Mapper.Map<Database.Models.PerfilUsuario>(p);


                    context.PerfilUsuario.Add(profile);
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

        #region Update

        public static bool? Update(DTO.PerfilUsuario perfilUpdate)
        {
            try
            {
                using (ModelContext context = new ModelContext())
                {
                    Database.Models.PerfilUsuario? perfil = context.PerfilUsuario
                        .FirstOrDefault(u => u.Idperfil == perfilUpdate.Idperfil);

                    if (perfil == null) // no encontró un registro existente, no actualizar.
                    {
                        return false;
                    }

                    perfil.Idperfil = perfilUpdate.Idperfil;
                    perfil.Descripcion = perfilUpdate.Descripcion;


                    context.PerfilUsuario.Update(perfil);
                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion


        #region Read

        public static DTO.PerfilUsuario? Read(string descripcion)
        {
            try
            {
                AutoMapperConfig.Configure();
                using (ModelContext context = new ModelContext())
                {
                    Database.Models.PerfilUsuario? perfilUsuario =
                        context.PerfilUsuario.FirstOrDefault(x => x.Descripcion.Equals(descripcion));

                    if (perfilUsuario == null)
                    {
                        return new DTO.PerfilUsuario();
                    }

                    DTO.PerfilUsuario perfilUsuarioResponse = 
                        MapperWrapper.Mapper.Map<DTO.PerfilUsuario>(perfilUsuario);

                    return perfilUsuarioResponse;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }


        public static DTO.PerfilUsuario? Read(int id)
        {
            try
            {
                AutoMapperConfig.Configure();
                using (ModelContext context = new ModelContext())
                {
                    Database.Models.PerfilUsuario? perfilUsuario =
                        context.PerfilUsuario.FirstOrDefault(x => x.Idperfil == id);

                    if (perfilUsuario == null)
                    {
                        return new DTO.PerfilUsuario();
                    }

                    DTO.PerfilUsuario perfilUsuarioResponse =
                        MapperWrapper.Mapper.Map<DTO.PerfilUsuario>(perfilUsuario);

                    return perfilUsuarioResponse;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public static List<DTO.PerfilUsuario> ReadAll()
        {
            try
            {
                AutoMapperConfig.Configure();
                using (ModelContext context = new ModelContext())
                {
                    List<Database.Models.PerfilUsuario> perfilUsuariosContext = context.PerfilUsuario.ToList();

                    if (perfilUsuariosContext.Any())
                    {

                        List<DTO.PerfilUsuario> perfilUsuariosResponse =
                            // Mapper.Map<ClaseOrigen, ClaseDestino>(objetoAMapear);
                            MapperWrapper.Mapper.Map<List<Database.Models.PerfilUsuario>, List<DTO.PerfilUsuario>>(perfilUsuariosContext);

                        return perfilUsuariosResponse;
                    }
                    return new List<DTO.PerfilUsuario>();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return new List<DTO.PerfilUsuario>();
            }
        }

        #endregion

    }
}
