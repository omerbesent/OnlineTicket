using Core.Entities.Concrete;
using Core.Utilities.Results;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
        IResult SendRegisterEmail(string email, string name, string body, string confirmLink);
    }
}
