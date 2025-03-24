using AstroPharm.Domain.Entities;

public class OrderDetailForResult
{
    public long Id { get; set; }
    public long Quantity { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalAmount { get; set; }
    public long OrderId { get; set; }
    public long MedicationId { get; set; }
    public long PaymentId { get; set; }
    
}