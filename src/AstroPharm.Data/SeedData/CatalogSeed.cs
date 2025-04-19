using AstroPharm.Domain.Entities.SubCategories;
using Microsoft.EntityFrameworkCore;

namespace AstroPharm.Data.SeedData
{
    public class CatalogSeed
    {
        public static void SeedCatalogs(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catalog>().HasData(
                new Catalog { Id = 1, CatalogName = "Pain Relief", CreatedAt = DateTime.Parse("2025-04-01") },
                new Catalog { Id = 2, CatalogName = "Antibiotics", CreatedAt = DateTime.Parse("2025-04-01") },
                new Catalog { Id = 3, CatalogName = "Vitamins & Supplements", CreatedAt = DateTime.Parse("2025-04-02") },
                new Catalog { Id = 4, CatalogName = "Skin Care", CreatedAt = DateTime.Parse("2025-04-02") },
                new Catalog { Id = 5, CatalogName = "Cold & Flu", CreatedAt = DateTime.Parse("2025-04-03") }
            );
        }
    }
}
