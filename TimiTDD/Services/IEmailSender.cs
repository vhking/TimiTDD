using System.Threading.Tasks;

namespace TimiTDD.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}