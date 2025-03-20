using AstroPharm.Domain.Entities.Pharmacy;
using AstroPharm.Service.DTOs.Medications;
using AstroPharm.Service.DTOs.PharmacyBranchs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPharm.Service.DTOs.PharmacyStocks
{
    public class PharmacyStockForResult
    {
        public long Id { get; set; }
        public long PharmacyBranchId { get; set; }
        public PharmacyBranchForResultDto PharmacyBranch { get; set; }

        public long MedicationId { get; set; }
        public MedicationForResultDto Medication { get; set; }

        public int Quantity { get; set; }
    }
}
