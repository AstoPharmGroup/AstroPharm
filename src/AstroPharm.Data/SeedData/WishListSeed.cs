using AstroPharm.Domain.Entities;
using AstroPharm.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AstroPharm.Data.SeedData
{
    public class WishListSeed
    {
        public static void SeedWishLists(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WishList>().HasData(
                new WishList
                {
                    Id = 1, // Explicitly setting Id
                    UserId = 1, // Example user with UserId 1
                    MedicationId = 2, // Example medication with MedicationId 2
                },
                new WishList
                {
                    Id = 2, // Explicitly setting Id
                    UserId = 1, // Example user with UserId 1
                    MedicationId = 3, // Example medication with MedicationId 3
                },
                new WishList
                {
                    Id = 3, // Explicitly setting Id
                    UserId = 2, // Example user with UserId 2
                    MedicationId = 1, // Example medication with MedicationId 1
                },
                new WishList
                {
                    Id = 4, // Explicitly setting Id
                    UserId = 3, // Example user with UserId 3
                    MedicationId = 4, // Example medication with MedicationId 4
                }
              
            );
        }
    }
}
