using Core.Entities.Concrete;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
