using FluentEmail.Smtp;
using FluentEmail.Core;
using System.Net.Mail;
using System.Text;
using Business.Util;
using Microsoft.CodeAnalysis.Text;
using RestSharp;
using System.Text.Json;

public class Program
{
    public static void Main(string[] args)
    {
        /*
        Business.DTO.MailResponse? mailResponse1 =
            MailHandler.SendPaymentEmail(
                "sebas@gmail.com", "sender@gmail.com", "seba", "payment data");

        Business.DTO.MailResponse? mailResponse2 =
            MailHandler.SendContractExpiredEmail(
                "sebas@gmail.com", "sender@gmail.com", "seba", "payment data");

        Business.DTO.MailResponse? mailResponse3 =
            MailHandler.SendContractAboutToExpireEmail(
                "sebas@gmail.com", "sender@gmail.com", "seba", "payment data");

        if (mailResponse1 != null)
        {
            Console.WriteLine(mailResponse1.Result);
        }
        if (mailResponse2 != null)
        {
            Console.WriteLine(mailResponse2.Result);
        }
        if (mailResponse3 != null)
        {
            Console.WriteLine(mailResponse3.Result);
        }
        */
        List<Business.DTO.Actividad>? actividades = Business.DTO.Actividad.ReadAll();
        foreach (var item in actividades)
        {
            Console.WriteLine(item.ToString());
        }
    }
}

