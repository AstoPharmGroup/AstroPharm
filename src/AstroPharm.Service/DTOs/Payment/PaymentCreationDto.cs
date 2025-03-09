using AstroPharm.Domain.Entities;
using AstroPharm.Domain.Enums;

public class PaymentCreationDto
{
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
}