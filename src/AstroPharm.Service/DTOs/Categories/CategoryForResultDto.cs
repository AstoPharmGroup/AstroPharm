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
<<<<<<< HEAD
    public CatalogForResultDto Catalog { get; set; }
=======
    public List<MedicationForResultDto> Medications { get; set; }
>>>>>>> 74b95a1ef7b0530fd50629725f818910c07d5482
}
