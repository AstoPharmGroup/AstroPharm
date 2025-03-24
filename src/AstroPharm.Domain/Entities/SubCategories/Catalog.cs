using AstroPharm.Domain.Commons;

namespace AstroPharm.Domain.Entities.SubCategories;

public class Catalog : Auditable
{
    public string CatalogName { get; set; }

    // Realation
    public virtual ICollection<Category> Categories { get; set; }
}
