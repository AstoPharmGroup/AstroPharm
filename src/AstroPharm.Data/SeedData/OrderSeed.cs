using System;
using Microsoft.EntityFrameworkCore;
using AstroPharm.Domain.Entities.Orders;

namespace AstroPharm.Data.SeedData
{
    public class OrderSeed
    {
        public static void SeedOrders(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasData(
                new Order
                {
                    Id = 1,
                    UserId = 1,
                    TotalAmount = 1000,
                    OrderDate = new DateTime(2025, 4, 1)
                },
                new Order
                {
                    Id = 2,
                    UserId = 2,
                    TotalAmount = 1500,
                    OrderDate = new DateTime(2025, 4, 2)
                },
                new Order
                {
                    Id = 3,
                    UserId = 3,
                    TotalAmount = 700,
                    OrderDate = new DateTime(2025, 4, 3)
                }
            );
        }
    }
}
