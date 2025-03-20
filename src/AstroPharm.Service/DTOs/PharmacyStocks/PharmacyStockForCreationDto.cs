using AstroPharm.Domain.Entities.Pharmacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPharm.Service.DTOs.PharmacyStocks
{
    public class PharmacyStockForCreationDto
    {
        public long PharmacyBranchId { get; set; }
        public long MedicationId { get; set; }
        public int Quantity { get; set; }
    }
}
