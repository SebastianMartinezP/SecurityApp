using Business.DTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Business.Util;
using System.Text.Json;

namespace Business.Util
{
    public static class MailHandler
    {
        public static MailResponse? SendPaymentEmail(
            string emailFrom, string emailTo, string nameTo, string paymentData)
        {
			try
			{
                string apiUri = string.Format(
                    "https://localhost:7000/" +
                    "MailSender/SendPaymentEmail?" +
                    "emailFrom={0}&emailTo={1}&nameTo={2}&paymentData={3}",
                    emailFrom, emailTo, nameTo, paymentData);


				RestClient client = new RestClient(apiUri);
                var request = new RestRequest("", Method.Post);
                RestResponse response = client.Execute(request);

                if (response.IsSuccessStatusCode)
                {
                    return new MailResponse()
                    {
                        IsSuccessful = true,
                        Result = 
                            string.Format("Correo enviado correctamente a: {0}.", 
                            emailTo),
                    };
                }
                else
                {
                    return new MailResponse()
                    {
                        IsSuccessful = false,
                        Result = "Error en la request."
                    };
                }

            }
			catch (Exception e)
			{

				return new MailResponse()
				{
					IsSuccessful = false,
					Result = e.Message,
				};
			}
        }


        public static MailResponse? SendContractAboutToExpireEmail(
            string emailFrom, string emailTo, string nameTo, string contractData)
        {
            try
            {
                string apiUri = string.Format(
                    "https://localhost:7000/" +
                    "MailSender/SendContractAboutToExpireEmail?" +
                    "emailFrom={0}&emailTo={1}&nameTo={2}&contractData={3}",
                    emailFrom, emailTo, nameTo, contractData);


                RestClient client = new RestClient(apiUri);
                var request = new RestRequest("", Method.Post);
                RestResponse response = client.Execute(request);

                if (response.IsSuccessStatusCode)
                {
                    return new MailResponse()
                    {
                        IsSuccessful = true,
                        Result = 
                            string.Format("correo enviado correctamente a: {0}.", 
                            emailTo),
                    };
                }
                else
                {
                    return new MailResponse()
                    {
                        IsSuccessful = false,
                        Result = "Error en la request."
                    };
                }

            }
            catch (Exception e)
            {

                return new MailResponse()
                {
                    IsSuccessful = false,
                    Result = e.Message,
                };
            }
        }


        public static MailResponse? SendContractExpiredEmail(
            string emailFrom, string emailTo, string nameTo, string contractData)
        {
            try
            {
                string apiUri = string.Format(
                    "https://localhost:7000/" +
                    "MailSender/SendContractExpiredEmail?" +
                    "emailFrom={0}&emailTo={1}&nameTo={2}&contractData={3}",
                    emailFrom, emailTo, nameTo, contractData);


                RestClient client = new RestClient(apiUri);
                var request = new RestRequest("", Method.Post);
                RestResponse response = client.Execute(request);

                if (response.IsSuccessStatusCode)
                {
                    return new MailResponse()
                    {
                        IsSuccessful = true,
                        Result = 
                            string.Format("Correo enviado correctamente a: {0}.",
                            emailTo),
                    };
                }
                else
                {
                    return new MailResponse()
                    {
                        IsSuccessful = false,
                        Result = "Error en la request."
                    };
                }

            }
            catch (Exception e)
            {

                return new MailResponse()
                {
                    IsSuccessful = false,
                    Result = e.Message,
                };
            }
        }
    }   
}
