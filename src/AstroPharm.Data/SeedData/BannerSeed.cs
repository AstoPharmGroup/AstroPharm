using AstroPharm.Domain.Entities.SubCategories;
using Microsoft.EntityFrameworkCore;

namespace AstroPharm.Data.SeedData
{
    public class BannerSeed
    {
        public static void SeedBanners(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Banner>().HasData(
                new Banner { Id = 1, Title = "Pain Relief Sale", Description = "20% off analgesics", Image = "pain_sale.jpg", CategoryId = 1, MedicationId = 1, CreatedAt = DateTime.Parse("2025-04-02") },
                new Banner { Id = 2, Title = "Antibiotic Promo", Description = "Buy 2, get 1 free", Image = "antibiotic_promo.jpg", CategoryId = 2, MedicationId = 2, CreatedAt = DateTime.Parse("2025-04-02") },
                new Banner { Id = 3, Title = "Winter Care Offer", Description = "50% off on cold medications", Image = "winter_care.jpg", CategoryId = 1, MedicationId = 3, CreatedAt = DateTime.Parse("2025-04-03") },
                new Banner { Id = 4, Title = "Healthy Gut Sale", Description = "15% off probiotics", Image = "gut_health.jpg", CategoryId = 2, MedicationId = 4, CreatedAt = DateTime.Parse("2025-04-04") },
                new Banner { Id = 5, Title = "Beauty Boosters", Description = "20% off on skin health products", Image = "beauty_boost.jpg", CategoryId = 3, MedicationId = 5, CreatedAt = DateTime.Parse("2025-04-05") }
            );
        }
    }
}
