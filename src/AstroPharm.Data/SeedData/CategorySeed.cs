using AstroPharm.Domain.Entities.SubCategories;
using Microsoft.EntityFrameworkCore;

namespace AstroPharm.Data.SeedData
{
    public class CategorySeed
    {
        public static void SeedCategories(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, CatalogId = 1, CategoryName = "Analgesics", Description = "Pain relief medications", CreatedAt = DateTime.Parse("2025-04-01") },
                new Category { Id = 2, CatalogId = 2, CategoryName = "Penicillin", Description = "Antibiotic medications", CreatedAt = DateTime.Parse("2025-04-01") },
                new Category { Id = 3, CatalogId = 3, CategoryName = "Multivitamins", Description = "Various vitamins and supplements", CreatedAt = DateTime.Parse("2025-04-02") },
                new Category { Id = 4, CatalogId = 4, CategoryName = "Moisturizers", Description = "Skin moisturizing products", CreatedAt = DateTime.Parse("2025-04-02") },
                new Category { Id = 5, CatalogId = 5, CategoryName = "Cough Syrups", Description = "Medicines for cough relief", CreatedAt = DateTime.Parse("2025-04-03") }
            );
        }
    }
}
