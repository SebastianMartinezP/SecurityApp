using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserInterface.Business
{
    public static class CheckList
    {
        #region Create
        
        public static bool? Create(Database.Models.CheckList c)
        {
            try
            {
                using (ModelContext context = new ModelContext())
                {
                    Database.Models.CheckList? checkList =
                        context.CheckList.FirstOrDefault(x => x.Descripcion.Equals(c.Descripcion));

                    if (checkList != null) // encontró un registro existente, no guardar.
                    {
                        return false;
                    }

                    context.CheckList.Add(c);
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

        public static bool? Update(Database.Models.CheckList c, int idChecklist)
        {
            try
            {
                using (ModelContext context = new ModelContext())
                {
                    Database.Models.CheckList? checkList =
                        context.CheckList.FirstOrDefault(x => 
                        x.Idcheck == idChecklist);

                    if (checkList == null) // no encontró un registro existente, no actualizar.
                    {
                        return false;
                    }

                    checkList.Isseniales = c.Isseniales;
                    checkList.Iselementoseguridad = c.Iselementoseguridad;
                    checkList.Ismaterial = c.Ismaterial;
                    checkList.Isredagua = c.Isredagua;
                    checkList.Isluminaria = c.Isluminaria;
                    checkList.Isseguro = c.Isseguro;
                    checkList.Istrabajoseguro = c.Istrabajoseguro;
                    checkList.Descripcion = c.Descripcion;

                    context.CheckList.Update(checkList);
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

        public static bool? RegisterUpgrade(Database.Models.CheckList c, int IdCheckList)
        {
            try
            {
                using (ModelContext context = new ModelContext())
                {
                    Database.Models.CheckList? checkList =
                        context.CheckList.FirstOrDefault(x =>
                        x.Idcheck == IdCheckList);

                    if (checkList == null) // no encontró un registro existente, no actualizar.
                    {
                        return false;
                    }

                    checkList.Descripcion = c.Descripcion;

                    context.CheckList.Update(checkList);
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

        public static Database.Models.CheckList? GetCheckList(int id)
        {
            try
            {
                using (ModelContext context = new ModelContext())
                {
                    Database.Models.CheckList? checkList = context.CheckList.FirstOrDefault(c =>
                        c.Idcheck == id);

                    if (checkList == null)
                    {
                        return new Database.Models.CheckList();
                    }

                    return checkList;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public static List<Database.Models.CheckList> GetAllCheckList()
        {
            try
            {
                using (ModelContext context = new ModelContext())
                {
                    List<Database.Models.CheckList> checkLists = context.CheckList.ToList();

                    if (checkLists.Any())
                    {
                        return checkLists;
                    }
                    return new List<Database.Models.CheckList>();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return new List<Database.Models.CheckList>();
            }
        }

        #endregion


    }
}
