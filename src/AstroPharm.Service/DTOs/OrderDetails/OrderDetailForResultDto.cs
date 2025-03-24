using AstroPharm.Domain.Entities;
using AstroPharm.Service.DTOs.Medications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPharm.Service.DTOs.OrderDetails
{
    public class OrderDetailForResultDto
    {
        public long Id { get; set; }
        public long Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public long OrderId { get; set; }
        public virtual OrderForResultDto Order { get; set; }
        public long MedicationId { get; set; }
        public virtual MedicationForResultDto Medication { get; set; }
        public long PaymentId { get; set; }
        public virtual PaymentForResultDto Payment { get; set; }
    }
}
