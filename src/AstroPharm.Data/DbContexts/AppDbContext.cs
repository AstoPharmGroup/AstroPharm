using AstroPharm.Domain.Entities;
using AstroPharm.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AstroPharm.Data.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    #region
    //public DbSet<User> Users { get; set; }
    //public DbSet<Order> Orders { get; set; }
    //public DbSet<Banner> Banners { get; set; }
    //public DbSet<Payment> Payments { get; set; }
    //public DbSet<Catalog> Catalogs { get; set; }
    //public DbSet<CartItem> CartItems { get; set; }
    //public DbSet<WishList> WishLists { get; set; }
    //public DbSet<Category> Categories { get; set; }
    //public DbSet<Medication> Medications { get; set; }
    //public DbSet<OrderDetail> OrderDetails { get; set; }
    //public DbSet<RefreshToken> RefreshTokens { get; set; }
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

        // // Banner -> Medication
        // modelBuilder.Entity<Banner>()
        //     .HasOne(b => b.Medication)
        //     .WithMany()
        //     .HasForeignKey(b => b.MedicationId)
        //     .OnDelete(DeleteBehavior.SetNull);

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
        #endregion
        #region Seed Data
        // Seeding Catalog
        // Replace Role.Customer with Role.User or another valid role
        modelBuilder.Entity<User>().HasData(
            new User { Id = 6, FirstName = "Alice", LastName = "Doe", Email = "alice@example.com", Password = "1234", Address = "123 Street", PhoneNumber = "1234567890", Role = Role.User },
            new User { Id = 2, FirstName = "Bob", LastName = "Smith", Email = "bob@example.com", Password = "1234", Address = "456 Avenue", PhoneNumber = "9876543210", Role = Role.User },
            new User { Id = 3, FirstName = "Charlie", LastName = "Brown", Email = "charlie@example.com", Password = "1234", Address = "789 Road", PhoneNumber = "1112223333", Role = Role.Admin },
            new User { Id = 4, FirstName = "David", LastName = "Johnson", Email = "david@example.com", Password = "1234", Address = "101 Highway", PhoneNumber = "4445556666", Role = Role.Admin },
            new User { Id = 5, FirstName = "Emma", LastName = "Wilson", Email = "emma@example.com", Password = "1234", Address = "202 Blvd", PhoneNumber = "7778889999", Role = Role.SuperAdmin }
        );

        modelBuilder.Entity<Catalog>().HasData(
            new Catalog { Id = 1, CatalogName = "Pharmaceuticals" }
        );

        // Seeding Category
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, CatalogId = 1, CategoryName = "Pain Relief", Description = "Medications for pain relief" }
        );

        // Seeding Medications
        modelBuilder.Entity<Medication>().HasData(
            new Medication { Id = 1, MedicationName = "Paracetamol", Description = "Pain reliever", Price = 5.99m, ExpiredDate = DateTime.UtcNow.AddYears(2), CategoryId = 1, Status = Status.mavjud, Image = "paracetamol.jpg" },
            new Medication { Id = 2, MedicationName = "Ibuprofen", Description = "Anti-inflammatory", Price = 7.49m, ExpiredDate = DateTime.UtcNow.AddYears(2), CategoryId = 1, Status = Status.mavjud, Image = "ibuprofen.jpg" },
            new Medication { Id = 3, MedicationName = "Aspirin", Description = "Blood thinner", Price = 4.99m, ExpiredDate = DateTime.UtcNow.AddYears(2), CategoryId = 1, Status = Status.mavjud, Image = "aspirin.jpg" },
            new Medication { Id = 4, MedicationName = "Amoxicillin", Description = "Antibiotic", Price = 12.99m, ExpiredDate = DateTime.UtcNow.AddYears(2), CategoryId = 1, Status = Status.mavjud, Image = "amoxicillin.jpg" },
            new Medication { Id = 5, MedicationName = "Cough Syrup", Description = "Cough suppressant", Price = 6.49m, ExpiredDate = DateTime.UtcNow.AddYears(2), CategoryId = 1, Status = Status.mavjud, Image = "coughsyrup.jpg" }
        );

        // Seeding Orders
        modelBuilder.Entity<Order>().HasData(
            new Order { Id = 1, UserId = 1, OrderDate = DateTime.UtcNow, TotalAmount = 30 },
            new Order { Id = 2, UserId = 2, OrderDate = DateTime.UtcNow, TotalAmount = 20 },
            new Order { Id = 3, UserId = 3, OrderDate = DateTime.UtcNow, TotalAmount = 15 },
            new Order { Id = 4, UserId = 4, OrderDate = DateTime.UtcNow, TotalAmount = 40 },
            new Order { Id = 5, UserId = 5, OrderDate = DateTime.UtcNow, TotalAmount = 50 }
        );

        // Seeding Payments
        modelBuilder.Entity<Payment>().HasData(
            new Payment { Id = 1, Amount = 30, PaymentDate = DateTime.UtcNow, PaymentMethod = PaymentMethod.cash, PaymentStatus = PaymentStatus.paid },
            new Payment { Id = 2, Amount = 20, PaymentDate = DateTime.UtcNow, PaymentMethod = PaymentMethod.card, PaymentStatus = PaymentStatus.paid },
            new Payment { Id = 3, Amount = 15, PaymentDate = DateTime.UtcNow, PaymentMethod = PaymentMethod.cash, PaymentStatus = PaymentStatus.paid },
            new Payment { Id = 4, Amount = 40, PaymentDate = DateTime.UtcNow, PaymentMethod = PaymentMethod.cash, PaymentStatus = PaymentStatus.paid },
            new Payment { Id = 5, Amount = 50, PaymentDate = DateTime.UtcNow, PaymentMethod = PaymentMethod.card, PaymentStatus = PaymentStatus.paid }
        );

        // Seeding OrderDetails
        modelBuilder.Entity<OrderDetail>().HasData(
            new OrderDetail { Id = 1, OrderId = 1, MedicationId = 1, Quantity = 2, TotalAmount = 12.00m, Discount = 0, PaymentId = 1 },
            new OrderDetail { Id = 2, OrderId = 2, MedicationId = 2, Quantity = 1, TotalAmount = 7.49m, Discount = 0, PaymentId = 2 },
            new OrderDetail { Id = 3, OrderId = 3, MedicationId = 3, Quantity = 3, TotalAmount = 15.00m, Discount = 0, PaymentId = 3 },
            new OrderDetail { Id = 4, OrderId = 4, MedicationId = 4, Quantity = 1, TotalAmount = 12.99m, Discount = 0, PaymentId = 4 },
            new OrderDetail { Id = 5, OrderId = 5, MedicationId = 5, Quantity = 4, TotalAmount = 25.96m, Discount = 0, PaymentId = 5 }
        );
        #endregion
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        base.OnConfiguring(optionsBuilder);
    }

}
