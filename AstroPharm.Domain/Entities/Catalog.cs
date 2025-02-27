using AstroPharm.Domain.Commons;

namespace AstroPharm.Domain.Entities;

public class Catalog : Auditable
{
    public string CatalogName { get; set; }
    public ICollection<Category> Categories { get; set; }
}
