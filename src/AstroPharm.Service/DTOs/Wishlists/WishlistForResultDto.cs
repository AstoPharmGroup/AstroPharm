using AstroPharm.Domain.Entities;

namespace AstroPharm.Service.DTOs.Wishlists;

public class WishlistForResultDto
{
    public long Id  { get; set; }
    public long UserId { get; set; }
    public long MedicationId { get; set; }
    public Medication Medication { get; set; }
}
