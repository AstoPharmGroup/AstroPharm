using AstroPharm.Domain.Commons;

namespace AstroPharm.Domain.Entities;

public class Order : Auditable
{
    public long UserId { get; set; }
    public virtual User User { get; set; }
    public DateTime OrderDate { get; set; }
    public long TotalAmount { get; set; }

}
