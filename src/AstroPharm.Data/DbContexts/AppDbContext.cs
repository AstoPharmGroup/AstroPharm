using AstroPharm.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AstroPharm.Data.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    #region
    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Banner> Banners { get; set; }
    public DbSet<PaymentForResultDto> Payments { get; set; }
    public DbSet<Catalog> Catalogs { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<WishList> WishLists { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Medication> Medications { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    #endregion
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // Hamma konfiguratsiyalarni avtomatik yuklash
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        #region boglanishlar tugadi
        // // Catalog -> Category
        // modelBuilder.Entity<Catalog>()
        //     .HasMany(c => c.Categories)
        //     .WithOne(c => c.Catalog)
        //     .HasForeignKey(c => c.CatalogId)
        //     .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Banner>()
        .HasOne(b => b.Category)
        .WithMany()
        .HasForeignKey(b => b.CategoryId)
        .OnDelete(DeleteBehavior.Restrict);

        // Banner -> Medication
        //modelBuilder.Entity<Banner>()
        //    .HasOne(b => b.Medication)
        //    .WithMany()
        //    .HasForeignKey(b => b.MedicationId)
        //    .OnDelete(DeleteBehavior.SetNull);

        //// Banner -> Category
        //modelBuilder.Entity<Banner>()
        //    .HasOne(b => b.Category)
        //    .WithMany()
        //    .HasForeignKey(b => b.CategoryId)
        //    .OnDelete(DeleteBehavior.NoAction);

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
        #endregion
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        base.OnConfiguring(optionsBuilder);
    }

}
