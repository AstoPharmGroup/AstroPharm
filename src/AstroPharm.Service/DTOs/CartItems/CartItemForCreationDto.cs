using AstroPharm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstroPharm.Service.DTOs.CartItems;

public class CartItemForCreationDto
{
    public int Count { get; set; }
    public long UserId { get; set; }
    public long MedicationId { get; set; }
}

