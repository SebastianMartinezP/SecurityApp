using Business.Util;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public partial class CheckList
    {
        #region Create
        
        public static bool? Create(DTO.CheckList c)
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

                    Database.Models.CheckList checklistSave =
                        MapperWrapper.Mapper.Map<Database.Models.CheckList>(c);

                    checklistSave.Fecharegistro = DateTime.Today;


                    context.CheckList.Add(checklistSave);
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

        public static bool? Update(DTO.CheckList c)
        {
            try
            {
                using (ModelContext context = new ModelContext())
                {
                    Database.Models.CheckList? checkList =
                        context.CheckList.FirstOrDefault(x => 
                        x.Idcheck == c.Idcheck);

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
                    // fechaRegistro no se actualiza

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

        public static bool? RegisterUpgrade(DTO.CheckList c)
        {
            try
            {
                using (ModelContext context = new ModelContext())
                {
                    Database.Models.CheckList? checkList =
                        context.CheckList.FirstOrDefault(x =>
                        x.Idcheck == c.Idcheck);

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

        public static DTO.CheckList? GetCheckList(int id)
        {
            try
            {
                AutoMapperConfig.Configure();
                using (ModelContext context = new ModelContext())
                {
                    Database.Models.CheckList? checkList = context.CheckList.FirstOrDefault(c =>
                        c.Idcheck == id);

                    if (checkList == null)
                    {
                        return new DTO.CheckList();
                    }

                    DTO.CheckList checklistResponse = MapperWrapper.Mapper.Map<DTO.CheckList>(checkList);

                    return checklistResponse;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public static List<DTO.CheckList> GetAllCheckList()
        {
            try
            {
                AutoMapperConfig.Configure();
                using (ModelContext context = new ModelContext())
                {
                    List<Database.Models.CheckList> checkLists = context.CheckList.ToList();

                    if (checkLists.Any())
                    {
                        List<DTO.CheckList> checklistsResponse =
                            // Mapper.Map<ClaseOrigen, ClaseDestino>(objetoAMapear);
                            MapperWrapper.Mapper.Map<List<Database.Models.CheckList>, List<DTO.CheckList>>(checkLists);

                        return checklistsResponse;
                    }
                    return new List<DTO.CheckList>();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return new List<DTO.CheckList>();
            }
        }

        #endregion


    }
}
