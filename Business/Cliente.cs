using Business.Util;
using Database.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DTO
{
    public partial class Cliente
    {
        #region Create

        public static bool? Create(DTO.Cliente nuevoCliente)
        {
            try
            {
                AutoMapperConfig.Configure();

                using (ModelContext context = new ModelContext())

                {
                    Database.Models.Cliente? Cliente = context.Cliente
                       .FirstOrDefault(c => c.Rutcliente.Equals(nuevoCliente.Rutcliente));


                    if (Cliente != null)
                    {
                        return false;
                    }

                    Database.Models.Cliente ClienteDB = 
                        MapperWrapper.Mapper.Map<Database.Models.Cliente>(nuevoCliente);

                    context.Cliente.Add(ClienteDB);
                    context.SaveChanges();

                    return true;


                }


            }
            catch (Exception e)
            {
                throw;//Console.WriteLine(e.ToString());
                //return null;

            }
        }


        #endregion

        #region Read


        public static DTO.Cliente? ReadCliente(string rutCliente)
        {
            try
            {
                AutoMapperConfig.Configure();
                using (ModelContext context = new ModelContext())
                {
                    Database.Models.Cliente? Cliente = context.Cliente.FirstOrDefault
                        (c => c.Rutcliente.Equals(rutCliente));

                    if (Cliente == null)
                    {
                        return new DTO.Cliente();
                    }

                    DTO.Cliente ClienteResponse = MapperWrapper.Mapper.Map<DTO.Cliente>(Cliente);

                    return ClienteResponse;
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
        public static List<DTO.Cliente>? ReadAllCliente()
        {
            try
            {
                AutoMapperConfig.Configure();
                using (ModelContext context = new ModelContext())
                {
                    List<Database.Models.Cliente> ClienteContext = context.Cliente.ToList();

                    if (ClienteContext.Any())
                    {

                        List<DTO.Cliente> ClienteResponse =
                        MapperWrapper.Mapper.Map<List<Database.Models.Cliente>, List<DTO.Cliente>>(ClienteContext);

                        return ClienteResponse;


                    }

                    return new List<DTO.Cliente>();
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

        public static bool? Update(DTO.Cliente clienteUpdate)
        {
            try
            {


                using (ModelContext context = new ModelContext())
                {
                    Database.Models.Cliente? Cliente = context.Cliente
                       .FirstOrDefault(c => c.Rutcliente.Equals(clienteUpdate.Rutcliente));


                    if (Cliente == null)
                    {
                        return false;
                    }


                    Cliente.Razonsocial = clienteUpdate.Razonsocial;
                    Cliente.Numerocontacto = clienteUpdate.Numerocontacto;
                    Cliente.Ismoroso = clienteUpdate.Ismoroso;

                    context.Cliente.Update(Cliente);
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

        #region DisableCliente

        public static bool? Disable(DTO.Cliente clienteUpdate)
        {
            try
            {


                using (ModelContext context = new ModelContext())
                {
                    Database.Models.Cliente? Cliente = context.Cliente
                       .FirstOrDefault(p => p.Rutcliente.Equals(clienteUpdate.Rutcliente));


                    if (Cliente == null)
                    {
                        return false;
                    }

                    Cliente.Ismoroso = "0";

                    context.Cliente.Update(Cliente);
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