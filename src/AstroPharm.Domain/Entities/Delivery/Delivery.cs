using AstroPharm.Domain.Commons;
using AstroPharm.Domain.Enums;
using AstroPharm.Domain.Entities.Pharmacy;
using System;

namespace AstroPharm.Domain.Entities.Delivery
{
    public class Delivery : Auditable
    {
        public long OrderId { get; set; }
        public virtual Order Order { get; set; }

        public long CourierId { get; set; }
        public virtual Courier Courier { get; set; }

        public DateTime DeliveryTime { get; set; } // Yetkazib berishga ketadigan vaqt vaqti
        public DeliveryStatus Status { get; set; }

        public long PharmacyBranchId { get; set; } // Dorilar qayerdan olinishi
        public virtual PharmacyBranch PharmacyBranch { get; set; }

        public long MedicationId { get; set; }
        public virtual Medication Medication { get; set; }

        public int Quantity { get; set; }
    }
}
