using AstroPharm.Domain.Entities.Users;
using AstroPharm.Service.Interfaces.Emails;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AstroPharm.Api.Controllers.Emails
{
    public class EmailController : BaseController
    {
        private readonly IEmailService emailService;

        public EmailController(IEmailService emailService)
        {
            this.emailService = emailService;
        }
        [HttpPost]
        public async Task<IActionResult> SendEmailAsync(Message message)
        {
           
            await emailService.SendMessage(message);

            return Ok();
        }
    }
}
