using AstroPharm.Domain.Entities;
using AstroPharm.Domain.Enums;

namespace AstroPharm.Service.DTOs.Deliveries;

public class DeliveryForCreationDto
{
    public long OrderId { get; set; }
    public long CourierId { get; set; }
    public DeliveryStatus Status { get; set; }
    public DateTime ActualDeliveryDate { get; set; }
    public DateTime EstimatedDeliveryDate { get; set; }

}
