using AstroPharm.Domain.Entities;
using AstroPharm.Service.DTOs.Catalogs;
using AstroPharm.Service.DTOs.Medications;

namespace AstroPharm.Service.DTOs.Categories;

public class CategoryForResultDto
{
    public long Id { get; set; }
    public long CatalogId { get; set; }
    public string Description { get; set; }
    public string CategoryName { get; set; }
    public CatalogForResultDto Catalog { get; set; }
    public List<MedicationForResultDto> Medications { get; set; }
}
