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

        // Folder : Catalog -> Category
        modelBuilder.Entity<Catalog>()
          .HasMany(c => c.Categories) 
          .WithOne(c => c.Catalog)     
          .HasForeignKey(c => c.CatalogId) 
          .OnDelete(DeleteBehavior.Cascade);

        // Folder : Banner -> Medication
        modelBuilder.Entity<Banner>()
       .HasOne(b => b.Medication)
       .WithMany()
       .HasForeignKey(b => b.MedicationId)
       .OnDelete(DeleteBehavior.Restrict); // Cascade delete ni o'chirish

        modelBuilder.Entity<Banner>()
            .HasOne(b => b.Category)
            .WithMany()
            .HasForeignKey(b => b.CategoryId)
            .OnDelete(DeleteBehavior.Restrict); // Cascade delete ni o'chirish
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        base.OnConfiguring(optionsBuilder);
    }

}
