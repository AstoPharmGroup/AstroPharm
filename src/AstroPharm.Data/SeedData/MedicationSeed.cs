using AstroPharm.Domain.Entities.Products;
using AstroPharm.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace AstroPharm.Data.SeedData
{
    public class MedicationSeed
    {
        public static void SeedMedications(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medication>().HasData(
                new Medication
                {
                    Id = 1,
                    MedicationName = "Paracetamol",
                    Image = "paracetamol.jpg",
                    Price = 5.99m,
                    Status = Status.mavjud,
                    CategoryId = 1,
                    Description = "Pain reliever",
                    ExpiredDate = DateTime.Parse("2026-04-01"),
                    CreatedAt = DateTime.Parse("2025-04-01")
                },
                new Medication
                {
                    Id = 2,
                    MedicationName = "Amoxicillin",
                    Image = "amoxicillin.jpg",
                    Price = 12.50m,
                    Status = Status.mavjud,
                    CategoryId = 2,
                    Description = "Antibiotic",
                    ExpiredDate = DateTime.Parse("2026-04-01"),
                    CreatedAt = DateTime.Parse("2025-04-01")
                },
                new Medication
                {
                    Id = 3,
                    MedicationName = "Ibuprofen",
                    Image = "ibuprofen.jpg",
                    Price = 8.99m,
                    Status = Status.mavjud,
                    CategoryId = 1,
                    Description = "Anti-inflammatory",
                    ExpiredDate = DateTime.Parse("2026-06-01"),
                    CreatedAt = DateTime.Parse("2025-04-02")
                },
                new Medication
                {
                    Id = 4,
                    MedicationName = "Ciprofloxacin",
                    Image = "ciprofloxacin.jpg",
                    Price = 15.99m,
                    Status = Status.mavjud,
                    CategoryId = 2,
                    Description = "Antibiotic",
                    ExpiredDate = DateTime.Parse("2026-06-01"),
                    CreatedAt = DateTime.Parse("2025-04-02")
                },
                new Medication
                {
                    Id = 5,
                    MedicationName = "Cetirizine",
                    Image = "cetirizine.jpg",
                    Price = 6.49m,
                    Status = Status.mavjud,
                    CategoryId = 1,
                    Description = "Antihistamine",
                    ExpiredDate = DateTime.Parse("2026-07-01"),
                    CreatedAt = DateTime.Parse("2025-04-03")
                }
            );
        }
    }
}
