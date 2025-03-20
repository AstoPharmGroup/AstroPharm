using AstroPharm.Domain.Entities.Pharmacy;
using AstroPharm.Service.DTOs.PharmacyStocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPharm.Service.DTOs.PharmacyBranchs
{
    public class PharmacyBranchForResultDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
      //  public virtual ICollection<PharmacyStockForResult> PharmacyStocks { get; set; }
    }
}
