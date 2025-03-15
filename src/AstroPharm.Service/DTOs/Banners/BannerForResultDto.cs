using AstroPharm.Domain.Entities;
using AstroPharm.Service.DTOs.Categories;
using AstroPharm.Service.DTOs.Medications;

namespace AstroPharm.Service.DTOs.Banners;

public class BannerForResultDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public virtual CategoryForResultDto Category { get; set; }
    public virtual MedicationForResultDto Medication { get; set; }
}
