using AstroPharm.Domain.Commons;

namespace AstroPharm.Domain.Entities;

public class Category : Auditable
{
    public long CatalogId { get; set; }
    public virtual Catalog Catalog { get; set; }
    public string CategoryName { get; set; }
    public string Description { get; set; }
    public ICollection<Banner> Banners { get; set; }
    public ICollection<Medication> Medications { get; set; }
}
