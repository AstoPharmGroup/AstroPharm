using AstroPharm.Domain.Entities;
using AstroPharm.Service.DTOs.OrderDetails;

public class OrderForResultDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public long TotalAmount { get; set; }
    //public ICollection<OrderDetailForResultDto> OrderDetails { get; set; }

}