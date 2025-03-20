using AstroPharm.Domain.Commons;
using AstroPharm.Domain.Entities.Pharmacy;

namespace AstroPharm.Domain.Entities;

public class CartItem : Auditable
{
    public int Count { get; set; }
    public long UserId { get; set; }
    public virtual User User { get; set; }
    public long MedicationId { get; set; }
    public virtual Medication Medication { get; set; }
}
