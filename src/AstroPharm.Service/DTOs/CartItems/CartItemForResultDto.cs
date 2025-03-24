using AstroPharm.Domain.Entities;
using AstroPharm.Service.DTOs.Medications;
using AstroPharm.Service.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPharm.Service.DTOs.CartItems;

public class CartItemForResultDto
{
    public long Id { get; set; }
    public int Count { get; set; }
    public long UserId { get; set; }
    // public virtual UserForResultDto User { get; set; }
    public long MedicationId { get; set; }
    public virtual MedicationForResultDto Medication { get; set; }
}
