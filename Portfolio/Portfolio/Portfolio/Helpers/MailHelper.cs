using Portfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Portfolio.Helpers
{
    public class MailHelper
    {
        public bool SendMail(MailingModel mailing)
        {
            try
            {

                List<string> Tos = mailing.MailTo.Split(',').ToList();

                //
                var body = mailing.MailBody;
                var message = new MailMessage();
                foreach (string to in Tos)
                {
                    message.To.Add(new MailAddress(to));
                }

                message.From = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["EmailFrom"]);  // replace with valid value
                message.Subject = mailing.MailSubject;
                message.Body = string.Format(body);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = System.Configuration.ConfigurationManager.AppSettings["EmailUserName"],
                        Password = System.Configuration.ConfigurationManager.AppSettings["EmailPassword"]
                    };
                    smtp.Credentials = credential;
                    smtp.Host = System.Configuration.ConfigurationManager.AppSettings["EmailSMTPHost"];
                    smtp.Port = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["EmailSMTPPort"]);
                    smtp.EnableSsl = Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["SSLEnable"]);
                    smtp.Send(message);

                }
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}