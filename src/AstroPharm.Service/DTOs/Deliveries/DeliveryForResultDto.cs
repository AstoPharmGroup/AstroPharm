using AstroPharm.Domain.Entities;
using AstroPharm.Domain.Enums;
using AstroPharm.Service.DTOs.Users;

namespace AstroPharm.Service.DTOs.Deliveries;

public class DeliveryForResultDto
{
    public long Id { get; set; }
    public long OrderId { get; set; }
    public long CourierId { get; set; }
    public DeliveryStatus Status { get; set; }
    public DateTime ActualDeliveryDate { get; set; }
    public DateTime EstimatedDeliveryDate { get; set; }

    public virtual OrderForResultDto Order { get; set; }
    public virtual UserForResultDto Courier { get; set; }
}
