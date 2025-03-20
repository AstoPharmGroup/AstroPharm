using AstroPharm.Domain.Entities.Delivery;

namespace AstroPharm.Domain.Entities.Pharmacy
{
    public class PharmacyBranch : Location
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public virtual ICollection<PharmacyStock> PharmacyStocks { get; set; }
    }
}
