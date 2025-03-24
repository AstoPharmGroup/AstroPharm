using AstroPharm.Domain.Commons;

namespace AstroPharm.Domain.Entities.Deliveries;

public class Location : Auditable
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
