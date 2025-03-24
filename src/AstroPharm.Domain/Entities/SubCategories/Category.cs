using AstroPharm.Domain.Commons;
using AstroPharm.Domain.Entities.Products;

namespace AstroPharm.Domain.Entities.SubCategories;

public class Category : Auditable
{
    public long CatalogId { get; set; }
    public string Description { get; set; }
    public string CategoryName { get; set; }
    public virtual Catalog Catalog { get; set; }
    public virtual ICollection<Banner> Banners { get; set; }
    public virtual ICollection<Medication> Medications { get; set; }
}
