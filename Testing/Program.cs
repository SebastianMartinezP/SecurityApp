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
            List<Database.Models.Contrato> contratoContext = context.Contrato.ToList();
            Console.WriteLine(contratoContext);
        }
    }
}

