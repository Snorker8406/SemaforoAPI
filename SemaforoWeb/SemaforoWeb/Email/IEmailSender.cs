using System.Threading.Tasks;

namespace SemaforoWeb.Email
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
