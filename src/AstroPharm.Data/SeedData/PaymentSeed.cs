using System;
using AstroPharm.Domain.Entities.Orders;
using AstroPharm.Domain.Entities.Products;
using AstroPharm.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace AstroPharm.Data.SeedData
{
    public class PaymentSeed
    {
        public static void SeedPayments(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>().HasData(
                new Payment
                {
                    Id = 1, // Explicitly setting Id
                    Amount = 1000.50m,
                    PaymentDate = new DateTime(2025, 4, 1),
                    PaymentStatus = PaymentStatus.paid, // Enum value for payment status
                    PaymentMethod = PaymentMethod.card, // Enum value for payment method
                },
                new Payment
                {
                    Id = 2, // Explicitly setting Id
                    Amount = 1500.75m,
                    PaymentDate = new DateTime(2025, 4, 2),
                    PaymentStatus = PaymentStatus.pending, // Enum value for payment status
                    PaymentMethod = PaymentMethod.card, // Enum value for payment method
                },
                new Payment
                {
                    Id = 3, // Explicitly setting Id
                    Amount = 700.00m,
                    PaymentDate = new DateTime(2025, 4, 3),
                    PaymentStatus = PaymentStatus.unpaid, // Enum value for payment status
                    PaymentMethod = PaymentMethod.cash, // Enum value for payment method
                }
            );
        }
    }
}
