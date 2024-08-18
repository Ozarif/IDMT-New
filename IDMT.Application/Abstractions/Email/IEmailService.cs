
using IDMT.Application.Models;

namespace IDMT.Application.Abstractions.Email;
public interface IEmailService
{
    Task SendAsync(EmailMessage emailMessage);
}
