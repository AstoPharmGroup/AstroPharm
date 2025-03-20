using AstroPharm.Domain.Commons;

namespace AstroPharm.Domain.Entities.Pharmacy;

public class PharmacyStock : Auditable
{
    public long PharmacyBranchId { get; set; }
    public virtual PharmacyBranch PharmacyBranch { get; set; }

    public long MedicationId { get; set; }
    public virtual Medication Medication { get; set; }

    public int Quantity { get; set; }
}

