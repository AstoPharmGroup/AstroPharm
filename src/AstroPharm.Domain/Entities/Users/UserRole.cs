using AstroPharm.Domain.Commons;
using AstroPharm.Domain.Enums;

namespace AstroPharm.Domain.Entities.Users;

public class UserRole : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }

    public Role Role { get; set; } 
}
