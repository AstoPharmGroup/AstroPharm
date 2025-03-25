using AstroPharm.Domain.Commons;
using AstroPharm.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPharm.Domain.Entities;

public class Delivery : Auditable
{
    public long OrderId { get; set; }
    public long CourierId { get;set; }
    public DeliveryStatus Status { get; set; }
    public DateTime ActualDeliveryDate { get; set; }
    public DateTime EstimatedDeliveryDate { get; set; }

    public virtual Order Order { get; set; }
    public virtual User Courier { get; set; }

}
