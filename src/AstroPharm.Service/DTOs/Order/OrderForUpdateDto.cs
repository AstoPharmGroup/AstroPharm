using AstroPharm.Domain.Entities;

public class OrderForUpdateDto
{
    public long UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public long TotalAmount { get; set; }
}