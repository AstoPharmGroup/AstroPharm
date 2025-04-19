using AstroPharm.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;

namespace AstroPharm.Data.SeedData
{
    public class CartItemSeed
    {
        public static void SeedCartItems(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CartItem>().HasData(
                new CartItem { Id = 1, Count = 2, UserId = 1, MedicationId = 1, CreatedAt = DateTime.Parse("2025-04-04") },
                new CartItem { Id = 2, Count = 1, UserId = 1, MedicationId = 2, CreatedAt = DateTime.Parse("2025-04-04") },
                new CartItem { Id = 3, Count = 3, UserId = 2, MedicationId = 1, CreatedAt = DateTime.Parse("2025-04-05") },
                new CartItem { Id = 4, Count = 1, UserId = 3, MedicationId = 2, CreatedAt = DateTime.Parse("2025-04-06") },
                new CartItem { Id = 5, Count = 5, UserId = 2, MedicationId = 1, CreatedAt = DateTime.Parse("2025-04-07") }
            );
        }
    }
}
