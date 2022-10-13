using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using Database.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Business.Util;
namespace Business.DTO
{
    
    public partial class Usuario
    {

        #region Read 
        public static DTO.Usuario? GetUsuario(string username, string pass)
        {
			try
			{
                AutoMapperConfig.Configure();
				using (ModelContext context = new ModelContext())
				{
                    Database.Models.Usuario? usuario = context.Usuario.FirstOrDefault(u => 
                        u.Correo.Equals(username) && u.Contrasenahashed.Equals(pass));

					if (usuario == null)
					{
						return new DTO.Usuario();
					}

                    DTO.Usuario usuarioResponse = MapperWrapper.Mapper.Map<DTO.Usuario>(usuario);


                    return usuarioResponse;
				}
			}
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public static List<DTO.Usuario> GetAllUsuario()
        {
            try
            {
                AutoMapperConfig.Configure();
                using (ModelContext context = new ModelContext())
                {
                    List<Database.Models.Usuario> usuariosContext = context.Usuario.ToList();
                    
                    if (usuariosContext.Any())
                    {
                        List<DTO.Usuario> usuariosResponse = 
                            // Mapper.Map<ClaseOrigen, ClaseDestino>(objetoAMapear);
                            MapperWrapper.Mapper.Map< List<Database.Models.Usuario>, List<DTO.Usuario> >(usuariosContext);
                        
                        return usuariosResponse;
                    }
                    return new List<DTO.Usuario>();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return new List<DTO.Usuario>();
            }
        }


        #endregion

        #region Create
        public static bool? Create(DTO.Usuario usuarioSave)
		{
			try
			{
                AutoMapperConfig.Configure();
                using (ModelContext context = new ModelContext())
                {
                    Database.Models.Usuario? usuario = context.Usuario
                        .FirstOrDefault(u =>
                            u.Correo.Equals(usuarioSave.Correo) 
                            && u.Contrasenahashed.Equals(usuarioSave.Contrasenahashed)
                        );


                    if (usuario != null) // encontró un registro existente, no guardar.
                    {
                        return false;
                    }

                    Database.Models.Usuario user = 
                        MapperWrapper.Mapper.Map<Database.Models.Usuario>(usuarioSave);

                    context.Usuario.Add(user);
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

        public static bool? Update(DTO.Usuario usuarioUpdate)
        {
            try
            {
                using (ModelContext context = new ModelContext())
                {
                    Database.Models.Usuario? usuario = context.Usuario
                        .FirstOrDefault(u =>
                            u.Correo.Equals(usuarioUpdate.Correo) 
                            && u.Contrasenahashed.Equals(usuarioUpdate.Contrasenahashed)
                        );

                    if (usuario == null) // no encontró un registro existente, no actualizar.
                    {
                        return false;
                    }

                    usuario.Correo = usuarioUpdate.Correo;
                    usuario.Contrasenahashed = usuarioUpdate.Contrasenahashed;
                    usuario.Ishabilitado = usuarioUpdate.Ishabilitado;

                    context.Usuario.Update(usuario);
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

        #region Disable (deshabilitar)

        public static bool? Disable(DTO.Usuario usuarioDisable)
        {
            try
            {
                using (ModelContext context = new ModelContext())
                {
                    Database.Models.Usuario? usuario = context.Usuario
                        .FirstOrDefault(u =>
                            u.Correo.Equals(usuarioDisable.Correo) 
                            && u.Contrasenahashed.Equals(usuarioDisable.Contrasenahashed)
                        );

                    if (usuario == null) // no encontró un registro existente, no deshabilitar.
                    {
                        return false;
                    }

                    usuario.Ishabilitado = "0";

                    context.Usuario.Update(usuario);
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
    }
}
