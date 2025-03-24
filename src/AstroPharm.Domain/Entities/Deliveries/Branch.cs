using AstroPharm.Domain.Commons;

namespace AstroPharm.Domain.Entities.Deliveries;

public class Branch : Auditable
{
    public string BranchName { get; set; }
    public long LocationId { get; set; }
    public Location Location { get; set; }
}
