using AstroPharm.Service.DTOs.Catalogs;

namespace AstroPharm.Service.DTOs.Categories;

public class CategoryForResultDto
{
    public long Id { get; set; }
    public long CatalogId { get; set; }
    public string CategoryName { get; set; }
    public CatalogForResultDto Catalog { get; set; }
}
