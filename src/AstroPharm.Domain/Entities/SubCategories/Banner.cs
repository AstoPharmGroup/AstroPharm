using AstroPharm.Domain.Commons;
using AstroPharm.Domain.Entities.Products;

namespace AstroPharm.Domain.Entities.SubCategories;

public class Banner : Auditable
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public long CategoryId { get; set; }
    public virtual Category Category { get; set; }
    public long MedicationId { get; set; }
    public virtual Medication Medication { get; set; }
}
