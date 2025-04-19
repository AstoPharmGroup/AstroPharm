using AstroPharm.Domain.Entities;
using AstroPharm.Domain.Entities.Users;
using AstroPharm.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace AstroPharm.Data.SeedData
{
    public class UserSeed
    {
        public static void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1, // Explicitly setting Id
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    Password = "hashedpassword123", // Should be hashed in production
                    PhoneNumber = "123-456-7890",
                    Role = Role.User, // Normal user role
                    LanguageId = 1, // Example LanguageId for English
                },
                new User
                {
                    Id = 2, // Explicitly setting Id
                    FirstName = "Jane",
                    LastName = "Smith",
                    Email = "jane.smith@example.com",
                    Password = "hashedpassword456",
                    PhoneNumber = "987-654-3210",
                    Role = Role.Admin, // Admin role
                    LanguageId = 2, // Example LanguageId for Spanish
                },
                new User
                {
                    Id = 3, // Explicitly setting Id
                    FirstName = "Alice",
                    LastName = "Johnson",
                    Email = "alice.johnson@example.com",
                    Password = "hashedpassword789",
                    PhoneNumber = "555-123-4567",
                    Role = Role.User, // Normal user role
                    LanguageId = 1, // English
                },
                new User
                {
                    Id = 4, // Explicitly setting Id
                    FirstName = "Bob",
                    LastName = "Brown",
                    Email = "bob.brown@example.com",
                    Password = "hashedpassword012",
                    PhoneNumber = "321-654-9870",
                    Role = Role.User, // Normal user role
                    LanguageId = 3, // Example LanguageId for French
                },
                new User
                {
                    Id = 5, // Explicitly setting Id
                    FirstName = "Charlie",
                    LastName = "Davis",
                    Email = "charlie.davis@example.com",
                    Password = "hashedpassword345",
                    PhoneNumber = "654-321-9876",
                    Role = Role.SuperAdmin, // SuperAdmin role
                    LanguageId = 2, // Spanish
                },
                new User
                {
                    Id = 6, // Explicitly setting Id
                    FirstName = "Diana",
                    LastName = "Evans",
                    Email = "diana.evans@example.com",
                    Password = "hashedpassword678",
                    PhoneNumber = "456-789-1230",
                    Role = Role.Admin, // Admin role
                    LanguageId = 1, // English
                },
                new User
                {
                    Id = 7, // Explicitly setting Id
                    FirstName = "Eve",
                    LastName = "White",
                    Email = "eve.white@example.com",
                    Password = "hashedpassword901",
                    PhoneNumber = "111-222-3333",
                    Role = Role.User, // Normal user role
                    LanguageId = 4, // Example LanguageId for German
                },
                new User
                {
                    Id = 8, // Explicitly setting Id
                    FirstName = "Frank",
                    LastName = "Green",
                    Email = "frank.green@example.com",
                    Password = "hashedpassword234",
                    PhoneNumber = "777-888-9999",
                    Role = Role.SuperAdmin, // SuperAdmin role
                    LanguageId = 3, // French
                }
            );
        }
    }
}
