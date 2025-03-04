using AstroPharm.Domain.Entities;

public class OrderForResultDto
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
    public long MedicationId { get; set; }
    public Medication Medication { get; set; }
    public long TotalAmount { get; set; }

}