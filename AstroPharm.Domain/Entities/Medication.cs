using AstroPharm.Domain.Commons;
using AstroPharm.Domain.Enums;

namespace AstroPharm.Domain.Entities;

public class Medication : Auditable
{
    public string MedicationName { get; set; }
    public string Description { get; set; }
    public DateTime ExpiredDate { get; set; }   
    public decimal Price { get; set; }
    public  Status Status { get; set; }
    public ICollection<Order> Orders { get; set; }
}
