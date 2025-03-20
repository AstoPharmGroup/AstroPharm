using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPharm.Service.DTOs.PharmacyStocks
{
    public class PharmacyStockForUpdateDto
    {
        public long PharmacyBranchId { get; set; }
        public long MedicationId { get; set; }
        public int Quantity { get; set; }
    }
}
