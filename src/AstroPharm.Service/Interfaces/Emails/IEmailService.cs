using AstroPharm.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPharm.Service.Interfaces.Emails
{
    public interface IEmailService
    {
        Task SendMessage(Message message); 
    }
}
