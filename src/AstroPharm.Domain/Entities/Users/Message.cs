using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPharm.Domain.Entities.Users
{
    public class Message
    {
        public string To { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }

    }
}
