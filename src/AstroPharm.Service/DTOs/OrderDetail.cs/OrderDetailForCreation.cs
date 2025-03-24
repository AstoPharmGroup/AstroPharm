using AstroPharm.Domain.Entities;

public class OrderDetailForCreation
{
    public long Quantity { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalAmount { get; set; }
    public long OrderId { get; set; }
    public long MedicationId { get; set; }
    public long PaymentId { get; set; }
    
    public virtual Order Order { get; set; }
    public virtual Payment Payment { get; set; }
    public virtual Medication Medication { get; set; }
}