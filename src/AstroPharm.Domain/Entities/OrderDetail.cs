using AstroPharm.Domain.Commons;

namespace AstroPharm.Domain.Entities;

public class OrderDetail : Auditable
{
    public long Quantity { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalAmount { get; set; }
    public long OrderId { get; set; }
    public Order Order { get; set; }
    public long MedicationId { get; set; }
    public Medication Medication { get; set; }
    public long PaymentId { get; set; }
    public Payment Payment { get; set; }
}
