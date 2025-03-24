using AstroPharm.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPharm.Service.DTOs.Deliveries;

public class DeliveryForUpdateDto
{
    public long OrderId { get; set; }
    public long CourierId { get; set; }
    public DeliveryStatus Status { get; set; }
    public DateTime ActualDeliveryDate { get; set; }
    public DateTime EstimatedDeliveryDate { get; set; }
}
