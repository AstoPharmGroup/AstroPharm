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
    public DateTime DeliveryTime { get; set; }
    public DeliveryStatus Status { get; set; }

    public long PharmacyBranchId { get; set; }
    public long MedicationId { get; set; }
    public int Quantity { get; set; }
}
