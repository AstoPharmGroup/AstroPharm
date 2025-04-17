using AstroPharm.Domain.Entities;
using AstroPharm.Domain.Entities.Orders;
using AstroPharm.Domain.Entities.Products;
using AstroPharm.Domain.Entities.SubCategories;
using AstroPharm.Domain.Entities.Users;
using AstroPharm.Domain.Enums;
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
    public DbSet<Payment> Payments { get; set; }
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
        //// Hamma konfiguratsiyalarni avtomatik yuklash
        //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

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

        #region SeedData
        modelBuilder.Entity<Language>().HasData(
            new Language { Id = 1, LanguageName = "English", CreatedAt = DateTime.Parse("2025-04-01") },
            new Language { Id = 2, LanguageName = "Uzbek", CreatedAt = DateTime.Parse("2025-04-01") }
        );

        // 2. Location
        modelBuilder.Entity<Location>().HasData(
            new Location { Id = 1, LoLatitude = 41.2995, Longitude = 69.2401, CreatedAt = DateTime.Parse("2025-04-01") }, // Tashkent
            new Location { Id = 2, LoLatitude = 39.7817, Longitude = 64.4286, CreatedAt = DateTime.Parse("2025-04-01") }  // Bukhara
        );

        // 3. Branch
        modelBuilder.Entity<Branch>().HasData(
            new Branch { Id = 1, BranchName = "Tashkent Central", LocationId = 1, CreatedAt = DateTime.Parse("2025-04-01") },
            new Branch { Id = 2, BranchName = "Bukhara Main", LocationId = 2, CreatedAt = DateTime.Parse("2025-04-01") }
        );

        // 4. User
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Role = Role.User, Email = "john.doe@example.com", FirstName = "John", LastName = "Doe", LanguageId = 1, Password = "hashedpassword1", PhoneNumber = "+998901234567", CreatedAt = DateTime.Parse("2025-04-02") },
            new User { Id = 2, Role = Role.Admin, Email = "admin@example.com", FirstName = "Admin", LastName = "User", LanguageId = 2, Password = "hashedpassword2", PhoneNumber = "+998901234568", CreatedAt = DateTime.Parse("2025-04-02") },
            new User { Id = 3, Role = Role.SuperAdmin, Email = "superadmin@example.com", FirstName = "SuperAdmin", LastName = "User", LanguageId = 1, Password = "hashedpassword3", PhoneNumber = "+998901234569", CreatedAt = DateTime.Parse("2025-04-02") }
        );

        // 5. UserRole (optional, since Role is also in User)
        //modelBuilder.Entity<UserRole>().HasData(
        //    new UserRole { Id = 1, UserId = 1, Role = Role.User, CreatedAt = DateTime.Parse("2025-04-02") },
        //    new UserRole { Id = 2, UserId = 2, Role = Role.Courier, CreatedAt = DateTime.Parse("2025-04-02") },
        //    new UserRole { Id = 3, UserId = 3, Role = Role.Admin, CreatedAt = DateTime.Parse("2025-04-02") }
        //);

        // 6. RefreshToken
        modelBuilder.Entity<RefreshToken>().HasData(
            new RefreshToken { Id = 1, Token = "token123", ExpiryDate = DateTime.Parse("2025-05-01"), UserId = 1, CreatedAt = DateTime.Parse("2025-04-03") },
            new RefreshToken { Id = 2, Token = "token456", ExpiryDate = DateTime.Parse("2025-05-01"), UserId = 2, CreatedAt = DateTime.Parse("2025-04-03") }
        );

        // 7. Catalog
        modelBuilder.Entity<Catalog>().HasData(
            new Catalog { Id = 1, CatalogName = "Pain Relief", CreatedAt = DateTime.Parse("2025-04-01") },
            new Catalog { Id = 2, CatalogName = "Antibiotics", CreatedAt = DateTime.Parse("2025-04-01") }
        );

        // 8. Category
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, CatalogId = 1, CategoryName = "Analgesics", Description = "Pain relief medications", CreatedAt = DateTime.Parse("2025-04-01") },
            new Category { Id = 2, CatalogId = 2, CategoryName = "Penicillin", Description = "Antibiotic medications", CreatedAt = DateTime.Parse("2025-04-01") }
        );

        // 9. Medication
        modelBuilder.Entity<Medication>().HasData(
            new Medication { Id = 1, MedicationName = "Paracetamol", Image = "paracetamol.jpg", Price = 5.99m, Status = Status.mavjud, CategoryId = 1, Description = "Pain reliever", ExpiredDate = DateTime.Parse("2026-04-01"), CreatedAt = DateTime.Parse("2025-04-01") },
            new Medication { Id = 2, MedicationName = "Amoxicillin", Image = "amoxicillin.jpg", Price = 12.50m, Status = Status.mavjud, CategoryId = 2, Description = "Antibiotic", ExpiredDate = DateTime.Parse("2026-04-01"), CreatedAt = DateTime.Parse("2025-04-01") }
        );

        // 10. Banner
        modelBuilder.Entity<Banner>().HasData(
            new Banner { Id = 1, Title = "Pain Relief Sale", Description = "20% off analgesics", Image = "pain_sale.jpg", CategoryId = 1, MedicationId = 1, CreatedAt = DateTime.Parse("2025-04-02") },
            new Banner { Id = 2, Title = "Antibiotic Promo", Description = "Buy 2, get 1 free", Image = "antibiotic_promo.jpg", CategoryId = 2, MedicationId = 2, CreatedAt = DateTime.Parse("2025-04-02") }
        );

        // 11. WishList
        modelBuilder.Entity<WishList>().HasData(
            new WishList { Id = 1, UserId = 1, MedicationId = 1, CreatedAt = DateTime.Parse("2025-04-03") },
            new WishList { Id = 2, UserId = 1, MedicationId = 2, CreatedAt = DateTime.Parse("2025-04-03") }
        );

        // 12. CartItem
        modelBuilder.Entity<CartItem>().HasData(
            new CartItem { Id = 1, Count = 2, UserId = 1, MedicationId = 1, CreatedAt = DateTime.Parse("2025-04-04") },
            new CartItem { Id = 2, Count = 1, UserId = 1, MedicationId = 2, CreatedAt = DateTime.Parse("2025-04-04") }
        );

        // 13. Order
        modelBuilder.Entity<Order>().HasData(
            new Order { Id = 1, UserId = 1, TotalAmount = 23, OrderDate = DateTime.Parse("2025-04-05"), CreatedAt = DateTime.Parse("2025-04-05") },
            new Order { Id = 2, UserId = 1, TotalAmount = 12, OrderDate = DateTime.Parse("2025-04-06"), CreatedAt = DateTime.Parse("2025-04-06") }
        );

        // 14. Payment
        modelBuilder.Entity<Payment>().HasData(
            new Payment { Id = 1, Amount = 23.48m, PaymentDate = DateTime.Parse("2025-04-05"), PaymentStatus = PaymentStatus.paid, PaymentMethod = PaymentMethod.card, CreatedAt = DateTime.Parse("2025-04-05") },
            new Payment { Id = 2, Amount = 12.50m, PaymentDate = DateTime.Parse("2025-04-06"), PaymentStatus = PaymentStatus.pending, PaymentMethod = PaymentMethod.cash, CreatedAt = DateTime.Parse("2025-04-06") }
        );

        // 15. OrderDetail
        modelBuilder.Entity<OrderDetail>().HasData(
            new OrderDetail { Id = 1, Quantity = 2, Discount = 0m, TotalAmount = 11.98m, OrderId = 1, MedicationId = 1, PaymentId = 1, CreatedAt = DateTime.Parse("2025-04-05") },
            new OrderDetail { Id = 2, Quantity = 1, Discount = 0m, TotalAmount = 12.50m, OrderId = 2, MedicationId = 2, PaymentId = 2, CreatedAt = DateTime.Parse("2025-04-06") }
        );

        // 16. Delivery
        //modelBuilder.Entity<Delivery>().HasData(
        //    new Delivery { Id = 1, OrderId = 1, CourierId = 2, Status = DeliveryStatus.Delivered, ActualDeliveryDate = DateTime.Parse("2025-04-06"), EstimatedDeliveryDate = DateTime.Parse("2025-04-06"), CreatedAt = DateTime.Parse("2025-04-05") },
        //    new Delivery { Id = 2, OrderId = 2, CourierId = 2, Status = DeliveryStatus.Pending, ActualDeliveryDate = DateTime.MinValue, EstimatedDeliveryDate = DateTime.Parse("2025-04-07"), CreatedAt = DateTime.Parse("2025-04-06") }
        //);
        #endregion
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        base.OnConfiguring(optionsBuilder);
    }

}
