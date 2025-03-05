using AstroPharm.Domain.Entities;
using AstroPharm.Service.DTOs.Users;
using System.Text.RegularExpressions;

namespace AstroPharm.Service.Validators;

public class UserValidator
{
    public void ValidateUser(UserForCreationDto user)
    {
        // Name leangth Validation
        if (string.IsNullOrWhiteSpace(user.FirstName) || user.FirstName.Length <= 2 || user.FirstName.Length > 50)
            throw new ArgumentException("First name must be between 2 and 50 characters.");
        // Name Validation
        if (!Regex.IsMatch(user.FirstName, "^[a-zA-Z]+$"))
            throw new ArgumentException("First name can only contain letters.");
        // Email format Validation
        if (string.IsNullOrWhiteSpace(user.Email) || !Regex.IsMatch(user.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            throw new ArgumentException("Invalid email format.");
        // Password Length Validation
        if (string.IsNullOrWhiteSpace(user.Password) || user.Password.Length < 8)
            throw new ArgumentException("Password must be at least 8 characters long.");
        // Password Format Validation
        if (!Regex.IsMatch(user.Password, @"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$"))
            throw new ArgumentException("Password must contain at least one uppercase letter, one number, and one special character.");

        if (string.IsNullOrWhiteSpace(user.PhoneNumber))
            throw new ArgumentException("Phone number is required.");
        // Uzbekistan phone number validation
        if (!Regex.IsMatch(user.PhoneNumber, @"^\+998\d{9}$"))
            throw new ArgumentException("Invalid phone number. It must start with +998 and have 9 digits.");

    }

}
