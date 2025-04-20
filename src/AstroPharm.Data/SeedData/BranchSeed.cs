using AstroPharm.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AstroPharm.Data.SeedData
{
    public class BranchSeed
    {
        public static void SeedBranches(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>().HasData(
                new Branch { Id = 1, BranchName = "Tashkent Central", LocationId = 1, CreatedAt = DateTime.Parse("2025-04-01") },
                new Branch { Id = 2, BranchName = "Bukhara Main", LocationId = 2, CreatedAt = DateTime.Parse("2025-04-01") },
                new Branch { Id = 3, BranchName = "Samarkand Plaza", LocationId = 3, CreatedAt = DateTime.Parse("2025-04-01") },
                new Branch { Id = 4, BranchName = "Fergana Central", LocationId = 4, CreatedAt = DateTime.Parse("2025-04-02") },
                new Branch { Id = 5, BranchName = "Andijan Main", LocationId = 5, CreatedAt = DateTime.Parse("2025-04-02") }
            );
        }
    }
}
