using FluentEmail.Smtp;
using FluentEmail.Core;
using System.Net.Mail;
using System.Text;
using Business.Util;
using Microsoft.CodeAnalysis.Text;
using RestSharp;
using System.Text.Json;
using System.Linq;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {

        using (ModelContext context = new ModelContext())
        {

            //IQueryable resultReduced = context.Contrato
            //    .Select(c => new
            //    {
            //        Valor = c.Valor,
            //        Vigente = c.Vigente,
            //        TipoActividad = Business.DTO.TipoActividad.Read(Business.DTO.Actividad.Read(c.Idactividad).Idtipoactividad).Descripcion
            //    });

            //foreach (var item in resultReduced)
            //{
            //    Console.WriteLine(item.GetType());
            //}

            //var result = (from c in context.Cliente
            //              join r in context.Rubro
            //              on c.Idrubro equals r.Idrubro
            //              group c.Rutcliente.Count() by new { r.Descripcion, c.Ismoroso } into g
            //              select new
            //              {
            //                  Rubro = g.Key.Descripcion,
            //                  //IsMoroso = g.Key.Ismoroso.Equals("0") ? true : false,
            //                  CantidadClientesMorosos = g.Count()
            //              }).ToList();

            List<string> labels =
                (
                    from c in context.Cliente
                    join r in context.Rubro
                    on c.Idrubro equals r.Idrubro
                    where c.Ismoroso.Equals("1")
                    group c.Rutcliente.Count() by r.Descripcion into g
                    select g.Key
                ).ToList<string>();

            List<int> debtors =
                (
                    from c in context.Cliente
                    join r in context.Rubro
                    on c.Idrubro equals r.Idrubro
                    where c.Ismoroso.Equals("1")
                    group c.Rutcliente.Count() by r.Descripcion into g
                    select g.Count()
                ).ToList<int>();

            List<int> notDebtors = 
                (
                    from c in context.Cliente
                    join r in context.Rubro
                    on c.Idrubro equals r.Idrubro
                    where c.Ismoroso.Equals("0")
                    group c.Rutcliente.Count() by r.Descripcion into g
                    select g.Count()
                ).ToList<int>();

            labels.ForEach(x => Console.WriteLine(x));
            debtors.ForEach(x => Console.WriteLine(x));
            notDebtors.ForEach(x => Console.WriteLine(x));
        }
    }
}

