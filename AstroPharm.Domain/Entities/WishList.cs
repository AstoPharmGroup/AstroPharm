using AstroPharm.Domain.Commons;

namespace AstroPharm.Domain.Entities;

public class WishList : Auditable
{
    public long UserId { get; set; }
    public User User { get; set; }
    public long MedicationId { get; set; }
    public Medication Medication { get; set; }
}
