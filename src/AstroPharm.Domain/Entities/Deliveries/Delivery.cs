using AstroPharm.Domain.Entities.Orders;
using AstroPharm.Domain.Entities.Users;

namespace AstroPharm.Domain.Entities.Deliveries;

public class Delivery
{
    public long OrderId { get; set; }
    public long UserId { get; set; } // ROle Curier
    public DateTime ActualDeliveryDate { get; set; }
    public DateTime EstimatedDeliveryDate { get; set; }

     // Realation
    public Order Order { get; set; }
    public User User { get; set; }

}
