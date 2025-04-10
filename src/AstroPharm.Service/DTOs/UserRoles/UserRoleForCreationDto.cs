using AstroPharm.Domain.Entities;
using AstroPharm.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPharm.Service.DTOs.UserRoles
{
    public class UserRoleForCreationDto 
    {
        public long UserId { get; set; }
        public Role Role { get; set; }
    }
}
