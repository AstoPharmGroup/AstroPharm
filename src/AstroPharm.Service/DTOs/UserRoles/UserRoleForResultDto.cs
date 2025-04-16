using AstroPharm.Domain.Entities;
using AstroPharm.Domain.Enums;
using AstroPharm.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPharm.Service.DTOs.UserRoles
{
    public class UserRoleForResultDto
    {
        public long UserId { get; set; }
        public UserForResultDto User { get; set; }
        public Role Role { get; set; }
    }
}
