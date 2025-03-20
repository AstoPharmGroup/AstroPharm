using AstroPharm.Domain.Enums;

using AstroPharm.Service.DTOs.Couriers;
using AstroPharm.Service.DTOs.PharmacyBranchs;
using AstroPharm.Service.DTOs.Medications;

namespace AstroPharm.Service.DTOs.Deliveries;

public class DeliveryForResultDto
{
    public long Id { get; set; }
    public long OrderId { get; set; }
    public long CourierId { get; set; }
    public DateTime DeliveryTime { get; set; }
    public DeliveryStatus Status { get; set; }

    public long PharmacyBranchId { get; set; }
    public long MedicationId { get; set; }
    public int Quantity { get; set; }

    public CourierForResultDto Courier { get; set; }
    public OrderForResultDto Order { get; set; }
    public PharmacyBranchForResultDto pharmacyBranch { get; set; }

    public MedicationForResultDto Medication { get; set; }
}
