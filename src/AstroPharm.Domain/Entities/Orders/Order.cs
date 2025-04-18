﻿using AstroPharm.Domain.Commons;
using AstroPharm.Domain.Entities.Users;

namespace AstroPharm.Domain.Entities.Orders;

public class Order : Auditable
{
    public long UserId { get; set; }
    public long TotalAmount { get; set; }
    public DateTime OrderDate { get; set; }
    //public long DeliveryId { get; set; }

    public virtual User User { get; set; }
    // public virtual Delivery Delivery { get; set; }
    public virtual ICollection<OrderDetail> OrderDetails { get; set; }
}   
