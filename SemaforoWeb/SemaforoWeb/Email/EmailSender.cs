using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System;

namespace SemaforoWeb.Email
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var emailSettings = _configuration.GetSection("CompanyMail").Get<EmailSenderSettings>();
                var client = new SmtpClient(emailSettings.SmtpServer, emailSettings.Port)
                {
                    EnableSsl = emailSettings.EnableSsl,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(emailSettings.Email, emailSettings.Password)
                };

                return client.SendMailAsync(
                    new MailMessage(from: emailSettings.Email,
                                    to: email,
                                    subject,
                                    message
                                    ));
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString()); // TODO: mejorar el logging de la app
                return null;
            }
        }
    }
}
