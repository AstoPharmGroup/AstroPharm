using AstroPharm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPharm.Service.DTOs.OrderDetails
{
    public class OrderDetailForUpdateDto
    {
        public long Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal TotalAmount { get; set; }
        public long OrderId { get; set; }
        public long MedicationId { get; set; }
        public long PaymentId { get; set; }
    }
}
