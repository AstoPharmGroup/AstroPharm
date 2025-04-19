using AstroPharm.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AstroPharm.Data.SeedData
{
    public class LanguageSeed
    {
        public static void SeedLanguages(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().HasData(
                new Language { Id = 1, LanguageName = "English", CreatedAt = DateTime.Parse("2025-04-01") },
                new Language { Id = 2, LanguageName = "Uzbek", CreatedAt = DateTime.Parse("2025-04-01") },
                new Language { Id = 3, LanguageName = "Russian", CreatedAt = DateTime.Parse("2025-04-02") },
                new Language { Id = 4, LanguageName = "Spanish", CreatedAt = DateTime.Parse("2025-04-02") },
                new Language { Id = 5, LanguageName = "French", CreatedAt = DateTime.Parse("2025-04-03") }
            );
        }
    }
}
