using AstroPharm.Domain.Commons;
using AstroPharm.Domain.Entities.Delivery;
using AstroPharm.Domain.Entities.Pharmacy;

namespace AstroPharm.Domain.Entities;

public class Order : Location
{
    public long UserId { get; set; }
    public long TotalAmount { get; set; }
    public virtual User User { get; set; }
    public DateTime OrderDate { get; set; }
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
}
