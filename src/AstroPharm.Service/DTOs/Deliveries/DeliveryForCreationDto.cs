using AstroPharm.Domain.Enums;

namespace AstroPharm.Service.DTOs.Deliveries;

public class DeliveryForCreationDto
{
    public long OrderId { get; set; }
    public long CourierId { get; set; }
    public DateTime DeliveryTime { get; set; }
    public DeliveryStatus Status { get; set; }

    public long PharmacyBranchId { get; set; }
    public long MedicationId { get; set; }
    public int Quantity { get; set; }
}
