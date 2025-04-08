using AstroPharm.Domain.Entities.Users;
using AstroPharm.Service.Interfaces.Emails;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
namespace AstroPharm.Service.Services.Emails
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration.GetSection("Email");
        }

        public async Task SendMessage(Message message)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_configuration["EmailAddress"]));
            email.To.Add(MailboxAddress.Parse(message.To));
            email.Subject = message.Subject;
            email.Body = new TextPart("html")
            {
                Text = message.Body
            };

            var smpt = new SmtpClient();
            await smpt.ConnectAsync(_configuration["Host"], 587, MailKit.Security.SecureSocketOptions.StartTls);
            await smpt.AuthenticateAsync(_configuration["EmailAddress"], _configuration["Password"]);
            await smpt.SendAsync(email);
            await smpt.DisconnectAsync(true);
        }
    }
}
