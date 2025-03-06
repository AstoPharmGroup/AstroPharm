using AstroPharm.Domain.Entities;

public class OrderForResultDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public DateTime OrderDate { get; set; }
    public long TotalAmount { get; set; }

}