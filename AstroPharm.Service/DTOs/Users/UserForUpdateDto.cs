﻿using AstroPharm.Domain.Entities;
using AstroPharm.Domain.Enums;

namespace AstroPharm.Service.DTOs.Users;

public class UserForUpdateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Role Role { get; set; }
}
