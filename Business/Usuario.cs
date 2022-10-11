using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using Database.Models;

namespace Business.DTO
{
    
    public partial class Usuario
    {

        #region Read 
        public static Database.Models.Usuario? GetUsuario(string username, string pass)
        {
			try
			{
				using (ModelContext context = new ModelContext())
				{
                    Database.Models.Usuario? usuario = context.Usuario.FirstOrDefault(u => 
                        u.Correo.Equals(username) && u.Contrasenahashed.Equals(pass));

					if (usuario == null)
					{
						return new Database.Models.Usuario();
					}

					return usuario;
				}
			}
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public static List<Database.Models.Usuario> GetAllUsuario()
        {
            try
            {
                using (ModelContext context = new ModelContext())
                {
                    List<Database.Models.Usuario> usuarios = context.Usuario.ToList();

                    if (usuarios.Any())
                    {
                        return usuarios;
                    }
                    return new List<Database.Models.Usuario>();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return new List<Database.Models.Usuario>();
            }
        }


        #endregion

        #region Create
        public static bool? Create(Database.Models.Usuario usuarioSave)
		{
			try
			{
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

					context.Usuario.Add(usuarioSave);
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

        public static bool? Update(Database.Models.Usuario usuarioUpdate)
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

        public static bool? Disable(Database.Models.Usuario usuarioDisable)
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
