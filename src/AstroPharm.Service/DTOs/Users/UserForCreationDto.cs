using AstroPharm.Domain.Entities;
using AstroPharm.Domain.Enums;
using System.Data;

namespace AstroPharm.Service.DTOs.Users;

public class UserForCreationDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public Role Role { get; set; }
}
