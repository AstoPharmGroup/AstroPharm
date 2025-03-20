using AstroPharm.Domain.Commons;
using AstroPharm.Domain.Entities.Pharmacy;

namespace AstroPharm.Domain.Entities;

public class Category : Auditable
{
    public long CatalogId { get; set; }
    public string Description { get; set; }
    public string CategoryName { get; set; }
    public virtual Catalog Catalog { get; set; }
    public virtual ICollection<Banner> Banners { get; set; }
    public virtual ICollection<Medication> Medications { get; set; }
}
