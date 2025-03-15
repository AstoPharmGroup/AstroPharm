using AstroPharm.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AstroPharm.Data.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Banner> Banners { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Catalog> Catalogs { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<WishList> WishLists { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Medication> Medications { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    // Bazadagi jadval nomlarini, ustunlarning uzunligi, turini o‘zgartirish
    // One-to-One, One-to-Many, Many-to-Many munosabatlarni aniqlash
    // Primary key, foreign key, unique constraintlarni belgilash
    // uchun foydalanamiz va u bilan biz Seed Data larni qoshamiz OnModelCreating bilan.
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Catalog -> Category
        modelBuilder.Entity<Catalog>()
            .HasMany(c => c.Categories)
            .WithOne(c => c.Catalog)
            .HasForeignKey(c => c.CatalogId)
            .OnDelete(DeleteBehavior.Cascade);

        // Banner -> Medication
        modelBuilder.Entity<Banner>()
            .HasOne(b => b.Medication)
            .WithMany()
            .HasForeignKey(b => b.MedicationId)
            .OnDelete(DeleteBehavior.SetNull);

        //// Banner -> Category
        //modelBuilder.Entity<Banner>()
        //    .HasOne(b => b.Category)
        //    .WithMany()
        //    .HasForeignKey(b => b.CategoryId)
        //    .OnDelete(DeleteBehavior.SetNull);

        //// Medication -> Category
        //modelBuilder.Entity<Medication>()
        //    .HasOne(m => m.Category)
        //    .WithMany(c => c.Medications)
        //    .HasForeignKey(m => m.CategoryId)
        //    .OnDelete(DeleteBehavior.Cascade);

        //// WishList -> Medication
        //modelBuilder.Entity<WishList>()
        //    .HasOne(w => w.Medication)
        //    .WithMany(m => m.WishLists)
        //    .HasForeignKey(w => w.MedicationId)
        //    .OnDelete(DeleteBehavior.Cascade);

        //// CartItem -> Medication
        //modelBuilder.Entity<CartItem>()
        //    .HasOne(c => c.Medication)
        //    .WithMany(m => m.CartItems)
        //    .HasForeignKey(c => c.MedicationId)
        //    .OnDelete(DeleteBehavior.Cascade);

        //// OrderDetails -> Medication
        //modelBuilder.Entity<OrderDetail>()
        //    .HasOne(o => o.Medication)
        //    .WithMany(m => m.OrderDetails)
        //    .HasForeignKey(o => o.MedicationId)
        //    .OnDelete(DeleteBehavior.Cascade);

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        base.OnConfiguring(optionsBuilder);
    }

}
