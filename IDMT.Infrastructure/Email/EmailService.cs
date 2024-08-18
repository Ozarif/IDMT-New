
using IDMT.Application.Abstractions.Email;
using IDMT.Application.Models;
using Microsoft.Extensions.Options;
using System.Net.Mail;

namespace IDMT.Infrastructure.Email
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _settings;

        public EmailService(IOptions<EmailConfiguration> settings)
        {
            _settings = settings.Value;
        }

		public async Task SendAsync(EmailMessage emailMessage)
		{
			MailMessage mailMessage = CreatMailMessage(emailMessage);

			SmtpClient smtpClient = new SmtpClient(_settings.SmtpServer, _settings.Port);

			smtpClient.Credentials = new System.Net.NetworkCredential(_settings.UserName, _settings.Password);

			try
			{
				await smtpClient.SendMailAsync(mailMessage);

			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        private MailMessage CreatMailMessage(EmailMessage email)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_settings.From);

            foreach (MailAddress toAddress in email.To)
            {
                mailMessage.To.Add(toAddress);
            }

            mailMessage.Subject = email.Subject;
            mailMessage.Body = email.Body;

            return mailMessage;
        }
    }
}