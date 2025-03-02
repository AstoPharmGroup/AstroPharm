using AstroPharm.Domain.Entities;
using AstroPharm.Domain.Enums;

namespace AstroPharm.Service.DTOs.Users;

public class UserForResultDto
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Role Role { get; set; }
    public ICollection<Order> Orders { get; set; }
}
