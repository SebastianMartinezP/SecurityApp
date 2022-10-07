using System;
using System.Collections.Generic;
using System.Linq;
using Database.Models;

namespace UserInterface.Business
{
    public static class PerfilUsuario
    {

        #region Create
        public static bool? Create(Database.Models.PerfilUsuario p)
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

                    context.PerfilUsuario.Add(p);
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

        public static Database.Models.PerfilUsuario? GetPerfilUsuario(string descripcion)
        {
            try
            {
                using (ModelContext context = new ModelContext())
                {
                    Database.Models.PerfilUsuario? perfilUsuario =
                        context.PerfilUsuario.FirstOrDefault(x => x.Descripcion.Equals(descripcion));

                    if (perfilUsuario == null)
                    {
                        return new Database.Models.PerfilUsuario();
                    }

                    return perfilUsuario;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public static List<Database.Models.PerfilUsuario> GetAllPerfilUsuario()
        {
            try
            {
                using (ModelContext context = new ModelContext())
                {
                    List<Database.Models.PerfilUsuario> perfilUsuarios = context.PerfilUsuario.ToList();

                    if (perfilUsuarios.Any())
                    {
                        return perfilUsuarios;
                    }
                    return new List<Database.Models.PerfilUsuario>();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return new List<Database.Models.PerfilUsuario>();
            }
        }

        #endregion

    }
}
