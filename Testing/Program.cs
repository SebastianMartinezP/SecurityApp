using FluentEmail.Smtp;
using FluentEmail.Core;
using System.Net.Mail;
using System.Text;

public class Program
{
    static async Task Main(string[] args)
    {
        var sender = new SmtpSender(() => new SmtpClient("localhost")
        {
            EnableSsl = false,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            Port = 25,

        });

        StringBuilder template = new();
        template.AppendLine("<h1>Hola @Model.FirstName,</h1>");
        template.AppendLine("<p> Gracias por comprar @Model.ProductName. Esperamos que le haya gustado. </p>");
        template.AppendLine(" - Security.");


        Email.DefaultSender = sender;


        var email = await Email
            .From("martinez.sebastian314159@gmail.com")
            .To("longlivetheking70@gmail.com", "Sebastian")
            .Subject("Hola 123")
            .UsingTemplate(template.ToString(), new { FirstName = "Sebastian", ProductName = "Teclado Mecanico"})
            .SendAsync();


    }
}

