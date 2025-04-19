using System;
using AstroPharm.Domain.Entities.Orders;
using AstroPharm.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;

namespace AstroPharm.Data.SeedData
{
    public class OrderDetailSeed
    {
        public static void SeedOrderDetails(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail
                {
                    Id = 1,
                    OrderId = 1,
                    MedicationId = 1,
                    PaymentId = 1,
                    Quantity = 2,
                    Discount = 1.50m, 
                    TotalAmount = 5.99m * 2 - 1.50m,
                },
                new OrderDetail
                {
                    Id = 2,
                    OrderId = 1,
                    MedicationId = 3,
                    PaymentId = 1,
                    Quantity = 1,
                    Discount = 0.99m,
                    TotalAmount = 8.99m - 0.99m, 
                },
                new OrderDetail
                {
                    Id = 3,
                    OrderId = 2,
                    MedicationId = 2,
                    PaymentId = 2,
                    Quantity = 3,
                    Discount = 2.00m, 
                    TotalAmount = 12.50m * 3 - 2.00m, 
                },
                new OrderDetail
                {
                    Id = 4,
                    OrderId = 3,
                    MedicationId = 4,
                    PaymentId = 3,
                    Quantity = 2,
                    Discount = 1.00m, 
                    TotalAmount = 15.99m * 2 - 1.00m, 
                }
            );
        }
    }
}
