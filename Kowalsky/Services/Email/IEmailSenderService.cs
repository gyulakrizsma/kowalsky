using System.Threading.Tasks;
using Kowalsky.Models;

namespace Kowalsky.Services.Email
{
    public interface IEmailSenderService
    {
        Task SendEmailAsync(ContactInfo contactInfo);
    }
}
