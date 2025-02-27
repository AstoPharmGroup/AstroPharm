using AstroPharm.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AstroPharm.Data.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Catalog> Catalogs { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Medication> Medications { get; set; }

    // Bazadagi jadval nomlarini, ustunlarning uzunligi, turini o‘zgartirish
    // One-to-One, One-to-Many, Many-to-Many munosabatlarni aniqlash
    // Primary key, foreign key, unique constraintlarni belgilash
    // uchun foydalanamiz va u bilan biz Seed Data larni qoshamiz OnModelCreating bilan.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

}
