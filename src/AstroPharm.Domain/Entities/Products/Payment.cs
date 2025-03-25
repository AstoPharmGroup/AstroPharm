using AstroPharm.Domain.Commons;
using AstroPharm.Domain.Entities.Orders;
using AstroPharm.Domain.Enums;

namespace AstroPharm.Domain.Entities.Products;

public class Payment : Auditable
{
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    //public virtual ICollection<OrderDetail> OrderDetails { get; set; }
}
