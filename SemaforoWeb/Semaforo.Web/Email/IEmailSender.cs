using System.Threading.Tasks;

namespace Semaforo.Web.Email
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
