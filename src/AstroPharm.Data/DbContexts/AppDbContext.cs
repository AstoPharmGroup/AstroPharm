using AstroPharm.Domain.Entities;
using AstroPharm.Domain.Entities.Delivery;
using AstroPharm.Domain.Entities.Pharmacy;
using AstroPharm.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace AstroPharm.Data.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Banner> Banners { get; set; }
    public DbSet<Courier> Couriers { get; set; }

    public DbSet<Payment> Payments { get; set; }
    public DbSet<Catalog> Catalogs { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<WishList> WishLists { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Delivery> Deliveries { get; set; }
    public DbSet<Medication> Medications { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<PharmacyStock> PharmacyStocks { get; set; }
    public DbSet<PharmacyBranch> PharmacyBranches { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //Ralations
        #region
        // Catalog -> Category
        //modelBuilder.Entity<Catalog>()
        //    .HasMany(c => c.Categories)
        //    .WithOne(c => c.Catalog)
        //    .HasForeignKey(c => c.CatalogId)
        //    .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<Banner>().HasOne(b => b.Category).WithMany(c => c.Banners).HasForeignKey(b => b.CategoryId);
        modelBuilder.Entity<Banner>().HasOne(b => b.Medication).WithMany().HasForeignKey(b => b.MedicationId);

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
        // Seed Data
        #region

        // Seed Users
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, FirstName = "Zuc", LastName = "Smith", Email = "zuc@example.com", Password = "hashedpassword", PhoneNumber = "1234567890", Role = Role.User },
            new User { Id = 2, FirstName = "Van", LastName = "Doe", Email = "van@example.com", Password = "hashedpassword", PhoneNumber = "0987654321", Role = Role.User }
        );

        // Seed Catalogs
        modelBuilder.Entity<Catalog>().HasData(
            new Catalog { Id = 1, CatalogName = "General Health" }
        );

        // Seed Categories
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, CategoryName = "Pain Relief", Description = "Pain relief medications", CatalogId = 1 },
            new Category { Id = 2, CategoryName = "Cold & Flu", Description = "Cold and flu medications", CatalogId = 1 }
        );

        // Seed Medications
        modelBuilder.Entity<Medication>().HasData(
            new Medication { Id = 1, MedicationName = "Ibuprofen", CategoryId = 1, Price = 10.0M, Description = "Pain reliever", ExpiredDate = new DateTime(2026, 03, 19), Status = Status.mavjud, Image = "/medications/247cf17a-2ef9-4514-92dc-9b3dae8dee0d.jfif" },
            new Medication { Id = 2, MedicationName = "Paracetamol", CategoryId = 1, Price = 5.0M, Description = "Fever reducer", ExpiredDate = new DateTime(2026, 03, 19), Status = Status.mavjud, Image = "/medications/247cf17a-2ef9-4514-92dc-9b3dae8dee0d.jfif" }
        );

        // Seed Orders
        modelBuilder.Entity<Order>().HasData(
            new Order { Id = 1, UserId = 1, TotalAmount = 20, OrderDate = new DateTime(2025, 03, 19) }
        );

        // Seed Payments
        modelBuilder.Entity<Payment>().HasData(
            new Payment { Id = 1, Amount = 20.0M, PaymentDate = new DateTime(2025, 03, 19), PaymentStatus = PaymentStatus.paid, PaymentMethod = PaymentMethod.cash }
        );

        // Seed OrderDetails 
        modelBuilder.Entity<OrderDetail>().HasData(
            new OrderDetail { Id = 1, PaymentId = 1, OrderId = 1, MedicationId = 1, Quantity = 1, Discount = 0, TotalAmount = 10 }
        );


        // Seed CartItems 
        modelBuilder.Entity<CartItem>().HasData(
            new CartItem { Id = 1, UserId = 1, MedicationId = 1, Count = 2 }
        );

        // Seed WishLists
        modelBuilder.Entity<WishList>().HasData(
            new WishList { Id = 1, UserId = 2, MedicationId = 2 }
        );

        // Seed Banners
        modelBuilder.Entity<Banner>().HasData(
            new Banner { Id = 1, Title = "Special Offer", Description = "Discount on pain relief", Image = "media/banners/f1659118-b313-44f6-84a3-ed1520d1c123.jpg", CategoryId = 1, MedicationId = 1 },
            new Banner { Id = 2, Title = "Winter Sale", Description = "Cold & Flu sale", Image = "media/banners/f1659118-b313-44f6-84a3-ed1520d1c123.jpg", CategoryId = 2, MedicationId = 2 }
        );

        #endregion
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        base.OnConfiguring(optionsBuilder);
    }

}
