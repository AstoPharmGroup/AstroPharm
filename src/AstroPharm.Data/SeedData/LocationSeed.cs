using AstroPharm.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AstroPharm.Data.SeedData
{
    public class LocationSeed
    {
        public static void SeedLocations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().HasData(
                new Location { Id = 1, LoLatitude = 41.2995, Longitude = 69.2401, CreatedAt = DateTime.Parse("2025-04-01") }, // Tashkent
                new Location { Id = 2, LoLatitude = 39.7817, Longitude = 64.4286, CreatedAt = DateTime.Parse("2025-04-01") }, // Bukhara
                new Location { Id = 3, LoLatitude = 40.1107, Longitude = 69.1111, CreatedAt = DateTime.Parse("2025-04-02") }, // Samarkand
                new Location { Id = 4, LoLatitude = 41.3123, Longitude = 69.2787, CreatedAt = DateTime.Parse("2025-04-02") }, // Fergana
                new Location { Id = 5, LoLatitude = 38.5355, Longitude = 66.9734, CreatedAt = DateTime.Parse("2025-04-03") }  // Nukus
            );
        }
    }
}
