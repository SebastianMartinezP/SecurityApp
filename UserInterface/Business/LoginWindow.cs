using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace UserInterface.Business
{
    
    public static class LoginWindow
    {
        /// <summary>
        /// Obtiene un usuario según credenciales de la base de datos.
		///  - usuario vacío: usuario no encontrado.
		///  - nulo: excepción dentro del método.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="pass"></param>
        /// <returns>Database.Models.Usuario, null</returns>
        public static Usuario? getUsuario(string username, string pass)
        {
			try
			{
				using (ModelContext context = new ModelContext())
				{
					Usuario? usuario = context.Usuario.FirstOrDefault(user => 
                    user.Correo.Equals(username) && user.Contrasenahashed.Equals(pass));

					if (usuario == null)
					{
						return new Usuario();
					}

					return usuario;
				}
			}
			catch (Exception)
			{
				return null;
			}
        }

        public static async Task<Usuario?> getUsuarioAsync(string username, string pass)
        {
            try
            {
                using (ModelContext context = new ModelContext())
                {
                    Usuario? usuario =
                        await (
                            context.Usuario
                            .Where(user =>
                                user.Correo.Equals(username)
                                && user.Contrasenahashed.Equals(pass))
                            ).FirstOrDefaultAsync<Usuario>();

                    if (usuario == null)
                    {
                        return new Usuario();
                    }

                    return usuario;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }



    }
}
