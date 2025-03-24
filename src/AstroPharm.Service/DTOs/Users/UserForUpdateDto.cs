using AstroPharm.Domain.Enums;

namespace AstroPharm.Service.DTOs.Users;

public class UserForUpdateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public long LanguageId { get; set; }
    public Role Role { get; set; }
}
