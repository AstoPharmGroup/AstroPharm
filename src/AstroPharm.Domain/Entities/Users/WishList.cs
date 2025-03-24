using AstroPharm.Domain.Commons;
using AstroPharm.Domain.Entities.Products;
using AstroPharm.Domain.Entities.Users;

namespace AstroPharm.Domain.Entities;

public class WishList : Auditable
{
    public long UserId { get; set; }
    public virtual User User { get; set; }
    public long MedicationId { get; set; }
    public virtual Medication Medication { get; set; }
}
