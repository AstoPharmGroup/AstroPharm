using AstroPharm.Domain.Commons;

namespace AstroPharm.Domain.Entities;

public class Banner : Auditable
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public long CategoryId { get; set; }
    public Category Category { get; set; }
    public long MedicationId { get; set; }
    public Medication Medication { get; set; }
}
