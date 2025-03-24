using AstroPharm.Domain.Commons;
using AstroPharm.Domain.Entities.Products;

namespace AstroPharm.Domain.Entities.Orders;

public class OrderDetail : Auditable
{
    public long Quantity { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalAmount { get; set; }
    public long OrderId { get; set; }
    public virtual Order Order { get; set; }
    public long MedicationId { get; set; }
    public virtual Medication Medication { get; set; }
    public long PaymentId { get; set; }
    public virtual Payment Payment { get; set; }
}
