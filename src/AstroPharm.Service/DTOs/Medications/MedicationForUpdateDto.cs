using AstroPharm.Domain.Entities;
using AstroPharm.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPharm.Service.DTOs.Medications
{
    public class MedicationForUpdateDto
    {
        public decimal Price { get; set; }
        public Status Status { get; set; }
        public long CategoryId { get; set; }
        public string Description { get; set; }
        public DateTime ExpiredDate { get; set; }
        public string MedicationName { get; set; }
        public string ImageUrl { get; set; }
    }
}
